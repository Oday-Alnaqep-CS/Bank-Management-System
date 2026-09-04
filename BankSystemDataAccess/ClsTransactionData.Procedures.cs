using ContactsDataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BankSystemDataAccess.FinancialData
{
    public static partial class ClsTransactionData
    {
        
        public static bool Transfers(int fromAccountID, int toAccountID, decimal amount,
                                         int currencyID, int? performedByClientID, string executedByUserID,
                                         string description, ref string errorMessage)

        {

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                try
                {

                    connection.Open();
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                       
                        string withdrawQuery = @"UPDATE Accounts 
                                                 SET Balance = Balance - @Amount 
                                                 WHERE AccountID = @FromAccountID AND Balance >= @Amount;";

                        using (SqlCommand withdrawCmd = new SqlCommand(withdrawQuery, connection, transaction))
                        {

                            withdrawCmd.Parameters.AddWithValue("@Amount", amount);
                            withdrawCmd.Parameters.AddWithValue("@FromAccountID", fromAccountID);


                            if (withdrawCmd.ExecuteNonQuery() == 0)
                            {
                                transaction.Rollback();
                                errorMessage = "Transaction failed: Insufficient balance or sender account not found.";
                                return false;
                            }
                        }

                      
                        string depositQuery = @"UPDATE Accounts 
                                                SET Balance = Balance + @Amount 
                                                WHERE AccountID = @ToAccountID;";

                        using (SqlCommand depositCmd = new SqlCommand(depositQuery, connection, transaction))
                        {

                            depositCmd.Parameters.AddWithValue("@Amount", amount);
                            depositCmd.Parameters.AddWithValue("@ToAccountID", toAccountID);


                            if (depositCmd.ExecuteNonQuery() == 0)
                            {
                                transaction.Rollback();
                                errorMessage = "Transaction failed: Receiver account not found.";
                                return false;
                            }
                        }

                       
                        string logQuery = @"INSERT INTO Transactions 
                                            (FromAccountID, ToAccountID, TransactionTypeID, CurrencyID, PerformedByClientID, ExecutedByUserID, Amount, Description, TransactionDate)
                                            VALUES (@FromAccountID, @ToAccountID, 3, @CurrencyID, @PerformedByClientID, @ExecutedByUserID, @Amount, @Description, GETDATE());";

                        using (SqlCommand logCmd = new SqlCommand(logQuery, connection, transaction))
                        {

                            logCmd.Parameters.AddWithValue("@FromAccountID", fromAccountID);
                            logCmd.Parameters.AddWithValue("@ToAccountID", toAccountID);
                            logCmd.Parameters.AddWithValue("@CurrencyID", currencyID);
                            logCmd.Parameters.AddWithValue("@PerformedByClientID", (object)performedByClientID ?? DBNull.Value);
                            logCmd.Parameters.AddWithValue("@ExecutedByUserID", (object)executedByUserID ?? DBNull.Value);
                            logCmd.Parameters.AddWithValue("@Amount", amount);
                            logCmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(description) ? DBNull.Value : (object)description);


                            logCmd.ExecuteNonQuery();


                        }

                        
                        transaction.Commit();
                        return true;

                    }

                }
                catch (Exception ex)
                {

                    errorMessage = ex.Message;
                    return false;

                }
            }
        }
    }
}
