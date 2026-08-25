using ContactsDataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BankSystemDataAccess.FinancialData
{
    public static partial class ClsLoanData
    {
       

        public static int AddNewLoan(int clientID, byte loanTypeID, decimal amount,
                                    decimal interestRate, short termMonths, decimal monthlyInstallment,
                                    DateTime startDate, DateTime endDate, byte status, ref string errorMessage)


        {

            int loanID = -1;


            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {


                string query = @"INSERT INTO Loans 
                             (ClientID, LoanTypeID, Amount, InterestRate, TermMonths, MonthlyInstallment, StartDate, EndDate, Status, CreatedDate)
                             VALUES 
                             (@ClientID, @LoanTypeID, @Amount, @InterestRate, @TermMonths, @MonthlyInstallment, @StartDate, @EndDate, @Status, GETDATE());
                             SELECT SCOPE_IDENTITY();";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClientID", clientID);
                    command.Parameters.AddWithValue("@LoanTypeID", loanTypeID);
                    command.Parameters.AddWithValue("@Amount", amount);
                    command.Parameters.AddWithValue("@InterestRate", interestRate);
                    command.Parameters.AddWithValue("@TermMonths", termMonths);
                    command.Parameters.AddWithValue("@MonthlyInstallment", monthlyInstallment);
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);
                    command.Parameters.AddWithValue("@Status", status);

                    try
                    {

                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {

                            loanID = insertedID;

                        }

                    }

                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                    }

                }
            }

            return loanID;

        }


       

        public static bool UpdateLoanStatus(int loanID, byte status, ref string errorMessage)
        {

            int rowsAffected = 0;


            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {


                string query = "UPDATE Loans SET Status = @Status WHERE LoanID = @LoanID;";


                using (SqlCommand command = new SqlCommand(query, connection))
                {


                    command.Parameters.AddWithValue("@LoanID", loanID);
                    command.Parameters.AddWithValue("@Status", status);

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

       
        public static bool DeleteLoan(int loanID, ref string errorMessage)
        {

            int rowsAffected = 0;


            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = "DELETE FROM Loans WHERE LoanID = @LoanID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LoanID", loanID);

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