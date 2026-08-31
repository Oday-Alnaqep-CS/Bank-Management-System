using BankSystemDataAccess;
using BankSystemDataAccess.EntitiesData;
using System;
using System.Data;

namespace BankSystemBuisniseLayer
{
    public class ClsUser
    {
        public enum enMode { AddNew = 1, Update = 2 }
        public enMode Mode = enMode.AddNew;

        public int UserID { get; set; }
        public string UserName { get; set; }
        public int PersonID { get; set; }
        public int DepartmentID { get; set; }
        public int BranchID { get; set; }
        public string JobTitle { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public byte Status { get; set; }
        public int Permissions { get; set; }
        public string ErrorMessage { get; set; }
        public ClsPerson PersonInfo { get; set; }
        public static object CurrentUser { get; set; }

        public ClsUser()
        {
            this.UserID = -1;
            this.PersonID = 0;
            this.DepartmentID = 0;
            this.BranchID = 0;
            this.JobTitle = "";
            this.HireDate = DateTime.Now;
            this.Salary = 0M;
            this.Status = 0;

            Mode = enMode.AddNew;
        }

        public ClsUser(int userID, int personID, int departmentID, int branchID,
                       string jobTitle, DateTime hireDate, decimal salary, byte status)
        {
            this.UserID = userID;
            this.PersonID = personID;
            this.DepartmentID = departmentID;
            this.BranchID = branchID;
            this.JobTitle = jobTitle;
            this.HireDate = hireDate;
            this.Salary = salary;
            this.Status = status;

            Mode = enMode.Update;
        }

        private bool _AddNewUser()
        {
            string errorMessage = "";

            this.UserID = ClsUserDataAccess.AddNewUser(this.PersonID, this.DepartmentID, this.BranchID,
                                                       this.JobTitle, this.HireDate, this.Salary,
                                                       this.Status, ref errorMessage);

            this.ErrorMessage = errorMessage;

            return (this.UserID != -1 && this.UserID != 0);
        }

        private bool _UpdateUser()
        {
            string errorMessage = "";

            bool isUpdate = ClsUserDataAccess.UpdateUser(this.UserID, this.PersonID, this.DepartmentID,
                                                         this.BranchID, this.JobTitle, this.HireDate,
                                                         this.Salary, this.Status, ref errorMessage);

            this.ErrorMessage = errorMessage;

            return isUpdate;
        }

        public bool Save()
        {
            bool isSuccessed = false;

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
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
                    return _UpdateUser();
            }

            return isSuccessed;
        }

        public static ClsUser Find(int userID, ref string errorMessage)
        {
            int personID = 0, departmentID = 0, branchID = 0;
            string jobTitle = "";
            DateTime hireDate = DateTime.Now;
            decimal salary = 0M;
            byte status = 0;

            if (ClsUserDataAccess.GetUserByID(userID, ref personID, ref departmentID, ref branchID,
                                             ref jobTitle, ref hireDate, ref salary, ref status, ref errorMessage))
            {
                return new ClsUser(userID, personID, departmentID, branchID, jobTitle, hireDate, salary, status);
            }

            return null;
        }

        public static bool DeleteUser(int userID, ref string errorMessage)
        {
            return ClsUserDataAccess.DeleteUser(userID, ref errorMessage);
        }

        public static DataTable GetAllUsers(ref string errorMessage)
        {
            return ClsUserDataAccess.GetUsersInFo(ref errorMessage);
        }

    
        public static bool IsUserExist(int userID, ref string errorMessage)
        {
            return ClsUserDataAccess.IsUserExistByID(userID, ref errorMessage);
        }

        public static bool IsUserExistByPersonID(int personID, ref string errorMessage)
        {
            return ClsUserDataAccess.IsUserExistByPersonID(personID, ref errorMessage);
        }

        public bool HasPermission(string permissionName)
        {
            string errorMessage = "";
            return ClsUserRoleDataAccess.DoesUserHavePermission(this.UserID, permissionName, ref errorMessage);
        }

        public static int GetCountOfAllUsers(out string errorMessage) =>
          ClsUserDataAccess.GetTotalUsers(out errorMessage);

        public static int GetCountOfActiveUsers(out string errorMessage) =>
                  ClsUserDataAccess.GetTotalActiveUsers(out errorMessage);

        public static int GetCountOfInActiveUsers(out string ErrorMessage) =>
                 ClsUserDataAccess.GetTotalUsers(out ErrorMessage) - ClsUserDataAccess.GetTotalActiveUsers(out ErrorMessage);

        public static int GetCountOfUsersRoles(out string errorMessage) =>
                  ClsUserRoleDataAccess.GetTotalUsersRoles(out errorMessage);

        public static ClsUser FindByUsernameAndPassword(string username, string password, ref string errorMessage)



        {


            int userID = -1, personID = -1, departmentID = -1, branchID = -1;
            string jobTitle = "";
            DateTime hireDate = DateTime.Now;
            decimal salary = 0M;
            byte status = 0;

            if (ClsUserDataAccess.GetUserByUsernameAndPassword(username, password, ref userID, ref personID,
                                                                ref departmentID, ref branchID, ref jobTitle,
                                                                ref hireDate, ref salary, ref status, ref errorMessage))
            {


                ClsPerson personInfo = ClsPerson.Find(personID,ref errorMessage);


                ClsUser user = new ClsUser(userID, personID, departmentID, branchID, jobTitle, hireDate, salary, status);

               
                user.PersonInfo = personInfo;


                return user;


            }

            return null;
        }
    }
}