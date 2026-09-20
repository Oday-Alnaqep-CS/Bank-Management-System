using Bank_Managment_System;
using BankSystemBuisniseLayer;
using BankSystemBusinessLayer;
using FontAwesome;
using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using LiveCharts;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using Tulpep.NotificationWindow;
using Volo.Abp.Users;
using static Bank_Managment_System.ClsBankingNotification;





namespace Bank_Managment_System
{
    public partial class Mainss : Form
    {


        private UC_Dashboard _US_Dashboard;
        private UC_CustomersManagement _US_CustomersManage = new UC_CustomersManagement();
        private UC_UsersManagement _US_UserManagement = new UC_UsersManagement();
        private UC_AccountManagement _US_AccountManagement = new UC_AccountManagement();
        private UC_TransfersManagement _US_TransfersManagement = new UC_TransfersManagement();
        private UC_TransactionsManagement UC_TransactionsManagement = new UC_TransactionsManagement();
        private UC_FXRates _UC_FXRates = new UC_FXRates();
        private UC_Notifications _UC_Notifications = new UC_Notifications();
        ClsBankingNotification notification = new ClsBankingNotification();
        // public static ClsUser CurrentUser = new ClsUser();

        ClsClient _Client = new ClsClient();

        UC_AddCustomer _AddCustomer = new UC_AddCustomer();

