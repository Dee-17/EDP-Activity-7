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
    public partial class Signup : Form
    {
        public static Signup instance;
        public TextBox txt1;
        public Signup()
        {
            InitializeComponent();
            instance = this;
            txt1 = txtEmail;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            // if the checkbox is checked
            if (checkShowPass.Checked)
            {
                // show the password
                txtConfirmPassword.UseSystemPasswordChar = false;
            }
            else
            {
                // hide the password
                txtConfirmPassword.UseSystemPasswordChar = true;
            }
        }

        private void createAccLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // close the current form and open the login form
            this.Close();
            Login login = new Login();
            login.Show();
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            // check if the password and confirm password are the same, else print an error message
            if (txtPassword.Text == txtConfirmPassword.Text)
            {
                // create a new instance of the connection class called conn
                connection conn = new connection();
                // create a new MySqlConnection called con and set it to the connect method from the conn instance
                MySqlConnection con = conn.connect();
                // open the connection
                con.Open();

                // get the values from the textboxes of username, email, and password and store them in variables
                string username = txtUsername.Text;
                string email = txtEmail.Text;
                string password = txtPassword.Text;

                // create a new MySqlCommand called cmd and set it to the query to insert the values into the database
                MySqlCommand cmd = new MySqlCommand("INSERT INTO admin (username, email_address, password) VALUES ('" + username + "', '" + email + "', '" + password + "')", con);
                // execute the query
                MySqlDataReader reader = cmd.ExecuteReader();

                // pop out a message box to show that the account has been created
                MessageBox.Show("Answer your security questions.");

                // close the connection
                con.Close();

                // if okay was clicked, close the current form and open the security questions form
                SecurityQuestions securityQuestions = new SecurityQuestions();
                securityQuestions.Show();

                SecurityQuestions.instance.lab1.Text = txtEmail.Text;

                this.Close();
            }
            else
            {
                MessageBox.Show("Passwords do not match");
            }

        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            txtConfirmPassword.UseSystemPasswordChar = false;

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;

        }
    }
}
