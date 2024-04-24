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
    public partial class SecurityQuestions : Form
    {
        public static SecurityQuestions instance;
        public Label lab1;
        public SecurityQuestions()
        {
            InitializeComponent();
            instance = this;
            lab1 = txtEmail;
        }

        private void SecurityQuestions_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // create a new instance of the connection class called conn
            connection conn = new connection();
            // create a new MySqlConnection called con and set it to the connect method from the conn instance
            MySqlConnection con = conn.connect();
            // open the connection
            con.Open();


            // check if the email exists in the database 
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM admin WHERE email_address = '" + txtEmail.Text + "'", con);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                // check if the security question answers in the database are null or not
                if (reader["secOne"].ToString() != "" && reader["secTwo"].ToString() != "" && reader["secThree"].ToString() != "")
                {
                    // check if the email and the answer exist in the database in the table called admin and column called email_address and secOne, secTwo, secThree
                    reader.Close();
                    MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM admin WHERE email_address = '" + txtEmail.Text + "' AND secOne = '" + txtAnswerOne.Text + "' AND secTwo = '" + txtAnswerTwo.Text + "' AND secThree = '" + txtAnswerThree.Text + "'", con);
                    MySqlDataReader reader2 = cmd1.ExecuteReader();
                    if (reader2.Read())
                    {
                        // if the email and the answers exist in the database, then show a message box to show that the answers are correct
                        ResetPassword reset = new ResetPassword();
                        reset.Show();
                        this.Hide();

                        ResetPassword.instance.lab1.Text = txtEmail.Text;
                    }
                    else
                    {
                        // if the email and the answers do not exist in the database, then show a message box to show that the answers are incorrect
                        MessageBox.Show("Incorrect answers");
                    }

                    reader2.Close();

                }
                else
                {
                    reader.Close();
                    // get the text from the textboxes and update the null columns
                    string sql = "UPDATE admin SET secOne = @secOne, secTwo = @secTwo, secThree = @secThree WHERE email_address = @email";
                    MySqlCommand cmd2 = new MySqlCommand(sql, con);

                    // Set parameters to prevent SQL injection
                    cmd2.Parameters.AddWithValue("@secOne", txtAnswerOne.Text);
                    cmd2.Parameters.AddWithValue("@secTwo", txtAnswerTwo.Text);
                    cmd2.Parameters.AddWithValue("@secThree", txtAnswerThree.Text);
                    cmd2.Parameters.AddWithValue("@email", txtEmail.Text);

                    // Execute the query
                    MySqlDataReader reader3 = cmd2.ExecuteReader();

                    // Close the connection
                    con.Close();
                    // close the reader
                    reader3.Close();

                    // pop up a message box to show that the security questions have been set
                    MessageBox.Show("Security questions have been set");

                    // open the login form and close the security questions form
                    Login login = new Login();
                    login.Show();  
                    this.Hide();

                }

            }
            else
            {
                // if the email does not exist, then show an error message
                MessageBox.Show("Email does not exist");
            }


















        }
    }
}
