using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraffoVision.Models;
using System.Windows.Forms;

namespace TraffoVision.Controllers
{
    public class ProcessVision
    {
        public Bitmap cropImage(Bitmap srcBitmap, int x, int y, int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height);
            using (Graphics gr = Graphics.FromImage(bitmap))
            {
                Rectangle source_rectangle = new Rectangle(x, y, width, height);
                Rectangle dest_rectangle = new Rectangle(0, 0, width, height);
                /* gr.SmoothingMode = SmoothingMode.AntiAlias;
                 gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                 gr.PixelOffsetMode = PixelOffsetMode.HighQuality;*/
                gr.DrawImage(srcBitmap, dest_rectangle, source_rectangle, GraphicsUnit.Pixel);
            }
            return bitmap;
        }
        public VectorOfVectorOfPoint FindContours(Image<Gray, byte> image, double minArea,double maxArea)
        {
            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            VectorOfVectorOfPoint returnContours = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(image, contours, new Mat(), Emgu.CV.CvEnum.RetrType.External, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);
            for(int i = 0; i < contours.Size; i++)
            {
                double area = CvInvoke.ContourArea(contours[i]);
                if (area >= minArea && area <= maxArea)
                {
                    returnContours.Push(contours[i]);
                }
            }
         
            return returnContours;
           
        }
        public PinInf processPinData(Button refPin, Bitmap bitmap, int crossLineY, int x, int y, double threshold, double maxThresold, double minArea, double maxArea)
        {
      
       
            PinInf pinData = new PinInf();
            pinData.DistanceAsPixel = 0;
            pinData.RefPin = refPin;
            pinData.BitmapImage = bitmap;
            pinData.GrayIplImage = bitmap.ToImage<Bgr, byte>().Convert<Gray, byte>().Not().ThresholdBinary(new Gray(threshold), new Gray(maxThresold));

            VectorOfVectorOfPoint contours = this.FindContours(pinData.GrayIplImage, minArea, maxArea);
            if (contours != null)
            {
                pinData.Contour2Draw = contours;

                pinData.MaxY= (this.FindPointWithMaxY(this.FindPointsUpperLine(contours, ((crossLineY)-2), y)).Y + y);
             
            }
          
            return pinData;
        }
   

        public List<Point> FindPointsUpperLine(VectorOfVectorOfPoint contours, int lineY,int offy)
        {
            List<Point> pointsBelowLine = new List<Point>();
            for (int i = 0; i < contours.Size; i++)
            {
   
                Point[] contourPoints = contours[i].ToArray();
                foreach (Point pt in contourPoints)
                {
                    if (pt.Y+offy < lineY  )
                    {
                        pointsBelowLine.Add(pt);
                    }
                   
                }
            }
            Console.WriteLine("List point upper Line :"+ pointsBelowLine.Count);
            return pointsBelowLine;
        }
        public Point FindPointWithMaxY(List<Point> points)
        {
            if (points == null || points.Count == 0)
            {
                throw new ArgumentException("Danh sách điểm không được rỗng.");
            }

            Point maxYPoint = points[0];
            foreach (Point point in points)
            {
                if (point.Y > maxYPoint.Y)
                {
                    maxYPoint = point;
                }
            }
            return maxYPoint;
        }
        public int DistanceFromBottomPinToLine(int MaxY,int LineY) 
        {
            return (LineY-MaxY);
        }

    
      
      
    }
}
