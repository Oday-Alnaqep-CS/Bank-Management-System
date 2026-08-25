using ContactsDataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BankSystemDataAccess.FinancialData
{
	public static partial class ClsAccountData
	{
		public static int AddNewAccount(string accountNumber, string iban, int clientID,
										int accountTypeID, int branchID, int currencyID,
										decimal balance, byte status, ref string errorMessage)


		{

			int accountID = -1;


			using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
			{

				string query = @"INSERT INTO Accounts (AccountNumber, IBAN, ClientID, AccountTypeID, BranchID, CurrencyID, Balance, Status, CreatedDate)
                             VALUES (@AccountNumber, @IBAN, @ClientID, @AccountTypeID, @BranchID, @CurrencyID, @Balance, @Status, GETDATE());
                             SELECT SCOPE_IDENTITY();";


				using (SqlCommand command = new SqlCommand(query, connection))
				{

					command.Parameters.AddWithValue("@AccountNumber", accountNumber);
					command.Parameters.AddWithValue("@IBAN", string.IsNullOrEmpty(iban) ? DBNull.Value : (object)iban);
					command.Parameters.AddWithValue("@ClientID", clientID);
					command.Parameters.AddWithValue("@AccountTypeID", accountTypeID);
					command.Parameters.AddWithValue("@BranchID", branchID);
					command.Parameters.AddWithValue("@CurrencyID", currencyID);
					command.Parameters.AddWithValue("@Balance", balance);
					command.Parameters.AddWithValue("@Status", status);

					try
					{

						connection.Open();
						object result = command.ExecuteScalar();
						if (result != null && int.TryParse(result.ToString(), out int insertedID))
						{

							accountID = insertedID;

						}

					}
					catch (Exception ex)
					{

						errorMessage = ex.Message;
					}

				}

			}

			return accountID;
		}


		public static bool UpdateAccountInfo(int accountID, int accountTypeID, int branchID,
											 int currencyID, byte status, ref string errorMessage)


		{
			int rowsAffected = 0;


			using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
			{

				string query = @"UPDATE Accounts 
                             SET AccountTypeID = @AccountTypeID, 
                                 BranchID = @BranchID, 
                                 CurrencyID = @CurrencyID, 
                                 Status = @Status 
                             WHERE AccountID = @AccountID;";


				using (SqlCommand command = new SqlCommand(query, connection))
				{

					command.Parameters.AddWithValue("@AccountID", accountID);
					command.Parameters.AddWithValue("@AccountTypeID", accountTypeID);
					command.Parameters.AddWithValue("@BranchID", branchID);
					command.Parameters.AddWithValue("@CurrencyID", currencyID);
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
				return rowsAffected > 0;

			}

		}

		public static bool DeleteAccount(int accountID, ref string errormessage)


		{

			int rowsAffected = 0;

			using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
			{

				string Query = "Delete from Accounts where AccountID =@AccountID;";

				using (SqlCommand command = new SqlCommand(Query, connection))
				{

					command.Parameters.AddWithValue("@AccountID", accountID);

					try
					{
						connection.Open();

						rowsAffected = command.ExecuteNonQuery();

					}
					catch (Exception ex)
					{

						errormessage = ex.Message;
						return false;
					}

				}

				return (rowsAffected > 0);
			}


		}




	}
}