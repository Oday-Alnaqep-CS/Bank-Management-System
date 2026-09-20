using BankSystemBuisniseLayer;
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
using System.Windows.Documents;
using System.Windows.Forms;


namespace Bank_Managment_System
{
    public partial class UC_UsersManagement : UserControl
    {
         
        private ContextMenuStrip cmsActions = new ContextMenuStrip();
        ClsUser _User = new ClsUser();
        public UC_UsersManagement()
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



            DeleteUser.Image = IconChar.UserTimes.ToBitmap(Color.FromArgb(239, 68, 68));     
            EditUser.Image = IconChar.UserEdit.ToBitmap(Color.FromArgb(59, 130, 246));       
            DeactiveUser.Image = IconChar.UserSlash.ToBitmap(Color.FromArgb(245, 158, 11));  
            ActivationUser.Image = IconChar.UserCheck.ToBitmap(Color.FromArgb(16, 185, 129));
            LockedUser.Image = IconChar.Lock.ToBitmap(Color.FromArgb(255, 193, 7)); 


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

        private void DataGridViewAllUsere_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
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


                    case "Inactive":
                    case "0":
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.Font = new Font(DataGridViewAllUsere.Font, FontStyle.Bold);
                        break;

                    case "Active":
                    case "1":
                        e.CellStyle.ForeColor = Color.LimeGreen;
                        e.CellStyle.Font = new Font(DataGridViewAllUsere.Font, FontStyle.Bold);
                        break;

                    case "Locked":
                    case "2":
                        e.CellStyle.ForeColor = Color.Orange;
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

            DataGridViewColumn column = DataGridViewAllUsere.Columns[e.ColumnIndex];

