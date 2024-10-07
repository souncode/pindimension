using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
using ThridLibray;
using TraffoVision.Controllers;
using Emgu.CV.Structure;
using Emgu.CV;
using TraffoVision.Models;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;
using Newtonsoft.Json;

using System.IO;
using ControlManager;
using TraffoVision.Constant;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;




namespace TraffoVision
{
    public partial class Home : Form
    {
        private object _locker = new object();
        int count;
        int passCount;
        int failCount;
        bool isRunning = false;
        List<PictureBox> pictureboxList = new List<PictureBox>(); 
        DHCamera[] cameraList;          // 相机数组
        const int CameraNumMax = 2;     // 最大支持相机个数
        int findCameraNum = 0;          // 发现的相机个数
        CrossLine crossLineLeft = new CrossLine();
        CrossLine crossLineRight = new CrossLine();
        ProcessVision Processvision= new ProcessVision();
        FormController formController = new FormController();
        int value =1297;        int value2;
        Button btn;
        Bitmap bmp;
        Image<Bgr, byte> img;
        private List<Button> pinBoxListFromImage1 = new List<Button>();
        private List<Button> pinBoxListFromImage2 = new List<Button>();
        private ICModel modelConfig = new ICModel();
        LineSegment2D thresholdLineLeft = new LineSegment2D();
        LineSegment2D thresholdLineRight = new LineSegment2D();
        Bitmap pbLeft_bmp, pbRight_bmp;
        private Image<Bgr, byte> srcIplImage1;
        private Image<Bgr, byte> srcIplImage2;
        bool isPassLeft = false;
        bool isPassRight = false;


        public Home()
        {
            InitializeComponent();
        }

  
        private void Form1_Shown(object sender, EventArgs e)
        {
            btnTrigger.Enabled = false;
            btnClose.Enabled = false;
            btnProcess.Enabled = false;

            pictureboxList.Add(pbLeft);
            pictureboxList.Add(pbRight);
            cameraList = new DHCamera[CameraNumMax];
            for (int i = 0; i < CameraNumMax; i++)
            {
                cameraList[i] = new DHCamera();
            }
        }
       


        private void btnOpen_Click(object sender, EventArgs e)
        {
            List<IDeviceInfo> li = Enumerator.EnumerateDevices();
            findCameraNum = li.Count;

            for (int i = 0; i < CameraNumMax; i++)
            {
                if (i < findCameraNum)
                {
                    if (cameraList[i].Open(i, pictureboxList[i]))
                    {
                        btnOpen.Enabled = false;
                        btnClose.Enabled = true;
                        btnTrigger.Enabled = true;
                        debugStrip.Text = "Camera :"+i+" connected";
                    }
                }
            }
        

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < CameraNumMax; i++)
            {
                if (i < findCameraNum)
                {
                    if (cameraList[i].Close())
                    {
                        btnOpen.Enabled = true;
                        btnClose.Enabled = false;
                        btnTrigger.Enabled = false;
                    }
                }
            }
        }


        protected override void OnClosed(EventArgs e)
        {
            for (int i = 0; i < CameraNumMax; i++)
            {
                cameraList[i].Dispose();
            }

            base.OnClosed(e);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            panelLeft.BackColor= Color.FromArgb(31, 32, 33); ;
            if (!Directory.Exists(AppConstant.MODELS_FOLDER_PATH))
            {
                Directory.CreateDirectory(AppConstant.MODELS_FOLDER_PATH);
            }
            else
            {
             
                loadModels();
                toolStripComboBoxModel.SelectedIndex = 0;
            }
            Bitmap bmptemp = (Bitmap)pbLeft.Image;
         //   btnOpen.PerformClick();
        }
        private void loadModels()
        {
            toolStripComboBoxModel.Items.Clear();
            toolStripComboBoxModel.Items.AddRange(new FormController().getListModels().ToArray());
            if (toolStripComboBoxModel.Items.Count > 0)
            {
                if (toolStripComboBoxModel.Text == "") toolStripComboBoxModel.SelectedIndex = 0;
            }
        }

