using ContactsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemBuisniseLayer
{
    public class clsSystemHealth


    {

        public static bool IsDatabaseConnected(ref string ErrorMessage)

        {

            return ClsDataAccessSettings.CheckDatabaseConnection(ref ErrorMessage);

        }
    }
}
