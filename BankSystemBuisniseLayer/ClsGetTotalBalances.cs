using BankSystemDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemBuisniseLayer
{
    public static class ClsGetTotalBalances
    {

        public static decimal GetTotalBalance(out string errorMessage)
        {

            return ClsGetTotalBalanceDataAccess.GetTotalBalance(out errorMessage);

        }
    }
}
