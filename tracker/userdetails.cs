using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tracker
{
    class userdetails
    {
        public static int ID;
        public static int GroupId;
        public static string Username;
        public static string Password;

        public static void Reset()
        {
            ID = 0;
            GroupId = 0;
            Username = null;
            Password = null;
        }
    }
}
