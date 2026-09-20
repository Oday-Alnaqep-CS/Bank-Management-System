using ContactsDataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;


namespace BankSystemDataAccess.FinancialData
{

    public static partial class ClsTransactionData
    {
       
        public static DataTable GetTransactionsView(ref string errorMessage)
        {

            DataTable dt = new DataTable();


            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT 
                    T.TransactionID AS [Transaction ID],
                    CONVERT(VARCHAR(30), T.TransactionDate , 100) AS [Date & Time],
                    Tr.TypeName AS [Type],
                    ISNULL(T.FromClientName, 'N/A') AS [From Customer Name],
                    ISNULL(T.ToClientName, 'N/A') AS [To Customer Name],
                    ISNULL(A.AccountNumber, 'N/A') AS [Account No.], 
                    T.Amount AS [Amount],
                    T.AmountAfter AS [Amount After],
                    CASE T.Status
                        WHEN 1 THEN 'Success'
                        WHEN 2 THEN 'Cancelled'
                        WHEN 3 THEN 'Pending'
                        ELSE 'Failed'
                    END AS [Status]
                 FROM Transactions T  
                 LEFT JOIN Accounts A ON COALESCE(T.FromAccountID, T.ToAccountID) = A.AccountID
                 LEFT JOIN Clients C ON A.ClientID = C.ClientID
                 LEFT JOIN Persons P ON C.PersonID = P.PersonID
                 INNER JOIN TransactionType Tr ON T.TransactionTypeID = Tr.TransactionTypeID
                 ORDER BY T.TransactionDate DESC;";

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

      

        public static DataTable GetTransactionsByAccountID(int accountID, ref string errorMessage)
        {

            DataTable dt = new DataTable();



            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = @"SELECT * FROM Transactions 
                             WHERE FromAccountID = @AccountID OR ToAccountID = @AccountID 
                             ORDER BY TransactionDate DESC;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AccountID", accountID);

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

       
        public static DataTable GetTransactionsByDateRange(DateTime startDate, DateTime endDate, ref string errorMessage)
        {

            DataTable dt = new DataTable();



            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = @"SELECT * FROM Transactions 
                             WHERE TransactionDate BETWEEN @StartDate AND @EndDate 
                             ORDER BY TransactionDate DESC;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

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
    }
}