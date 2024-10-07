using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace TraffoVision.Controllers
{
    public class CrossLine
    {
        public LineSegment2D GetMainLine(Bitmap bitmap,int value) {
            try
            {
                 Console.WriteLine("Return main line");
                return new LineSegment2D(new Point(bitmap.Width,value),new Point(0,value));
               
            }
            catch (Exception e)
            {
                throw e;
            }
          
        }
    }
}
