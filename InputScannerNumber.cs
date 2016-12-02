using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using AForge.Video;
using AForge.Video.DirectShow;

namespace SecondTestProgram
{
    public partial class InputScannerNumber : Form
    {
        public static string serNo;
        public static string localPath;
        //public static FolderBrowserDialog fbd = new FolderBrowserDialog();
        private VideoCaptureDevice cam;
        private FilterInfoCollection webcam;
        Taking_Pictures Taking_Pictures = new Taking_Pictures();
        public static string threeMonthsAgo;

        //this is the location of the template folder.
        //for testing this is local to my computer. 
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!MUST BE UPDATED BEFORE SHIPPING TO A SERVER BASED FOLDER!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public static string copyFolder = "\\\\pa-fs02\\proddata\\Scanner LS\\Focus 3D Scanners\\templateFolder\\";

        public InputScannerNumber()
        {
            InitializeComponent();
        }

        //sets max characters to twelve, and uses enter to push button
        private void textBox1_TextChanged(object sender, EventArgs e)
        {          
            textBox1.MaxLength = 12;             
            this.AcceptButton = button1;                                  
        }

        //when the button is clicked
        //check if there are enough characters
        private void button1_Click(object sender, EventArgs e)
        {
            serNo = textBox1.Text;

            if (serNo.Length < 12)
            {
                MessageBox.Show("Minimum Characters is 12");
            }
            else
            {
                try
                {
                    webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                    cam = new VideoCaptureDevice(webcam[0].MonikerString);
                    cam.Start();
                    cam.Stop();

                }
                catch
                {
                    const string message = "No USB Webcam Present.  Closing Program.";
                    const string caption = "No Camera";
                    var result = MessageBox.Show(message, caption,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Question);

                    if (result == DialogResult.OK)
                    {
                        System.Windows.Forms.Application.Exit();
                    }
                }

                //find country, and name the correct folder to save in
                localPath = whereDoesTheFolderGo(serNo, whatCountry()) + "\\"+ serNo;
                //MessageBox.Show( localPath);

                DateTime ninetyDays = DateTime.Now;
                int days = 90;
                while (days > 0)
                {
                    threeMonthsAgo =  "\\"+ ninetyDays.ToString("yyyy-MM-dd");
                    localPath = localPath + threeMonthsAgo;
                    
                    DirectoryInfo dir = new DirectoryInfo(localPath);
                    if (dir.Exists)
                    {
                       // MessageBox.Show("found existing directory within 90 days at "+localPath);             
                        break;
                    }
                    else
                    {
                        //MessageBox.Show("found no existing directory within 90 days at "+localPath);
                        days--;
                        ninetyDays = ninetyDays.AddDays(-1);
                        localPath = whereDoesTheFolderGo(serNo, whatCountry()) + "\\" + serNo;

                    }
                }
                if (days == 0)
                {
                    DateTime backToToday = DateTime.Today;
                    string todaysDate = backToToday.ToString("yyyy-MM-dd") + "\\";
                    localPath = whereDoesTheFolderGo(serNo, whatCountry()) + serNo + "\\" + todaysDate;
                    //MessageBox.Show("creating directory for "+localPath);
                    //create new directory for the scanner at the path specified above
                    DirectoryInfo di = Directory.CreateDirectory(localPath);

                    //copy all of the shit from the template folder.
                    //MessageBox.Show("copying template into " + localPath);
                    directoryCopy(copyFolder, localPath, true);

                    this.Hide();
                    Taking_Pictures.Show();
                }else
                {
                    //MessageBox.Show("using existing directory " + localPath);
                    this.Hide();
                    Taking_Pictures.Show();
                }
            }
        }

        //this should be the method to recursively copy a directory and its contents
        private static void directoryCopy (string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            

            if(!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found:" + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }
            try
            {
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo file in files)
                {
                    string tempPath = Path.Combine(destDirName, file.Name);
                    file.CopyTo(tempPath, false);
                }

                if (copySubDirs)
                {
                    foreach (DirectoryInfo subdir in dirs)
                    {
                        string tempPath = Path.Combine(destDirName, subdir.Name);
                        directoryCopy(subdir.FullName, tempPath, copySubDirs);
                    }
                }
            }catch
            {

            }
        }

        //determines and sets country string to two letter country code
        //sets folder appropriately
        public int whatCountry()
        {
            string countryCode = RegionInfo.CurrentRegion.TwoLetterISORegionName;
            switch (countryCode)
            {
                case "US":
                    //AMERICAN
                    return 1;
                case "DE":
                    //GERMAN
                    return 2;
                case "SG":
                    //SINGAPOREAN
                    return 3;
                case "GB":
                    //BRITISH
                    return 4;
                default:
                    return 0;
            }
        }

