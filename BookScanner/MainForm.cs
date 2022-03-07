using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WIA;
using BookScanner.Utils;

namespace BookScanner
{
    public partial class MainForm : Form
    {
        private string ProjectName;
        private bool unsavedChanges;
        private bool closing;
        private BookScannerConfig BookScannerConfig;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            BookScannerConfig = ConfigLoader.LoadConfiguration();
            RefreshColorScanButtonIcon();
        }

        #region "File Menu"
        private void SelectScannerMenuItem_Click(object sender, EventArgs e)
        {
            Scan.SelectScanner();
        }

        private void SaveAsPDFMenuItem_Click(object sender, EventArgs e)
        {
            //
        }

        private void FileCloseMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        private void ScannedImage(Image img)
        {
            string path = Utils.Cache.AddImage(ProjectName, img);
            IMControl.SetPicture(path);
        }

        #region "Menu Bar"
        private void NewProjectButton_Click(object sender, EventArgs e)
        {
            if (unsavedChanges)
                if (MessageBox.Show("Nie wszystkie zmiany zostały zapisane. Ostanie zmiany zostaną utracone. Czy chcesz kontynuować?", "Nie zapisano...", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes)
                    return;
            IMControl.Reset();
            Cache.DeleteTemp();
            ProjectName = new Random().Next().ToString();
            IMControl.Reset();
            SaveButton.Enabled = true;
            SaveAsButton.Enabled = true;
            SaveAsSeparateFiles.Enabled = true;
            ScanButton.Enabled = true;
            CutToSelectionButton.Enabled = true;
            RestoreImageButton.Enabled = true;
            ImportImageButton.Enabled = true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            CancelSaveButton.Enabled = true;
            IMControl.SaveImage(ChangesSaved, this);
        }

        private void SaveAsButton_Click(object sender, EventArgs e)
        {
            CancelSaveButton.Enabled = true;
            IMControl.SaveAsImage(ChangesSaved, this);
        }

        private void CancelSave()
        {
            IMControl.CancelSave();
            CancelSaveButton.Enabled = false;
        }

        private void ChangesSaved(bool success)
        {
            if (success)
            {
                this.Invoke((Action)delegate {ChangesSaved();});
                if (closing)
                    this.Invoke((Action)delegate {Close();});
            }
            CancelSaveButton.Enabled = false;
            closing = false;
        }

        private void ChangesSaved()
        {
            SaveButton.Enabled = false;
            unsavedChanges = false;
            CancelSaveButton.Enabled = false;
        }

        private void ScanButton_Click(object sender, EventArgs e)
        {
            try
            {
                AfterScan(Scan.DoScan(this, BookScannerConfig.colorScan));
            }
            catch (Exception)
            {
            }
        }

        public void AfterScan(Image img)
        {
            ScannedImage(new Bitmap(img));
            img.Dispose();
            ChangesMade();
        }

        private void ImportImageButton_Click(object sender, EventArgs e)
        {
            if (OFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (string filePath in OFD.FileNames)
                {
                    string path = Utils.Cache.CopyFile(ProjectName, filePath);
                    if (path != null)
                    {
                        IMControl.SetPicture(path);
                    }
                }
                ChangesMade();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            IMControl.CutToSelection();
            ChangesMade();
        }

        private void RestoreImageButton_Click(object sender, EventArgs e)
        {
            IMControl.RestoreImage();
            ChangesMade();
        }

        private void MoveImageDownButton_Click(object sender, EventArgs e)
        {
            IMControl.MoveDown();
        }

        private void MoveImageUpButton_Click(object sender, EventArgs e)
        {
            IMControl.MoveUp();
        }

        private void DeleteImageButton_Click(object sender, EventArgs e)
        {
            IMControl.Delete();
        }
        #endregion

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (unsavedChanges)
            {
                e.Cancel = true;
                DialogResult result = MessageBox.Show("Nie wszystkie zmiany zostały zapisane. Ostanie zmiany zostaną utracone. Czy chcesz zapisać zmiany?", "Niezapisane zmiany", MessageBoxButtons.YesNoCancel);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    closing = true;
                    SaveButton_Click(null, null);
                }
                else if (result == System.Windows.Forms.DialogResult.Cancel)
                    return;
                else
                {
                    unsavedChanges = false;
                    Close();
                }
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            IMControl.Reset();
            Cache.DeleteTemp();
        }

        private void IMControl_ThumbnailClick(object sender, Controls.ThumbnailClickEventArgs e)
        {
            MoveImageDownButton.Enabled = e != null;
            MoveImageUpButton.Enabled = e != null;
            DeleteImageButton.Enabled = e != null;
        }

        private void ChangesMade()
        {
            SaveButton.Enabled = true;
            unsavedChanges = true;
        }

        private void IMControl_ChangesMade(object sender, EventArgs e)
        {
            ChangesMade();
        }

        private void ToogleColorScanningButton_Click(object sender, EventArgs e)
        {
            BookScannerConfig.colorScan = !BookScannerConfig.colorScan;
            ConfigLoader.SaveConfiguration(BookScannerConfig);
            RefreshColorScanButtonIcon();
        }

        private void RefreshColorScanButtonIcon()
        {
            ToogleColorScanningButton.Image = BookScannerConfig.colorScan ? Properties.Resources.color_scan : Properties.Resources.gray_scan;
        }

        private void bookScannerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm ab = new AboutForm();
            ab.ShowDialog();
            ab.Dispose();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && ScanButton.Enabled)
                ScanButton_Click(null, null);
        }

        public void ReportSaveProgress(int progress, int count)
        {
            ActionProgressLabel.Visible = progress != count;
            ActionProgressBar.Visible = ActionProgressLabel.Visible;
            ActionProgressLabel.Text = "Zapisywanie...";
            ActionProgressBar.Value = progress;
            ActionProgressBar.Maximum = count;
        }

        private void SaveAsSeparateFiles_Click(object sender, EventArgs e)
        {
            IMControl.SaveAsSeparate(ChangesSaved, this);
            CancelSaveButton.Enabled = true;
        }

        private void CancelSaveButton_Click(object sender, EventArgs e)
        {
            CancelSave();
        }
    }
}
