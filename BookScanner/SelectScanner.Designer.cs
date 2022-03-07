namespace BookScanner
{
    partial class SelectScannerForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ScannersListBox = new System.Windows.Forms.ListBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelFormButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ScannersListBox
            // 
            this.ScannersListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScannersListBox.FormattingEnabled = true;
            this.ScannersListBox.Location = new System.Drawing.Point(3, 3);
            this.ScannersListBox.Name = "ScannersListBox";
            this.ScannersListBox.Size = new System.Drawing.Size(228, 69);
            this.ScannersListBox.TabIndex = 0;
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.Location = new System.Drawing.Point(237, 12);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 1;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelFormButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelFormButton.Location = new System.Drawing.Point(237, 41);
            this.CancelFormButton.Name = "CancelButton";
            this.CancelFormButton.Size = new System.Drawing.Size(75, 23);
            this.CancelFormButton.TabIndex = 2;
            this.CancelFormButton.Text = "Anuluj";
            this.CancelFormButton.UseVisualStyleBackColor = true;
            this.CancelFormButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SelectScannerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 76);
            this.Controls.Add(this.CancelFormButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.ScannersListBox);
            this.Name = "SelectScannerForm";
            this.Text = "Wybierz skaner";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ScannersListBox;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelFormButton;
    }
}