            if (column.HeaderText == "Status")
            {
                string statusValue = e.Value?.ToString();

                if (statusValue == "Inactive" || statusValue == "0" || statusValue == "Deactive")
                {

                    DataGridViewRow row = DataGridViewAllUsere.Rows[e.RowIndex];
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        // cell.Style.BackColor = Color.FromArgb(32, 40, 50);
                        cell.Style.BackColor = Color.FromArgb(42, 53, 70);
                        //cell.Style.BackColor = Color.FromArgb(30, 53, 75);
                        // cell.Style.BackColor = Color.FromArgb(50, 65, 85);
                    }
                }
            }
        }

        private void cmbFilterMain_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            _ApplyRolesFilter();
        }

        private void cbFilterStatus_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            _ApplyStatusFilter();
        }

        private void btnAddNewUser_Click_1(object sender, EventArgs e)
        {

            if (!ClsPermission.CheckUserPermission(ClsGlobal.CurrentUser.UserID, ClsPermission.enPermissions.Manage_Users.ToString()))
            {
                ClsBankingNotification.ShowBankingNotification("Access Denied", "You do not have the required permissions to perform this action.",
                                                                   ClsBankingNotification.NotificationType.Error);
                return;
            }

            ((FrmMain)this.FindForm()).LoadUserControl(new UC_AddUser());
        }

        private void _RefreshUserList()
        {
            _LoadViewAllUsers();
        }

        private void _ChaingUserStatus(byte newStatus, string ActionType)

        {

            if (!ClsPermission.CheckUserPermission(ClsGlobal.CurrentUser.UserID, ClsPermission.enPermissions.Manage_Users.ToString()))
            {
                ClsBankingNotification.ShowBankingNotification("Access Denied", "You do not have the required permissions to perform this action.",
                                                                   ClsBankingNotification.NotificationType.Error);
                return;
            }

            string ErrorMessage = string.Empty;

            if (DataGridViewAllUsere.CurrentRow != null)

            {

                string UserID = Convert.ToString(DataGridViewAllUsere.CurrentRow.Cells["User ID"].Value);
               // MessageBox.Show("ID Found: " + UserID);
                _User = ClsUser.Find(UserID, ref ErrorMessage);

                if (_User != null)

                {
                    if (_User.UpdateStatusOnly(newStatus))
                    {
                        MessageBox.Show($"User status changed to {ActionType} successfully.", "Change User Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _RefreshUserList();
                        DataGridViewAllUsere.Refresh();
                    }
                    else
                    {
                        MessageBox.Show($"Failed to change user status to {ActionType}. Error: {ErrorMessage}", "Change User Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                   
                }
                else
                {
                    MessageBox.Show($"Could not find User with ID: '{UserID}' in database! Error: {ErrorMessage}", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            

        }

        private void EditUser_Click_1(object sender, EventArgs e)
        {

            if (!ClsPermission.CheckUserPermission(ClsGlobal.CurrentUser.UserID, ClsPermission.enPermissions.Manage_Users.ToString()))
            {
                ClsBankingNotification.ShowBankingNotification("Access Denied", "You do not have the required permissions to perform this action.",
                                                                   ClsBankingNotification.NotificationType.Error);
                return;
            }

            string UserID = Convert.ToString(DataGridViewAllUsere.CurrentRow.Cells["User ID"].Value);
            ((FrmMain)this.FindForm()).LoadUserControl(new UC_AddUser(UserID));

        }

        private void DeleteUser_Click_1(object sender, EventArgs e)
        {

            if (!ClsPermission.CheckUserPermission(ClsGlobal.CurrentUser.UserID, ClsPermission.enPermissions.Manage_Users.ToString()))
            {
                ClsBankingNotification.ShowBankingNotification("Access Denied", "You do not have the required permissions to perform this action.",
                                                                   ClsBankingNotification.NotificationType.Error);
                return;
            }
            string ErrorMessage = string.Empty;
            if (DataGridViewAllUsere.CurrentRow != null)

            {
                string UserID = Convert.ToString(DataGridViewAllUsere.CurrentRow.Cells["User ID"].Value);
                MessageBox.Show("ID Found: " + UserID);

                _User = ClsUser.Find(UserID, ref ErrorMessage);
                if (_User != null)
                {
                    var confirmResult = MessageBox.Show($"Are you sure to delete user '{_User.UserName}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirmResult == DialogResult.Yes)

                    {

                        if (ClsUser.DeleteUser(UserID, ref ErrorMessage))

                        {
                            MessageBox.Show($"User '{_User.UserName}' deleted successfully.", "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _RefreshUserList();
                        }
                        else
                        {
                            MessageBox.Show($"Failed to delete user '{_User.UserName}'. Error: {ErrorMessage}", "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"Could not find User with ID: '{UserID}' in database!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void ActivationUser_Click_1(object sender, EventArgs e)
        {
            if (!ClsPermission.CheckUserPermission(ClsGlobal.CurrentUser.UserID, ClsPermission.enPermissions.Manage_Users.ToString()))
            {
                ClsBankingNotification.ShowBankingNotification("Access Denied", "You do not have the required permissions to perform this action.",
                                                                   ClsBankingNotification.NotificationType.Error);
                return;
            }

            _ChaingUserStatus(1, "Activated");

        }

        private void DeactiveUser_Click_1(object sender, EventArgs e)
        {

            if (!ClsPermission.CheckUserPermission(ClsGlobal.CurrentUser.UserID, ClsPermission.enPermissions.Manage_Users.ToString()))
            {
                ClsBankingNotification.ShowBankingNotification("Access Denied", "You do not have the required permissions to perform this action.",
                                                                   ClsBankingNotification.NotificationType.Error);
                return;
            }

            _ChaingUserStatus(0, "Deactivated");

        }

        private void LockedUser_Click_1(object sender, EventArgs e)
        {

            if (!ClsPermission.CheckUserPermission(ClsGlobal.CurrentUser.UserID, ClsPermission.enPermissions.Manage_Users.ToString()))
            {
                ClsBankingNotification.ShowBankingNotification("Access Denied", "You do not have the required permissions to perform this action.",
                                                                   ClsBankingNotification.NotificationType.Error);
                return;
            }

            _ChaingUserStatus(2, "Locked");

        }

        private void DataGridViewAllUsere_CellMouseDown_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {

                DataGridViewAllUsere.ClearSelection();
                DataGridViewAllUsere.Rows[e.RowIndex].Selected = true;
                DataGridViewAllUsere.CurrentCell = DataGridViewAllUsere.Rows[e.RowIndex].Cells[e.ColumnIndex];

            }
        }
    }

   
}
