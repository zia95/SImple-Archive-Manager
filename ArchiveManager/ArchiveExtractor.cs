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
using SharpCompress.Reader;
using SharpCompress.Common;

namespace ArchiveManager
{
    public partial class ArchiveExtractor : Form
    {
        private readonly string ArchivePath = null;
        private readonly string ExtractionPath = null;

        private bool extract_sucessful = false;
        public bool ExtractionWasSucessful { get { return this.extract_sucessful; } }
        private void BeginExtraction()
        {
            this.Text = "Extracting: " + this.ArchivePath;
            ProgressSync.Reset();
            this.bwExtraction.RunWorkerAsync(new string[] { this.ArchivePath, this.ExtractionPath });
        }
        public ArchiveExtractor(string archive, string extract_location)
        {
            InitializeComponent();

            this.ArchivePath = archive;
            if (extract_location != null && !extract_location.EndsWith("\\"))
                extract_location += '\\';

            this.ExtractionPath = extract_location;

            /*Check Extraction path for files and sub dir 
                if files or sub dirs exist create new directory for extraction
            if (extract_location != null && System.IO.Directory.Exists(extract_location))
            {
                var dir_info = new System.IO.DirectoryInfo(extract_location);
                if(dir_info.Exists)
                {
                    var files = dir_info.GetFiles();
                    var dirs = dir_info.GetDirectories();
                    if ((files != null && files.Length > 0) || (dirs != null && dirs.Length > 0))
                    {
                        int no_index = 0;
                        string new_ext_dir = null;
                        
                        string sub_dir_name = "extraction";
                        if (archive != null)
                        {
                            string file_name = System.IO.Path.GetFileNameWithoutExtension(archive);
                            if (file_name != null)
                                sub_dir_name += '.' + file_name;
                        }
                        if (!extract_location.EndsWith("\\")) extract_location += "\\";
                        do
                        {
                            new_ext_dir = (no_index == 0) ?
                                extract_location + sub_dir_name :
                                extract_location + sub_dir_name + '.' + no_index;

                            no_index++;
                        }
                        while (System.IO.Directory.Exists(new_ext_dir));

                        System.IO.Directory.CreateDirectory(new_ext_dir);
                        this.ExtractionPath = new_ext_dir;
                    }
                } 
            }
            */
        }
        
