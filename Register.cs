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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // remove the text from the textboxes
            txtName.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtStatus.Text = "";
        }

        // if the form is closed, open the accounts form
        private void Register_FormClosed(object sender, FormClosedEventArgs e)
        {
    
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Button Clicked");

            // call the public class connection and create a new instance of it called conn
            connection conn = new connection();
            // create a new MySqlConnection called con and set it to the connect method from the conn instance
            MySqlConnection con = conn.connect();
            // open the connection
            con.Open();

            // create a new MySqlCommand called cmd and set it to the query to insert the data from the textboxes into the database
            MySqlCommand cmd = new MySqlCommand("INSERT INTO borrowers (Name, Address, Email, Status) VALUES ('" + txtName.Text + "', '" + txtAddress.Text + "', '" + txtEmail.Text + "', '" + txtStatus.Text + "')", con);
            // execute the query
            // if the textboxes are empty, show a message box
            if (txtName.Text == "" || txtAddress.Text == "" || txtEmail.Text == "" || txtStatus.Text == "")
            {
                MessageBox.Show("Please fill in all the fields");
            }
            else
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                MessageBox.Show("Account Added Successfully");

                this.Hide();
            }

            con.Close();

            // remove the text from the textboxes
            txtName.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtStatus.Text = "";
        }
    }
}
