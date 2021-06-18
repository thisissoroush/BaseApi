using System.IO;
using System.Security.Cryptography;

namespace FrameWork.Security.Encryption
{
    public static class Encryption
    {
        static readonly string key = "39SNT2UQBUaC7FgCVABJoc/kpL+uRQA1b63kU4mrKJO=";
        static readonly char[] padding = { '=' };

        public static EncryptionModel EncryptPassword(string password)
        {
            EncryptionModel encryptedData = new EncryptionModel();
            using (TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider())
            {
                var sugar = EncryptionUtil.GenerateRandomCode();
                encryptedData.Sugar = EncryptSHA256(sugar);
                var salt = EncryptionUtil.ByteArrayToBase64String(tdes.IV);
                encryptedData.Salt = EncryptSHA256(salt);
                encryptedData.Password = Encrypt3Des(password, sugar, salt);
            }
            return encryptedData;
        }

        public static bool IsEqual(EncryptionModel encryptedData, string Password)
        {
            encryptedData.Salt = DecryptSHA256(encryptedData.Salt);
            encryptedData.Sugar = DecryptSHA256(encryptedData.Sugar);

            if (Encrypt3Des(Password, encryptedData.Sugar,encryptedData.Salt) == encryptedData.Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static string EncryptSHA256(string data)
        {

            byte[] toEncryptArry = EncryptionUtil.StringToByteArray(data);
            byte[] keyArry = EncryptionUtil.Base64StringToByteArray(key);

            var aes = new AesCryptoServiceProvider
            {
                Key = keyArry,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            ICryptoTransform cTransform = aes.CreateEncryptor();
            byte[] encrypted = cTransform.TransformFinalBlock(toEncryptArry, 0, toEncryptArry.Length);
            string encryptCode = EncryptionUtil.ByteArrayToBase64String(encrypted);

            encryptCode = encryptCode.TrimEnd(padding).Replace('+', '-').Replace('/', '_');
            return encryptCode;
        }

        public static string DecryptSHA256(string data)
        {
            string incoming = data.Replace('_', '/').Replace('-', '+');
            switch (data.Length % 4)
            {
                case 2: incoming += "=="; break;
                case 3: incoming += "="; break;
            }

            byte[] toDecryptArry = EncryptionUtil.Base64StringToByteArray(incoming);
            byte[] keyArry = EncryptionUtil.Base64StringToByteArray(key);
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider
            {
                Key = keyArry,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            ICryptoTransform cTransform = aes.CreateDecryptor();
            byte[] decrypted = cTransform.TransformFinalBlock(toDecryptArry, 0, toDecryptArry.Length);
            return EncryptionUtil.ByteArrayToString(decrypted);
        }

        public static string Encrypt3Des(string plainText, string key, string iv)
        {

            byte[] keyArray = EncryptionUtil.Base64StringToByteArray(key);
            byte[] ivArray = EncryptionUtil.Base64StringToByteArray(iv);
            byte[] toEncryptArray = EncryptionUtil.StringToByteArray(plainText);
            byte[] encrypted;
            using (TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider())
            {
                tdes.Padding = PaddingMode.PKCS7;
                tdes.Mode = CipherMode.ECB;
                ICryptoTransform encryptor = tdes.CreateEncryptor(keyArray, ivArray);
                using (MemoryStream ms = new MemoryStream())
                {

                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                            sw.Write(plainText);
                        encrypted = ms.ToArray();
                    }
                }
            }
            return EncryptionUtil.ByteArrayToBase64String(encrypted);

        }

        static string Decrypt3Des(string cipherText, string key, string iv)
        {
            byte[] keyArray = EncryptionUtil.Base64StringToByteArray(key);
            byte[] ivArray = EncryptionUtil.Base64StringToByteArray(iv);
            byte[] toDecryptArray = EncryptionUtil.Base64StringToByteArray(cipherText);
            string decrypted = "";


            using (TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider())
            {
                tdes.Padding = PaddingMode.PKCS7;
                tdes.Mode = CipherMode.ECB;
                ICryptoTransform decryptor = tdes.CreateDecryptor(keyArray, ivArray);
                using (MemoryStream ms = new MemoryStream(toDecryptArray))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(cs))
                            decrypted = reader.ReadToEnd();
                    }
                }
            }
            return decrypted;
        }
    }
}
