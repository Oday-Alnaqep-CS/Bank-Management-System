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

        public static int GetCountryIDByCityID(int CityID, ref string ErrorMessage)
        {
            int CountryID = -1; 

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                
                string query = @"SELECT CountryID FROM Cities WHERE CityID = @CityID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CityID", CityID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar(); 

                        if (result != null && int.TryParse(result.ToString(), out int parsedCountryID))
                        {
                            CountryID = parsedCountryID;
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                }
            }

            return CountryID;
        }
    }
}
