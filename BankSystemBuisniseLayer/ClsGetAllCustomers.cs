using BankSystemDataAccess;
using BankSystemDataAccess.EntitiesData;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Packaging;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace BankSystemBuisniseLayer
{
    public static class ClsGetAllCustomers
    {

        public static DataTable GetAllCustomersInFo(ref string Errormessage) =>
                ClsClientDataAccess.GetAllCustomers(ref Errormessage);

        
    }
}
