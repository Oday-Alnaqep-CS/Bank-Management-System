using BankSystemBuisniseLayer;
using FontAwesome.Sharp;
using Guna.UI2.WinForms;
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
    public partial class UC_TotalBalance : UserControl
    {
        public UC_TotalBalance()
        {
            InitializeComponent();
        }

        private void UC_TotalBalance_Load(object sender, EventArgs e)
        {

            string ErrorMessage = string.Empty;

            btnBacktoDashboardOverview.Image = IconChar.CircleArrowLeft.ToBitmap(Color.Red, 30);
            txtSearch.IconRight = IconChar.Search.ToBitmap(Color.Gray, 20);
            lblTotalBalance.Text = $"$ {ClsGetTotalBalances.GetTotalBalance(out ErrorMessage).ToString("N0")}";
            ViewAllBalances();
            ApplyCleanGridViewStyle();

        }

        private void ViewAllBalances()

        {
            string ErrorMessage = string.Empty;
            DataTable dtViewAllTotalBalance = ClsBalance.GetAllBalances(ref ErrorMessage);

            if (!string.IsNullOrEmpty(ErrorMessage))

            {

                ClsBankingNotification.ShowBankingNotification("Error", ErrorMessage, ClsBankingNotification.NotificationType.Error);
                return;

            }

            if (dtViewAllTotalBalance == null)
            {
                MessageBox.Show("Error");
            }

            if (dtViewAllTotalBalance != null)
            {

                DataGridViewAllTotalBalance.DataSource = dtViewAllTotalBalance;
            }
        }

        private void ApplyCleanGridViewStyle()


        {

            DataGridViewAllTotalBalance.EnableHeadersVisualStyles = false;
            DataGridViewAllTotalBalance.BackgroundColor = Color.FromArgb(15, 23, 42);
            DataGridViewAllTotalBalance.BorderStyle = BorderStyle.None;
            DataGridViewAllTotalBalance.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            DataGridViewAllTotalBalance.GridColor = Color.FromArgb(30, 40, 60);


            DataGridViewAllTotalBalance.ColumnHeadersHeight = 80;
            DataGridViewAllTotalBalance.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 30, 50);
            DataGridViewAllTotalBalance.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DataGridViewAllTotalBalance.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            DataGridViewAllTotalBalance.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            DataGridViewAllTotalBalance.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 5, 8, 5);

           
            DataGridViewAllTotalBalance.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

           
            DataGridViewAllTotalBalance.DefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
            DataGridViewAllTotalBalance.DefaultCellStyle.ForeColor = Color.White;
            DataGridViewAllTotalBalance.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 58, 138);
            DataGridViewAllTotalBalance.DefaultCellStyle.SelectionForeColor = Color.Cyan;
            DataGridViewAllTotalBalance.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            DataGridViewAllTotalBalance.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

            DataGridViewAllTotalBalance.RowsDefaultCellStyle.Padding = new Padding(8, 2, 8, 2);
            DataGridViewAllTotalBalance.RowHeadersVisible = false;
            DataGridViewAllTotalBalance.AllowUserToResizeRows = false;
            DataGridViewAllTotalBalance.AllowUserToResizeColumns = false;
            DataGridViewAllTotalBalance.RowTemplate.Height = 35;


            DataGridViewAllTotalBalance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;



        }

        private void btnBacktoDashboardOverview_Click(object sender, EventArgs e)
        {
            ((FrmMain)this.FindForm()).LoadUserControl(new UC_Dashboard());
        }

        private void ApplyFilter()
        {

            if (DataGridViewAllTotalBalance.DataSource is DataTable dt)
            {

                dt.CaseSensitive = false;
                string text = txtSearch.Text.Trim().Replace("'", "''"); 
                string selectedValue = cmbFilterMain.SelectedItem?.ToString() ?? "All";

                
                if (string.IsNullOrEmpty(text))
                {
                    dt.DefaultView.RowFilter = string.Empty;
                    return;
                }

                string filter = string.Empty;

                switch (selectedValue)
                {
                    case "Client ID":
                        if (int.TryParse(text, out int id))
                            filter = $"[Client ID] = {id}";
                        else
                            filter = "[Client ID] = 0";
                        break;

                    case "Full Name":
                        filter = $"[Full Name] LIKE '%{text}%'";
                        break;

                    case "Account Number":
                        filter = $"[Account Number] LIKE '%{text}%'";
                        break;

                    case "Currency":
                        filter = $"[Currency] LIKE '%{text}%'";
                        break;

                    case "Balance":
                        if (decimal.TryParse(text, out decimal balance))
                            filter = $"[Balance] = {balance}";
                        else
                            filter = $"CONVERT([Balance], 'System.String') LIKE '%{text}%'";
                        break;

                    case "Active":
                    case "Account Status - Active":
                        filter = $"[Account Status] = 'Active' AND ([Full Name] LIKE '%{text}%' OR [Account Number] LIKE '%{text}%')";
                        break;

                    case "Dormant":
                    case "Account Status - Dormant":
                        filter = $"[Account Status] = 'Dormant' AND ([Full Name] LIKE '%{text}%' OR [Account Number] LIKE '%{text}%')";
                        break;

                    case "Frozen":
                    case "Account Status - Frozen":
                        filter = $"[Account Status] = 'Frozen' AND ([Full Name] LIKE '%{text}%' OR [Account Number] LIKE '%{text}%')";
                        break;

                    case "Country":
                        filter = $"[Country] LIKE '%{text}%'";
                        break;

                    
                    case "All":
                    case "All Filters":
                    default:
                        filter = $"[Full Name] LIKE '%{text}%' OR [Account Number] LIKE '%{text}%' OR [Currency] LIKE '%{text}%' OR [Country] LIKE '%{text}%' OR CONVERT([Balance], 'System.String') LIKE '%{text}%'";
                        if (int.TryParse(text, out int searchId))
                        {
                            filter += $" OR [Client ID] = {searchId}";
                        }
                        break;
                }

                dt.DefaultView.RowFilter = filter;
            }
        }

       
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }


        private void cmbFilterMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void DataGridViewAllTotalBalance_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {




            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string columnName = DataGridViewAllTotalBalance.Columns[e.ColumnIndex].Name;
          
            if (columnName == "Account Status")


            {

                string status = e.Value?.ToString();

                switch (status)
                {
                    case "Active":
                    case "1":
                      //  e.CellStyle.BackColor = Color.FromArgb(20, 40, 167, 69);  
                        e.CellStyle.ForeColor = Color.FromArgb(46, 204, 113);     
                        e.CellStyle.SelectionForeColor = Color.White;
                        break;

                    case "Dormant":
                    case "2":
                        //e.CellStyle.BackColor = Color.FromArgb(20, 241, 196, 15);  
                        e.CellStyle.ForeColor = Color.FromArgb(241, 196, 15);      
                        e.CellStyle.SelectionForeColor = Color.White;
                        break;

                    case "frozen":
                    case "Frozen":
                    case "3":
                        //e.CellStyle.BackColor = Color.FromArgb(20, 231, 76, 60);  // خلفية حمراء شفافة خفيفة
                        e.CellStyle.ForeColor = Color.FromArgb(231, 76, 60);      // أحمر كورال جذاب للتجميد
                        e.CellStyle.SelectionForeColor = Color.White;
                        break;
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

     
    }
}
