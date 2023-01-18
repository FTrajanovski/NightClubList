using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightClubList
{
    public class LogIn
    {
        
       
            private string username;
            private string password;

            public LogIn(string username, string password)
            {
                UserName = username;
                Password = password;
            }

            public String UserName
            {
                get { return username; }
                set { username = value; }
            }

            public String Password
            {
                get { return password; }
                set { password = value; }
            }
        }
}
