using ContactsDataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BankSystemDataAccess.EntitiesData
{
    public static partial class ClsClientDataAccess
    {

        public static bool GetClientByID(int clientID, ref int personID, ref byte clientType,
                                         ref DateTime createdDate, ref byte status, ref string errorMessage)
        {

            bool isFound = false;

            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Clients WHERE ClientID = @ClientID;";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ClientID", clientID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();


                if (reader.Read())
                {


                    isFound = true;
                    personID = Convert.ToInt32(reader["PersonID"]);
                    clientType = Convert.ToByte(reader["ClientType"]);
                    createdDate = Convert.ToDateTime(reader["CreatedDate"]);
                    status = Convert.ToByte(reader["Status"]);
                    

                }
                else
                {
                    isFound = false;

                }
                reader.Close();

            }
            catch (Exception ex)
            {

                errorMessage = ex.Message;
                isFound = false;

            }
            finally
            {

                connection.Close();

            }




            return isFound;
        }

        public static bool GetClientByPersonID(int personID, ref int clientID, ref byte clientType,
                                               ref DateTime createdDate, ref byte status, ref string errorMessage)
        {

            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Clients WHERE PersonID = @PersonID;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", personID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                clientID = Convert.ToInt32(reader["ClientID"]);
                                clientType = Convert.ToByte(reader["ClientType"]);
                                createdDate = Convert.ToDateTime(reader["CreatedDate"]);
                                status = Convert.ToByte(reader["Status"]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                        isFound = false;
                    }
                }
            }



            return isFound;


        }

        public static int AddNewClient(int personID, byte clientType, DateTime createdDate, byte status, ref string errorMessage)


        {


            int newID = -1;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO Clients (PersonID, ClientType, CreatedDate, Status)
                                 VALUES (@PersonID, @ClientType, @CreatedDate, @Status);
                                 SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", personID);
                    command.Parameters.AddWithValue("@ClientType", clientType);
                    command.Parameters.AddWithValue("@CreatedDate", createdDate);
                    command.Parameters.AddWithValue("@Status", status);

                    try
                    {

                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            newID = insertedID;
                        }
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                    }
                }
            }


            return newID;


        }


        public static bool UpdateClient(int clientID, int personID, byte clientType, byte status, DateTime CreatedDate,ref string errorMessage)


        {
            int rowsAffected = 0;


            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE Clients 
                                 SET PersonID = @PersonID,
                                     ClientType = @ClientType,
                                     Status = @Status
                                 WHERE ClientID = @ClientID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClientID", clientID);
                    command.Parameters.AddWithValue("@PersonID", personID);
                    command.Parameters.AddWithValue("@ClientType", clientType);
                    command.Parameters.AddWithValue("@Status", status);
                    command.Parameters.AddWithValue("@CreatedDate", CreatedDate);


                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                        errorMessage = ex.Message;

                    }
                }
            }


            return rowsAffected > 0;


        }


        public static bool DeleteClient(int clientID, ref string errorMessage)


        {

            int rowsAffected = 0;


            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM Clients WHERE ClientID = @ClientID;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClientID", clientID);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                    }
                }
            }


            return rowsAffected > 0;

        }

        public static DataTable GetAllClients(ref string errorMessage,string query)


        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
              
              

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
                        errorMessage = ex.Message;
                    }
                }
            }

            return dt;
        }


        public static bool IsClientExist(int clientID, ref string errorMessage)


        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT Found = 1 FROM Clients WHERE ClientID = @ClientID;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClientID", clientID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        isFound = (result != null);

                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                    }
                }
            }

            return isFound;

        }

        public static bool IsClientExistByPersonID(int personID, ref string errorMessage)
        {

            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT Found = 1 FROM Clients WHERE PersonID = @PersonID;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", personID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        isFound = (result != null);
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                    }
                }
            }


            return isFound;
        }
    }
}