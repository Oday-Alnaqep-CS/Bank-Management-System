using BankSystemBuisniseLayer;
using FontAwesome.Sharp;
using NetTopologySuite.Triangulate;
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
    public partial class UC_Notifications : UserControl
    {
        public UC_Notifications()
        {
            InitializeComponent();
        }

        private void UC_Notifications_Load(object sender, EventArgs e)
        {


            txtSearch.IconRight = IconChar.Search.ToBitmap(Color.Gray, 20);
            btnBacktoDashboardOverview.Image = IconChar.CircleArrowLeft.ToBitmap(Color.Red, 30);
            _ApplyCleanGridViewStyle();
            _LoadData();


         }



        private void _ApplyCleanGridViewStyle()


        {

            DataGridViewNotification.EnableHeadersVisualStyles = false;
            DataGridViewNotification.BackgroundColor = Color.FromArgb(15, 23, 42);
            DataGridViewNotification.BorderStyle = BorderStyle.None;
            DataGridViewNotification.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            DataGridViewNotification.GridColor = Color.FromArgb(45, 60, 80);


            DataGridViewNotification.ColumnHeadersHeight = 40;
            DataGridViewNotification.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            DataGridViewNotification.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 30, 50);
            DataGridViewNotification.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DataGridViewNotification.ColumnHeadersDefaultCellStyle.Font = new Font("Georgia", 12F, FontStyle.Bold);
            DataGridViewNotification.ColumnHeadersDefaultCellStyle.Padding = new Padding(12, 0, 12, 0);


            DataGridViewNotification.RowTemplate.Height = 70;
            DataGridViewNotification.DefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
            DataGridViewNotification.DefaultCellStyle.ForeColor = Color.White;
            DataGridViewNotification.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 58, 138);
            DataGridViewNotification.DefaultCellStyle.SelectionForeColor = Color.Cyan;
            DataGridViewNotification.DefaultCellStyle.Font = new Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
            DataGridViewNotification.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            // Change size of Image 
            DataGridViewNotification.RowsDefaultCellStyle.Padding = new Padding(3, 3, 3, 3);


            DataGridViewNotification.RowHeadersVisible = false;
            DataGridViewNotification.AllowUserToResizeRows = false;
            DataGridViewNotification.AllowUserToResizeColumns = true;
            DataGridViewNotification.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DataGridViewNotification.ScrollBars = ScrollBars.Both;


            if (DataGridViewNotification.Columns["Profile"] is DataGridViewImageColumn imgCol)
            {
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                imgCol.Width = 90;
            }
        }


        void _LoadData()

        {
            string ErrorMessage = string.Empty;

            DataTable dtNotification = ClsNotification.GetNotificationsByUserID(ClsGlobal.CurrentUser.UserID, ref  ErrorMessage);


            if (ErrorMessage != string.Empty)
            {
                ClsBankingNotification.ShowBankingNotification("Get List Notification", ErrorMessage, ClsBankingNotification.NotificationType.Error);

              
                MessageBox.Show(ErrorMessage, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DataGridViewNotification.DataSource = dtNotification;

            DataGridViewNotification.RowTemplate.Height = 50;
        }

        private void _ApplyClientsFilter()
        {
            if (DataGridViewNotification.DataSource is DataTable dt)
            {
                dt.CaseSensitive = false;
                string search = txtSearch.Text.Trim().Replace("'", "''");
                string selectedValue = cmbFilterMain.SelectedItem?.ToString() ?? "All Filters";

                string filter = string.Empty;

                switch (selectedValue)
                {
                    case "Notification ID":
                        if (!string.IsNullOrEmpty(search))
                            filter = int.TryParse(search, out int ID) ? $"[Notification ID] = {ID}" : "[Notification ID] = 0";
                        break;

                    case "Titale":
                        if (!string.IsNullOrEmpty(search))
                            filter = $"[Title] LIKE '%{search}%'";
                        break;

                    case "IsRead":
                        if (!string.IsNullOrEmpty(search))
                            filter = $"[IsRead] LIKE '%{search}%'";
                        break;

                }

                dt.DefaultView.RowFilter = filter;
            }
        }

        private void DataGridViewNotification_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {


            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string ColumnName = DataGridViewNotification.Columns[e.ColumnIndex].Name;

            if (ColumnName == "Is Read")
            {
                if (e.Value != null)
                {
                    string status = e.Value.ToString();

                    if (status == "Read")
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(46, 204, 113);  
                    }
                    else if (status == "Unread")
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(255, 95, 95);   
                    }

                    e.CellStyle.Font = new Font(DataGridViewNotification.Font, FontStyle.Bold);
                    e.FormattingApplied = true;
                }
            }

        }

        private void cmbFilterMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ApplyClientsFilter();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            if (DataGridViewNotification.DataSource is DataTable dt)
            {

                dt.CaseSensitive = true;

                string txt = txtSearch.Text.Trim();

                dt.DefaultView.RowFilter = string.IsNullOrEmpty(txt) ? string.Empty : string.Format("[Title] LIKE '%{0}%' OR [Message] LIKE '%{0}%'", txt);
            }
        }
        private void UC_Notifications_VisibleChanged(object sender, EventArgs e)
        {
           
        }

        private void btnBacktoDashboardOverview_Click(object sender, EventArgs e)
        {
            string ErrorMessage = string.Empty;
            ((FrmMain)this.FindForm()).LoadUserControl(new UC_Dashboard());
            ClsNotification.MarkAsRead(ClsGlobal.CurrentUser.UserID, ref ErrorMessage);
         
            

        }

        private void UC_Notifications_VisibleChanged_1(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                _LoadData();
            }
        }
    }
}
