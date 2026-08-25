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

             this.DoubleBuffered = true;
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

          
            DataTable dtViewAllClients = ClsClient.GetClientsList(ref ErrorMessage);

            if (!string.IsNullOrEmpty(ErrorMessage))


            {
                ClsBankingNotification.ShowBankingNotification("Error", ErrorMessage, ClsBankingNotification.NotificationType.Error);
                return;
            }

            if (dtViewAllClients != null)
            {
                
                dtViewAllClients.Columns.Add("ClientImage", typeof(Image));

                
                foreach (DataRow row in dtViewAllClients.Rows)


                {
                    string imagePath = row["Profile"] != DBNull.Value ? row["Profile"].ToString() : "";

                    if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))

                    {

                        row["ClientImage"] = Image.FromFile(imagePath);
                    }
                    else
                    {
                       
                        row["ClientImage"] = Properties.Resources.default_user;
                    }
                }

              

                DataGridViewAllClients.DataSource = dtViewAllClients;

                
                if (DataGridViewAllClients.Columns.Contains("Profile"))
                    DataGridViewAllClients.Columns["Profile"].Visible = false;

              
                if (DataGridViewAllClients.Columns.Contains("ClientImage"))
                {
                    DataGridViewAllClients.Columns["ClientImage"].HeaderText = "Profile";
                    DataGridViewAllClients.Columns["ClientImage"].DisplayIndex = 1;

                    var imageCol = (DataGridViewImageColumn)DataGridViewAllClients.Columns["ClientImage"];
                    imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                }

                
                DataGridViewAllClients.RowTemplate.Height = 90;
                DataGridViewAllClients.Columns["ClientImage"].Width = 80;
            }


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

            if (dtViewAllClients != null)
            {

                dtViewAllClients.Columns.Add("ClientImage", typeof(Image));


                foreach (DataRow row in dtViewAllClients.Rows)


                {
                    string imagePath = row["Profile"] != DBNull.Value ? row["Profile"].ToString() : "";

                    if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))

                    {

                        row["ClientImage"] = Image.FromFile(imagePath);
                    }
                    else
                    {

                        row["ClientImage"] = Properties.Resources.default_user;
                    }
                }



                DataGridViewAllClients.DataSource = dtViewAllClients;


                if (DataGridViewAllClients.Columns.Contains("Profile"))
                    DataGridViewAllClients.Columns["Profile"].Visible = false;


                if (DataGridViewAllClients.Columns.Contains("ClientImage"))
                {
                    DataGridViewAllClients.Columns["ClientImage"].HeaderText = "Profile";
                    DataGridViewAllClients.Columns["ClientImage"].DisplayIndex = 1;

                    var imageCol = (DataGridViewImageColumn)DataGridViewAllClients.Columns["ClientImage"];
                    imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                }


                DataGridViewAllClients.RowTemplate.Height = 90;
                DataGridViewAllClients.Columns["ClientImage"].Width = 80;
            }


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
                        //   e.CellStyle.BackColor = Color.FromArgb(40, 0, 100, 0);
                        e.CellStyle.ForeColor = Color.LimeGreen;
                        break;

                    case "Inactive":
                    case "0":
                        //  e.CellStyle.BackColor = Color.FromArgb(40, 200, 100, 0);
                        e.CellStyle.ForeColor = Color.Red;
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


            if (DataGridViewAllClients.DataSource is DataTable dt)


            {


                string selectedValue = cmbFilterMain.SelectedItem?.ToString() ?? "All Filters";
                DataView dv = dt.DefaultView;
                string search = txtSearch.Text.Trim().Replace("'", "''");

                string filter = string.Empty;

                
                if (string.IsNullOrEmpty(search))
                {
                    dv.RowFilter = string.Empty;
                    return;
                }

                switch (selectedValue)
                {
                    case "Client ID":
                        if (int.TryParse(search, out int id))
                            filter = $"[Client ID] = {id}";
                        else
                            filter = "[Client ID] = 0";
                        break;

                    case "Full Name":
                        filter = $"[Full Name] LIKE '%{search}%'";
                        break;

                    case "Country":
                        filter = $"[Country] LIKE '%{search}%'";
                        break;

                    case "Active":
                        filter = $"[Status] = 'Active' AND ([Full Name] LIKE '%{search}%' OR [Email Address] LIKE '%{search}%')";
                        break;

                    case "Inactive":
                        filter = $"[Status] = 'Inactive' AND ([Full Name] LIKE '%{search}%' OR [Email Address] LIKE '%{search}%')";
                        break;

                  
                    case "All Filters":
                    case "All":
                    default:
                        filter = $"[Full Name] LIKE '%{search}%' OR [Email Address] LIKE '%{search}%' OR [Phone Number] LIKE '%{search}%' OR [Country] LIKE '%{search}%'";
                        if (int.TryParse(search, out int searchId))
                        {
                            filter += $" OR [Client ID] = {searchId}";
                        }
                        break;
                }

                dv.RowFilter = filter;
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
