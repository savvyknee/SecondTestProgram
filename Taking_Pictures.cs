using System.Windows.Forms;
using System.Windows;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Controls;
using System;
using System.Linq;

namespace SecondTestProgram
{
    public partial class Taking_Pictures : Form
    {
        System.Windows.Controls.UserControl UserControl1 = new System.Windows.Controls.UserControl();

        public Taking_Pictures()
        {
            InitializeComponent();
        }
        private FilterInfoCollection webcam;
        private VideoCaptureDevice cam;
        public string filepath = InputScannerNumber.localPath + "\\Pictures\\" + InputScannerNumber.serNo + "_image_";
       // public static string directoryName = InputScannerNumber.localPath + "\\Pictures\\";
        public string bmp = ".bmp";
        public int filesSkipped = 0;
        public int picsTakenCount;
        public string fileName;
        List<PictureBox> pictureboxList = new List<PictureBox>();

        private void Taking_Pictures_Load(object sender, System.EventArgs e)
        {
            webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach(FilterInfo VideoCaptureDevice in webcam)
                {
                comboBox1.Items.Add(VideoCaptureDevice.Name);
                }
            comboBox1.SelectedIndex = 0;
        }

        private void startPreviewButton_Click(object sender, System.EventArgs e)
        {
            cam = new VideoCaptureDevice(webcam[comboBox1.SelectedIndex].MonikerString);
            cam.NewFrame += new NewFrameEventHandler(cam_NewFrame);
            cam.Start();
            snapPictureButton.Enabled = true;

        }

        void cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bit = (Bitmap)eventArgs.Frame.Clone();
            previewBox.Image = bit;
        }

        //if there is no webcam to select, the stop button will exit the program, otherwise it stops the camera feed
        private void stopButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                cam.Stop();
                System.Windows.Forms.Application.Exit();
            }
            catch
            {
                System.Windows.Forms.Application.Exit();
            }              
        }

        private void snapPictureButton_Click(object sender, System.EventArgs e)
        {
            if (comboBox1.Items.Count == 0)
            {
                System.Windows.MessageBox.Show("No WebCam Plugged In!");
            }
            else
            {          
                picsTakenCount++;
                Stamp(previewBox.Image, System.DateTime.Now, "yyyy/MM/dd hh:mm:ss");
                filepath = InputScannerNumber.localPath + "\\Pictures\\" + InputScannerNumber.serNo + "_image_";
                fileName = filepath + picsTakenCount + bmp;
                while (File.Exists(fileName))
                {
                    filesSkipped++;
                    picsTakenCount++;
                    fileName = filepath + picsTakenCount + bmp;
                }

                //previewBox.Image.Save(filepath + picsTakenCount + bmp);
                previewBox.Image.Save(fileName);

                //List<PictureBox> pictureboxList = new List<PictureBox>();

                for (int i = 0; i < (picsTakenCount-filesSkipped); i++)
                {

                    PictureBox picture = new PictureBox
                    {
                        Name = "pictureBox" + i,
                        Size = new System.Drawing.Size(150, 100),
                        Location = new System.Drawing.Point(i * 150, 1),
                        BorderStyle = BorderStyle.FixedSingle,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        ImageLocation = fileName,                        
                    };
                    pictureboxList.Add(picture);
                }            

                foreach (PictureBox p in pictureboxList)
                {
                    p.Click += p_Click;
                    panel1.Controls.Add(p);
                }
            }
        }

        protected void Stamp(System.Drawing.Image b, System.DateTime dt, string format)
        {
            string stampString;

            if (!string.IsNullOrEmpty(format))
            {
                stampString = dt.ToString(format);
            }
            else
            {
                stampString = dt.ToString();
            }

            Graphics g = Graphics.FromImage(b);
            g.FillRectangle(Brushes.Black, 0, 0, b.Width, 20);
            g.DrawString(stampString, new Font("Arial", 12f), Brushes.White, 2, 2);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            
 
        }

        void p_Click(object sender, EventArgs e)
        {

            //System.Windows.Forms.MessageBox.Show(InputScannerNumber.localPath);

            PictureBox p = (PictureBox)sender;
            string file = p.ImageLocation.ToString();
            Process.Start(file);
        }
    }
}

