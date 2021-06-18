using System;
using System.Collections.Generic;
using System.Text;

namespace FrameWork.Security.Encryption
{
    public static class EncryptionUtil
    {
        public static byte[] StringToByteArray(string data)
        {
            return Encoding.UTF8.GetBytes(data);
        }
        public static string ByteArrayToString(byte[] data)
        {
            return Encoding.UTF8.GetString(data, 0, data.Length);
        }
        public static byte[] Base64StringToByteArray(string data)
        {
            return Convert.FromBase64String(data);
        }
        public static string ByteArrayToBase64String(byte[] data)
        {
            return Convert.ToBase64String(data);
        }
        public static string GenerateRandomCode()
        {
            Guid g = Guid.NewGuid();
            return Convert.ToBase64String(g.ToByteArray());
        }
    }
}
