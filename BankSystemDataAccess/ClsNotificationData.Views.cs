using ContactsDataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BankSystemDataAccess.FinancialData
{
    public static partial class ClsNotificationData
    {



        public static DataTable GetNotificationsView(ref string errorMessage)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = "SELECT * FROM Notifications ORDER BY NotificationID DESC;";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows) dt.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                    }

                }
            }

            return dt;
        }

        public static DataTable GetNotificationsByUserID(string UserID, ref string errorMessage)


        {

            DataTable dt = new DataTable();



            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {


                string query = @"SELECT NotificationID AS [Notification ID] , Title, Message, CASE 
                             WHEN IsRead = 1 THEN 'Read' ELSE 'Unread' END AS [Is Read], SentDate AS [Sent Date]
                             FROM Notifications 
                             WHERE UserID = @UserID 
                             ORDER BY SentDate DESC;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", UserID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows) dt.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                    }

                }
            }

            return dt;
        }

    }
}