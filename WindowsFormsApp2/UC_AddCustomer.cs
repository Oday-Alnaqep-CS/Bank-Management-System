using AForge.Video;
using AForge.Video.DirectShow;
using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_Managment_System
{
    public partial class UC_AddCustomer : UserControl
    {


        private string _SelectedImagePath = string.Empty;

        public UC_AddCustomer()
        {
            InitializeComponent();
        }

        private void UC_AddCustomer_Load(object sender, EventArgs e)
        {

            //guna2CheckBox4.UncheckedState.BorderRadius = 10;
            ApplyRadioButtonStyle(Check_ActiveAccount);
            ApplyRadioButtonStyle(Check_InActiveAccount);
           
       
            Design();
        }
     
        private void guna2Panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Design()

        {


            PictCustomerPhoto.Image = Properties.Resources.DefaultMaleAvatar;
            btnUploadPhoto.Image = IconChar.FolderOpen.ToBitmap(Color.Gold, 20);//IconChar.Upload.ToBitmap(Color.White, 20);
            btnRemovePhoto.Image = IconChar.Trash.ToBitmap(Color.Red, 15);

            txtFirstName.IconLeft = IconChar.UserAlt.ToBitmap(Color.Gray);
            txtSecondName.IconLeft = IconChar.UserAlt.ToBitmap(Color.Gray);
            txtLastName.IconLeft = IconChar.UserAlt.ToBitmap(Color.Gray);


        }

        private void ApplyRadioButtonStyle(Guna.UI2.WinForms.Guna2CustomRadioButton radioButton)
        {

            radioButton.CheckedState.InnerColor = Color.Transparent;
            radioButton.UncheckedState.InnerColor = Color.Transparent;

           
            radioButton.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
            radioButton.CheckedState.FillColor = Color.Transparent;
            radioButton.CheckedState.BorderThickness = 3;

            
            radioButton.UncheckedState.BorderColor = Color.FromArgb(70, 85, 110);
            radioButton.UncheckedState.FillColor = Color.Transparent;
            radioButton.UncheckedState.BorderThickness = 2;

        
            radioButton.BackgroundImageLayout = ImageLayout.Zoom;
        }

    


        private void CheckActiveAccount_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_ActiveAccount.Checked)
            {
                
                Check_ActiveAccount.BackgroundImage = IconChar.Check.ToBitmap(Color.FromArgb(94, 148, 255), 30);
            }
            else
            {
                
                Check_ActiveAccount.BackgroundImage = null;
            }
        }

        private void CheckInActiveAccount_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_InActiveAccount.Checked)
            {

                Check_InActiveAccount.BackgroundImage = IconChar.Check.ToBitmap(Color.FromArgb(94, 148, 255), 30);
            }
            else
            {

                Check_InActiveAccount.BackgroundImage = null;
            }
        }

        private void btnUploadPhoto_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {


                openFileDialog.InitialDirectory = @"C:\My Projects - Apps\Bank_Managment_System\WindowsFormsApp2\Image\CustomersImage";

                // أو استخدام مجلد الصور الخاص بالمستخدم الحالي:
                // openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                openFileDialog.RestoreDirectory = true; //


                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Select Customer Photo";


                if (openFileDialog.ShowDialog() == DialogResult.OK)

                {




                    _SelectedImagePath = openFileDialog.FileName;

                    if (PictCustomerPhoto.Image != null)
                    {
                        PictCustomerPhoto.Image.Dispose();
                    }

                    using (var tempImage = Image.FromFile(_SelectedImagePath))
                    {
                        PictCustomerPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
                        PictCustomerPhoto.Image = new Bitmap(tempImage);
                    }
                }
            }


        }

        private void btnRemovePhoto_Click(object sender, EventArgs e)
        {

            PictCustomerPhoto.Image.Dispose();
            PictCustomerPhoto.Image = null;
            PictCustomerPhoto.Image = Properties.Resources.DefaultMaleAvatar;

        }

        private void PictC_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
