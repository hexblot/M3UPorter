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
            this.pgbProgress = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbS1A)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbS3A)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbS3D)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbS1D)).BeginInit();
            this.grpStep2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbS2D)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbS2A)).BeginInit();
            this.grpStep1.SuspendLayout();
            this.grpStep3.SuspendLayout();
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
            this.txtM3UPath.TabIndex = 3;
            // 
            // pbS1A
            // 
            this.pbS1A.Enabled = false;
            this.pbS1A.Image = ((System.Drawing.Image)(resources.GetObject("pbS1A.Image")));
            this.pbS1A.Location = new System.Drawing.Point(310, 50);
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
            this.pbS3A.Location = new System.Drawing.Point(310, 299);
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
            this.pbS3D.Location = new System.Drawing.Point(310, 299);
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
            this.pbS1D.Location = new System.Drawing.Point(310, 50);
            this.pbS1D.Name = "pbS1D";
            this.pbS1D.Size = new System.Drawing.Size(32, 32);
            this.pbS1D.TabIndex = 4;
            this.pbS1D.TabStop = false;
            this.pbS1D.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "m3u";
            this.openFileDialog1.Filter = "M3U Playlists|*.m3u";
            this.openFileDialog1.Title = "Select M3U Playlist";
            // 
            // btnOutputDir
            // 
            this.btnOutputDir.Location = new System.Drawing.Point(6, 28);
            this.btnOutputDir.Name = "btnOutputDir";
            this.btnOutputDir.Size = new System.Drawing.Size(275, 23);
            this.btnOutputDir.TabIndex = 5;
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
            this.txtOutputDir.TabIndex = 3;
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // grpStep2
            // 
            this.grpStep2.Controls.Add(this.btnOutputDir);
            this.grpStep2.Controls.Add(this.txtOutputDir);
            this.grpStep2.Location = new System.Drawing.Point(12, 119);
            this.grpStep2.Name = "grpStep2";
            this.grpStep2.Size = new System.Drawing.Size(287, 100);
            this.grpStep2.TabIndex = 7;
            this.grpStep2.TabStop = false;
            this.grpStep2.Text = "Step 2. Select output location";
            // 
            // pbS2D
            // 
            this.pbS2D.Enabled = false;
            this.pbS2D.Image = ((System.Drawing.Image)(resources.GetObject("pbS2D.Image")));
            this.pbS2D.Location = new System.Drawing.Point(310, 161);
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
            this.pbS2A.Location = new System.Drawing.Point(310, 161);
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
            this.grpStep1.Location = new System.Drawing.Point(12, 13);
            this.grpStep1.Name = "grpStep1";
            this.grpStep1.Size = new System.Drawing.Size(287, 100);
            this.grpStep1.TabIndex = 10;
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
            this.cbMoveFiles.TabIndex = 0;
            this.cbMoveFiles.Text = "Move files instead of copying them";
            this.cbMoveFiles.UseVisualStyleBackColor = true;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(6, 91);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(275, 23);
            this.btnGo.TabIndex = 7;
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
            this.grpStep3.Location = new System.Drawing.Point(12, 244);
            this.grpStep3.Name = "grpStep3";
            this.grpStep3.Size = new System.Drawing.Size(287, 129);
            this.grpStep3.TabIndex = 6;
            this.grpStep3.TabStop = false;
            this.grpStep3.Text = "Step 3. Select options and run";
            // 
            // pgbProgress
            // 
            this.pgbProgress.Location = new System.Drawing.Point(12, 170);
            this.pgbProgress.Name = "pgbProgress";
            this.pgbProgress.Size = new System.Drawing.Size(330, 23);
            this.pgbProgress.Step = 1;
            this.pgbProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pgbProgress.TabIndex = 11;
            this.pgbProgress.Visible = false;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(12, 152);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(172, 13);
            this.lblProgress.TabIndex = 12;
            this.lblProgress.Text = "Please wait, performing operation...";
            this.lblProgress.Visible = false;
            // 
            // FrmMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 387);
            this.Controls.Add(this.grpStep1);
            this.Controls.Add(this.pbS2A);
            this.Controls.Add(this.grpStep2);
            this.Controls.Add(this.grpStep3);
            this.Controls.Add(this.pbS3A);
            this.Controls.Add(this.pbS3D);
            this.Controls.Add(this.pbS1A);
            this.Controls.Add(this.pbS1D);
            this.Controls.Add(this.pbS2D);
            this.Controls.Add(this.pgbProgress);
            this.Controls.Add(this.lblProgress);
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
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.ProgressBar pgbProgress;
        private System.Windows.Forms.Label lblProgress;
    }
}

