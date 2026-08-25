using ContactsDataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;


namespace BankSystemDataAccess.EntitiesData
{
    public static partial class ClsUserDataAccess
    {

        public static bool GetUserByID(int UserID, ref int PersonID, ref int DepartmentID, ref int BranchID
                                       , ref string JobTitle, ref DateTime HirdDate, ref decimal Salary
                                       , ref byte Status, ref string ErrorMessage)

        {


            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);

            string Query = "Select * from Users where UserID = @UserID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@UserID", UserID);


            try
            {


                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();


                if (reader.Read())
                {

                    IsFound = true;

                    PersonID = (int)reader["PersonID"];
                    DepartmentID = (int)reader["DepartmentID"];
                    BranchID = (int)reader["BranchID"];
                    JobTitle = (string)reader["JobTitle"];
                    HirdDate = (DateTime)reader["HireDate"];
                    Salary = (decimal)reader["Salary"];
                    Status = (byte)reader["Status"];


                }
                else
                {

                    IsFound = false;
                }
                reader.Close();
            }
            catch (Exception ex)
            {

                IsFound = false;
                ErrorMessage = ex.Message;

            }
            finally
            {

                Connection.Close();

            }

            return IsFound;


        }

        public static bool GetUserByPersonID(int PersonID, ref int UserID, ref int DepartmentID, ref int BranchID
                                    , ref string JobTitle, ref DateTime HirdDate, ref decimal Salary
                                    , ref byte Status, ref string ErrorMessage)

        {


            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);

            string Query = "Select * from Users where PersonID = @PersonID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);


            try
            {


                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();


                if (reader.Read())
                {

                    IsFound = true;

                    UserID = (int)reader["UserID"];
                    DepartmentID = (int)reader["DepartmentID"];
                    BranchID = (int)reader["BranchID"];
                    JobTitle = (string)reader["JobTitle"];
                    HirdDate = (DateTime)reader["HireDate"];
                    Salary = (decimal)reader["Salary"];
                    Status = (byte)reader["Status"];


                }
                else
                {

                    IsFound = false;

                }
                reader.Close();


            }
            catch (Exception ex)
            {

                IsFound = false;
                ErrorMessage = ex.Message;

            }
            finally
            {

                Connection.Close();

            }

            return IsFound;


        }

        public static DataTable GetAllUsers(ref string ErrorMessage)
        {


            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);

            string Query = "Select * from Users";
            SqlCommand Command = new SqlCommand(Query, Connection);


            try
            {

                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();


                if (reader.HasRows)
                {

                    dt.Load(reader);
                }

                reader.Close();

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


        public static int AddNewUser(int personID, int departmentID, int branchID,
                                     string jobTitle, DateTime hireDate, decimal salary,
                                     byte status, ref string ErrorMessage)

        {

            int newUserID = -1;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = @"INSERT INTO Users (PersonID, DepartmentID, BranchID, JobTitle, HireDate, Salary, Status)
                                 VALUES (@PersonID, @DepartmentID, @BranchID, @JobTitle, @HireDate, @Salary, @Status);
                                 SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", personID);
                    command.Parameters.AddWithValue("@DepartmentID", departmentID);
                    command.Parameters.AddWithValue("@BranchID", branchID);
                    command.Parameters.AddWithValue("@JobTitle", jobTitle);
                    command.Parameters.AddWithValue("@HireDate", hireDate);
                    command.Parameters.AddWithValue("@Salary", salary);
                    command.Parameters.AddWithValue("@Status", status);

                    try
                    {

                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {

                            newUserID = insertedID;

                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                }

            }

            return newUserID;
        }


        public static bool UpdateUser(int UserID, int personID, int departmentID, int branchID,
                                     string jobTitle, DateTime hireDate, decimal salary,
                                     byte status, ref string ErrorMessage)

        {

            int rowsAffected = 0;

            SqlConnection Connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);

            string Query = @"UPDATE Users 
                                 SET PersonID = @PersonID,
                                     DepartmentID = @DepartmentID,
                                     BranchID = @BranchID,
                                     JobTitle = @JobTitle,
                                     HireDate = @HireDate,
                                     Salary = @Salary,
                                     Status = @Status
                                 WHERE UserID = @UserID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@UserID", UserID);
            Command.Parameters.AddWithValue("@PersonID", personID);
            Command.Parameters.AddWithValue("@DepartmentID", departmentID);
            Command.Parameters.AddWithValue("@BranchID", branchID);
            Command.Parameters.AddWithValue("@JobTitle", jobTitle);
            Command.Parameters.AddWithValue("@HireDate", hireDate);
            Command.Parameters.AddWithValue("@Salary", salary);
            Command.Parameters.AddWithValue("@Status", status);


            try
            {

                Connection.Open();

                rowsAffected = Command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {

                  ErrorMessage = ex.Message;
                return false;

            }
            finally
            {

                Connection.Close();
            }

            return (rowsAffected > 0);




        }


        public static bool DeleteUser(int UserID , ref string ErrorMessage)


        {

            int rowsDeleted = 0;

            SqlConnection Connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);

            string Query = "Delete from Users Where UserID = @UserID;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@UserID", UserID);


            try
            {

                Connection.Open();
                rowsDeleted = Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
                return false;
            }
            finally
            {

                Connection.Close();
            }
            return (rowsDeleted > 0);


        }


        public static bool IsUserExistByID(int UserID , ref string ErrorMessage)


        {

            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);

            string Query = "Select Found = 1 from Users where UserID = @UserID; ";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@UserID", UserID);


            try
            {

                Connection.Open();
                object result = Command.ExecuteScalar();
                IsFound = (result!= null);

            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;

            }
            finally
            {

                Connection.Close();

            }

            return IsFound;
        }


        public static bool IsUserExistByPersonID(int PersonID , ref string ErrorMessage)


        {

            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);

            string Query = "select Found = 1 from Users where PersonID = @PersonID";
            SqlCommand Command = new SqlCommand(Query , Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {

                Connection.Open();
                object result = Command.ExecuteScalar();
                IsFound = (result != null);
            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;

            }
            finally
            {

                Connection.Close();

            }

            return IsFound;


        }



        public static bool GetUserByUsernameAndPassword(string username, string password,
                                        ref int userID, ref int personID, ref int departmentID,
                                        ref int branchID, ref string jobTitle, ref DateTime hireDate,
                                        ref decimal salary, ref byte status, ref string errorMessage)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
                {
                     
                    string query = @"SELECT 
                                U.UserID, 
                                U.PersonID, 
                                U.DepartmentID, 
                                U.BranchID, 
                                U.JobTitle, 
                                U.HireDate, 
                                U.Salary, 
                                U.Status, 
                                UC.Username
                            FROM Users U 
                            INNER JOIN UserCredentials UC ON U.UserID = UC.UserID 
                            WHERE UC.Username = @Username 
                              AND UC.PasswordHash = @PasswordHash";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);

                       
                        command.Parameters.AddWithValue("@PasswordHash", password);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                userID = (int)reader["UserID"];
                                personID = (int)reader["PersonID"];
                                departmentID = reader["DepartmentID"] != DBNull.Value ? (int)reader["DepartmentID"] : -1;
                                branchID = reader["BranchID"] != DBNull.Value ? (int)reader["BranchID"] : -1;
                                jobTitle = reader["JobTitle"] != DBNull.Value ? (string)reader["JobTitle"] : "";
                                hireDate = Convert.ToDateTime(reader["HireDate"]);
                                salary = Convert.ToDecimal(reader["Salary"]);
                                status = Convert.ToByte(reader["Status"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                isFound = false;
                errorMessage = ex.Message;
            }

            return isFound;
        }

    }
}
