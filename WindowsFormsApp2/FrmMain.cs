using Bank_Managment_System;
using BankSystemBuisniseLayer;
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
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;
using static Bank_Managment_System.ClsBankingNotification;





namespace Bank_Managment_System
{
    public partial class FrmMain : Form
    {


        private UC_Dashboard _ucDashboard;
        ClsBankingNotification notification = new ClsBankingNotification();
        public static ClsUser CurrentUser = new ClsUser();

        public FrmMain()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                  ControlStyles.AllPaintingInWmPaint |
                  ControlStyles.UserPaint, true);
            this.UpdateStyles();

            


        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
           
            string JobTitle = ClsGlobal.CurrentUser.JobTitle;
            string UserName = ClsGlobal.CurrentUser.UserName;
             //this.DoubleBuffered = true;

            Design();
            _ucDashboard = new UC_Dashboard();
            lblUserInfo.Text = $"{UserName} ({JobTitle})";

            RenderDatabaseStatus();
            GetBranchName();
            LoadView(_ucDashboard);
            SetupSidebarButtons();


        }

        private void UpdateNotificationBadge()


        {
           

            if (ClsGlobal.CurrentUser == null) return;

            string ErrorMessage = "";
            DataTable dtNotifications = ClsNotification.GetNotificationsByClientID(ClsGlobal.CurrentUser.UserID, ref ErrorMessage);

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

               // lblNotificationCountf.Visible = false;
            }
        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SetupTopBarIconsAndData()


        {
           
            if (ClsGlobal.CurrentUser != null)
            {
                lblUserInfo.Text = $"  {ClsGlobal.CurrentUser.PersonInfo.FullName } ({ClsGlobal.CurrentUser.JobTitle}) |";
            }
            else
            {
                lblUserInfo.Text = "Oday Al-Naqep (System Admin)"; 
            }

          //  btnLogout.Click += BtnLogout_Click;
           
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {


            DialogResult result = MessageBox.Show( "Are you sure you want to log out?", "Confirm Logout",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

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

      
            lblUserInfo.IconLeft = FontAwesome.Sharp.IconChar.UserAlt.ToBitmap(Color.White, 500);



          
            SetupTopBarIconsAndData();
            UpdateNotificationBadge();

            //  cardTotalClientsicon.Image = FontAwesome.Sharp.IconChar.Users.ToBitmap(Color.White, 28, FontAwesome.Sharp.IconFont.Solid);



          
            btnRole.Image = IconChar.UserShield.ToBitmap(Color.SteelBlue, 50);

           
            btnVersion.Image = IconChar.InfoCircle.ToBitmap(Color.SteelBlue, 50);

        }

        public void LoadView(UserControl userControl)


        {
            
            pnlContainer.Controls.Clear();

          
            userControl.Dock = DockStyle.Fill;

          
            pnlContainer.Controls.Add(userControl);
            userControl.BringToFront();


        }

        public void LoadUserControl(UserControl uc)


        {


            pnlContainer.SuspendLayout();

        
            pnlContainer.Controls.Clear();

          
            uc.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(uc);

         
            pnlContainer.ResumeLayout();
          

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

           // lblBranchName.Text =  ClsGetResultWhatDoyouWannt.GetCurrentBranchName(ClsGlobal.CurrentUser.BranchID, out ErrorMessage);
             btnBranch.Text =  ClsGetResultWhatDoyouWannt.GetCurrentBranchName(ClsGlobal.CurrentUser.BranchID, out ErrorMessage);
            //MessageBox.Show(Resulr);
        }

        private void GetRole()

        {

            string ErrorMessage = string.Empty;

            //lblBranchName.Text =  ClsGetResultWhatDoyouWannt.GetCurrentBranchName(ClsGlobal.CurrentUser.BranchID, out ErrorMessage);
            btnBranch.Text = ClsGetResultWhatDoyouWannt.GetCurrentBranchName(ClsGlobal.CurrentUser.BranchID, out ErrorMessage);

        }

        private void btnBashBoard_Click(object sender, EventArgs e)
        {

            
            LoadView(_ucDashboard);


        }

       

        private void btnBranch_Click(object sender, EventArgs e)
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