using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArchiveManager
{
    public static class Helper
    {
        public static string SizeToString(long bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            decimal len = bytes;
            int order = 0;
            while (len >= 1024 && order + 1 < sizes.Length)
            {
                order++;
                len = len / 1024;
            }
            return String.Format("{0:0.##}{1}", len, sizes[order]);
        }

        public static float GetPercentage(decimal total, decimal a)
        {
            return (float)((a * 100) / total);
        }
        public static long GetDirectorySize(string dir)
        {
            if (dir != null && System.IO.Directory.Exists(dir))
                return GetDirectorySize(new System.IO.DirectoryInfo(dir));
            return 0;
        }
        public static long GetDirectorySize(System.IO.DirectoryInfo d)
        {
            long size = 0;
            // Add file sizes.
            System.IO.FileInfo[] fis = d.GetFiles();
            foreach (System.IO.FileInfo fi in fis)
            {
                size += fi.Length;
            }
            // Add subdirectory sizes.
            System.IO.DirectoryInfo[] dis = d.GetDirectories();
            foreach (System.IO.DirectoryInfo di in dis)
            {
                size += GetDirectorySize(di);
            }
            return size;
        }

        public static System.Windows.Forms.TreeNode PopulateNode(System.IO.DirectoryInfo d)
        {
            System.Windows.Forms.TreeNode node = new System.Windows.Forms.TreeNode(d.Name);

            System.IO.FileInfo[] files = null;
            System.IO.DirectoryInfo[] dirs = null;
            try
            {
                files = d.GetFiles();
            }
            catch (UnauthorizedAccessException) { }
            if(files != null)
            {
                foreach (var file in files)
                {
                    node.Nodes.Add(new System.Windows.Forms.TreeNode(file.Name));
                }
            }
            

            try
            {
                dirs = d.GetDirectories();
            }
            catch(UnauthorizedAccessException) { }
            
            if(dirs != null)
            {
                foreach (var sdir in dirs)
                {
                    node.Nodes.Add(PopulateNode(sdir));
                }
            }

            
            return node;
        }
    }
}
