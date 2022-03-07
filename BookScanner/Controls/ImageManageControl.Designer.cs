namespace BookScanner.Controls
{
    partial class ImageManageControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.PicControl = new BookScanner.Controls.PictureControl();
            this.thumbnailContainer = new BookScanner.Controls.ThumbnailContainer();
            this.SFD = new System.Windows.Forms.SaveFileDialog();
            this.FBD = new System.Windows.Forms.FolderBrowserDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.PicControl, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.thumbnailContainer, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(549, 413);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // PicControl
            // 
            this.PicControl.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.PicControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.PicControl.Location = new System.Drawing.Point(153, 3);
            this.PicControl.Name = "PicControl";
            this.PicControl.Padding = new System.Windows.Forms.Padding(3);
            this.PicControl.Size = new System.Drawing.Size(360, 407);
            this.PicControl.TabIndex = 0;
            this.PicControl.ImageChanged += new System.EventHandler<BookScanner.Controls.PictureControl.ImageChangedEventArgs>(this.PicControl_ImageChanged);
            this.PicControl.Resize += new System.EventHandler(this.PicControl_Resize);
            // 
            // thumbnailContainer
            // 
            this.thumbnailContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.thumbnailContainer.Location = new System.Drawing.Point(3, 3);
            this.thumbnailContainer.Name = "thumbnailContainer";
            this.thumbnailContainer.Size = new System.Drawing.Size(144, 407);
            this.thumbnailContainer.TabIndex = 1;
            this.thumbnailContainer.ThumbnailClick += new System.EventHandler<BookScanner.Controls.ThumbnailClickEventArgs>(this.thumbnailContainer_ThumbnailClick);
            // 
            // SFD
            // 
            this.SFD.DefaultExt = "tiff";
            this.SFD.Filter = "TIFF|*.tiff";
            // 
            // ImageManageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ImageManageControl";
            this.Size = new System.Drawing.Size(549, 413);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private PictureControl PicControl;
        private ThumbnailContainer thumbnailContainer;
        private System.Windows.Forms.SaveFileDialog SFD;
        private System.Windows.Forms.FolderBrowserDialog FBD;
    }
}
