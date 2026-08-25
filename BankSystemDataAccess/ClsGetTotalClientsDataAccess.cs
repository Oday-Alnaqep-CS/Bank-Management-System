using ContactsDataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BankSystemDataAccess
{
    public static class ClsGetTotalClientsDataAccess
    {

        public static int GetTotalClients(out string ErrorMessage)



        {

            int TotalClients = 0;
            ErrorMessage = string.Empty;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))

            {
                string query = "SELECT COUNT(*) FROM Clients";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                   

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)


                        {

                            TotalClients = Convert.ToInt32(result);

                        }

                    }
                    catch (Exception ex)
                    {
                        ErrorMessage = ex.Message;
                        System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
                    }
                }
            }

            return TotalClients;
        }
    }
}
