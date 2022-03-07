namespace BookScanner.Controls
{
    partial class PictureControl
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
            this.PictBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PictBox
            // 
            this.PictBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PictBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PictBox.Location = new System.Drawing.Point(3, 3);
            this.PictBox.Name = "PictBox";
            this.PictBox.Size = new System.Drawing.Size(354, 352);
            this.PictBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictBox.TabIndex = 0;
            this.PictBox.TabStop = false;
            this.PictBox.Paint += new System.Windows.Forms.PaintEventHandler(this.PictBox_Paint);
            this.PictBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictBox_MouseDown);
            this.PictBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictBox_MouseMove);
            this.PictBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictBox_MouseUp);
            // 
            // PictureControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.PictBox);
            this.Name = "PictureControl";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(360, 358);
            this.Resize += new System.EventHandler(this.PictureControl_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.PictBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PictBox;
    }
}
