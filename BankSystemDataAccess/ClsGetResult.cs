using ContactsDataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BankSystemDataAccess
{
    public static class ClsGetResult


    {
      
        public static T ExecuteScalar<T>(string query, SqlParameter[] parameters, out string ErrorMessage, T defaultValue = default)


        {


            ErrorMessage = string.Empty;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))

            {


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                   


                    if (parameters != null && parameters.Length > 0)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)


                        {
                           

                            Type conversionType = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);
                            return (T)Convert.ChangeType(result, conversionType);
                        }

                    }
                    catch (Exception ex)
                    {
                        ErrorMessage = ex.Message;
                        System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
                    }
                }
            }

            return defaultValue;
        }

      

        public static T ExecuteScalar<T>(string query, out string ErrorMessage, T defaultValue = default)
        {
            return ExecuteScalar<T>(query, null, out ErrorMessage, defaultValue);
        }
    }
}