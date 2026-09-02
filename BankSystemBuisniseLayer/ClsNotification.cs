using System;
using System.Data;
using BankSystemDataAccess.FinancialData;

namespace BankSystemBuisniseLayer
{
    public class ClsNotification
    {
        public enum enMode { AddNew = 1, Update = 2 }
        public enMode Mode = enMode.AddNew;

        public int NotificationID { get; set; }
        public int ClientID { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ErrorMessage { get; set; }

        public ClsNotification()
        {
            this.NotificationID = -1;
            this.ClientID = -1;
            this.Title = "";
            this.Message = "";
            this.IsRead = false;
            this.CreatedDate = DateTime.Now;

            Mode = enMode.AddNew;
        }

        public ClsNotification(int notificationID, int clientID, string title, string message, bool isRead, DateTime createdDate)
        {
            this.NotificationID = notificationID;
            this.ClientID = clientID;
            this.Title = title;
            this.Message = message;
            this.IsRead = isRead;
            this.CreatedDate = createdDate;

            Mode = enMode.Update;
        }

        private bool _AddNewNotification()
        {
            string errorMessage = "";

            this.NotificationID = ClsNotificationData.AddNewNotification(this.ClientID, this.Title, this.Message, ref errorMessage);

            this.ErrorMessage = errorMessage;

            return (this.NotificationID != -1 && this.NotificationID != 0);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewNotification())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    
                    return false;
            }

            return false;
        }

        public static ClsNotification Find(int notificationID, ref string errorMessage)
        {
            int clientID = -1;
            string title = "", message = "";
            bool isRead = false;
            DateTime createdDate = DateTime.Now;

            if (ClsNotificationData.GetNotificationByID(notificationID, ref clientID, ref title, ref message, ref isRead, ref createdDate, ref errorMessage))
            {
                return new ClsNotification(notificationID, clientID, title, message, isRead, createdDate);
            }

            return null;
        }

        public static bool DeleteNotification(int notificationID, ref string errorMessage)
        {
            return ClsNotificationData.DeleteNotification(notificationID, ref errorMessage);
        }

        public static bool MarkAsRead(int notificationID, ref string errorMessage)
        {
            return ClsNotificationData.MarkAsRead(notificationID, ref errorMessage);
        }

        public static DataTable GetNotificationsByClientID(string clientID, ref string errorMessage)
        {
            return ClsNotificationData.GetNotificationsByClientID(clientID, ref errorMessage);
        }

        public static int GetNotificationCount(int ClirntID , ref string ErrorMessage)

        {

            return ClsNotificationData.GetUnreadNotificationsCount(ClirntID, ref ErrorMessage);
        }
    }
}