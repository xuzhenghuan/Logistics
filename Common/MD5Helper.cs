﻿using System;
using System.Security.Cryptography;
using System.Text;

namespace Logistics.Common
{
    public class MD5Helper
    {
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="input">需要加密的字符串</param>
        /// <returns></returns>
        public static string MD5Encrypt(string input)
        {
            return MD5Encrypt(input, new UTF8Encoding());
        }

        /// <summary>
        /// md5加密16|32位
        /// </summary>
        /// <param name="input"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string MD5Encrypt(string input, int length)
        {
            string res = MD5Encrypt(input, new UTF8Encoding());
            if (length == 16)
            {
                res = res.Substring(8, 16);
            }
            return res;
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="input">需要加密的字符串</param>
        /// <param name="encode">字符的编码</param>
        /// <returns></returns>
        public static string MD5Encrypt(string input, Encoding encode)
        {
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }
            StringBuilder sBuilder = new StringBuilder();
            using (MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider())
            {
                byte[] data = md5Hasher.ComputeHash(encode.GetBytes(input));
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
            }
            return sBuilder.ToString();
        }
    }
}
