using BankSystemBuisniseLayer;
using BankSystemBusinessLayer;
using BankSystemDataAccess.Financial;
using FontAwesome.Sharp;
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
    public partial class FrmWithdraw : Form
    {

        ClsAccount _Account = new ClsAccount();
        UC_TransactionsManagement _Transaction = new UC_TransactionsManagement();
        clsTransaction _Trans = new clsTransaction();
        ClsNotification _Notification = new ClsNotification();
        private UC_TransactionsManagement _transactionsUC;

        public FrmWithdraw(UC_TransactionsManagement transactionsUC)
        {
            InitializeComponent();
           _transactionsUC = transactionsUC;
        }

        private void FrmWithdraw_Load(object sender, EventArgs e)
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
            ToplblIcone.Image = IconChar.Upload.ToBitmap(Color.MediumOrchid);
            AfterWithdrawIcone.Image = IconChar.BalanceScale.ToBitmap(Color.MediumSpringGreen);
            btnConfirmWithdraw.Image = IconChar.ArrowRightToBracket.ToBitmap(Color.MediumSpringGreen);
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

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            txtTransferTime.Text = DateTime.Now.ToString("hh:mm:ss tt", CultureInfo.InvariantCulture);
            // lblAmountAfterDeposit.Text = txtAmount.Value.ToString();
        }

        private void CbCustomer_SelectedIndexChanged(object sender, EventArgs e)
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
                    lblCurrentBalanceOfAccount.Text = "0.00";
                }

            }
        }

        private void CbAccount_SelectedIndexChanged_1(object sender, EventArgs e)
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

                lblCurrentBalanceOfAccount.Text = CurrentBalance.ToString("N2");

                if (AccountStatus == "Active")
                {
                    lblCurrentBalanceOfAccount.ForeColor = Color.FromArgb(0, 192, 192);
                    txtAccount.BorderColor = Color.FromArgb(0, 192, 192);
                    btnConfirmWithdraw.Enabled = true;
                }
                else if (AccountStatus == "Dormant")
                {
                    MessageBox.Show("The selected account is dormant. Please contact the bank for assistance.", "Account Dormant", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lblCurrentBalanceOfAccount.ForeColor = Color.Orange;
                    txtAccount.BorderColor = Color.Orange;
                    btnConfirmWithdraw.Enabled = false;
                }
                else if (AccountStatus == "Frozen")
                {
                    MessageBox.Show("The selected account is frozen. Please contact the bank for assistance.", "Account Frozen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lblCurrentBalanceOfAccount.ForeColor = Color.Red;
                    txtAccount.BorderColor = Color.Red;
                    btnConfirmWithdraw.Enabled = false;
                }
                else
                {
                    MessageBox.Show("The selected account has an unknown status. Please contact the bank for assistance.", "Unknown Account Status", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lblCurrentBalanceOfAccount.ForeColor = Color.Gray;
                    txtAccount.BorderColor = Color.Gray;
                    btnConfirmWithdraw.Enabled = false;
                }
            }

        }

        private void txtAmount_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnConfirmWithdraw_Click(object sender, EventArgs e)
        {
            if (CbAccount.SelectedIndex == -1 || string.IsNullOrEmpty(txtAccount.Text))
            {
                MessageBox.Show("Please select a valid account first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


          
            if (!decimal.TryParse(txtAmount.Text, out decimal WithdrawAmount) || WithdrawAmount <= 0)
            {
                MessageBox.Show("Please enter a valid Withdraw amount.", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return;
            }

            decimal CurrentAmount = Convert.ToDecimal(lblCurrentBalanceOfAccount.Text); 

            if (WithdrawAmount > CurrentAmount)

            {
                if (WithdrawAmount > CurrentAmount)
                {
                    MessageBox.Show($"You cannot withdraw an amount bigger than ({CurrentAmount}). " +
                        "Please enter a valid withdraw amount.", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAmount.Focus();
                    return;
                }
            }

            string accountNumber = txtAccount.Text;
            string errorMessage = string.Empty;


            DialogResult result = MessageBox.Show(
                $"Are you sure you want to Withdraw ${WithdrawAmount:N2} from account [{accountNumber}]?",
                "Confirm Withdraw",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                string ErrorMessage = string.Empty;
                _Account = ClsAccount.FindByAccountNumber(accountNumber, ref ErrorMessage);

                if (_Account != null && _Account.Withdraw(WithdrawAmount))
                {

                    if (decimal.TryParse(lblCurrentBalanceOfAccount.Text, NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal currentBalance))
                    {
                        decimal totalAfterWithdraw = currentBalance - WithdrawAmount;
                        lblAmountAfterWithdraw.Text = totalAfterWithdraw.ToString("N2");
                    }

                    MessageBox.Show("Withdraw processed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    _Trans.FromAccountID = null;
                    _Trans.ToAccountID = _Account.AccountID;
                    _Trans.FromCustomerName = CbCustomer.Text;
                    _Trans.TransactionTypeID = 2;
                    _Trans.CurrencyID = _Account.CurrencyID;
                    _Trans.PerformedByClientID = _Account.ClientID;
                    _Trans.ExecutedByUserID = ClsGlobal.CurrentUser.UserID;
                    _Trans.Amount = WithdrawAmount;
                    _Trans.AmountAfter = Convert.ToDecimal(lblAmountAfterWithdraw.Text);
                    _Trans.Description = "Withdraw operation via system";


                    _Notification.Title = "Withdraw Notification";
                    _Notification.Message = $"Successfully withdraw ${WithdrawAmount:N2} from account [{accountNumber}].";
                    _Notification.UserID = ClsGlobal.CurrentUser.UserID;

                    bool isTransactionSaved = _Trans.Save();


                    bool isNotificationSaved = _Notification.Save();

                    if (isTransactionSaved && _Trans.TransactionID != -1 && isNotificationSaved && _Notification.NotificationID != -1)
                    {
                       
                        MessageBox.Show("Withdraw processed and recorded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (_transactionsUC == null)
                            return;
                        _transactionsUC._RefreshTransactionsList();

                    }
                    else
                    {

                        if (!isTransactionSaved || _Trans.TransactionID == -1)
                        {
                            MessageBox.Show("Withdraw succeeded, but saving transaction log failed: " + _Trans.ErrorMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        if (!isNotificationSaved || _Notification.NotificationID == -1)
                        {
                            MessageBox.Show("Withdraw succeeded, but saving Notification log failed: " + _Notification.ErrorMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }






                    CbAccount_SelectedIndexChanged_1(sender, e);
                    txtAmount.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Withdraw failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show( "Are you sure you want to cancel this process?","Confirm Cancel",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close(); 
            }


        }

    
    }
}