        private void initListView()
        {
            listView1.Clear();
            listView2.Clear();
            listView1.View = View.Details;
            listView1.Columns.Add("PIN");
            listView1.Columns.Add("Status");
            listView1.Columns.Add("Distance");
            listView2.View = View.Details;
            listView2.Columns.Add("PIN");
            listView2.Columns.Add("Status");
            listView2.Columns.Add("Distance");
            isPassLeft = true;
            isPassRight = true;
        }
        private void process_Click(object sender, EventArgs e)
        { 
            drawLine();
            initListView();
           
            if (pbLeft == null || pbRight == null)
            {
                MessageBox.Show("Not found Img1 or Img 2");
                return;
            }
            Console.WriteLine("pin box count :" + pinBoxListFromImage1.Count);

            foreach (Button button in pinBoxListFromImage1)
            {
                button.FlatAppearance.BorderColor = Color.LimeGreen;
                button.Text = "";
                double realRatioW = ((Bitmap)pbLeft.Image).Width / (pbLeft.Width);
                double realRatioH = ((Bitmap)pbLeft.Image).Height / (pbLeft.Height);
                int x = Convert.ToInt32(button.Location.X * realRatioW);
                int y = Convert.ToInt32(button.Location.Y * realRatioH);
                int w = Convert.ToInt32(button.Width * realRatioW);
                int h = Convert.ToInt32(button.Height * realRatioH);
                Bitmap croppedImgLeft = Processvision.cropImage((Bitmap)pbLeft.Image, x, y, w, h);
                ICPin iCPin = this.modelConfig.Image1ICPins.Where(p => p.Name == button.Name).First();
                PinInf pinData = Processvision.processPinData(button, croppedImgLeft, modelConfig.YCrossLine1, x, y, iCPin.ThresholdMin, iCPin.ThresholdMax, modelConfig.MinContourArea, modelConfig.MaxContourArea);
                Console.WriteLine("Image left " + button.Name + " Pin to Line : " + (modelConfig.YCrossLine1 - pinData.MaxY) + " Px");
                button.Text = (modelConfig.YCrossLine1 - pinData.MaxY).ToString();
                button.MouseUp += Button_MouseUpLeft;
                pinData.IsPass = (modelConfig.YCrossLine1 - pinData.MaxY) < Int32.Parse(tbLimit.Text);

               
                if (!pinData.IsPass)
                {
                    button.FlatAppearance.BorderColor = Color.Red;
                    isPassRight = false;
                }
               
                string[] arr = new string[3];
                ListViewItem itm1;
                arr[0] = button.Name;
                arr[1] = pinData.IsPass ? "OK" : "NG";
                arr[2] = (modelConfig.YCrossLine1 - pinData.MaxY).ToString();
                itm1 = new ListViewItem(arr);
                itm1.ForeColor = pinData.IsPass ? System.Drawing.Color.LimeGreen : System.Drawing.Color.Red;
                listView1.Items.Add(itm1);

            }
            foreach (Button button in pinBoxListFromImage2)
            {
                button.FlatAppearance.BorderColor = Color.LimeGreen;
                button.Text = "";
                double realRatioW = ((Bitmap)pbLeft.Image).Width / (pbLeft.Width);
                double realRatioH = ((Bitmap)pbLeft.Image).Height / (pbLeft.Height);
                int x = Convert.ToInt32(button.Location.X * realRatioW);
                int y = Convert.ToInt32(button.Location.Y * realRatioH);
                int w = Convert.ToInt32(button.Width * realRatioW);
                int h = Convert.ToInt32(button.Height * realRatioH);
                Bitmap croppedImgRight = Processvision.cropImage((Bitmap)pbRight.Image, x, y, w, h);
                ICPin iCPin = this.modelConfig.Image2ICPins.Where(p => p.Name == button.Name).First();
                Console.WriteLine("Image2");
                PinInf pinData = Processvision.processPinData(button, croppedImgRight, modelConfig.YCrossLine2, x, y, iCPin.ThresholdMin, iCPin.ThresholdMax, modelConfig.MinContourArea, modelConfig.MaxContourArea);
                Console.WriteLine("Image right " + button.Name + " Pin to Line : " + (modelConfig.YCrossLine2 - pinData.MaxY) + " Px");
                button.Text = (modelConfig.YCrossLine2 - pinData.MaxY).ToString();
                button.MouseUp += Button_MouseUpRight;
                pinData.IsPass = (modelConfig.YCrossLine2 - pinData.MaxY) < Int32.Parse(tbLimit.Text);
                if (!pinData.IsPass)
                {
                    button.FlatAppearance.BorderColor = Color.Red;
                    isPassLeft = false;
                }
                string[] arr = new string[3];
                ListViewItem itm;
                arr[0] = button.Name;
                arr[1] = pinData.IsPass ? "OK" : "NG";
                arr[2] = (modelConfig.YCrossLine2 - pinData.MaxY).ToString();
                itm = new ListViewItem(arr);
                itm.ForeColor = pinData.IsPass ? System.Drawing.Color.LimeGreen : System.Drawing.Color.Red;
                listView2.Items.Add(itm);
            }



            if (!isPassLeft || !isPassRight)
            {
                debugStrip.Text = "Fail";
                failCount++;
                lbFail.Text = failCount.ToString();
                btnLogo.BackColor = Color.Red;

            }
            else {
                debugStrip.Text = "Pass";
                passCount++;
                lbPass.Text = passCount.ToString();
                btnLogo.BackColor = Color.White;
            }
            

        }

