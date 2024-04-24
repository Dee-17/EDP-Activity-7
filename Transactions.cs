using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryIS
{
    public partial class Transactions : Form
    {
        public Transactions()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BookBorrow bookBorrow = new BookBorrow();
            bookBorrow.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BookReturn bookReturn = new BookReturn();
            bookReturn.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BookAdd bookAdd = new BookAdd();
            bookAdd.Show();
        }
    }
}
