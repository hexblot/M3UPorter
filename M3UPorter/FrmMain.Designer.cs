namespace M3UPorter
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.txtM3UPath = new System.Windows.Forms.TextBox();
            this.pbS1A = new System.Windows.Forms.PictureBox();
            this.pbS3A = new System.Windows.Forms.PictureBox();
            this.pbS3D = new System.Windows.Forms.PictureBox();
            this.pbS1D = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnOutputDir = new System.Windows.Forms.Button();
            this.txtOutputDir = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.grpStep2 = new System.Windows.Forms.GroupBox();
            this.pbS2D = new System.Windows.Forms.PictureBox();
            this.pbS2A = new System.Windows.Forms.PictureBox();
            this.grpStep1 = new System.Windows.Forms.GroupBox();
            this.cbPrependNum = new System.Windows.Forms.CheckBox();
            this.cbMoveFiles = new System.Windows.Forms.CheckBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.grpStep3 = new System.Windows.Forms.GroupBox();
            this.optionsForm = new System.Windows.Forms.Panel();
            this.progressForm = new System.Windows.Forms.Panel();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblProgressText = new System.Windows.Forms.Label();
            this.pgbProgress = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.endResultsForm = new System.Windows.Forms.Panel();
            this.btnEndResultsOK = new System.Windows.Forms.Button();
            this.txtEndReport = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbS1A)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbS3A)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbS3D)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbS1D)).BeginInit();
            this.grpStep2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbS2D)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbS2A)).BeginInit();
            this.grpStep1.SuspendLayout();
            this.grpStep3.SuspendLayout();
            this.optionsForm.SuspendLayout();
            this.progressForm.SuspendLayout();
            this.endResultsForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Location = new System.Drawing.Point(6, 19);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(275, 23);
            this.btnLoadFile.TabIndex = 0;
            this.btnLoadFile.Text = "Load File ...";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // txtM3UPath
            // 
            this.txtM3UPath.Enabled = false;
            this.txtM3UPath.Location = new System.Drawing.Point(6, 58);
            this.txtM3UPath.Name = "txtM3UPath";
            this.txtM3UPath.Size = new System.Drawing.Size(275, 20);
            this.txtM3UPath.TabIndex = 1;
            // 
            // pbS1A
            // 
            this.pbS1A.Enabled = false;
            this.pbS1A.Image = ((System.Drawing.Image)(resources.GetObject("pbS1A.Image")));
            this.pbS1A.Location = new System.Drawing.Point(310, 53);
            this.pbS1A.Name = "pbS1A";
            this.pbS1A.Size = new System.Drawing.Size(32, 32);
            this.pbS1A.TabIndex = 4;
            this.pbS1A.TabStop = false;
            this.pbS1A.Visible = false;
            // 
            // pbS3A
            // 
            this.pbS3A.Enabled = false;
            this.pbS3A.Image = ((System.Drawing.Image)(resources.GetObject("pbS3A.Image")));
            this.pbS3A.Location = new System.Drawing.Point(310, 300);
            this.pbS3A.Name = "pbS3A";
            this.pbS3A.Size = new System.Drawing.Size(32, 32);
            this.pbS3A.TabIndex = 4;
            this.pbS3A.TabStop = false;
            this.pbS3A.Visible = false;
            // 
            // pbS3D
            // 
            this.pbS3D.Enabled = false;
            this.pbS3D.Image = ((System.Drawing.Image)(resources.GetObject("pbS3D.Image")));
            this.pbS3D.Location = new System.Drawing.Point(310, 300);
            this.pbS3D.Name = "pbS3D";
            this.pbS3D.Size = new System.Drawing.Size(32, 32);
            this.pbS3D.TabIndex = 4;
            this.pbS3D.TabStop = false;
            this.pbS3D.Visible = false;
            // 
            // pbS1D
            // 
            this.pbS1D.Enabled = false;
            this.pbS1D.Image = ((System.Drawing.Image)(resources.GetObject("pbS1D.Image")));
            this.pbS1D.Location = new System.Drawing.Point(310, 53);
            this.pbS1D.Name = "pbS1D";
            this.pbS1D.Size = new System.Drawing.Size(32, 32);
            this.pbS1D.TabIndex = 4;
            this.pbS1D.TabStop = false;
            this.pbS1D.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "m3u8";
            this.openFileDialog1.Filter = "M3U(8) Playlists|*.m3u8;*.m3u|All files (*.*)|*.*";
            this.openFileDialog1.Title = "Select M3U Playlist";
            // 
            // btnOutputDir
            // 
            this.btnOutputDir.Location = new System.Drawing.Point(6, 28);
            this.btnOutputDir.Name = "btnOutputDir";
            this.btnOutputDir.Size = new System.Drawing.Size(275, 23);
            this.btnOutputDir.TabIndex = 0;
            this.btnOutputDir.Text = "Select output directory";
            this.btnOutputDir.UseVisualStyleBackColor = true;
            this.btnOutputDir.Click += new System.EventHandler(this.btnOutputDir_Click);
            // 
            // txtOutputDir
            // 
            this.txtOutputDir.Enabled = false;
            this.txtOutputDir.Location = new System.Drawing.Point(6, 66);
            this.txtOutputDir.Name = "txtOutputDir";
            this.txtOutputDir.Size = new System.Drawing.Size(275, 20);
            this.txtOutputDir.TabIndex = 1;
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // grpStep2
            // 
            this.grpStep2.Controls.Add(this.btnOutputDir);
            this.grpStep2.Controls.Add(this.txtOutputDir);
            this.grpStep2.Location = new System.Drawing.Point(12, 123);
            this.grpStep2.Name = "grpStep2";
            this.grpStep2.Size = new System.Drawing.Size(287, 100);
            this.grpStep2.TabIndex = 0;
            this.grpStep2.TabStop = false;
            this.grpStep2.Text = "Step 2. Select output location";
            // 
            // pbS2D
            // 
            this.pbS2D.Enabled = false;
            this.pbS2D.Image = ((System.Drawing.Image)(resources.GetObject("pbS2D.Image")));
            this.pbS2D.Location = new System.Drawing.Point(310, 162);
            this.pbS2D.Name = "pbS2D";
            this.pbS2D.Size = new System.Drawing.Size(32, 32);
            this.pbS2D.TabIndex = 8;
            this.pbS2D.TabStop = false;
            this.pbS2D.Visible = false;
            // 
            // pbS2A
            // 
            this.pbS2A.Enabled = false;
            this.pbS2A.Image = ((System.Drawing.Image)(resources.GetObject("pbS2A.Image")));
            this.pbS2A.Location = new System.Drawing.Point(310, 162);
            this.pbS2A.Name = "pbS2A";
            this.pbS2A.Size = new System.Drawing.Size(32, 32);
            this.pbS2A.TabIndex = 9;
            this.pbS2A.TabStop = false;
            this.pbS2A.Visible = false;
            // 
            // grpStep1
            // 
            this.grpStep1.Controls.Add(this.btnLoadFile);
            this.grpStep1.Controls.Add(this.txtM3UPath);
            this.grpStep1.Location = new System.Drawing.Point(12, 21);
            this.grpStep1.Name = "grpStep1";
            this.grpStep1.Size = new System.Drawing.Size(287, 91);
            this.grpStep1.TabIndex = 0;
            this.grpStep1.TabStop = false;
            this.grpStep1.Text = "Step 1. Select input playlist";
            // 
            // cbPrependNum
            // 
            this.cbPrependNum.AutoSize = true;
            this.cbPrependNum.Location = new System.Drawing.Point(6, 30);
            this.cbPrependNum.Name = "cbPrependNum";
            this.cbPrependNum.Size = new System.Drawing.Size(206, 17);
            this.cbPrependNum.TabIndex = 0;
            this.cbPrependNum.Text = "Prepend playlist number to copied files";
            this.cbPrependNum.UseVisualStyleBackColor = true;
            // 
            // cbMoveFiles
            // 
            this.cbMoveFiles.AutoSize = true;
            this.cbMoveFiles.Location = new System.Drawing.Point(6, 55);
            this.cbMoveFiles.Name = "cbMoveFiles";
            this.cbMoveFiles.Size = new System.Drawing.Size(189, 17);
            this.cbMoveFiles.TabIndex = 1;
            this.cbMoveFiles.Text = "Move files instead of copying them";
            this.cbMoveFiles.UseVisualStyleBackColor = true;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(6, 91);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(275, 23);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Go!";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // grpStep3
            // 
            this.grpStep3.Controls.Add(this.btnGo);
            this.grpStep3.Controls.Add(this.cbMoveFiles);
            this.grpStep3.Controls.Add(this.cbPrependNum);
            this.grpStep3.Enabled = false;
            this.grpStep3.Location = new System.Drawing.Point(12, 234);
            this.grpStep3.Name = "grpStep3";
            this.grpStep3.Size = new System.Drawing.Size(287, 129);
            this.grpStep3.TabIndex = 1;
            this.grpStep3.TabStop = false;
            this.grpStep3.Text = "Step 3. Select options and run";
            // 
            // optionsForm
            // 
            this.optionsForm.Controls.Add(this.grpStep1);
            this.optionsForm.Controls.Add(this.pbS2A);
            this.optionsForm.Controls.Add(this.grpStep2);
            this.optionsForm.Controls.Add(this.pbS3A);
            this.optionsForm.Controls.Add(this.grpStep3);
            this.optionsForm.Controls.Add(this.pbS3D);
            this.optionsForm.Controls.Add(this.pbS1A);
            this.optionsForm.Controls.Add(this.pbS2D);
            this.optionsForm.Controls.Add(this.pbS1D);
            this.optionsForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsForm.Location = new System.Drawing.Point(0, 0);
            this.optionsForm.Name = "optionsForm";
            this.optionsForm.Size = new System.Drawing.Size(354, 387);
            this.optionsForm.TabIndex = 0;
            // 
            // progressForm
            // 
            this.progressForm.Controls.Add(this.btnStop);
            this.progressForm.Controls.Add(this.lblProgressText);
            this.progressForm.Controls.Add(this.pgbProgress);
            this.progressForm.Controls.Add(this.lblProgress);
            this.progressForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressForm.Location = new System.Drawing.Point(0, 0);
            this.progressForm.Name = "progressForm";
            this.progressForm.Size = new System.Drawing.Size(354, 387);
            this.progressForm.TabIndex = 13;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(96, 354);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(162, 23);
            this.btnStop.TabIndex = 20;
            this.btnStop.Text = "Stop!";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblProgressText
            // 
            this.lblProgressText.Location = new System.Drawing.Point(12, 171);
            this.lblProgressText.Name = "lblProgressText";
            this.lblProgressText.Size = new System.Drawing.Size(330, 19);
            this.lblProgressText.TabIndex = 2;
            this.lblProgressText.Text = "progress";
            this.lblProgressText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pgbProgress
            // 
            this.pgbProgress.Location = new System.Drawing.Point(12, 141);
            this.pgbProgress.Name = "pgbProgress";
            this.pgbProgress.Size = new System.Drawing.Size(330, 23);
            this.pgbProgress.Step = 1;
            this.pgbProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pgbProgress.TabIndex = 1;
            // 
            // lblProgress
            // 
            this.lblProgress.Location = new System.Drawing.Point(12, 123);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(330, 20);
            this.lblProgress.TabIndex = 0;
            this.lblProgress.Text = "Please wait, performing operation...";
            // 
            // endResultsForm
            // 
            this.endResultsForm.Controls.Add(this.txtEndReport);
            this.endResultsForm.Controls.Add(this.btnEndResultsOK);
            this.endResultsForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.endResultsForm.Location = new System.Drawing.Point(0, 0);
            this.endResultsForm.Name = "endResultsForm";
            this.endResultsForm.Size = new System.Drawing.Size(354, 387);
            this.endResultsForm.TabIndex = 15;
            // 
            // btnEndResultsOK
            // 
            this.btnEndResultsOK.Location = new System.Drawing.Point(96, 354);
            this.btnEndResultsOK.Name = "btnEndResultsOK";
            this.btnEndResultsOK.Size = new System.Drawing.Size(162, 23);
            this.btnEndResultsOK.TabIndex = 21;
            this.btnEndResultsOK.Text = "OK";
            this.btnEndResultsOK.UseVisualStyleBackColor = true;
            this.btnEndResultsOK.Click += new System.EventHandler(this.btnEndResultsOK_Click);
            // 
            // txtEndReport
            // 
            this.txtEndReport.Location = new System.Drawing.Point(12, 21);
            this.txtEndReport.Multiline = true;
            this.txtEndReport.Name = "txtEndReport";
            this.txtEndReport.Size = new System.Drawing.Size(330, 318);
            this.txtEndReport.TabIndex = 22;
            // 
            // FrmMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 387);
            this.Controls.Add(this.endResultsForm);
            this.Controls.Add(this.progressForm);
            this.Controls.Add(this.optionsForm);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(370, 545);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(370, 425);
            this.Name = "FrmMain";
            this.Text = "M3UPorter";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.FrmMain_HelpButtonClicked);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FrmMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FrmMain_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.pbS1A)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbS3A)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbS3D)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbS1D)).EndInit();
            this.grpStep2.ResumeLayout(false);
            this.grpStep2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbS2D)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbS2A)).EndInit();
            this.grpStep1.ResumeLayout(false);
            this.grpStep1.PerformLayout();
            this.grpStep3.ResumeLayout(false);
            this.grpStep3.PerformLayout();
            this.optionsForm.ResumeLayout(false);
            this.progressForm.ResumeLayout(false);
            this.endResultsForm.ResumeLayout(false);
            this.endResultsForm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadFile;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.TextBox txtM3UPath;
        private System.Windows.Forms.PictureBox pbS1A;
        private System.Windows.Forms.PictureBox pbS3A;
        private System.Windows.Forms.PictureBox pbS3D;
        private System.Windows.Forms.PictureBox pbS1D;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnOutputDir;
        private System.Windows.Forms.TextBox txtOutputDir;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox grpStep2;
        private System.Windows.Forms.PictureBox pbS2D;
        private System.Windows.Forms.PictureBox pbS2A;
        private System.Windows.Forms.GroupBox grpStep1;
        private System.Windows.Forms.CheckBox cbPrependNum;
        private System.Windows.Forms.CheckBox cbMoveFiles;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.GroupBox grpStep3;
        private System.Windows.Forms.Panel optionsForm;
        private System.Windows.Forms.Panel progressForm;
        private System.Windows.Forms.Label lblProgressText;
        private System.Windows.Forms.ProgressBar pgbProgress;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Panel endResultsForm;
        private System.Windows.Forms.Button btnEndResultsOK;
        private System.Windows.Forms.TextBox txtEndReport;
    }
}

