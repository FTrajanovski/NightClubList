﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightClubList
{
    public static class Helper
    {


        private static MySqlConnection connection;
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;

        public static void EstablishConnection()
        {
            try
            {
                MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
                builder.Server = "127.0.0.1";
                builder.UserID = "root";
                builder.Password = "Kadino44";
                builder.Database = "inlamningsuppgift";
                builder.SslMode = MySqlSslMode.None;
                connection = new MySqlConnection(builder.ToString());
                MessageBox.Show("Database connection successfull", "Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("connection Failed");
            }
        }
        public static MySqlCommand RunQuery(string query, string username)
        {
            try
            {
                if (connection != null)
                {
                    connection.Open();
                    cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                connection.Close();
            }
            return cmd;


        }
}   }
