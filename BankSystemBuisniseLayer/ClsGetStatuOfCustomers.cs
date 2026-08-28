using BankSystemDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemBuisniseLayer
{
    public static class  ClsGetStatuOfCustomers
    {

        public static int GetCountOfActiveAccounts(out string errorMessage) =>
                  ClsGetCountOfActiveAccountsDataAccess.GetActiveAccounts(out errorMessage);

        public static int GetCountOfInActiveAccounts(out string ErrorMessage) =>
                 ClsGetTotalClients.GetTotalClients(out ErrorMessage) - ClsGetCountOfActiveAccountsDataAccess.GetActiveAccounts(out ErrorMessage);
    }
}