        private void ArchiveExtractor_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.icon;
            if (this.ArchivePath != null && System.IO.File.Exists(this.ArchivePath) &&
                this.ExtractionPath != null && System.IO.Directory.Exists(this.ExtractionPath))
            {
                this.BeginExtraction();
            }
            else
            {
                MessageBox.Show("Wrong parameters archive extractor cannot continue...!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void ArchiveExtractor_FormClosing(object sender, FormClosingEventArgs e)
        {
            ProgressSync.Reset();
        }
        private void btClose_Click(object sender, EventArgs e)
        {
            if (this.bwExtraction.IsBusy)
            {
                if (MessageBox.Show("Currently extracting archive, are you sure you want to cancel?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    this.bwExtraction.CancelAsync();
            }
            this.Close();
        }
        
        private void tmrProgressUpdater_Tick(object sender, EventArgs e)
        {
            if(ProgressSync.Extracting && ProgressSync.MonitorProgress)
            {
                if(ProgressSync.Done)
                {
                    this.pbarTotalProgress.Value = 0;
                    this.lbExtractionProgress.Text = "Bytes Written: 0";
                    this.lbCurrentExtractingEntry.Text = "Current Extracting: ---";
                    this.Text = "Extraction Done!!";
                    this.tmrProgressUpdater.Enabled = false;
                }
                else
                {
                    if(ProgressSync.TotalBytesRead < ProgressSync.TotalBytes)
                    {
                        float percent = Helper.GetPercentage((decimal)ProgressSync.TotalBytes,
                                                            (decimal)ProgressSync.TotalBytesRead);

                        this.pbarTotalProgress.Value = (int)percent;
                        this.lbExtractionProgress.Text = string.Format("Bytes Written: {0} out of {1} ({2:00.##}%)", 
                            Helper.SizeToString(ProgressSync.TotalBytesRead), Helper.SizeToString(ProgressSync.TotalBytes), percent);
                        this.lbCurrentExtractingEntry.Text = string.Format("Extracting File: {0}", ProgressSync.CurrentEntry.FilePath);

                        string c_entry_full_path = this.ExtractionPath + ProgressSync.CurrentEntry.FilePath;
                        if(System.IO.File.Exists(c_entry_full_path))
                        {
                            var f_info = new System.IO.FileInfo(c_entry_full_path);
                            if(f_info.Exists)
                            {
                                long c_entry_total_size = ProgressSync.CurrentEntry.Size;
                                long c_entry_file_size = f_info.Length;
                                if(c_entry_file_size < c_entry_total_size)
                                {
                                    float c_entry_perc = Helper.GetPercentage(c_entry_total_size, c_entry_file_size);

                                    this.pbarEntryExtractProgress.Value = (int)c_entry_perc;

                                    this.lbEntryExtractProgress.Text = string.Format("Entries: {0} out of {1} Current Entry Extraction:{2:00.##}",
                                        ProgressSync.EntriesExtracted, ProgressSync.TotalEntries, c_entry_perc);
                                }
                            }
                        }
                    }
                    else
                    {
                        if(ProgressSync.Done == false)
                        {
                            this.tmrProgressUpdater.Enabled = false;
                            this.bwExtraction.CancelAsync();
                            this.extract_sucessful = false;
                            MessageBox.Show("something went wrong!!", "unexpected_error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            
                            this.Close();
                            
                        }
                    }
                }
            }
        }
        private static class ProgressSync
        {
            public static bool MonitorProgress { get; set; } = false;

            public static bool Extracting { get; set; } = false;
            public static bool Done { get; set; } = false;

            public static long TotalBytes { get; set; } = 0;
            public static long TotalBytesRead { get; set; } = 0;

            public static int TotalEntries { get; set; } = 0;
            public static int EntriesExtracted { get; set; } = 0;
            public static long CurrentEntryBytesRead { get; set; } = 0;
            public static IArchiveEntry CurrentEntry { get; set; } = null;

            public static void Reset()
            {
                ProgressSync.Extracting = false;
                ProgressSync.Done = false;
                ProgressSync.TotalBytes = 0;
                ProgressSync.TotalBytesRead = 0;
                ProgressSync.TotalEntries = 0;
                ProgressSync.EntriesExtracted = 0;
                ProgressSync.CurrentEntryBytesRead = 0;
                ProgressSync.CurrentEntry = null;
            }
        }

        private void bwExtraction_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] eparams = e.Argument as string[];
            string arc = eparams[0];
            string ext_path = eparams[1];
            using(var stream = System.IO.File.OpenRead(arc))
            using (var extractor = ArchiveFactory.Open(stream))
            {
                bool stop_operation = false;
                if (extractor.IsSolid)
                {
                    e.Result = "solid";
                    stop_operation = true;
                }
                
                if (!stop_operation)
                {
                    //-----events---//
                    extractor.EntryExtractionBegin += A_ext_EntryExtractionBegin;
                    extractor.EntryExtractionEnd += A_ext_EntryExtractionEnd;
                    extractor.CompressedBytesRead += Extractor_CompressedBytesRead;
                    //calculate-total-size//
                    if (extractor.IsComplete)
                    {
                        foreach (var entry in extractor.Entries)
                        {
                            ProgressSync.TotalBytes += entry.Size;
                            if (!entry.IsDirectory)
                                ProgressSync.TotalEntries++;
                        }
                    }
                    else
                    {
                        foreach(var vol in extractor.Volumes)
                        {
                            using (var split_arc_file = ArchiveFactory.Open(vol.VolumeFile))
                            {
                                foreach (var s_a_entry in split_arc_file.Entries)
                                {
                                    ProgressSync.TotalBytes += s_a_entry.Size;
                                    if (!s_a_entry.IsDirectory)
                                        ProgressSync.TotalEntries++;
                                }
                            }
                        }
                    }

                    if (extractor.Type == ArchiveType.GZip)
                    {
                        MessageBox.Show("Cannot monitor progress of archive type of 'gzip' but it will extract.", "Cannot Monitor Progress", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ProgressSync.MonitorProgress = false;
                    }
                    else
                    {
                        ProgressSync.MonitorProgress = true;
                    }

                    ProgressSync.Extracting = true;
                    
                    extractor.WriteToDirectory(ext_path, ExtractOptions.ExtractFullPath | ExtractOptions.Overwrite);
                    ProgressSync.Done = true;// to_stop_updater_tmr
                    e.Result = ext_path;
                }
            }
        }
        
        private void Extractor_CompressedBytesRead(object sender, CompressedBytesReadEventArgs e)
        {
            ProgressSync.TotalBytesRead = e.CompressedBytesRead;
        }

        private void A_ext_EntryExtractionBegin(object sender, ArchiveExtractionEventArgs<IArchiveEntry> e)
        {
            ProgressSync.CurrentEntry = e.Item;
        }
        private void A_ext_EntryExtractionEnd(object sender, ArchiveExtractionEventArgs<IArchiveEntry> e)
        {
            ProgressSync.EntriesExtracted++;
        }

        

        private void bwExtraction_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string result = e.Result as string;

            if (result == null && e.Error != null)
            {
                MessageBox.Show("Error_Message:" + e.Error.Message,
                    "Extraction failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.extract_sucessful = false;
                this.Close();
            }
            else if (result == "solid")
            {
                MessageBox.Show("Solid extraction is not supported!!",
                    "Extraction failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.extract_sucessful = false;
                this.Close();
            }

            


            if (!e.Cancelled)
            {
                if (MessageBox.Show("Open directory where archive is extracted?", "Extraction Complete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(result);
                }
                this.extract_sucessful = true;
                this.Close();
            }

            
        }

        
    }
}
