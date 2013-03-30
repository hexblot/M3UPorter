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
                    if (System.IO.Path.GetExtension(filename).ToUpperInvariant() != ".M3U") {
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

        private void btnGo_Click(object sender, EventArgs ea)
        {
            btnGo.Enabled = false;

            try
            {
                using (StreamReader sr = new StreamReader(txtM3UPath.Text, Encoding.Default))
                {
                    String line = "";
                    int i = 1;
                    while((line = sr.ReadLine()) != null) { 
                        if (!line.StartsWith("#") && !line.StartsWith("http")) {

                            // Convert relative paths to absolute if necessary
                            if (!System.IO.Path.IsPathRooted(line))
                            {
                                line = System.IO.Path.GetDirectoryName(txtM3UPath.Text) + System.IO.Path.DirectorySeparatorChar + line;
                            }
                            String prefix;
                            if (cbPrependNum.Checked) { prefix = i.ToString("D3") + " - "; } else { prefix = ""; }

                            String destination = txtOutputDir.Text + System.IO.Path.DirectorySeparatorChar + prefix + System.IO.Path.GetFileName(line);
                            
                            if ( cbMoveFiles.Checked ) { 
                                System.IO.File.Move(line, destination);
                            } else {
                                System.IO.File.Copy(line, destination, true);
                            }

                            i++;                            
                        }
                    }

                    btnGo.Enabled = true;
                    MessageBox.Show("Operation complete!");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("The playlist file could not be read" + e.ToString());
            }
        }
    }
}
