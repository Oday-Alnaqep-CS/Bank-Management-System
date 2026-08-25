using ContactsDataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BankSystemDataAccess.EntitiesData
{
    public class ClsPermissionDataAccess
    {
        public static bool GetPermissionByID(int permissionID, ref string permissionName, ref string description, ref string errorMessage)


        {


            bool isFound = false;


            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {


                string query = @"SELECT * FROM Permissions WHERE PermissionID = @PermissionID;";

                using (SqlCommand command = new SqlCommand(query, connection))

                {

                    command.Parameters.AddWithValue("@PermissionID", permissionID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                isFound = true;
                                permissionName = reader["PermissionName"].ToString();
                                description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : "";
                            }
                        }

                    }

                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                        isFound = false;
                    }
                }

            }


            return isFound;
        }



        public static bool GetPermissionByName(string permissionName, ref int permissionID, ref string description, ref string errorMessage)


        {

            bool isFound = false;


            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = @"SELECT * FROM Permissions WHERE PermissionName = @PermissionName;";

                
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@PermissionName", permissionName);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                permissionID = (int)reader["PermissionID"];
                                description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : "";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                        isFound = false;
                    }

                }

            }


            return isFound;
        }



        public static int AddNewPermission(string permissionName, string description, ref string errorMessage)
        {


            int permissionID = -1;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO Permissions (PermissionName, Description)
                                 VALUES (@PermissionName, @Description);
                                 SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {


                    command.Parameters.AddWithValue("@PermissionName", permissionName);

                    if (string.IsNullOrEmpty(description))
                        command.Parameters.AddWithValue("@Description", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@Description", description);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            permissionID = insertedID;
                        }
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                    }
                }
            }

            return permissionID;
        }

        public static bool UpdatePermission(int permissionID, string permissionName, string description, ref string errorMessage)


        {
            int rowsAffected = 0;


            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                string query = @"UPDATE Permissions
                                 SET PermissionName = @PermissionName,
                                     Description = @Description
                                 WHERE PermissionID = @PermissionID;";



                using (SqlCommand command = new SqlCommand(query, connection))
                {


                    command.Parameters.AddWithValue("@PermissionID", permissionID);
                    command.Parameters.AddWithValue("@PermissionName", permissionName);


                    if (string.IsNullOrEmpty(description))
                        command.Parameters.AddWithValue("@Description", DBNull.Value);

                    else
                        command.Parameters.AddWithValue("@Description", description);


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

        public static bool DeletePermission(int permissionID, ref string errorMessage)


        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))


            {
                string query = @"DELETE FROM Permissions WHERE PermissionID = @PermissionID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
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

        public static bool IsPermissionExist(int permissionID, ref string errorMessage)
        {
            bool isExist = false;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT 1 FROM Permissions WHERE PermissionID = @PermissionID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PermissionID", permissionID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            isExist = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                    }
                }
            }

            return isExist;
        }

        public static bool IsPermissionExistByName(string permissionName, ref string errorMessage)
        {
            bool isExist = false;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT 1 FROM Permissions WHERE PermissionName = @PermissionName;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PermissionName", permissionName);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            isExist = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                    }
                }
            }

            return isExist;
        }

        public static DataTable GetAllPermissions(ref string errorMessage)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT PermissionID, PermissionName, Description FROM Permissions;";

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
                        errorMessage = ex.Message;
                    }
                }
            }

            return dt;
        }
    }
}