        public Mainss()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                  ControlStyles.AllPaintingInWmPaint |
                  ControlStyles.UserPaint, true);
            this.UpdateStyles();
            this.DoubleBuffered = true;




        }

        private void Mainss_Load(object sender, EventArgs e)
        {
            string errorMessage = null;


            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;


            string JobTitle = ClsGlobal.CurrentUser.JobTitle;
            string UserName = ClsGlobal.CurrentUser.UserName;
            this.DoubleBuffered = true;

            Design();
            _US_Dashboard = new UC_Dashboard();
            lblUserInfo.Text = $"{UserName} ({JobTitle})";
            RenderDatabaseStatus();
            GetBranchName();
            GetRole();
            LoadUserControl(_US_Dashboard);
            SetupSidebarButtons();
            timer1.Start();

        }

        private void UpdateNotificationBadge()


        {


            if (ClsGlobal.CurrentUser == null) return;

            string ErrorMessage = "";
            DataTable dtNotifications = ClsNotification.GetNotificationsByUserID(ClsGlobal.CurrentUser.UserID, ref ErrorMessage);

            int unreadCount = (dtNotifications != null) ? dtNotifications.Rows.Count : 0;

            UpdateNotificationCount(unreadCount);


        }

        private void UpdateNotificationCount(int count)


        {
            if (count > 0)
            {

                lblNotificationCountf.Text = count > 99 ? "99+" : count.ToString();

            }
            else
            {

                lblNotificationCountf.Text = 0.ToString();


            }
        }

        private void SetupTopBarIconsAndData()


        {

            if (ClsGlobal.CurrentUser != null)
            {


                lblUserInfo.Text = $"  {ClsGlobal.CurrentUser.PersonInfo.FirstName} {ClsGlobal.CurrentUser.PersonInfo.LastName} ({ClsGlobal.CurrentUser.JobTitle})";


            }
            else
            {
                lblUserInfo.Text = "Oday Al-Naqep (System Admin)";
            }



        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {


            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)

            {

                ClsGlobal.CurrentUser = null;


                FrmLogin frmLogin = new FrmLogin();
                frmLogin.Show();

                this.Close();
            }

        }

        private void Design()


        {

            Font logoFont = new Font("Segoe MDL2 Assets", 22F, FontStyle.Regular);
            Font iconFont = new Font("Segoe MDL2 Assets", 12F, FontStyle.Regular);
            // Font logoFont = new Font("Century Schoolbook", 20F, FontStyle.Bold);
            lblBankLogo.Font = logoFont;
            lblBankLogo.Text = "\uE80F  BANK MANAGEMENT SYSTEM";

            btnNotification.Font = iconFont;
            btnNotification.Image = IconChar.Bell.ToBitmap(Color.SteelBlue, 50);
            btnNotification.Text = string.Empty;


            txtSearch.IconLeft = IconChar.SearchPlus.ToBitmap(Color.Gray, 20);
            txtSearch.IconLeftOffset = new Point(5, 0);
            txtSearch.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);

            btnDashBoard.Image = IconChar.HomeAlt.ToBitmap(Color.White, 50);
            btnLogout.Image = IconChar.SignOutAlt.ToBitmap(Color.FromArgb(239, 68, 68), 20);

            string ErrorMessage = string.Empty;

            ClsGlobal.CurrentUser = ClsUser.Find(ClsGlobal.CurrentUser.UserID, ref ErrorMessage);

            if (!string.IsNullOrEmpty(ClsGlobal.CurrentUser.PersonInfo.ImagePath) &&
             File.Exists(ClsGlobal.CurrentUser.PersonInfo.ImagePath))
            {

                using (Image orginalImage = Image.FromFile(ClsGlobal.CurrentUser.PersonInfo.ImagePath))
                {
                    lblUserInfo.IconLeft = ClsImageSetting.GetCircularImage(orginalImage);
                }

            }
            else
            {

                lblUserInfo.IconLeft = Properties.Resources.DefaultImage;
            }




            SetupTopBarIconsAndData();
            UpdateNotificationBadge();

            //  cardTotalClientsicon.Image = FontAwesome.Sharp.IconChar.Users.ToBitmap(Color.White, 28, FontAwesome.Sharp.IconFont.Solid);




            btnRole.Image = IconChar.UserShield.ToBitmap(Color.SteelBlue, 50);


            btnVersion.Image = IconChar.InfoCircle.ToBitmap(Color.SteelBlue, 50);

        }

        public void LoadUserControl(UserControl userControl)


        {


            pnlContainer.Controls.Clear();


            userControl.Dock = DockStyle.Fill;


            pnlContainer.Controls.Add(userControl);
            userControl.BringToFront();


        }

        private void SetupSidebarButtons()


        {

            int iconSize = 32;


            btnBranch.Image = IconChar.BuildingColumns.ToBitmap(Color.FromArgb(100, 200, 255), iconSize);


            btnCustomers.Image = IconChar.Users.ToBitmap(Color.FromArgb(120, 230, 160), iconSize);


            btnUsers.Image = IconChar.UserShield.ToBitmap(Color.FromArgb(190, 150, 255), iconSize);


            btnAccounts.Image = IconChar.Wallet.ToBitmap(Color.FromArgb(255, 215, 100), iconSize);


            btnTransfers.Image = IconChar.RightLeft.ToBitmap(Color.FromArgb(100, 230, 220), iconSize);


            btnTransactions.Image = IconChar.Receipt.ToBitmap(Color.FromArgb(255, 170, 110), iconSize);


            btnFXRates.Image = IconChar.Coins.ToBitmap(Color.FromArgb(130, 245, 180), iconSize);


            btnLones.Image = IconChar.HandHoldingDollar.ToBitmap(Color.FromArgb(255, 140, 160), iconSize);


            btnSettings.Image = IconChar.Sliders.ToBitmap(Color.FromArgb(210, 220, 230), iconSize);

        }

        private void RenderDatabaseStatus()

        {

            string ErrorMessage = string.Empty;

            bool IsConnectd = clsSystemHealth.IsDatabaseConnected(ref ErrorMessage);

            if (IsConnectd)

            {

                btnServerConnected.Image = IconChar.CircleDot.ToBitmap(Color.Green, 50);
                lblServerState.Text = "Connected (SQL Server)";
                ClsBankingNotification.ShowBankingNotification("Succsee", "SQL Server Is Connected :-)", ClsBankingNotification.NotificationType.Success);

            }
            else

            {

                btnServerConnected.Image = IconChar.CircleDot.ToBitmap(Color.Red, 50);
                lblServerState.Text = "Disconnected (SQL Server)";
                lblServerState.ForeColor = Color.Red;

                ClsBankingNotification.ShowBankingNotification("Error", "SQL Server Is Disconnected", ClsBankingNotification.NotificationType.Error);
            }
        }

        private void GetBranchName()

        {

            string ErrorMessage = string.Empty;

            ClsGlobal.CurrentUser = ClsUser.Find(ClsGlobal.CurrentUser.UserID, ref ErrorMessage);


            btnBranch.Text = $"Branche :  {ClsGetResultWhatDoyouWannt.GetCurrentBranchName(ClsGlobal.CurrentUser.BranchID, out ErrorMessage)}";

        }

        private void GetRole()

        {

            string ErrorMessage = string.Empty;

            btnRole.Text = $"Role :  {ClsGlobal.CurrentUser.RoleName}";


        }

        private void btnBashBoard_Click(object sender, EventArgs e)
        {


            LoadUserControl(_US_Dashboard);


        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {

            if (!ClsPermission.CheckUserPermission(ClsGlobal.CurrentUser.UserID, ClsPermission.enPermissions.Manage_Customers.ToString()) &&
                !ClsPermission.CheckUserPermission(ClsGlobal.CurrentUser.UserID, ClsPermission.enPermissions.View_Customer_Financials.ToString()))
            {
                ClsBankingNotification.ShowBankingNotification("Access Denied", "You do not have the required permissions to perform this action.", ClsBankingNotification.NotificationType.Error);
                return;
            }

            LoadUserControl(_US_CustomersManage);

        }

        private void btnUsers_Click(object sender, EventArgs e)
        {

            if (!ClsPermission.CheckUserPermission(ClsGlobal.CurrentUser.UserID, ClsPermission.enPermissions.Manage_Users.ToString()))
            {
                ClsBankingNotification.ShowBankingNotification("Access Denied", "You do not have the required permissions to perform this action.", ClsBankingNotification.NotificationType.Error);
                return;
            }

            LoadUserControl(_US_UserManagement);

        }

        private void btnAccounts_Click(object sender, EventArgs e)
        {

            if (!ClsPermission.CheckUserPermission(ClsGlobal.CurrentUser.UserID, ClsPermission.enPermissions.Manage_Branch_Accounts.ToString()) &&
                !ClsPermission.CheckUserPermission(ClsGlobal.CurrentUser.UserID, ClsPermission.enPermissions.View_Branch_Reports.ToString()))
            {
                ClsBankingNotification.ShowBankingNotification("Access Denied", "You do not have the required permissions to perform this action.", ClsBankingNotification.NotificationType.Error);
                return;
            }

            LoadUserControl(_US_AccountManagement);
        }

        private void btnTransfers_Click(object sender, EventArgs e)
        {

            if (!ClsPermission.CheckUserPermission(ClsGlobal.CurrentUser.UserID, ClsPermission.enPermissions.Execute_Transfers.ToString()))
            {
                ClsBankingNotification.ShowBankingNotification("Access Denied", "You do not have the required permissions to perform this action.", ClsBankingNotification.NotificationType.Error);
                return;
            }

            LoadUserControl(_US_TransfersManagement);
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {

            if (!ClsPermission.CheckUserPermission(ClsGlobal.CurrentUser.UserID, ClsPermission.enPermissions.View_Branch_Reports.ToString()))
            {
                ClsBankingNotification.ShowBankingNotification("Access Denied", "You do not have the required permissions to perform this action.", ClsBankingNotification.NotificationType.Error);
                return;
            }

            LoadUserControl(UC_TransactionsManagement);

        }

        private void btnNotification_Click(object sender, EventArgs e)
        {


            LoadUserControl(_UC_Notifications);
        }

        private void btnFXRates_Click(object sender, EventArgs e)
        {

            if (!ClsPermission.CheckUserPermission(ClsGlobal.CurrentUser.UserID, ClsPermission.enPermissions.System_Settings.ToString()))
            {
                ClsBankingNotification.ShowBankingNotification("Access Denied", "You do not have the required permissions to perform this action.", ClsBankingNotification.NotificationType.Error);
                return;
            }

            LoadUserControl(_UC_FXRates);
        }

        private void btnLones_Click(object sender, EventArgs e)
        {
            if (!ClsPermission.CheckUserPermission(ClsGlobal.CurrentUser.UserID, ClsPermission.enPermissions.View_Customer_Financials.ToString()))
            {
                ClsBankingNotification.ShowBankingNotification("Access Denied", "You do not have the required permissions to perform this action.", ClsBankingNotification.NotificationType.Error);
                return;
            }
        }

        private void _LoadNotificationData()

        {

            if (!ClsPermission.CheckUserPermission(ClsGlobal.CurrentUser.UserID, ClsPermission.enPermissions.View_Branch_Reports.ToString()))
            {
                // ClsBankingNotification.ShowBankingNotification("Access Denied", "You do not have the required permissions to perform this action.", ClsBankingNotification.NotificationType.Error);
                return;
            }

            string ErrorMessage = string.Empty;
            lblNotificationCountf.Text = ClsNotification.GetNotificationCount(ClsGlobal.CurrentUser.UserID, ref ErrorMessage).ToString();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            _LoadNotificationData();
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