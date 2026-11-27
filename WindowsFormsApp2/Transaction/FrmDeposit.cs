using BankSystemBuisniseLayer;
using BankSystemBusinessLayer;
using BankSystemDataAccess.Financial;
using FontAwesome.Sharp;
using OpenCvSharp.Internal.Vectors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Util;
using System.Windows.Forms;

namespace Bank_Managment_System
{
    public partial class FrmDeposit : Form
    {

        public event EventHandler DepositCompleted;
        ClsAccount _Account = new ClsAccount();
        UC_TransactionsManagement _Transaction = new UC_TransactionsManagement();
         clsTransaction _Trans = new clsTransaction();
        ClsNotification _Notification = new ClsNotification();
        private UC_TransactionsManagement _transactionsUC;

        public FrmDeposit(UC_TransactionsManagement transactionsUC)
        {
            InitializeComponent();
            _transactionsUC = transactionsUC;


        }

        private void FrmDeposit_Load(object sender, EventArgs e)
        {

            _Desing();
            _FillCustomerInformation();
            timer1.Start();
        }

        private void _Desing()

        {
         
            PictCustomerIcone.Image = IconChar.User.ToBitmap(Color.DodgerBlue);
            PctAccountIcone.Image = IconChar.User.ToBitmap(Color.DodgerBlue);
            PictAmountIcone.Image = IconChar.MoneyBillWave.ToBitmap(Color.MediumSpringGreen);
            CurrentBalanceIcone.Image = IconChar.Wallet.ToBitmap(Color.DodgerBlue);
            ToplblIcone.Image = IconChar.Download.ToBitmap(Color.DodgerBlue);
            AfterDepositIcone.Image = IconChar.BalanceScale.ToBitmap(Color.MediumSpringGreen);
            btnConfirmDeposit.Image = IconChar.ArrowRightToBracket.ToBitmap(Color.MediumSpringGreen);
            btnCancel.Image = FontAwesome.Sharp.IconChar.Xmark.ToBitmap(Color.Red);
            txtTransferTime.Image = IconChar.Clock.ToBitmap(Color.CornflowerBlue);
            txtTransferDate.Image = IconChar.CalendarAlt.ToBitmap(Color.CornflowerBlue);
            txtTransferDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            txtTransferDate.TextAlign = HorizontalAlignment.Center;
            //    txtTransferTime.Text = DateTime.Now.ToString("hh:mm:ss tt", CultureInfo.InvariantCulture);
            txtTransferTime.TextAlign = HorizontalAlignment.Center;


        }


        private void _FillCustomerInformation()

        {

            string errorMessage = string.Empty;
            DataTable dtClients = ClsClient.GetClientsInfo(ref errorMessage);

            if (!string.IsNullOrEmpty(errorMessage))

            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            CbCustomer.DataSource = dtClients;
            CbCustomer.DisplayMember = "Full Name";
            CbCustomer.ValueMember = "Customer ID";
            CbCustomer.MaxDropDownItems = 4;
            CbCustomer.AutoCompleteSource = AutoCompleteSource.ListItems;
            CbCustomer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;



        }

        private void CbSenderCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (CbCustomer.SelectedIndex == -1 || CbCustomer.SelectedValue == null)
                return;

            if (int.TryParse(CbCustomer.SelectedValue.ToString(), out int CustomerID))

            {

                string errorMessage = string.Empty;
                DataTable dtAccounts = ClsAccount.FindAccountByClientID(CustomerID, ref errorMessage);

                if (!string.IsNullOrEmpty(errorMessage))
                {
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (dtAccounts != null && dtAccounts.Rows.Count > 0)
                {

                    CbAccount.DataSource = dtAccounts;
                    CbAccount.DisplayMember = "AccountNumber";
                    CbAccount.ValueMember = "AccountNumber";
                    CbAccount.SelectedIndex = -1;
                }
                else
                {
                    CbAccount.DataSource = null;
                    txtAccount.Text = string.Empty;
                    lblCurrentBalanceOfSender.Text = "0.00";
                }

            }

        }

        private void CbAccount_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (CbAccount.SelectedIndex == -1 || CbAccount.SelectedValue == null)
                return; 

            string AccountNUmber = CbAccount.SelectedValue.ToString();
            txtAccount.Text = AccountNUmber;

            string errorMessage = string.Empty;

            if (CbAccount.SelectedItem is DataRowView row)
            {
                int CurrencyID = Convert.ToInt32(row["CurrencyID"]);
            }


            string Currency = AccountNUmber.Substring(AccountNUmber.Length - 3);


