namespace ArchiveManager
{
    partial class FileArchiveExplorer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstExplorer = new System.Windows.Forms.ListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.treeExplorer = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // lstExplorer
            // 
            this.lstExplorer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstExplorer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderSize,
            this.columnHeaderType});
            this.lstExplorer.FullRowSelect = true;
            this.lstExplorer.GridLines = true;
            this.lstExplorer.Location = new System.Drawing.Point(150, 0);
            this.lstExplorer.MultiSelect = false;
            this.lstExplorer.Name = "lstExplorer";
            this.lstExplorer.Size = new System.Drawing.Size(250, 200);
            this.lstExplorer.TabIndex = 2;
            this.lstExplorer.UseCompatibleStateImageBehavior = false;
            this.lstExplorer.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 125;
            // 
            // columnHeaderSize
            // 
            this.columnHeaderSize.Text = "Size";
            // 
            // columnHeaderType
            // 
            this.columnHeaderType.Text = "Type";
            // 
            // treeExplorer
            // 
            this.treeExplorer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeExplorer.Location = new System.Drawing.Point(0, 0);
            this.treeExplorer.Name = "treeExplorer";
            this.treeExplorer.Size = new System.Drawing.Size(150, 200);
            this.treeExplorer.TabIndex = 3;
            // 
            // FileArchiveExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeExplorer);
            this.Controls.Add(this.lstExplorer);
            this.Name = "FileArchiveExplorer";
            this.Size = new System.Drawing.Size(400, 200);
            this.Load += new System.EventHandler(this.FileArchiveExplorer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstExplorer;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderSize;
        private System.Windows.Forms.ColumnHeader columnHeaderType;
        private System.Windows.Forms.TreeView treeExplorer;
    }
}
