using System;
using System.Data;
using System.Runtime.InteropServices;
using BankSystemDataAccess.EntitiesData;
using BankSystemDataAccess.FinancialData;


namespace BankSystemDataAccess.Financial
{

    public partial class ClsAccount
    {


        public enum enAccountType
        {
            CheckingAccountIndividual = 1,
            SavingsAccountInvestment = 2,
            CorporateCommercialAccount = 3,
            WeeklyDepositAccount = 4,
            PayrollAccount = 5
        }

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int AccountID { get; set; }
        public string AccountNumber { get; set; }
        public string IBAN { get; set; }
        public int ClientID { get; set; }
        public int AccountTypeID { get; set; }
        public int BranchID { get; set; }
        public int CurrencyID { get; set; }
        public decimal Balance { get; set; }
        public byte Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive => Status == 1;
        public string ErrorMessage = "";



        public ClsAccount()

        {

            this.AccountID = -1;
            this.AccountNumber = "";
            this.IBAN = "";
            this.ClientID = -1;
            this.AccountTypeID = -1;
            this.BranchID = -1;
            this.CurrencyID = -1;
            this.Balance = 0M;
            this.Status = 1;
            this.CreatedDate = DateTime.Now;

            Mode = enMode.AddNew;


        }

        private ClsAccount(int accountID, string accountNumber, string iban, int clientID,
                          int accountTypeID, int branchID, int currencyID, decimal balance,
                          byte status, DateTime createdDate)

        {

            this.AccountID = accountID;
            this.AccountNumber = accountNumber;
            this.IBAN = iban;
            this.ClientID = clientID;
            this.AccountTypeID = accountTypeID;
            this.BranchID = branchID;
            this.CurrencyID = currencyID;
            this.Balance = balance;
            this.Status = status;
            this.CreatedDate = createdDate;

            Mode = enMode.Update;

        }


        private bool _AddNewAccount()


        {

             string ErrorMessage = string.Empty;

            this.AccountID = ClsAccountData.AddNewAccount(this.AccountNumber, this.IBAN, this.ClientID,
                                                                  this.AccountTypeID, this.BranchID, this.CurrencyID,
                                                                  this.Balance, this.Status, ref ErrorMessage);

             this.ErrorMessage = ErrorMessage;

            return (AccountID != 0);



        }


        private bool _UpdateAccount()


        {

            string ErrorMessage = "";

            bool IsUpdate = ClsAccountData.UpdateAccountInfo(this.AccountID, this.AccountTypeID, this.BranchID,
                                                             this.CurrencyID, this.Status, ref ErrorMessage);

            this.ErrorMessage = ErrorMessage;

            return IsUpdate;
        }


        public bool Save()


        {

            

            bool IsSuccessed = false;

            switch(Mode)

            {

                case enMode.AddNew:

                    if(_AddNewAccount())
                    {

                        Mode = enMode.Update;
                        return true;

                    }
                    else
                    {

                        return false;

                    }
                    

                case enMode.Update:

                    return _UpdateAccount();

            }
            return IsSuccessed;
        }


        public static ClsAccount Find(int AccountID, ref string ErrorMessage)


        {



            string accountNumber = "", iban = "";
            int clientID = -1, accountTypeID = -1, branchID = -1, currencyID = -1;
            decimal balance = 0M;
            byte status = 0;
            DateTime createdDate = DateTime.Now;


            if (ClsAccountData.GetAccountByID(AccountID, ref accountNumber, ref iban, ref clientID, ref accountTypeID,
                                              ref branchID, ref currencyID, ref balance, ref status, ref createdDate, ref ErrorMessage))
            {

                return new ClsAccount(AccountID, accountNumber, iban, clientID, accountTypeID, branchID, currencyID, balance, status, createdDate);
            }

            return null;
        }


        public static ClsAccount FindByAccountNumber(string AccountNumber, ref string ErrorMessage)


        {




            int AccountID = 0; string iban = "";
            int clientID = -1, accountTypeID = -1, branchID = -1, currencyID = -1;
            decimal balance = 0M;
            byte status = 0;
            DateTime createdDate = DateTime.Now;


            if (ClsAccountData.GetAccountByAccountNumber(AccountNumber, ref AccountID, ref iban, ref clientID, ref accountTypeID,
                                              ref branchID, ref currencyID, ref balance, ref status, ref createdDate, ref ErrorMessage))
            {

                return new ClsAccount(AccountID, AccountNumber, iban, clientID, accountTypeID, branchID, currencyID, balance, status, createdDate);
            }

            return null;

        }

        public static DataTable FindByClientID(int ClientID, ref string ErrorMessage)
        {
            return ClsAccountData.GetAccountsByClientID(
                ClientID,
                ref ErrorMessage
            );
        }

        public static DataTable GetAllAccounts(ref string ErrorMessage)

        {

            return ClsAccountData.GetAccountsView( ref ErrorMessage );

        }

        public static DataTable GetAccountType( ref string ErroeMessage)

        {

            return ClsAccountData.GetAccountsType(ref ErroeMessage);
        }

        public static bool Delete(int AccountID, ref string ErrorMessage)

        {

            return ClsAccountData.DeleteAccount(AccountID, ref ErrorMessage);

        }

        public static bool IsAccountExist(int AccountID, ref string ErrorMessage)
        {

            return ClsAccountData.IsAccountExist(AccountID, ref ErrorMessage);

        }

        public bool Deposit(decimal Amount)

        {

            if (Amount <= 0)

            {

                this.ErrorMessage = "Deposit amount must be greater than zero!.";
                return false;

            }

            if (!IsActive)

            {
                this.ErrorMessage = "Your account isn't Active!.";
                return false;

            }


            string ErrorMessage = "";


            if ( ClsAccountData.Deposit(this.AccountID,Amount,ref ErrorMessage))

            {

                this.Balance += Amount;
                this.ErrorMessage = "";
                return true;

            }

            this.ErrorMessage = ErrorMessage;
            return false;

        }

        public bool Withdraw(decimal Amount)

        {

            if ( Amount <= 0)
            {

                this.ErrorMessage = "Withdrawal amount must be greater than zero.";
                return false;

            }


            if (!IsActive)

            {
                this.ErrorMessage = "Your account isn't Active!.";
                return false;

            }


            string ErrorMessage = "";


            if ( ClsAccountData.Withdraw(this.AccountID,Amount,ref ErrorMessage))

            {

                this.Balance -= Amount;
                this.ErrorMessage = "";
                return true;

            }

            this.ErrorMessage = ErrorMessage;
            return false;

        }

        public  int GetTotalAccountsCount(ref string ErrorMessage)
        {
            return ClsAccountData.GetTotalAccounts(ref ErrorMessage);
        }

        public  int GetTotalActiveAccountsCount(ref string ErrorMessage)
        {
            return ClsAccountData.GetTotalActiveAccounts(ref ErrorMessage);
        }

        public  int GetTotalDormantAccountsCount(ref string ErrorMessage)
        {
            return ClsAccountData.GetTotalDormantAccounts(ref ErrorMessage);
        }

        public int GetTotalInactiveAccountsCount(ref string ErrorMessage)
        {
            return ClsAccountData.GetTotalInactiveAccounts(ref ErrorMessage);
        }
    }
}