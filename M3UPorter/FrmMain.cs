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

        /// <summary>
        /// Saved value of last progress report received from the worker thread.
        /// </summary>
        ProgressReport _lastProgressReport = new ProgressReport(0, 0, 0, 0, String.Empty);

        public FrmMain()
        {
            InitializeComponent();
            pbS1A.Visible = true;
            pbS2A.Visible = true;

            _ShowOptionsForm();

            LoadSettings();

            // Create a background worker to prevent "Not responsive" when writing to slow media such as USB sticks
            bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += new DoWorkEventHandler(DoWork);

            // what to do when progress changed (update the progress bar for example)
            bw.ProgressChanged += new ProgressChangedEventHandler(OnProgressChanged);

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

            _ShowProgressForm();
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
            _ShowEndResultsForm();
            btnEndResultsOK.Focus();

            if (args.Cancelled)
            {
                txtEndReport.Text = String.Format( 
                    "Cancelled!\r\n\r\n"
                    + "  {0}/{1} files copied\r\n",
                    _lastProgressReport.FilesCopied,
                    _lastProgressReport.TotalFiles );
            }
            else if (args.Error != null)
            {
                // There was an error during the operation. 
                string msg = String.Format("Unexpected Error:\n{0}", args.Error.ToString() );
                txtEndReport.Text = msg;
            }
            else
            {
                CopyResult copyResult = (CopyResult)args.Result;

                StringBuilder reportBuilder = new StringBuilder();
                reportBuilder.AppendLine("Operation Complete!");
                reportBuilder.AppendLine("");

                if (_lastProgressReport.FilesCopied == _lastProgressReport.TotalFiles)
                {
                    reportBuilder.AppendFormat( "  {0} files copied\r\n", _lastProgressReport.FilesCopied );
                }
                else
                {
                    reportBuilder.AppendFormat("  {0}/{1} files copied\r\n",
                        _lastProgressReport.FilesCopied,
                        _lastProgressReport.TotalFiles);
                }
                
                if (_lastProgressReport.FilesSkipped > 0)
                {
                    reportBuilder.AppendFormat("  {0} not found\r\n", _lastProgressReport.FilesSkipped);
                }

                if (copyResult == CopyResult.OUT_OF_SPACE)
                {
                    reportBuilder.AppendFormat("  destination device is full.");
                }
                
                txtEndReport.Text = reportBuilder.ToString();
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
            int nCopied = 0;
            int nSkipped = 0;
            int i = 0; // number of files processed

            foreach (Pair<string, string> pair in tasks)
            {
                i++;

                if (bw.CancellationPending)
                {
                    args.Cancel = true;
                    return;
                }

                ProgressReport report = new ProgressReport(nCopied, nSkipped, i, total, pair.Right);
                bw.ReportProgress(i / total, report);

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
                    ++nCopied;
                }
                catch (FileNotFoundException)
                {
                    // Do nothing, just skip the file
                    ++nSkipped;
                }
                catch (DirectoryNotFoundException)
                {
                    ++nSkipped;
                }
                catch (IOException ioe)
                {
                    // delete the partial output file if it exists
                    File.Delete(pair.Right);

                    // If it's an "out of space" exception, exit quietly
                    if ((ioe.HResult & 0xffff) == ERROR_DISK_FULL)
                    {
                        args.Result = CopyResult.OUT_OF_SPACE;
                        return; // ** quick exit ** Finished early.
                    }

                    throw; // otherwise, exit noisily
                }
                catch (Exception)
                {
                    // delete the output file on the assumption that it's incomplete
                    File.Delete(pair.Right);
                    throw;
                }
            }

            args.Result = CopyResult.SUCCESS; // no exceptions or ANYTHING.
        }

        void OnProgressChanged(object o, ProgressChangedEventArgs args)
        {
            ProgressReport report = (ProgressReport)args.UserState;
            if (null == report) // Huh?
                return;

            _lastProgressReport = report;

            int progress = (int)(((float)report.Processed / (float)report.TotalFiles) * 90);
            pgbProgress.Value = progress + 10;

            string missingReport;
            if (report.FilesSkipped <= 0)
                missingReport = String.Empty;
            else
                missingReport = String.Format(" ({0} not found)", report.FilesSkipped);

            lblProgressText.Text =
                String.Format("{0}/{1}{2}", report.Processed, report.TotalFiles, missingReport);

            lblCurrentAction.Text = Path.GetFileName( report.CurrentFileName );
        }

        private void btnEndResultsOK_Click(object sender, EventArgs e)
        {
            _ShowOptionsForm();
            btnLoadFile.Focus();
        }

        void _ShowEndResultsForm()
        {
            optionsForm.Hide();
            progressForm.Hide(); // TODO: show final results form?
            endResultsForm.Show();
        }

        void _ShowOptionsForm()
        {
            optionsForm.Show();
            progressForm.Hide(); // TODO: show final results form?
            endResultsForm.Hide();
        }

        void _ShowProgressForm()
        {
            optionsForm.Hide();
            progressForm.Show(); // TODO: show final results form?
            endResultsForm.Hide();
        }
    }
}

