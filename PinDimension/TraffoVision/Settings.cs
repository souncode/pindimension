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
using TraffoVision.Constant;
using Emgu.CV.Structure;
using Emgu.CV;
using TraffoVision.Models;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;
using Newtonsoft.Json;
using System.IO;
using ControlManager;
using System.Net.NetworkInformation;


namespace TraffoVision
{
    public partial class Settings : Form
    {
        private List<Button> pinBoxListFromImage1 = new List<Button>();
        private List<Button> pinBoxListFromImage2 = new List<Button>();
        private Image<Bgr, byte> srcIplImage1;
        private Image<Bgr, byte> srcIplImage2;
        List<PictureBox> pictureboxList = new List<PictureBox>();  //PictureBox列表
        DHCamera[] cameraList;          // 相机数组
        const int CameraNumMax = 2;     // 最大支持相机个数
        int findCameraNum = 0;          // 发现的相机个数
        CrossLine crossLineLeft = new CrossLine();
        CrossLine crossLineRight = new CrossLine();
        LineSegment2D thresholdLineLeft = new LineSegment2D();
        LineSegment2D thresholdLineRight = new LineSegment2D();
        Bitmap pbLeft_bmp, pbRight_bmp;
        ProcessVision Processvision = new ProcessVision();
        FormController formController = new FormController();
        int trbLine1;
        int trbLine2;
        Button btn;
        Image<Bgr, byte> img;
        private List<Button> pinBoxList1 = new List<Button>();
        bool testMode = true;
        private ICModel modelConfig = new ICModel();
      
        Image originalImage1;
        Image originalImage2;


        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Shown(object sender, EventArgs e)
        {
            //    btnClose.Enabled = false;
           
                pictureboxList.Add(pbLeft);
                pictureboxList.Add(pbRight);
                cameraList = new DHCamera[CameraNumMax];
                for (int i = 0; i < CameraNumMax; i++)
                {
                    cameraList[i] = new DHCamera();
                }
                List<IDeviceInfo> li = Enumerator.EnumerateDevices();
                findCameraNum = li.Count;

                for (int i = 0; i < CameraNumMax; i++)
                {
                    if (i < findCameraNum)
                    {
                        if (cameraList[i].Open(i, pictureboxList[i]))
                        {
                            // btnOpen.Enabled = false;
                            //  btnClose.Enabled = true;

                        }
                    }
                }
            
           
        }

        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(!testMode) {

                for (int i = 0; i < CameraNumMax; i++)
                {
                    if (i < findCameraNum)
                    {
                        if (cameraList[i].Close())
                        {
                            //btnOpen.Enabled = true;
                            // btnClose.Enabled = false;
                        }
                    }
                }
                for (int i = 0; i < CameraNumMax; i++)
                {
                    cameraList[i].Dispose();
                }

                base.OnClosed(e);
            }
         
        }


