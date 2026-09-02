using BankSystemDataAccess.Financial;
using FontAwesome.Sharp;
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
    public partial class UC_AccountManagement : UserControl
    {
        public UC_AccountManagement()
        {
            InitializeComponent();
        }

        private void UC_AccountManagement_Load(object sender, EventArgs e)
        {


            TotalAccountIcone.IconChar = FontAwesome.Sharp.IconChar.Wallet;
            ActiveAccountIcone.IconChar = FontAwesome.Sharp.IconChar.UserCheck;
            TotalDromantsICone.IconChar = FontAwesome.Sharp.IconChar.UserClock;
            InActiveAccountIcon.IconChar = FontAwesome.Sharp.IconChar.UserSlash;
            btnAddNewAccount.Image = IconChar.UserPlus.ToBitmap(Color.Blue);
            ClsControls.ApplyZoomEffect(

                                     (TotalAccountIcone, Color.FromArgb(59, 130, 246)),
                                     (ActiveAccountIcone, Color.FromArgb(34, 197, 94)),
                                     (TotalDromantsICone, Color.FromArgb(245, 158, 11)),
                                     (InActiveAccountIcon, Color.FromArgb(239, 68, 68))

);


            _SupInFo();
            _ApplyCleanGridViewStyle();
            _LoadAllAccountsIntoGridView();
        }


        private void _SupInFo()

        {

            string ErrorMessage = string.Empty;
            ClsAccount _Account = new ClsAccount();
            lblTotalAccounts.Text = _Account.GetTotalAccountsCount(ref ErrorMessage).ToString();
            lblActiveAccounts.Text = _Account.GetTotalActiveAccountsCount(ref ErrorMessage).ToString();
            lblDormantAccounts.Text = _Account.GetTotalDormantAccountsCount(ref ErrorMessage).ToString();
            lblInActiveAccounts.Text = _Account.GetTotalInactiveAccountsCount(ref ErrorMessage  ).ToString();
        }

        private void _ApplyCleanGridViewStyle()


        {

            DataGridViewAllAccount.EnableHeadersVisualStyles = false;
            DataGridViewAllAccount.BackgroundColor = Color.FromArgb(15, 23, 42);
            DataGridViewAllAccount.BorderStyle = BorderStyle.None;
            DataGridViewAllAccount.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            DataGridViewAllAccount.GridColor = Color.FromArgb(30, 40, 60);


            DataGridViewAllAccount.ColumnHeadersHeight = 50;
            DataGridViewAllAccount.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            DataGridViewAllAccount.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 30, 50);
            DataGridViewAllAccount.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DataGridViewAllAccount.ColumnHeadersDefaultCellStyle.Font = new Font("Georgia", 12F, FontStyle.Bold);
            DataGridViewAllAccount.ColumnHeadersDefaultCellStyle.Padding = new Padding(12, 0, 12, 0);/* Century Schoolbook; 13pt; style = Bold*/


            DataGridViewAllAccount.RowTemplate.Height = 80;
            DataGridViewAllAccount.DefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);/*Segoe UI Semibold*/
            DataGridViewAllAccount.DefaultCellStyle.ForeColor = Color.White;
            DataGridViewAllAccount.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 58, 138);
            DataGridViewAllAccount.DefaultCellStyle.SelectionForeColor = Color.Cyan;
            DataGridViewAllAccount.DefaultCellStyle.Font = new Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            DataGridViewAllAccount.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            // Change size of Image 
            DataGridViewAllAccount.RowsDefaultCellStyle.Padding = new Padding(5, 2, 2, 2);


            DataGridViewAllAccount.RowHeadersVisible = false;
            DataGridViewAllAccount.AllowUserToResizeRows = false;
            DataGridViewAllAccount.AllowUserToResizeColumns = true;
            DataGridViewAllAccount.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DataGridViewAllAccount.ScrollBars = ScrollBars.Both;


            if (DataGridViewAllAccount.Columns["Profile"] is DataGridViewImageColumn imgCol)
            {
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                imgCol.Width = 90;
            }
        }

        private void _LoadAllAccountsIntoGridView()

        {


            string ErrorMessage = string.Empty;

            DataTable dtAccounts =ClsAccount.GetAllAccounts(ref ErrorMessage);

            if (dtAccounts != null && dtAccounts.Rows.Count > 0)
            {
                DataGridViewAllAccount.DataSource = dtAccounts;
            }
            else
            {
                MessageBox.Show("No accounts found or an error occurred: " + ErrorMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            DataGridViewAllAccount.RowTemplate.Height = 40;

        }






        private void btnAddNewCustoer_Click(object sender, EventArgs e)
        {

        }

        private void DataGridViewAllAccount_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

          
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string columnName = DataGridViewAllAccount.Columns[e.ColumnIndex].Name;

            
            if (columnName == "Account Status")
            {
                string status = e.Value?.ToString();
                switch (status)
                {
                    case "Active":
                        e.CellStyle.ForeColor = Color.FromArgb(46, 204, 113); 
                        break;
                    case "Dormant":
                        e.CellStyle.ForeColor = Color.FromArgb(241, 196, 15); 
                        break;
                    case "Frozen":
                        e.CellStyle.ForeColor = Color.FromArgb(231, 76, 60);  
                        break;
                }
                e.CellStyle.SelectionForeColor = Color.White;
            }

            else if (columnName == "Account Type")
            {
                string accType = e.Value?.ToString();
                switch (accType)
                {
                    case "Checking Account":
                        e.CellStyle.ForeColor = Color.FromArgb(52, 152, 219); 
                        break;
                    case "Savings Account":
                        e.CellStyle.ForeColor = Color.FromArgb(155, 89, 182); 
                        break;
                    case "Corporate Account":
                        e.CellStyle.ForeColor = Color.FromArgb(230, 126, 34); 
                        break;
                }
                e.CellStyle.SelectionForeColor = Color.White;
            }


            else if (columnName == "Currency Symbol" || columnName == "Symbol")
            {
                string currency = e.Value?.ToString();
                if (currency == "USD" || currency == "$")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(39, 174, 96);   
                    e.CellStyle.Font = new Font(DataGridViewAllAccount.Font, FontStyle.Bold);
                }
                else if (currency == "YER")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(243, 156, 18);  
                }
                else if (currency == "SAR" || currency == "EUR")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(52, 152, 219);  
                }
                e.CellStyle.SelectionForeColor = Color.White;
            }


            else if (columnName == "Branch" || columnName.Contains("Branch"))
            {
                e.CellStyle.ForeColor = Color.FromArgb(189, 195, 199);  
            }

          
            else if (columnName == "Balance")
            {
                if (decimal.TryParse(e.Value?.ToString(), out decimal balance))
                {
                    if (balance >= 500000)
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(46, 204, 113); 
                        e.CellStyle.Font = new Font(DataGridViewAllAccount.Font, FontStyle.Bold);
                    }
                }
            }

        }
    }
}
