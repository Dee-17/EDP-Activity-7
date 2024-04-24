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
    public partial class ResetPassword : Form
    {
        public static ResetPassword instance;
        public Label lab1;
        public ResetPassword()
        {
            InitializeComponent();
            instance = this;
            lab1 = txtEmail;
        }

        private void Password_TextChanged(object sender, EventArgs e)
        {
            txtNewPassword.UseSystemPasswordChar = true;

        }

        private void checkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            // if the checkbox is checked, show the password
            if (checkShowPass.Checked)
            {
                txtConfirmPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtConfirmPassword.UseSystemPasswordChar = true;
            }
        }


        private void loginBtn_Click(object sender, EventArgs e)
        {
            // check if the password and confirm password are the same
            if (txtNewPassword.Text == txtConfirmPassword.Text)
            {
                //call public class connection and create a new instance of it called conn
                connection conn = new connection();
                //create a new MySqlConnection called con and set it to the connect method from the conn instance
                MySqlConnection con = conn.connect();
                //open the connection
                con.Open();

                MySqlCommand update = new MySqlCommand("UPDATE admin SET password = '" + txtNewPassword.Text + "' WHERE email_address = '" + txtEmail.Text + "'", con);
                MySqlDataReader updateReader = update.ExecuteReader();
                MessageBox.Show("Password updated successfully");

                // if okay was clicked in the message box, then open the form called Login 
                Login login = new Login();
                login.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Password and Confirm Password do not match");
            }
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            txtConfirmPassword.UseSystemPasswordChar = false;
        }

        private void createAccLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // close the form and open the login form
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
