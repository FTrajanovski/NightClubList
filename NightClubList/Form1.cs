using Microsoft.VisualBasic.ApplicationServices;

namespace NightClubList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Helper.EstablishConnection();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            LogIn logIn = LogInDB.RetrieveUser(username);
            if (logIn.Password.Equals(password))
            {
                MessageBox.Show("Login Success");
                Form Form2 = new Form2();
                Form2.Show();
                this.Hide();


            }
            else
            {
                MessageBox.Show("Login Failed. Please try again");
                
                txtPassword.Text = "";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}