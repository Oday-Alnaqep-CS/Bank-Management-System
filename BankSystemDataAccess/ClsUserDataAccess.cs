using ContactsDataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO.Packaging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace BankSystemDataAccess.EntitiesData
{
    public static partial class ClsUserDataAccess
    {

        public static bool GetUserByID(string UserID, ref int PersonID, ref int DepartmentID, ref int BranchID
                                       , ref string JobTitle, ref DateTime HirdDate, ref decimal Salary
                                       , ref byte Status,ref string  UserName, ref string PasswordHash,ref int RoleID, ref string ErrorMessage)

        {


            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);

            string Query = @"SELECT Users.*, UserRoles.RoleID, UserCredentials.Username, UserCredentials.PasswordHash 
                 FROM Users 
                 INNER JOIN UserCredentials ON Users.UserID = UserCredentials.UserID 
                 LEFT JOIN UserRoles ON Users.UserID = UserRoles.UserID 
                 WHERE Users.UserID = @UserID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@UserID", UserID);


            try
            {


                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();


                if (reader.Read())
                {

                    IsFound = true;

                    PersonID = reader["PersonID"] != DBNull.Value ? (int)reader["PersonID"] : 0;
                    DepartmentID = reader["DepartmentID"] != DBNull.Value ? Convert.ToInt32(reader["DepartmentID"]) : 0;
                    BranchID = reader["BranchID"] != DBNull.Value ? Convert.ToInt32(reader["BranchID"]) : 0;
                    JobTitle = reader["JobTitle"] != DBNull.Value ? reader["JobTitle"].ToString() : string.Empty;
                    HirdDate = reader["HireDate"] != DBNull.Value ? Convert.ToDateTime(reader["HireDate"]) : DateTime.Now;
                    Salary = reader["Salary"] != DBNull.Value ? Convert.ToDecimal(reader["Salary"]) : 0;
                    Status = reader["Status"] != DBNull.Value ? Convert.ToByte(reader["Status"]) : (byte)0;

                    RoleID = reader["RoleID"] != DBNull.Value ? Convert.ToInt32(reader["RoleID"]) : 0;
                    UserName = reader["Username"] != DBNull.Value ? reader["Username"].ToString() : string.Empty;
                    PasswordHash = reader["PasswordHash"] != DBNull.Value ? reader["PasswordHash"].ToString() : string.Empty;
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

        public static bool GetUserByPersonID(int PersonID, ref string UserID, ref int DepartmentID, ref int BranchID
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

                    UserID = (string)reader["UserID"];
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

            string Query = "Select * from UserCredentials";
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

        public static DataTable GetUsersInFo(ref string ErrorMessage)
        {


            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);

            string Query = "SELECT P.ImagePath AS [Profile], " +
                           "U.UserID AS [User ID], " +
                           "UC.Username AS [User Name], " +
                           "P.FirstName + ' ' + P.LastName AS [Full Name], " +
                           "R.RoleName AS [Role / Permissions], " +
                           "U.HireDate AS [Hire Date], " +
                           "U.JobTitle AS [Job Title], " +
                           "CASE WHEN U.Status = 1 THEN 'Active' WHEN U.Status = 2 THEN 'Locked' ELSE 'Inactive' END AS [Status] " +
                           "FROM Users U " +
                           "LEFT JOIN Persons P ON U.PersonID = P.PersonID AND P.PersonType = 'User' " +
                           "LEFT JOIN UserCredentials UC ON U.UserID = UC.UserID " +
                           "LEFT JOIN UserRoles UR ON U.UserID = UR.UserID " +
                           "LEFT JOIN Roles R ON UR.RoleID = R.RoleID;";







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

        public static DataTable GetDepartments(ref string ErrorMessage)
        {


            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);

            string Query = "SELECT DepartmentID , DepartmentName FROM Departments";


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

        public static string GetLastUserID()
        {
            string lastUserID = null;

            
            string query = "SELECT TOP 1 UserID FROM Users ORDER BY UserID DESC;";

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            lastUserID = result.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                      
                        string error = ex.Message;
                    }
                }
            }

            return lastUserID;
        }

        public static string AddNewUserWithPerson(string firstName, string lastName, string nationalID, string Username,string PasswordHash,
                                                  string phone, string email, string imagePath,int RoleID,
                                                  int departmentID,string jobTitle, DateTime hireDate,
                                                  byte status,byte Gender, ref string errorMessage)

        {

            string NewUserID = null;
            string CurrentYear = DateTime.Now.Year.ToString();
            string prefix = $"USR-{CurrentYear}-";

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))

            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                       
                        string personQuery = @"INSERT INTO Persons 
                                     (FirstName, LastName, NationalID,Phone, Email,ImagePath,PersonType,Gender) 
                                     VALUES 
                                     (@FirstName, @LastName, @NationalID, @Phone, @Email,@ImagePath,'User',@Gender );
                                     SELECT SCOPE_IDENTITY();";

                        int personID;

                        using (SqlCommand command = new SqlCommand(personQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@FirstName", firstName);
                            command.Parameters.AddWithValue("@LastName", lastName);
                            command.Parameters.AddWithValue("@NationalID", nationalID);
                            command.Parameters.AddWithValue("@Phone", phone);
                            command.Parameters.AddWithValue("@Email", email);
                            command.Parameters.AddWithValue("@Gender", Gender);
                            command.Parameters.AddWithValue("@ImagePath", imagePath ?? "");

                            personID = Convert.ToInt32(command.ExecuteScalar());
                        }

                       
                       string getLastIdQuery = "SELECT TOP 1 UserID FROM Users WHERE UserID LIKE @Prefix ORDER BY UserID DESC";
                        int nextNumber = 1;

                        using (SqlCommand Command = new SqlCommand(getLastIdQuery, connection, transaction))

                        {

                            Command.Parameters.AddWithValue("@Prefix", prefix + "%");
                            object lastIdObj = Command.ExecuteScalar();

                            if (lastIdObj != null)
                            {
                                string lastId = lastIdObj.ToString();
                                string numberPart = lastId.Substring(lastId.LastIndexOf('-') + 1);
                                if (int.TryParse(numberPart, out int NUm))
                                {
                                    nextNumber = NUm + 1;
                                }
                            }

                            NewUserID = $"{prefix}{nextNumber:D4}";
                        }

                        
                        string UserQuery = @"INSERT INTO Users (UserID, PersonID, DepartmentID, JobTitle, HireDate, Status)
                                       VALUES (@UserID, @PersonID, @DepartmentID,  @JobTitle, @HireDate, @Status);";

                        using (SqlCommand command = new SqlCommand(UserQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@UserID", NewUserID);
                            command.Parameters.AddWithValue("@PersonID", personID);
                            command.Parameters.AddWithValue("@DepartmentID", departmentID);
                            command.Parameters.AddWithValue("@JobTitle", jobTitle);
                            command.Parameters.AddWithValue("@HireDate", DateTime.Now);
                            command.Parameters.AddWithValue("@Status", status);

                            command.ExecuteNonQuery();
                        }


                        string UserCredentialsQuery = @"INSERT INTO UserCredentials (UserID, Username, PasswordHash)
                                       VALUES (@UserID, @Username, @PasswordHash);";

                        using (SqlCommand command = new SqlCommand(UserCredentialsQuery, connection, transaction))

                        {

                            command.Parameters.AddWithValue("@UserID", NewUserID);
                            command.Parameters.AddWithValue("@Username", Username);
                            command.Parameters.AddWithValue("@PasswordHash", PasswordHash);
                            command.ExecuteNonQuery();
                        }

                        string RolsQuery = @"INSERT INTO UserRoles (UserID, RoleID)
                                       VALUES (@UserID, @RoleID);";

                        using (SqlCommand command = new SqlCommand(RolsQuery, connection, transaction))

                        {

                            command.Parameters.AddWithValue("@UserID", NewUserID);
                            command.Parameters.AddWithValue("@RoleID",RoleID ); 
                            command.ExecuteNonQuery();
                        }
                            transaction.Commit();
                        return NewUserID;
                    }
                    catch (Exception ex)
                    {
                       
                        transaction.Rollback();
                        errorMessage = ex.Message;
                        return null;
                    }
                }
            }
        }

        //public static int AddNewUser(int personID, int departmentID, int branchID,
        //                             string jobTitle, DateTime hireDate, decimal salary,
        //                             byte status, ref string ErrorMessage)

        //{

        //    string NewUserID = null;

        //    using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
        //    {

        //        string query = @"INSERT INTO Users (PersonID, DepartmentID, BranchID, JobTitle, HireDate, Salary, Status)
        //                         VALUES (@PersonID, @DepartmentID, @BranchID, @JobTitle, @HireDate, @Salary, @Status);
        //                         SELECT SCOPE_IDENTITY();";

        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@PersonID", personID);
        //            command.Parameters.AddWithValue("@DepartmentID", departmentID);
        //            command.Parameters.AddWithValue("@BranchID", branchID);
        //            command.Parameters.AddWithValue("@JobTitle", jobTitle);
        //            command.Parameters.AddWithValue("@HireDate", hireDate);
        //            command.Parameters.AddWithValue("@Salary", salary);
        //            command.Parameters.AddWithValue("@Status", status);

        //            try
        //            {

        //                connection.Open();

        //                object result = command.ExecuteScalar();

        //                if (result != null && int.TryParse(result.ToString(), out int insertedID))
        //                {

        //                    NewUserID = insertedID;

        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                ErrorMessage = ex.Message;
        //            }

        //        }

        //    }

        //    return NewUserID;
        //}

        public static bool UpdateUser(string UserID, int personID, int departmentID, int branchID,
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

        public static bool UpdateUserWithPerson(string userID, int personID, string firstName, string lastName,
                                        string nationalID, string username, string passwordHash,
                                        string phone, string email, string imagePath, int roleID,
                                        int departmentID, string jobTitle, byte status,byte Gender, ref string errorMessage)

        {
            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))

            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                       
                        string personQuery = @"UPDATE Persons SET FirstName = @FirstName, LastName = @LastName, NationalID = @NationalID, 
                             Phone = @Phone, Email = @Email, ImagePath = @ImagePath, Gender = @Gender WHERE PersonID = @PersonID ;";

                        using (SqlCommand command = new SqlCommand(personQuery, connection, transaction))

                        {
                            command.Parameters.AddWithValue("@PersonID", personID);
                            command.Parameters.AddWithValue("@FirstName", firstName);
                            command.Parameters.AddWithValue("@LastName", lastName);
                            command.Parameters.AddWithValue("@NationalID", nationalID);
                            command.Parameters.AddWithValue("@Phone", phone);
                            command.Parameters.AddWithValue("@Gender", Gender);
                            command.Parameters.AddWithValue("@Email", email);
                            command.Parameters.AddWithValue("@ImagePath", imagePath ?? "");

                            command.ExecuteNonQuery();
                        }

                        string userQuery = @"UPDATE Users SET DepartmentID = @DepartmentID,JobTitle = @JobTitle,Status = @Status WHERE UserID = @UserID;";

                        using (SqlCommand command = new SqlCommand(userQuery, connection, transaction))

                        {
                            command.Parameters.AddWithValue("@UserID", userID);
                            command.Parameters.AddWithValue("@DepartmentID", departmentID);
                            command.Parameters.AddWithValue("@JobTitle", jobTitle);
                            command.Parameters.AddWithValue("@Status", status);

                            command.ExecuteNonQuery();
                        }

                      
                        string userCredentialsQuery = @"UPDATE UserCredentials SET Username = @Username,PasswordHash = @PasswordHash WHERE UserID = @UserID;";

                        using (SqlCommand command = new SqlCommand(userCredentialsQuery, connection, transaction))

                        {
                            command.Parameters.AddWithValue("@UserID", userID);
                            command.Parameters.AddWithValue("@Username", username);
                            command.Parameters.AddWithValue("@PasswordHash", passwordHash);

                            command.ExecuteNonQuery();
                        }

                      
                        string roleQuery = @"UPDATE UserRoles SET RoleID = @RoleID WHERE UserID = @UserID;";

                        using (SqlCommand command = new SqlCommand(roleQuery, connection, transaction))

                        {
                            command.Parameters.AddWithValue("@UserID", userID);
                            command.Parameters.AddWithValue("@RoleID", roleID);

                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }

                    catch (Exception ex)

                    {
                        transaction.Rollback();
                        errorMessage = ex.Message;
                        return false;
                    }
                }
            }
        }

        public static bool UpdateUserStatus(string UserID, byte status, ref string errorMessage)

        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE Users 
                         SET Status = @Status 
                         WHERE UserID = @UserID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.Parameters.AddWithValue("@Status", status);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                        return false;
                    }
                }
            }

            return rowsAffected > 0;
        }

        public static bool DeleteUser(string UserID, ref string ErrorMessage)


        {

           
            int PersonID = -1;

            using (SqlConnection Connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))

            {

                try
                {

                    Connection.Open();

                    string GetPersonIDQuery = "SELECT PersonID FROM Users WHERE UserID = @UserID;";
                    using (SqlCommand GetPersonIDCommand = new SqlCommand(GetPersonIDQuery, Connection))

                    {
                        GetPersonIDCommand.Parameters.AddWithValue("@UserID", UserID);

                       
                            object result = GetPersonIDCommand.ExecuteScalar();

                            if (result != null && int.TryParse(result.ToString(), out int id))
                            {
                                PersonID = Convert.ToInt32(id);
                            }

                    }


                    if (PersonID == -1)

                    {
                        ErrorMessage = "User or associated Person id not found.";
                        return false;

                    }

                    using (SqlTransaction Transaction = Connection.BeginTransaction())

                    {
                        try
                        {

                            string DeleteUserQuery = "DELETE FROM Users WHERE UserID = @UserID;";
                            using (SqlCommand DeleteUserCommand = new SqlCommand(DeleteUserQuery, Connection, Transaction))

                            {

                                 DeleteUserCommand.Parameters.AddWithValue("@UserID", UserID);
                                 DeleteUserCommand.ExecuteNonQuery();

                            }

                            string DeletePersonQuery = "DELETE FROM Persons WHERE PersonID = @PersonID";
                            using (SqlCommand DeletePersonCommand = new SqlCommand(DeletePersonQuery, Connection, Transaction))

                            {

                                DeletePersonCommand.Parameters.AddWithValue(@"PersonID", PersonID);
                                DeletePersonCommand.ExecuteNonQuery();

                            }

                            Transaction.Commit();
                            return true;

                        }
                        catch (Exception ex)
                        {
                            Transaction.Rollback();
                            ErrorMessage = ex.Message;
                            return false;
                        }

                    }


                }
                catch (Exception ex)
                {
                    ErrorMessage = ex.Message;
                    return false;
                }

            } 

        }

        public static bool IsUserExistByID(string UserID , ref string ErrorMessage)


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
                                        ref string userID, ref int personID, ref int departmentID,
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

                                userID = (string)reader["UserID"];
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

        public static int GetTotalUsers(out string ErrorMessage)



        {

            int TotalClients = 0;
            ErrorMessage = string.Empty;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))

            {
                string query = "SELECT COUNT(*) FROM Users";

                using (SqlCommand command = new SqlCommand(query, connection))
                {


                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)


                        {

                            TotalClients = Convert.ToInt32(result);

                        }

                    }
                    catch (Exception ex)
                    {
                        ErrorMessage = ex.Message;
                        System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
                    }
                }
            }

            return TotalClients;
        }

        public static int GetTotalActiveUsers(out string ErrorMessage)



        {

            int TotalClients = 0;
            ErrorMessage = string.Empty;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))

            {
                string query = "SELECT COUNT(*) FROM Users where Users.Status = 1";

                using (SqlCommand command = new SqlCommand(query, connection))
                {


                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)


                        {

                            TotalClients = Convert.ToInt32(result);

                        }

                    }
                    catch (Exception ex)
                    {
                        ErrorMessage = ex.Message;
                        System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
                    }
                }
            }

            return TotalClients;
        }

    
    }
}
