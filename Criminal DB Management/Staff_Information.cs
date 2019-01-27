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
    public partial class Staff_Information : Form
    {
        DDBDataContext DB = new DDBDataContext();
        public Staff_Information()
        {
            InitializeComponent();
            dataGridView1.DataSource = DB.LoginSts ;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            (new MenuAd()).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            (new LoginOption()).Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DDBDataContext DB = new DDBDataContext();
            string nid = textboxsearchNID.Text;

            var sres = from x in DB.LoginSts
                       where x.NID == nid
                       select x;

            dataGridView1.DataSource = sres;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string nid = textboxsearchNID.Text;

            LoginSt ob = DB.LoginSts.SingleOrDefault(x => x.NID == nid);
            //    Criminal ob = DB.Criminals.SingleOrDefault(st => st.NID ==textboxsearchNID);
            if (ob != null)
            {
                DB.LoginSts.DeleteOnSubmit(ob);
                DB.SubmitChanges();
                MessageBox.Show("Staff Deleted");
            }
            else
            {
                MessageBox.Show("Error");
            } 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            (new add_staff()).Show();
          
        }
    }
}
