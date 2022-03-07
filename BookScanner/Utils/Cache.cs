using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace BookScanner.Utils
{
    public static class Cache
    {
        private static string Prefix = Process.GetCurrentProcess().Id.ToString();
        private static string TempFolder = Path.GetTempPath() + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + "\\";
        public static string AddImage(string dir, Image img)
        {
            string currentPath = TempFolder + Prefix + "_" + dir;
            DirectoryInfo di = new DirectoryInfo(currentPath);
            if (!di.Exists)
                di.Create();
            FileInfo fi = new FileInfo(Path.GetTempFileName());
            if (!fi.Exists)
                fi.Create();
            string filePath = currentPath + "\\" + fi.Name;
            img.Save(filePath, ImageFormat.Tiff);
            img.Dispose();
            return filePath;
        }

        public static string CopyFile(string dir, string path)
        {
            string currentPath = TempFolder + Prefix + "_" + dir;
            DirectoryInfo di = new DirectoryInfo(currentPath);
            if (!di.Exists)
                di.Create();
            FileInfo fi = new FileInfo(path);
            if (!fi.Exists)
                return null;
            string filePath = currentPath + "\\" + (new Random()).Next().ToString() + fi.Extension;
            fi.CopyTo(filePath);
            return filePath;
        }

        public static void DeleteTemp()
        {
            DirectoryInfo di = new DirectoryInfo(TempFolder);
            if (!di.Exists)
                di.Create();
            foreach (DirectoryInfo sub in di.GetDirectories())
                if (sub.Name.StartsWith(Prefix) && sub.Exists)
                    sub.Delete(true);
        }
    }
}
