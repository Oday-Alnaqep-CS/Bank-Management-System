using BankSystemBusinessLayer;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_Managment_System
{
    public partial class UC_TransactionsManagement : UserControl
    {
        public UC_TransactionsManagement()
        {
            InitializeComponent();
        }

        private void UC_Transactions_Load(object sender, EventArgs e)
        {


           
            btnGoBack.Image = IconChar.ArrowLeft.ToBitmap(Color.FromArgb(255, 128, 128), 35);
            btnDeposit.Image = IconChar.ArrowCircleDown.ToBitmap(Color.FromArgb(0, 192, 192), 35);
            btnWithdraw.Image = IconChar.ArrowCircleUp.ToBitmap(Color.FromArgb(255, 128, 0), 35);


            btnGoBack.BorderColor = Color.FromArgb(255, 128, 128);


            btnDeposit.BorderColor = Color.FromArgb(0, 192, 192);


            btnWithdraw.BorderColor = Color.FromArgb(255, 128, 0);

            txtSearch.IconRight = IconChar.Search.ToBitmap(Color.Gray, 20);

            TransactionManagementIcone.Image = IconChar.ListUl.ToBitmap(Color.DodgerBlue);
            ; _ApplyCleanGridViewStyle();
            _LoadTransactionsList();
        }

        private void _ApplyCleanGridViewStyle()


        {

            DataGridViewAllTransactions.EnableHeadersVisualStyles = false;
            DataGridViewAllTransactions.BackgroundColor = Color.FromArgb(15, 23, 42);
            DataGridViewAllTransactions.BorderStyle = BorderStyle.None;
            DataGridViewAllTransactions.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            DataGridViewAllTransactions.GridColor = Color.FromArgb(45, 60, 80);


            DataGridViewAllTransactions.ColumnHeadersHeight = 40;
            DataGridViewAllTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            DataGridViewAllTransactions.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 30, 50);
            DataGridViewAllTransactions.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DataGridViewAllTransactions.ColumnHeadersDefaultCellStyle.Font = new Font("Georgia", 12F, FontStyle.Bold);
            DataGridViewAllTransactions.ColumnHeadersDefaultCellStyle.Padding = new Padding(12, 0, 12, 0);


            DataGridViewAllTransactions.RowTemplate.Height = 30;
            DataGridViewAllTransactions.DefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
            DataGridViewAllTransactions.DefaultCellStyle.ForeColor = Color.White;
            DataGridViewAllTransactions.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 58, 138);
            DataGridViewAllTransactions.DefaultCellStyle.SelectionForeColor = Color.Cyan;
            DataGridViewAllTransactions.DefaultCellStyle.Font = new Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
            DataGridViewAllTransactions.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            // Change size of Image 
            DataGridViewAllTransactions.RowsDefaultCellStyle.Padding = new Padding(3, 3, 3, 3);


            DataGridViewAllTransactions.RowHeadersVisible = false;
            DataGridViewAllTransactions.AllowUserToResizeRows = false;
            DataGridViewAllTransactions.AllowUserToResizeColumns = true;
            DataGridViewAllTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DataGridViewAllTransactions.ScrollBars = ScrollBars.Both;


         
        }

        private void _LoadTransactionsList()

        {

            string ErroeMessage = string.Empty;

            DataTable dtTransactions = clsTransaction.GetTransactionsList(ref ErroeMessage);

            if (!string.IsNullOrEmpty(ErroeMessage))
            {
                MessageBox.Show(ErroeMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataGridViewAllTransactions.DataSource = dtTransactions;
            DataGridViewAllTransactions.RowTemplate.Height = 35;
        }

        public void _RefreshTransactionsList()

        {
            _LoadTransactionsList();
        }

        private void DataGridViewAllTransactions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            string ColumnName = DataGridViewAllTransactions.Columns[e.ColumnIndex].Name;

            if (ColumnName == "TransactionStatus" || ColumnName == "Status")

            {

               string Status = e.Value?.ToString();

                switch(Status)

                {
                    case "Success":
                    case "1":
                        //   e.CellStyle.BackColor = Color.FromArgb(40, 0, 100, 0);
                        e.CellStyle.ForeColor = Color.LimeGreen;
                        break;

                    case "Pending":
                    case "3":
                        //  e.CellStyle.BackColor = Color.FromArgb(40, 200, 100, 0);
                        e.CellStyle.ForeColor = Color.Orange;
                        break;

                    case "Cancelled":
                    case "2":
                        //  e.CellStyle.BackColor = Color.FromArgb(40, 100, 100, 100);
                        e.CellStyle.ForeColor = Color.Gray;
                        break;

                    case "Failed":
                    default:
                        //   e.CellStyle.BackColor = Color.FromArgb(40, 150, 0, 0);
                        e.CellStyle.ForeColor = Color.Crimson;
                        break;
                }
            }


            if (ColumnName == "Date & Time" && e.Value != null)
            {
                if (DateTime.TryParse(e.Value.ToString(), out DateTime dt))
                {
                    e.Value = dt.ToString("MMM  d  yyyy  h : mm  tt", new System.Globalization.CultureInfo("en-US"));
                    e.FormattingApplied = true;
                }
            }


            if (ColumnName == "Amount")

            {
                int Balacnce = Convert.ToInt32( e.Value);

                if (Balacnce < 0 || Balacnce == 0)
                {

                    e.CellStyle.ForeColor = Color.Red;
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Green;

                }
            }
        }

        private void DataGridViewAllTransactions_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (DataGridViewAllTransactions.Columns[e.ColumnIndex].Name == "Type")
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);


                string type = DataGridViewAllTransactions.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString() ?? "";

                string iconSymbol = "";
                Color iconColor = Color.White;


                switch (type)
                {
                    case "Deposit":
                    case "Cash Deposit":
                        iconSymbol = "↓";
                        iconColor = Color.LimeGreen;
                        break;

                    case "Withdraw":
                    case "Cash Withdrawal":
                        iconSymbol = "↑";
                        iconColor = Color.Crimson;
                        break;

                    case "Transfer":
                    case "Internal Account Transfer":
                        iconSymbol = "⇆";
                        iconColor = Color.Gold;
                        break;

                    case "External Bank Transfer":
                        iconSymbol = "➔";
                        iconColor = Color.DeepSkyBlue;
                        break;

                    case "Loan Installment Payment":
                        iconSymbol = "↻";
                        iconColor = Color.MediumOrchid;
                        break;

                    case "POS Purchase":
                        iconSymbol = "🛒"; // أو "💳"
                        iconColor = Color.Teal;
                        break;

                    default:
                        iconSymbol = "•";
                        iconColor = Color.Gray;
                        break;
                }


                using (Font iconFont = new Font("Segoe UI Symbol", 15, FontStyle.Bold))
                using (SolidBrush iconBrush = new SolidBrush(iconColor))
                {
                    PointF iconPos = new PointF(e.CellBounds.Left + 10, e.CellBounds.Top + (e.CellBounds.Height - 18) / 2);
                    e.Graphics.DrawString(iconSymbol, iconFont, iconBrush, iconPos);
                }

                using (SolidBrush textBrush = new SolidBrush(e.CellStyle.ForeColor))
                {
                    PointF textPos = new PointF(e.CellBounds.Left + 40, e.CellBounds.Top + (e.CellBounds.Height - 16) / 2);
                    e.Graphics.DrawString(type, e.CellStyle.Font, textBrush, textPos);
                }

                e.Handled = true;
            }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (DataGridViewAllTransactions.DataSource is DataTable dt) 
            {

                dt.CaseSensitive = true;

                string Text = txtSearch.Text.Trim();

                dt.DefaultView.RowFilter = string.IsNullOrEmpty(Text)
                    ? string.Empty
                    : string.Format("[Type] LIKE '%{0}%' OR [From Customer Name] LIKE '%{0}%' OR [Account NO.] LIKE '%{0}%' OR [To Customer Name] LIKE '%{0}%'", Text);
            }
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {

            if (!ClsPermission.CheckUserPermission(ClsGlobal.CurrentUser.UserID, ClsPermission.enPermissions.Perform_Deposit.ToString()))
            {
                ClsBankingNotification.ShowBankingNotification("Access Denied","You do not have the required permissions to perform this action.",
                                                                   ClsBankingNotification.NotificationType.Error );
                return;
            }

            FrmDeposit frm = new FrmDeposit(this);
            frm.ShowDialog();
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {

            if (!ClsPermission.CheckUserPermission(ClsGlobal.CurrentUser.UserID, ClsPermission.enPermissions.Perform_Withdrawal.ToString()))
            {
                ClsBankingNotification.ShowBankingNotification("Access Denied", "You do not have the required permissions to perform this action.",
                                                                   ClsBankingNotification.NotificationType.Error);
                return;
            }

            FrmWithdraw frm = new FrmWithdraw(this);
            frm.ShowDialog();
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            ((FrmMain)this.FindForm()).LoadUserControl(new UC_Dashboard());
        }

        private void cmbFilterMain_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (DataGridViewAllTransactions.DataSource is DataTable dt)
            {
                
                string selectedValue = cmbFilterMain.SelectedItem?.ToString();
                string Filter = string.Empty;

                 
                if (!string.IsNullOrEmpty(selectedValue) && selectedValue != "All")
                {
                     
                    switch (selectedValue)
                    {
                        case "Deposit":
                            Filter = "Type = 'Deposit'";
                            break;

                        case "Withdraw":
                            Filter = "Type = 'Withdraw'";
                            break;

                        case "Transfer":
                            Filter = "Type = 'Transfer'";
                            break;

                        case "External Bank Transfer":
                            Filter = "Type = 'External Bank Transfer'";
                            break;

                        case "Loan Installment Payment":
                            Filter = "Type = 'Loan Installment Payment'";
                            break;

                        case "POS Purchase":
                            Filter = "Type = 'POS Purchase'";
                            break;

                        default:
                            Filter = string.Empty;
                            break;
                    }
                }
                else
                {
                    Filter = string.Empty;
                }

                 
                dt.DefaultView.RowFilter = Filter;
            }
        }
    }
}
