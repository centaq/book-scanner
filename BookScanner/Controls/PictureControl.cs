using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BookScanner.Controls
{
    public partial class PictureControl : UserControl
    {
        private Point selStart, selEnd;
        private Rectangle selection;
        private bool mouseDown;
        private Image img;
        private Rectangle imgRect;
        private string imgPath;

        public event EventHandler<ImageChangedEventArgs> ImageChanged;

        public PictureControl()
        {
            InitializeComponent();
        }

        public void SetPicture(string _imgPath, FileStream _fs, Rectangle _rect)
        {
            if (img != null)
                img.Dispose();
            if (_imgPath == null)
                return;
            imgPath = _imgPath;
            img = Utils.Tiff.GetImage(_fs, _rect);
            imgRect = _rect.IsEmpty ? new Rectangle(0, 0, img.Width, img.Height) : _rect;
            PictBox.Image = img;

            ResizePictBox();
        }

        public void Reset()
        {
            if (img != null)
                img.Dispose();
            if (PictBox.Image != null)
                PictBox.Image.Dispose();
            PictBox.Image = new Bitmap(1, 1);
        }

        private void PictBox_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            if (selection != Rectangle.Empty)
            {
                using (Pen pen = new Pen(Color.Black, 1F))
                {
                    pen.DashStyle = DashStyle.Dash;
                    e.Graphics.DrawRectangle(pen, selection);
                }
            }
        }

        private void PictBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (img == null)
                return;
            selection = Rectangle.Empty;
            selStart = e.Location;
            mouseDown = true;
        }

        private void PictBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                selEnd = e.Location;
                SetSelRect();
                PictBox.Invalidate();
            }
        }

        private void PictBox_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            PictBox.Invalidate();
        }

        private void SetSelRect()
        {
            selection = new Rectangle(Math.Min(selStart.X, selEnd.X), Math.Min(selStart.Y, selEnd.Y), 
                Math.Abs(selStart.X - selEnd.X), Math.Abs(selStart.Y - selEnd.Y));
        }

        private void PictureControl_Resize(object sender, EventArgs e)
        {
            ResizePictBox();
        }

        private void ResizePictBox()
        {
            selection = Rectangle.Empty;
            if (img == null)
                return;
            if (img.Width > img.Height)
            {
                PictBox.Width = this.Width - PictBox.Margin.Horizontal;
                PictBox.Height = img.Height * PictBox.Width / img.Width;
                PictBox.Location = new Point(PictBox.Margin.Left, (this.Height - PictBox.Height) / 2 + PictBox.Margin.Top);
            }
            else
            {
                PictBox.Height = this.Height - PictBox.Margin.Vertical;
                PictBox.Width = img.Width * PictBox.Height / img.Height;
                PictBox.Location = new Point(PictBox.Margin.Left + (this.Width - PictBox.Width) / 2, PictBox.Margin.Top);
            }
        }

        public void CutToSelection()
        {
            if (img == null || selection == Rectangle.Empty)
                return;
            Rectangle rect = new Rectangle(selection.X * imgRect.Width / PictBox.Width, selection.Y * imgRect.Height / PictBox.Height,
                selection.Width * imgRect.Width / PictBox.Width, selection.Height * imgRect.Height / PictBox.Height);
            imgRect = new Rectangle(imgRect.X + rect.X, imgRect.Y + rect.Y, rect.Width, rect.Height);
            if (ImageChanged != null)
                ImageChanged(this, new ImageChangedEventArgs(imgPath, imgRect));
        }

        public class ImageChangedEventArgs : EventArgs
        {
            private string imgPath;
            private Rectangle rect;

            public ImageChangedEventArgs(string imgPath, Rectangle rect)
            {
                this.imgPath = imgPath;
                this.rect = rect;
            }

            public string ImgPath
            {
                get { return imgPath; }
            }

            public Rectangle Rect
            {
                get { return rect; }
            }
        }
    }
}