        private void Button_MouseUpLeft(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            Console.WriteLine("Button : " + button.Name + " is Mouse Up");
            double realRatio = ((Bitmap)pbLeft.Image).Width / (pbLeft.Width);
            double realRatio2 = ((Bitmap)pbLeft.Image).Height / (pbLeft.Height);
            int x = Convert.ToInt32(button.Location.X * realRatio);
            int y = Convert.ToInt32(button.Location.Y * realRatio2);
            int w = Convert.ToInt32(button.Width * realRatio);
            int h = Convert.ToInt32(button.Height * realRatio2);
            Console.WriteLine($"x:{x} y:{y} w:{w} h:{h}");
            Bitmap t = (Bitmap)pbLeft.Image;
            Bitmap tmpPic1 = Processvision.cropImage(t, x, y, w, h);
            Image<Bgr, byte> ts = tmpPic1.ToImage<Bgr, byte>();
            Image<Gray, byte> imgoutput = ts.Convert<Gray, byte>().ThresholdBinary(new Gray(100), new Gray(255));
            Image<Bgr, byte> tmpPic2 = tmpPic1.ToImage<Bgr, byte>();
            VectorOfVectorOfPoint contours2 = Processvision.FindContours(imgoutput, 1000, 20000);
            CvInvoke.DrawContours(tmpPic2, contours2, -1, new MCvScalar(255, 0, 0), 1);
            pbPinCropLeft.Image = tmpPic2.ToBitmap();
            Console.WriteLine("Size " + contours2.Size.ToString());

            if (contours2.Size != 0)
            {

                Processvision.FindPointsUpperLine(contours2, 1016, y);
                Console.WriteLine("Max Y" + (Processvision.FindPointWithMaxY(Processvision.FindPointsUpperLine(contours2, 1016, y)).Y + y));

            }
            else { Console.WriteLine("Not found contour"); }

        }
        private void Button_MouseUpRight(object sender, MouseEventArgs e)
        {

            Button button = sender as Button;
            Console.WriteLine("Button : " + button.Name + " is Mouse Up");
            double realRatio = ((Bitmap)pbRight.Image).Width / (pbRight.Width);
            double realRatio2 = ((Bitmap)pbRight.Image).Height / (pbRight.Height);
            int x = Convert.ToInt32(button.Location.X * realRatio);
            int y = Convert.ToInt32(button.Location.Y * realRatio2);
            int w = Convert.ToInt32(button.Width * realRatio);
            int h = Convert.ToInt32(button.Height * realRatio2);
            Console.WriteLine($"x:{x} y:{y} w:{w} h:{h}");
            Bitmap t = (Bitmap)pbRight.Image;
            Bitmap tmpPic1 = Processvision.cropImage(t, x, y, w, h);
            Image<Bgr, byte> ts = tmpPic1.ToImage<Bgr, byte>();
            Image<Gray, byte> imgoutput = ts.Convert<Gray, byte>().ThresholdBinary(new Gray(100), new Gray(255));
            Image<Bgr, byte> tmpPic2 = tmpPic1.ToImage<Bgr, byte>();
            VectorOfVectorOfPoint contours2 = Processvision.FindContours(imgoutput, 1000, 20000);
            CvInvoke.DrawContours(tmpPic2, contours2, -1, new MCvScalar(255, 0, 0), 1);
            pbPinCropRight.Image = tmpPic2.ToBitmap();
            Console.WriteLine("Size " + contours2.Size.ToString());

            if (contours2.Size != 0)
            {
                Processvision.FindPointsUpperLine(contours2, 1016, y);
                Console.WriteLine("Max Y" + (Processvision.FindPointWithMaxY(Processvision.FindPointsUpperLine(contours2, 1016, y)).Y + y));

            }
            else
            {
                Console.WriteLine("Not found contour");
            }
        }



