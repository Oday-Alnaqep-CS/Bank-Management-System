using BankSystemBuisniseLayer;
using BankSystemBusinessLayer;
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
    public partial class UC_CustomersManagement : UserControl
    {

        ClsClient _Client = new ClsClient();
        public UC_CustomersManagement()
        {
            InitializeComponent();
          
        }

        private void US_CustomersManage_Load(object sender, EventArgs e)
        {
            
            _Icones_Setting();
            _LoadSupData(); 
            _ApplyCleanGridViewStyle();
            _ViewAllcustomers();
        }

        private void _Icones_Setting()

        {


            DeleteCustomer1.Image = IconChar.UserTimes.ToBitmap(Color.FromArgb(239, 68, 68));
            EditCustomer1.Image = IconChar.UserEdit.ToBitmap(Color.FromArgb(59, 130, 246));
            DeactiveCustomer.Image = IconChar.UserSlash.ToBitmap(Color.FromArgb(245, 158, 11));
            beActiveCustomer.Image = IconChar.UserCheck.ToBitmap(Color.FromArgb(16, 185, 129));
          //  LockedUser.Image = IconChar.Lock.ToBitmap(Color.FromArgb(255, 193, 7));

            txtSearch.IconRight = IconChar.Search.ToBitmap(Color.Gray, 20);

            TotalCustomersIcon.IconChar = FontAwesome.Sharp.IconChar.Users;
            NewCustomersIcon.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            InActiveCustomerIcon.IconChar = FontAwesome.Sharp.IconChar.UserSlash;
            ActiveAccountIcone.IconChar = FontAwesome.Sharp.IconChar.UserCheck;
            TotalBalanceIcone.IconChar = FontAwesome.Sharp.IconChar.Wallet;


            TotalCustomersIcon.IconColor = Color.FromArgb(94, 148, 255);
            NewCustomersIcon.IconColor = Color.FromArgb(46, 196, 182);
            ActiveAccountIcone.IconColor = Color.MediumSpringGreen;
            InActiveCustomerIcon.IconColor = Color.FromArgb(231, 76, 60);
            TotalBalanceIcone.IconColor = Color.FromArgb(231, 111, 81);






            TotalCustomersIcon.BackColor = Color.Transparent;
            NewCustomersIcon.BackColor = Color.Transparent;
            InActiveCustomerIcon.BackColor = Color.Transparent;
            ActiveAccountIcone.BackColor = Color.Transparent;
            TotalBalanceIcone.BackColor = Color.Transparent;


            btnAddNewCustoer.Image = IconChar.UserPlus.ToBitmap(Color.Blue);
        }

        private void _ApplyCleanGridViewStyle()


        {

            DataGridViewAllCustomers.EnableHeadersVisualStyles = false;
            DataGridViewAllCustomers.BackgroundColor = Color.FromArgb(15, 23, 42);
            DataGridViewAllCustomers.BorderStyle = BorderStyle.None;
            DataGridViewAllCustomers.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            DataGridViewAllCustomers.GridColor = Color.FromArgb(30, 40, 60);
             

            DataGridViewAllCustomers.ColumnHeadersHeight = 40;
            DataGridViewAllCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            DataGridViewAllCustomers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 30, 50);
            DataGridViewAllCustomers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DataGridViewAllCustomers.ColumnHeadersDefaultCellStyle.Font = new Font("Georgia", 11F, FontStyle.Bold);
            DataGridViewAllCustomers.ColumnHeadersDefaultCellStyle.Padding = new Padding(12, 0, 12, 0);

            
            DataGridViewAllCustomers.RowTemplate.Height = 70;
            DataGridViewAllCustomers.DefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
            DataGridViewAllCustomers.DefaultCellStyle.ForeColor = Color.White;
            DataGridViewAllCustomers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 58, 138);
            DataGridViewAllCustomers.DefaultCellStyle.SelectionForeColor = Color.Cyan;
            DataGridViewAllCustomers.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            DataGridViewAllCustomers.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            // Change size of Image 
            DataGridViewAllCustomers.RowsDefaultCellStyle.Padding = new Padding(3, 3, 3, 3);

           
            DataGridViewAllCustomers.RowHeadersVisible = false;
            DataGridViewAllCustomers.AllowUserToResizeRows = false;
            DataGridViewAllCustomers.AllowUserToResizeColumns = true;
            DataGridViewAllCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DataGridViewAllCustomers.ScrollBars = ScrollBars.Both;

           
            if (DataGridViewAllCustomers.Columns["Profile"] is DataGridViewImageColumn imgCol)
            {
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                imgCol.Width = 90;
            }
        }

        private void _ApplyClientsFilter()
        {
            if (DataGridViewAllCustomers.DataSource is DataTable dt)
            {
                dt.CaseSensitive = true;
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

        private void _LoadSupData()

        {

            string ErrorMessage = string.Empty;

            lblTotalCustomers.Text = ClsGetTotalClients.GetTotalClients(out ErrorMessage).ToString();
            lblNewcustomers.Text = ClsTotalNewCustomerBu.GetTotalNewCustomer(ref ErrorMessage).ToString();
            lblInActiveCustomer.Text = ClsGetStatuOfCustomers.GetCountOfInActiveCustomer(out ErrorMessage).ToString();
            lblActiveCustomer.Text = ClsGetStatuOfCustomers.GetCountOfActiveCustomer(out ErrorMessage).ToString();
            lblTotalBalance.Text = $"$ {ClsGetTotalBalances.GetTotalBalance(out ErrorMessage).ToString("N0")}";       

        }

        private void _ViewAllcustomers()

        {

            string ErrorMessage = string.Empty;

            DataTable dtCustomers = ClsGetAllCustomers.GetAllCustomersInFo(ref ErrorMessage);

            if (!string.IsNullOrEmpty(ErrorMessage))

            {
                ClsBankingNotification.ShowBankingNotification("Get List Customer", ErrorMessage, ClsBankingNotification.NotificationType.Error);
                MessageBox.Show(ErrorMessage);
                return;
            }

            ClsImageSetting.GetImage(dtCustomers);

            DataGridViewAllCustomers.DataSource = dtCustomers;

            
            if (DataGridViewAllCustomers.Columns.Contains("Profile"))
            {
                DataGridViewAllCustomers.Columns["Profile"].Visible = false; 
            }

            if (DataGridViewAllCustomers.Columns.Contains("Image"))
            {
                DataGridViewImageColumn imgCol = (DataGridViewImageColumn)DataGridViewAllCustomers.Columns["Image"];
                imgCol.HeaderText = "Profile";
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom; 
                imgCol.DisplayIndex = 0; 
                imgCol.Width = 60; 
            }

          
            DataGridViewAllCustomers.RowTemplate.Height = 50;
        }

        private void btnAddNewCustoer_Click(object sender, EventArgs e)
        {

            if (!ClsPermission.CheckUserPermission(ClsGlobal.CurrentUser.UserID, ClsPermission.enPermissions.Manage_Customers.ToString()))
            {
                ClsBankingNotification.ShowBankingNotification("Access Denied", "You do not have the required permissions to perform this action.",
                                                                   ClsBankingNotification.NotificationType.Error);
                return;
            }

            ((FrmMain)this.FindForm()).LoadUserControl(new UC_AddCustomer());
        }

        private void EditCustomer1_Click(object sender, EventArgs e)
        {
            if (!ClsPermission.CheckUserPermission(ClsGlobal.CurrentUser.UserID, ClsPermission.enPermissions.Manage_Customers.ToString()))
            {
                ClsBankingNotification.ShowBankingNotification("Access Denied", "You do not have the required permissions to perform this action.",
                                                                   ClsBankingNotification.NotificationType.Error);
                return;
            }

            if (DataGridViewAllCustomers.CurrentRow != null)

            {
                 int ClientID = Convert.ToInt32(DataGridViewAllCustomers.CurrentRow.Cells["Customer ID"].Value);
                ((FrmMain)this.FindForm()).LoadUserControl(new UC_AddCustomer(ClientID));

            }
        }

        private void DeleteCustomer1_Click(object sender, EventArgs e)
        {

            if (!ClsPermission.CheckUserPermission(ClsGlobal.CurrentUser.UserID, ClsPermission.enPermissions.Manage_Customers.ToString()))
            {
                ClsBankingNotification.ShowBankingNotification("Access Denied", "You do not have the required permissions to perform this action.",
                                                                   ClsBankingNotification.NotificationType.Error);
                return;
            }

            int ClientID = Convert.ToInt32(DataGridViewAllCustomers.CurrentRow.Cells["Customer ID"].Value);


            if (ClsGlobal.CurrentUser.UserName != "Oday Al-Naqeeb")
            {

                MessageBox.Show(
                                         "╔══════════════════════════════════════════════╗\n" +
                                         "║              ⚠️  ACCESS DENIED  ⚠️                            ║\n"+
                                         "╠══════════════════════════════════════════════╣\n" +
                                         "║                                                                                ║\n" +
                                         "║  You do not have permission to delete this              ║\n" + " "+
                                      "║  customer.                                                               ║\n" +
                                         "║                                                                                ║\n" +
                                        $"║   👤 Client ID: [ {ClientID} ]                                                   ║\n" +
                                         "║                                                                                ║\n" +
                                         "║  🔒 Only authorized administrators can                   ║\n" +
                                         "║     perform this action.                                             ║\n" +
                                         "║                                                                                ║\n" +
                                         "║  ⚠️ Deleting a customer is a high-risk                     ║\n" +
                                         "║     operation.                                                            ║\n" +
                                         "║                                                                                ║\n" +
                                         "╚══════════════════════════════════════════════╝",
                                         "Access Denied",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error
                                      );
                return;
            }
            if (DataGridViewAllCustomers.CurrentRow != null)

            {

                string ErrorMessage = string.Empty;

                _Client = ClsClient.Find(ClientID, ref ErrorMessage);

                if (_Client != null)
                {
                    int PersonID = _Client.PersonInfo.PersonID;

                    if (MessageBox.Show(
                                           $"Are you sure you want to permanently delete Client ID [ {ClientID} ]?\n\n" +
                                           "⚠️ WARNING: This action is irreversible and will delete:\n" +
                                           " 🔹 Client Profile & Personal Data\n" +
                                           " 🔹 All Linked Bank Accounts (Savings, Checking, etc.)\n" +
                                           " 🔹 All Transaction History & Records\n" +
                                           " 🔹 Associated Cards and System Logs",
                                           "Confirm Permanent Delete",
                                           MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Warning) == DialogResult.Yes)
                    {



                        if (ClsClient.ForceDeleteClient(ClientID, PersonID, ref ErrorMessage))
                        {
                            MessageBox.Show("Client deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _ViewAllcustomers();
                        }
                        else
                        {

                            MessageBox.Show($"Failed to delete client:\n{ErrorMessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }


                    }
                }
                else

                {
                    MessageBox.Show("Could not find client details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void _RefreshClientsList()

        {
            _ViewAllcustomers();
            _LoadSupData();
        }

        private void _ChangeClientStatus(byte status, string actionName)

        {
            if (!ClsPermission.CheckUserPermission(ClsGlobal.CurrentUser.UserID, ClsPermission.enPermissions.Manage_Customers.ToString()))
            {
                ClsBankingNotification.ShowBankingNotification("Access Denied", "You do not have the required permissions to perform this action.",
                                                                   ClsBankingNotification.NotificationType.Error);
                return;
            }

            string ErrorMessage = string.Empty;

            if (DataGridViewAllCustomers.CurrentRow != null)

            {

                int clientID = Convert.ToInt32(DataGridViewAllCustomers.CurrentRow.Cells["Customer ID"].Value);

                _Client = ClsClient.Find(clientID, ref ErrorMessage);

                if (_Client != null)
                {
                   
                    if (_Client.UpdateStatusOnly(status))
                    {
                        MessageBox.Show($"Client account has been {actionName} successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _RefreshClientsList();
                        DataGridViewAllCustomers.Refresh();
                    }
                    else
                    {
                        MessageBox.Show($"Failed to update client status:\n{_Client.ErrorMessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void cmbFilterMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ApplyClientsFilter();

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            if (DataGridViewAllCustomers.DataSource is DataTable dt)

            {

                dt.CaseSensitive = true;

                string Text = txtSearch.Text.Trim();

                dt.DefaultView.RowFilter = string.IsNullOrEmpty(Text)
                    ? string.Empty
                    : string.Format("[Full Name] LIKE '%{0}%' OR [Email Address] LIKE '%{0}%' OR [Phone Number] LIKE '%{0}%'", Text);
            }

        }

        private void DeactiveCustomer_Click(object sender, EventArgs e)
        {
            if (!ClsPermission.CheckUserPermission(ClsGlobal.CurrentUser.UserID, ClsPermission.enPermissions.Manage_Customers.ToString()))
            {
                ClsBankingNotification.ShowBankingNotification("Access Denied", "You do not have the required permissions to perform this action.",
                                                                   ClsBankingNotification.NotificationType.Error);
                return;
            }

            _ChangeClientStatus(0, "Deactivated");

        }

        private void beActiveCustomer_Click(object sender, EventArgs e)
        {
            if (!ClsPermission.CheckUserPermission(ClsGlobal.CurrentUser.UserID, ClsPermission.enPermissions.Manage_Customers.ToString()))
            {
                ClsBankingNotification.ShowBankingNotification("Access Denied", "You do not have the required permissions to perform this action.",
                                                                   ClsBankingNotification.NotificationType.Error);
                return;
            }

            _ChangeClientStatus(1, "Activated");
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

            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

           
            DataGridViewColumn column = DataGridViewAllCustomers.Columns[e.ColumnIndex];

          
            if (column.HeaderText == "Status")
            {
                string statusValue = e.Value?.ToString();

                if (statusValue == "Inactive" || statusValue == "0" || statusValue == "Deactive")
                {
                    
                    DataGridViewRow row = DataGridViewAllCustomers.Rows[e.RowIndex];
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        // cell.Style.BackColor = Color.FromArgb(32, 40, 50);
                        //cell.Style.BackColor = Color.FromArgb(42, 53, 70);
                         cell.Style.BackColor = Color.FromArgb(30, 53, 75);
                        //  cell.Style.BackColor = Color.FromArgb(50, 65, 85);
                    }
                }
            }


        }

        private void timer_Tick(object sender, EventArgs e)
        {
            _LoadSupData();
            //_ViewAllcustomers();
        }

        private void DataGridViewAllCustomers_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                DataGridViewAllCustomers.ClearSelection();
                DataGridViewAllCustomers.Rows[e.RowIndex].Selected = true;
                DataGridViewAllCustomers.CurrentCell = DataGridViewAllCustomers.Rows[e.RowIndex].Cells[e.ColumnIndex];
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

        private void DataGridViewAllCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
