using BankSystemBuisniseLayer;
using FontAwesome.Sharp;
using Krypton.Toolkit;
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
    public partial class UC_CustomersManage : UserControl
    {
        
        public UC_CustomersManage()
        {
            InitializeComponent();
        }

        private void US_CustomersManage_Load(object sender, EventArgs e)
        {

            Icones_Setting();
            LoadSupData();
            ApplyCleanGridViewStyle();
            ViewAllcustomers();

        }

        private void Icones_Setting()

        {

            txtSearch.IconRight = IconChar.Search.ToBitmap(Color.Gray, 20);

            TotalCustomersIcon.IconChar = FontAwesome.Sharp.IconChar.Users;
            NewCustomersIcon.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            InActiveCustomerIcon.IconChar = FontAwesome.Sharp.IconChar.UserSlash;
            ActiveAccountIcone.IconChar = FontAwesome.Sharp.IconChar.UserCheck;
            TotalBalanceIcone.IconChar = FontAwesome.Sharp.IconChar.Wallet;


            TotalCustomersIcon.IconColor = Color.FromArgb(94, 148, 255);
            NewCustomersIcon.IconColor = Color.FromArgb(46, 196, 182);
            InActiveCustomerIcon.IconColor = Color.FromArgb(230, 57, 70);
            ActiveAccountIcone.IconColor = Color.FromArgb(162, 89, 255);
            TotalBalanceIcone.IconColor = Color.FromArgb(231, 111, 81);

            TotalCustomersIcon.BackColor = Color.Transparent;
            NewCustomersIcon.BackColor = Color.Transparent;
            InActiveCustomerIcon.BackColor = Color.Transparent;
            ActiveAccountIcone.BackColor = Color.Transparent;
            TotalBalanceIcone.BackColor = Color.Transparent;


            btnAddNewCustoer.Image = IconChar.UserPlus.ToBitmap(Color.Blue);
        }

        private void ApplyCleanGridViewStyle()


        {


            DataGridViewAllCustomers.EnableHeadersVisualStyles = false;

            DataGridViewAllCustomers.EnableHeadersVisualStyles = false;
            DataGridViewAllCustomers.BackgroundColor = Color.FromArgb(15, 23, 42);
            DataGridViewAllCustomers.BorderStyle = BorderStyle.None;
            DataGridViewAllCustomers.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            DataGridViewAllCustomers.GridColor = Color.FromArgb(30, 40, 60);

            DataGridViewAllCustomers.ColumnHeadersHeight = 40;
            DataGridViewAllCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            DataGridViewAllCustomers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 30, 50);
            DataGridViewAllCustomers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DataGridViewAllCustomers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            // DataGridViewAllClients.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            DataGridViewAllCustomers.ColumnHeadersDefaultCellStyle.Padding = new Padding(12, 0, 12, 0);


            DataGridViewAllCustomers.RowTemplate.Height = 70;
            DataGridViewAllCustomers.DefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
            DataGridViewAllCustomers.DefaultCellStyle.ForeColor = Color.White;
            DataGridViewAllCustomers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 58, 138);
            DataGridViewAllCustomers.DefaultCellStyle.SelectionForeColor = Color.Cyan;
            DataGridViewAllCustomers.DefaultCellStyle.Font = new Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            DataGridViewAllCustomers.DefaultCellStyle.WrapMode = DataGridViewTriState.False;


            DataGridViewAllCustomers.RowsDefaultCellStyle.Padding = new Padding(8, 8, 8, 8);
            DataGridViewAllCustomers.RowHeadersVisible = false;
            DataGridViewAllCustomers.AllowUserToResizeRows = false;
            DataGridViewAllCustomers.AllowUserToResizeColumns = true;
            DataGridViewAllCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DataGridViewAllCustomers.ScrollBars = ScrollBars.Both;
        }

        private void ApplyClientsFilter()
        {
            if (DataGridViewAllCustomers.DataSource is DataTable dt)
            {
                dt.CaseSensitive = false;
                string search = txtSearch.Text.Trim().Replace("'", "''");
                string selectedValue = cmbFilterMain.SelectedItem?.ToString() ?? "All Filters";

                string filter = string.Empty;

                switch (selectedValue)
                {
                    case "Client ID":
                        if (!string.IsNullOrEmpty(search))
                            filter = int.TryParse(search, out int id) ? $"[Client ID] = {id}" : "[Client ID] = 0";
                        break;

                    case "Full Name":
                        if (!string.IsNullOrEmpty(search))
                            filter = $"[Full Name] LIKE '%{search}%'";
                        break;

                    case "Country":
                        if (!string.IsNullOrEmpty(search))
                            filter = $"[Country] LIKE '%{search}%'";
                        break;

                    case "Active":
                        filter = "[Status] = 'Active'";
                        if (!string.IsNullOrEmpty(search))
                            filter += $" AND ([Full Name] LIKE '%{search}%' OR [Email Address] LIKE '%{search}%')";
                        break;

                    case "Inactive":
                        filter = "[Status] = 'Inactive'";
                        if (!string.IsNullOrEmpty(search))
                            filter += $" AND ([Full Name] LIKE '%{search}%' OR [Email Address] LIKE '%{search}%')";
                        break;

                    case "All Filters":
                    case "All":
                    default:
                        if (!string.IsNullOrEmpty(search))
                        {
                            filter = $"[Full Name] LIKE '%{search}%' OR [Email Address] LIKE '%{search}%' OR [Phone Number] LIKE '%{search}%' OR [Country] LIKE '%{search}%'";
                            if (int.TryParse(search, out int searchId))
                                filter += $" OR [Client ID] = {searchId}";
                        }
                        break;
                }

                dt.DefaultView.RowFilter = filter;
            }
        }

        private void LoadSupData()

        {

            string ErrorMessage = string.Empty;

            lblTotalCustomers.Text = ClsGetTotalClients.GetTotalClients(out ErrorMessage).ToString();
            lblNewcustomers.Text = ClsTotalNewCustomerBu.GetTotalNewCustomer(ref ErrorMessage).ToString();
            lblInActiveCustomer.Text = ClsGetStatuOfCustomers.GetCountOfInActiveAccounts(out ErrorMessage).ToString();
            lblActiveCustomer.Text = ClsGetStatuOfCustomers.GetCountOfActiveAccounts(out ErrorMessage).ToString();
            lblTotalBalance.Text = $"$ {ClsGetTotalBalances.GetTotalBalance(out ErrorMessage).ToString("N0")}";       

        }

        private void ViewAllcustomers()

        {

            string ErrorMessage = string.Empty;

            DataTable dtCustomers = ClsGetAllCustomers.GetAllCustomersInFo(ref ErrorMessage);

            if (!string.IsNullOrEmpty(ErrorMessage))

            {
                ClsBankingNotification.ShowBankingNotification("Get List Customer", ErrorMessage, ClsBankingNotification.NotificationType.Error);
                MessageBox.Show(ErrorMessage);
                return;
            }

            ClsImageSetting.GetCustoerImage(dtCustomers);

            DataGridViewAllCustomers.DataSource = dtCustomers;

            
            if (DataGridViewAllCustomers.Columns.Contains("Profile"))
            {
                DataGridViewAllCustomers.Columns["Profile"].Visible = false; 
            }

            if (DataGridViewAllCustomers.Columns.Contains("ClientImage"))
            {
                DataGridViewImageColumn imgCol = (DataGridViewImageColumn)DataGridViewAllCustomers.Columns["ClientImage"];
                imgCol.HeaderText = "Profile";
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom; 
                imgCol.DisplayIndex = 0; 
                imgCol.Width = 60; 
            }

          
            DataGridViewAllCustomers.RowTemplate.Height = 50;
        }

        private void btnAddNewCustoer_Click(object sender, EventArgs e)
        {

            ((FrmMain)this.FindForm()).LoadUserControl(new UC_AddCustomer());
        }


        private void DataGridViewAllCustomers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {


            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string columnName = DataGridViewAllCustomers.Columns[e.ColumnIndex].Name;

           
            if (columnName == "Status")
            {
                string status = e.Value?.ToString();

                switch (status)
                {
                    case "Active":
                    case "1":
                        e.CellStyle.ForeColor = Color.LimeGreen;
                        e.CellStyle.Font = new Font(DataGridViewAllCustomers.Font, FontStyle.Bold);
                        break;

                    case "Inactive":
                    case "0":
                        e.CellStyle.ForeColor = Color.Red;  
                        e.CellStyle.Font = new Font(DataGridViewAllCustomers.Font, FontStyle.Bold);
                        break;
                }
            }
            
            else if (columnName == "Account Type" || columnName == "Account Type(s)")
            {

                string accountType = e.Value?.ToString();
                if (string.IsNullOrEmpty(accountType)) return;

                switch (accountType)

                {

                    case "Savings":
                        e.CellStyle.ForeColor = Color.FromArgb(56, 189, 248);  
                        break;

                    case "Checking":
                        e.CellStyle.ForeColor = Color.FromArgb(251, 146, 60);  
                        break;

                    case "Corporate":
                        e.CellStyle.ForeColor = Color.FromArgb(250, 204, 21);  
                        e.CellStyle.Font = new Font(DataGridViewAllCustomers.Font, FontStyle.Bold);
                        break;

                    case "Payroll":
                        e.CellStyle.ForeColor = Color.FromArgb(168, 85, 247);  
                        break;

                    case "Weekly":
                        e.CellStyle.ForeColor = Color.FromArgb(45, 212, 191);  
                        break;

                    case "No Accounts":
                        e.CellStyle.ForeColor = Color.Red;  
                        break;

                }
            }

            else if (columnName == "Total Balance (USD)")
            {
                if (decimal.TryParse(e.Value?.ToString(), out decimal balance))
                {
                    e.Value = balance.ToString("N2") + " $"; 
                    e.FormattingApplied = true;

                    if (balance >= 100000)
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(45, 212, 191);  
                        e.CellStyle.Font = new Font(DataGridViewAllCustomers.Font, FontStyle.Bold);
                    }
                }
            }
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

        private void guna2Panel4K_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
