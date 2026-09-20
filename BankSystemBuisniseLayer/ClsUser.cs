using BankSystemDataAccess;
using BankSystemDataAccess.EntitiesData;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Windows;

namespace BankSystemBuisniseLayer
{
    public class  ClsUser
    {
        public enum enMode { AddNew = 1, Update = 2 }
        public enMode Mode = enMode.AddNew;
        public string UserID { get; set; }
        public string UserName { get; set; }
        public int PersonID { get; set; }
        public int BranchID { get; set; }
        public int Permissions { get; set; }
        public int DepartmentID { get; set; }
        public string JobTitle { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public byte Status { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public string PasswordHash { get; set; }
        public string ErrorMessage { get; set; }
        public ClsPerson PersonInfo { get; set; }
        public static object CurrentUser { get; set; }

        public ClsUser()
        {
            this.UserID = null;
            this.PersonID = 0;
            this.DepartmentID = 0;
            this.JobTitle = "";
            this.HireDate = DateTime.Now;
            this.Salary = 0M;
            this.Status = 0;
            this.RoleID = 0;
            this.UserName = "";
            this.PasswordHash = "";
            this.PersonInfo = new ClsPerson();

            Mode = enMode.AddNew;
        }

        public ClsUser(string userID, int personID, int departmentID, int branchID,
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

           
            this.UserID = ClsUserDataAccess.AddNewUserWithPerson(this.PersonInfo.FirstName,this.PersonInfo.LastName,this.PersonInfo.NationalID,
                this.UserName,this.PasswordHash,this.PersonInfo.Phone,this.PersonInfo.Email,this.PersonInfo.ImagePath,
                this.RoleID,this.DepartmentID,this.JobTitle,this.HireDate,this.Status, (byte)this.PersonInfo.Gender, ref errorMessage
            );

            this.ErrorMessage = errorMessage;

            return !string.IsNullOrEmpty(this.UserID);

        }

        private bool _UpdateUser()
        {
            string errorMessage = "";

            bool isUpdated = ClsUserDataAccess.UpdateUserWithPerson(this.UserID,this.PersonID,this.PersonInfo.FirstName,this.PersonInfo.LastName,
                this.PersonInfo.NationalID,this.UserName,this.PasswordHash,this.PersonInfo.Phone,this.PersonInfo.Email,this.PersonInfo.ImagePath,this.RoleID,       
                this.DepartmentID,this.JobTitle,this.Status, (byte)this.PersonInfo.Gender, ref errorMessage
            );

            if (isUpdated)

            {
                return true;
            }
            else

            {
                this.ErrorMessage = errorMessage;
                return false;
            }
        }

        public bool UpdateStatusOnly(byte newStatus)

        {

            string errorMessage = "";
            bool isUpdate = ClsUserDataAccess.UpdateUserStatus(this.UserID, newStatus, ref errorMessage);

            this.ErrorMessage = errorMessage;
            if (isUpdate)
            {
                this.Status = newStatus;
            }
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

        public static ClsUser Find(string userID, ref string errorMessage)
        {
            int personID = 0, departmentID = 0, branchID = 0;
            string jobTitle = "", UserName = "", PasswordHash = "" , RoleName = "";
            DateTime hireDate = DateTime.Now;
            decimal salary = 0M;
            byte status = 0;
            int RoleID = 0;

            if (ClsUserDataAccess.GetUserByID(userID, ref personID, ref departmentID, ref branchID,
                                             ref jobTitle, ref hireDate, ref salary, ref status, ref UserName, ref PasswordHash,ref RoleName, ref RoleID, ref errorMessage))


            {


                ClsUser User = new ClsUser(userID, personID, departmentID, branchID, jobTitle, hireDate, salary, status);
             
                User.UserName = UserName;
                User.PasswordHash = PasswordHash;
                User.RoleID = RoleID;
                User.RoleName = RoleName;
                User.PersonInfo = ClsPerson.Find(personID, ref errorMessage);
              

                return User;

            }
            
         

            return null;
        }

        public static bool DeleteUser(string userID, ref string errorMessage)
        {
            return ClsUserDataAccess.DeleteUser(userID, ref errorMessage);
        }

        public static DataTable GetAllUsers(ref string errorMessage)
        {
            return ClsUserDataAccess.GetUsersInFo(ref errorMessage);
        }

        public static DataTable GetDepartments(ref string errorMessage)
        {
            return ClsUserDataAccess.GetDepartments(ref errorMessage);
        }

        public static string GetNextUserID()
        {
           
            string lastUserID = ClsUserDataAccess.GetLastUserID();

           
            if (string.IsNullOrEmpty(lastUserID))
            {
                return "USR-2026-1001";
            }

            
            try
            {
                string[] parts = lastUserID.Split('-');
                if (parts.Length == 3 && int.TryParse(parts[2], out int lastNumber))
                {
                    int nextNumber = lastNumber + 1;
                    return $"{parts[0]}-{parts[1]}-{nextNumber:D4}"; ;
                }
            }
            catch
            {
               
                return "USR-2026-1001";
            }

            return "USR-2026-1001";
        }

        public static bool IsUserExist(string userID, ref string errorMessage)
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


            string userID = null; int personID = -1, departmentID = -1, branchID = -1;
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