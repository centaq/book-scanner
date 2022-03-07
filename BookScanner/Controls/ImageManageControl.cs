using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BookScanner.Controls
{
    public class ImageItem
    {
        public int order;
        public FileStream fs;
        public Rectangle rect;

        public ImageItem(FileStream _fs, int _order)
        {
            fs = _fs;
            order = _order;
            rect = Rectangle.Empty;
        }

        public void SetRect(Rectangle _rect)
        {
            rect = _rect;
        }

        public void SetOrder(int _order)
        {
            order = _order;
        }

        public void Dispose()
        {
            fs.Dispose();
        }
    }

    public partial class ImageManageControl : UserControl
    {
        public event EventHandler<ThumbnailClickEventArgs> ThumbnailClick;
        public event EventHandler<EventArgs> ChangesMade;
        private Dictionary<string, ImageItem> images = new Dictionary<string, ImageItem>();
        private string lastSaved;
        private string currImage;

        public ImageManageControl()
        {
            InitializeComponent();
        }

        public void Reset()
        {
            foreach (KeyValuePair<string, ImageItem> img in images)
                img.Value.Dispose();
            thumbnailContainer.Reset();
            PicControl.Reset();
            images = new Dictionary<string, ImageItem>();
            lastSaved = null;
            currImage = null;
        }

        private void PicControl_Resize(object sender, EventArgs e)
        {
            PicControl.Width = PicControl.Height;
        }

        public void SetPicture(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete);
            images[path] = new ImageItem(fs, images.Count);
            currImage = path;
            thumbnailContainer.AddImage(path);
            PicControl.SetPicture(path, images[path].fs, images[path].rect);
        }

        public void CutToSelection()
        {
            PicControl.CutToSelection();
        }

        public void RestoreImage()
        {
            images[currImage].SetRect(Rectangle.Empty);
            PicControl.SetPicture(currImage, images[currImage].fs, images[currImage].rect);
            thumbnailContainer.UpdateImage(currImage, Utils.Tiff.GetImage(images[currImage]));
        }

        private void PicControl_ImageChanged(object sender, PictureControl.ImageChangedEventArgs e)
        {
            images[e.ImgPath].SetRect(e.Rect);
            PicControl.SetPicture(e.ImgPath, images[e.ImgPath].fs, images[e.ImgPath].rect);
            thumbnailContainer.UpdateImage(e.ImgPath, Utils.Tiff.GetImage(images[e.ImgPath]));
        }

        private void thumbnailContainer_ThumbnailClick(object sender, ThumbnailClickEventArgs e)
        {
            PicControl.SetPicture(e.ImgPath, images[e.ImgPath].fs, images[e.ImgPath].rect);
            currImage = e.ImgPath;
            if (ThumbnailClick != null)
                ThumbnailClick(this, e);
        }

        public void SaveImage(Utils.Tiff.SaveFinished method, Control ctrl)
        {
            SaveImage(method, ctrl, false);
        }

        public void SaveAsImage(Utils.Tiff.SaveFinished method, Control ctrl)
        {
            SaveImage(method, ctrl, true);
        }

        private void SaveImage(Utils.Tiff.SaveFinished method, Control ctrl, bool newPath)
        {
            if (String.IsNullOrEmpty(lastSaved) || newPath)
            {
                if (SFD.ShowDialog() != DialogResult.OK)
                    method(false);

                lastSaved = SFD.FileName;
            }
            if (!String.IsNullOrEmpty(lastSaved))
            {
                Utils.Tiff.Save(method, ctrl, lastSaved, images.Values.ToList());
            }
            else
                method(false);
        }

        public void CancelSave()
        {
            Utils.Tiff.CancelSave();
        }

        public bool SaveAsSeparate(Utils.Tiff.SaveFinished method, Control ctrl)
        {
            if (FBD.ShowDialog() != DialogResult.OK)
                return false;
            Utils.Tiff.SaveAsSeparate(method, ctrl, FBD.SelectedPath, images.Values.ToList());
            return true;
        }

        public void MoveDown()
        {
            int order = images[currImage].order;
            if (order == images.Count - 1)
                return;
            string other = "";
            foreach (KeyValuePair<string, ImageItem> item in images)
                if (item.Value.order == order + 1)
                {
                    other = item.Key;
                    item.Value.SetOrder(order);
                }
            images[currImage].SetOrder(order + 1);
            thumbnailContainer.MoveUp(other);

            if (ChangesMade != null)
                ChangesMade(null, null);
        }

        public void MoveUp()
        {
            int order = images[currImage].order;
            if (order == 0)
                return;
            foreach (KeyValuePair<string, ImageItem> item in images)
                if (item.Value.order == order - 1)
                    item.Value.SetOrder(order);
            images[currImage].SetOrder(order - 1);
            thumbnailContainer.MoveUp(currImage);

            if (ChangesMade != null)
                ChangesMade(null, null);
        }

        public void Delete()
        {
            if (images[currImage] == null)
                return;
            images[currImage].Dispose();
            new System.IO.FileInfo(currImage).Delete();
            images.Remove(currImage);
            PicControl.SetPicture(null, null, Rectangle.Empty);
            thumbnailContainer.DeleteImage(currImage);
            if (ThumbnailClick != null)
                ThumbnailClick(null, null);
        }
    }
}
