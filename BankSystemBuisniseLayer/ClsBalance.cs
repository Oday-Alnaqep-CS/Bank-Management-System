using System;
using System.Data;
using System.Runtime.InteropServices;
using BankSystemDataAccess;


namespace BankSystemBuisniseLayer
{
    public static class ClsBalance
    {


        public static DataTable GetAllBalances(ref string ErrirMessage)

        {

            return ClsBalanceData.GetAllBalance(ref ErrirMessage);
        }
    }
}
