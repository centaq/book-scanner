using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using WIA;

namespace BookScanner.Utils
{
    public static class Scan
    {
        /*struct ScanObject
        {
            public Control ctrl;
            public bool color;
        }
        
        struct ScanResult
        {
            public Control ctrl;
            public Image img;
        }
        
        private static BackgroundWorker worker;*/
        private static bool scanInProgress = false;
        private static DeviceInfo selectedDevice;

        private static List<DeviceInfo> GetScannersList()
        {
            List<DeviceInfo> result = new List<DeviceInfo>();
            DeviceManager deviceManager = new DeviceManager();
            foreach (DeviceInfo info in deviceManager.DeviceInfos)
                if (info.Type == WiaDeviceType.ScannerDeviceType)
                    result.Add(info);
            return result;
        }

        private static List<string> GetScannersNames()
        {
            List<string> result = new List<string>();
            foreach (DeviceInfo info in GetScannersList())
                foreach (Property p in info.Properties)
                    if (p.Name == "Name")
                        result.Add(((WIA.IProperty)p).get_Value().ToString());
            return result;
        }

        private static DeviceInfo GetScanner(string scannerName)
        {
            foreach (DeviceInfo info in GetScannersList())
                foreach (Property p in info.Properties)
                    if (p.Name == "Name" && ((WIA.IProperty)p).get_Value().ToString() == scannerName)
                        return info;
            return null;
        }
        
        public static void SelectScanner()
        {
            List<string> scanners = GetScannersNames();
            SelectScannerForm ssf = new SelectScannerForm(scanners);
            if (ssf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                selectedDevice = GetScanner(ssf.GetScannerName);
            }
        }

        public static Image DoScan(Control ctrl, bool color)
        {
            /*
            if (worker == null)
            {
              //  worker = new BackgroundWorker();
              //  worker.DoWork += new DoWorkEventHandler(worker_DoWork);
              //  worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            }*/
            if (selectedDevice == null)
            {
                List<DeviceInfo> scanners = GetScannersList();
                if (scanners.Count > 0)
                    selectedDevice = GetScannersList().First();
            }
            if (selectedDevice != null)
            {
                if (scanInProgress)
                {
                    System.Windows.Forms.MessageBox.Show("Skanowanie w toku. Proszę czekać.");
                    return null;
                }
                scanInProgress = true;
                return ScanInternal(color);
               // worker.RunWorkerAsync(new ScanObject() { ctrl = ctrl, color = color });
            }
            else
                System.Windows.Forms.MessageBox.Show("Proszę wybrać skaner.");
            return null;
        }

       /* static void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            ScanObject so = (ScanObject)e.Argument;
            e.Result = new ScanResult() { img = ScanInternal(so.color), ctrl = so.ctrl };
        }

        static void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                ScanResult sr = (ScanResult)e.Result;
                sr.ctrl.Invoke((Action)delegate { ((MainForm)sr.ctrl).AfterScan(sr.img); }, null);
            }
            scanInProgress = false;
        }
        */
        private static Image ScanInternal(bool color)
        {
            WIA.CommonDialog commonDialog = new WIA.CommonDialog();
            Device device = selectedDevice.Connect();
            device.Items[1].Properties["Current Intent"].set_Value(color ? 1 : 2);

            ImageFile image = (ImageFile)commonDialog.ShowTransfer(device.Items[1]);

            scanInProgress = false;

            byte[] bytes = (byte[])image.FileData.get_BinaryData();
            using (MemoryStream ms = new MemoryStream(bytes))
                return Image.FromStream(ms);
        }
    }
}
