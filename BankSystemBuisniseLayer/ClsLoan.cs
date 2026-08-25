using BankSystemDataAccess;
using BankSystemDataAccess.FinancialData;
using System;
using System.Data;

namespace BankSystemBuisniseLayer
{
    public class ClsLoan
    {
        public enum enMode { AddNew = 1, Update = 2 }
        public enMode Mode = enMode.AddNew;

        public int LoanID { get; set; }
        public int ClientID { get; set; }
        public byte LoanTypeID { get; set; }
        public decimal Amount { get; set; }
        public decimal InterestRate { get; set; }
        public short TermMonths { get; set; }
        public decimal MonthlyInstallment { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public byte Status { get; set; }
        public string ErrorMessage { get; set; }

        public ClsLoan()
        {
            this.LoanID = -1;
            this.ClientID = -1;
            this.LoanTypeID = 0;
            this.Amount = 0;
            this.InterestRate = 0;
            this.TermMonths = 0;
            this.MonthlyInstallment = 0;
            this.StartDate = DateTime.Now;
            this.EndDate = DateTime.Now;
            this.Status = 0;

            Mode = enMode.AddNew;
        }

        public ClsLoan(int loanID, int clientID, byte loanTypeID, decimal amount, decimal interestRate, short termMonths, decimal monthlyInstallment, DateTime startDate, DateTime endDate, byte status)
        {
            this.LoanID = loanID;
            this.ClientID = clientID;
            this.LoanTypeID = loanTypeID;
            this.Amount = amount;
            this.InterestRate = interestRate;
            this.TermMonths = termMonths;
            this.MonthlyInstallment = monthlyInstallment;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Status = status;

            Mode = enMode.Update;
        }

        private bool _AddNewLoan()
        {
            string errorMessage = "";

            this.LoanID = ClsLoanData.AddNewLoan(this.ClientID, this.LoanTypeID, this.Amount, this.InterestRate, this.TermMonths, this.MonthlyInstallment, this.StartDate, this.EndDate, this.Status, ref errorMessage);

            this.ErrorMessage = errorMessage;

            return (this.LoanID != -1 && this.LoanID != 0);
        }

        private bool _UpdateLoan()
        {
            string errorMessage = "";

            bool isUpdated = ClsLoanData.UpdateLoanStatus(this.LoanID, this.Status, ref errorMessage);

            this.ErrorMessage = errorMessage;

            return isUpdated;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLoan())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateLoan();
            }

            return false;
        }

        public static ClsLoan Find(int loanID, ref string errorMessage)
        {
            int clientID = -1;
            byte loanTypeID = 0, status = 0;
            decimal amount = 0, interestRate = 0, monthlyInstallment = 0;
            short termMonths = 0;
            DateTime startDate = DateTime.Now, endDate = DateTime.Now;

            if (ClsLoanData.GetLoanByID(loanID, ref clientID, ref loanTypeID, ref amount, ref interestRate, ref termMonths, ref monthlyInstallment, ref startDate, ref endDate, ref status, ref errorMessage))
            {
                return new ClsLoan(loanID, clientID, loanTypeID, amount, interestRate, termMonths, monthlyInstallment, startDate, endDate, status);
            }

            return null;
        }

        public static bool DeleteLoan(int loanID, ref string errorMessage)
        {
            return ClsLoanData.DeleteLoan(loanID, ref errorMessage);
        }

        public static DataTable GetAllLoans(ref string errorMessage)
        {
            return ClsLoanData.GetLoansView(ref errorMessage);
        }
    }
}