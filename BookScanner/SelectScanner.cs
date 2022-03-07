using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BookScanner
{
    public partial class SelectScannerForm : Form
    {
        private List<string> scanners;

        public string GetScannerName
        {
            get { return (string)ScannersListBox.SelectedItem; }
        }

        public SelectScannerForm(List<string> scanners)
        {
            InitializeComponent();
            this.scanners = scanners;
            ScannersListBox.Items.Clear();
            foreach (string scanner in scanners)
                ScannersListBox.Items.Add(scanner);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}
