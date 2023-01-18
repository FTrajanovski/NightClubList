using Google.Protobuf.WellKnownTypes;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NightClubList
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (txtLastNameSearch.Text == "")
            {




                string connstring = "server=localhost;uid=root;pwd=Kadino44;database=inlämningsuppgift";
                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = connstring;
                con.Open();



                string sql = "select * from inlämningsuppgift.nightclublist";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {


                    string item = "";
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        item += reader.GetValue(i).ToString() + " - ";
                    }
                    listBox1.Items.Add(item);
                }
                reader.Close();


                //   {
                //1        DataTable dt = new DataTable();
                //1        adapter.Fill(dt);
                //1 listBox1.DataSource = dt;
                //1 listBox1.DisplayMember = "FirstName";
                //1 listBox1.DisplayMember = "LastName";





                //MessageBox.Show
                //  listBox1.DisplayMember = ("FName " + reader["FirstName"] + "LName" + reader["LastName"] + "EAdress" + reader["EmailAdress"] + "PNumber" + reader["PhoneNumber"]);

                //   }
                //} catch(MySqlException ex)
                //  {
                //  MessageBox.Show(
                //   ex.ToString());
                //   listBox1.Text = ex.Message;
                //   }
            }
            else if(txtLastNameSearch.Text != "")
            {
               
                
                
                
                    string connstring = "server=localhost;uid=root;pwd=Kadino44;database=inlämningsuppgift";
                    MySqlConnection con = new MySqlConnection();
                    con.ConnectionString = connstring;
                    con.Open();

                string sql = "SELECT * FROM nightclublist WHERE LastName LIKE @searchText";
                MySqlCommand command = new MySqlCommand(sql, con);
                command.Parameters.AddWithValue("@searchText", "%" + txtLastNameSearch.Text + "%");
                MySqlDataReader reader = command.ExecuteReader();
                listBox1.Items.Clear();
                while (reader.Read())
                {
                    

                    string item = "";
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        item += reader.GetValue(i).ToString() + " - ";
                    }
                    listBox1.Items.Add(item);
                }
                reader.Close();
                txtLastNameSearch.Clear();



            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {

              string connstring = "server=localhost;uid=root;pwd=Kadino44;database=inlämningsuppgift";
              MySqlConnection con = new MySqlConnection();
              con.ConnectionString = connstring;
              con.Open();
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Please fill out all personal data");
            }
            else
            {


                string insertSQL = "INSERT INTO nightclublist (FirstName, LastName, EmailAdress, PhoneNumber) VALUES (@value1, @value2, @value3, @value4)";
                using (MySqlCommand cmd = new MySqlCommand(insertSQL, con))
                {
                    cmd.Parameters.AddWithValue("@value1", textBox1.Text);
                    cmd.Parameters.AddWithValue("@value2", textBox2.Text);
                    cmd.Parameters.AddWithValue("@value3", textBox3.Text);
                    cmd.Parameters.AddWithValue("@value4", textBox4.Text);

                    cmd.ExecuteNonQuery();
                }
                con.Close();
                listBox1.Items.Add(textBox1.Text);
                listBox1.Items.Add(textBox2.Text);
                listBox1.Items.Add(textBox3.Text);
                listBox1.Items.Add(textBox4.Text);
                listBox1.Items.Clear();

                listBox1.Items.Add(textBox1.Text + " is added to the list");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connstring = "server=localhost;uid=root;pwd=Kadino44;database=inlämningsuppgift";
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = connstring;
            con.Open();

            string sql = "DELETE FROM nightclublist WHERE ID = @id";
            MySqlCommand command = new MySqlCommand(sql, con);
            command.Parameters.AddWithValue("@id", listBox1.SelectedValue);
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {


                listBox1.Items.Remove(listBox1.SelectedItem);
            }con.Close();
        }
    }
}
