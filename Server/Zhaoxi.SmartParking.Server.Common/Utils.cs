using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Zhaoxi.SmartParking.Server.ICommon;

namespace Zhaoxi.SmartParking.Server.Common
{
    public class Utils : IUtils
    {
        public string GetMD5Str(string inputStr)
        {
            if (string.IsNullOrEmpty(inputStr)) return "";

            byte[] result = Encoding.Default.GetBytes(inputStr);    //tbPass为输入密码的文本框
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            return BitConverter.ToString(output).Replace("-", "");  //tbMd5pass为输出加密文本的文本框
        }
    }
}
