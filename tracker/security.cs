using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tracker
{
    class security
    {
        private static string salt = "searchndestroy";
        public static string GenerateHash(string value)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(salt + value);
            data = System.Security.Cryptography.MD5.Create().ComputeHash(data);
            return Convert.ToBase64String(data);
        }
    }
}
