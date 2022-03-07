using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BookScanner.Controls
{
    public partial class ThumbnailContainer : UserControl
    {
        private Dictionary<string, ThumbnailControl> thumbnails = new Dictionary<string, ThumbnailControl>();

        public event EventHandler<ThumbnailClickEventArgs> ThumbnailClick;

        public ThumbnailContainer()
        {
            InitializeComponent();
        }

        public void AddImage(string path)
        {
            ThumbnailControl tc = new ThumbnailControl();
            tc.InitControl(path);
            tc.Dock = DockStyle.Fill;
            tc.ThumbnailClick += new EventHandler<ThumbnailClickEventArgs>(tc_ThumbnailClick);
            thumbnails.Add(path, tc);
            MainPanel.RowCount++;
            MainPanel.RowStyles.Insert(0, new RowStyle(SizeType.Absolute, tc.Height));
            MainPanel.Controls.Add(tc);
            SetActive(path);
        }

        public void DeleteImage(string path)
        {
            ThumbnailControl tc = thumbnails[path];
            MainPanel.RowStyles.RemoveAt(0);
            MainPanel.Controls.Remove(tc);
            MainPanel.RowCount--;
            tc.Dispose();
        }

        void tc_ThumbnailClick(object sender, ThumbnailClickEventArgs e)
        {
            SetActive(e.ImgPath);
            if (ThumbnailClick != null)
                ThumbnailClick(this, e);
        }

        public void SetActive(string path)
        {
            foreach (KeyValuePair<string, ThumbnailControl> control in thumbnails)
                control.Value.SetActive(control.Key == path);
        }

        public void UpdateImage(string path, Image img)
        {
            thumbnails[path].SetImage(img);
        }

        public void Reset()
        {
            foreach (Control ctrl in MainPanel.Controls)
            {
                ctrl.Dispose();
                MainPanel.RowCount--;
                MainPanel.RowStyles.RemoveAt(0);
            }
        }

        public void MoveUp(string path)
        {
            Control ctrl = thumbnails[path];
            MainPanel.Controls.SetChildIndex(ctrl, MainPanel.Controls.GetChildIndex(ctrl) - 1);
        }
    }
}
