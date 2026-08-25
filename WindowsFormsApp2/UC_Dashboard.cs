using BankSystemBuisniseLayer;
using BankSystemBusinessLayer;
using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bank_Managment_System
{
    public partial class UC_Dashboard : UserControl
    {

       

        public UC_Dashboard()
        {
            InitializeComponent();

        }

        private void UserControlMainLogin_Load(object sender, EventArgs e)
        {

            this.DoubleBuffered = true;

            LoadDashboardMetrics();
            LoadTransactionsList();
            ApplyCleanGridViewStyle();
            SetupQuickActionButtons();


            cardTotalClientsicon.ImageAlign = HorizontalAlignment.Center;


            TotalClientIcone.IconChar = FontAwesome.Sharp.IconChar.Users;
            ActiveAccountIcone.IconChar = FontAwesome.Sharp.IconChar.UserCheck;
            TotalBalanceIcone.IconChar = FontAwesome.Sharp.IconChar.Wallet;
            TodayTransIcone.IconChar = FontAwesome.Sharp.IconChar.ExchangeAlt;
           


            ClsControls.ApplyZoomEffect(

                (TotalClientIcone, Color.FromArgb(142, 45, 226)),
                (ActiveAccountIcone, Color.FromArgb(34, 197, 94)),
                (TotalBalanceIcone, Color.FromArgb(234, 179, 8)),
                (TodayTransIcone, Color.FromArgb(168, 85, 247))

            );




        }

        private void LoadDashboardMetrics()


        {


            string errorMessage = string.Empty;

           


            int totalClients = ClsGetTotalClients.GetTotalClients(out errorMessage);
            lblTotalClients.Text = totalClients.ToString("N0");


            int activeAccounts = ClsGetActiveAccounts.GetActiveAccounts(out errorMessage);
            lblActiveAccount.Text = activeAccounts.ToString("N0");
           // MessageBox.Show(activeAccounts.ToString());

    
            lblTotalBalance.Text = $"$ {ClsGetTotalBalances.GetTotalBalance(out errorMessage).ToString("N0")}"; // or "CO" in yemen


            int todayTrans = ClsGetResults.GetTodayTransactions(out errorMessage);
            lblTodayTrans.Text = todayTrans.ToString("N0");


            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show($"حدث خطأ أثناء تحميل بيانات اللوحة: {errorMessage}",
                                "خطأ قاعدة البيانات",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

        }

        private void LoadTransactionsList()

        {

            string ErrorMessage = string.Empty;

            DataTable atTransactions = clsTransaction.GetTransactionsList(ref ErrorMessage);


            if (!string.IsNullOrEmpty (ErrorMessage))

            {

                ClsBankingNotification.ShowBankingNotification("Database Error", ErrorMessage, ClsBankingNotification.NotificationType.Error);
                return;

            }

           


            dgvRecentTransactions.DataSource = atTransactions;



        }

        private void guna2Panel4K_Paint(object sender, PaintEventArgs e)
        {

        }
  
        private void DataGradeView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {


            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string columnName = dgvRecentTransactions.Columns[e.ColumnIndex].Name;

            if (columnName == "TransactionStatus" || columnName == "Status")
            {
                string status = e.Value?.ToString();

                switch (status)
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

        }

        private void ApplyCleanGridViewStyle()


        {

           
            dgvRecentTransactions.EnableHeadersVisualStyles = false;
            dgvRecentTransactions.BackgroundColor = Color.FromArgb(15, 23, 42);
            dgvRecentTransactions.BorderStyle = BorderStyle.None;
            dgvRecentTransactions.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvRecentTransactions.GridColor = Color.FromArgb(30, 41, 59);
            dgvRecentTransactions.ScrollBars = ScrollBars.Both;

           
            dgvRecentTransactions.RowHeadersVisible = false;
            dgvRecentTransactions.AllowUserToResizeRows = false;
            dgvRecentTransactions.AllowUserToResizeColumns = false;

          
            dgvRecentTransactions.ColumnHeadersHeight = 40;
            dgvRecentTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvRecentTransactions.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59);
            dgvRecentTransactions.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvRecentTransactions.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            dgvRecentTransactions.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvRecentTransactions.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 5, 8, 5);
            dgvRecentTransactions.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

          
            dgvRecentTransactions.RowTemplate.Height = 35;
            dgvRecentTransactions.DefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
            dgvRecentTransactions.DefaultCellStyle.ForeColor = Color.White;
            dgvRecentTransactions.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 58, 138);
            dgvRecentTransactions.DefaultCellStyle.SelectionForeColor = Color.Cyan;
            dgvRecentTransactions.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            dgvRecentTransactions.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            
            dgvRecentTransactions.RowsDefaultCellStyle.Padding = new Padding(8, 2, 8, 2);

            dgvRecentTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


        }

        private void RecentDataGridView_CellPainting_1(object sender, DataGridViewCellPaintingEventArgs e)
        {


            if (e.RowIndex < 0 || e.ColumnIndex < 0 || dgvRecentTransactions.Rows[e.RowIndex].IsNewRow) return;

            
            if (dgvRecentTransactions.Columns.Contains("Type") &&
                dgvRecentTransactions.Columns[e.ColumnIndex].Name == "Type")
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                 
                string type = dgvRecentTransactions.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString() ?? "";

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

               
                using (Font iconFont = new Font("Segoe UI Symbol", 13, FontStyle.Bold))
                using (SolidBrush iconBrush = new SolidBrush(iconColor))
                {
                    PointF iconPos = new PointF(e.CellBounds.Left + 10, e.CellBounds.Top + (e.CellBounds.Height - 18) / 2);
                    e.Graphics.DrawString(iconSymbol, iconFont, iconBrush, iconPos);
                }

                using (SolidBrush textBrush = new SolidBrush(e.CellStyle.ForeColor))
                {
                    PointF textPos = new PointF(e.CellBounds.Left + 30, e.CellBounds.Top + (e.CellBounds.Height - 16) / 2);
                    e.Graphics.DrawString(type, e.CellStyle.Font, textBrush, textPos);
                }

                e.Handled = true;
            }

        }

        private void SetupQuickActionButtons()


        {


            btnNewClient.Image = IconChar.UserPlus.ToBitmap(Color.FromArgb(29, 0, 107), 30);
            btnNewClient.FillColor = Color.FromArgb(234, 232, 255);


            btnNewUser.Image = IconChar.UserPlus.ToBitmap(Color.FromArgb(13, 122, 19), 30);
            btnNewUser.FillColor = Color.FromArgb(232, 248, 234);


            btnNewDeposit.Image = IconChar.FileDownload.ToBitmap(Color.FromArgb(112, 0, 110), 30);
            btnNewDeposit.FillColor = Color.FromArgb(248, 232, 248);


            btnNewWithdraw.Image = IconChar.ArrowCircleUp.ToBitmap(Color.FromArgb(198, 83, 0), 30);
            btnNewWithdraw.FillColor = Color.FromArgb(255, 242, 226);


            btnNewTransfer.Image = IconChar.ExchangeAlt.ToBitmap(Color.FromArgb(0, 122, 122), 30);
            btnNewTransfer.FillColor = Color.FromArgb(229, 248, 248);


            btnCurrencyDiff.Image = IconChar.HandHoldingUsd.ToBitmap(Color.FromArgb(161, 0, 0), 30);
            btnCurrencyDiff.FillColor = Color.FromArgb(255, 234, 234);






           // //btnNewClient.ForeColor = Color.FromArgb(29, 0, 107);
           // // btnNewClient.Image = IconChar.UserPlus.ToBitmap(Color.FromArgb(29, 0, 107), 30);
           // btnNewClient.FillColor = Color.FromArgb(234, 232, 255);

           // // 2. New User (أخضر هادئ)
           // btnNewUser.FillColor = Color.FromArgb(232, 248, 234);
           //// btnNewUser.ForeColor = Color.FromArgb(13, 122, 19);
           //// btnNewUser.Image = IconChar.UserPlus.ToBitmap(Color.FromArgb(13, 122, 19), 30);

           //// // 3. New Deposit (وردي/بنفسجي هادئ)
           // btnNewDeposit.FillColor = Color.FromArgb(248, 232, 248);
           //// btnNewDeposit.ForeColor = Color.FromArgb(112, 0, 110);
           //// btnNewDeposit.Image = IconChar.FileDownload.ToBitmap(Color.FromArgb(112, 0, 110), 30);

           //// // 4. New Withdraw (برتقالي هادئ)
           // btnNewWithdraw.FillColor = Color.FromArgb(255, 242, 226);
           //// btnNewWithdraw.ForeColor = Color.FromArgb(198, 83, 0);
           //// btnNewWithdraw.Image = IconChar.ArrowCircleUp.ToBitmap(Color.FromArgb(198, 83, 0), 30);

           //// // 5. New Transfer (سماوي/تيركواز هادئ)
           // btnNewTransfer.FillColor = Color.FromArgb(229, 248, 248);
           //// btnNewTransfer.ForeColor = Color.FromArgb(0, 122, 122);
           //// btnNewTransfer.Image = IconChar.ExchangeAlt.ToBitmap(Color.FromArgb(0, 122, 122), 30);

           //// // 6. Currency Diff (أحمر هادئ)
           // btnCurrencyDiff.FillColor = Color.FromArgb(255, 234, 234);
           //// btnCurrencyDiff.ForeColor = Color.FromArgb(161, 0, 0);
           //// btnCurrencyDiff.Image = IconChar.HandHoldingUsd.ToBitmap(Color.FromArgb(161, 0, 0), 30);
        }

        private void btnViewAllClients_Click(object sender, EventArgs e)
        {

            ((FrmMain)this.FindForm()).LoadUserControl(new US_ViewAllClients("View All Clients"));

        }

        private void btnViewAllActiveAccounts_Click(object sender, EventArgs e)
        {

            ((FrmMain)this.FindForm()).LoadUserControl(new US_ViewAllClients("View All Active Accounts"));

        }

        private void btnViewTotalBalance_Click(object sender, EventArgs e)
        {

            ((FrmMain)this.FindForm()).LoadUserControl(new UC_TotalBalance());

        }

        private void btnViewAllTodayTrans_Click(object sender, EventArgs e)
        {

        }







        protected override CreateParams CreateParams


        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
                return cp;
            }
        }

    }
}
