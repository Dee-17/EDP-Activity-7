using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LibraryIS
{
    public partial class Email : Form
    {
        public static Email instance;
        public TextBox tb1;
        public Email()
        {
            InitializeComponent();
            instance = this;
            tb1 = txtEmail;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            // create a new instance of the connection class called conn
            connection conn = new connection();
            // create a new MySqlConnection called con and set it to the connect method from the conn instance
            MySqlConnection con = conn.connect();
            // open the connection
            con.Open();

            // if the button is clicked, check if the email exist in the database in the table called admin and column called email_address
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM admin WHERE email_address = '" + txtEmail.Text + "'", con);
            MySqlDataReader reader = cmd.ExecuteReader();
            // if the email exist, then open the form called ForgotPassword
            if (reader.Read())
            {
                SecurityQuestions sq = new SecurityQuestions();
                sq.Show();
                this.Hide();

                SecurityQuestions.instance.lab1.Text = txtEmail.Text;

            } //else, show a message box that the email does not exist
            else
            {
                MessageBox.Show("Email does not exist");
            }

        }
    }
}
