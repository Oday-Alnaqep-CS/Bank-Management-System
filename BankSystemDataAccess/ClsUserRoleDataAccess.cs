using ContactsDataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BankSystemDataAccess.EntitiesData
{
    public class ClsUserRoleDataAccess
    {
        public static bool AddUserRole(string userID, int roleID, ref string errorMessage)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO UserRoles (UserID, RoleID) 
                                 VALUES (@UserID, @RoleID);";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@RoleID", roleID);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                    }
                }
            }

            return (rowsAffected > 0);
        }

        public static bool DeleteUserRole(string userID, int roleID, ref string errorMessage)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                string query = @"DELETE FROM UserRoles 
                                 WHERE UserID = @UserID AND RoleID = @RoleID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@RoleID", roleID);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                    }
                }
            }

            return (rowsAffected > 0);
        }

        public static bool DeleteAllRolesByUserID(string userID, ref string errorMessage)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                string query = @"DELETE FROM UserRoles WHERE UserID = @UserID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                    }
                }
            }

            return (rowsAffected >= 0);
        }

        public static DataTable GetRolesByUserID(string userID, ref string errorMessage)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT R.RoleID, R.RoleName, R.Description
                                 FROM UserRoles UR
                                 INNER JOIN Roles R ON UR.RoleID = R.RoleID
                                 WHERE UR.UserID = @UserID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID);

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
                        errorMessage = ex.Message;
                    }
                }
            }

            return dt;
        }

        public static bool IsUserInRole(string userID, int roleID, ref string errorMessage)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT 1 FROM UserRoles 
                                 WHERE UserID = @UserID AND RoleID = @RoleID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@RoleID", roleID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            isFound = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                    }
                }
            }

            return isFound;
        }

        public static bool DoesUserHavePermission(string userID, string permissionName, ref string errorMessage)
        {
            bool hasPermission = false;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT 1 
                                 FROM UserRoles UR
                                 INNER JOIN RolePermissions RP ON UR.RoleID = RP.RoleID
                                 INNER JOIN Permissions P ON RP.PermissionID = P.PermissionID
                                 WHERE UR.UserID = @UserID AND P.PermissionName = @PermissionName;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@PermissionName", permissionName);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            hasPermission = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                    }
                }
            }

            return hasPermission;
        }


        public static int GetTotalUsersRoles(out string ErrorMessage)



        {

            int TotalClients = 0;
            ErrorMessage = string.Empty;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))

            {
                string query = "SELECT COUNT(*) FROM Roles";

                using (SqlCommand command = new SqlCommand(query, connection))
                {


                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)


                        {

                            TotalClients = Convert.ToInt32(result);

                        }

                    }
                    catch (Exception ex)
                    {
                        ErrorMessage = ex.Message;
                        System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
                    }
                }
            }

            return TotalClients;
        }

    }
}