using BankSystemDataAccess.EntitiesData;
using System;
using System.Data;

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

        private bool _AddNewClient()

        {

            string errorMessage = "";

            this.ClientID = ClsClientDataAccess.AddNewClient(
                this.PersonID,
                this.ClientType,
                this.CreatedDate,
                this.Status,
                ref errorMessage
            );

            this.ErrorMessage = errorMessage;
            return (this.ClientID != -1);
        }

        private bool _UpdateClient()

        {

            string errorMessage = "";

            bool isUpdated = ClsClientDataAccess.UpdateClient(
                this.ClientID,
                this.PersonID,
                this.ClientType,
                this.Status,
                this.CreatedDate,
                ref errorMessage
            );

            this.ErrorMessage = errorMessage;
            return isUpdated;
        }

        public bool Save()

        {
            
            if (this.PersonInfo != null)

            {

                string personErr = "";
                if (!this.PersonInfo.Save())
                {
                    this.ErrorMessage = "Error Dosen't Saved a Person Details : " + personErr;
                    return false;
                }
                this.PersonID = this.PersonInfo.PersonID;

            }

           
            switch (Mode)

            {

                case enMode.AddNew:
                    if (_AddNewClient())

                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;


                case enMode.Update:
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