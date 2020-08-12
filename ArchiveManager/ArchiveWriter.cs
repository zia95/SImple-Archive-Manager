using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SharpCompress;
using SharpCompress.Archive;
using SharpCompress.Writer;
using SharpCompress.Writer.GZip;
using SharpCompress.Writer.Zip;
using SharpCompress.Writer.Tar;
using SharpCompress.Common;
using ArchiveTypes = SharpCompress.Common.ArchiveType;
using SharpCompress.Compressor.Deflate;

namespace ArchiveManager
{
    public partial class ArchiveWriter : Form
    {
        private bool archive_write_sucessful = false;
        public bool ArchiveWrittenSucessful { get { return this.archive_write_sucessful; } }


        #region ArchiveEntry
        public class ArchiveEntry
        {
            public static bool CheckEntries(params ArchiveEntry[] entries)
            {
                if(entries != null && entries.Length > 0)
                {
                    foreach(var entry in entries)
                    {
                        if (entry == null || entry.IsValid == false)
                        {
                            return false;
                        }
                    }
                    return true;
                }
                return false;
            }
            private string src = null;
            private System.IO.FileInfo file = null;
            private System.IO.DirectoryInfo dir = null;

            public string SourcePath { get { return this.src; } }
            public System.IO.FileInfo File { get { return this.file; } }
            public System.IO.DirectoryInfo Directory { get { return this.dir; } }