            DataTable dtAccountDetails = ClsBalance.GetAccountDetailsByAccountNumber(AccountNUmber, ref errorMessage);

            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (dtAccountDetails != null && dtAccountDetails.Rows.Count > 0)
            {
                string AccountStatus = Convert.ToString(dtAccountDetails.Rows[0]["Account Status"]);
                double CurrentBalance = Convert.ToDouble(dtAccountDetails.Rows[0]["Current Balance (USD)"]);

                lblCurrentBalanceOfSender.Text = CurrentBalance.ToString("N2");

                if (AccountStatus == "Active")
                {
                    lblCurrentBalanceOfSender.ForeColor = Color.FromArgb(0, 192, 192);
                    txtAccount.BorderColor = Color.FromArgb(0, 192, 192);
                    btnConfirmDeposit.Enabled = true;
                }
                else if (AccountStatus == "Dormant")
                {
                    MessageBox.Show("The selected account is dormant. Please contact the bank for assistance.", "Account Dormant", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lblCurrentBalanceOfSender.ForeColor = Color.Orange;
                    txtAccount.BorderColor = Color.Orange;
                    btnConfirmDeposit.Enabled = false;
                }
                else if (AccountStatus == "Frozen")
                {
                    MessageBox.Show("The selected account is frozen. Please contact the bank for assistance.", "Account Frozen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lblCurrentBalanceOfSender.ForeColor = Color.Red;
                    txtAccount.BorderColor = Color.Red;
                    btnConfirmDeposit.Enabled = false;
                }
                else
                {
                    MessageBox.Show("The selected account has an unknown status. Please contact the bank for assistance.", "Unknown Account Status", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lblCurrentBalanceOfSender.ForeColor = Color.Gray;
                    txtAccount.BorderColor = Color.Gray;
                    btnConfirmDeposit.Enabled = false;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtTransferTime.Text = DateTime.Now.ToString("hh:mm:ss tt", CultureInfo.InvariantCulture);
           // lblAmountAfterDeposit.Text = txtAmount.Value.ToString();
        }

        private void btnConfirmDeposit_Click(object sender, EventArgs e)
        {



          
            if (CbAccount.SelectedIndex == -1 || string.IsNullOrEmpty(txtAccount.Text))
            {
                MessageBox.Show("Please select a valid account first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            if (!decimal.TryParse(txtAmount.Text, out decimal depositAmount) || depositAmount <= 0)
            {
                MessageBox.Show("Please enter a valid deposit amount.", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return;
            }

            string accountNumber = txtAccount.Text;
            string errorMessage = string.Empty;

           
            DialogResult result = MessageBox.Show(
                $"Are you sure you want to deposit ${depositAmount:N2} to account [{accountNumber}]?",
                "Confirm Deposit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                string ErrorMessage = string.Empty;
                _Account = ClsAccount.FindByAccountNumber(accountNumber,ref ErrorMessage);

                if (_Account != null && _Account.Deposit(depositAmount))
                {
                   
                    if (decimal.TryParse(lblCurrentBalanceOfSender.Text, NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal currentBalance))
                    {
                        decimal totalAfterDeposit = currentBalance + depositAmount;
                        lblAmountAfterDeposit.Text = totalAfterDeposit.ToString("N2");
                    }

                    MessageBox.Show("Deposit processed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    _Trans.FromAccountID = null; 
                    _Trans.ToAccountID = _Account.AccountID;
                    _Trans.ToCustomerName = CbCustomer.Text;
                    _Trans.TransactionTypeID = 1; 
                    _Trans.CurrencyID = _Account.CurrencyID;
                    _Trans.PerformedByClientID = _Account.ClientID;
                    _Trans.ExecutedByUserID = ClsGlobal.CurrentUser.UserID; 
                    _Trans.Amount = depositAmount;
                    _Trans.AmountAfter = Convert.ToDecimal(lblAmountAfterDeposit.Text);
                    _Trans.Description = "Deposit operation via system";
                    

                    _Notification.Title = "Deposit Notification";
                    _Notification.Message = $"Successfully deposited ${depositAmount:N2} to account [{accountNumber}].";
                    _Notification.UserID = ClsGlobal.CurrentUser.UserID;

                    bool isTransactionSaved = _Trans.Save();

              
                    bool isNotificationSaved = _Notification.Save();

                    if (isTransactionSaved && _Trans.TransactionID != -1 && isNotificationSaved && _Notification.NotificationID != -1)
                    {
                        MessageBox.Show("Deposit processed and recorded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _transactionsUC._RefreshTransactionsList();
                    }
                    else
                    {
                        
                        if (!isTransactionSaved || _Trans.TransactionID == -1)
                        {
                            MessageBox.Show("Deposit succeeded, but saving transaction log failed: " + _Trans.ErrorMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        if (!isNotificationSaved || _Notification.NotificationID == -1)
                        {
                            MessageBox.Show("Deposit succeeded, but saving Notification log failed: " + _Notification.ErrorMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }






                    CbAccount_SelectedIndexChanged(sender, e);
                    txtAmount.Text = string.Empty; 
                }
                else
                {
                    MessageBox.Show("Deposit failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
