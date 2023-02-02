using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightClubList
{
    public static class LogInDB
    {
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;

        public static LogIn RetrieveUser(string username)
        {
            string query = "SELECT * FROM inlamningsuppgift.login where userName = (@username) limit 1";
            cmd = Helper.RunQuery(query, username);
            LogIn logIn = null;
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    string uName = dr["username"].ToString();
                    string password = dr["password"].ToString();
                    logIn = new LogIn(uName, password);
                }
            }
            return logIn;
        }
    }
}
