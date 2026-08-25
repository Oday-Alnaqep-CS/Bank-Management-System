using System;
using System.Data;
using System.Data.SqlClient;
using BankSystemDataAccess;

namespace BankSystemBuisniseLayer
{
    public  class ClsGetResults

    {
      

      

       

      

        public static int GetTodayTransactions(out string errorMessage)
        {
            string query = @"SELECT COUNT(*) FROM Transactions 
                             WHERE TransactionDate >= CAST(GETDATE() AS DATE) 
                             AND TransactionDate < DATEADD(DAY, 1, CAST(GETDATE() AS DATE))";
            return ClsGetResult.ExecuteScalar<int>(query, out errorMessage);
        }

       

        public static string GetCurrentBranchName(int branchId, out string errorMessage)
        {
            string query = "SELECT BranchName FROM Branches WHERE BranchID = @BranchID";
            SqlParameter[] parameters =
            {
                new SqlParameter("@BranchID", SqlDbType.Int) { Value = branchId }
            };

            return ClsGetResult.ExecuteScalar<string>(query, parameters, out errorMessage, "N/A");
        }


        public static bool HasPermission(int roleID, bool isAdmin, string permissionName, out string errorMessage)
        {
            errorMessage = string.Empty;


            if (isAdmin)
                return true;



            string query = @"SELECT CASE WHEN EXISTS (
                        SELECT 1 
                        FROM RolePermissions RP
                        INNER JOIN Permissions P ON RP.PermissionID = P.PermissionID
                        WHERE RP.RoleID = @RoleID AND P.PermissionName = @PermissionName
                    ) THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END;";

            SqlParameter[] parameters =
            {
                      new SqlParameter("@RoleID", SqlDbType.Int) { Value = roleID },
                      new SqlParameter("@PermissionName", SqlDbType.NVarChar, 100) { Value = permissionName }
            };

            return ClsGetResult.ExecuteScalar<bool>(query, parameters, out errorMessage);
        }



        public static T GetResultsFrom<T>(string query, out string errorMessage)
        {
            return ClsGetResult.ExecuteScalar<T>(query, out errorMessage);
        }

        public static T GetResultsFrom<T>(string query, SqlParameter[] parameters, out string errorMessage)
        {
            return ClsGetResult.ExecuteScalar<T>(query, parameters, out errorMessage);
        }

      
    }
}