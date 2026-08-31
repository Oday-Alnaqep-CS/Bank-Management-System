using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_Managment_System
{
    public static class ClsImageSetting
    {





        public static Image GetCircularImage(Image originalImage)
        {

            int size = Math.Min(originalImage.Width, originalImage.Height);
            Bitmap destinationImage = new Bitmap(size, size);

            using (Graphics g = Graphics.FromImage(destinationImage))
            {

                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                using (System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    path.AddEllipse(0, 0, size, size);
                    g.SetClip(path);
                    g.DrawImage(originalImage, 0, 0, size, size);
                }
            }
            return destinationImage;

        }

        public static Image GetDefaultAvatarByGender(DataRow row)

        {
            bool isMale = true; 

           
            if (row.Table.Columns.Contains("Gender") && row["Gender"] != DBNull.Value)
            {
                string genderValue = row["Gender"].ToString().Trim().ToUpper();

               
                if (genderValue == "F" || genderValue == "FEMALE" || genderValue == "2")
                {
                    isMale = false;
                }
            }

           
            if (isMale)
            {
                return GetCircularImage(Properties.Resources.DefaultMaleAvatar);
            }
            else
            {
                return GetCircularImage(Properties.Resources.DefaultFemaleAvatar);
            }

        }

        public static DataTable GetImage(DataTable Data)

        {

            if (Data != null)

            {

                Data.Columns.Add("Image", typeof(Image));

               // string projectFolder = @"C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image";

                foreach (DataRow row in Data.Rows)
                {
                    string fullPath = row["Profile"] != DBNull.Value ? row["Profile"].ToString().Trim() : "";
                  
                    //string fileName = System.IO.Path.GetFileName(rawPath);
                    //string fullPath = System.IO.Path.Combine(projectFolder, "CustomersImage", fileName);

                    if (!string.IsNullOrEmpty(fullPath) && System.IO.File.Exists(fullPath))
                    {
                        try
                        {
                            using (var ms = new System.IO.MemoryStream(System.IO.File.ReadAllBytes(fullPath)))
                            {
                                using (Image loadedImg = Image.FromStream(ms))
                                {

                                    row["Image"] = ClsImageSetting.GetCircularImage(loadedImg);
                                }
                            }
                        }
                        catch
                        {
                            row["Image"] = ClsImageSetting.GetDefaultAvatarByGender(row);
                        }
                    }
                    else
                    {
                        row["Image"] = ClsImageSetting.GetDefaultAvatarByGender(row);
                    }
                }

               
            }

            return Data;
        }

       


    }
}
