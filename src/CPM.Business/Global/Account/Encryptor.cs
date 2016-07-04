using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static CPM.Business.Global.Account.Encryption;

namespace CPM.Business.Global.Account
{
    public class Encryptor
    {

        #region _Encryption_

        public static string Encrypt(string value)
        {
            Symmetric sym = new Symmetric();

            CPM.Business.Global.Account.Encryption.Data encryptedData = default(CPM.Business.Global.Account.Encryption.Data);
            encryptedData = sym.Encrypt(new CPM.Business.Global.Account.Encryption.Data(value));

            return encryptedData.Base64;
        }

        public static string Decrypt(string value)
        {
            Symmetric sym = new Symmetric();

            CPM.Business.Global.Account.Encryption.Data encryptedData = new CPM.Business.Global.Account.Encryption.Data();
            encryptedData.Base64 = value;

            CPM.Business.Global.Account.Encryption.Data decryptedData = default(CPM.Business.Global.Account.Encryption.Data);
            decryptedData = sym.Decrypt(encryptedData);

            return decryptedData.Text;
        }

        #endregion

        #region _One way hashing_

        public static string EncryptOneWay(string value)
        {
            try
            {
                //The array of bytes that will contain the encrypted value of strPlainText
                byte[] hashedDataBytes = null;

                //The encoder class used to convert strPlainText to an array of bytes
                UTF8Encoding encoder = new UTF8Encoding();

                //Create an instance of the MD5CryptoServiceProvider class
                MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();

                //Call ComputeHash, passing in the plain-text string as an array of bytes
                //The return value is the encrypted value, as an array of bytes
                hashedDataBytes = md5Hasher.ComputeHash(encoder.GetBytes(value));

                //Convert encrypted byte array to string
                return encoder.GetString(hashedDataBytes).Replace("?", "?");
            }
            catch
            {
                return "";
            }
        }

        public static string EncryptOneWayBase64(string value)
        {
            try
            {
                //The array of bytes that will contain the encrypted value of strPlainText
                byte[] hashedDataBytes = null;

                //The encoder class used to convert strPlainText to an array of bytes
                UTF8Encoding encoder = new UTF8Encoding();

                //Create an instance of the MD5CryptoServiceProvider class
                MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();

                //Call ComputeHash, passing in the plain-text string as an array of bytes
                //The return value is the encrypted value, as an array of bytes
                hashedDataBytes = md5Hasher.ComputeHash(encoder.GetBytes(value));

                //Convert encrypted byte array to string
                return Convert.ToBase64String(hashedDataBytes).TrimEnd("=".ToCharArray());
            }
            catch
            {
                return "";
            }
        }

        #endregion
    }
}
