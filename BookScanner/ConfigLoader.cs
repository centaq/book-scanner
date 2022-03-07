using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace BookScanner
{
    public class BookScannerConfig
    {
        public bool colorScan;

        public BookScannerConfig() { }

        public BookScannerConfig(bool colorScan)
        {
            this.colorScan = colorScan;
        }

        public void setColorScan(bool colorScan)
        {
            this.colorScan = colorScan;
        }

        public bool getColorScan()
        {
            return colorScan;
        }
    }

    class ConfigLoader
    {
        private const string CONFID_FILE_NAME = "config.bc";

        public static void SaveConfiguration(BookScannerConfig bc)
        {
            XmlSerializer ser = new XmlSerializer(bc.GetType());
            using (FileStream fs = new FileStream(CONFID_FILE_NAME, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                ser.Serialize(fs, bc);
            }
        }

        public static BookScannerConfig LoadConfiguration()
        {
            try 
            {
                using (FileStream fs = new FileStream(CONFID_FILE_NAME, FileMode.Open, FileAccess.Read))
                {
                    BookScannerConfig bc;
                    XmlSerializer ser = new XmlSerializer(typeof(BookScannerConfig));
                    bc = (BookScannerConfig)ser.Deserialize(fs);
                    return bc;
                }
            }
            catch (Exception)
            {
                return new BookScannerConfig(true);
            }
        }
    }
}