        private void btnTrigger_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < CameraNumMax; i++)
            {
                cameraList[i].trigger();
            }
        }

        private void btnAddLeft_Click(object sender, EventArgs e)
        {
            string pinName = "PIN1_" + (pinBoxListFromImage1.Count + 1).ToString();
            btn = formController.addNewPinToPictureBox(pbLeft, pinName);
            this.modelConfig.Image1ICPins.Add(new ICPin(btn.Name, btn.Location.X, btn.Location.Y, btn.Size.Width, btn.Size.Height));
            pinBoxListFromImage1.Add(btn);
        }

        private void btnAddRight_Click(object sender, EventArgs e)
        {
            string pinName = "PIN2_" + (pinBoxListFromImage2.Count + 1).ToString();
            btn = formController.addNewPinToPictureBox(pbRight, pinName);
            this.modelConfig.Image2ICPins.Add(new ICPin(btn.Name, btn.Location.X, btn.Location.Y, btn.Size.Width, btn.Size.Height));
            pinBoxListFromImage2.Add(btn);
        }

        private void btnDrawLeft_Click(object sender, EventArgs e)
        {
            if (originalImage1 == null)
            {
                originalImage1 = (Bitmap)pbLeft.Image.Clone();
            }

            pbLeft.Image = originalImage1;
            pbLeft_bmp = (Bitmap)pbLeft.Image;
            img = pbLeft_bmp.ToImage<Bgr, byte>();
            srcIplImage1 = img;
         //  LineSegment2D X = new LineSegment2D(new Point(1300, pbLeft_bmp.Height), new Point(1300, 0));
            LineSegment2D thresholdLine = new LineSegment2D();

            thresholdLine = crossLineLeft.GetMainLine((Bitmap)pbLeft.Image, trbLine1);
   
            srcIplImage1.Draw(thresholdLine, new Bgr(Color.Red), 1);
         //   srcIplImage1.Draw(X, new Bgr(Color.Red), 1);
            // srcIplImage1.Draw(X, new Bgr(Color.Red), 1);
            Bitmap bmptemp = srcIplImage1.ToBitmap();
            pbLeft.Image = bmptemp;

        }

      

        private void btnDrawRight_Click(object sender, EventArgs e)
        {
            pbRight_bmp = (Bitmap)pbRight.Image;
            srcIplImage2 = pbRight_bmp.ToImage<Bgr, byte>();
         //   LineSegment2D X = new LineSegment2D(new Point(trbLine2, pbRight_bmp.Height), new Point(trbLine2, 0));
    
            thresholdLineRight = crossLineRight.GetMainLine((Bitmap)pbRight.Image, trbLine2);
            srcIplImage2.Draw(thresholdLineRight, new Bgr(Color.Red), 1);
            Bitmap bmptemp = srcIplImage2.ToBitmap();
            pbRight.Image = bmptemp;
        }
        private void tbLine1_Scroll(object sender, EventArgs e)
        {
            trbLine1 = tbLine1.Value;
            lbMainLineLeft.Text = trbLine1.ToString();
            if (originalImage1 == null)
            {
                originalImage1 = (Bitmap)pbLeft.Image.Clone();
            }

            pbLeft.Image = originalImage1;
            pbLeft_bmp = (Bitmap)pbLeft.Image;
            img = pbLeft_bmp.ToImage<Bgr, byte>();
            srcIplImage1 = img;
            //  LineSegment2D X = new LineSegment2D(new Point(1300, pbLeft_bmp.Height), new Point(1300, 0));
            LineSegment2D thresholdLine = new LineSegment2D();

            thresholdLine = crossLineLeft.GetMainLine((Bitmap)pbLeft.Image, trbLine1);

            srcIplImage1.Draw(thresholdLine, new Bgr(Color.Red), 1);
            //   srcIplImage1.Draw(X, new Bgr(Color.Red), 1);
            // srcIplImage1.Draw(X, new Bgr(Color.Red), 1);
            Bitmap bmptemp = srcIplImage1.ToBitmap();
            pbLeft.Image = bmptemp;
        }

        private void btnProcessLeft_Click(object sender, EventArgs e)
        {
            double realRatio = ((Bitmap)pbLeft.Image).Width / (pbLeft.Width);
            double realRatio2 = ((Bitmap)pbLeft.Image).Height / (pbLeft.Height);
            Console.WriteLine($"Bitmap Width {((Bitmap)pbLeft.Image).Width} Height {((Bitmap)pbLeft.Image).Height}");
            Console.WriteLine("RR : " + realRatio);
            Console.WriteLine("RR2 : " + realRatio);
            int x = Convert.ToInt32(btn.Location.X * realRatio);
            int y = Convert.ToInt32(btn.Location.Y * realRatio2);
            int w = Convert.ToInt32(btn.Width * realRatio);
            int h = Convert.ToInt32(btn.Height * realRatio2);
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
             
      
                Processvision.FindPointsUpperLine(contours2, 1016,y);
                Console.WriteLine("Max Y"+ (Processvision.FindPointWithMaxY(Processvision.FindPointsUpperLine(contours2, 1016, y)).Y+y));
             
            }
            else { Console.WriteLine("Not found contour"); }
            //Console.WriteLine($"Client Width :{pbRight.Width.ToString()} Client Height :{pbRight.ClientSize.Height.ToString()}");

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.modelConfig.YCrossLine1 = trbLine1;
                this.modelConfig.YCrossLine2 = trbLine2;
                this.modelConfig.Name = tbNamePN.Text.ToString();
                this.modelConfig.Code = 1;
                Console.WriteLine("count"+pinBoxListFromImage1.Count);
                Console.WriteLine("count" + pinBoxListFromImage2.Count);

                foreach (Button button in pinBoxListFromImage1)
                {
               
                    this.modelConfig.Image1ICPins.Where(p => p.Name == button.Name).First().LocationX = button.Location.X;
                    this.modelConfig.Image1ICPins.Where(p => p.Name == button.Name).First().LocationY = button.Location.Y;
                    this.modelConfig.Image1ICPins.Where(p => p.Name == button.Name).First().Width = button.Size.Width;
                    this.modelConfig.Image1ICPins.Where(p => p.Name == button.Name).First().Height = button.Size.Height;
                  
                }
                foreach (Button button in pinBoxListFromImage2)
                {

                    this.modelConfig.Image2ICPins.Where(p => p.Name == button.Name).First().LocationX = button.Location.X;
                    this.modelConfig.Image2ICPins.Where(p => p.Name == button.Name).First().LocationY = button.Location.Y;
                    this.modelConfig.Image2ICPins.Where(p => p.Name == button.Name).First().Width = button.Size.Width;
                    this.modelConfig.Image2ICPins.Where(p => p.Name == button.Name).First().Height = button.Size.Height;

                }
                var json = JsonConvert.SerializeObject(this.modelConfig, Newtonsoft.Json.Formatting.Indented);

                File.WriteAllText(AppConstant.MODELS_FOLDER_PATH + "/" + this.modelConfig.Name + ".json", json.ToString());

                MessageBox.Show("saved");
            }
            catch (Exception)
            {

                MessageBox.Show("Unable to save");
            }
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string jsonText = File.ReadAllText(AppConstant.MODELS_FOLDER_PATH + "/" + cbModel.Text + ".json", Encoding.UTF8);
            this.modelConfig = JsonConvert.DeserializeObject<ICModel>(jsonText);

            ControlMoverOrResizer.WorkType = ControlMoverOrResizer.MoveOrResize.MoveAndResize;

            foreach (ICPin pin in this.modelConfig.Image1ICPins)
            {
                Button button = formController.addModelPinToPictureBox(pbLeft, pin);
               button.MouseUp += Button_MouseUpLeft;
                pinBoxListFromImage1.Add(button);
            }
            
            foreach (ICPin pin in this.modelConfig.Image2ICPins)
            {
                Button button = formController.addModelPinToPictureBox(pbRight, pin);
              //  button.MouseUp += Button_MouseUp2;
                pinBoxListFromImage2.Add(button);
            }
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
            pbRight.Image = bmptemp;

        }
     
        public List<string> getListModels()
        {
            List<string> results = new List<string>();
            if (!Directory.Exists(AppConstant.MODELS_FOLDER_PATH)) Directory.CreateDirectory(AppConstant.MODELS_FOLDER_PATH);
            DirectoryInfo directoryInfo = new DirectoryInfo(AppConstant.MODELS_FOLDER_PATH);
            FileInfo[] files = directoryInfo.GetFiles("*.json");
            foreach (FileInfo file in files)
            {
                results.Add(Path.GetFileNameWithoutExtension(file.Name));
            }
            return results;
        }
        private void loadModels()
        {
            cbModel.Items.Clear();
            cbModel.Items.AddRange(new FormController().getListModels().ToArray());
            if (cbModel.Items.Count > 0)
            {
                if (cbModel.Text == "") cbModel.SelectedIndex = 0;
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {

            if (!Directory.Exists(AppConstant.MODELS_FOLDER_PATH))
            {
                Directory.CreateDirectory(AppConstant.MODELS_FOLDER_PATH);
            }
            else
            {
                loadModels();
            }
            listView1.View = View.Details;
            listView1.Columns.Add("PIN");
            listView1.Columns.Add("Status");
            listView1.Columns.Add("Distance");
            listView2.View = View.Details;
            listView2.Columns.Add("PIN");
            listView2.Columns.Add("Status");
            listView2.Columns.Add("Distance");
         //   cbModel.SelectedIndex = 4;
        }

        private void tbX_Scroll(object sender, EventArgs e)
        {

        }

        private void btnTestProcess_Click(object sender, EventArgs e)
        {
            
            if (pbLeft == null || pbRight == null)
            {
                MessageBox.Show("Input Image 1, Image 2 First");
                return;
            }
            Console.WriteLine("pin box count :" +pinBoxListFromImage1.Count);
         
            foreach (Button button in pinBoxListFromImage1)
            {
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
                button.MouseUp += Button_MouseUpLeft;
                button.Text = (modelConfig.YCrossLine1 - pinData.MaxY).ToString();
                pinData.IsPass = (modelConfig.YCrossLine2 - pinData.MaxY) < 5;
                string[] arr = new string[3];
                ListViewItem itm;
                arr[0] = button.Name;
                arr[1] = pinData.IsPass ? "OK" : "NG";
                arr[2] = (modelConfig.YCrossLine1 - pinData.MaxY).ToString();
                itm = new ListViewItem(arr);
                itm.ForeColor = pinData.IsPass ? System.Drawing.Color.Blue : System.Drawing.Color.Red;
                listView1.Items.Add(itm);
               
                
            }
            foreach (Button button in pinBoxListFromImage2)
            {
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
                pinData.IsPass = (modelConfig.YCrossLine2 - pinData.MaxY)<5;
                string[] arr = new string[3];
                ListViewItem itm;
                arr[0] = button.Name;
                arr[1] = pinData.IsPass ? "OK" : "NG";
                arr[2] = (modelConfig.YCrossLine2 - pinData.MaxY).ToString();
                itm = new ListViewItem(arr);
                itm.ForeColor = pinData.IsPass ? System.Drawing.Color.Blue : System.Drawing.Color.Red;
                listView2.Items.Add(itm);
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
            //Console.WriteLine($"Client Width :{pbRight.Width.ToString()} Client Height :{pbRight.ClientSize.Height.ToString()}");
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
            else { Console.WriteLine("Not found contour"); 
            }
        }


        private void btnProcessRight_Click(object sender, EventArgs e)
        {
            double realRatio = ((Bitmap)pbRight.Image).Width / (pbRight.Width);
            double realRatio2 = ((Bitmap)pbRight.Image).Height / (pbRight.Height);
            Console.WriteLine($"Bitmap Width {((Bitmap)pbRight.Image).Width} Height {((Bitmap)pbRight.Image).Height}");
            Console.WriteLine("RR : " + realRatio);
            Console.WriteLine("RR2 : " + realRatio);
            int x = Convert.ToInt32(btn.Location.X * realRatio);
            int y = Convert.ToInt32(btn.Location.Y * realRatio2);
            int w = Convert.ToInt32(btn.Width * realRatio);
            int h = Convert.ToInt32(btn.Height * realRatio2);
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
            else { Console.WriteLine("Not found contour"); }
            //Console.WriteLine($"Client Width :{pbRight.Width.ToString()} Client Height :{pbRight.ClientSize.Height.ToString()}");

        }

        private void btnSubLeft_Click(object sender, EventArgs e)
        {
            if (pinBoxListFromImage1.Count > 0)
            {
                pbLeft.Controls.RemoveAt(pinBoxListFromImage1.Count - 1);
                pinBoxListFromImage1.RemoveAt(pinBoxListFromImage1.Count - 1);
                this.modelConfig.Image1ICPins.RemoveAt(this.modelConfig.Image1ICPins.Count - 1);
            }
        }

        private void btnSubRight_Click(object sender, EventArgs e)
        {
            if (pinBoxListFromImage2.Count > 0)
            {
                pbRight.Controls.RemoveAt(pinBoxListFromImage2.Count - 1);
                pinBoxListFromImage2.RemoveAt(pinBoxListFromImage2.Count - 1);
                this.modelConfig.Image2ICPins.RemoveAt(this.modelConfig.Image2ICPins.Count - 1);
            }
        }

        private void cbModel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
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

   

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (int i = 0; i < CameraNumMax; i++)
            {
                if (i < findCameraNum)
                {
                    if (cameraList[i].Close())
                    {
                        Console.WriteLine("Camera Closed");
                    }
                }
            }
        }

        private void tbLine2_Scroll(object sender, EventArgs e)
        {
            trbLine2 = tbLine2.Value;
            lbMainLineRight.Text = trbLine2.ToString();
            if (originalImage2 == null)
            {
                originalImage2 = (Bitmap)pbRight.Image.Clone();
            }

            pbRight.Image = originalImage2;
            pbRight_bmp = (Bitmap)pbRight.Image;
            srcIplImage2 = pbRight_bmp.ToImage<Bgr, byte>();
            thresholdLineRight = crossLineRight.GetMainLine((Bitmap)pbRight.Image, trbLine2);
            srcIplImage2.Draw(thresholdLineRight, new Bgr(Color.Red), 1);
            Bitmap bmptemp = srcIplImage2.ToBitmap();
            pbRight.Image = bmptemp;
        }
       
    }
}
