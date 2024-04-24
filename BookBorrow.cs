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
    public partial class BookBorrow : Form
    {
        public BookBorrow()
        {
            InitializeComponent();
        }

        private void BookBorrow_Load(object sender, EventArgs e)
        {
            // call public class connection and create a new instance of it called conn
            connection conn = new connection();
            // create a new MySqlConnection called con and set it to the connect method from the conn instance
            MySqlConnection con = conn.connect();
            // open the connection
            con.Open();

            // connect the data grid view to the database but do not include the column names and skip the first row of the table
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM active_borrowers", con);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView2.DataSource = table;

            MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM available_books", con);
            MySqlDataAdapter adapter1 = new MySqlDataAdapter(cmd1);
            DataTable table1 = new DataTable();
            adapter1.Fill(table1);
            dataGridView1.DataSource = table1;

            MySqlCommand cmd2 = new MySqlCommand("SELECT * FROM transactions_list;", con);
            MySqlDataAdapter adapter2 = new MySqlDataAdapter(cmd2);
            DataTable table2 = new DataTable();
            adapter2.Fill(table2);
            dataGridView3.DataSource = table2;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // removes the text in txtBox
            txtBorrow.Text = "";
            txtBook.Text = "";

            // create a new instance of the connection class called conn
            connection conn = new connection();
            // create a new MySqlConnection called con and set it to the connect method from the conn instance
            MySqlConnection con = conn.connect();
            // open the connection
            con.Open();
            // connect the data grid view to the database but do not include the column names and skip the first row of the table
            MySqlCommand cmd2 = new MySqlCommand("SELECT * FROM transactions_list;", con);
            MySqlDataAdapter adapter2 = new MySqlDataAdapter(cmd2);
            DataTable table2 = new DataTable();
            adapter2.Fill(table2);
            dataGridView3.DataSource = table2;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtBorrow.Text = "";
            txtBook.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // create a new instance of the connection class called conn
            connection conn = new connection();
            // create a new MySqlConnection called con and set it to the connect method from the conn instance
            MySqlConnection con = conn.connect();
            // open the connection
            con.Open();

            MySqlCommand cmd = new MySqlCommand("INSERT INTO transactions (book_id, borrower_id) VALUES (@BookID, @BorrowerID)", con);
            cmd.Parameters.AddWithValue("@BorrowerID", txtBorrow.Text);
            cmd.Parameters.AddWithValue("@BookID", txtBook.Text);

            if (txtBook.Text == "" || txtBorrow.Text == "")
            {
                MessageBox.Show("Please fill in all the fields");
            }
            else
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                MessageBox.Show("Transaction Added Successfully");

                this.Hide();
            }


            con.Close();
        }
    }
}
