using ContactsDataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;



namespace BankSystemDataAccess.EntitiesData
{
    public static partial class ClsPersonDataAccess
    {



        public static bool GetPersonByID(int PersonID, ref string NationalID, ref string FirstName,
                                        ref string LastName, ref byte Gender, ref string Email,
                                        ref string Phone, ref string Address, ref int CityID,ref string ErrorMessage )
        {

            bool isFound = false;
            SqlConnection Connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);


            string Query = "SELECT * FROM Persons WHERE PersonID = @PersonID;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);

                    
            try
            {

                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();


                if (reader.Read())
                {

                    isFound = true;
                    NationalID = reader["NationalID"].ToString();
                    FirstName = reader["FirstName"].ToString();
                    LastName = reader["LastName"].ToString();

                    Gender = Convert.ToByte(reader["Gender"]);

                   
                    Email = reader["Email"] as string ?? "";
                    Phone = reader["Phone"] as string ?? "";
                    Address = reader["Address"] as string ?? "";

                    CityID = Convert.ToInt32(reader["CityID"]);

                }
                else
                {
                    isFound = false;
                }
                reader.Close();

            }

            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
                isFound = false;


            }
            finally
            {

                Connection.Close();
            }


            return isFound;
        }

        public static bool GetPersonByNationalID(string NationalID, ref int PersonID, ref string FirstName,
                                        ref string LastName, ref byte Gender, ref string Email,
                                        ref string Phone, ref string Address, ref int CityID, ref string ErrorMessage)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Persons WHERE NationalID = @NationalID;";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalID", NationalID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    PersonID = Convert.ToInt32(reader["PersonID"]);
                    FirstName = reader["FirstName"].ToString();
                    LastName = reader["LastName"].ToString();
                    Gender = Convert.ToByte(reader["Gender"]);
                    Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : "";
                    Phone = reader["Phone"] != DBNull.Value ? reader["Phone"].ToString() : "";
                    Address = reader["Address"] != DBNull.Value ? reader["Address"].ToString() : "";
                    CityID = reader["CityID"] != DBNull.Value ? Convert.ToInt32(reader["CityID"]) : -1;
                }
                else
                {
                    isFound = false;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                isFound = false;
            }
            finally

            {

                connection.Close();
            }


            return isFound;
        }

        public static DataTable GetAllPersons(ref string ErrorMessage)

        {


            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);

            string Query = "SELECT * FROM Persons";

            SqlCommand Command = new SqlCommand(Query, Connection);


            try
            {

                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dt.Load(Reader);
                }
                Reader.Close();

            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;

            }
            finally
            {

                Connection.Close();

            }

            return dt;

        }
        

        public static int AddNewPerson(string NationalID, string FirstName, string LastName,
                                       byte Gender, string Email, string Phone, string Address,
                                       int CityID , ref string ErrorMessage )
        {

            int NewID = -1;

            SqlConnection Connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO Persons (NationalID, FirstName, LastName, Gender, Email, Phone, Address, CityID)
                                 VALUES (@NationalID, @FirstName, @LastName, @Gender, @Email, @Phone, @Address, @CityID);
                                 SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@NationalID", NationalID);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@Gender", Gender);
            Command.Parameters.AddWithValue("@Email", (object)Email ?? DBNull.Value);
            Command.Parameters.AddWithValue("@Phone", (object)Phone ?? DBNull.Value);
            Command.Parameters.AddWithValue("@Address", (object)Address ?? DBNull.Value);
            Command.Parameters.AddWithValue("@CityID", CityID);

            try
            {


                Connection.Open();

                object result = Command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    NewID = insertedID;
            }
            catch (Exception ex) 
            { 

                ErrorMessage = ex.Message;


            }
            finally
            {

                Connection.Close();

            }


            return NewID;
        }

        public static bool UpdatePerson(int personID, string nationalID, string firstName, string lastName,
                                        byte gender, string email, string phone, string address, int cityID, 
                                        ref string ErrorMessage)
        {

            int rowsAffected = 0;
            SqlConnection Connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);

            string Query = @"UPDATE Persons 
                                 SET NationalID = @NationalID,
                                     FirstName = @FirstName,
                                     LastName = @LastName,
                                     Gender = @Gender,
                                     Email = @Email,
                                     Phone = @Phone,
                                     Address = @Address,
                                     CityID = @CityID
                                 WHERE PersonID = @PersonID;";


            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", personID);
            Command.Parameters.AddWithValue("@NationalID", nationalID);
            Command.Parameters.AddWithValue("@FirstName", firstName);
            Command.Parameters.AddWithValue("@LastName", lastName);
            Command.Parameters.AddWithValue("@Gender", gender);
            Command.Parameters.AddWithValue("@Email", (object)email ?? DBNull.Value);
            Command.Parameters.AddWithValue("@Phone", (object)phone ?? DBNull.Value);
            Command.Parameters.AddWithValue("@Address", (object)address ?? DBNull.Value);
            Command.Parameters.AddWithValue("@CityID", cityID);

            try
            {

                Connection.Open();
                rowsAffected = Command.ExecuteNonQuery();


            }
            catch (Exception ex) 
            {
            
                ErrorMessage = ex.Message;
            
            
            }
            finally
            {

                Connection.Close();

            }


            return (rowsAffected > 0);
        }

        public static bool DeletePerson(int PersonID,ref string ErrorMessage)


        {

            int rowsAffected = 0;
            SqlConnection Connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);

            string Query = "DELETE FROM Persons WHERE PersonID = @PersonID;";

          

                SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {

                Connection.Open();
                rowsAffected = Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
            }
            finally
            {

                Connection.Close();

            }

            return (rowsAffected > 0);

        }

        public static bool IsPersonExist(int PersonID, ref string ErrorMessage)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT Found = 1 FROM Persons WHERE PersonID = @PersonID;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        isFound = (result != null);
                    }
                    catch (Exception ex)
                    {
                        ErrorMessage = ex.Message;
                        isFound = false;
                    }
                }
            }
            return isFound;
        }

        public static bool IsPersonExist(string NationalID, ref string ErrorMessage)

        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);

            string query = "SELECT Found = 1 FROM Persons WHERE NationalID = @NationalID;";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalID", NationalID);

            try
            {

                connection.Open();
                object result = command.ExecuteScalar();
                isFound = (result != null);


            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
                isFound = false;

            }
            finally
            {
                connection.Close();
            }


            return isFound;
        }



    }
}
