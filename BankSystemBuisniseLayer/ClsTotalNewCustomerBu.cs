using BankSystemDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemBuisniseLayer
{
    public static class ClsTotalNewCustomerBu
    {

        public static int GetTotalNewCustomer(ref string ErrorMessage)

        {
            return ClsTotalNewCustomersDataAccess.GetTotalNewCustomersCount(ref  ErrorMessage);
        }

    }
}
