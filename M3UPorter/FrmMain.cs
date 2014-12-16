using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

using M3UPorter.Properties; // for Settings

namespace M3UPorter
{
    public partial class FrmMain : Form
    {
        // Interesting IOException HRESULT codes
        protected static readonly int ERROR_DISK_FULL = (0x70);

        readonly BackgroundWorker bw;

        public FrmMain()
        {
            InitializeComponent();
            pbS1A.Visible = true;
            pbS2A.Visible = true;

            optionsForm.Show();
            progressForm.Hide();

            LoadSettings();

            // Create a background worker to prevent "Not responsive" when writing to slow media such as USB sticks
            bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += new DoWorkEventHandler(DoWork);

            // what to do when progress changed (update the progress bar for example)
            bw.ProgressChanged += new ProgressChangedEventHandler(
            delegate(object o, ProgressChangedEventArgs args)
            {
                pgbProgress.Value = args.ProgressPercentage + 10;
                if (null != args.UserState)
                    lblProgressText.Text = (String)args.UserState;
            });

            // what to do when worker completes its task (notify the user)
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(WorkerCompleted);
        }

        private void LoadSettings()
        {
            txtM3UPath.Text = Settings.Default.LastPlaylistFilePath;
            txtOutputDir.Text = Settings.Default.LastOutputPath;
            cbPrependNum.Checked = Settings.Default.DoPrependNumber;
        }

        private void SaveSettings()
        {
            Settings.Default.LastPlaylistFilePath = txtM3UPath.Text;
            Settings.Default.LastOutputPath = txtOutputDir.Text;
            Settings.Default.DoPrependNumber = cbPrependNum.Checked;
            Settings.Default.Save();
        }

        private void FrmMain_DragDrop(object sender, DragEventArgs e)
        {
            string[] filenames = e.Data.GetData(DataFormats.FileDrop, true) as string[];
            foreach (string filename in filenames)
            {
                txtM3UPath.Text = System.IO.Path.GetFullPath(filename);
                pbS1A.Visible = false;
                pbS1D.Visible = true;
                if (pbS2D.Visible)
                {
                    pbS3A.Visible = true;
                    grpStep3.Enabled = true;
                }
            }
        }

        // Disable drop target for non-M3U files on entering
        private void FrmMain_DragEnter(object sender, DragEventArgs e)
        {
            bool dropEnabled = true;

            if (e.Data.GetDataPresent(DataFormats.FileDrop, true)) {
                string[] filenames = e.Data.GetData(DataFormats.FileDrop, true) as string[];

                foreach (string filename in filenames) {
                    //MessageBox.Show(System.IO.Path.GetExtension(filename).ToUpperInvariant());
                    if (System.IO.Path.GetExtension(filename).ToUpperInvariant() != ".M3U" || System.IO.Path.GetExtension(filename).ToUpperInvariant() != ".M3U8")
                    {
                        dropEnabled = false;
                        break;
                    }
                }
            } else {
                dropEnabled = false;
            }

            if (!dropEnabled) {
                e.Effect = DragDropEffects.None;
            } else {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.FileName = Path.GetFileName(txtM3UPath.Text);
            }
            catch (Exception)
            {
                openFileDialog1.FileName = "";
            }

            try
            {
                openFileDialog1.InitialDirectory = Path.GetDirectoryName(txtM3UPath.Text);
            }
            catch (Exception)
            {
            }

            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtM3UPath.Text = openFileDialog1.FileName;
                pbS1A.Visible = false;
                pbS1D.Visible = true;
                if (pbS2D.Visible)
                {
                    pbS3A.Visible = true;
                    grpStep3.Enabled = true;
                }
            }

            btnOutputDir.Focus();
        }

