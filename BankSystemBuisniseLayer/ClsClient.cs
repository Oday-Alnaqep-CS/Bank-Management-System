using BankSystemDataAccess.EntitiesData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace BankSystemBuisniseLayer
{
    public class ClsClient
    {


        public enum enMode { AddNew = 1, Update = 2 }
        public enMode Mode = enMode.AddNew;


        public int ClientID { get; set; }
        public int PersonID { get; set; }
        public byte ClientType { get; set; }
        public DateTime CreadtedDate { get; set; }
        public byte status { get; set; }
        public string ErrorMessaget { get; set; }


        public ClsClient()
        {

            this.ClientID = 0;
            this.PersonID = 0;
            this.ClientType = 0;
            this.CreadtedDate = DateTime.Now;
            this.status = 0;

            Mode = enMode.AddNew;

        }

        public ClsClient(int ClientID, int PersonID, byte ClientType, DateTime CreadtedDate,byte status)
        {

            this.ClientID = ClientID;
            this.PersonID = PersonID;
            this.ClientType =(byte)ClientType;
            this.CreadtedDate =(DateTime)CreadtedDate;
            this.status =(byte)status;
            
            Mode = enMode.Update; 

        }

        private bool _AddNewClient()
        
        
        {

            string ErrorMessage = "";

            this.ClientID = ClsClientDataAccess.AddNewClient(this.PersonID, this.ClientType, this.CreadtedDate,
                                                       this.status, ref ErrorMessage);

           

            this.ErrorMessaget = ErrorMessage;

            return (this.ClientID != -1);
        }

        private bool _UpdateClient()
        
        
        {

            string ErrorMessage = "";

            bool IsUpdate = ClsClientDataAccess.UpdateClient(this.ClientID, this.PersonID, this.ClientType, this.status, 
                                                                this.CreadtedDate,  ref ErrorMessage);
          
            this.ErrorMessaget = ErrorMessage;

            return IsUpdate;


        }

        public bool Save()
        
        
        {


            bool IsSuccessed = false;

            switch(Mode)
            {

                case enMode.AddNew:

                    if (_AddNewClient())
                    {

                        Mode = enMode.Update;
                        IsSuccessed = true;

                    }
                    else
                    {
                        IsSuccessed = false;
                    }
                    break;

                case enMode.Update:
                    return _UpdateClient();
              
            }

            return IsSuccessed;


        }

        public static ClsClient Find(int ClientID, ref string ErrorMessage)
        
        {

            

            int PersonID = 0; byte ClientType = 0; DateTime CreadtedDate = DateTime.Now;
            byte status = 0;  


            if (ClsClientDataAccess.GetClientByID(ClientID,ref PersonID , ref ClientType, ref CreadtedDate
                                                   , ref status, ref ErrorMessage))
            {

                return new ClsClient(ClientID,PersonID,ClientType,  CreadtedDate, status);
            }

            
            return null;
        }

        public static ClsClient FindByPersonID(int PersonID, ref string ErrorMessage)
        

        {

            int ClientID = 0; byte ClientType = 0; DateTime CreadtedDate = DateTime.Now;
            byte status = 0;


            if (ClsClientDataAccess.GetClientByPersonID(PersonID, ref ClientID, ref ClientType, ref CreadtedDate,
                                         ref status, ref ErrorMessage))


            {
                
                return new ClsClient(ClientID, PersonID, ClientType, CreadtedDate, status);
            }

            return null;


        }

        public static bool DeletClient(int ClientID, ref string ErrorMessage)

        {

            return ClsClientDataAccess.DeleteClient(ClientID , ref ErrorMessage);
            
        }

        public static DataTable GetClientsList(ref string ErrorMessage)


        {

            return ClsClientDataAccess.GetAllClients(ref ErrorMessage);

        }

        public static DataTable GetActiveAccounts(ref string ErrorMessage)


        {

            return ClsClientDataAccess.GetAllActiveClients(ref ErrorMessage);


        }

        public static bool IsclientExist(int ClientID, ref string ErrorMessage)

        {

            return ClsClientDataAccess.IsClientExist(ClientID , ref ErrorMessage);
            
        }

        public static bool IsClientExistByPersonID(int PersonID, ref string ErrorMessage)

        {

            return ClsClientDataAccess.IsClientExistByPersonID (PersonID, ref ErrorMessage);

        }




    }
}
