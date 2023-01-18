using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace NightClubList
{
    public class PersonDB
    {
      
        public void Search(string searchTerm, ListBox listbox)
        {
            string connstring = "server=localhost;uid=root;pwd=Kadino44;database=inlämningsuppgift";
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = connstring;
            con.Open();

            // Execute the query
            String sql = ("SELECT * FROM nightclublist WHERE name LIKE @searchTerm");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");
            MySqlDataReader reader = cmd.ExecuteReader();

            // Clear the listbox and populate it with the new data
            listbox.Items.Clear();
            while (reader.Read())
            {
                listbox.Items.Add(reader["LastName"].ToString());
            }
        }



        }

}

