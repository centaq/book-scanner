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
    public partial class ThumbnailControl : UserControl
    {
        private string path;

        public event EventHandler<ThumbnailClickEventArgs> ThumbnailClick;
        
        public ThumbnailControl()
        {
            InitializeComponent();
        }

        public void InitControl(string path)
        {
            this.path = path;
            Image img;
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                img = GetScaledImage(new Bitmap(fs, true));

            PictBox.Image = img;
        }

        private void PictBox_Click(object sender, EventArgs e)
        {
            if (ThumbnailClick != null)
                ThumbnailClick(this, new ThumbnailClickEventArgs(path));
        }

        public void SetImage(Image img)
        {
            PictBox.Image.Dispose();
            PictBox.Image = GetScaledImage(img);
        }

        private Image GetScaledImage(Image img)
        {
            int ratio = Math.Max(img.Width / 125, img.Height / 180);
            Image newImg = new Bitmap(img, img.Width / ratio, img.Height / ratio);
            img.Dispose();
            return newImg;
        }

        public void SetActive(bool active)
        {
            BackColor = active ? SystemColors.ControlLight : SystemColors.Control;
        }
    }

    public class ThumbnailClickEventArgs : EventArgs
    {
        private string imgPath;

        public ThumbnailClickEventArgs(string imgPath)
        {
            this.imgPath = imgPath;
        }

        public string ImgPath
        {
            get { return imgPath; }
        }
    }
}
