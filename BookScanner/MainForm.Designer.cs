namespace BookScanner
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MenuStrip = new System.Windows.Forms.ToolStrip();
            this.NewProjectButton = new System.Windows.Forms.ToolStripButton();
            this.SaveButton = new System.Windows.Forms.ToolStripButton();
            this.SaveAsButton = new System.Windows.Forms.ToolStripButton();
            this.CancelSaveButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ScanButton = new System.Windows.Forms.ToolStripButton();
            this.ImportImageButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CutToSelectionButton = new System.Windows.Forms.ToolStripButton();
            this.RestoreImageButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.MoveImageDownButton = new System.Windows.Forms.ToolStripButton();
            this.MoveImageUpButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.DeleteImageButton = new System.Windows.Forms.ToolStripButton();
            this.ToogleColorScanningButton = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectScannerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.SaveAsSeparateFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsPDFMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.FileCloseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PomocMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookScannerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            this.IMControl = new BookScanner.Controls.ImageManageControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ActionProgressLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ActionProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.MenuStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewProjectButton,
            this.SaveButton,
            this.SaveAsButton,
            this.CancelSaveButton,
            this.toolStripSeparator2,
            this.ScanButton,
            this.ImportImageButton,
            this.toolStripSeparator1,
            this.CutToSelectionButton,
            this.RestoreImageButton,
            this.toolStripSeparator3,
            this.MoveImageDownButton,
            this.MoveImageUpButton,
            this.toolStripSeparator4,
            this.DeleteImageButton,
            this.ToogleColorScanningButton});
            this.MenuStrip.Location = new System.Drawing.Point(0, 24);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(658, 31);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Text = "toolStrip1";
            // 
            // NewProjectButton
            // 
            this.NewProjectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.NewProjectButton.Image = global::BookScanner.Properties.Resources.document_file;
            this.NewProjectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewProjectButton.Name = "NewProjectButton";
            this.NewProjectButton.Size = new System.Drawing.Size(28, 28);
            this.NewProjectButton.Text = "Nowy";
            this.NewProjectButton.Click += new System.EventHandler(this.NewProjectButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveButton.Enabled = false;
            this.SaveButton.Image = global::BookScanner.Properties.Resources.save;
            this.SaveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(28, 28);
            this.SaveButton.Text = "Zapisz";
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // SaveAsButton
            // 
            this.SaveAsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveAsButton.Enabled = false;
            this.SaveAsButton.Image = global::BookScanner.Properties.Resources.save_as;
            this.SaveAsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveAsButton.Name = "SaveAsButton";
            this.SaveAsButton.Size = new System.Drawing.Size(28, 28);
            this.SaveAsButton.Text = "Zapisz jako";
            this.SaveAsButton.Click += new System.EventHandler(this.SaveAsButton_Click);
            // 
            // CancelSaveButton
            // 
            this.CancelSaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CancelSaveButton.Enabled = false;
            this.CancelSaveButton.Image = global::BookScanner.Properties.Resources.cancel_save;
            this.CancelSaveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CancelSaveButton.Name = "CancelSaveButton";
            this.CancelSaveButton.Size = new System.Drawing.Size(28, 28);
            this.CancelSaveButton.Text = "Anuluj zapisywanie";
            this.CancelSaveButton.Click += new System.EventHandler(this.CancelSaveButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // ScanButton
            // 
            this.ScanButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ScanButton.Enabled = false;
            this.ScanButton.Image = global::BookScanner.Properties.Resources.scanner;
            this.ScanButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ScanButton.Name = "ScanButton";
            this.ScanButton.Size = new System.Drawing.Size(28, 28);
            this.ScanButton.Text = "Skanuj";
            this.ScanButton.Click += new System.EventHandler(this.ScanButton_Click);
            // 
            // ImportImageButton
            // 
            this.ImportImageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ImportImageButton.Enabled = false;
            this.ImportImageButton.Image = global::BookScanner.Properties.Resources.import_image;
            this.ImportImageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ImportImageButton.Name = "ImportImageButton";
            this.ImportImageButton.Size = new System.Drawing.Size(28, 28);
            this.ImportImageButton.Text = "Importuj obraz";
            this.ImportImageButton.Click += new System.EventHandler(this.ImportImageButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // CutToSelectionButton
            // 
            this.CutToSelectionButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CutToSelectionButton.Enabled = false;
            this.CutToSelectionButton.Image = global::BookScanner.Properties.Resources.cut;
            this.CutToSelectionButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CutToSelectionButton.Name = "CutToSelectionButton";
            this.CutToSelectionButton.Size = new System.Drawing.Size(28, 28);
            this.CutToSelectionButton.Text = "Przytnij do zaznaczenia";
            this.CutToSelectionButton.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // RestoreImageButton
            // 
            this.RestoreImageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RestoreImageButton.Enabled = false;
            this.RestoreImageButton.Image = global::BookScanner.Properties.Resources.undo;
            this.RestoreImageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RestoreImageButton.Name = "RestoreImageButton";
            this.RestoreImageButton.Size = new System.Drawing.Size(28, 28);
            this.RestoreImageButton.Text = "Przywróć obraz";
            this.RestoreImageButton.Click += new System.EventHandler(this.RestoreImageButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // MoveImageDownButton
            // 
            this.MoveImageDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MoveImageDownButton.Enabled = false;
            this.MoveImageDownButton.Image = global::BookScanner.Properties.Resources.arrow_down;
            this.MoveImageDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MoveImageDownButton.Name = "MoveImageDownButton";
            this.MoveImageDownButton.Size = new System.Drawing.Size(28, 28);
            this.MoveImageDownButton.Text = "Przesuń obraz w dół";
            this.MoveImageDownButton.Click += new System.EventHandler(this.MoveImageDownButton_Click);
            // 
            // MoveImageUpButton
            // 
            this.MoveImageUpButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MoveImageUpButton.Enabled = false;
            this.MoveImageUpButton.Image = global::BookScanner.Properties.Resources.arrow_up;
            this.MoveImageUpButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MoveImageUpButton.Name = "MoveImageUpButton";
            this.MoveImageUpButton.Size = new System.Drawing.Size(28, 28);
            this.MoveImageUpButton.Text = "Przesuń obraz w górę";
            this.MoveImageUpButton.Click += new System.EventHandler(this.MoveImageUpButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 31);
            // 
            // DeleteImageButton
            // 
            this.DeleteImageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DeleteImageButton.Enabled = false;
            this.DeleteImageButton.Image = global::BookScanner.Properties.Resources.delete;
            this.DeleteImageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteImageButton.Name = "DeleteImageButton";
            this.DeleteImageButton.Size = new System.Drawing.Size(28, 28);
            this.DeleteImageButton.Text = "Usuń obraz";
            this.DeleteImageButton.Click += new System.EventHandler(this.DeleteImageButton_Click);
            // 
            // ToogleColorScanningButton
            // 
            this.ToogleColorScanningButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToogleColorScanningButton.Image = global::BookScanner.Properties.Resources.color_scan;
            this.ToogleColorScanningButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToogleColorScanningButton.Name = "ToogleColorScanningButton";
            this.ToogleColorScanningButton.Size = new System.Drawing.Size(28, 28);
            this.ToogleColorScanningButton.Text = "Przełącz skanowanie kolor/czarno-białe";
            this.ToogleColorScanningButton.Click += new System.EventHandler(this.ToogleColorScanningButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.PomocMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(658, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelectScannerMenuItem,
            this.toolStripMenuItem2,
            this.SaveAsSeparateFiles,
            this.SaveAsPDFMenuItem,
            this.toolStripMenuItem1,
            this.FileCloseMenuItem});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // SelectScannerMenuItem
            // 
            this.SelectScannerMenuItem.Name = "SelectScannerMenuItem";
            this.SelectScannerMenuItem.Size = new System.Drawing.Size(220, 22);
            this.SelectScannerMenuItem.Text = "Wybierz skaner";
            this.SelectScannerMenuItem.Click += new System.EventHandler(this.SelectScannerMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(217, 6);
            // 
            // SaveAsSeparateFiles
            // 
            this.SaveAsSeparateFiles.Enabled = false;
            this.SaveAsSeparateFiles.Name = "SaveAsSeparateFiles";
            this.SaveAsSeparateFiles.Size = new System.Drawing.Size(220, 22);
            this.SaveAsSeparateFiles.Text = "Zapisz jako pojedyńcze pliki";
            this.SaveAsSeparateFiles.Click += new System.EventHandler(this.SaveAsSeparateFiles_Click);
            // 
            // SaveAsPDFMenuItem
            // 
            this.SaveAsPDFMenuItem.Enabled = false;
            this.SaveAsPDFMenuItem.Name = "SaveAsPDFMenuItem";
            this.SaveAsPDFMenuItem.Size = new System.Drawing.Size(220, 22);
            this.SaveAsPDFMenuItem.Text = "Zapisz jako PDF";
            this.SaveAsPDFMenuItem.Visible = false;
            this.SaveAsPDFMenuItem.Click += new System.EventHandler(this.SaveAsPDFMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(217, 6);
            // 
            // FileCloseMenuItem
            // 
            this.FileCloseMenuItem.Name = "FileCloseMenuItem";
            this.FileCloseMenuItem.Size = new System.Drawing.Size(220, 22);
            this.FileCloseMenuItem.Text = "Wyjście";
            this.FileCloseMenuItem.Click += new System.EventHandler(this.FileCloseMenuItem_Click);
            // 
            // PomocMenuItem
            // 
            this.PomocMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bookScannerToolStripMenuItem});
            this.PomocMenuItem.Name = "PomocMenuItem";
            this.PomocMenuItem.Size = new System.Drawing.Size(57, 20);
            this.PomocMenuItem.Text = "Pomoc";
            // 
            // bookScannerToolStripMenuItem
            // 
            this.bookScannerToolStripMenuItem.Name = "bookScannerToolStripMenuItem";
            this.bookScannerToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.bookScannerToolStripMenuItem.Text = "Book Scanner - informacje";
            this.bookScannerToolStripMenuItem.Click += new System.EventHandler(this.bookScannerToolStripMenuItem_Click);
            // 
            // OFD
            // 
            this.OFD.Filter = "\"Image Files|*.bmp;*.jpg;*.jpeg;*.gif;*.tif;*.tiff;*.png";
            this.OFD.Multiselect = true;
            // 
            // IMControl
            // 
            this.IMControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IMControl.Location = new System.Drawing.Point(0, 55);
            this.IMControl.Name = "IMControl";
            this.IMControl.Size = new System.Drawing.Size(658, 342);
            this.IMControl.TabIndex = 2;
            this.IMControl.ThumbnailClick += new System.EventHandler<BookScanner.Controls.ThumbnailClickEventArgs>(this.IMControl_ThumbnailClick);
            this.IMControl.ChangesMade += new System.EventHandler<System.EventArgs>(this.IMControl_ChangesMade);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionProgressLabel,
            this.ActionProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 375);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(658, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ActionProgressLabel
            // 
            this.ActionProgressLabel.Name = "ActionProgressLabel";
            this.ActionProgressLabel.Size = new System.Drawing.Size(52, 17);
            this.ActionProgressLabel.Text = "Progress";
            this.ActionProgressLabel.Visible = false;
            // 
            // ActionProgressBar
            // 
            this.ActionProgressBar.Name = "ActionProgressBar";
            this.ActionProgressBar.Size = new System.Drawing.Size(100, 16);
            this.ActionProgressBar.Tag = "";
            this.ActionProgressBar.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 397);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.IMControl);
            this.Controls.Add(this.MenuStrip);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Book Scanner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip MenuStrip;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FileCloseMenuItem;
        private System.Windows.Forms.ToolStripButton ScanButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton NewProjectButton;
        private System.Windows.Forms.ToolStripButton SaveButton;
        private System.Windows.Forms.ToolStripButton SaveAsButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton CutToSelectionButton;
        private System.Windows.Forms.ToolStripButton RestoreImageButton;
        private Controls.ImageManageControl IMControl;
        private System.Windows.Forms.ToolStripMenuItem SaveAsPDFMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem SelectScannerMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton MoveImageDownButton;
        private System.Windows.Forms.ToolStripButton MoveImageUpButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton DeleteImageButton;
        private System.Windows.Forms.OpenFileDialog OFD;
        private System.Windows.Forms.ToolStripButton ImportImageButton;
        private System.Windows.Forms.ToolStripButton ToogleColorScanningButton;
        private System.Windows.Forms.ToolStripMenuItem PomocMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookScannerToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ActionProgressLabel;
        private System.Windows.Forms.ToolStripProgressBar ActionProgressBar;
        private System.Windows.Forms.ToolStripMenuItem SaveAsSeparateFiles;
        private System.Windows.Forms.ToolStripButton CancelSaveButton;
    }
}

