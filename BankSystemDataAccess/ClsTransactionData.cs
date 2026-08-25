using ContactsDataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BankSystemDataAccess.FinancialData
{
    public static partial class ClsTransactionData
    {


        public static bool GetTransactionByID(int transactionID, ref int? fromAccountID, ref int? toAccountID,
                                               ref byte transactionTypeID, ref int currencyID,
                                               ref int? performedByClientID, ref int? executedByUserID,
                                               ref decimal amount, ref string description,
                                               ref DateTime transactionDate, ref string errorMessage)
        {
            bool isFound = false;


            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = @"SELECT FromAccountID, ToAccountID, TransactionTypeID, CurrencyID, 
                                    PerformedByClientID, ExecutedByUserID, Amount, Description, TransactionDate 
                             FROM Transactions 
                             WHERE TransactionID = @TransactionID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@TransactionID", transactionID);


                    try
                    {

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {

                                isFound = true;

                                fromAccountID = reader["FromAccountID"] != DBNull.Value ? (int?)reader["FromAccountID"] : null;
                                toAccountID = reader["ToAccountID"] != DBNull.Value ? (int?)reader["ToAccountID"] : null;
                                transactionTypeID = (byte)reader["TransactionTypeID"];
                                currencyID = (int)reader["CurrencyID"];
                                performedByClientID = reader["PerformedByClientID"] != DBNull.Value ? (int?)reader["PerformedByClientID"] : null;
                                executedByUserID = reader["ExecutedByUserID"] != DBNull.Value ? (int?)reader["ExecutedByUserID"] : null;
                                amount = (decimal)reader["Amount"];
                                description = reader["Description"] != DBNull.Value ? (string)reader["Description"] : string.Empty;
                                transactionDate = (DateTime)reader["TransactionDate"];

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

 

        public static bool IsTransactionExist(int transactionID, ref string errorMessage)
        {

            bool isFound = false;


            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = "SELECT Found=1 FROM Transactions WHERE TransactionID = @TransactionID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TransactionID", transactionID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null) isFound = true;
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