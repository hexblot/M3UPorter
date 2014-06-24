using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            pbS1D.Visible = !pbS1D.Visible;
            pbS2D.Visible = !pbS2D.Visible;
            pbS3A.Visible = !pbS3A.Visible;
        }

        private void btnGo_Click(object sender, EventArgs ea)
        {
            btnGo.Enabled = false;
            // First process the playlist file
            Dictionary<string, string> tasks = new Dictionary<string, string>();
            switch_state();

            try
            {
                using (StreamReader sr = new StreamReader(txtM3UPath.Text, System.Text.Encoding.UTF8, true))
                {
                    String line = "";
                    
                    int i = 1;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (!line.StartsWith("#") && !line.StartsWith("http"))
                        {
                            // Convert relative paths to absolute if necessary
                            if (!System.IO.Path.IsPathRooted(line))
                            {
                                line = System.IO.Path.GetDirectoryName(txtM3UPath.Text) + System.IO.Path.DirectorySeparatorChar + line;
                            }
                            String prefix;
                            if (cbPrependNum.Checked) { prefix = i.ToString("D3") + " - "; } else { prefix = ""; }

                            String destination = txtOutputDir.Text + System.IO.Path.DirectorySeparatorChar + prefix + System.IO.Path.GetFileName(line);
                            i++;

                            tasks.Add(line, destination);
                        }
                    }                       
                }

                pgbProgress.Value = 10;

            }
            catch (Exception e)
            {
                MessageBox.Show("The playlist file could not be read" + e.ToString());
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

                foreach (KeyValuePair<string, string> pair in tasks)
                {
                    try
                    {
                        if (cbMoveFiles.Checked)
                        {
                            System.IO.File.Move(pair.Key, pair.Value);
                        }
                        else
                        {
                            System.IO.File.Copy(pair.Key, pair.Value, true);
                        }
                    }
                    catch (FileNotFoundException e)
                    {
                        // Do nothing, just skip the file
                    }
                    int progress = (int) (((float)i / (float) total) * 90);
                    b.ReportProgress(progress); 
                    i++;
                }
                
            });

            // what to do when progress changed (update the progress bar for example)
            bw.ProgressChanged += new ProgressChangedEventHandler(
            delegate(object o, ProgressChangedEventArgs args)
            {
                pgbProgress.Value = args.ProgressPercentage+10;
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
