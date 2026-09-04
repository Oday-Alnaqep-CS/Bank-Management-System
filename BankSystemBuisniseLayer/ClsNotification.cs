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
        public string UserID { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ErrorMessage { get; set; }

        public ClsNotification()
        {
            this.NotificationID = -1;
            this.UserID = null;
            this.Title = "";
            this.Message = "";
            this.IsRead = false;
            this.CreatedDate = DateTime.Now;

            Mode = enMode.AddNew;
        }

        public ClsNotification(int notificationID, string userID, string title, string message, bool isRead, DateTime createdDate)
        {
            this.NotificationID = notificationID;
            this.UserID = userID;
            this.Title = title;
            this.Message = message;
            this.IsRead = isRead;
            this.CreatedDate = createdDate;

            Mode = enMode.Update;
        }

        private bool _AddNewNotification()
        {
            string errorMessage = "";

            this.NotificationID = ClsNotificationData.AddNewNotification(this.UserID, this.Title, this.Message, ref errorMessage);

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
            string userID = null;
            string title = "", message = "";
            bool isRead = false;
            DateTime createdDate = DateTime.Now;

            if (ClsNotificationData.GetNotificationByID(notificationID, ref userID   , ref title, ref message, ref isRead, ref createdDate, ref errorMessage))
            {
                return new ClsNotification(notificationID, userID, title, message, isRead, createdDate);
            }

            return null;
        }

        public static bool DeleteNotification(int notificationID, ref string errorMessage)
        {
            return ClsNotificationData.DeleteNotification(notificationID, ref errorMessage);
        }

        public static bool MarkAsRead(string UserID, ref string errorMessage)
        {
            return ClsNotificationData.MarkAsRead(UserID, ref errorMessage);
        }

        public static DataTable GetNotificationsByUserID(string UserID, ref string errorMessage)
        {
            return ClsNotificationData.GetNotificationsByUserID(UserID, ref errorMessage);
        }

        public static int GetNotificationCount(string UserID , ref string ErrorMessage)

        {

            return ClsNotificationData.GetUnreadNotificationsCount(UserID, ref ErrorMessage);
        }
    }
}