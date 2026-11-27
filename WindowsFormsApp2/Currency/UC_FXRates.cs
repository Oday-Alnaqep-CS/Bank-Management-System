using BankSystemBuisniseLayer;
using BankSystemBusinessLayer;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThinkGeo.Core;

namespace Bank_Managment_System
{
    public partial class UC_FXRates : UserControl
    {



        ClsUser ClsUser = new ClsUser();
        public UC_FXRates()
        {
            InitializeComponent();
        }

        private void UC_FXRates_Load(object sender, EventArgs e)
        {
            _Icones_Setting();
            _ApplyCleanGridViewStyle();
            _LoadCurrenciesData();
            string ErrorMessage = string.Empty;

            lblTotalCurrencies.Text = ClsCurrency.GetCountOfCurrency(ref ErrorMessage).ToString();
            lblInActiveUsers.Text = ClsCurrency.GetCountOfActiveCurrency(ref ErrorMessage).ToString();
        

        }


        private void _Icones_Setting()

        {
            
            DeleteUser.Image = IconChar.UserTimes.ToBitmap(Color.FromArgb(239, 68, 68));
            EditUser.Image = IconChar.UserEdit.ToBitmap(Color.FromArgb(59, 130, 246));
            DeactiveUser.Image = IconChar.UserSlash.ToBitmap(Color.FromArgb(245, 158, 11));
            ActivationUser.Image = IconChar.UserCheck.ToBitmap(Color.FromArgb(16, 185, 129));
            LockedUser.Image = IconChar.Lock.ToBitmap(Color.FromArgb(255, 193, 7));

            TotalCurrencyIcon.IconChar = FontAwesome.Sharp.IconChar.Coins;
            ActiveCurrencyIcon.IconChar = FontAwesome.Sharp.IconChar.CheckCircle; 
            LastUpdateIconde.IconChar = FontAwesome.Sharp.IconChar.Clock; 

            TotalCurrencyIcon.IconColor = Color.RoyalBlue;
            LastUpdateIconde.IconColor = Color.MediumSpringGreen;
            ActiveCurrencyIcon.IconColor = Color.Crimson;

            btnCurrencyDiff.Image = IconChar.ExchangeAlt.ToBitmap(Color.LightSkyBlue);
            btnUpdateRate.Image = IconChar.Sync.ToBitmap(Color.LightSkyBlue);
        }

        private void _ApplyCleanGridViewStyle()


        {

            DataGridViewAllCurrencies.EnableHeadersVisualStyles = false;
            DataGridViewAllCurrencies.BackgroundColor = Color.FromArgb(15, 23, 42);
            DataGridViewAllCurrencies.BorderStyle = BorderStyle.None;
            DataGridViewAllCurrencies.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            DataGridViewAllCurrencies.GridColor = Color.FromArgb(30, 40, 60);


            DataGridViewAllCurrencies.ColumnHeadersHeight = 50;
            DataGridViewAllCurrencies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            DataGridViewAllCurrencies.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 30, 50);
            DataGridViewAllCurrencies.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DataGridViewAllCurrencies.ColumnHeadersDefaultCellStyle.Font = new Font("Georgia", 12F, FontStyle.Bold);
            DataGridViewAllCurrencies.ColumnHeadersDefaultCellStyle.Padding = new Padding(12, 0, 12, 0);/* Century Schoolbook; 13pt; style = Bold*/


