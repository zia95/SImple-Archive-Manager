using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

using SharpCompress.Archive;

namespace ArchiveManager
{
    public partial class FileArchiveExplorer : UserControl
    {
        #region LIST_ITEMS_WIDTH_ARRANGER
        private int ConvPercent(int percentage, int total)
        {
            return ((percentage * total) / 100) ;
        }
        private void SetListItemsSizeByPercent(int p_name, int p_size, int p_type)
        {
            int lst_w = this.lstExplorer.Size.Width;

            this.columnHeaderName.Width = this.ConvPercent(p_name, lst_w);
            this.columnHeaderSize.Width = this.ConvPercent(p_size, lst_w);
            this.columnHeaderType.Width = this.ConvPercent(p_type, lst_w);
        }
        #endregion

        #region Class : List Item Info
        public class ListItemInfo
        {
            private bool is_dir, is_file, is_arc_entry = false;
            private string name, type, source = null;
            private long siz = 0;
            private string siz_str = null;
            public string Source { get { return this.source; } }

            public string Name { get { return this.name; } }
            public long Size { get { return this.siz; } }
            public string strSize { get { return this.siz_str; } }
            public string Type { get { return this.type; } }
            public bool IsDirectory { get { return this.is_dir; } }
            public bool IsFile { get { return this.is_file; } }
            public bool IsArchiveEntry { get { return this.is_arc_entry; } }

            public ListItemInfo(string _source, string _name,long _siz,string _type,bool dir,bool file, bool arc)
            {
                this.Assign(_source, _name,  _siz,  _type,  dir,  file,  arc);
            }
            public ListItemInfo(FileInfo f)
            {
                string type = Path.GetExtension(f.FullName);
                if (type == null) type = "<NONE>";

                this.Assign(f.FullName, f.Name, f.Length, type, false, true, false);
            }
            public ListItemInfo(DirectoryInfo d)
            {
                this.Assign(d.FullName, d.Name, 0, "Directory", true, false, false);
            }

            private void Assign(string _source, string _name, long _siz, string _type, bool dir, bool file, bool arc)
            {
                this.source = _source;
                this.name = _name;
                this.siz = _siz;
                this.siz_str = dir ? "Directory" : Helper.SizeToString(_siz);
                this.type = _type;
                this.is_dir = dir;
                this.is_file = file;
                this.is_arc_entry = arc;
            }
        }

        #endregion
        public FileArchiveExplorer()
        {
            InitializeComponent();
        }
        
        public bool ShowTreeView { get; set; }

        [Browsable(false)]
        public bool HasArchiveEntries
        {
            get
            {
                foreach(ListViewItem itm in this.lstExplorer.Items)
                {
                    ListItemInfo item_info = itm.Tag as ListItemInfo;
                    if (item_info != null && item_info.IsArchiveEntry)
                        return true;
                }
                return false;
            }
        }
        [Browsable(false)]
        public int SelectedIndex
        {
            get
            {
                var indinces = this.lstExplorer.SelectedIndices;
                return (indinces != null && indinces.Count > 0) ? indinces[0] : -1;
            }
        }
        [Browsable(false)]
        public int Count { get { return this.lstExplorer.Items.Count; } }
        
        private int AddToList(ListItemInfo info)
        {
            if(info != null)
            {
                var itm = this.lstExplorer.Items.Add(info.Name);
                itm.SubItems.Add(info.strSize);
                itm.SubItems.Add(info.Type);
                itm.Tag = info;

                if (this.ShowTreeView)
                    this.UpdateTreeView();

                return itm.Index;
            }
            return -1;
            
        }
        private void UpdateTreeView()
        {
            this.treeExplorer.Nodes.Clear();
            foreach (ListViewItem lstitem in this.lstExplorer.Items)
            {
                var info = lstitem.Tag as ListItemInfo;
                if(info != null)
                {
                    foreach(TreeNode tnode in this.treeExplorer.Nodes)
                    {
                        if (tnode.Text == info.Name && tnode.Tag == info)
                            continue;
                    }
                    if (info.IsFile)
                    {
                        var node = this.treeExplorer.Nodes.Add(info.Name);
                        node.Tag = info;
                    }
                    else if (info.IsDirectory)
                    {
                        var snode = Helper.PopulateNode(new DirectoryInfo(info.Source));
                        snode.Tag = info;
                        this.treeExplorer.Nodes.Add(snode);
                    }
                }
            }
        }
        
        public int AddFile(FileInfo file)
        {
            if(file != null && file.Exists)
            {
                return this.AddToList(new ListItemInfo(file));
            }
            return -1;
        }

        public int AddDirectory(DirectoryInfo dir)
        {
            if(dir != null && dir.Exists)
            {
                return this.AddToList(new ListItemInfo(dir));
            }
            return -1;
        }
        public void AddAllFromDirectory(DirectoryInfo d)
        {
            if(d != null && d.Exists)
            {
                //var mydir = d.Parent;

                var files = d.GetFiles();
                if(files != null)
                {
                    foreach(var f in files)
                    {
                        this.AddFile(f);
                    }
                }
                var dirs = d.GetDirectories();
                if(dirs != null)
                {
                    foreach(var sub_dir in dirs)
                    {
                        this.AddDirectory(sub_dir);
                    }
                }
            }
        }
        public bool AddArchive(string archive_path)
        {
            if(archive_path != null && File.Exists(archive_path))
            {
                try
                {
                    using (var arc = ArchiveFactory.Open(archive_path))
                    {
                        if(arc.Entries != null)
                        {
                            foreach(var entry in arc.Entries)
                            {
                                var itm_info = new ListItemInfo(
                                    archive_path,
                                    entry.FilePath,
                                    entry.Size,
                                    entry.IsDirectory ? "Archive/Directory" : "Archive/File",
                                    entry.IsDirectory,
                                    !entry.IsDirectory,
                                    true);
                                this.AddToList(itm_info);
                            }
                        }
                    }
                    return true;
                }
                catch (Exception) { return false; }
            }
            return false;
        }

        
        public void RemoveAt(int index) { this.lstExplorer.Items.RemoveAt(index); this.UpdateTreeView(); }
        public void Clear() { this.lstExplorer.Items.Clear();  this.UpdateTreeView(); }

        public ListItemInfo GetListItem(int index)
        {
            return (this.lstExplorer.Items[index].Tag as ListItemInfo);
        }
        public ListItemInfo[] GetAllListItems()
        {
            List<ListItemInfo> myitminfo = new List<ListItemInfo>();
            foreach(ListViewItem itm in this.lstExplorer.Items)
            {
                myitminfo.Add(itm.Tag as ListItemInfo);
            }
            return myitminfo.Count > 0 ? myitminfo.ToArray() : null;
        }

        private void FileArchiveExplorer_Load(object sender, EventArgs e)
        {
            if(this.ShowTreeView == false)
            {
                this.treeExplorer.Visible = false;
                this.lstExplorer.Dock = DockStyle.Fill;
            }
            this.SetListItemsSizeByPercent(69, 15, 15);
        }
    }
}
