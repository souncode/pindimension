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

namespace TraffoVision
{
    public class DHCamera
    {
        List<IGrabbedRawData> m_frameList = new List<IGrabbedRawData>();   // 图像缓存列表 | frame data list 
        private IDevice m_dev;               // 设备对象 | device object 
        Mutex m_mutex = new Mutex();         // 锁，保证多线程安全 | mutex 
        Thread renderThread = null;          // 显示线程 | image display thread 
        bool m_bShowLoop = true;             // 线程控制变量 | thread looping flag 
        private Graphics _g = null;
        PictureBox pbImage = null;
        bool istrigger = false;

  

        public DHCamera()
        {
            if (null == renderThread)
            {
                renderThread = new Thread(new ThreadStart(ShowThread));
                renderThread.Start();
            }
            m_stopWatch.Start();
        }

        public bool Open(int cameraId, PictureBox pictureBox)
        {
            this.pbImage = pictureBox;
            try
            {
                // 获取搜索到的第cameraId+1个设备 
                // get the cameraId+1 searched device 
                m_dev = Enumerator.GetDeviceByIndex(cameraId);

                // 注册链接事件 
                // register event callback 
                m_dev.CameraOpened += OnCameraOpen;
                m_dev.ConnectionLost += OnConnectLoss;
                m_dev.CameraClosed += OnCameraClose;

                // 打开设备 
                // open device 
                if (!m_dev.Open())
                {
                    MessageBox.Show("Open camera(cameraId:" + cameraId + ") failed");
                    return false;
                }

                // 设置缓存个数为8
                // set buffer count to 8 
                m_dev.StreamGrabber.SetBufferCount(8);

                // 注册码流回调事件 
                // register grab event callback 
                m_dev.StreamGrabber.ImageGrabbed += OnImageGrabbed;

                // 开启码流 
                // start grabbing 
                if (!m_dev.GrabUsingGrabLoopThread())
                {
                    MessageBox.Show(@"Start grabbing failed");
                    return false;
                }
            }
            catch (Exception exception)
            {
                Catcher.Show(exception);
            }
            return true;
        }
        public void trigger()
        {
            istrigger = true;
        }

        public bool Close()
        {
            try
            {
                if (m_dev == null || !m_dev.IsOpen)
                {
                    return false;
                }
                m_dev.StreamGrabber.ImageGrabbed -= OnImageGrabbed;         // 反注册回调 | unregister grab event callback 
                m_dev.ShutdownGrab();                                       // 停止码流 | stop grabbing 
                bool closeFlag = m_dev.Close();                             // 关闭相机 | close camera
                return closeFlag;
            }
            catch (Exception exception)
            {
                Catcher.Show(exception);
                return false;
            }
        }

        // 码流数据回调 
        // grab callback function 
        private void OnImageGrabbed(Object sender, GrabbedEventArgs e)
        {
            if (istrigger) {
                m_mutex.WaitOne();
                m_frameList.Add(e.GrabResult.Clone());
                m_mutex.ReleaseMutex();

                istrigger = false;
            }
        }

        // 相机打开回调 
        // camera open event callback 
        private void OnCameraOpen(object sender, EventArgs e)
        {
            Console.WriteLine("Camera connected");
        }

        // 相机关闭回调 
        // camera close event callback 
        private void OnCameraClose(object sender, EventArgs e)
        {
            Console.WriteLine("Camera disconnected");
        }

        // 相机丢失回调 
        // camera disconnect event callback 
        private void OnConnectLoss(object sender, EventArgs e)
        {
            Console.WriteLine("Camera connect loss");
        }


        private void ShowThread()
        {



            while (m_bShowLoop)
            {
                if (m_frameList.Count == 0)
                {
                  
                    continue;
                }
                m_mutex.WaitOne();
                IGrabbedRawData frame = m_frameList.ElementAt(m_frameList.Count-1);
                m_frameList.Clear();
                m_mutex.ReleaseMutex();
 
                GC.Collect();

                if (false == isTimeToDisplay())
                {
                    continue;
                }

                try
                {
                    Bitmap tempBitmap = (Bitmap)frame.ToBitmap(false).Clone();
                    UpdateImage(tempBitmap);

                }
                catch (Exception exception)
                {
                    Catcher.Show(exception);
                }
            }
        }
        private void UpdateImage(Bitmap bitmap)
        {
            if (pbImage.InvokeRequired)
            {
              
                pbImage.Invoke(new Action<Bitmap>(UpdateImage), bitmap);
            }
            else
            {
                pbImage.Image?.Dispose(); 
                pbImage.Image = bitmap;
            }
        }
   

        public void Dispose()
        {
            if (m_dev != null)
            {
                m_dev.Dispose();
                m_dev = null;
            }
            m_bShowLoop = false;
            renderThread.Join();

            if (_g != null)
            {
                _g.Dispose();
                _g = null;
            }
        }

        const int DEFAULT_INTERVAL = 40;
        Stopwatch m_stopWatch = new Stopwatch();

        private bool isTimeToDisplay()
        {
            m_stopWatch.Stop();
            long m_lDisplayInterval = m_stopWatch.ElapsedMilliseconds;
            if (m_lDisplayInterval <= DEFAULT_INTERVAL)
            {
                m_stopWatch.Start();
                return false;
            }
            else
            {
                m_stopWatch.Reset();
                m_stopWatch.Start();
                return true;
            }
        }
    }
}
