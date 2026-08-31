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
using System.Windows.Documents;
using System.Windows.Forms;


namespace Bank_Managment_System
{
    public partial class US_UsersManagement : UserControl
    {
         
        private ContextMenuStrip cmsActions = new ContextMenuStrip();

        public US_UsersManagement()
        {
            InitializeComponent();
        }

        private void US_UsersManagement_Load(object sender, EventArgs e)
        {

            string ErrorMessage = string.Empty;

            _Icones_Setting();
            _ApplyCleanGridViewStyle();
            _LoadViewAllUsers();
            // _SetupContextMenu();
            // _AddSingleActionsColumn();
            //  _LoadTemporaryData();

            lblTotalUsers.Text = ClsUser.GetCountOfAllUsers(out ErrorMessage).ToString();
            lblActiveUsers.Text = ClsUser.GetCountOfActiveUsers(out ErrorMessage).ToString();
            lblInActiveUsers.Text = ClsUser.GetCountOfInActiveUsers(out ErrorMessage).ToString();
            lblTotalRoles.Text = ClsUser.GetCountOfUsersRoles(out ErrorMessage).ToString();

        }

        private void _Icones_Setting()

        {


            TotalUsersIcon.IconChar = FontAwesome.Sharp.IconChar.Users;
            InActiveUsersIcon.IconChar = FontAwesome.Sharp.IconChar.UserSlash;
            ActiveUsersIcone.IconChar = FontAwesome.Sharp.IconChar.UserCheck;
            TotalRolesIcone.IconChar = FontAwesome.Sharp.IconChar.UserShield; 

           
            TotalUsersIcon.IconColor = Color.RoyalBlue;              
            ActiveUsersIcone.IconColor = Color.MediumSpringGreen;    
            InActiveUsersIcon.IconColor = Color.Crimson;             
            TotalRolesIcone.IconColor = Color.MediumSlateBlue;

         
            btnAddNewUser.Image = IconChar.UserPlus.ToBitmap(Color.Blue);
        }

        private void _ApplyCleanGridViewStyle()


        {

            DataGridViewAllUsere.EnableHeadersVisualStyles = false;
            DataGridViewAllUsere.BackgroundColor = Color.FromArgb(15, 23, 42);
            DataGridViewAllUsere.BorderStyle = BorderStyle.None;
            DataGridViewAllUsere.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            DataGridViewAllUsere.GridColor = Color.FromArgb(30, 40, 60);


            DataGridViewAllUsere.ColumnHeadersHeight = 50;
            DataGridViewAllUsere.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            DataGridViewAllUsere.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 30, 50);
            DataGridViewAllUsere.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DataGridViewAllUsere.ColumnHeadersDefaultCellStyle.Font = new Font("Georgia", 12F, FontStyle.Bold);
            DataGridViewAllUsere.ColumnHeadersDefaultCellStyle.Padding = new Padding(12, 0, 12, 0);/* Century Schoolbook; 13pt; style = Bold*/


