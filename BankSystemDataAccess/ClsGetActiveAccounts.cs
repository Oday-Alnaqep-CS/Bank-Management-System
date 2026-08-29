using ContactsDataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BankSystemDataAccess
{
    public static class ClsGetCountOfActiveAccountsDataAccess
    {

        public static int GetCountOfActiveAccounts(out string ErrorMessage)



        {

            int  TotalActiveViews =0;

            ErrorMessage = string.Empty;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))

            {
                string query = "SELECT COUNT(*) FROM Accounts WHERE Accounts.Status = 1";

                using (SqlCommand command = new SqlCommand(query, connection))
                {


                    try
                    {
                        connection.Open();
                       object result = command.ExecuteScalar();

                        TotalActiveViews = Convert.ToInt32(result);




                    }
                    catch (Exception ex)
                    {
                        ErrorMessage = ex.Message;
                        System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
                    }
                }
            }

            return TotalActiveViews; 
        }
        public static int GetCountOfActiveCustomer(out string ErrorMessage)



        {

            int  TotalActiveViews =0;

            ErrorMessage = string.Empty;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))

            {
                string query = "SELECT COUNT(*) FROM CLients WHERE CLients.Status = 1";

                using (SqlCommand command = new SqlCommand(query, connection))
                {


                    try
                    {
                        connection.Open();
                       object result = command.ExecuteScalar();

                        TotalActiveViews = Convert.ToInt32(result);




                    }
                    catch (Exception ex)
                    {
                        ErrorMessage = ex.Message;
                        System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
                    }
                }
            }

            return TotalActiveViews; 
        }
    }
}
