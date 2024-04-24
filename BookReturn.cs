using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LibraryIS
{
    public partial class BookReturn : Form
    {
        public BookReturn()
        {
            InitializeComponent();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // if a row is clicked, get the data from the row and put it in the textboxes
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView3.Rows[e.RowIndex];
                txtDue.Text = row.Cells["Due Date"].Value.ToString();
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtTrans.Text = row.Cells["Transaction ID"].Value.ToString();

            }
        }

        private void BookReturn_Load(object sender, EventArgs e)
        {

            // call public class connection and create a new instance of it called conn
            connection conn = new connection();
            // create a new MySqlConnection called con and set it to the connect method from the conn instance
            MySqlConnection con = conn.connect();
            // open the connection
            con.Open();

            // connect the data grid view to the database but do not include the column names and skip the first row of the table
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM pending_transactions;", con);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView3.DataSource = table;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            txtDue.Text = "";
            txtName.Text = "";
            txtReturn.Text = "";
            txtTrans.Text = "";


            // call public class connection and create a new instance of it called conn
            connection conn = new connection();
            // create a new MySqlConnection called con and set it to the connect method from the conn instance
            MySqlConnection con = conn.connect();
            // open the connection
            con.Open();

            // connect the data grid view to the database but do not include the column names and skip the first row of the table
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM pending_transactions;", con);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView3.DataSource = table;
            dataGridView3.DataSource = table;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtDue.Text = "";
            txtName.Text = "";
            txtReturn.Text = "";
            txtTrans.Text = "";
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
            MySqlCommand cmd = new MySqlCommand("UPDATE transactions SET return_date = @ReturnDate WHERE transaction_id = @TransID", con);
            cmd.Parameters.AddWithValue("@ReturnDate", txtReturn.Text);
            cmd.Parameters.AddWithValue("@TransID", txtTrans.Text);
            MySqlDataReader reader = cmd.ExecuteReader();
            MessageBox.Show("Updated Successfully");

            reader.Close();
        }
    }
}
