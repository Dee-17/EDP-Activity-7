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
    public partial class Accounts : Form
    {
        public Accounts()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // if a row is clicked, get the data from the row and put it in the textboxes
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtStatus.Text = row.Cells["Status"].Value.ToString();
                txtID.Text = row.Cells["ID"].Value.ToString();

            }

        }

        private void Accounts_Load(object sender, EventArgs e)
        {
            // call public class connection and create a new instance of it called conn
            connection conn = new connection();
            // create a new MySqlConnection called con and set it to the connect method from the conn instance
            MySqlConnection con = conn.connect();
            // open the connection
            con.Open();

            // connect the data grid view to the database but do not include the column names and skip the first row of the table
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM borrowers", con);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // find the borrower by the text in the text box
            connection conn = new connection();
            MySqlConnection con = conn.connect();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM borrowers WHERE Name LIKE '%" + txtBox.Text + "%'", con);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // remove the text from the textboxes
            txtName.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtStatus.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // create a new instance of the connection class called conn
            connection conn = new connection();
            // create a new MySqlConnection called con and set it to the connect method from the conn instance
            MySqlConnection con = conn.connect();
            // open the connection
            con.Open();

            // if the button is clicked, get the data from the textboxes and update the row with the same ID as the one in the textbox
            MySqlCommand cmd = new MySqlCommand("UPDATE borrowers SET Name = @Name, Address = @Address, Email = @Email, Status = @Status WHERE ID = @ID", con);
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@Status", txtStatus.Text);
            cmd.Parameters.AddWithValue("@ID", txtID.Text);
            MySqlDataReader reader = cmd.ExecuteReader();
            MessageBox.Show("Updated Successfully");

            reader.Close();
            // connect the data grid view to the database but do not include the column names and skip the first row of the table
            MySqlCommand cmd2 = new MySqlCommand("SELECT * FROM borrowers", con);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd2);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;

            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // removes the text in txtBox
            txtBox.Text = "";

            // create a new instance of the connection class called conn
            connection conn = new connection();
            // create a new MySqlConnection called con and set it to the connect method from the conn instance
            MySqlConnection con = conn.connect();
            // open the connection
            con.Open();
            // connect the data grid view to the database but do not include the column names and skip the first row of the table
            MySqlCommand cmd2 = new MySqlCommand("SELECT * FROM borrowers", con);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd2);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //open register form
            Register register = new Register();
            register.Show();

        }
    }
}
