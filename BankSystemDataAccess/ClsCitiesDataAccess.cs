using ContactsDataAccessLayer;
using System.Data.SqlClient;
using System;
using System.Data;

namespace BankSystemDataAccess
{
    public static class ClsCitiesDataAccess
    {

        public static DataTable GetCitiesByCountryID(int CountryID, ref string ErrorMessage)
        {

            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = @"SELECT CityID, CityName FROM Cities WHERE CountryID = @CountryID ORDER BY CityName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@CountryID", CountryID);
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
