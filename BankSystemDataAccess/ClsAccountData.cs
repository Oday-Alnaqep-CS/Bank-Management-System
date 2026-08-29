using ContactsDataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BankSystemDataAccess.FinancialData
{
    public static partial class ClsAccountData
    {


        public static bool GetAccountByID(int accountID, ref string accountNumber, ref string iban,
                                           ref int clientID, ref int accountTypeID, ref int branchID,
                                           ref int currencyID, ref decimal balance, ref byte status,
                                           ref DateTime createdDate, ref string errorMessage)

        {


            bool isFound = false;



            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = @"SELECT AccountNumber, IBAN, ClientID, AccountTypeID, BranchID, CurrencyID, Balance, Status, CreatedDate 
                             FROM Accounts WHERE AccountID = @AccountID;";


                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@AccountID", accountID);

                    try
                    {

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {

                                isFound = true;
                                accountNumber = (string)reader["AccountNumber"];
                                iban = reader["IBAN"] != DBNull.Value ? (string)reader["IBAN"] : string.Empty;
                                clientID = (int)reader["ClientID"];
                                accountTypeID = (int)reader["AccountTypeID"];
                                branchID = (int)reader["BranchID"];
                                currencyID = (int)reader["CurrencyID"];
                                balance = (decimal)reader["Balance"];
                                status = (byte)reader["Status"];
                                createdDate = (DateTime)reader["CreatedDate"];

                            }

                        }

                    }

                    catch (Exception ex)
                    {
                        isFound = false;
                        errorMessage = ex.Message;
                    }
                }
            }
            return isFound;
        }


        public static bool GetAccountByAccountNumber(string accountNumber, ref int accountID, ref string iban,
                                                      ref int clientID, ref int accountTypeID, ref int branchID,
                                                      ref int currencyID, ref decimal balance, ref byte status,
                                                      ref DateTime createdDate, ref string errorMessage)

        {

            bool isFound = false;


            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = @"SELECT AccountID, IBAN, ClientID, AccountTypeID, BranchID, CurrencyID, Balance, Status, CreatedDate 
                             FROM Accounts WHERE AccountNumber = @AccountNumber;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@AccountNumber", accountNumber);

                    try
                    {

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {

                                isFound = true;
                                accountID = (int)reader["AccountID"];
                                iban = reader["IBAN"] != DBNull.Value ? (string)reader["IBAN"] : string.Empty;
                                clientID = (int)reader["ClientID"];
                                accountTypeID = (int)reader["AccountTypeID"];
                                branchID = (int)reader["BranchID"];
                                currencyID = (int)reader["CurrencyID"];
                                balance = (decimal)reader["Balance"];
                                status = (byte)reader["Status"];
                                createdDate = (DateTime)reader["CreatedDate"];

                            }

                        }

                    }

                    catch (Exception ex)
                    {
                        isFound = false;
                        errorMessage = ex.Message;
                    }

                }
            }

            return isFound;

        }


        public static bool IsAccountExist(int AccountID, ref string errorMessage)


        {

            bool IsFound = false;

            using (SqlConnection Connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {


                string Query = "Select Found = 1 from Accounts Where AccountID =@AccountID";

                using (SqlCommand command = new SqlCommand(Query, Connection))
                {

                    command.Parameters.AddWithValue("@AccountID", AccountID);

                    try
                    {

                        Connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null) IsFound = true;

                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                    }

                }

                return IsFound;

            }

        }



        public static DataTable GetAccountsView(ref string errorMessage)


        {


            DataTable dt = new DataTable();


            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = "SELECT * FROM vw_Accounts;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows) dt.Load(reader);
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


        public static DataTable GetAccountsByClientID(int clientID, ref string errorMessage)


        {

            DataTable dt = new DataTable();


            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = "SELECT * FROM Accounts WHERE ClientID = @ClientID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@ClientID", clientID);

                    try
                    {

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows) dt.Load(reader);
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

        public static DataTable GetAccountsType( ref string errorMessage)


        {

            DataTable dt = new DataTable();


            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = "SELECT TypeName , AccountTypeID from AccountTypes";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                 

                    try
                    {

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows) dt.Load(reader);
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



        public static bool Deposit(int AccountID,decimal Amount,ref string ErrorMessage)


        {
            using (SqlConnection connection =  new SqlConnection(ClsDataAccessSettings.ConnectionString))


            {
                        string query = @"
                                          UPDATE Accounts
                                          SET Balance = Balance + @Amount
                                          WHERE AccountID = @AccountID;";

                using (SqlCommand command =
                       new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AccountID", AccountID);
                    command.Parameters.AddWithValue("@Amount", Amount);

                    try
                    {
                        connection.Open();

                        int RowsAffected = command.ExecuteNonQuery();

                        return RowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        ErrorMessage = ex.Message;
                        return false;
                    }

                }

            }

        }




        public static bool Withdraw( int AccountID,decimal Amount,ref string ErrorMessage)


        {


            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))

            {

                string query = @"
                                 UPDATE Accounts
                                 SET Balance = Balance - @Amount
                                 WHERE AccountID = @AccountID
                                   AND Balance >= @Amount;";



                using (SqlCommand command = new SqlCommand(query, connection))

                {

                    command.Parameters.AddWithValue("@AccountID", AccountID);
                    command.Parameters.AddWithValue("@Amount", Amount);

                    try
                    {
                        connection.Open();

                        int RowsAffected = command.ExecuteNonQuery();

                        return RowsAffected > 0;
                    }
                    catch (Exception ex)
                    {

                        ErrorMessage = ex.Message;
                        return false;

                    }

                }

            }

        }


    }






}
