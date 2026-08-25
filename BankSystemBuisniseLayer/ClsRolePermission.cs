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

        public static bool DeletePermissionsByRoleID(int roleID, ref string errorMessage)
        {
            return ClsRolePermissionDataAccess.DeletePermissionsByRoleID(roleID, ref errorMessage);
        }

        public static DataTable GetPermissionsByRoleID(int roleID, ref string errorMessage)
        {
            return ClsRolePermissionDataAccess.GetPermissionsByRoleID(roleID, ref errorMessage);
        }

        public static bool DoesRoleHavePermission(int roleID, string permissionName, ref string errorMessage)
        {
            return ClsRolePermissionDataAccess.DoesRoleHavePermission(roleID, permissionName, ref errorMessage);
        }
    }
}