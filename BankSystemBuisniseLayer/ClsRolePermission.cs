using System;
using System.Data;
using BankSystemDataAccess.EntitiesData;

namespace BankSystemBuisniseLayer
{
    public class ClsRolePermission
    {
        public static bool AddRolePermission(int roleID, int permissionID, ref string errorMessage)

        {
            return ClsRolePermissionDataAccess.AddRolePermission(roleID, permissionID, ref errorMessage);
        }

        public static DataTable GetAllUserRoles(ref string ErrorMessage)

        {
            return ClsRolePermissionDataAccess.GetAllRolePermissions(ref ErrorMessage);
        }

        public static bool DoesRoleHavePermission(int roleID, string permissionName, ref string errorMessage)

        {
            return ClsRolePermissionDataAccess.DoesRoleHavePermission(roleID, permissionName, ref errorMessage);
        }
    }
}