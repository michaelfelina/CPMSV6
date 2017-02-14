using Common.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPMS.BL
{
    public static class Security
    {
        private static string key = "ELIDTECH";
        public static string Encrypt(this string value) => Encryption.Encrypt(key, value);
        public static string Decrypt(this string value) => Encryption.Decrypt(key, value);
        public static string Encrypt(this object value) => Encryption.Encrypt(key, value.ToString());
        public static string Decrypt(this object value) => Encryption.Decrypt(key, value.ToString());
    }
}
