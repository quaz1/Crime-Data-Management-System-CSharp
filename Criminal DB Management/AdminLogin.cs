using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Criminal_DB_Management
{
    public partial class AdminLogin : Form
    {
        DDBDataContext DB = new DDBDataContext();
        public AdminLogin()
        {
            InitializeComponent();
            textboxPassword.UseSystemPasswordChar = true; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textboxUsername.Text;
            string password = textboxPassword.Text;
            var login = DB.Logins.FirstOrDefault(std => std.Username == username && std.Password == password);
            if (login != null)
            {
                this.Hide();
                new MenuAd().Visible = true;

            }
            else
            {
                MessageBox.Show("Username or password is incorrect!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            (new LoginOption()).Show();
        }
    }
}
