using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraffoVision.Controllers;

namespace TraffoVision.Models
{
    public class ICPin
    {
        public string Name { get; set; }
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int ThresholdMin { get; set; }
        public int ThresholdMax { get; set; }

        public ICPin(string Name, int LocationX, int LocationY, int Width, int Height)
        {
            this.Name = Name;
            this.LocationX = LocationX;
            this.LocationY = LocationY;
            this.Width = Width;
            this.Height = Height;
            this.ThresholdMin = 100;
            this.ThresholdMax = 255;
        }
    }
 
        public class CropArea
        {
            public int LocationX { get; set; }
            public int LocationY { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }

            public CropArea(int LocationX, int LocationY, int Width, int Height)
            {
                this.LocationX = LocationX;
                this.LocationY = LocationY;
                this.Width = Width;
                this.Height = Height;
            }
        }

    public class ICModel
    {
        public String Name { get; set; }
        public int Code { get; set; }
        public List<ICPin> Image1ICPins { get; set; }
        public List<ICPin> Image2ICPins { get; set; }

        public CropArea Image1CropArea { get; set; }
        public CropArea Image2CropArea { get; set; }

        public int YCrossLine1 {  get; set; }
        public int YCrossLine2 { get; set; }
        public int MinContourArea { get; set; }
        public int MaxContourArea { get; set; }
       

        public ICModel()
        {
            this.Image1ICPins = new List<ICPin>();
            this.Image2ICPins = new List<ICPin>();

            this.MinContourArea = 1000;
            this.MaxContourArea = 20000;
        }
    }
}
