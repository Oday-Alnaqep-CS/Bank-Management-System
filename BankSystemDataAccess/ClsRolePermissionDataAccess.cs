using ContactsDataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BankSystemDataAccess.EntitiesData
{
    public class ClsRolePermissionDataAccess
    {
        public static bool AddRolePermission(int roleID, int permissionID, ref string errorMessage)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO RolePermissions (RoleID, PermissionID) 
                                 VALUES (@RoleID, @PermissionID);";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RoleID", roleID);
                    command.Parameters.AddWithValue("@PermissionID", permissionID);

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

            return (rowsAffected > 0);
        }

        public static bool DeleteRolePermission(int roleID, int permissionID, ref string errorMessage)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                string query = @"DELETE FROM RolePermissions 
                                 WHERE RoleID = @RoleID AND PermissionID = @PermissionID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RoleID", roleID);
                    command.Parameters.AddWithValue("@PermissionID", permissionID);

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

            return (rowsAffected > 0);
        }

        public static bool DeletePermissionsByRoleID(int roleID, ref string errorMessage)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                string query = @"DELETE FROM RolePermissions WHERE RoleID = @RoleID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RoleID", roleID);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                        return false; // Explicitly return false on exception
                    }
                }
            }

            return (rowsAffected >= 0);
        }

        public static DataTable GetPermissionsByRoleID(int roleID, ref string errorMessage)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT P.PermissionID, P.PermissionName, P.Description
                                 FROM RolePermissions RP
                                 INNER JOIN Permissions P ON RP.PermissionID = P.PermissionID
                                 WHERE RP.RoleID = @RoleID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RoleID", roleID);

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

        public static bool DoesRoleHavePermission(int roleID, string permissionName, ref string errorMessage)
        {
            bool hasPermission = false;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT 1 
                                 FROM RolePermissions RP
                                 INNER JOIN Permissions P ON RP.PermissionID = P.PermissionID
                                 WHERE RP.RoleID = @RoleID AND P.PermissionName = @PermissionName;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RoleID", roleID);
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

        public static bool DoesRoleHavePermission(int roleID, int permissionID, ref string errorMessage)
        {
            bool hasPermission = false;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT 1 
                                 FROM RolePermissions 
                                 WHERE RoleID = @RoleID AND PermissionID = @PermissionID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RoleID", roleID);
                    command.Parameters.AddWithValue("@PermissionID", permissionID);

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
    }
}