using ContactsDataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BankSystemDataAccess
{
    public static class ClsTotalNewCustomersDataAccess
    {

        public static int GetTotalNewCustomersCount(ref string ErrorMessage)

        {

            int TotalCount = 0;
            string ErorMessage = string.Empty;

            using(SqlConnection Connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))

            {

                string Query = @"SELECT COUNT(*) FROM Clients 
                  WHERE CreationDate >= DATEADD(month, DATEDIFF(month, 0, GETDATE()) - 1, 0)
                    AND CreationDate <  DATEADD(month, DATEDIFF(month, 0, GETDATE()), 0);";


                // string Query = @"Select Count(*) from Clients WHERE DATEDIFF(month, CreationDate, GETDATE()) = 1;";

                using (SqlCommand Command = new SqlCommand(Query, Connection))

                {

                    try
                    {

                        Connection.Open();
                        object result = Command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)

                        {
                            TotalCount = (int)result;
                        }
                            

                    }
                    catch(Exception ex)
                    {

                        ErrorMessage = ex.Message;
                        System.Diagnostics.Debug.WriteLine("Erro : " + ErrorMessage);
                    }
                }
            }
            return TotalCount;
             
        }

    }
}
