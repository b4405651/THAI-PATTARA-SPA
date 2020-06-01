using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPA_MANAGEMENT_SYSTEM
{
    public class CRYPT
    {
        public static string Encode(String text)
        {
            return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(text));
        }

        public static string Decode(String text)
        {
            return System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(text));
        }
    }
}