        private void btnOutputDir_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = txtOutputDir.Text;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtOutputDir.Text = folderBrowserDialog1.SelectedPath;
            }

            pbS2A.Visible = false;
            pbS2D.Visible = true;
            if (pbS1D.Visible)
            {
                pbS3A.Visible = true;
                grpStep3.Enabled = true;
            }

            cbPrependNum.Focus();
        }

        private void FrmMain_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            new AboutBox1().Show();
            e.Cancel = true;
        }

        private void btnGo_Click(object sender, EventArgs ea)
        {
            SaveSettings();

            btnGo.Enabled = false;
            optionsForm.Hide();
            progressForm.Show();
            btnStop.Focus();

            // First process the playlist file
            List<Pair<String, String> > tasks = new List<Pair<String, String> >();

            lblProgressText.Text = "reading m3u";
            try
            {
                using (StreamReader sr = new StreamReader(txtM3UPath.Text, System.Text.Encoding.UTF8, true))
                {
                    while (true)
                    {
                        String line = sr.ReadLine();
                        if (null == line)
                            break;

                        if (!line.StartsWith("#") && !line.StartsWith("http"))
                        {
                            // tasks.Add(new KeyValuePair<String,String>(line, String.Empty));
                            tasks.Add(new Pair<String, string>(line, String.Empty));
                        }
                    }                       
                }

                pgbProgress.Value = 5;
            }
            catch (Exception e)
            {
                MessageBox.Show("The playlist file could not be read" + e.ToString());
            }

            // Now that we know how many files there are,
            // calculate the destination paths, optionally with prefix

            try
            {
                // Calculate prefix length (power of 10?)
                int nFiles = tasks.Count;
                int prefixLength = (int)Math.Floor(Math.Log10((long)nFiles * 10));
                Debug.Assert(prefixLength > 0);
                String prefixFormat = String.Format("D{0}", prefixLength);

                // Convert relative paths to absolute if necessary
                int i = 1; // prefix index
                foreach (Pair<string, string> pair in tasks)
                {
                    string line = pair.Left;

                    // source

                    if (!System.IO.Path.IsPathRooted(line))
                    {
                        pair.Left = Path.Combine( System.IO.Path.GetDirectoryName(txtM3UPath.Text), line );
                    }

                    // destination

                    String basename = System.IO.Path.GetFileName(line);
                    if (cbPrependNum.Checked)
                    {
                        basename = i.ToString(prefixFormat) + " - " + basename;
                    } 
                    pair.Right = Path.Combine(txtOutputDir.Text, basename);  // TODO detect destination filename reuse?
                    
                    i++;
                }

                pgbProgress.Value = 10;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error computing the destination file names: " + e.ToString());
            }

            bw.RunWorkerAsync(tasks);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            bw.CancelAsync();
        }


        void WorkerCompleted(object o, RunWorkerCompletedEventArgs args)
        {
            btnGo.Enabled = true;
            optionsForm.Show();
            progressForm.Hide(); // TODO: show final results form?

            if (args.Cancelled)
            {
                // The user canceled the operation. The user knows this, so don't report it.
            }
            else if (args.Error != null)
            {
                // There was an error during the operation. 
                string msg = String.Format("Error: {0}", args.Error.Message);
                MessageBox.Show(msg);
            }
            else
            {
                MessageBox.Show("Operation complete!");
            }
        }

        /// <summary>
        /// Background file copy delegate
        /// </summary>
        void DoWork(object o, DoWorkEventArgs args)
        {
            List<Pair<String,String> > tasks = (List<Pair<String,String> >)args.Argument;
            BackgroundWorker bw = o as BackgroundWorker;
            int total = tasks.Count;
            int i = 0;

            foreach (Pair<string, string> pair in tasks)
            {
                i++;

                if (bw.CancellationPending)
                {
                    args.Cancel = true;
                    return;
                }

                int progress = (int)(((float)i / (float)total) * 90);
                try
                {
                    if (cbMoveFiles.Checked) // TODO: this is probably not thread safe
                    {
                        System.IO.File.Move(pair.Left, pair.Right);
                    }
                    else
                    {
                        System.IO.File.Copy(pair.Left, pair.Right, true);
                    }
                    bw.ReportProgress(progress, String.Format("{0}/{1}", i, total));
                }
                catch (FileNotFoundException)
                {
                    // Do nothing, just skip the file
                    bw.ReportProgress(progress, String.Format("{0}/{1} (missing)", i, total));
                }
                catch (IOException ioe)
                {
                    bw.ReportProgress(progress, String.Format("{0}/{1} (IO error)", i, total));

                    // delete the output file if it exists
                    File.Delete(pair.Right);

                    // If it's an "out of space" exception, exit quietly
                    if ((ioe.HResult & 0xffff) == ERROR_DISK_FULL)
                        break;

                    throw;
                }
                catch (Exception)
                {
                    bw.ReportProgress(progress, String.Format("{0}/{1} (error)", i, total));

                    // delete the output file on the assumption that it's incomplete
                    File.Delete(pair.Right);
                }
            }
        }
    }

}

