using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArchiveManager
{
    public partial class MainForm : Form
    {
        #region Methods & Globals
        private bool CheckListForArchiveAndFiles()
        {
            if (this.lstFileExplorer.HasArchiveEntries)
            {
                var dr = MessageBox.Show("Archive is already opened, close current archive to continue operation... do you want to close this archive?",
                    "Archive is opened!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    this.ClearList();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {

                if(this.lstFileExplorer.Count > 0)
                {
                    var dr = MessageBox.Show("Some Files are added to list, clear list to continue operation... do you want to clear list?",
                    "List is not empty", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr == DialogResult.Yes)
                    {
                        this.ClearList();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                return true;
            }
        }
        private void SetText(string text = null)
        {
            text = text == null ? "Archive Manager" : text;
            this.Text = text;
        }
        #endregion

        #region Menu__File__DropDown
        private void OpenAcrhive()
        {
            if (this.CheckListForArchiveAndFiles() == false)
                return;

            if(this.ofAddArchiveDialog.ShowDialog() == DialogResult.OK)
            {
                var src = this.ofAddArchiveDialog.FileName;
                if (System.IO.File.Exists(src))
                {
                    if(this.lstFileExplorer.AddArchive(src))
                    {
                        this.SetText(this.ofAddArchiveDialog.SafeFileName + " - Archive Manager");
                    }
                    else
                    {
                        MessageBox.Show("Failed to open archive file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Archive not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void AddFile()
        {
            if (this.CheckListForArchiveAndFiles() == false)
                return;

            if (this.ofAddFileDialog.ShowDialog() == DialogResult.OK)
            {
                var files = this.ofAddFileDialog.FileNames;
                if(files != null && files.Length > 0)
                {
                    foreach(var file in files)
                    {
                        if (file != null && System.IO.File.Exists(file))
                            this.lstFileExplorer.AddFile(new System.IO.FileInfo(file));
                    }
                    this.SetText("Files And Directories: " + this.lstFileExplorer.Count + " - Archive Manager");
                }
                else
                {
                    MessageBox.Show("No File(s)", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void AddAllFromDir()
        {
            if (this.CheckListForArchiveAndFiles() == false)
                return;

            if (this.bfDirectorySelectDialog.ShowDialog() == DialogResult.OK)
            {
                this.bfDirectorySelectDialog.Description = "Select a directory.";
                var dir = this.bfDirectorySelectDialog.SelectedPath;
                if(dir != null && System.IO.Directory.Exists(dir))
                {
                    this.lstFileExplorer.AddAllFromDirectory(new System.IO.DirectoryInfo(dir));
                    this.SetText("Files And Directories: " + this.lstFileExplorer.Count + " - Archive Manager");
                }
                else
                {
                    MessageBox.Show("Directory not exist.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void AddDirectory()
        {
            if (this.CheckListForArchiveAndFiles() == false)
                return;

            if (this.bfDirectorySelectDialog.ShowDialog() == DialogResult.OK)
            {
                this.bfDirectorySelectDialog.Description = "Select a directory.";
                var dir = this.bfDirectorySelectDialog.SelectedPath;
                if (dir != null && System.IO.Directory.Exists(dir))
                {
                    this.lstFileExplorer.AddDirectory(new System.IO.DirectoryInfo(dir));
                    this.SetText("Files And Directories: " + this.lstFileExplorer.Count + " - Archive Manager");
                }
                else
                {
                    MessageBox.Show("Directory not exist.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Menu__Edit__DropDown
        private void RemoveSelected()
        {
            var selected_index = this.lstFileExplorer.SelectedIndex;
            if (selected_index >= 0 && selected_index < this.lstFileExplorer.Count)
                this.lstFileExplorer.RemoveAt(selected_index);
            else
                MessageBox.Show("Select item from list first.", "Selected?", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if(this.lstFileExplorer.Count <= 0)
                this.SetText();
        }
        private void ClearList()
        {
            this.lstFileExplorer.Clear();
            this.SetText();
        }
        #endregion

        #region Menu__Tools__DropDown
        private void OpenArchiveCreator()
        {
            if (this.lstFileExplorer.HasArchiveEntries == false && this.lstFileExplorer.Count > 0)
            {
                //---------------Convert---List--Item---To---Archive---Entry----------------//
                List<ArchiveWriter.ArchiveEntry> filter_arc_itm = new List<ArchiveWriter.ArchiveEntry>();
                foreach(var lst_itm in this.lstFileExplorer.GetAllListItems())
                {
                    if(lst_itm != null)
                    {
                        if(lst_itm.IsFile)
                        {
                            var file_info = new System.IO.FileInfo(lst_itm.Source);
                            if (file_info != null && file_info.Exists)
                                filter_arc_itm.Add(new ArchiveWriter.ArchiveEntry(lst_itm.Source, file_info));
                        }
                        else if(lst_itm.IsDirectory)
                        {
                            var dir_info = new System.IO.DirectoryInfo(lst_itm.Source);
                            if(dir_info != null && dir_info.Exists)
                                filter_arc_itm.Add(new ArchiveWriter.ArchiveEntry(lst_itm.Source, dir_info));

                        }
                    }
                }
                ArchiveWriter.ArchiveEntry[] archive_entries = filter_arc_itm.Count > 0 ? filter_arc_itm.ToArray() : null;

                if (archive_entries != null && ArchiveWriter.ArchiveEntry.CheckEntries(archive_entries))
                {
                    this.bfDirectorySelectDialog.Description = "Select a directory to create a archive.";
                    if (this.bfDirectorySelectDialog.ShowDialog() == DialogResult.OK)
                    {
                        string dir = this.bfDirectorySelectDialog.SelectedPath;
                        if (dir != null && System.IO.Directory.Exists(dir))
                        {
                            new ArchiveWriter(dir, archive_entries).ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Wrong directory, directory does not exist.", "Directory Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Archive entrie(s) does not exist, deleted?", "Entries?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Add files or directory to list first.", "No files or dir opened yet", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void OpenArchiveExtractor()
        {
            if(this.lstFileExplorer.HasArchiveEntries)
            {
                string archive_path = this.lstFileExplorer.GetListItem(0).Source;

                if(archive_path != null && System.IO.File.Exists(archive_path))
                {
                    this.bfDirectorySelectDialog.Description = "Select a directory to extract the archive.";
                    if (this.bfDirectorySelectDialog.ShowDialog() == DialogResult.OK)
                    {
                        string dir = this.bfDirectorySelectDialog.SelectedPath;
                        if(dir != null && System.IO.Directory.Exists(dir))
                        {
                            new ArchiveExtractor(archive_path, dir).ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Wrong directory, directory does not exist.", "Directory Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Archive does not exist, archive has been deleted?", "Archive?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Open Archive first.", "No archive opened yet", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.icon;

            this.ofAddArchiveDialog.Filter = "All supported archives | *.zip; *.rar; *.tar; *.gz; *.7z; |"+
                                            "All Files | *.*";

            this.ofAddFileDialog.Filter = "All Files | *.*";
        }

        #region Main__Menu__Strip__
        private void fileToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            this.fileToolStripMenuItem.DropDown.Close();

            if(e.ClickedItem == this.openArchiveToolStripMenuItem)
            {
                this.OpenAcrhive();
            }
            else if(e.ClickedItem == this.addFileToolStripMenuItem)
            {
                this.AddFile();
            }
            else if(e.ClickedItem == this.addAllFromDirectoryToolStripMenuItem)
            {
                this.AddAllFromDir(); 
            }
            else if(e.ClickedItem == this.addDirectoryToolStripMenuItem)
            {
                this.AddDirectory();
            }

        }

        private void editToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            this.editToolStripMenuItem.DropDown.Close();
            
            if(e.ClickedItem == this.removeSelectedToolStripMenuItem)
            {
                this.RemoveSelected();
            }
            else if(e.ClickedItem == this.clearListToolStripMenuItem)
            {
                this.ClearList();
            }
        }

        private void toolsToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            this.toolsToolStripMenuItem.DropDown.Close();

            if(e.ClickedItem == this.archiveCreatorToolStripMenuItem)
            {
                this.OpenArchiveCreator();
            }
            else if(e.ClickedItem == this.archiveExtractorToolStripMenuItem)
            {
                this.OpenArchiveExtractor();
            }
        }
        #endregion
    }
}
