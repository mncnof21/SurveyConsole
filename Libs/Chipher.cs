using System;
using System.Security.Cryptography;
using System.Text;

namespace SurveyConsole.Libs
{
    public class Chipher
    {
        private const int Keysize = 256;
        private const int DerivationIterations = 1000;
        public static string passPhrase = "mfin";

        public static string key = "447FC2AA6EFFFEE5405A559E88DC958C";
        public static string iv = "A5D!A6EF";

        public static string Encryptword(string vText)
        {
            var tripleDESCipher = new TripleDESCryptoServiceProvider();
            tripleDESCipher.Mode = CipherMode.CBC;
            tripleDESCipher.Padding = PaddingMode.PKCS7;
            byte[] pwdBytes = System.Text.Encoding.UTF8.GetBytes(key);
            byte[] keyBytes = new byte[24];
            int len = pwdBytes.Length;
            if (len > keyBytes.Length)
                len = keyBytes.Length;
            System.Array.Copy(pwdBytes, keyBytes, len);
            tripleDESCipher.Key = keyBytes;
            tripleDESCipher.IV = Encoding.ASCII.GetBytes(iv);

            ICryptoTransform transform = tripleDESCipher.CreateEncryptor();
            byte[] plainText = Encoding.UTF8.GetBytes(vText);
            byte[] cipherBytes = transform.TransformFinalBlock(plainText, 0, plainText.Length);
            return Convert.ToBase64String(cipherBytes);
        }

        public static string Decryptword(string vText)
        {
            var tripleDESCipher = new TripleDESCryptoServiceProvider();
            tripleDESCipher.Mode = CipherMode.CBC;
            tripleDESCipher.Padding = PaddingMode.PKCS7;

            byte[] encryptedData = Convert.FromBase64String(vText);
            byte[] pwdBytes = System.Text.Encoding.UTF8.GetBytes(key);
            byte[] keyBytes = new byte[24];
            byte[] ivBytes = Encoding.ASCII.GetBytes(iv);
            int len = pwdBytes.Length;
            if (len > keyBytes.Length)
                len = keyBytes.Length;
            System.Array.Copy(pwdBytes, keyBytes, len);
            tripleDESCipher.Key = keyBytes;
            tripleDESCipher.IV = ivBytes;
            ICryptoTransform transform = tripleDESCipher.CreateDecryptor();
            byte[] plainText = transform.TransformFinalBlock(encryptedData, 0, encryptedData.Length);
            return Encoding.UTF8.GetString(plainText);
        }

        public static string Encryptword2(string Encryptval)
        {
            byte[] SrctArray;
            byte[] EnctArray = UTF8Encoding.UTF8.GetBytes(Encryptval);
            SrctArray = UTF8Encoding.UTF8.GetBytes(passPhrase);
            TripleDESCryptoServiceProvider objt = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider objcrpt = new MD5CryptoServiceProvider();
            SrctArray = objcrpt.ComputeHash(UTF8Encoding.UTF8.GetBytes(passPhrase));
            objcrpt.Clear();
            objt.Key = SrctArray;
            objt.Mode = CipherMode.ECB;
            objt.Padding = PaddingMode.PKCS7;
            ICryptoTransform crptotrns = objt.CreateEncryptor();
            byte[] resArray = crptotrns.TransformFinalBlock(EnctArray, 0, EnctArray.Length);
            objt.Clear();
            return Convert.ToBase64String(resArray, 0, resArray.Length);
        }
        public static string Decryptword2(string DecryptText)
        {
            byte[] SrctArray;
            byte[] DrctArray = Convert.FromBase64String(DecryptText);
            SrctArray = UTF8Encoding.UTF8.GetBytes(passPhrase);
            TripleDESCryptoServiceProvider objt = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider objmdcript = new MD5CryptoServiceProvider();
            SrctArray = objmdcript.ComputeHash(UTF8Encoding.UTF8.GetBytes(passPhrase));
            objmdcript.Clear();
            objt.Key = SrctArray;
            objt.Mode = CipherMode.ECB;
            objt.Padding = PaddingMode.PKCS7;
            ICryptoTransform crptotrns = objt.CreateDecryptor();
            byte[] resArray = crptotrns.TransformFinalBlock(DrctArray, 0, DrctArray.Length);
            objt.Clear();
            return UTF8Encoding.UTF8.GetString(resArray);
        }
    }
}
