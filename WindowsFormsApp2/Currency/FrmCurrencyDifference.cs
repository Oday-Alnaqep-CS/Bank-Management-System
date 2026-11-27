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
using System.Windows.Forms;

namespace Bank_Managment_System
{
    public partial class FrmCurrencyDifference : Form
    {

        private ClsCurrency _FromCurrency = null;
        private ClsCurrency _ToCurrency = null;

        public FrmCurrencyDifference()
        {
            InitializeComponent();
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void CurrencyDifference_Load(object sender, EventArgs e)
        {

            _FillCurrencyName();
            PictuIconeDiff.Image = IconChar.ExchangeAlt.ToBitmap(Color.DodgerBlue);


        }

        private void _FillCurrencyName()
        {


            string ErrorMessage = string.Empty;
            DataTable dtCurrencyInfo = ClsCurrency.GetAllCurrenciesName(ref ErrorMessage);


            if (dtCurrencyInfo == null)
            {
                ClsBankingNotification.ShowBankingNotification("Error", "this dtCurrencyInfo is null", ClsBankingNotification.NotificationType.Error);
                return;
            }

            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ClsBankingNotification.ShowBankingNotification("Error", ErrorMessage, ClsBankingNotification.NotificationType.Error);
                return;
            }


            DataTable dtCurrencyInfo2 = dtCurrencyInfo.Copy();

            CbFromCurrencyName.DataSource = dtCurrencyInfo;
            CbFromCurrencyName.DisplayMember = "currency Name";
            CbFromCurrencyName.ValueMember = "Currency ID";
            CbFromCurrencyName.SelectedIndex = -1;

            CbToCurrencyName.DataSource = dtCurrencyInfo2;
            CbToCurrencyName.DisplayMember = "currency Name";
            CbToCurrencyName.ValueMember = "Currency ID";
            CbToCurrencyName.SelectedIndex = -1;



        }



        private void btnCalculateCurrencyDiff_Click(object sender, EventArgs e)
        {

        }

        private void txtAmountToDiff_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtAmountYouWillGet_ValueChanged(object sender, EventArgs e)
        {

        }

        private void CbFromCurrencyName_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (CbFromCurrencyName.SelectedValue == null)
                return;


            int.TryParse(CbFromCurrencyName.SelectedValue.ToString(), out int CurrencyID);

            if (CurrencyID > 0)
            {

                _ToCurrency = ClsCurrency.FindByCurrencyID(CurrencyID);

                if (_ToCurrency == null)
                {
                    MessageBox.Show("This Currency was not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!string.IsNullOrEmpty(_ToCurrency.FlagPath) && System.IO.File.Exists(_ToCurrency.FlagPath))

                {
                    PictCurrencyNameIcone.Image = Image.FromFile(_ToCurrency.FlagPath);
                }
                else
                {
                    PictCurrencyNameIcone.Image = null;
                }

            }

        }

        private void CbToCurrencyName_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (CbToCurrencyName.SelectedValue == null)
                return;


            int.TryParse(CbToCurrencyName.SelectedValue.ToString(), out int CurrencyID);

            if (CurrencyID > 0)
            {

                _ToCurrency = ClsCurrency.FindByCurrencyID(CurrencyID);

                if (_ToCurrency == null)
                {
                    MessageBox.Show("This Currency was not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!string.IsNullOrEmpty(_ToCurrency.FlagPath) && System.IO.File.Exists(_ToCurrency.FlagPath))

                {
                    PictToCurrencyNameIcone.Image = Image.FromFile(_ToCurrency.FlagPath);
                }
                else
                {
                    PictToCurrencyNameIcone.Image = null;
                }

            }

        }

        private void btnCancels_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _CalculateExchange()

        {
              
            if (!decimal.TryParse(txtAmount.Text.Trim(), out decimal amount) || amount <= 0)
            {
                txtAmountYouWillGet.Text = "0.00";
                return;
            }

             
            if (_FromCurrency == null || _ToCurrency == null)
                return;

            try
            {
                decimal resultAmount = 0;
                decimal exchangeRate = 0;

                if (_FromCurrency.CurrencyID == _ToCurrency.CurrencyID)
                {
                    resultAmount = amount;
                    exchangeRate = 1;
                }
                else
                {
                    decimal amountInBase = amount / _FromCurrency.ExchangeRate;
                    resultAmount = amountInBase * _ToCurrency.ExchangeRate;
                    exchangeRate = _ToCurrency.ExchangeRate / _FromCurrency.ExchangeRate;
                }

                 
                txtAmountYouWillGet.Text = resultAmount.ToString("N2");
                lblExchangeRateInfo.Text = $"{_FromCurrency.CurrencyCode} = {exchangeRate:N4} {_ToCurrency.CurrencyCode}";
            }
            catch (Exception ex)
            {
                ClsBankingNotification.ShowBankingNotification("Error", ex.Message, ClsBankingNotification.NotificationType.Error);
            }
        }

    }
}
