using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Tulpep.NotificationWindow;

namespace Bank_Managment_System
{
    public class ClsBankingNotification

    {

        public enum NotificationType { Info, Success, Error }

        public static void ShowBankingNotification(string title, string message, NotificationType type = NotificationType.Info)


        {
            PopupNotifier popup = new PopupNotifier();

            
            popup.TitleText = title;
            popup.ContentText = message;

          
            popup.BodyColor = Color.FromArgb(15, 23, 42);       
            popup.ContentColor = Color.FromArgb(226, 232, 240); 

    
            switch (type)
            {
                case NotificationType.Success:
                    popup.TitleColor = Color.FromArgb(16, 185, 129);  

                    popup.BorderColor = Color.FromArgb(16, 185, 129);
                    break;

                case NotificationType.Error:
                    popup.TitleColor = Color.FromArgb(239, 68, 68);    

                    popup.BorderColor = Color.FromArgb(239, 68, 68);
                    break;

                case NotificationType.Info:
                default:
                    popup.TitleColor = Color.FromArgb(212, 175, 55);  

                    popup.BorderColor = Color.FromArgb(30, 41, 59);   

                    break;
            }

         

            popup.TitleFont = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            popup.ContentFont = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            popup.Size = new Size(350, 90);

           

            popup.Delay = 3000;           

            popup.AnimationInterval = 15; 

            popup.AnimationDuration = 500;


      

            popup.Popup();
        }



    }
}
