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
    public partial class BookAdd : Form
    {
        public BookAdd()
        {
            InitializeComponent();
        }

        private void BookAdd_Load(object sender, EventArgs e)
        {
            // call public class connection and create a new instance of it called conn
            connection conn = new connection();
            // create a new MySqlConnection called con and set it to the connect method from the conn instance
            MySqlConnection con = conn.connect();
            // open the connection
            con.Open();

            // connect the data grid view to the database but do not include the column names and skip the first row of the table
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM authors", con);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;

            MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM genres", con);
            MySqlDataAdapter adapter1 = new MySqlDataAdapter(cmd1);
            DataTable table1 = new DataTable();
            adapter1.Fill(table1);
            dataGridView2.DataSource = table1;

            MySqlCommand cmd2 = new MySqlCommand("SELECT * FROM book_inventory;", con);
            MySqlDataAdapter adapter2 = new MySqlDataAdapter(cmd2);
            DataTable table2 = new DataTable();
            adapter2.Fill(table2);
            dataGridView3.DataSource = table2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // removes the text in txtBox
            txtAuthor.Text = "";
            txtAvail.Text = "";
            txtGenre.Text = "";
            txtISBN.Text = "";
            txtTitle.Text = "";
            txtYear.Text = "";


            // create a new instance of the connection class called conn
            connection conn = new connection();
            // create a new MySqlConnection called con and set it to the connect method from the conn instance
            MySqlConnection con = conn.connect();
            // open the connection
            con.Open();
            // connect the data grid view to the database but do not include the column names and skip the first row of the table
            MySqlCommand cmd2 = new MySqlCommand("SELECT * FROM book_inventory;", con);
            MySqlDataAdapter adapter2 = new MySqlDataAdapter(cmd2);
            DataTable table2 = new DataTable();
            adapter2.Fill(table2);
            dataGridView3.DataSource = table2;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // removes the text in txtBox
            txtAuthor.Text = "";
            txtAvail.Text = "";
            txtGenre.Text = "";
            txtISBN.Text = "";
            txtTitle.Text = "";
            txtYear.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // create a new instance of the connection class called conn
            connection conn = new connection();
            // create a new MySqlConnection called con and set it to the connect method from the conn instance
            MySqlConnection con = conn.connect();
            // open the connection
            con.Open();

            MySqlCommand cmd = new MySqlCommand("INSERT INTO books (title, author_id, genre_id, publication_year, ISBN, availability) VALUES (@Title, @AuthorID, @GenreID, @Year, @ISBN, @Availability)", con);
            cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
            cmd.Parameters.AddWithValue("@AuthorID", txtAuthor.Text);
            cmd.Parameters.AddWithValue("@GenreID", txtGenre.Text);
            cmd.Parameters.AddWithValue("@Year", txtYear.Text);
            cmd.Parameters.AddWithValue("@ISBN", txtISBN.Text);
            cmd.Parameters.AddWithValue("@Availability", txtAvail.Text);


            if (txtTitle.Text == "" || txtAuthor.Text == "" || txtGenre.Text == "" || txtYear.Text == "" || txtISBN.Text == "" || txtAvail.Text == "")
            {
                MessageBox.Show("Please fill in all the fields");
            }
            else
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                MessageBox.Show("Book Added Successfully");

                this.Hide();
            }


            con.Close();
        }
    }
}
