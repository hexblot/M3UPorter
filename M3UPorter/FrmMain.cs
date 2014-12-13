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

namespace M3UPorter
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            pbS1A.Visible = true;
            pbS2A.Visible = true;
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
           DialogResult result = openFileDialog1.ShowDialog();
           if (result == DialogResult.OK)
           {
               txtM3UPath.Text = openFileDialog1.FileName;
               pbS1A.Visible = false;
               pbS1D.Visible = true;
               if (pbS2D.Visible) { 
                   pbS3A.Visible = true;
                   grpStep3.Enabled = true;
               }
           }
        }

        private void btnOutputDir_Click(object sender, EventArgs e)
        {
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

        }

        private void FrmMain_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            new AboutBox1().Show();
            e.Cancel = true;
        }

        private void switch_state()
        {
            // Switches from progress bar state to control state
            grpStep1.Visible = !grpStep1.Visible;
            grpStep2.Visible = !grpStep2.Visible;
            grpStep3.Visible = !grpStep3.Visible;
            pgbProgress.Visible = !pgbProgress.Visible;
            lblProgress.Visible = !lblProgress.Visible;
            lblProgressText.Visible = !lblProgressText.Visible;
            pbS1D.Visible = !pbS1D.Visible;
            pbS2D.Visible = !pbS2D.Visible;
            pbS3A.Visible = !pbS3A.Visible;
        }

        private void btnGo_Click(object sender, EventArgs ea)
        {
            btnGo.Enabled = false;
            // First process the playlist file
            List<Pair<String, String> > tasks = new List<Pair<String, String> >();
            switch_state();

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

                pgbProgress.Value = 5;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error computing the destination file names: " + e.ToString());
            }

            // Create a background worker to prevent "Not responsive" when writing to slow media such as USB sticks
            BackgroundWorker bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;


            bw.DoWork += new DoWorkEventHandler(
            delegate(object o, DoWorkEventArgs args)
            {
                BackgroundWorker b = o as BackgroundWorker;
                int total = tasks.Count;
                int i = 1;

                foreach (Pair<string, string> pair in tasks)
                {
                    try
                    {
                        if (cbMoveFiles.Checked)
                        {
                            System.IO.File.Move(pair.Left, pair.Right);
                        }
                        else
                        {
                            System.IO.File.Copy(pair.Left, pair.Right, true);
                        }
                    }
                    catch (FileNotFoundException)
                    {
                        // Do nothing, just skip the file
                    }
                    int progress = (int) (((float)i / (float) total) * 90);
                    b.ReportProgress(progress, String.Format("{0}/{1}", i, total)); 
                    i++;
                }
                
            });

            // what to do when progress changed (update the progress bar for example)
            bw.ProgressChanged += new ProgressChangedEventHandler(
            delegate(object o, ProgressChangedEventArgs args)
            {
                pgbProgress.Value = args.ProgressPercentage+10;
                if (null != args.UserState)
                    lblProgressText.Text = (String)args.UserState;
            });

            // what to do when worker completes its task (notify the user)
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
            delegate(object o, RunWorkerCompletedEventArgs args)
            {
                btnGo.Enabled = true;
                switch_state();
                MessageBox.Show("Operation complete!");
            });

            bw.RunWorkerAsync();

                 
        }
    }
}
