using ContactsDataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BankSystemDataAccess.FinancialData
{
    public static partial class ClsNotificationData
    {
        

        public static int AddNewNotification(int clientID, string title, string message, ref string errorMessage)
        {

            int notificationID = -1;



            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {


                string query = @"INSERT INTO Notifications (ClientID, Title, Message, IsRead, CreatedDate)
                             VALUES (@ClientID, @Title, @Message, 0, GETDATE());
                             SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClientID", clientID);
                    command.Parameters.AddWithValue("@Title", title);
                    command.Parameters.AddWithValue("@Message", message);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            notificationID = insertedID;
                        }
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                    }
                }

            }

            return notificationID;
        }

       
        public static bool MarkAsRead(int notificationID, ref string errorMessage)


        {

            int rowsAffected = 0;


            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = "UPDATE Notifications SET IsRead = 1 WHERE NotificationID = @NotificationID;";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NotificationID", notificationID);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                        return false;
                    }

                }

            }

            return rowsAffected > 0;
        }

        

        public static bool DeleteNotification(int notificationID, ref string errorMessage)


        {

            int rowsAffected = 0;


            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = "DELETE FROM Notifications WHERE NotificationID = @NotificationID;";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NotificationID", notificationID);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                        return false;
                    }
                }

            }

            return rowsAffected > 0;
        }

    }
}