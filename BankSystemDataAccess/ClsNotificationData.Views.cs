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

                string query = "SELECT * FROM vw_Notifications ORDER BY NotificationID DESC;";


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


        public static DataTable GetNotificationsByClientID(int clientID, ref string errorMessage)


        {

            DataTable dt = new DataTable();



            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {


                string query = @"SELECT NotificationID, Title, Message, IsRead, CreatedDate 
                             FROM Notifications 
                             WHERE ClientID = @ClientID 
                             ORDER BY CreatedDate DESC;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClientID", clientID);

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