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
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Set the current date
            DateTime dateTime = DateTime.Now;
            this.dateLabel.Text = dateTime.ToLongDateString();

            // set the current time
            this.timeLabel.Text = dateTime.ToLongTimeString();

            this.timer1.Enabled = true;


            // call public class connection and create a new instance of it called conn
            connection conn = new connection();
            // create a new MySqlConnection called con and set it to the connect method from the conn instance
            MySqlConnection con = conn.connect();
            // open the connection
            con.Open();

            // connect the data grid view to the database but do not include the column names and skip the first row of the table
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM pending_transactions", con);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;



            // count the number of rows in the books table
            MySqlCommand cmd2 = new MySqlCommand("SELECT COUNT(*) FROM books", con);
            int count = Convert.ToInt32(cmd2.ExecuteScalar());
            label8.Text = count.ToString();

            //count the number of active status in the borrowers table
            MySqlCommand cmd3 = new MySqlCommand("SELECT COUNT(*) FROM borrowers WHERE Status = 'Active'", con);
            int count2 = Convert.ToInt32(cmd3.ExecuteScalar());
            label9.Text = count2.ToString();


            //count the number of borrowed books by counting the number of rows that has a return date that is null
            MySqlCommand cmd4 = new MySqlCommand("SELECT COUNT(*) FROM transactions WHERE return_date IS NULL", con);
            int count3 = Convert.ToInt32(cmd4.ExecuteScalar());
            label10.Text = count3.ToString();
            label13.Text = count3.ToString();


            //count the number of returned books by counting the number of rows that has a return date that is not null
            MySqlCommand cmd5 = new MySqlCommand("SELECT COUNT(*) FROM transactions WHERE return_date IS NOT NULL", con);
            int count4 = Convert.ToInt32(cmd5.ExecuteScalar());
            label11.Text = count4.ToString();
            label14.Text = count4.ToString();

            con.Close();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void label8_Click(object sender, EventArgs e)
        {
        }
    }
}
