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

            string query = @"
                                   SELECT 
                                       Clients.ClientID AS [Client ID],
                                       Persons.ImagePath AS [Profile],
                                       Persons.FirstName + ' ' + Persons.LastName AS [Full Name],
                                       Persons.Email AS [Email Address],
                                       Persons.Phone AS [Phone Number],
                                       ISNULL(Countries.CountryName, 'N/A') AS [Country],
                                       COUNT(Accounts.AccountID) AS [Total Accounts], 

                                       CASE 
                                           WHEN Clients.Status = 1 THEN 'Active' 
                                           ELSE 'Inactive' 
                                       END AS [Status],
                                       ISNULL(SUM(Accounts.Balance), 0.00) AS [Total Balance (USD)],
                                       Clients.CreatedDate AS [Date Registered],
                                       ISNULL(STRING_AGG(AccountTypes.TypeName, ' & '), 'No Accounts') AS [Account Type(s)]
                                   FROM Clients
                                   INNER JOIN Persons ON Clients.PersonID = Persons.PersonID
                                   LEFT JOIN Cities ON Persons.CityID = Cities.CityID
                                   LEFT JOIN Countries ON Cities.CountryID = Countries.CountryID
                                   LEFT JOIN Accounts ON Clients.ClientID = Accounts.ClientID
                                   LEFT JOIN AccountTypes ON Accounts.AccountTypeID = AccountTypes.AccountTypeID";


                                query += @" GROUP BY 
                                           Clients.ClientID, 
                                           Persons.ImagePath, 
                                           Persons.FirstName, 
                                           Persons.LastName, 
                                           Persons.Email, 
                                           Persons.Phone, 
                                           Countries.CountryName, 
                                           Clients.CreatedDate, 
                                           Clients.Status;";



            return ClsClientDataAccess.GetAllClients(ref ErrorMessage, query);
        }

        public static DataTable GetActiveAccounts(ref string ErrorMessage)


        {

            string query = @"
                                 SELECT 
                                     Clients.ClientID AS [Client ID],
                                     Persons.ImagePath AS [Profile],
                                     Persons.FirstName + ' ' + Persons.LastName AS [Full Name],
                                     Persons.Email AS [Email Address],
                                     Persons.Phone AS [Phone Number], 
                                     ISNULL(STRING_AGG(AccountTypes.TypeName, ' & '), 'No Accounts') AS [Account Type(s)],
                                     ISNULL(STRING_AGG(CAST(Accounts.AccountNumber AS VARCHAR(50)), ' & '), 'N/A') AS [Accounts Number], 
                                     
                                     (
                                         SELECT MAX(T.TransactionDate) 
                                         FROM Transactions T 
                                         INNER JOIN Accounts Acc ON T.FromAccountID = Acc.AccountID OR T.ToAccountID = Acc.AccountID 
                                         WHERE Acc.ClientID = Clients.ClientID
                                     ) AS [Last TransAction Date],
                                     
                                     CASE 
                                         WHEN Clients.Status = 1 THEN 'Active'
                                         ELSE 'Inactive' 
                                     END AS [Status],
                                     ISNULL(SUM(Accounts.Balance), 0.00) AS [Total Balance (USD)],
                                     Clients.CreatedDate AS [Date Registered]
                                 FROM Clients
                                 INNER JOIN Persons ON Clients.PersonID = Persons.PersonID
                                 LEFT JOIN Cities ON Persons.CityID = Cities.CityID
                                 LEFT JOIN Countries ON Cities.CountryID = Countries.CountryID
                                 LEFT JOIN Accounts ON Clients.ClientID = Accounts.ClientID
                                 LEFT JOIN AccountTypes ON Accounts.AccountTypeID = AccountTypes.AccountTypeID
                                 WHERE Clients.Status = 1 ";

            query += @" GROUP BY 
                                 Clients.ClientID, 
                                 Persons.ImagePath, 
                                 Persons.FirstName, 
                                 Persons.LastName, 
                                 Persons.Email, 
                                 Persons.Phone, 
                                 Clients.CreatedDate, 
                                 Clients.Status;";

            return ClsClientDataAccess.GetAllClients(ref ErrorMessage, query);


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
