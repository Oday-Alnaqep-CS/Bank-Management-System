using BankSystemBuisniseLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Managment_System
{
    public class ClsGetResultWhatDoyouWannt


    {


        public static string GetCurrentBranchName(int currentBranchID, out string errorMessage)


        {

            string query = "SELECT BranchName FROM Branches WHERE BranchID = @BranchID";
            SqlParameter[] parameters =
            {
                new SqlParameter("@BranchID", SqlDbType.Int) { Value = currentBranchID }
            };


            return ClsGetResults.GetResultsFrom<string>(query, parameters, out errorMessage);


        }


        public static string GetRole(int currentUserID, out string errorMessage)

        {

            string query = "SELECT Role FROM Rols WHERE UserID = @UserID";
            SqlParameter[] parameters =
            {
                new SqlParameter("@UserID", SqlDbType.Int) { Value = currentUserID }
            };


            return ClsGetResults.GetResultsFrom<string>(query, parameters, out errorMessage);

        }




    }
}
