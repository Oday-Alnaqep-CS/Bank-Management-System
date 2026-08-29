using BankSystemDataAccess;
using System;
using System.Data;


namespace BankSystemBuisniseLayer
{
    public static class ClsCities
    {

        public static DataTable GetCitiesByCountryID(int CountryID, ref string ErroeMessge)
        {
            return ClsCitiesDataAccess.GetCitiesByCountryID(CountryID, ref ErroeMessge);
        }
    }
}
