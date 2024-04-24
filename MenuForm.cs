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
    public partial class MenuForm : Form
    {
        public static MenuForm instance;
        public Label lab1;
        public MenuForm()
        {
            InitializeComponent();
            instance = this;
            lab1 = txtUsername;
        }

        private void loadform(object Form)
        {
            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadform(new DashboardForm());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadform (new Accounts());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadform (new Reports());
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Close the current form and open login form
            this.Close();
            Login login = new Login();
            login.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            loadform(new DashboardForm());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            loadform(new Transactions());
        }
    }
}
