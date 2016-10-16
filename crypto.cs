using System;
using System.Text;


namespace CY12031
{
    public class Crypto
    {


        public static string getMD5Sum(string source)
        {

            return getMD5Sum(source, "base64");
        }

        public static string getMD5Sum(string source, string format)
        {

            System.Security.Cryptography.MD5CryptoServiceProvider MD5CSP = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] byteSource = System.Text.Encoding.UTF8.GetBytes(source);
            byte[] byteHash = MD5CSP.ComputeHash(byteSource);
            if (format == "base64")
            {
                return Convert.ToBase64String(byteHash);

            }
            else
            {
                return toHex(byteHash);
            }


        }

        public static string toHex(byte[] bytes)
        {

            StringBuilder sb = new StringBuilder();
            if (bytes == null)
            {
                return "";
            }
            for (int i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("x2"));
            }
            return sb.ToString();

        }

        /// <summary>
        /// 获取签名
        /// </summary>
        /// <param name="signStr">待签名字符串</param>
        /// <returns></returns>
        public static string getSignature(string signStr)
        {

            return getMD5Sum(signStr);

        }

    }
}
