using ContactsDataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BankSystemDataAccess.FinancialData
{
    public static partial class ClsCardData
    {
        
        public static int AddNewCard(int accountID, string cardNumber, byte cardTypeID,
                                    string pin, string cvv, DateTime expirationDate,
                                    bool isActive, ref string errorMessage)
        {

            int cardID = -1;



            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {


                string query = @"INSERT INTO Cards (AccountID, CardNumber, CardTypeID, PIN, CVV, ExpirationDate, IsActive, CreatedDate)
                             VALUES (@AccountID, @CardNumber, @CardTypeID, @PIN, @CVV, @ExpirationDate, @IsActive, GETDATE());
                             SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@AccountID", accountID);
                    command.Parameters.AddWithValue("@CardNumber", cardNumber);
                    command.Parameters.AddWithValue("@CardTypeID", cardTypeID);
                    command.Parameters.AddWithValue("@PIN", pin);
                    command.Parameters.AddWithValue("@CVV", cvv);
                    command.Parameters.AddWithValue("@ExpirationDate", expirationDate);
                    command.Parameters.AddWithValue("@IsActive", isActive);

                    try
                    {

                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            cardID = insertedID;
                        }

                    }

                    catch (Exception ex)
                    {

                        errorMessage = ex.Message;
                    }

                }
            }

            return cardID;

        }


        public static bool ChangePIN(int cardID, string newPIN, ref string errorMessage)


        {

            int rowsAffected = 0;


            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = "UPDATE Cards SET PIN = @PIN WHERE CardID = @CardID;";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CardID", cardID);
                    command.Parameters.AddWithValue("@PIN", newPIN);


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



        public static bool SetCardActiveStatus(int cardID, bool isActive, ref string errorMessage)


        {

            int rowsAffected = 0;


            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = "UPDATE Cards SET IsActive = @IsActive WHERE CardID = @CardID;";



                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@CardID", cardID);
                    command.Parameters.AddWithValue("@IsActive", isActive);

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