using BankSystemBuisniseLayer;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Bank_Managment_System
{
    public partial class US_ViewAllClients : UserControl
    {

        public string Condition = string.Empty;
        public US_ViewAllClients(string ConditionType = "")
        {

            InitializeComponent();


            Condition = ConditionType;
        }


        private void US_ViewAllClients_Load(object sender, EventArgs e)
        {

            
            btnBacktoDashboardOverview.Image = IconChar.CircleArrowLeft.ToBitmap(Color.Red, 30);

            txtSearch.IconRight = IconChar.Search.ToBitmap(Color.Gray, 20);

            ApplyCleanGridViewStyle();


            switch (Condition)

            {


                case "View All Clients":
                    ViewAllClients(); 
                    lblTypeAction.Text = "All System Clients"; 
                    break;


                case "View All Active Accounts":
                    ViewAllActiveAccounts();
                    lblTypeAction.Text = "Active System Clients";
                    break;

            }

        }

        private void btnBacktoDashboardOverview_Click(object sender, EventArgs e)
        {
            ((FrmMain)this.FindForm()).LoadUserControl(new UC_Dashboard());
        }

        private void ViewAllClients()


        {

            string ErrorMessage = string.Empty;

            DataTable dtCustomers = ClsClient.GetClientsList(ref ErrorMessage);

            if (!string.IsNullOrEmpty(ErrorMessage))

            {
                ClsBankingNotification.ShowBankingNotification("Get List Customer", ErrorMessage, ClsBankingNotification.NotificationType.Error);
               
                return;
            }


            ClsImageSetting.GetCustoerImage(dtCustomers);


            DataGridViewAllClients.DataSource = dtCustomers;


            if (DataGridViewAllClients.Columns.Contains("Profile"))
            {
                DataGridViewAllClients.Columns["Profile"].Visible = false;
            }

            if (DataGridViewAllClients.Columns.Contains("ClientImage"))
            {
                DataGridViewImageColumn imgCol = (DataGridViewImageColumn)DataGridViewAllClients.Columns["ClientImage"];
                imgCol.HeaderText = "Profile";
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                imgCol.DisplayIndex = 0;
                imgCol.Width = 60;
            }


            DataGridViewAllClients.RowTemplate.Height = 50;


        }

        private void ViewAllActiveAccounts()

        {
            string ErrorMessage = string.Empty;


            DataTable dtViewAllClients = ClsClient.GetActiveAccounts(ref ErrorMessage);

            if (!string.IsNullOrEmpty(ErrorMessage))


            {
                ClsBankingNotification.ShowBankingNotification("Error", ErrorMessage, ClsBankingNotification.NotificationType.Error);
                return;
            }

            ClsImageSetting.GetCustoerImage(dtViewAllClients);

            DataGridViewAllClients.DataSource = dtViewAllClients;


            if (DataGridViewAllClients.Columns.Contains("Profile"))
            {
                DataGridViewAllClients.Columns["Profile"].Visible = false;
            }

            if (DataGridViewAllClients.Columns.Contains("ClientImage"))
            {
                DataGridViewImageColumn imgCol = (DataGridViewImageColumn)DataGridViewAllClients.Columns["ClientImage"];
                imgCol.HeaderText = "Profile";
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                imgCol.DisplayIndex = 0;
                imgCol.Width = 60;
            }


            DataGridViewAllClients.RowTemplate.Height = 50;



        }

        private void ApplyCleanGridViewStyle()


        {

            
            DataGridViewAllClients.EnableHeadersVisualStyles = false;

            DataGridViewAllClients.EnableHeadersVisualStyles = false;
            DataGridViewAllClients.BackgroundColor = Color.FromArgb(15, 23, 42);
            DataGridViewAllClients.BorderStyle = BorderStyle.None;
            DataGridViewAllClients.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            DataGridViewAllClients.GridColor = Color.FromArgb(30, 40, 60);

            DataGridViewAllClients.ColumnHeadersHeight = 40;
            DataGridViewAllClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
             DataGridViewAllClients.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 30, 50);
            DataGridViewAllClients.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DataGridViewAllClients.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
           // DataGridViewAllClients.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            DataGridViewAllClients.ColumnHeadersDefaultCellStyle.Padding = new Padding(12, 0, 12, 0);


            DataGridViewAllClients.RowTemplate.Height = 70;
            DataGridViewAllClients.DefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
            DataGridViewAllClients.DefaultCellStyle.ForeColor = Color.White;
            DataGridViewAllClients.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 58, 138);
            DataGridViewAllClients.DefaultCellStyle.SelectionForeColor = Color.Cyan;
            DataGridViewAllClients.DefaultCellStyle.Font = new Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            DataGridViewAllClients.DefaultCellStyle.WrapMode = DataGridViewTriState.False;


            DataGridViewAllClients.RowsDefaultCellStyle.Padding = new Padding(8, 8, 8, 8);
            DataGridViewAllClients.RowHeadersVisible = false;
            DataGridViewAllClients.AllowUserToResizeRows = false;
            DataGridViewAllClients.AllowUserToResizeColumns = true;
            DataGridViewAllClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DataGridViewAllClients.ScrollBars = ScrollBars.Both;
        }

        private void DataGridViewAllClients_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {



            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string columnName = DataGridViewAllClients.Columns[e.ColumnIndex].Name;

            if (columnName == "Status")
            {
                string status = e.Value?.ToString();

                switch (status)
                {
                    case "Active":
                    case "1":
                        e.CellStyle.ForeColor = Color.LimeGreen;
                        e.CellStyle.Font = new Font(DataGridViewAllClients.Font, System.Drawing.FontStyle.Bold);
                        break;

                    case "Inactive":
                    case "0":
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.Font = new Font(DataGridViewAllClients.Font, System.Drawing.FontStyle.Bold);
                        break;
                }
            }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            if (DataGridViewAllClients.DataSource is DataTable dt)

            {

                dt.CaseSensitive = false;

                string Text = txtSearch.Text.Trim();

                dt.DefaultView.RowFilter = string.IsNullOrEmpty(Text)
                    ? string.Empty
                    : string.Format("[Full Name] LIKE '%{0}%' OR [Email Address] LIKE '%{0}%' OR [Phone Number] LIKE '%{0}%'", Text);
            }

        }

        private void cmbFilterMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyClientsFilter();
        }


        private void ApplyClientsFilter()
        {
            if (DataGridViewAllClients.DataSource is DataTable dt)
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


        protected override CreateParams CreateParams


        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
                return cp;
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
