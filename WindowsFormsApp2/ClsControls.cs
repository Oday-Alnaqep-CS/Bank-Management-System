using System;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace Bank_Managment_System
{
    public static class ClsControls
    {
        

        public static void ApplyZoomEffect(IconPictureBox icon, Color color, int zoomAmount = 8)
        {
            if (icon == null) return;

             
            icon.IconColor = color;
            icon.BackColor = Color.Transparent;
            icon.SizeMode = PictureBoxSizeMode.Zoom;
            icon.Cursor = Cursors.Hand;

             
            Size originalSize = icon.Size;
            Point originalLocation = icon.Location;
            int offset = zoomAmount / 2;

             
            icon.MouseEnter += (s, e) =>
            {
                icon.Size = new Size(originalSize.Width + zoomAmount, originalSize.Height + zoomAmount);
                icon.Location = new Point(originalLocation.X - offset, originalLocation.Y - offset);
                icon.IconColor = color;
            };

            icon.MouseLeave += (s, e) =>
            {
                icon.Size = originalSize;
                icon.Location = originalLocation;
                icon.IconColor = color;
            };
        }

        
        public static void ApplyZoomEffect(params (IconPictureBox Icon, Color Color)[] items)
        {
            foreach (var item in items)
            {
                ApplyZoomEffect(item.Icon, item.Color);
            }
        }
    }
}