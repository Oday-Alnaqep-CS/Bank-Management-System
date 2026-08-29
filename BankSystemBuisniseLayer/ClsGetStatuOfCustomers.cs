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
                  ClsGetCountOfActiveAccountsDataAccess.GetCountOfActiveAccounts(out errorMessage);

        public static int GetCountOfInActiveAccounts(out string ErrorMessage) =>
                 ClsGetTotalClients.GetTotalClients(out ErrorMessage) - ClsGetCountOfActiveAccountsDataAccess.GetCountOfActiveAccounts(out ErrorMessage);

        public static int GetCountOfActiveCustomer(out string errorMessage) =>
                  ClsGetCountOfActiveAccountsDataAccess.GetCountOfActiveCustomer(out errorMessage);

        public static int GetCountOfInActiveCustomer(out string ErrorMessage) =>
                 ClsGetTotalClients.GetTotalClients(out ErrorMessage) - ClsGetCountOfActiveAccountsDataAccess.GetCountOfActiveCustomer(out ErrorMessage);
    }
}
