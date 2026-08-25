using System;
using System.Data;
using System.Windows.Controls;
using BankSystemDataAccess.FinancialData;

namespace BankSystemBusinessLayer
{
    public class clsTransaction
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public int TransactionID { get; set; }
        public int? FromAccountID { get; set; }
        public int? ToAccountID { get; set; }
        public byte TransactionTypeID { get; set; }
        public int CurrencyID { get; set; }
        public int? PerformedByClientID { get; set; }
        public int? ExecutedByUserID { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime TransactionDate { get; set; }
        public string ErrorMessage { get; set; }


        public clsTransaction()

        {

            this.TransactionID = -1;
            this.FromAccountID = null;
            this.ToAccountID = null;
            this.TransactionTypeID = 1;
            this.CurrencyID = 1;
            this.PerformedByClientID = null;
            this.ExecutedByUserID = null;
            this.Amount = 0M;
            this.Description = "";
            this.TransactionDate = DateTime.Now;

            Mode = enMode.AddNew;

        }


        private clsTransaction(int transactionID, int? fromAccountID, int? toAccountID,
                              byte transactionTypeID, int currencyID, int? performedByClientID,
                              int? executedByUserID, decimal amount, string description, DateTime transactionDate)



        {


            this.TransactionID = transactionID;
            this.FromAccountID = fromAccountID;
            this.ToAccountID = toAccountID;
            this.TransactionTypeID = transactionTypeID;
            this.CurrencyID = currencyID;
            this.PerformedByClientID = performedByClientID;
            this.ExecutedByUserID = executedByUserID;
            this.Amount = amount;
            this.Description = description;
            this.TransactionDate = transactionDate;

            Mode = enMode.Update;


        }


        private bool _AddNewTransaction()


        {

            string ErrorMessage = "";

            this.TransactionID = ClsTransactionData.AddNewTransaction(this.FromAccountID, this.ToAccountID,
                                                                             this.TransactionTypeID, this.CurrencyID,
                                                                             this.PerformedByClientID, this.ExecutedByUserID,
                                                                             this.Amount, this.Description, ref ErrorMessage);

            this.ErrorMessage = ErrorMessage;

            return (this.TransactionID > 0);

        }


        private bool _UpdateTransaction()


        {

            string ErrorMessage = "";

            bool Result = ClsTransactionData.UpdateTransactionDescription(
                    this.TransactionID,
                    this.Description,
                    ref ErrorMessage
                );

            this.ErrorMessage = ErrorMessage;

            return Result;

        }


        public static clsTransaction Find(int transactionID, ref string ErrorMessage)


        {

            int? fromAccountID = null, toAccountID = null, performedByClientID = null, executedByUserID = null;
            byte transactionTypeID = 0;
            int currencyID = 0;
            decimal amount = 0M;
            string description = "";
            DateTime transactionDate = DateTime.Now;



            if (ClsTransactionData.GetTransactionByID(transactionID, ref fromAccountID, ref toAccountID,
                                                      ref transactionTypeID, ref currencyID, ref performedByClientID,
                                                      ref executedByUserID, ref amount, ref description,
                                                      ref transactionDate, ref ErrorMessage))

            {

                return new clsTransaction(transactionID, fromAccountID, toAccountID, transactionTypeID,
                                          currencyID, performedByClientID, executedByUserID, amount, description, transactionDate);
            }
            return null;
        }




        public bool Save()

        {

            switch (Mode)

            {

                case enMode.AddNew:

                    if (_AddNewTransaction())
                    {

                        Mode = enMode.Update;
                        return true;

                    }

                    return false;

                case enMode.Update:

                    return _UpdateTransaction();

            }

            return false;
        }



        public static bool Transfer(int fromAccountID, int toAccountID, decimal amount,
                                    int currencyID, int? performedByClientID, int? executedByUserID,
                                    string description, ref string errorMessage)
        {


            return ClsTransactionData.Transfers(fromAccountID, toAccountID, amount,
                                                    currencyID, performedByClientID, executedByUserID,
                                                    description, ref errorMessage);


        }



        public static DataTable GetTransactionsList(ref string ErrorMessage)

        {
           

            return ClsTransactionData.GetTransactionsView(ref ErrorMessage);

        }


        public static DataTable GetAccountTransactions(int accountID, ref string ErrorMessage)

        {


            return ClsTransactionData.GetTransactionsByAccountID(accountID, ref ErrorMessage);

        }

    }

}