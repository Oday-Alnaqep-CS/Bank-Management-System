using ContactsDataAccessLayer;
using System.Data.SqlClient;
using System;
using System.Data;

namespace BankSystemDataAccess
{
    public static class ClsCountryDataAccess
    {

        public static DataTable GetCountries(ref string ErrorMessage)
        {

            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = @"SELECT CountryID, CountryName FROM Countries ";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                        ErrorMessage = ex.Message;

                    }
                }
            }

            return dt;

        }
    }
}
