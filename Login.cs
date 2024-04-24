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
    public partial class Login : Form
    {
        public static Login instance;
        public TextBox tb1;
        public Login()
        {
            InitializeComponent();
            instance = this;
            tb1 = txtUsername;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            //call public class connection and create a new instance of it called conn
            connection conn = new connection();
            //create a new MySqlConnection called con and set it to the connect method from the conn instance
            MySqlConnection con = conn.connect();
            //open the connection
            con.Open();
        }

        private void Username_TextChanged(object sender, EventArgs e)
        {
        }

        private void checkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkShowPass.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            // create a new instance of the connection class called conn
            connection conn = new connection();
            // create a new MySqlConnection called con and set it to the connect method from the conn instance
            MySqlConnection con = conn.connect();

            // open the connection
            con.Open();

            // if the button is clicked, get the username and password from the textboxes and check if they are in the database in a table called admin and columns called username and password
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM admin WHERE username = @username AND password = @password", con);
            cmd.Parameters.AddWithValue("@username", txtUsername.Text);
            cmd.Parameters.AddWithValue("@password", txtPassword.Text);
            MySqlDataReader reader = cmd.ExecuteReader();
            

            // if the username and password are in the database, open the dashboard form and close the login form
            if (reader.Read())
            {
                // open dashboard form
                MenuForm menu = new MenuForm();
                menu.Show();
                this.Hide();

                MenuForm.instance.lab1.Text = txtUsername.Text;
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }

            // close the connection
            con.Close();

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Email email = new Email();
            email.Show();
            this.Hide();
        }

        private void createAccLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // if the link is clicked, open the signup form and close the login form
            Signup signup = new Signup();
            signup.Show();
            this.Hide();
        }
    }
 }


// create public class called connection
public class connection
{
    // create a public method called connect
    public MySqlConnection connect()
    {
        // create a string variable called conString and set it to the connection string
        string conString = "server=localhost;user id=root; pwd=1412; database=infosys";
        // create a MySqlConnection variable called con and set it to a new MySqlConnection with the conString as the parameter
        MySqlConnection conn = new MySqlConnection(conString);
        // return the con variable
        return conn;
    }
}
