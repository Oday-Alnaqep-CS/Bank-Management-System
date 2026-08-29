using System;
using System.Data;
using BankSystemDataAccess;


namespace BankSystemBuisniseLayer
{
    public static class ClsCountry
    {

        public static DataTable GetAllCountries(ref string ErrorMessage)
        {
            return ClsCountryDataAccess.GetCountries(ref ErrorMessage);
        }
    }
}
