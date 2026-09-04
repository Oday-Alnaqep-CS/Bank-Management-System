using ContactsDataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BankSystemDataAccess.FinancialData
{
    public static partial class ClsNotificationData
    {
       

        public static bool GetNotificationByID(int notificationID, ref string UserID, ref string title,
                                                ref string message, ref bool isRead,
                                                ref DateTime createdDate, ref string errorMessage)
        {

            bool isFound = false;
          

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {


                string query = @"SELECT * FROM Notifications WHERE NotificationID = @NotificationID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@NotificationID", notificationID);

                    try
                    {

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                UserID = (string)reader["UserID"];
                                title = (string)reader["Title"];
                                message = (string)reader["Message"];
                                isRead = (bool)reader["IsRead"];
                                createdDate = (DateTime)reader["CreatedDate"];
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        isFound = false;
                        errorMessage = ex.Message;
                    }
                }

            }

            return isFound;

        }

        
        public static int GetUnreadNotificationsCount(string UserID, ref string errorMessage)
        {

            int count = 0;



            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {


                string query = "SELECT COUNT(*) FROM Notifications WHERE UserID = @UserID AND IsRead = 0;";


                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@UserID", UserID);

                    try
                    {

                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int parsedCount))
                        {
                            count = parsedCount;
                        }
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                    }
                }

            }

            return count;

        }
    }

}