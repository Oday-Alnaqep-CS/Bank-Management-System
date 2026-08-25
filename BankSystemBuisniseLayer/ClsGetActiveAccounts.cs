using BankSystemDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemBuisniseLayer
{
    public static class  ClsGetActiveAccounts
    {

        public static int GetActiveAccounts(out string errorMessage)
        {

            return ClsGetActiveAccountsDataAccess.GetActiveAccounts(out errorMessage);

        }
    }
}
