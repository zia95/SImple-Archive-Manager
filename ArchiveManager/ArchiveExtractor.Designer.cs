namespace ArchiveManager
{
    partial class ArchiveExtractor
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
            this.pbarTotalProgress = new System.Windows.Forms.ProgressBar();
            this.lbCurrentExtractingEntry = new System.Windows.Forms.Label();
            this.btClose = new System.Windows.Forms.Button();
            this.tmrProgressUpdater = new System.Windows.Forms.Timer(this.components);
            this.bwExtraction = new System.ComponentModel.BackgroundWorker();
            this.lbExtractionProgress = new System.Windows.Forms.Label();
            this.lbEntryExtractProgress = new System.Windows.Forms.Label();
            this.pbarEntryExtractProgress = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // pbarTotalProgress
            // 
            this.pbarTotalProgress.Location = new System.Drawing.Point(20, 12);
            this.pbarTotalProgress.Name = "pbarTotalProgress";
            this.pbarTotalProgress.Size = new System.Drawing.Size(250, 10);
            this.pbarTotalProgress.TabIndex = 0;
            // 
            // lbCurrentExtractingEntry
            // 
            this.lbCurrentExtractingEntry.AutoSize = true;
            this.lbCurrentExtractingEntry.Location = new System.Drawing.Point(17, 51);
            this.lbCurrentExtractingEntry.Name = "lbCurrentExtractingEntry";
            this.lbCurrentExtractingEntry.Size = new System.Drawing.Size(113, 13);
            this.lbCurrentExtractingEntry.TabIndex = 2;
            this.lbCurrentExtractingEntry.Text = "Currently Extracting: ---";
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(195, 99);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 3;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // tmrProgressUpdater
            // 
            this.tmrProgressUpdater.Enabled = true;
            this.tmrProgressUpdater.Tick += new System.EventHandler(this.tmrProgressUpdater_Tick);
            // 
            // bwExtraction
            // 
            this.bwExtraction.WorkerSupportsCancellation = true;
            this.bwExtraction.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwExtraction_DoWork);
            this.bwExtraction.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwExtraction_RunWorkerCompleted);
            // 
            // lbExtractionProgress
            // 
            this.lbExtractionProgress.AutoSize = true;
            this.lbExtractionProgress.Location = new System.Drawing.Point(17, 25);
            this.lbExtractionProgress.Name = "lbExtractionProgress";
            this.lbExtractionProgress.Size = new System.Drawing.Size(83, 13);
            this.lbExtractionProgress.TabIndex = 4;
            this.lbExtractionProgress.Text = "Progress: 0.00%";
            // 
            // lbEntryExtractProgress
            // 
            this.lbEntryExtractProgress.AutoSize = true;
            this.lbEntryExtractProgress.Location = new System.Drawing.Point(17, 80);
            this.lbEntryExtractProgress.Name = "lbEntryExtractProgress";
            this.lbEntryExtractProgress.Size = new System.Drawing.Size(83, 13);
            this.lbEntryExtractProgress.TabIndex = 6;
            this.lbEntryExtractProgress.Text = "Progress: 0.00%";
            // 
            // pbarEntryExtractProgress
            // 
            this.pbarEntryExtractProgress.Location = new System.Drawing.Point(20, 67);
            this.pbarEntryExtractProgress.Name = "pbarEntryExtractProgress";
            this.pbarEntryExtractProgress.Size = new System.Drawing.Size(250, 10);
            this.pbarEntryExtractProgress.TabIndex = 5;
            // 
            // ArchiveExtractor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 130);
            this.Controls.Add(this.lbEntryExtractProgress);
            this.Controls.Add(this.pbarEntryExtractProgress);
            this.Controls.Add(this.lbExtractionProgress);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.lbCurrentExtractingEntry);
            this.Controls.Add(this.pbarTotalProgress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ArchiveExtractor";
            this.Text = "ArchiveExtractor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ArchiveExtractor_FormClosing);
            this.Load += new System.EventHandler(this.ArchiveExtractor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbarTotalProgress;
        private System.Windows.Forms.Label lbCurrentExtractingEntry;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Timer tmrProgressUpdater;
        private System.ComponentModel.BackgroundWorker bwExtraction;
        private System.Windows.Forms.Label lbExtractionProgress;
        private System.Windows.Forms.Label lbEntryExtractProgress;
        private System.Windows.Forms.ProgressBar pbarEntryExtractProgress;
    }
}