using BankDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemBuisniseLayer
{
    public class clsBankSystemDataBaseManager
    {

        public static void InitializeDatabase()
        {
            DatabaseInitializer.InitializeDatabase();
        }
    }
}
