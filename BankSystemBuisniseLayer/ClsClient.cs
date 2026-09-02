using BankSystemDataAccess.EntitiesData;
using BankSystemDataAccess.Financial;
using System;
using System.Data;
using System.Windows.Media.Converters;

namespace BankSystemBuisniseLayer
{
    public class ClsClient
    {


        public enum enClientType
        {
            Standard = 1,
            VIP = 2,
            Corporate = 3
        }


        public enum enMode { AddNew = 1, Update = 2 }
        public enMode Mode = enMode.AddNew;

        public int ClientID { get; set; }
        public int PersonID { get; set; }
        public byte ClientType { get; set; }
        public DateTime CreatedDate { get; set; }
        public byte Status { get; set; }
        public string ErrorMessage { get; set; }

        
        public ClsPerson PersonInfo { get; set; }

        public ClsClient()

        {

            this.ClientID = -1;
            this.PersonID = -1;
            this.ClientType = 1;
            this.CreatedDate = DateTime.Now;
            this.Status = 1;
            this.ErrorMessage = "";
            this.PersonInfo = null;

            Mode = enMode.AddNew;
        }

        private ClsClient(int clientID, int personID, byte clientType, DateTime createdDate, byte status)

        {

            this.ClientID = clientID;
            this.PersonID = personID;
            this.ClientType = clientType;
            this.CreatedDate = createdDate;
            this.Status = status;
            this.ErrorMessage = "";

           
            string personError = "";
            this.PersonInfo = ClsPerson.Find(personID, ref personError);

            Mode = enMode.Update;
        }

        private bool _AddNewClient(ClsAccount account)

        {
            int ClientID = -1;
            int AccountID = -1;
            string ErrorMessage = "";

            
            string accountNumber = account != null ? account.AccountNumber : "";
            string iban = account != null ? account.IBAN : "";
            int accountTypeID = account != null ? account.AccountTypeID : 1;
            int branchID = account != null ? account.BranchID : 1;
            int currencyID = account != null ? account.CurrencyID : 1;
            decimal balance = account != null ? account.Balance : 0;
            byte accountStatus = account != null ? account.Status : (byte)1;


            bool isAdded = ClsClientDataAccess.AddNewClientWithAccount(this.PersonInfo.FirstName,
                this.PersonInfo.LastName,this.PersonInfo.NationalID,this.PersonInfo.DateOFBirth,this.PersonInfo.Phone,
                this.PersonInfo.Email,(byte)this.PersonInfo.Gender,this.PersonInfo.CityID,this.PersonInfo.ImagePath,this.ClientType,
                this.Status,accountNumber,iban,accountTypeID,branchID,currencyID,balance,accountStatus,ref ClientID,ref AccountID,ref ErrorMessage

            );

            if (isAdded)
            {
               

                this.ClientID = ClientID;
                if (account != null)

                {

                    account.AccountID = AccountID;
                    account.ClientID = ClientID;

                }
                return true;
            }
            else
            {

                this.ErrorMessage = ErrorMessage;
                return false;

            }
        }

        private bool _UpdateClient()

        {
            string errorMessage = "";

            bool isUpdated = ClsClientDataAccess.UpdateClientWithPerson(this.ClientID,this.PersonID,this.PersonInfo.FirstName,this.PersonInfo.LastName,
                this.PersonInfo.NationalID,this.PersonInfo.DateOFBirth,this.PersonInfo.Phone,this.PersonInfo.Email,
                (byte)this.PersonInfo.Gender,this.PersonInfo.CityID,this.PersonInfo.ImagePath,this.ClientType,this.Status,
                ref errorMessage
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
            this.Status = newStatus;

            bool isUpdated = ClsClientDataAccess.UpdateClientStatus(this.ClientID, this.Status, ref errorMessage);

            if (!isUpdated)
            {
                this.ErrorMessage = errorMessage;
            }

            return isUpdated;
        }

        public bool Save(ClsAccount account = null)
        {
            switch (Mode)
            {
                case enMode.AddNew:
                  
                    if (_AddNewClient(account))
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;


                case enMode.Update:
                   
                    if (this.PersonInfo != null)
                    {
                        if (!this.PersonInfo.Save())
                        {
                            this.ErrorMessage = "Error Doesn't Save Person Details: " + this.PersonInfo.ErrorMessage;
                            return false;
                        }
                        this.PersonID = this.PersonInfo.PersonID;
                    }

                    return _UpdateClient();
            }

            return false;
        }

        public static ClsClient Find(int clientID, ref string errorMessage)

        {

            int personID = -1;
            byte clientType = 0;
            DateTime createdDate = DateTime.Now;
            byte status = 0;

            if (ClsClientDataAccess.GetClientByID(clientID, ref personID, ref clientType, ref createdDate, ref status, ref errorMessage))
            {
                return new ClsClient(clientID, personID, clientType, createdDate, status);
            }

            return null;

        }

        public static ClsClient FindByPersonID(int personID, ref string errorMessage)

        {

            int clientID = -1;
            byte clientType = 0;
            DateTime createdDate = DateTime.Now;
            byte status = 0;

            if (ClsClientDataAccess.GetClientByPersonID(personID, ref clientID, ref clientType, ref createdDate, ref status, ref errorMessage))
            {
                return new ClsClient(clientID, personID, clientType, createdDate, status);
            }

            return null;

        }

        public static bool DeleteClient(int clientID, ref string errorMessage)
        {
            return ClsClientDataAccess.DeleteClient(clientID, ref errorMessage);
        }

        public static bool ForceDeleteClient(int ClientID,int PersonID,ref string errorMessage)
        {
            return ClsClientDataAccess.ForceDeleteClient(ClientID, PersonID, ref errorMessage);
        }

        public static DataTable GetClientsList(ref string errorMessage)
        {
            return ClsClientDataAccess.GetAllClients(ref errorMessage);
        }

        public static DataTable GetActiveClients(ref string errorMessage)
        {
            return ClsClientDataAccess.GetAllActiveClients(ref errorMessage);
        }

        public static bool IsClientExist(int clientID, ref string errorMessage)
        {
            return ClsClientDataAccess.IsClientExist(clientID, ref errorMessage);
        }

        public static bool IsClientExistByPersonID(int personID, ref string errorMessage)
        {
            return ClsClientDataAccess.IsClientExistByPersonID(personID, ref errorMessage);
        }

        public static int GetNextClientID(string errorMessage)
        {
            return ClsClientDataAccess.GetNextClientID(ref errorMessage);
        }

        public static string GetClientTypeName(byte clientType)
        {
            switch ((enClientType)clientType)
            {
                case enClientType.Standard: return "Standard Client";
                case enClientType.VIP: return "VIP Client";
                case enClientType.Corporate: return "Corporate Client";
                default: return "Unknown";
            }
        }
    }
}