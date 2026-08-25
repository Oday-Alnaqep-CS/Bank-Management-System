using ContactsDataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BankSystemDataAccess.FinancialData
{
    public static partial class ClsCardData
    {
         
        public static bool GetCardByID(int cardID, ref int accountID, ref string cardNumber,
                                      ref byte cardTypeID, ref string pin, ref string cvv,
                                      ref DateTime expirationDate, ref bool isActive, ref string errorMessage)

        {

            bool isFound = false;



            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = @"SELECT AccountID, CardNumber, CardTypeID, PIN, CVV, ExpirationDate, IsActive 
                             FROM Cards WHERE CardID = @CardID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CardID", cardID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                accountID = (int)reader["AccountID"];
                                cardNumber = (string)reader["CardNumber"];
                                cardTypeID = (byte)reader["CardTypeID"];
                                pin = (string)reader["PIN"];
                                cvv = (string)reader["CVV"];
                                expirationDate = (DateTime)reader["ExpirationDate"];
                                isActive = (bool)reader["IsActive"];
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


        public static bool GetCardByCardNumber(string cardNumber, ref int cardID, ref int accountID,
                                               ref byte cardTypeID, ref string pin, ref string cvv,
                                               ref DateTime expirationDate, ref bool isActive, ref string errorMessage)
        {

            bool isFound = false;
            

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {


                string query = @"SELECT CardID, AccountID, CardTypeID, PIN, CVV, ExpirationDate, IsActive 
                             FROM Cards WHERE CardNumber = @CardNumber;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CardNumber", cardNumber);

                    try
                    {

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                isFound = true;
                                cardID = (int)reader["CardID"];
                                accountID = (int)reader["AccountID"];
                                cardTypeID = (byte)reader["CardTypeID"];
                                pin = (string)reader["PIN"];
                                cvv = (string)reader["CVV"];
                                expirationDate = (DateTime)reader["ExpirationDate"];
                                isActive = (bool)reader["IsActive"];
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
    }
}