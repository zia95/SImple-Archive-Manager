namespace ArchiveManager
{
    partial class ArchiveWriter
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.cbArchiveType = new System.Windows.Forms.ComboBox();
            this.gboxArchiveCreateSettings = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbArchivePath = new System.Windows.Forms.TextBox();
            this.tbArchiveExtension = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbArchiveName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbArchiveCompression = new System.Windows.Forms.ComboBox();
            this.gboxProgress = new System.Windows.Forms.GroupBox();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.lbProgress = new System.Windows.Forms.Label();
            this.btClose = new System.Windows.Forms.Button();
            this.btCreateArchive = new System.Windows.Forms.Button();
            this.bwArchiveCreate = new System.ComponentModel.BackgroundWorker();
            this.tmrUpdateProgress = new System.Windows.Forms.Timer(this.components);
            this.gboxArchiveCreateSettings.SuspendLayout();
            this.gboxProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Archive Type:";
            // 
            // cbArchiveType
            // 
            this.cbArchiveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbArchiveType.FormattingEnabled = true;
            this.cbArchiveType.Location = new System.Drawing.Point(100, 17);
            this.cbArchiveType.Name = "cbArchiveType";
            this.cbArchiveType.Size = new System.Drawing.Size(250, 21);
            this.cbArchiveType.TabIndex = 5;
            this.cbArchiveType.SelectedIndexChanged += new System.EventHandler(this.cbArchiveType_SelectedIndexChanged);
            // 
            // gboxArchiveCreateSettings
            // 
            this.gboxArchiveCreateSettings.Controls.Add(this.label4);
            this.gboxArchiveCreateSettings.Controls.Add(this.tbArchivePath);
            this.gboxArchiveCreateSettings.Controls.Add(this.tbArchiveExtension);
            this.gboxArchiveCreateSettings.Controls.Add(this.label3);
            this.gboxArchiveCreateSettings.Controls.Add(this.tbArchiveName);
            this.gboxArchiveCreateSettings.Controls.Add(this.label2);
            this.gboxArchiveCreateSettings.Controls.Add(this.cbArchiveCompression);
            this.gboxArchiveCreateSettings.Controls.Add(this.label1);
            this.gboxArchiveCreateSettings.Controls.Add(this.cbArchiveType);
            this.gboxArchiveCreateSettings.Location = new System.Drawing.Point(12, 12);
            this.gboxArchiveCreateSettings.Name = "gboxArchiveCreateSettings";
            this.gboxArchiveCreateSettings.Size = new System.Drawing.Size(360, 135);
            this.gboxArchiveCreateSettings.TabIndex = 6;
            this.gboxArchiveCreateSettings.TabStop = false;
            this.gboxArchiveCreateSettings.Text = "Settings";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Archive Path:";
            // 
            // tbArchivePath
            // 
            this.tbArchivePath.Location = new System.Drawing.Point(100, 101);
            this.tbArchivePath.Name = "tbArchivePath";
            this.tbArchivePath.ReadOnly = true;
            this.tbArchivePath.Size = new System.Drawing.Size(250, 20);
            this.tbArchivePath.TabIndex = 11;
            // 
            // tbArchiveExtension
            // 
            this.tbArchiveExtension.Location = new System.Drawing.Point(311, 71);
            this.tbArchiveExtension.Name = "tbArchiveExtension";
            this.tbArchiveExtension.ReadOnly = true;
            this.tbArchiveExtension.Size = new System.Drawing.Size(39, 20);
            this.tbArchiveExtension.TabIndex = 10;
            this.tbArchiveExtension.TextChanged += new System.EventHandler(this.tbArchiveExtension_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Archive Name:";
            // 
            // tbArchiveName
            // 
            this.tbArchiveName.Location = new System.Drawing.Point(100, 71);
            this.tbArchiveName.Name = "tbArchiveName";
            this.tbArchiveName.Size = new System.Drawing.Size(205, 20);
            this.tbArchiveName.TabIndex = 8;
            this.tbArchiveName.Text = "New Archive";
            this.tbArchiveName.TextChanged += new System.EventHandler(this.tbArchiveName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Compression:";
            // 
            // cbArchiveCompression
            // 
            this.cbArchiveCompression.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbArchiveCompression.FormattingEnabled = true;
            this.cbArchiveCompression.Location = new System.Drawing.Point(100, 44);
            this.cbArchiveCompression.Name = "cbArchiveCompression";
            this.cbArchiveCompression.Size = new System.Drawing.Size(250, 21);
            this.cbArchiveCompression.TabIndex = 7;
            // 
            // gboxProgress
            // 
            this.gboxProgress.Controls.Add(this.pbProgress);
            this.gboxProgress.Controls.Add(this.lbProgress);
            this.gboxProgress.Location = new System.Drawing.Point(12, 153);
            this.gboxProgress.Name = "gboxProgress";
            this.gboxProgress.Size = new System.Drawing.Size(360, 70);
            this.gboxProgress.TabIndex = 7;
            this.gboxProgress.TabStop = false;
            this.gboxProgress.Text = "Write Progress";
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(13, 19);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(337, 23);
            this.pbProgress.TabIndex = 1;
            // 
            // lbProgress
            // 
            this.lbProgress.AutoSize = true;
            this.lbProgress.Location = new System.Drawing.Point(11, 45);
            this.lbProgress.Name = "lbProgress";
            this.lbProgress.Size = new System.Drawing.Size(83, 13);
            this.lbProgress.TabIndex = 0;
            this.lbProgress.Text = "Progress: 0.00%";
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(287, 230);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 8;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btCreateArchive
            // 
            this.btCreateArchive.Location = new System.Drawing.Point(181, 230);
            this.btCreateArchive.Name = "btCreateArchive";
            this.btCreateArchive.Size = new System.Drawing.Size(100, 23);
            this.btCreateArchive.TabIndex = 9;
            this.btCreateArchive.Text = "Create Archive";
            this.btCreateArchive.UseVisualStyleBackColor = true;
            this.btCreateArchive.Click += new System.EventHandler(this.btCreateArchive_Click);
            // 
            // bwArchiveCreate
            // 
            this.bwArchiveCreate.WorkerSupportsCancellation = true;
            this.bwArchiveCreate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwArchiveCreate_DoWork);
            this.bwArchiveCreate.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwArchiveCreate_RunWorkerCompleted);
            // 
            // tmrUpdateProgress
            // 
            this.tmrUpdateProgress.Tick += new System.EventHandler(this.tmrUpdateProgress_Tick);
            // 
            // ArchiveWriter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 264);
            this.Controls.Add(this.btCreateArchive);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.gboxProgress);
            this.Controls.Add(this.gboxArchiveCreateSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ArchiveWriter";
            this.Text = "ArchiveCreator";
            this.Load += new System.EventHandler(this.ArchiveCreator_Load);
            this.gboxArchiveCreateSettings.ResumeLayout(false);
            this.gboxArchiveCreateSettings.PerformLayout();
            this.gboxProgress.ResumeLayout(false);
            this.gboxProgress.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbArchiveType;
        private System.Windows.Forms.GroupBox gboxArchiveCreateSettings;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbArchivePath;
        private System.Windows.Forms.TextBox tbArchiveExtension;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbArchiveName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbArchiveCompression;
        private System.Windows.Forms.GroupBox gboxProgress;
        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.Label lbProgress;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btCreateArchive;
        private System.ComponentModel.BackgroundWorker bwArchiveCreate;
        private System.Windows.Forms.Timer tmrUpdateProgress;
    }
}