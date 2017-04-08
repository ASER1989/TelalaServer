using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Extends
{
    public static class StringExtend
    {
        public static string ToMD5(this string str)
        {
            if (str == null) return str;

            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = System.Text.Encoding.Unicode.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null; 
            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x");
            }

            return byte2String;
        }

        public static string ObjToString(this object str, string defval = null)
        {
            try
            {

                if (str == null)
                {
                    return defval;
                }
                return str.ToString();
            }
            catch (Exception ex)
            {
                return defval;
            }
        }
 
 

        public static string ToString(this DateTime? date, string part)
        {
            try
            {
                if (date == null)
                {
                    return null;
                }

                DateTime time = date ?? DateTime.Now;
                return time.ToString(part);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
