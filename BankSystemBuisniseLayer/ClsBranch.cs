using System;
using System.Data;
using BranchDataAccess.EntitiesData;

namespace BankSystemBuisniseLayer
{
    public class ClsBranch
    {
        public enum enMode { AddNew = 1, Update = 2 }
        public enMode Mode = enMode.AddNew;

        public int BranchID { get; set; }
        public string BranchName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int CityID { get; set; }
        public string ErrorMessage { get; set; }

        public ClsBranch()
        {
            this.BranchID = -1;
            this.BranchName = "";
            this.Address = "";
            this.Phone = "";
            this.CityID = -1;

            Mode = enMode.AddNew;
        }

        public ClsBranch(int branchID, string branchName, string address, string phone, int cityID)
        {
            this.BranchID = branchID;
            this.BranchName = branchName;
            this.Address = address;
            this.Phone = phone;
            this.CityID = cityID;

            Mode = enMode.Update;
        }

        private bool _AddNewBranch()
        {
            string errorMessage = "";

            this.BranchID = clsBranchDataAccess.AddNewBranch(this.BranchName, this.Address, this.Phone, this.CityID, ref errorMessage);

            this.ErrorMessage = errorMessage;

            return (this.BranchID != -1 && this.BranchID != 0);
        }

        private bool _UpdateBranch()
        {
            string errorMessage = "";

            bool isUpdated = clsBranchDataAccess.UpdateBranch(this.BranchID, this.BranchName, this.Address, this.Phone, this.CityID, ref errorMessage);

            this.ErrorMessage = errorMessage;

            return isUpdated;
        }

        public bool Save()
        {
            bool isSuccessed = false;

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewBranch())
                    {
                        Mode = enMode.Update;
                        isSuccessed = true;
                    }
                    else
                    {
                        isSuccessed = false;
                    }
                    break;

                case enMode.Update:
                    return _UpdateBranch();
            }

            return isSuccessed;
        }

        public static ClsBranch Find(int branchID, ref string errorMessage)
        {
            string branchName = "", address = "", phone = "";
            int cityID = -1;

            if (clsBranchDataAccess.GetBranchInfoByID(branchID, ref branchName, ref address, ref phone, ref cityID, ref errorMessage))
            {
                return new ClsBranch(branchID, branchName, address, phone, cityID);
            }

            return null;
        }

        public static bool DeleteBranch(int branchID, ref string errorMessage)
        {
            return clsBranchDataAccess.DeleteBranch(branchID, ref errorMessage);
        }

        public static bool IsBranchExist(int branchID, ref string errorMessage)
        {
            return clsBranchDataAccess.IsBranchExist(branchID, ref errorMessage);
        }

        public static DataTable GetAllBranches(ref string errorMessage)
        {
            return clsBranchDataAccess.GetAllBranches(ref errorMessage);
        }

        public static DataTable GetBranchesByCityID(int CityID, ref string ErrorMessage)
        {
            return clsBranchDataAccess.GetBranchesByCityID(CityID, ref ErrorMessage);
        }

        public static DataTable GetCurrentBranchName(string UserID, ref string ErrorMessage)
        {
            return clsBranchDataAccess.GetBrancheByUserID(UserID, ref ErrorMessage);
        }

        public static int GetBranchIDByCityID(int CityID, ref string ErrorMessage)
        {
            return clsBranchDataAccess.GetBranchIDByCityID(CityID, ref ErrorMessage);
        }
    }
}