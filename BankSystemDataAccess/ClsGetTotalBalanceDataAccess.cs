using ContactsDataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BankSystemDataAccess
{
    public static class ClsGetTotalBalanceDataAccess
    {

        public static decimal GetTotalBalance(out string ErrorMessage)



        {

            decimal TotalBalance = 0;
            ErrorMessage = string.Empty;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))

            {
                string query = "SELECT ISNULL(SUM(Balance), 0) FROM Accounts";


                using (SqlCommand command = new SqlCommand(query, connection))
                {


                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)


                        {

                            TotalBalance = (decimal)result;

                        }

                    }
                    catch (Exception ex)
                    {
                        ErrorMessage = ex.Message;
                        System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
                    }
                }
            }

            return TotalBalance;
        }
    }
}
