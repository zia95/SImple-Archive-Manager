namespace ArchiveManager
{
    partial class MainForm
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
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openArchiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAllFromDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.archiveCreatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.archiveExtractorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ofAddFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ofAddArchiveDialog = new System.Windows.Forms.OpenFileDialog();
            this.bfDirectorySelectDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.lstFileExplorer = new ArchiveManager.FileArchiveExplorer();
            this.menuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(475, 24);
            this.menuMain.TabIndex = 0;
            this.menuMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openArchiveToolStripMenuItem,
            this.addFileToolStripMenuItem,
            this.addAllFromDirectoryToolStripMenuItem,
            this.addDirectoryToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.fileToolStripMenuItem_DropDownItemClicked);
            // 
            // openArchiveToolStripMenuItem
            // 
            this.openArchiveToolStripMenuItem.Name = "openArchiveToolStripMenuItem";
            this.openArchiveToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.openArchiveToolStripMenuItem.Text = "Open Archive";
            // 
            // addFileToolStripMenuItem
            // 
            this.addFileToolStripMenuItem.Name = "addFileToolStripMenuItem";
            this.addFileToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.addFileToolStripMenuItem.Text = "Add File";
            // 
            // addAllFromDirectoryToolStripMenuItem
            // 
            this.addAllFromDirectoryToolStripMenuItem.Name = "addAllFromDirectoryToolStripMenuItem";
            this.addAllFromDirectoryToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.addAllFromDirectoryToolStripMenuItem.Text = "Add All From Directory";
            // 
            // addDirectoryToolStripMenuItem
            // 
            this.addDirectoryToolStripMenuItem.Name = "addDirectoryToolStripMenuItem";
            this.addDirectoryToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.addDirectoryToolStripMenuItem.Text = "Add Directory";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeSelectedToolStripMenuItem,
            this.clearListToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.editToolStripMenuItem_DropDownItemClicked);
            // 
            // removeSelectedToolStripMenuItem
            // 
            this.removeSelectedToolStripMenuItem.Name = "removeSelectedToolStripMenuItem";
            this.removeSelectedToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.removeSelectedToolStripMenuItem.Text = "Remove Selected";
            // 
            // clearListToolStripMenuItem
            // 
            this.clearListToolStripMenuItem.Name = "clearListToolStripMenuItem";
            this.clearListToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.clearListToolStripMenuItem.Text = "Clear List";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archiveCreatorToolStripMenuItem,
            this.archiveExtractorToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            this.toolsToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolsToolStripMenuItem_DropDownItemClicked);
            // 
            // archiveCreatorToolStripMenuItem
            // 
            this.archiveCreatorToolStripMenuItem.Name = "archiveCreatorToolStripMenuItem";
            this.archiveCreatorToolStripMenuItem.Size = new System.Drawing.Size(281, 22);
            this.archiveCreatorToolStripMenuItem.Text = "Create a new archive of added files/dirs";
            // 
            // archiveExtractorToolStripMenuItem
            // 
            this.archiveExtractorToolStripMenuItem.Name = "archiveExtractorToolStripMenuItem";
            this.archiveExtractorToolStripMenuItem.Size = new System.Drawing.Size(281, 22);
            this.archiveExtractorToolStripMenuItem.Text = "Extract opened archive";
            // 
            // ofAddFileDialog
            // 
            this.ofAddFileDialog.Filter = "All Files (*.*) | *.*";
            this.ofAddFileDialog.Multiselect = true;
            this.ofAddFileDialog.Title = "Add File(s)";
            // 
            // ofAddArchiveDialog
            // 
            this.ofAddArchiveDialog.Title = "Open Archive";
            // 
            // bfDirectorySelectDialog
            // 
            this.bfDirectorySelectDialog.Description = "Select a directory";
            // 
            // lstFileExplorer
            // 
            this.lstFileExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFileExplorer.Location = new System.Drawing.Point(0, 24);
            this.lstFileExplorer.Name = "lstFileExplorer";
            this.lstFileExplorer.ShowTreeView = true;
            this.lstFileExplorer.Size = new System.Drawing.Size(475, 214);
            this.lstFileExplorer.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 238);
            this.Controls.Add(this.lstFileExplorer);
            this.Controls.Add(this.menuMain);
            this.MainMenuStrip = this.menuMain;
            this.Name = "MainForm";
            this.Text = "Archive Manager";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private FileArchiveExplorer lstFileExplorer;
        private System.Windows.Forms.ToolStripMenuItem openArchiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addAllFromDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addDirectoryToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog ofAddFileDialog;
        private System.Windows.Forms.OpenFileDialog ofAddArchiveDialog;
        private System.Windows.Forms.FolderBrowserDialog bfDirectorySelectDialog;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem archiveCreatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem archiveExtractorToolStripMenuItem;
    }
}

