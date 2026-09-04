using BankSystemBuisniseLayer;
using BankSystemDataAccess.Financial;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Bank_Managment_System
{
    public partial class UC_TransfersManagement : UserControl
    {

        ClsUser _User = new ClsUser();
        ClsNotification _Notification = new ClsNotification();
        int _currentCurrencyID = 0;
        public UC_TransfersManagement()
        {
            InitializeComponent();
           
        }

        private void UC_TransactionManage_Load(object sender, EventArgs e)
        {
            _Desing();
            _FillCustomerInformation();
            timer1.Start(); 
        }

        private void _Desing()
        {

            
            lblTitle.Image = IconChar.ExchangeAlt.ToBitmap(Color.DodgerBlue);


           
            SenderInformationIcone.Image = IconChar.UserShield.ToBitmap(Color.FromArgb(17, 24, 39), 35);
            reciverInformantionIcone.Image = IconChar.UserCheck.ToBitmap(Color.FromArgb(17, 24, 39), 35);

            PictCustomerIcone.Image = IconChar.User.ToBitmap(Color.DodgerBlue);
            PctAccountIcone.Image = IconChar.User.ToBitmap(Color.DodgerBlue);
            PictCustomerIcone1.Image = IconChar.UserTag.ToBitmap(Color.DodgerBlue);
            PictAmountIcone.Image = IconChar.MoneyBillWave.ToBitmap(Color.MediumSpringGreen);
            PctTransfer.Image = IconChar.ExchangeAlt.ToBitmap(Color.MediumPurple);



            txtSenderAccount.Image = IconChar.CreditCard.ToBitmap(Color.CornflowerBlue);
            txtReceiverAccount.Image = IconChar.CreditCard.ToBitmap(Color.CornflowerBlue);
            txtTransferDate.Image = IconChar.CalendarAlt.ToBitmap(Color.CornflowerBlue);
            txtTransferTime.Image = IconChar.Clock.ToBitmap(Color.CornflowerBlue);
            txtTransferDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            txtTransferDate.TextAlign = HorizontalAlignment.Center;
    //    txtTransferTime.Text = DateTime.Now.ToString("hh:mm:ss tt", CultureInfo.InvariantCulture);
            txtTransferTime.TextAlign = HorizontalAlignment.Center;


            CurrentBalanceIcone.Image = IconChar.Wallet.ToBitmap(Color.DodgerBlue);
            CurrentBalanceIcone1.Image = IconChar.Wallet.ToBitmap(Color.DodgerBlue);
            AfterTransferIcone.Image = IconChar.BalanceScale.ToBitmap(Color.MediumSpringGreen);
            AfterTransferIcone1.Image = IconChar.BalanceScale.ToBitmap(Color.MediumSpringGreen);

           
            btnConfirmTransfer.Image = IconChar.LongArrowAltRight.ToBitmap(Color.MediumSpringGreen); 
            btnCancel.Image = IconChar.TimesCircle.ToBitmap(Color.Crimson); 





        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            txtTransferTime.Text = DateTime.Now.ToString("hh:mm:ss tt", CultureInfo.InvariantCulture);

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


            CbSenderCustomer.DataSource = dtClients;
            CbSenderCustomer.DisplayMember = "Full Name";
            CbSenderCustomer.ValueMember = "Customer ID";
            CbSenderCustomer.MaxDropDownItems = 4;
            CbSenderCustomer.AutoCompleteSource = AutoCompleteSource.ListItems;
            CbSenderCustomer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

           
            CbReciverCustomer.DataSource = dtClients.Copy();
            CbReciverCustomer.DisplayMember = "Full Name";
            CbReciverCustomer.ValueMember = "Customer ID";
            CbReciverCustomer.MaxDropDownItems = 4;
            CbReciverCustomer.AutoCompleteSource = AutoCompleteSource.ListItems;
            CbReciverCustomer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;


        }

        private void CbSenderCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (CbSenderCustomer.SelectedIndex == -1 || CbSenderCustomer.SelectedValue == null)
                return;

            if (int.TryParse(CbSenderCustomer.SelectedValue.ToString(), out int CustomerID))

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

                    CbSenderAccount.DataSource = dtAccounts;
                    CbSenderAccount.DisplayMember = "AccountNumber";
                    CbSenderAccount.ValueMember = "AccountNumber";
                    CbSenderAccount.SelectedIndex = -1; 
                }
                else
                {
                    CbSenderAccount.DataSource = null;
                    txtSenderAccount.Text = string.Empty;
                    lblCurrentBalanceOfSender.Text = "0.00";
                }

            }

        }

        private void CbSenderAccount_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (CbSenderAccount.SelectedIndex == -1 || CbSenderAccount.SelectedValue == null)
                return;

            string senderAccountNumber = CbSenderAccount.SelectedValue.ToString();
            string errorMessage = string.Empty;
            txtSenderAccount.Text = senderAccountNumber;

            if (CbSenderAccount.SelectedItem is DataRowView row)
            {
               
                _currentCurrencyID = Convert.ToInt32(row["CurrencyID"]);
            }

            string senderCurrency = senderAccountNumber.Substring(senderAccountNumber.Length - 3);


            DataTable dtSenderDetails = ClsBalance.GetAccountDetailsByAccountNumber(senderAccountNumber, ref errorMessage);

            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dtSenderDetails != null && dtSenderDetails.Rows.Count > 0)
            {
                string AccountStatus = Convert.ToString(dtSenderDetails.Rows[0]["Account Status"]);
                double CurrentBalance = Convert.ToDouble(dtSenderDetails.Rows[0]["Current Balance (USD)"]);

                lblCurrentBalanceOfSender.Text = CurrentBalance.ToString("N2");

                if (AccountStatus == "Active")
                {
                    lblCurrentBalanceOfSender.ForeColor = Color.FromArgb(0, 192, 192);
                    txtSenderAccount.BorderColor = Color.FromArgb(0, 192, 192);
                    btnConfirmTransfer.Enabled = true;
                }
                else if (AccountStatus == "Dormant")
                {
                    MessageBox.Show("The selected account is dormant. Please contact the bank for assistance.", "Account Dormant", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lblCurrentBalanceOfSender.ForeColor = Color.Orange;
                    txtSenderAccount.BorderColor = Color.Orange;
                    btnConfirmTransfer.Enabled = false;
                }
                else if (AccountStatus == "Frozen")
                {
                    MessageBox.Show("The selected account is frozen. Please contact the bank for assistance.", "Account Frozen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lblCurrentBalanceOfSender.ForeColor = Color.Red;
                    txtSenderAccount.BorderColor = Color.Red;
                    btnConfirmTransfer.Enabled = false;
                }
                else
                {
                    MessageBox.Show("The selected account has an unknown status. Please contact the bank for assistance.", "Unknown Account Status", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lblCurrentBalanceOfSender.ForeColor = Color.Gray;
                    txtSenderAccount.BorderColor = Color.Gray;
                    btnConfirmTransfer.Enabled = false;
                }
            }

          
            DataTable dtAllAccountsAndClients = ClsAccount.GetAllAccounts(ref errorMessage);

            if (dtAllAccountsAndClients != null && dtAllAccountsAndClients.Rows.Count > 0)
            {
                DataView dvFiltered = dtAllAccountsAndClients.DefaultView;
                dvFiltered.RowFilter = $"[Account Number] LIKE '%{senderCurrency}' AND [Account Number] <> '{senderAccountNumber}'";

                CbReciverCustomer.DataSource = dvFiltered.ToTable();
                CbReciverCustomer.DisplayMember = "Customer Name";
                CbReciverCustomer.ValueMember = "Account Number";
                CbReciverCustomer.SelectedIndex = -1;
            }
        }

        private void CbReciverCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (CbReciverCustomer.SelectedIndex != -1 && CbReciverCustomer.SelectedValue != null)

            {

                string AccountNumber = CbReciverCustomer.SelectedValue.ToString();
                string errorMessage = string.Empty;
                txtReceiverAccount.Text = AccountNumber;

                DataTable dt = ClsBalance.GetAccountDetailsByAccountNumber(AccountNumber, ref errorMessage);

                if (!string.IsNullOrEmpty(errorMessage))
                {
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (dt != null && dt.Rows.Count > 0)
                {
                    string AccountStatus = Convert.ToString(dt.Rows[0]["Account Status"]);
                    double CurrentBalance = Convert.ToDouble(dt.Rows[0]["Current Balance (USD)"]);

                    lblCurrentBalanceOfReciver.Text = CurrentBalance.ToString("N2");

                    if (AccountStatus == "Active")

                    {

                        lblCurrentBalanceOfReciver.ForeColor = Color.FromArgb(0, 192, 192);
                        txtReceiverAccount.BorderColor = Color.FromArgb(0, 192, 192);


                        btnConfirmTransfer.Enabled = true;
                    }
                    else if (AccountStatus == "Dormant")


                    {
                        MessageBox.Show("The selected account is dormant. Please contact the bank for assistance.", "Account Dormant", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        lblCurrentBalanceOfReciver.ForeColor = Color.Orange;
                        txtReceiverAccount.BorderColor = Color.Orange;


                        btnConfirmTransfer.Enabled = false;
                    }
                    else if (AccountStatus == "Frozen")

                    {


                        MessageBox.Show("The selected account is frozen. Please contact the bank for assistance.", "Account Frozen", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        lblCurrentBalanceOfReciver.ForeColor = Color.Red;
                        txtReceiverAccount.BorderColor = Color.Red;


                        btnConfirmTransfer.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("The selected account has an unknown status. Please contact the bank for assistance.", "Unknown Account Status", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        lblCurrentBalanceOfReciver.ForeColor = Color.Gray;
                        txtReceiverAccount.BorderColor = Color.Gray;


                        btnConfirmTransfer.Enabled = false;
                    }
                }

            }

        }

        private void btnConfirmTransfer_Click(object sender, EventArgs e)
        {


            string ErrorMessage = string.Empty;
            ClsAccount senderAccount = ClsAccount.FindByAccountNumber(txtSenderAccount.Text.Trim(), ref ErrorMessage);
            ClsAccount receiverAccount = ClsAccount.FindByAccountNumber(txtReceiverAccount.Text.Trim(), ref ErrorMessage);


            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                MessageBox.Show(ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (senderAccount == null)
            {
                MessageBox.Show("Sender account not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (receiverAccount == null)
            {
                MessageBox.Show("Receiver account not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(txtTransferAmount.Text.Trim(), out decimal transferAmount) || transferAmount <= 0)
            {
                MessageBox.Show("Please enter a valid transfer amount.", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (senderAccount.AccountID == receiverAccount.AccountID)
            {
                MessageBox.Show("Cannot transfer funds to the same account!  Sender and receiver accounts are the same.", "Invalid Transfer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (senderAccount.Balance < transferAmount)
            {
                MessageBox.Show("Insufficient balance in the sender's account.", "Insufficient Balance", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to perform this transfer?", "Confirm Transfer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            _Notification.UserID = ClsGlobal.CurrentUser.UserID;
            _Notification.Title = "Transfer Notification";
            string senderAccountNumber = CbSenderAccount.SelectedValue.ToString();
            string senderCurrency = senderAccountNumber.Substring(senderAccountNumber.Length - 3);

            _Notification.Message = $"A transfer of {transferAmount:N2} {senderCurrency} has been made from account {senderAccount.AccountNumber} to account {receiverAccount.AccountNumber}.";
        

            if ( _Notification.Save())
            {
               // MessageBox.Show(ClsNotification.GetNotificationCount(ClsGlobal.CurrentUser.UserID, ref ErrorMessage).ToString());
            }
            else
            {
                MessageBox.Show("Failed to save notification: " + _Notification.ErrorMessage, "Notification Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            int currencyID = _currentCurrencyID;  
            string executedByUserID =  ClsGlobal.CurrentUser.UserID;
            int? performedByClientID = senderAccount.ClientID; 
            string description = $"Transfer from  {senderAccount.AccountNumber} to {receiverAccount.AccountNumber} Amount {transferAmount:C}";

        
            bool isSuccess = senderAccount.TransferTo(
                senderAccount,
                receiverAccount,
                transferAmount,
                currencyID,
                performedByClientID,
                executedByUserID,
                description
            );

            if (isSuccess)
            {
                MessageBox.Show("Transfer completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

               
                txtTransferAmount.Text = "0.00";
                txtReceiverAccount.Text = string.Empty;
                CbReciverCustomer.SelectedIndex = -1;
               // lblCurrentBalanceOfSender.Text = senderAccount.Balance.ToString("N2");
                lblAmountAftertransferOfsender.Text = senderAccount.Balance.ToString();
                lblAmountAftertransferOfReciver.Text = receiverAccount.Balance.ToString();
            }
            else
            {
                MessageBox.Show("Transfer failed: " + senderAccount.ErrorMessage, "Transfer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel?", "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                txtTransferAmount.Text = "0.00";
                txtReceiverAccount.Text = string.Empty;
                CbReciverCustomer.SelectedIndex = -1;
             
            }
        }
    }
}
