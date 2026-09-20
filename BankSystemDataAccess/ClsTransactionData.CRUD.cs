using ContactsDataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BankSystemDataAccess.FinancialData
{
    public static partial class ClsTransactionData
    {
        public static int AddNewTransaction(int? fromAccountID, int? toAccountID, byte transactionTypeID,
                            int currencyID, int? performedByClientID, string executedByUserID,
                            decimal amount, decimal amountafter, string description, string FromClientName, string ToClientName, ref string errorMessage)


        {
            int transactionID = -1;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
              
                string query = @"INSERT INTO Transactions 
                                (FromAccountID, ToAccountID, TransactionTypeID, CurrencyID, PerformedByClientID, ExecutedByUserID, Amount, AmountAfter, Description, TransactionDate, FromClientName, ToClientName)
                                VALUES 
                                (@FromAccountID, @ToAccountID, @TransactionTypeID, @CurrencyID, @PerformedByClientID, @ExecutedByUserID, @Amount, @AmountAfter, @Description, GETDATE(), @FromClientName, @ToClientName);
                                SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FromAccountID", (object)fromAccountID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ToAccountID", (object)toAccountID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@TransactionTypeID", transactionTypeID);
                    command.Parameters.AddWithValue("@CurrencyID", currencyID);
                    command.Parameters.AddWithValue("@PerformedByClientID", (object)performedByClientID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ExecutedByUserID", (object)executedByUserID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Amount", amount);
                    command.Parameters.AddWithValue("@AmountAfter", amountafter);
                    command.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(description) ? DBNull.Value : (object)description);

                    command.Parameters.AddWithValue("@FromClientName", string.IsNullOrEmpty(FromClientName) ? DBNull.Value : (object)FromClientName);
                    command.Parameters.AddWithValue("@ToClientName", string.IsNullOrEmpty(ToClientName) ? DBNull.Value : (object)ToClientName);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            transactionID = insertedID;
                        }
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                    }
                }
            }

            return transactionID;
        }


        public static bool UpdateTransactionDescription(int transactionID, string newDescription, ref string errorMessage)
        {


            int rowsAffected = 0;


            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = "UPDATE Transactions SET Description = @Description WHERE TransactionID = @TransactionID;";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TransactionID", transactionID);
                    command.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(newDescription) ? DBNull.Value : (object)newDescription);

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

   
        public static bool DeleteTransaction(int transactionID, ref string errorMessage)
        {

            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = "DELETE FROM Transactions WHERE TransactionID = @TransactionID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TransactionID", transactionID);

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
    }
}