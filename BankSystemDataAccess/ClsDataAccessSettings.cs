using System;
using System.Data;
using System.Data.SqlClient;


namespace ContactsDataAccessLayer
{
    public static class ClsDataAccessSettings
    {

        public static string ConnectionString = @"Server=.\MYSQLSERVER1; Database=BankSystemDB; Integrated Security=True; TrustServerCertificate=True;";



        public static bool CheckDatabaseConnection(ref string ErrorMessage)


        {

            try

            {

                using(SqlConnection Connection = new SqlConnection(ConnectionString))

                {
                    Connection.Open();
                    return (Connection.State == ConnectionState.Open);
                }
            }
            catch (Exception e)
            {

                ErrorMessage = e.Message;
            }

            return false;
        }
    }
}
