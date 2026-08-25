using BankSystemDataAccess.EntitiesData;
using BankSystemDataAccess.FinancialData;
using System;
using System.Data;

namespace BankSystemBuisniseLayer
{
    public class ClsCard
    {
        public enum enMode { AddNew = 1, Update = 2 }
        public enMode Mode = enMode.AddNew;

        public int CardID { get; set; }
        public int AccountID { get; set; }
        public string CardNumber { get; set; }
        public byte CardTypeID { get; set; }
        public string PIN { get; set; }
        public string CVV { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }
        public string ErrorMessage { get; set; }

        public ClsCard()
        {
            this.CardID = -1;
            this.AccountID = -1;
            this.CardNumber = "";
            this.CardTypeID = 0;
            this.PIN = "";
            this.CVV = "";
            this.ExpiryDate = DateTime.Now;
            this.IsActive = true;

            Mode = enMode.AddNew;
        }

        public ClsCard(int cardID, int accountID, string cardNumber, byte cardTypeID, string pin, string cvv, DateTime expiryDate, bool isActive)
        {
            this.CardID = cardID;
            this.AccountID = accountID;
            this.CardNumber = cardNumber;
            this.CardTypeID = cardTypeID;
            this.PIN = pin;
            this.CVV = cvv;
            this.ExpiryDate = expiryDate;
            this.IsActive = isActive;

            Mode = enMode.Update;
        }

        public static ClsCard Find(int cardID, ref string errorMessage)
        {
            int accountID = -1;
            string cardNumber = "", pin = "", cvv = "";
            byte cardTypeID = 0;
            DateTime expiryDate = DateTime.MinValue;
            bool isActive = false;

            if (ClsCardData.GetCardByID(cardID, ref accountID, ref cardNumber, ref cardTypeID, ref pin, ref cvv, ref expiryDate, ref isActive, ref errorMessage))
            {
                return new ClsCard(cardID, accountID, cardNumber, cardTypeID, pin, cvv, expiryDate, isActive);
            }

            return null;
        }

        public static DataTable GetAllCards(ref string errorMessage)
        {
            return ClsCardData.GetCardsView(ref errorMessage);
        }
    }
}