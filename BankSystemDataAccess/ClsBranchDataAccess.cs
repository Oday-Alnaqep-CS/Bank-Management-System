using ContactsDataAccessLayer;
using System.Data.SqlClient;
using System;
using System.Data;


namespace BranchDataAccess.EntitiesData
{
    public static class clsBranchDataAccess
    {

        public static bool GetBranchInfoByID(int BranchID, ref string branchName, ref string address, 
                                      ref string phone, ref int cityID, ref string ErrorMessage)

        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                string query = @"Select * FROM Branches 
                                WHERE BranchID = @BranchID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BranchID", BranchID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {

                                isFound = true;
                                branchName = (string)reader["BranchName"];
                                address = reader["Address"] != DBNull.Value ? (string)reader["Address"] : string.Empty;
                                phone = reader["Phone"] != DBNull.Value ? (string)reader["Phone"] : string.Empty;
                                cityID = (int)reader["CityID"];

                            }

                        }
                    }
                    catch (Exception ex)
                    {

                        ErrorMessage = ex.Message;
                        isFound = false;
                    }
                }
            }

            return isFound;
        }

        public static int AddNewBranch(string branchName, string address, string phone, int cityID, ref string ErrorMessage)


        {
            int branchID = -1;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO Branches (BranchName, Address, Phone, CityID)
                                VALUES (@BranchName, @Address, @Phone, @CityID);
                                SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BranchName", branchName);
                    command.Parameters.AddWithValue("@Address", (object)address ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Phone", (object)phone ?? DBNull.Value);
                    command.Parameters.AddWithValue("@CityID", cityID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            branchID = insertedID;
                        }
                    }
                    catch (Exception ex)
                    {

                        ErrorMessage = ex.Message;

                    }
                }
            }

            return branchID;
        }

        public static bool UpdateBranch(int branchID, string branchName, string address, string phone, int cityID,ref string ErrorMessage)


        {

            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = @"UPDATE Branches
                                SET BranchName = @BranchName,
                                    Address = @Address,
                                    Phone = @Phone,
                                    CityID = @CityID
                                WHERE BranchID = @BranchID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@BranchID", branchID);
                    command.Parameters.AddWithValue("@BranchName", branchName);
                    command.Parameters.AddWithValue("@Address", (object)address ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Phone", (object)phone ?? DBNull.Value);
                    command.Parameters.AddWithValue("@CityID", cityID);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                        ErrorMessage = ex.Message;
                        return false;

                    }
                }
            }

            return rowsAffected > 0;
        }

        public static bool DeleteBranch(int branchID, ref string ErrorMessage)

        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                string query = @"DELETE FROM Branches WHERE BranchID = @BranchID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BranchID", branchID);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {

                        ErrorMessage = ex.Message;
                        return false;

                    }
                }
            }

            return rowsAffected > 0;


        }

        public static DataTable GetAllBranches(ref string ErrorMessage)


        {

            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = @"SELECT  * FROM  vw_Branches ORDER BY vw_Branches DESC;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
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

        public static DataTable GetBranchesByCityID(int CityID ,ref string ErrorMessage)


        {

            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = @"SELECT BranchID, BranchName FROM Branches WHERE CityID = @CityID ORDER BY BranchName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@CityID", CityID);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
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

        public static DataTable GetBrancheByUserID(string UserID ,ref string ErrorMessage)


        {

            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = @"SELECT BranchName FROM Branches WHERE UserID = @UserID ORDER BY BranchName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
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

        public static int GetBranchIDByCityID(int CityID, ref string ErrorMessage)
        {
            int branchID = -1; 

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                
                string query = @"SELECT BranchID FROM Branches WHERE CityID = @CityID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CityID", CityID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar(); 

                        if (result != null && int.TryParse(result.ToString(), out int parsedBranchID))
                        {
                            branchID = parsedBranchID;
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                }
            }

            return branchID;
        }

        public static bool IsBranchExist(int branchID, ref string ErrorMessage)


        {

            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = @"SELECT 1 FROM Branches WHERE BranchID = @BranchID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BranchID", branchID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        isFound = (result != null);
                    }
                    catch (Exception ex)
                    {

                        ErrorMessage = ex.Message;
                        isFound = false;


                    }
                }
            }

            return isFound;
        }



    }
}