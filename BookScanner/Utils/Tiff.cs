using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BookScanner.Controls;

namespace BookScanner.Utils
{
    public static class Tiff
    {
        private struct SaveObject
        {
            public Control ctrl;
            public string destFile;
            public List<ImageItem> images;
            public SaveFinished method;
        }

        public delegate void SaveFinished(bool success);
        private static bool saveInProgress;
        private static BackgroundWorker saveBW;
        private static BackgroundWorker saveSepBW;

        public static void Save(SaveFinished method, Control ctrl, string destFile, List<ImageItem> images)
        {
            if (saveInProgress)
            {
                MessageBox.Show("Zapisywanie w toku");
                return;
            }
            saveBW = new BackgroundWorker();
            saveBW.DoWork += new DoWorkEventHandler(bw_DoWork);
            saveBW.RunWorkerAsync(new SaveObject() { method = method, ctrl = ctrl, destFile = destFile, images = images });
            saveInProgress = true;
        }

        static void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            SaveObject so = (SaveObject)e.Argument;
            Image mainImage = null;
            try
            {
                MainForm mf = (MainForm)so.ctrl;
                string destFile = so.destFile;
                List<ImageItem> images = so.images;

                ImageCodecInfo info = null;
                foreach (ImageCodecInfo ice in ImageCodecInfo.GetImageEncoders())
                    if (ice.MimeType == "image/tiff")
                        info = ice;

                //use the save encoder
                Encoder enc = Encoder.SaveFlag;
                Encoder encCompress = Encoder.Compression;

                EncoderParameters ep = new EncoderParameters(2);
                ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.MultiFrame);
                ep.Param[1] = new EncoderParameter(encCompress, (long)EncoderValue.CompressionLZW);


                int frame = 0;
                mf.Invoke((Action)delegate { mf.ReportSaveProgress(frame, images.Count); });

                foreach (ImageItem item in images.OrderBy(item => item.order))
                {
                    if (e.Cancel)
                    {
                        saveInProgress = false;
                        so.method(false);
                    }
                    if (frame == 0)
                    {
                        mainImage = GetImage(item);
                        //save the first frame
                        mainImage.Save(destFile, info, ep);
                    }
                    else
                    {
                        //save the intermediate frames
                        ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.FrameDimensionPage);
                        using (Image img = GetImage(item))
                            mainImage.SaveAdd(img, ep);
                    }
                    mf.Invoke((Action)delegate { mf.ReportSaveProgress(frame + 1, images.Count); });

                    if (frame == images.Count - 1)
                    {
                        ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.Flush);

                        mainImage.SaveAdd(ep);
                    }

                    frame++;
                }
                so.method(true);
            }
            catch (Exception)
            {
                so.method(false);
            }
            finally
            {
                if (mainImage != null)
                    mainImage.Dispose();
                saveInProgress = false;
            }
        }

        public static void SaveAsSeparate(SaveFinished method, Control ctrl, string path, List<ImageItem> images)
        {
            if (saveInProgress)
            {
                MessageBox.Show("Zapisywanie w toku");
                return;
            }
            saveSepBW = new BackgroundWorker();
            saveSepBW.DoWork += new DoWorkEventHandler(bw_DoWorkSeparate);
            saveSepBW.RunWorkerAsync(new SaveObject() { method = method, ctrl = ctrl, destFile = path, images = images });
            saveInProgress = true;
        }

        static void bw_DoWorkSeparate(object sender, DoWorkEventArgs e)
        {
            SaveObject so = (SaveObject)e.Argument;
            try
            {
                MainForm mf = (MainForm)so.ctrl;
                string destFile = so.destFile;
                List<ImageItem> images = so.images;
                int index = 0;
                mf.Invoke((Action)delegate { mf.ReportSaveProgress(0, images.Count); });

                foreach (ImageItem item in images)
                {
                    if (e.Cancel)
                    {
                        saveInProgress = false;
                        so.method(false);
                    }
                    FileInfo file = new FileInfo(item.fs.Name);
                    GetImage(item).Save(destFile + "\\" + item.order + ".tiff");
                    /*if (file.Exists)
                        File.Copy(item.fs.Name, destFile + "\\" + item.order + file.Extension, true);
                    else
                        MessageBox.Show("Plik " + file.Name + " nie istnieje", "Błąd");
                    */
                    mf.Invoke((Action)delegate { mf.ReportSaveProgress(index + 1, images.Count); });
                    index++;
                }
                so.method(true);
            }
            catch (Exception)
            {
                so.method(false);
            }
            finally
            {
                saveInProgress = false;
            }
        }

        public static void CancelSave()
        {
            try
            {
                if (saveBW.IsBusy)
                    saveBW.CancelAsync();

                if (saveSepBW.IsBusy)
                    saveSepBW.CancelAsync();
            }
            catch (Exception)
            {
            }
            saveInProgress = false;
        }

        public static Image GetImage(ImageItem imgItem)
        {
            return GetImage(imgItem.fs, imgItem.rect);
        }

        public static Image GetImage(System.IO.FileStream fs, Rectangle r)
        {
            Image img = Image.FromStream(fs);
            if (r != Rectangle.Empty)
            {
                Image tmp = new Bitmap(r.Width, r.Height);
                using (Graphics g = Graphics.FromImage(tmp))
                {
                    g.DrawImage(img, new Rectangle(0, 0, r.Width, r.Height), r, GraphicsUnit.Pixel);
                }
                img.Dispose();
                img = tmp;
            }
            return img;
        }
    }
}