        //for each country, determine where the folder should go based on the 8th character of the serNo, converted to an INT
        private static string whereDoesTheFolderGo(string serNo, int whichCountry)
        {
            int eighthChar = Convert.ToInt32(serNo[8]); ;
            switch (whichCountry)
            {
                case 1:
                    //US do stuff
                    localPath = "\\\\pa-fs02\\proddata\\Scanner LS\\Focus 3D Scanners\\";
                    return localPath;
                case 2:
                    //DE do stuff
                    switch (eighthChar)
                    {
                        case 0:
                            localPath = "\\\\hq-eu-filerls01\\ScannerData01\\01_Scanner-1100\\"  ;
                            return localPath;
                        case 1:
                            localPath = "\\\\hq-eu-filerls01\\ScannerData03\\01_Archive\\01_Scanner-2000\\" ;
                            return localPath;
                        case 2:
                            localPath = "\\\\hq-eu-filerls01\\ScannerData03\\01_Archive\\01_Scanner-3000\\" ;
                            return localPath;
                        case 3:
                            localPath = "\\\\hq-eu-filerls01\\ScannerData01\\01_Scanner-4000\\" ;
                            return localPath;
                        case 4:
                            localPath = "\\\\hq-eu-filerls01\\ScannerData02\\01_Scanner-5000\\" ;
                            return localPath;
                        case 5:
                            localPath = "\\\\hq-eu-filerls01\\ScannerData04\\01_Scanner-6000\\" ;
                            return localPath;
                        case 6:
                            localPath = "\\\\hq-eu-filerls01\\ScannerData05\\01_Scanner-7000\\" ;
                            return localPath;
                        default:
                            localPath = "\\\\faroeurope.com\\hqdfs01\\ScannerData\\02_Focus_3D\\01_Scanner\\" ;
                            return localPath;
                    }
                case 3:
                    //SG do stuff
                    switch (eighthChar)
                    {
                        case 0:
                            localPath = "\\\\asia\\sg\\Scanner\\scanner\\01-Scanner\\01-Scanner-0000\\" ;
                            return localPath;
                        case 1:
                            localPath = "\\\\asia\\sg\\Scanner\\scanner\\01-Scanner\\01-Scanner-1000\\" ;
                            return localPath;
                        case 2:
                            localPath = "\\\\asia\\sg\\Scanner\\scanner\\01-Scanner\\01-Scanner-2000\\" ;
                            return localPath;
                        case 3:
                            localPath = "\\\\asia\\sg\\Scanner\\scanner\\01-Scanner\\01-Scanner-3000\\" ;
                            return localPath;
                        case 4:
                            localPath = "\\\\asia\\sg\\Scanner\\scanner\\01-Scanner\\01-Scanner-4000\\" ;
                            return localPath;
                        case 5:
                            localPath = "\\\\asia\\sg\\Scanner\\scanner\\01-Scanner\\01-Scanner-5000\\" ;
                            return localPath;
                        case 6:
                            localPath = "\\\\asia\\sg\\Scanner\\scanner\\01-Scanner\\01-Scanner-6000\\" ;
                            return localPath;
                        case 7:
                            localPath = "\\\\asia\\sg\\Scanner\\scanner\\01-Scanner\\01-Scanner-7000\\" ;
                            return localPath;
                        case 8:
                            localPath = "\\\\asia\\sg\\Scanner\\scanner\\01-Scanner\\01-Scanner-8000\\" ;
                            return localPath;
                        default:
                            localPath = "\\\\asia\\sg\\Scanner\\scanner\\01-Scanner\\01-Scanner-9000\\" ;
                            return localPath;
                    }
                case 4:
                    switch (eighthChar)
                    {
                        case 0:
                            localPath = "\\\\hq-eu-filerls01\\ScannerData01\\01_Scanner-1100\\" ;
                            return localPath;
                        case 1:
                            localPath = "\\\\hq-eu-filerls01\\ScannerData03\\01_Archive\\01_Scanner-2000\\" ;
                            return localPath;
                        case 2:
                            localPath = "\\\\hq-eu-filerls01\\ScannerData03\\01_Archive\\01_Scanner-3000\\" ;
                            return localPath;
                        case 3:
                            localPath = "\\\\hq-eu-filerls01\\ScannerData01\\01_Scanner-4000\\" ;
                            return localPath;
                        case 4:
                            localPath = "\\\\hq-eu-filerls01\\ScannerData02\\01_Scanner-5000\\" ;
                            return localPath;
                        case 5:
                            localPath = "\\\\hq-eu-filerls01\\ScannerData02\\01_Scanner-6000\\" ;
                            return localPath;
                        case 6:
                            localPath = "\\\\hq-eu-filerls01\\ScannerData05\\01_Scanner-7000\\" ;
                            return localPath;
                        default:
                            localPath = "\\\\faroeurope.com\\hqdfs01\\ScannerData\\02_Focus_3D\\01_Scanner\\" ;
                            return localPath;
                    }
                default:
                    MessageBox.Show("Your location has not yet been added. Killing Program.");
                    System.Windows.Forms.Application.Exit();
                    return serNo;
            }
        }
    }
}

