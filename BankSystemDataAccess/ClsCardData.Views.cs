using ContactsDataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BankSystemDataAccess.FinancialData
{
    public static partial class ClsCardData
    {

        public static DataTable GetCardsView(ref string errorMessage)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = "SELECT * FROM vw_Cards ORDER BY CardID DESC;";

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


        public static DataTable GetCardsByAccountID(int accountID, ref string errorMessage)
        {


            DataTable dt = new DataTable();


            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = "SELECT * FROM Cards WHERE AccountID = @AccountID;";

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
    }
}