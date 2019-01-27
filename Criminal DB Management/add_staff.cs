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
    public partial class add_staff : Form
    {
        public add_staff()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DDBDataContext DB = new DDBDataContext();
            LoginSt obp = new LoginSt();

            obp.username = textBoxusername.Text;
            obp.password = textBoxpassword.Text;
            obp.NID = textboxNID.Text;
         

            DB.LoginSts.InsertOnSubmit(obp);

            try
            {
                DB.SubmitChanges();
                MessageBox.Show("Inserted.");
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }
    }
}