            public bool IsValid
            {
                get
                {
                    if (this.file != null)
                    {
                        if(this.file.Exists && this.src != null && System.IO.File.Exists(this.src))
                        {
                            return true;
                        }
                    }
                    else if(this.dir != null)
                    {
                        if (this.dir.Exists && this.src != null && System.IO.Directory.Exists(this.src))
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }

            public ArchiveEntry(string source, System.IO.FileInfo f)
            {
                if(source != null && System.IO.File.Exists(source) && f != null && f.Exists)
                {
                    this.src = source;
                    this.file = f;
                }
                else
                {
                    throw new ArgumentException("Invalid archive entry args.");
                }
            }
            public ArchiveEntry(string source, System.IO.DirectoryInfo d)
            {
                if (source != null && System.IO.Directory.Exists(source) && d != null && d.Exists)
                {
                    this.src = source;
                    this.dir = d;
                }
                else
                {
                    throw new ArgumentException("Invalid archive entry args.");
                }
            }

        }
        #endregion

        #region ComboBox & Archive Settings __ METHODS
        private ArchiveTypes[] arc_types = null;
        private CompressionMethods[] comp_methods = null;
        private enum CompressionMethods
        {
            Store,
            Normal,
            Good,
            Best,
        };
        /*
        private enum ArchiveTypes
        {
            Zip,
            Rar,
        };
        */
        private void PopulateComboBox()
        {
            this.arc_types = (ArchiveTypes[])Enum.GetValues(typeof(ArchiveTypes));
            this.comp_methods = (CompressionMethods[])Enum.GetValues(typeof(CompressionMethods));


            List<ArchiveType> arc_remover = new List<ArchiveTypes>();
            arc_remover.AddRange(this.arc_types);
            arc_remover.Remove(ArchiveTypes.SevenZip);
            arc_remover.Remove(ArchiveTypes.Rar);
            this.arc_types = arc_remover.ToArray();


            foreach (var arc_type in this.arc_types)
                this.cbArchiveType.Items.Add(arc_type);

            foreach (var comp in this.comp_methods)
                this.cbArchiveCompression.Items.Add(comp);

            this.cbArchiveType.SelectedIndex = 0;
            this.cbArchiveCompression.SelectedIndex = 0;
        }
        private ArchiveTypes GetArchiveType()
        {
            return this.arc_types[this.cbArchiveType.SelectedIndex];
        }
        private CompressionMethods GetCompressMethod()
        {
            return this.comp_methods[this.cbArchiveCompression.SelectedIndex];
        }
        #endregion

        #region Some Custom Settings Helping Methods
        private void UpdateArchiveFullPath()
        {
            if(!string.IsNullOrEmpty(this.tbArchiveName.Text))
            {
                bool path_good = true;
                //-----check-------path----valid---or---not-----//
                foreach(char c in System.IO.Path.GetInvalidFileNameChars())
                {
                    if (this.tbArchiveName.Text.Contains(c))
                    {
                        path_good = false;
                        break;
                    }
                }
                string path_string = this.ArchiveDirectory + this.tbArchiveName.Text + this.tbArchiveExtension.Text;
                this.tbArchivePath.Text = path_good ? path_string : "Invalid Path";
            }
            else
            {
                this.tbArchivePath.Text = "Write archive name";
            }
        }
        #endregion

        private readonly string ArchiveDirectory = null;
        private readonly ArchiveEntry[] ArchiveEntries = null;
        public ArchiveWriter(string archive_path, ArchiveEntry[] arc_entries)
        {
            InitializeComponent();

            bool arc_dir_valid = false;
            bool entries_valid = ArchiveEntry.CheckEntries(arc_entries);

            if (archive_path != null && System.IO.Directory.Exists(archive_path))
            {
                if (!archive_path.EndsWith("\\")) archive_path += "\\";
                arc_dir_valid = true;
            }

            
            
            if (arc_dir_valid && entries_valid)
            {
                this.ArchiveDirectory = archive_path;
                this.ArchiveEntries = arc_entries;
            }
            else
            {
                MessageBox.Show("Archive creator wrong params, cannot continue...",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void ArchiveCreator_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.icon;
            this.Text = "Total Entries:" + this.ArchiveEntries.Length;
            this.PopulateComboBox();
            this.UpdateArchiveFullPath();
            this.gboxProgress.Enabled = false;
        }

        #region Settings Events
        private void cbArchiveType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(this.GetArchiveType())
            {
                case ArchiveTypes.Zip:
                    this.tbArchiveExtension.Text = ".zip";
                    break;
                case ArchiveTypes.Rar:
                    this.tbArchiveExtension.Text = ".rar";
                    break;
                case ArchiveTypes.GZip:
                    this.tbArchiveExtension.Text = ".gz";
                    break;
                case ArchiveTypes.SevenZip:
                    this.tbArchiveExtension.Text = ".7z";
                    break;
                case ArchiveTypes.Tar:
                    this.tbArchiveExtension.Text = ".tar";
                    break;
            }
        }

        private void tbArchiveName_TextChanged(object sender, EventArgs e)
        {
            this.UpdateArchiveFullPath();
        }

        private void tbArchiveExtension_TextChanged(object sender, EventArgs e)
        {
            this.UpdateArchiveFullPath();
        }
        #endregion
        
        private void btClose_Click(object sender, EventArgs e)
        {
            if(this.bwArchiveCreate.IsBusy)
                this.bwArchiveCreate.CancelAsync();
            this.Close();
        }

        private void btCreateArchive_Click(object sender, EventArgs e)
        {
            string arc_path = System.IO.Path.GetFullPath(this.tbArchivePath.Text);
            if(arc_path != null)
            {
                ArchiveCreatorParams myparams = new ArchiveCreatorParams(
                    arc_path, this.ArchiveEntries, this.GetArchiveType(), this.GetCompressMethod());
                this.bwArchiveCreate.RunWorkerAsync(myparams);
                this.my_tmr_params = myparams;
                this.gboxArchiveCreateSettings.Enabled = false;
                this.gboxProgress.Enabled = true;
                this.btCreateArchive.Enabled = false;
                this.tmrUpdateProgress.Enabled = true;
                this.Text = "Creating archive....";
                
            }
            else
            {
                MessageBox.Show("Invalid archive path.", "Path Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //-------------ARCHIVE--------CREATE---------------------//
        private class ArchiveCreatorParams
        {
            private string archive_path = null;
            private ArchiveEntry[] archive_entries = null;
            private ArchiveTypes archive_type = ArchiveTypes.Zip;
            private CompressionMethods compress_method = CompressionMethods.Store;


            public string ArchiveFullPath { get { return this.archive_path; } }
            public ArchiveEntry[] ArchiveEntries { get { return this.archive_entries; } }
            public ArchiveTypes ArchiveType { get { return this.archive_type; } }
            public CompressionMethods CompressMethod { get { return this.compress_method; } }

            public ArchiveCreatorParams(string arc_path, 
                ArchiveEntry[] arc_entries, ArchiveTypes arc_type, CompressionMethods comp_methd)
            {
                this.archive_path = arc_path;
                this.archive_entries = arc_entries;

                this.archive_type = arc_type;
                this.compress_method = comp_methd;
            }
        }
        private long my_full_size = -1;
        private ArchiveCreatorParams my_tmr_params = null;
        private void tmrUpdateProgress_Tick(object sender, EventArgs e)
        {
            if (!this.bwArchiveCreate.IsBusy && my_tmr_params != null) return;

            #region Get__FULL___WRITE___SIZE
            if (my_full_size == -1)
            {
                my_full_size = 0;
                foreach(var entry in this.ArchiveEntries)
                {
                    if(entry.IsValid)
                    {
                        if(entry.File != null)
                        {
                            my_full_size += entry.File.Length;
                        }
                        else if(entry.Directory != null)
                        {
                            my_full_size += Helper.GetDirectorySize(entry.Directory);
                        }
                    }
                }
            }
            #endregion

            if(System.IO.File.Exists(this.my_tmr_params.ArchiveFullPath))
            {
                long arc_len = new System.IO.FileInfo(this.my_tmr_params.ArchiveFullPath).Length;

                if(my_full_size > arc_len)
                {
                    var progress = Helper.GetPercentage(my_full_size, arc_len);
                    this.pbProgress.Value = (int)progress;
                    this.lbProgress.Text = string.Format("Bytes Written: {0} ({1:0.##}%)", Helper.SizeToString(arc_len), progress);  
                }
                
            }
            
            
        }

        private void bwArchiveCreate_DoWork(object sender, DoWorkEventArgs e)
        {
            ArchiveCreatorParams my_params = e.Argument as ArchiveCreatorParams;
            if(my_params != null)
            {
                #region Convert my Settings to Lib Settings
                CompressionType c_type = CompressionType.Deflate;
                CompressionLevel c_lvl = CompressionLevel.None;
                switch (my_params.ArchiveType)
                {
                    case ArchiveTypes.Rar:
                        c_type = CompressionType.Rar;
                        break;
                    case ArchiveTypes.Zip:
                        c_type = CompressionType.LZMA;
                        break;
                    case ArchiveTypes.Tar:
                        c_type = CompressionType.GZip;
                        break;
                    case ArchiveTypes.SevenZip:
                        c_type = CompressionType.LZMA;
                        break;
                    case ArchiveTypes.GZip:
                        c_type = CompressionType.GZip;
                        break;
                }
                switch(my_params.CompressMethod)
                {
                    case CompressionMethods.Store:
                        c_lvl = CompressionLevel.None;
                        break;
                    case CompressionMethods.Normal:
                        c_lvl = CompressionLevel.Level4;
                        break;
                    case CompressionMethods.Good:
                        c_lvl = CompressionLevel.Level6;
                        break;
                    case CompressionMethods.Best:
                        c_lvl = CompressionLevel.BestCompression;
                        break;
                }


                CompressionInfo compress_info = new CompressionInfo()
                {
                    Type = c_type,
                    DeflateCompressionLevel = c_lvl,
                };
                #endregion
                
                
                
                using(var arc_stream = System.IO.File.Create(my_params.ArchiveFullPath))
                using (var writer = WriterFactory.Open(arc_stream, my_params.ArchiveType, compress_info))
                {
                    foreach(var entry in my_params.ArchiveEntries)
                    {
                        if(entry.IsValid)
                        {
                            if(entry.File != null)
                            {
                                writer.Write(entry.File.Name, entry.File);
                            }
                            else if(entry.Directory != null)
                            {
                                foreach(var file in entry.Directory.GetFiles("*.*", System.IO.SearchOption.AllDirectories))
                                {
                                    string filepathindir = entry.Directory.Name + file.FullName.Substring(entry.Directory.FullName.Length);
                                    writer.Write(filepathindir, file.FullName);
                                }
                            }
                        }
                    }
                    e.Result = my_params.ArchiveFullPath;
                }
                
            }
        }

        private void bwArchiveCreate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string archive_path = e.Result as string;
            if(archive_path != null && System.IO.File.Exists(archive_path))
            {
                
                if(MessageBox.Show("Archive Written sucessful, Open Archive?", 
                    "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(archive_path);
                }
                archive_write_sucessful = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to create archive...",
                    "Archive Create Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                archive_write_sucessful = false;
                this.Close();
            }
        }
    }
}
