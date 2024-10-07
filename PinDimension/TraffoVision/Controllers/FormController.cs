using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using ControlManager;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TraffoVision.Models;
using System.IO;
using TraffoVision.Constant;

namespace TraffoVision.Controllers
{
    public class FormController
    {
       
        public Button addNewPinToPictureBox(PictureBox pictureBox, string pinName, bool enableResize = true)
        {
            ControlMoverOrResizer.WorkType = ControlMoverOrResizer.MoveOrResize.MoveAndResize;
            Button pinBtn = new Button();
            pinBtn.Name = pinName;
            pinBtn.Size = new Size(15, 30);
            pinBtn.Location = new Point(10, pictureBox.Height / 2 - 20);
            pinBtn.FlatStyle = FlatStyle.Flat;
            pinBtn.BackColor = Color.Transparent;
            pinBtn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            pinBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            pinBtn.FlatAppearance.BorderSize = 1;
            pinBtn.FlatAppearance.BorderColor = Color.Yellow;
            if (enableResize) ControlMoverOrResizer.Init(pinBtn);
            pictureBox.Controls.Add(pinBtn);
            return pinBtn;
        }


        public Button addModelPinToPictureBox(PictureBox pictureBox, ICPin pin, bool enableResize = true)
        {
            Button pinBtn = new Button();
            pinBtn.Name = pin.Name;
            pinBtn.Location = new Point(pin.LocationX, pin.LocationY);
            pinBtn.Size = new Size(pin.Width, pin.Height);
            pinBtn.FlatStyle = FlatStyle.Flat;
            pinBtn.BackColor = Color.Transparent;
            pinBtn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            pinBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            pinBtn.FlatAppearance.BorderSize = 1;
            pinBtn.FlatAppearance.BorderColor = Color.LimeGreen;
            if (enableResize) ControlMoverOrResizer.Init(pinBtn);
            pictureBox.Controls.Add(pinBtn);
            return pinBtn;
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


    }
}
