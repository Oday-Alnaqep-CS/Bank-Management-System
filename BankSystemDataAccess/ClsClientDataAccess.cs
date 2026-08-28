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

        public static DataTable GetAllClients(ref string errorMessage)


        {

            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = @"
                                   SELECT 
                                       Clients.ClientID AS [Client ID],
                                       Persons.ImagePath AS [Profile],
                                       Persons.FirstName + ' ' + Persons.LastName AS [Full Name],
                                       Persons.Email AS [Email Address],
                                       Persons.Phone AS [Phone Number],

                                      CASE 
                                          When Persons.Gender = 1 Then 'M'
                                          else 'F'
                                      END AS [Gender],

                                       ISNULL(Countries.CountryName, 'N/A') AS [Country],
                                       COUNT(Accounts.AccountID) AS [Total Accounts], 

                                       CASE 
                                           WHEN Clients.Status = 1 THEN 'Active' 
                                           ELSE 'Inactive' 
                                       END AS [Status],
                                       ISNULL(SUM(Accounts.Balance), 0.00) AS [Total Balance (USD)],
                                       Clients.CreatedDate AS [Date Registered],
                                       ISNULL(STRING_AGG(AccountTypes.TypeName, ' & '), 'No Accounts') AS [Account Type(s)]
                                   FROM Clients
                                   INNER JOIN Persons ON Clients.PersonID = Persons.PersonID
                                   LEFT JOIN Cities ON Persons.CityID = Cities.CityID
                                   LEFT JOIN Countries ON Cities.CountryID = Countries.CountryID
                                   LEFT JOIN Accounts ON Clients.ClientID = Accounts.ClientID
                                   LEFT JOIN Cards Ca ON Ca.AccountID = Accounts.AccountID
                                   LEFT JOIN AccountTypes ON Accounts.AccountTypeID = AccountTypes.AccountTypeID";


                query += @" GROUP BY 
                                           Clients.ClientID, 
                                           Persons.ImagePath, 
                                           Persons.FirstName, 
                                           Persons.LastName, 
                                           Persons.Email, 
                                           Persons.Phone, 
                                           Persons.Gender,
                                           Countries.CountryName, 
                                           Clients.CreatedDate, 
                                           Clients.Status;";

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

        public static DataTable GetAllActiveClients(ref string errorMessage)


        {

            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = @"
                          SELECT 
                              Clients.ClientID AS [Client ID],
                              Persons.ImagePath AS [Profile],
                              Persons.FirstName + ' ' + Persons.LastName AS [Full Name],
                              Persons.Email AS [Email Address],
                              Persons.Phone AS [Phone Number], 
                              CASE 
                                          When Persons.Gender = 1 Then 'M'
                                          else 'F'
                             END AS [Gender],

                              CASE 
                                  WHEN Clients.Status = 1 THEN 'Active'
                                  ELSE 'Inactive' 
                              END AS [Status],

                             (
                                  SELECT MAX(T.TransactionDate) 
                                  FROM Transactions T 
                                  INNER JOIN Accounts Acc ON T.FromAccountID = Acc.AccountID OR T.ToAccountID = Acc.AccountID 
                                  WHERE Acc.ClientID = Clients.ClientID
                              ) AS [Last TransAction Date],

                              ISNULL(STRING_AGG(AccountTypes.TypeName, ' & '), 'No Accounts') AS [Account Type(s)],
                              ISNULL(STRING_AGG(CAST(Accounts.AccountNumber AS VARCHAR(50)), ' & '), 'N/A') AS [Accounts Number], 
                              
                             
                              
                             
                              ISNULL(SUM(Accounts.Balance), 0.00) AS [Total Balance (USD)],
                              Clients.CreatedDate AS [Date Registered]
                          FROM Clients
                          INNER JOIN Persons ON Clients.PersonID = Persons.PersonID
                          LEFT JOIN Cities ON Persons.CityID = Cities.CityID
                          LEFT JOIN Countries ON Cities.CountryID = Countries.CountryID
                          LEFT JOIN Accounts ON Clients.ClientID = Accounts.ClientID
                          LEFT JOIN Cards Ca ON Ca.AccountID = Accounts.AccountID
                          LEFT JOIN AccountTypes ON Accounts.AccountTypeID = AccountTypes.AccountTypeID
                          WHERE Clients.Status = 1 ";

                query += @" GROUP BY 
                          Clients.ClientID, 
                          Persons.ImagePath, 
                          Persons.FirstName, 
                          Persons.LastName, 
                          Persons.Email, 
                          Persons.Phone, 
                          Persons.Gender,
                          Clients.CreatedDate, 
                          Clients.Status;";

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

        public static DataTable GetAllCustomers(ref string errorMessage)


        {

            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = @"
                                  SELECT 
                                      P.ImagePath AS [Profile],
                                      ISNULL(MIN(Accounts.AccountNumber), 'N/A') AS [Accounts Number],
                                      P.FirstName + ' ' + P.LastName AS [Full Name],
                                      P.Phone AS [Phone Number],
                                      P.Email AS [Email Address],
   
                                      CASE 
                                          When P.Gender = 1 Then 'M'
                                          else 'F'
                                      END AS [Gender],
                                       
                                      ISNULL(MIN(Ca.PIN_Hash), 'N/A') AS [PinCode],
                                      DATEDIFF(YEAR, P.DateOfBirth, GETDATE()) AS Age,
                                      ISNULL(MIN(Ca.CardNumber), 'N/A') AS [Card Number],
                                      ISNULL(MIN(Branches.BranchName), 'N/A') AS [Branche],
                                      ISNULL(Countries.CountryName, 'N/A') AS [Country],
                                      ISNULL(Cities.CityName, 'N/A') AS [City],
                                      COUNT(DISTINCT Accounts.AccountID) AS [Total Accounts], 

                                      CASE 
                                          WHEN Clients.Status = 1 THEN 'Active'
                                          ELSE 'Inactive'
                                      END AS [Status],

                                      ISNULL(SUM(Accounts.Balance), 0.00) AS [Total Balance (USD)],
                                      Clients.CreatedDate AS [Date Registered],
                                      ISNULL(MIN(AccountTypes.TypeName), 'No Accounts') AS [Account Type(s)]

                                  FROM Clients
                                  INNER JOIN Persons P ON Clients.PersonID = P.PersonID
                                  LEFT JOIN Cities ON P.CityID = Cities.CityID
                                  LEFT JOIN Countries ON Cities.CountryID = Countries.CountryID
                                  LEFT JOIN Accounts ON Clients.ClientID = Accounts.ClientID
                                  LEFT JOIN AccountTypes ON Accounts.AccountTypeID = AccountTypes.AccountTypeID
                                  LEFT JOIN Cards Ca ON Ca.AccountID = Accounts.AccountID
                                  LEFT JOIN Branches ON Accounts.BranchID = Branches.BranchID



                                  GROUP BY 
                                      Clients.ClientID,
                                      P.ImagePath,
                                      P.FirstName,
                                      P.LastName,
                                      P.Phone,
                                      P.Email,
                                      P.Gender,
                                      P.DateOfBirth,
                                      Countries.CountryName,
                                      Cities.CityName,
                                      Clients.Status,
                                      Clients.CreatedDate;";


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