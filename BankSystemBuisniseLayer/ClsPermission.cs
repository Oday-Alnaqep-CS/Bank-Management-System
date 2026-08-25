using System;
using System.Data;
using BankSystemDataAccess.EntitiesData;

namespace BankSystemBusinessLayer
{
    public class ClsPermission
    {
        public enum enMode { AddNew = 1, Update = 2 }
        public enMode Mode = enMode.AddNew;

        public int PermissionID { get; set; }
        public string PermissionName { get; set; }
        public string Description { get; set; }
        public string ErrorMessage { get; set; }

        public ClsPermission()
        {
            this.PermissionID = -1;
            this.PermissionName = "";
            this.Description = "";

            Mode = enMode.AddNew;
        }

        private ClsPermission(int permissionID, string permissionName, string description)
        {
            this.PermissionID = permissionID;
            this.PermissionName = permissionName;
            this.Description = description;

            Mode = enMode.Update;
        }

        private bool _AddNewPermission()
        {
            string errorMessage = "";

            this.PermissionID = ClsPermissionDataAccess.AddNewPermission(
                this.PermissionName,
                this.Description,
                ref errorMessage
            );

            this.ErrorMessage = errorMessage;

            return (this.PermissionID != -1 && this.PermissionID != 0);
        }

        private bool _UpdatePermission()
        {
            string errorMessage = "";

            bool isUpdated = ClsPermissionDataAccess.UpdatePermission(
                this.PermissionID,
                this.PermissionName,
                this.Description,
                ref errorMessage
            );

            this.ErrorMessage = errorMessage;

            return isUpdated;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPermission())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdatePermission();

                default:
                    return false;
            }
        }

        public static ClsPermission Find(int permissionID, ref string errorMessage)
        {
            string permissionName = "";
            string description = "";

            if (ClsPermissionDataAccess.GetPermissionByID(permissionID, ref permissionName, ref description, ref errorMessage))
            {
                return new ClsPermission(permissionID, permissionName, description);
            }

            return null;
        }

        public static ClsPermission FindByName(string permissionName, ref string errorMessage)
        {
            int permissionID = -1;
            string description = "";

            if (ClsPermissionDataAccess.GetPermissionByName(permissionName, ref permissionID, ref description, ref errorMessage))
            {
                return new ClsPermission(permissionID, permissionName, description);
            }

            return null;
        }

        public static bool DeletePermission(int permissionID, ref string errorMessage)
        {
            return ClsPermissionDataAccess.DeletePermission(permissionID, ref errorMessage);
        }

        public static bool IsPermissionExist(int permissionID, ref string errorMessage)
        {
            return ClsPermissionDataAccess.IsPermissionExist(permissionID, ref errorMessage);
        }

        public static bool IsPermissionExist(string permissionName, ref string errorMessage)
        {
            return ClsPermissionDataAccess.IsPermissionExistByName(permissionName, ref errorMessage);
        }

        public static DataTable GetAllPermissions(ref string errorMessage)
        {
            return ClsPermissionDataAccess.GetAllPermissions(ref errorMessage);
        }
    }
}