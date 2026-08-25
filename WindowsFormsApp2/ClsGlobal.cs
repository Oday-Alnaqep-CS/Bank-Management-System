using System;
using System.IO;
using System.Windows.Forms;
using BankSystemBuisniseLayer;

namespace Bank_Managment_System
{
    public static class ClsGlobal
    {
        
        public static ClsUser CurrentUser = new ClsUser();

      


        public static bool CheckAccessPermission(int permissionID)
        {


            if (CurrentUser == null)
                return false;

          

            if (CurrentUser.Permissions == -1)
                return true;

            return (CurrentUser.Permissions & permissionID) == permissionID;


        }



        public static bool RememberUsernameAndPassword(string username, string password)


        {

            try
            {
               


                string filePath = Path.Combine(Application.StartupPath, "RememberMe.txt");


                if (string.IsNullOrEmpty(username) && File.Exists(filePath))


                {

                    File.Delete(filePath);
                    return true;

                }

               

                string rawData = username + "#//#" + password;

              
                string encryptedData = ClsEncryption.Encrypt(rawData);

               
                File.WriteAllText(filePath, encryptedData);
                return true;


            }

            catch (Exception ex)


            {

                MessageBox.Show("Error: " + ex.Message, "Wronge", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }


        }

        public static bool GetStoredCredential(ref string username, ref string password)


        {

            try
            {

                string filePath = Path.Combine(Application.StartupPath, "RememberMe.txt");

                if (File.Exists(filePath))


                {
                  

                    string encryptedData = File.ReadAllText(filePath);

                
                    string decryptedData = ClsEncryption.Decrypt(encryptedData);

                    if (!string.IsNullOrEmpty(decryptedData))


                    {
                      
                        string[] result = decryptedData.Split(new string[] { "#//#" }, StringSplitOptions.None);

                        if (result.Length == 2)


                        {
                            username = result[0];
                            password = result[1];
                            return true;
                        }

                    }

                }


                return false;
            }

            catch (Exception ex)
            {
                MessageBox.Show("خطأ أثناء استرجاع بيانات الدخول: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }



    }

}