using System;
using System.Security.Cryptography;
using System.Text;

namespace Bank_Managment_System
{
    public static class ClsEncryption
    {
       
        public static string Encrypt(string Text)


        {
            if (string.IsNullOrEmpty(Text))
                
                return "";

            byte[] plainBytes = Encoding.UTF8.GetBytes(Text);
            
            byte[] encryptedBytes = ProtectedData.Protect(plainBytes, null, DataProtectionScope.CurrentUser);

            return Convert.ToBase64String(encryptedBytes);

        }



        public static string Decrypt(string cipherText)


        {
            if (string.IsNullOrEmpty(cipherText))
                
                return "";

            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            byte[] decryptedBytes = ProtectedData.Unprotect(cipherBytes, null, DataProtectionScope.CurrentUser);

            return Encoding.UTF8.GetString(decryptedBytes);


        }
    }
}