            DataGridViewAllCurrencies.RowTemplate.Height = 40;
            DataGridViewAllCurrencies.DefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);/*Segoe UI Semibold*/
            DataGridViewAllCurrencies.DefaultCellStyle.ForeColor = Color.White;
            DataGridViewAllCurrencies.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 58, 138);
            DataGridViewAllCurrencies.DefaultCellStyle.SelectionForeColor = Color.Cyan;
            DataGridViewAllCurrencies.DefaultCellStyle.Font = new Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            DataGridViewAllCurrencies.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            // Change size of Image 
            DataGridViewAllCurrencies.RowsDefaultCellStyle.Padding = new Padding(2, 2, 2, 2);


            DataGridViewAllCurrencies.RowHeadersVisible = false;
            DataGridViewAllCurrencies.AllowUserToResizeRows = false;
            DataGridViewAllCurrencies.AllowUserToResizeColumns = true;
            DataGridViewAllCurrencies.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DataGridViewAllCurrencies.ScrollBars = ScrollBars.Both;


            if (DataGridViewAllCurrencies.Columns["Profile"] is DataGridViewImageColumn imgCol)
            {
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                imgCol.Width = 90;
            }
        }

        private void _LoadCurrenciesData()
        {
            string ErrorMessage = string.Empty;

            DataTable dtCurrency = ClsCurrency.GetAllCurrencies(ref ErrorMessage);


            if (dtCurrency != null)
            {

                dtCurrency.Columns.Add("FlagImg", typeof(Image));

                foreach (DataRow row in dtCurrency.Rows)
                {
                    string path = row["Flag"]?.ToString();
                    if (!string.IsNullOrEmpty(path) && System.IO.File.Exists(path))
                    {
                        using (Image originalImg = Image.FromFile(path))
                        {
                           
                            Bitmap resizedBitmap = new Bitmap(32, 20);

                           
                            using (Graphics g = Graphics.FromImage(resizedBitmap))
                            {
                              
                                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                                
                                g.DrawImage(originalImg, 0, 0, 20, 10);
                            }

                           
                            row["FlagImg"] = resizedBitmap;
                        }

                    }
                }

                DataGridViewAllCurrencies.DataSource = dtCurrency;

            
                if (DataGridViewAllCurrencies.Columns["Flag"] != null)
                    DataGridViewAllCurrencies.Columns["Flag"].Visible = false;

                if (DataGridViewAllCurrencies.Columns["FlagImg"] != null)
                {

                    DataGridViewAllCurrencies.Columns["FlagImg"].HeaderText = "Flag";
                    DataGridViewAllCurrencies.Columns["FlagImg"].DisplayIndex = 1;
                    ((DataGridViewImageColumn)DataGridViewAllCurrencies.Columns["FlagImg"]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                }

                    lblTotalCurrencies.Text = dtCurrency.Rows.Count.ToString();
            }
            else
            {
                MessageBox.Show($"Error loading currencies data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridViewAllCurrencies_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string ColumnName = DataGridViewAllCurrencies.Columns[e.ColumnIndex].Name;

            if (ColumnName == "Changed Date" && e.Value != null)
            {
                if (DateTime.TryParse(e.Value.ToString(), out DateTime dt))
                {
                    e.Value = dt.ToString("MMM d yyyy  h:mm tt", new System.Globalization.CultureInfo("en-US"));
                    lblDateLastUpdate.Text = e.Value.ToString();
                    e.FormattingApplied = true;
                }
            }

            if (ColumnName == "Status")
            {
                string status = e.Value?.ToString();

                switch (status)
                {


                    case "Unactive":
                    case "0":
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.Font = new Font(DataGridViewAllCurrencies.Font, FontStyle.Bold);
                        break;

                    case "Active":
                    case "1":
                        e.CellStyle.ForeColor = Color.LimeGreen;
                        e.CellStyle.Font = new Font(DataGridViewAllCurrencies.Font, FontStyle.Bold);
                        break;

              
                }
            }


        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (DataGridViewAllCurrencies.DataSource is DataTable dt)

            {
                dt.CaseSensitive = true;

                string Text = txtSearch.Text.Trim();

                dt.DefaultView.RowFilter = string.IsNullOrEmpty(Text)
                    ? string.Empty
                    : string.Format("[Currency] LIKE '%{0}%' OR [Code] LIKE '%{0}%' OR [Symbol] LIKE '%{0}%' OR[Changed By User ID] LIKE '%{0}%'",Text);


            }

        }

        private void cbFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (DataGridViewAllCurrencies.DataSource is DataTable dt)

            {

                dt.CaseSensitive = true;

                string SelectValue = cbFilterStatus.SelectedItem.ToString();
                string Filter = string.Empty;

                if (!string.IsNullOrEmpty(SelectValue) && SelectValue != "All")

                {

                    switch (SelectValue)
                    {

                        case "Active":
                            Filter = "Status = 'Active'";
                            break;

                        case "InActive":
                            Filter = "Status = 'InActive'";
                            break;
                    }


                }
                else
                {
                    Filter = string.Empty;
                }

                dt.DefaultView.RowFilter = Filter;

            }
        }

        private void btnUpdateRate_Click(object sender, EventArgs e)
        {


            if (!ClsPermission.CheckUserPermission(ClsGlobal.CurrentUser.UserID, ClsPermission.enPermissions.System_Settings.ToString()))
            {
                ClsBankingNotification.ShowBankingNotification("Access Denied", "You do not have the required permissions to perform this action.",
                                                                   ClsBankingNotification.NotificationType.Error);
                return;
            }

            FrmUpdateFX frm = new FrmUpdateFX();
            frm.ShowDialog();
        }

        private void btnCurrencyDiff_Click(object sender, EventArgs e)
        {

            if (!ClsPermission.CheckUserPermission(ClsGlobal.CurrentUser.UserID, ClsPermission.enPermissions.System_Settings.ToString()))
            {
                ClsBankingNotification.ShowBankingNotification("Access Denied", "You do not have the required permissions to perform this action.",
                                                                   ClsBankingNotification.NotificationType.Error);
                return;
            }

            FrmCurrencyDifference frm = new FrmCurrencyDifference();
            frm.ShowDialog();
        }
    }
}