        private void openCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<IDeviceInfo> li = Enumerator.EnumerateDevices();
            findCameraNum = li.Count;

            for (int i = 0; i < CameraNumMax; i++)
            {
                if (i < findCameraNum)
                {
                    if (cameraList[i].Open(i, pictureboxList[i]))
                    {
                        btnOpen.Enabled = false;
                        btnClose.Enabled = true;

                    }
                }
            }
        }

        private void closeCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < CameraNumMax; i++)
            {
                if (i < findCameraNum)
                {
                    if (cameraList[i].Close())
                    {
                        btnOpen.Enabled = true;
                        btnClose.Enabled = false;
                    }
                }
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings frm = new Settings();
            frm.Show();
            for (int i = 0; i < CameraNumMax; i++)
            {
                if (i < findCameraNum)
                {
                    if (cameraList[i].Close())
                    {
                        btnOpen.Enabled = true;
                        btnClose.Enabled = false;
                    }
                }
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pbLeft.Image != null && pbRight.Image != null)
            {
                btnProcess.Enabled = true;
                string jsonText = File.ReadAllText(AppConstant.MODELS_FOLDER_PATH + "/" + toolStripComboBoxModel.Text + ".json", Encoding.UTF8);
                this.modelConfig = JsonConvert.DeserializeObject<ICModel>(jsonText);

                ControlMoverOrResizer.WorkType = ControlMoverOrResizer.MoveOrResize.MoveAndResize;

                foreach (ICPin pin in this.modelConfig.Image1ICPins)
                {
                    Button button = formController.addModelPinToPictureBox(pbLeft, pin);

                    pinBoxListFromImage1.Add(button);
                }

                foreach (ICPin pin in this.modelConfig.Image2ICPins)
                {
                    Button button = formController.addModelPinToPictureBox(pbRight, pin);

                    pinBoxListFromImage2.Add(button);
                }
                drawLine();
            }
            else {
                MessageBox.Show("Please trigger or upload local image before load PN");
            }
            
           

        }
        void drawLine() {
            pbRight_bmp = (Bitmap)pbRight.Image;
            srcIplImage2 = pbRight_bmp.ToImage<Bgr, byte>();
            thresholdLineRight = crossLineRight.GetMainLine((Bitmap)pbRight.Image, this.modelConfig.YCrossLine2);
            srcIplImage2.Draw(thresholdLineRight, new Bgr(Color.Red), 1);
            Bitmap bmptemp = srcIplImage2.ToBitmap();
            pbRight.Image = bmptemp;
            pbLeft_bmp = (Bitmap)pbLeft.Image;
            srcIplImage1 = pbLeft_bmp.ToImage<Bgr, byte>();
            thresholdLineLeft = crossLineLeft.GetMainLine((Bitmap)pbLeft.Image, this.modelConfig.YCrossLine1);
            srcIplImage1.Draw(thresholdLineLeft, new Bgr(Color.Red), 1);
            Bitmap bmptemp2 = srcIplImage1.ToBitmap();
            pbLeft.Image = bmptemp2;
        }

   

        private void btnStart_Click(object sender, EventArgs e)
        {
            isRunning = !isRunning;
            if (isRunning)
            {
                debugStrip.Text = "Running";
                btnStart.Image = MultiDisplay.Properties.Resources.stop_button;
                timer1.Start();
            }
            else
            {
                debugStrip.Text = "Stopped";
                btnStart.Image = MultiDisplay.Properties.Resources.play_button;
                timer1.Stop();
            }
          
        }

        private void Trigger_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                cameraList[0].trigger();
                Task.Delay(100).Wait(); 
                
            });
            Task.Run(() =>
            {
                cameraList[1].trigger();
       

            });
        

            if (isRunning)
            {
                btnProcess.PerformClick();
            }
         
              
        }

        private void btnLoadLocal_Click(object sender, EventArgs e)
        {

            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.gif, *.bmp)|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Bitmap tempPb;
                        string filePath = openFileDialog.FileName;
                        System.Drawing.Image image = System.Drawing.Image.FromFile(filePath);
                        tempPb = (Bitmap)image;
                        pbLeft.Image = image;
                        var imageBytes = File.ReadAllBytes(filePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not open image file. Original error: " + ex.Message);
                    }
                }
            }
        }

        private void btnLoadLocal2_Click(object sender, EventArgs e)
        {
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.gif, *.bmp)|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Bitmap tempPb;
                        string filePath = openFileDialog.FileName;
                        System.Drawing.Image image = System.Drawing.Image.FromFile(filePath);
                        tempPb = (Bitmap)image;
                        pbRight.Image = image;
                        var imageBytes = File.ReadAllBytes(filePath);


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not open image file. Original error: " + ex.Message);
                    }
                }
            }
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void processToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnProcess.PerformClick();
        }

        private void loadImage1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.gif, *.bmp)|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Bitmap tempPb;
                        string filePath = openFileDialog.FileName;
                        System.Drawing.Image image = System.Drawing.Image.FromFile(filePath);
                        tempPb = (Bitmap)image;
                        pbLeft.Image = image;
                        var imageBytes = File.ReadAllBytes(filePath);


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not open image file. Original error: " + ex.Message);
                    }
                }
            }
        }

        private void loadImage2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.gif, *.bmp)|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Bitmap tempPb;
                        string filePath = openFileDialog.FileName;
                        System.Drawing.Image image = System.Drawing.Image.FromFile(filePath);
                        tempPb = (Bitmap)image;
                        pbRight.Image = image;
                        var imageBytes = File.ReadAllBytes(filePath);


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not open image file. Original error: " + ex.Message);
                    }
                }
            }
        }

        private void btnMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void drawToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnTrigger.PerformClick();
            count++;
            testModeToolStripMenuItem.Text= count.ToString();
            Random rd = new Random();
           int Numrd = rd.Next(1, 20);
           tbLimit.Text = Numrd.ToString();
        }

        private void triggerCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < CameraNumMax; i++)
            {
                cameraList[i].trigger();
            }
        }
    }
}
