using System;
using BankSystemDataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemBuisniseLayer
{
    public static class ClsGetTotalClients
    {

        public static int GetTotalClients(out string ErrorMessage)
        {
            return ClsGetTotalClientsDataAccess.GetTotalClients(out ErrorMessage);
        }
    }
}
