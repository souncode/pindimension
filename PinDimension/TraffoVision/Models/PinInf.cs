using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace TraffoVision.Models
{

    public class PinInf
    {
        public VectorOfVectorOfPoint Contour2Draw {  get; set; }
        public Button RefPin { get; set; }
        public Bitmap BitmapImage { get; set; }
        public Image<Gray, byte> GrayIplImage { get; set; }

        public VectorOfPoint VOP { get; set; }
        public int MaxY {  get; set; }
        public int DistanceAsPixel { get; set; }

        public bool IsPass { get; set; }
        public List<string> PintInfors { get; set; }
        public bool IsPinValid { get; set; }

        public PinInf()
        {
            this.PintInfors = new List<string>();
        }
    }
}
