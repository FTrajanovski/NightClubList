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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace NightClubList
{
    public partial class Form2 : Form
    {
        private string firstName;
        private string lastName;


        public Form2()
        {
            InitializeComponent();
        }
       


        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
           
             
            if (txtLastNameSearch.Text == "")
            {




                string connstring = "server=localhost;uid=root;pwd=Kadino44;database=inlämningsuppgift";
                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = connstring;
                con.Open();

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();



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
       

            }
            else if (txtLastNameSearch.Text != "")
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
            

            string selectedItem = listBox1.SelectedItem.ToString();
            string[] values = selectedItem.Split(" - ");
            string id = values[0];
            string firstName = values[1];
            string lastName = values[2];
            string email = values[3];
            string phone = values[4];
            
            
            textBox1.Text = firstName;
            textBox2.Text = lastName;
            textBox3.Text = email;
            textBox4.Text = phone;
            textBox5.Text = id;
           
            //if (textBox5.Text != "")
            //{
              //  button2.Enabled = false;
                
            //}
            







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
            else if (!int.TryParse(textBox4.Text, out int result))
            {
                MessageBox.Show("Phone Number must be a number");
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
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();



        }








        private void button4_Click(object sender, EventArgs e)
        {
            string connstring = "server=localhost;uid=root;pwd=Kadino44;database=inlämningsuppgift";
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = connstring;
            con.Open();
            if (textBox5.Text == "")
            {
                MessageBox.Show("Select a row to delete");
            }
            else
            {



                string updateSQL = "DELETE FROM nightclublist WHERE Id = @value1";
                using (MySqlCommand cmd = new MySqlCommand(updateSQL, con))
                {
                    cmd.Parameters.AddWithValue("@value1", textBox5.Text);
                    cmd.ExecuteNonQuery();

                }
                listBox1.Items.Clear();
                listBox1.Items.Add(textBox1.Text + " is deleted from the list");

            }
        }



        private void button5_Click(object sender, EventArgs e)
        {
            string connstring = "server=localhost;uid=root;pwd=Kadino44;database=inlämningsuppgift";
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = connstring;
            con.Open();

            if (textBox5.Text == "")
            {
                MessageBox.Show("Select a row to update the current data");
            }
            else
            {



                string updateSQL = "UPDATE nightclublist SET FirstName = @value2, LastName = @value3, EmailAdress = @value4, PhoneNumber = @value5 WHERE Id = @value1";
                using (MySqlCommand cmd = new MySqlCommand(updateSQL, con))
                {
                    cmd.Parameters.AddWithValue("@value1", textBox5.Text);
                    cmd.Parameters.AddWithValue("@value2", textBox1.Text);
                    cmd.Parameters.AddWithValue("@value3", textBox2.Text);
                    cmd.Parameters.AddWithValue("@value4", textBox3.Text);
                    cmd.Parameters.AddWithValue("@value5", textBox4.Text);

                    cmd.ExecuteNonQuery();
                }
                con.Close();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();


            }


        }


    }


    
} 