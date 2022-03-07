namespace BookScanner.Controls
{
    partial class ThumbnailControl
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
            if (PictBox.Image != null)
                PictBox.Image.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PictBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PictBox
            // 
            this.PictBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictBox.Location = new System.Drawing.Point(0, 0);
            this.PictBox.Name = "PictBox";
            this.PictBox.Size = new System.Drawing.Size(123, 178);
            this.PictBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictBox.TabIndex = 0;
            this.PictBox.TabStop = false;
            this.PictBox.Click += new System.EventHandler(this.PictBox_Click);
            // 
            // ThumbnailControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.PictBox);
            this.MaximumSize = new System.Drawing.Size(125, 180);
            this.MinimumSize = new System.Drawing.Size(125, 180);
            this.Name = "ThumbnailControl";
            this.Size = new System.Drawing.Size(123, 178);
            ((System.ComponentModel.ISupportInitialize)(this.PictBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PictBox;
    }
}
