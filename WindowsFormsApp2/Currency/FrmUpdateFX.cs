using BankSystemBuisniseLayer;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_Managment_System
{
    public partial class FrmUpdateFX : Form
    {



        ClsCurrency _Rate = new ClsCurrency();

        public FrmUpdateFX()
        {
            InitializeComponent();
        }

        private void FrmUpdateFX_Load(object sender, EventArgs e)
        {
            _Design();
            timer1.Start();
            _FillCurrencyName();
        }

        private void _Design()
        {
            PictCurrencyNameIcone.Image = IconChar.Coins.ToBitmap(Color.DodgerBlue);
            ToplblIcone.Image = IconChar.ExchangeAlt.ToBitmap(Color.DodgerBlue);
            btnConfirmUpdate.Image = IconChar.ArrowRightToBracket.ToBitmap(Color.MediumSpringGreen);
            btnCancel.Image = FontAwesome.Sharp.IconChar.Xmark.ToBitmap(Color.Red);
            txtTime.Image = IconChar.Clock.ToBitmap(Color.CornflowerBlue);
            txtDate.Image = IconChar.CalendarAlt.ToBitmap(Color.CornflowerBlue);
            UpdateFXInformationIcone.Image = IconChar.Coins.ToBitmap(Color.DodgerBlue); 

            txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            txtDate.TextAlign = HorizontalAlignment.Center;

            // txtTransferTime.Text = DateTime.Now.ToString("hh:mm:ss tt", CultureInfo.InvariantCulture);
            txtTime.TextAlign = HorizontalAlignment.Center;
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtTime.Text = DateTime.Now.ToString("hh:mm:ss tt", CultureInfo.InvariantCulture);
        }

        private void _FillCurrencyName()

        {

            string ErrorMessage = string.Empty;
            DataTable dtCurrencyInfo = ClsCurrency.GetAllCurrenciesName(ref ErrorMessage);

            if (dtCurrencyInfo == null)
            {
                ClsBankingNotification.ShowBankingNotification("Error", "this dtCurrencyInfo is null", ClsBankingNotification.NotificationType.Error);
            }
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ClsBankingNotification.ShowBankingNotification("Error", ErrorMessage, ClsBankingNotification.NotificationType.Error);
                return;
            }


            CbCurrencyName.DataSource = dtCurrencyInfo;
            CbCurrencyName.DisplayMember = "currency Name";
            CbCurrencyName.ValueMember = "Currency ID";

            CbCurrencyName.SelectedIndex = 0;
        }

        private void _LoadData(int CurrencyID)

        {

            if (CurrencyID > 0)
            {

                _Rate = ClsCurrency.FindByCurrencyID(CurrencyID);

                if (_Rate == null)
                {
                    MessageBox.Show("This Currencies was not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!string.IsNullOrEmpty(_Rate.FlagPath) && System.IO.File.Exists(_Rate.FlagPath))

                {
                    PictCurrencyNameIcone.Image = Image.FromFile(_Rate.FlagPath);
                }
                else
                {
                    PictCurrencyNameIcone.Image = null;
                }

            }

            txtCurrentCode.Text = _Rate.CurrencyCode;
            txtCurrentBuyRate.Text = (_Rate.CurrentBuyRate.ToString());
            txtCurrentSellRate.Text = (_Rate.CurrentSellRate.ToString());
            txtSpread.Text = (_Rate.ExchangeRate.ToString());
            txtLastUpdateBy.Text = _Rate.ExCgangeByUserID.ToString();

        }

        private void CbCurrencyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(CbCurrencyName.SelectedValue != null && int.TryParse(CbCurrencyName.SelectedValue.ToString(), out int CurrencyID))

            {
                string ErrorMessage = string.Empty;

                DataTable dtCurrencies = ClsCurrency.GetAllCurrenciesName(ref ErrorMessage);

                if (!string.IsNullOrEmpty(ErrorMessage))
                {
                    ClsBankingNotification.ShowBankingNotification("Error", ErrorMessage, ClsBankingNotification.NotificationType.Error);
                    return;
                }


                _LoadData(CurrencyID);

            }

            
        }

        private void _CalculateSpread()

        {
            

            if (decimal.TryParse(txtNewSellRate.Text, out decimal sellRate) &&
                decimal.TryParse(txtNewBuyRate.Text, out decimal buyRate))
            {
                decimal spread = sellRate - buyRate;

               
                txtSpread.Text = spread.ToString("0.0000");
            }
            else
            {
                txtSpread.Text = "0.0000";
            }
        }

        private void txtNewBuyRate_ValueChanged(object sender, EventArgs e)
        {
            _CalculateSpread();
        }

        private void txtNewSellRate_ValueChanged(object sender, EventArgs e)
        {
            _CalculateSpread();
        }

        private void btnConfirmUpdate_Click(object sender, EventArgs e)
        {
             
            if (!decimal.TryParse(txtNewBuyRate.Text, out decimal newBuyRate) ||
                !decimal.TryParse(txtNewSellRate.Text, out decimal newSellRate))
            {
                MessageBox.Show("Please enter valid numbers for the rates.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            _Rate.CurrentBuyRate = newBuyRate;
            _Rate.CurrentSellRate = newSellRate;

            if (decimal.TryParse(txtSpread.Text, out decimal spread))
            {
                _Rate.ExchangeRate = spread;
            }

            _Rate.ExCgangeByUserID = ClsGlobal.CurrentUser.UserID;  
            _Rate.ChangeReason = string.IsNullOrEmpty(txtChangeReason?.Text) ? "Updated via system" : txtChangeReason.Text;

            
            string errorMessage = string.Empty;

            bool isSaved = _Rate._UpdateCurrencyRate(ref errorMessage);
            if (isSaved)
            {
                ClsBankingNotification.ShowBankingNotification("Success", "Exchange rates updated successfully!", ClsBankingNotification.NotificationType.Success);
                //this.DialogResult = DialogResult.OK;
                _LoadData(_Rate.CurrencyID);
            }
            else
            {
                
                MessageBox.Show("Database Error Details: \n" + (string.IsNullOrEmpty(errorMessage) ? "No rows were affected in the database (Ensure the CurrencyID is valid and exists)." : errorMessage), "SQL Error Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateFXInformationIcone_Click(object sender, EventArgs e)
        {

        }
    }
}
