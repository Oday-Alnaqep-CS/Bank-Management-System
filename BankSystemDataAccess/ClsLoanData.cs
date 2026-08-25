using ContactsDataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BankSystemDataAccess.FinancialData
{
    public static partial class ClsLoanData
    {
        

        public static bool GetLoanByID(int loanID, ref int clientID, ref byte loanTypeID,
                                       ref decimal amount, ref decimal interestRate, ref short termMonths,
                                       ref decimal monthlyInstallment, ref DateTime startDate,
                                       ref DateTime endDate, ref byte status, ref string errorMessage)
        {

            bool isFound = false;


            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = @"SELECT ClientID, LoanTypeID, Amount, InterestRate, TermMonths, 
                                    MonthlyInstallment, StartDate, EndDate, Status 
                             FROM Loans WHERE LoanID = @LoanID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LoanID", loanID);

                    try
                    {

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                clientID = (int)reader["ClientID"];
                                loanTypeID = (byte)reader["LoanTypeID"];
                                amount = (decimal)reader["Amount"];
                                interestRate = (decimal)reader["InterestRate"];
                                termMonths = (short)reader["TermMonths"];
                                monthlyInstallment = (decimal)reader["MonthlyInstallment"];
                                startDate = (DateTime)reader["StartDate"];
                                endDate = (DateTime)reader["EndDate"];
                                status = (byte)reader["Status"];
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


        

        public static bool IsLoanExist(int loanID, ref string errorMessage)
        {

            bool isFound = false;


            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = "SELECT Found=1 FROM Loans WHERE LoanID = @LoanID;";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LoanID", loanID);

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