            DataGridViewAllUsere.RowTemplate.Height = 80;
            DataGridViewAllUsere.DefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);/*Segoe UI Semibold*/
            DataGridViewAllUsere.DefaultCellStyle.ForeColor = Color.White;
            DataGridViewAllUsere.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 58, 138);
            DataGridViewAllUsere.DefaultCellStyle.SelectionForeColor = Color.Cyan;
            DataGridViewAllUsere.DefaultCellStyle.Font = new Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            DataGridViewAllUsere.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            // Change size of Image 
            DataGridViewAllUsere.RowsDefaultCellStyle.Padding = new Padding(2, 2, 2, 2);


            DataGridViewAllUsere.RowHeadersVisible = false;
            DataGridViewAllUsere.AllowUserToResizeRows = false;
            DataGridViewAllUsere.AllowUserToResizeColumns = true;
            DataGridViewAllUsere.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DataGridViewAllUsere.ScrollBars = ScrollBars.Both;


            if (DataGridViewAllUsere.Columns["Profile"] is DataGridViewImageColumn imgCol)
            {
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                imgCol.Width = 90;
            }
        }

        private void _ApplyRolesFilter()
        {
            if (DataGridViewAllUsere.DataSource is DataTable dt)
            {
                dt.CaseSensitive = false;

                string selectedValue = cmbFilterMain.SelectedItem?.ToString() ?? "All";
                string filter = string.Empty;

                switch (selectedValue)
                {
                    case "Full Admin (ALL)":
                    case "System Developer":
                    case "Branch Supervisor":
                    case "Teller / Operations":
                    case "Loan Analyst":
                       
                        filter = $"[Role / Permissions] = '{selectedValue}'";
                        break;

                    case "All":
                    default:
                        filter = string.Empty; 
                        break;
                }

                dt.DefaultView.RowFilter = filter;
            }
        }

        private void _ApplyStatusFilter()
        {
            if (DataGridViewAllUsere.DataSource is DataTable dt)
            {
                dt.CaseSensitive = false;

                string selectedValue = cbFilterStatus.SelectedItem?.ToString() ?? "All";
                string filter = string.Empty;

                switch (selectedValue)
                {
            
                    case "Active":
                        filter = "[Status] = 'Active'";
                        break;

                    case "InActive":
                        filter = "[Status] = 'InActive'";
                        break;

                   
                    case "All Status":
                    case "All":
                    default:
                        filter = string.Empty;
                        break;
                }

                dt.DefaultView.RowFilter = filter;
            }
        }

        private void _LoadViewAllUsers()

        {
            string ErrorMessage = string.Empty;

            DataTable dtUsers = ClsUser.GetAllUsers(ref ErrorMessage);

            if (!string.IsNullOrEmpty(ErrorMessage))

            {
                ClsBankingNotification.ShowBankingNotification("Get List Users", ErrorMessage, ClsBankingNotification.NotificationType.Error);
                MessageBox.Show(ErrorMessage);
                return;
            }

            ClsImageSetting.GetImage(dtUsers);

            DataGridViewAllUsere.DataSource = dtUsers;

           
            if (DataGridViewAllUsere.Columns.Contains("Profile"))
            {
                DataGridViewAllUsere.Columns["Profile"].Visible = false;
            }

            if (DataGridViewAllUsere.Columns.Contains("Image"))
            {
                DataGridViewImageColumn imgCol = (DataGridViewImageColumn)DataGridViewAllUsere.Columns["Image"];
                imgCol.HeaderText = "Profile";
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                imgCol.DisplayIndex = 0;
                imgCol.Width = 60;
            }


            DataGridViewAllUsere.RowTemplate.Height = 50;

        }

        private void DataGridViewAllUsere_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {


            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string columnName = DataGridViewAllUsere.Columns[e.ColumnIndex].Name;

      
            if (columnName == "User Name" || columnName == "Username")
            {
                e.CellStyle.ForeColor = Color.FromArgb(56, 189, 248);
                e.CellStyle.Font = new Font(DataGridViewAllUsere.Font, FontStyle.Bold);
            }
           
            else if (columnName == "Status")
            {
                string status = e.Value?.ToString();

                switch (status)
                {
                    case "Active":
                    case "1":
                        e.CellStyle.ForeColor = Color.LimeGreen;
                        e.CellStyle.Font = new Font(DataGridViewAllUsere.Font, FontStyle.Bold);
                        break;

                    case "Inactive":
                    case "0":
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.Font = new Font(DataGridViewAllUsere.Font, FontStyle.Bold);
                        break;
                }
            }
          
            else if (columnName == "Role / Permissions" || columnName == "RoleName")
            {
                string roleName = e.Value?.ToString();
                if (string.IsNullOrEmpty(roleName)) return;

                switch (roleName)
                {
                    case "Full Admin (ALL)":
                        e.CellStyle.ForeColor = Color.FromArgb(168, 85, 247); 
                        e.CellStyle.Font = new Font(DataGridViewAllUsere.Font, FontStyle.Bold);
                        break;

                    case "System Developer":
                        e.CellStyle.ForeColor = Color.FromArgb(56, 189, 248);  
                        e.CellStyle.Font = new Font(DataGridViewAllUsere.Font, FontStyle.Bold);
                        break;

                    case "Branch Supervisor":
                        e.CellStyle.ForeColor = Color.FromArgb(163, 230, 53);  
                        e.CellStyle.Font = new Font(DataGridViewAllUsere.Font, FontStyle.Bold);
                        break;

                    case "Loan Analyst":
                        e.CellStyle.ForeColor = Color.FromArgb(250, 204, 21);  
                        e.CellStyle.Font = new Font(DataGridViewAllUsere.Font, FontStyle.Bold);
                        break;

                    case "Teller / Operations":
                        e.CellStyle.ForeColor = Color.FromArgb(45, 212, 191); 
                        e.CellStyle.Font = new Font(DataGridViewAllUsere.Font, FontStyle.Bold);
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
                        e.CellStyle.Font = new Font(DataGridViewAllUsere.Font, FontStyle.Bold);
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

        }

        private void cmbFilterMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ApplyRolesFilter();
        }

        private void cbFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ApplyStatusFilter();
        }
    }
}
