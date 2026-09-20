using BankSystemDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemBuisniseLayer
{
    public class ClsCurrency
    {

        public int CurrencyID { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencySymbol { get; set; }
        public decimal ExchangeRate { get; set; }
        public bool IsActive { get; set; }
        public string FlagPath { get; set; }
        public string ExCgangeByUserID { get; set; }

       
        public decimal CurrentBuyRate { get; set; }
        public decimal CurrentSellRate { get; set; }
        public string ChangeReason { get; set; }

        public string ErrorMessage { get; set; }

      
        
        enum enMode { AddNew = 0, Update = 1 };
        enMode _Mode = enMode.Update;

         
        public ClsCurrency()
        {
            this.CurrencyID = -1;
            this.CurrencyCode = "";
            this.CurrencyName = "";
            this.CurrencySymbol = "";
            this.ExchangeRate = 1.0000m;
            this.IsActive = true;
            this.FlagPath = "";
            _Mode = enMode.AddNew;
        }
        private ClsCurrency(int currencyID, string currencyCode, string currencyName, string currencySymbol, decimal exchangeRate, bool isActive, string flagPath)
        {
            this.CurrencyID = currencyID;
            this.CurrencyCode = currencyCode;
            this.CurrencyName = currencyName;
            this.CurrencySymbol = currencySymbol;
            this.ExchangeRate = exchangeRate;
            this.IsActive = isActive;
            this.FlagPath = flagPath;
            _Mode = enMode.Update;
        }
        
        public static DataTable GetAllCurrencies(ref string ErrorMessage)
        {
          
            return ClsRateDataAccess.GetAllCurrencies(ref ErrorMessage);
        }

        public static DataTable GetAllCurrenciesName(ref string ErrorMessage)
        {
           

            return ClsRateDataAccess.GetAllCurrenciesName(ref ErrorMessage);
            
        }

        public static int GetCountOfCurrency(ref string ErrorMessage)

        {
            
            return ClsRateDataAccess.GetCountOfAllCurrencies(ref ErrorMessage);
        }

        public static int GetCountOfActiveCurrency(ref string ErrorMessage)

        {
            
            return ClsRateDataAccess.GetCountOfAllActiveCurrencies(ref ErrorMessage);
        }

        public static ClsCurrency FindByCurrencyID(int currencyID)
        {
           
           

            
            string currencyCode = string.Empty;
            string currencyName = string.Empty;
            string currencySymbol = string.Empty;
            decimal exchangeRate = 0;
            bool isActive = true;
            string flagPath = string.Empty;
            decimal currentBuyRate = 0;
            decimal currentSellRate = 0;
            string changedByUserID = string.Empty;
            string changeReason = string.Empty;

            bool isFound = ClsRateDataAccess.FindByCurrencyID(
                currencyID,
                ref currencyCode,
                ref currencyName,
                ref currencySymbol,
                ref exchangeRate,
                ref isActive,
                ref flagPath,
                ref currentBuyRate,
                ref currentSellRate,
                ref changedByUserID,
                ref changeReason
            );

            if (isFound)
            {


                ClsCurrency currency = new ClsCurrency(currencyID, currencyCode, currencyName, currencySymbol, exchangeRate, isActive, flagPath);

                
                currency.CurrentBuyRate = currentBuyRate;
                currency.CurrentSellRate = currentSellRate;
                currency.ExCgangeByUserID = changedByUserID;
                currency.ChangeReason = changeReason;

                currency._Mode = enMode.Update;
                return currency;

            }

            return null; 
        }

        public bool Save()
        {
            string errorMessage = string.Empty;

            switch (_Mode)
            {
                case enMode.AddNew:
                   
                    // return _AddNewCurrency();
                   

                case enMode.Update:
                    return _UpdateCurrencyRate(ref errorMessage);
            }

            return false;
        }

        private bool _UpdateCurrency(ref string errorMessage)
        {
            
            return ClsRateDataAccess.UpdateCurrency(
                this.CurrencyID,
                this.CurrencyName,
                this.CurrencySymbol,
                this.ExchangeRate,
                this.IsActive,
                this.FlagPath,
                this.ExCgangeByUserID, 
                "Updating Currency data via system",
                ref errorMessage
            );
        }
        public bool _UpdateCurrencyRate(ref string errorMessage)
        {
            
            return ClsRateDataAccess.UpdateCurrencyRate(
                this.CurrencyID,
                this.CurrentSellRate,
                this.CurrentBuyRate,
                this.ExchangeRate,
                this.ExCgangeByUserID,
                this.ChangeReason ?? "Updating Currency data via system",
                ref errorMessage
            );
        }


        public static bool UpdateExchangeRate(int currencyID, decimal newExchangeRate, string ExCgangeByUserID, string reason, ref string errorMessage)
        {
            return ClsRateDataAccess.UpdateExchangeRate(currencyID, newExchangeRate, ExCgangeByUserID, reason, ref errorMessage);
        }
    }
}
