using ContactsDataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Media.Animation;
namespace BankSystemDataAccess
{
    public static class ClsBalanceData
    {

        public static DataTable GetAllBalance(ref string ErrorMessage)

        {

            DataTable dt = new DataTable();

            using (SqlConnection Connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))

            {
                string query = @"SELECT 
                                      Clients.ClientID AS [Client ID], 
                                      Acc.AccountNumber AS [Account Number],                   
                                      P.FirstName + ' ' + P.LastName AS [Full Name],                   
                                      ISNULL(AccountTypes.TypeName, 'Unknown') AS [Account Type],                   
                                      ISNULL(Acc.Balance, 0.00) AS [Current Balance (USD)],                                                 
                                      CASE 
                                          WHEN Acc.Status = 1 THEN 'Active'
                                          WHEN Acc.Status = 2 THEN 'Dormant'
                                          WHEN Acc.Status = 3 THEN 'Frozen'
                                          ELSE 'Unknown'
                                      END AS [Account Status],
                                       (
                                         SELECT MAX(T.TransactionDate) 
                                         FROM Transactions T 
                                         INNER JOIN Accounts Acc ON T.FromAccountID = Acc.AccountID OR T.ToAccountID = Acc.AccountID 
                                         WHERE Acc.ClientID = Clients.ClientID
                                       ) AS [Last Transaction Date],

                                      ISNULL(Currencies.CurrencyCode, 'USD') AS [Currency]
                                  FROM Accounts AS Acc
                                  INNER JOIN Clients ON Acc.ClientID = Clients.ClientID
                                  INNER JOIN Persons AS P ON Clients.PersonID = P.PersonID
                                  LEFT JOIN AccountTypes ON Acc.AccountTypeID = AccountTypes.AccountTypeID
                                  LEFT JOIN Currencies ON Acc.CurrencyID = Currencies.CurrencyID;";

                using (SqlCommand Command = new SqlCommand(query, Connection))

                {

                    try

                    {
                        Connection.Open();

                        using (SqlDataReader Reader = Command.ExecuteReader())

                        {
                            if (Reader.HasRows)

                            {
                                dt.Load(Reader);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                }

            }

            return dt;

        }

        public static DataTable GetAccountDetailsByAccountNumber(string AccountNumber, ref string ErrorMessage)
        {
            DataTable dt = new DataTable();

            using (SqlConnection Connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT 
                              ISNULL(Acc.Balance, 0.00) AS [Current Balance (USD)],                                                 
                              CASE 
                                  WHEN Acc.Status = 1 THEN 'Active'
                                  WHEN Acc.Status = 2 THEN 'Dormant'
                                  WHEN Acc.Status = 3 THEN 'Frozen'
                                  ELSE 'Unknown'
                              END AS [Account Status],
                               (
                                 SELECT MAX(T.TransactionDate) 
                                 FROM Transactions T 
                                 WHERE T.FromAccountID = Acc.AccountID OR T.ToAccountID = Acc.AccountID
                               ) AS [Last Transaction Date],

                              ISNULL(Currencies.CurrencyCode, 'USD') AS [Currency]
                          FROM Accounts AS Acc
                          INNER JOIN Clients ON Acc.ClientID = Clients.ClientID
                          INNER JOIN Persons AS P ON Clients.PersonID = P.PersonID
                          LEFT JOIN AccountTypes ON Acc.AccountTypeID = AccountTypes.AccountTypeID
                          LEFT JOIN Currencies ON Acc.CurrencyID = Currencies.CurrencyID
                          WHERE Acc.AccountNumber = @AccountNumber;";

                using (SqlCommand Command = new SqlCommand(query, Connection))
                {
                   
                    Command.Parameters.AddWithValue("@AccountNumber", AccountNumber);

                    try
                    {
                        Connection.Open();

                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.HasRows)
                            {
                                dt.Load(Reader);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                }
            }

            return dt;
        }
    }
}
