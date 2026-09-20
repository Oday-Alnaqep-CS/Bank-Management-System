using ContactsDataAccessLayer;
using System.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace BankSystemDataAccess
{
    public static class ClsRateDataAccess
    {


        public static DataTable GetAllCurrencies(ref string ErrorMessage)

        {
            DataTable dt = new DataTable();

            using (SqlConnection Connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))

            {
                string Query = @"SELECT 
                                    C.CurrencyID AS [ID], 
                                    C.FlagPath AS [Flag], 
                                    C.CurrencyName AS [Currency], 
                                    C.CurrencyCode AS [Code],
                                    C.CurrencySymbol AS [Symbol],
                                    C.ExchangeRate AS [Exchange Rate], 
                                    CASE 
                                        WHEN C.IsActive = 1 THEN 'Active' 
                                        ELSE 'Inactive' 
                                    END AS [Status],
                                    CR.NewBuyRate AS [Buy Rate], 
                                    CR.NewSellRate AS [Sell Rate],
                                    CR.ChangedByUserID AS [Changed By User ID],
                                    CR.ChangedDate AS [Changed Date],
                                    CR.ChangeReason AS [Change Reason] 
                                 FROM Currencies C
                                 LEFT JOIN CurrencyRateHistory CR ON CR.CurrencyID = C.CurrencyID";

                using (SqlCommand Command = new SqlCommand(Query, Connection))

                {

                    try
                    {
                        Connection.Open();

                        using(SqlDataReader reader = Command.ExecuteReader())
                        {

                            if (reader.HasRows)
                            {
                                dt.Load(reader);
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
        public static DataTable GetAllCurrenciesName(ref string ErrorMessage)

        {
            DataTable dt = new DataTable();

            using (SqlConnection Connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))

            {
                string Query = @"SELECT 
                                    C.CurrencyID AS [Currency ID], 
                                    C.CurrencyName AS [Currency Name]
                                  
                                 FROM Currencies C ";
                                

                using (SqlCommand Command = new SqlCommand(Query, Connection))

                {

                    try
                    {
                        Connection.Open();

                        using(SqlDataReader reader = Command.ExecuteReader())
                        {

                            if (reader.HasRows)
                            {
                                dt.Load(reader);
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
        public static int GetCountOfAllCurrencies(ref string ErrorMessage)
        {
            int count = 0;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT COUNT(*) FROM Currencies";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        // ExecuteScalar returns the first column of the first row
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int parsedCount))
                        {
                            count = parsedCount;
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                }
            }

            return count;
        }
        public static int GetCountOfAllActiveCurrencies(ref string ErrorMessage)
        {
            int count = 0;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT COUNT(*) FROM Currencies C where C.IsActive = 1";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        // ExecuteScalar returns the first column of the first row
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int parsedCount))
                        {
                            count = parsedCount;
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                }
            }

            return count;
        }
        public static bool UpdateCurrency(int currencyID, string currencyName, string currencySymbol, decimal exchangeRate, bool isActive, string flagPath, string changedByUserID, string changeReason, ref string errorMessage)
        {
            bool isUpdated = false;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                

                string query = @"UPDATE Currencies 
                         SET CurrencyName = @CurrencyName,
                             CurrencySymbol = @CurrencySymbol,
                             ExchangeRate = @ExchangeRate,
                             IsActive = @IsActive,
                             FlagPath = @FlagPath
                         WHERE CurrencyID = @CurrencyID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CurrencyID", currencyID);
                    command.Parameters.AddWithValue("@CurrencyName", currencyName);
                    command.Parameters.AddWithValue("@CurrencySymbol", currencySymbol);
                    command.Parameters.AddWithValue("@ExchangeRate", exchangeRate);
                    command.Parameters.AddWithValue("@IsActive", isActive);
                    command.Parameters.AddWithValue("@FlagPath", string.IsNullOrEmpty(flagPath) ? (object)DBNull.Value : flagPath);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            isUpdated = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                        isUpdated = false;
                    }
                }
            }

            return isUpdated;
        }
        public static bool UpdateCurrencyRate(int currencyID, decimal NewSellRate, decimal NewBuyRate, decimal ExchangeRate, string ChangedByUserID, string ChangeReason, ref string errorMessage)
        {
            bool isUpdated = false;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                
                string query = @"
                                  DECLARE @OldBuy DECIMAL(18,6) = 0, @OldSell DECIMAL(18,6) = 0;
                                  
                                
                                  SELECT TOP 1 @OldBuy = NewBuyRate, @OldSell = NewSellRate 
                                  FROM CurrencyRateHistory 
                                  WHERE CurrencyID = @CurrencyID 
                                  ORDER BY RateHistoryID DESC;
                           
                                  
                                  UPDATE Currencies 
                                  SET ExchangeRate = @ExchangeRate
                                  WHERE CurrencyID = @CurrencyID;                                                            
                           
                                  
                                  INSERT INTO CurrencyRateHistory 
                                  (CurrencyID, OldBuyRate, OldSellRate, NewBuyRate, NewSellRate,  ChangedByUserID, ChangedDate, ChangeReason)
                                  VALUES 
                                  (@CurrencyID, @OldBuy, @OldSell, @NewBuyRate, @NewSellRate,   @ChangedByUserID, GETDATE(), @ChangeReason);";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CurrencyID", currencyID);
                    command.Parameters.AddWithValue("@NewSellRate", NewSellRate);
                    command.Parameters.AddWithValue("@NewBuyRate", NewBuyRate);
                    command.Parameters.AddWithValue("@ExchangeRate", ExchangeRate);
                    command.Parameters.AddWithValue("@ChangedByUserID", string.IsNullOrEmpty(ChangedByUserID) ? (object)DBNull.Value : ChangedByUserID);
                    command.Parameters.AddWithValue("@ChangeReason", string.IsNullOrEmpty(ChangeReason) ? (object)DBNull.Value : ChangeReason);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            isUpdated = true;
                        }
                        else
                        {
                            errorMessage = "لم يتم العثور على العملة المطلوبة أو لم يحدث أي تغيير.";
                        }
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                        isUpdated = false;
                    }
                }
            }

            return isUpdated;
        }
        public static bool UpdateExchangeRate(int currencyID, decimal newExchangeRate, string changedByUserID, string changeReason, ref string errorMessage)
        {
            bool isUpdated = false;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
               
                string query = @"UPDATE Currencies 
                         SET ExchangeRate = @ExchangeRate
                         WHERE CurrencyID = @CurrencyID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CurrencyID", currencyID);
                    command.Parameters.AddWithValue("@ExchangeRate", newExchangeRate);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            isUpdated = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                        isUpdated = false;
                    }
                }
            }

            return isUpdated;
        }

        public static bool FindByCurrencyID(int currencyID,ref string currencyCode,ref string currencyName,ref string currencySymbol,ref decimal exchangeRate,ref bool isActive,
                                            ref string flagPath,ref decimal currentBuyRate,ref decimal currentSellRate,ref string changedByUserID,ref string changeReason)
        {

            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                
                string query = @"
                                  SELECT c.*, 
                                         (SELECT TOP 1 NewBuyRate FROM CurrencyRateHistory WHERE CurrencyID = c.CurrencyID ORDER BY RateHistoryID DESC) AS LatestBuyRate,
                                         (SELECT TOP 1 NewSellRate FROM CurrencyRateHistory WHERE CurrencyID = c.CurrencyID ORDER BY RateHistoryID DESC) AS LatestSellRate,
                                         (SELECT TOP 1 ChangeReason FROM CurrencyRateHistory WHERE CurrencyID = c.CurrencyID ORDER BY RateHistoryID DESC) AS LastReason,
                                         (SELECT TOP 1 ChangedByUserID FROM CurrencyRateHistory WHERE CurrencyID = c.CurrencyID ORDER BY RateHistoryID DESC) AS LastUser
                                  FROM Currencies c 
                                  WHERE c.CurrencyID = @CurrencyID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CurrencyID", currencyID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                currencyCode = reader["CurrencyCode"] != DBNull.Value ? reader["CurrencyCode"].ToString() : string.Empty;
                                currencyName = reader["CurrencyName"] != DBNull.Value ? reader["CurrencyName"].ToString() : string.Empty;
                                currencySymbol = reader["CurrencySymbol"] != DBNull.Value ? reader["CurrencySymbol"].ToString() : string.Empty;
                                exchangeRate = reader["ExchangeRate"] != DBNull.Value ? Convert.ToDecimal(reader["ExchangeRate"]) : 1.0000m;
                                isActive = reader["IsActive"] != DBNull.Value ? Convert.ToBoolean(reader["IsActive"]) : true;
                                flagPath = reader["FlagPath"] != DBNull.Value ? reader["FlagPath"].ToString() : string.Empty;

                                
                                currentBuyRate = reader["LatestBuyRate"] != DBNull.Value ? Convert.ToDecimal(reader["LatestBuyRate"]) : 0.000000m;
                                currentSellRate = reader["LatestSellRate"] != DBNull.Value ? Convert.ToDecimal(reader["LatestSellRate"]) : 0.000000m;

                                 
                                changedByUserID = reader["LastUser"] != DBNull.Value ? reader["LastUser"].ToString() : string.Empty;
                                changeReason = reader["LastReason"] != DBNull.Value ? reader["LastReason"].ToString() : string.Empty;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        isFound = false;
                    }
                }
            }

            return isFound;
        }

    }
}
