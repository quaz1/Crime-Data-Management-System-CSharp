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
    public partial class Criminal_Information : Form
    {
        DDBDataContext DB = new DDBDataContext();
        public Criminal_Information()
        {
            InitializeComponent();
            dataGridView1.DataSource = DB.Criminals;
    
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

        private void Criminal_Information_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.DataSource = DB.Criminals;
   
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DDBDataContext DB = new DDBDataContext();
            string nid = textboxsearchNID.Text;

            var sres =  from x in DB.Criminals 
                                            where x.NID == nid 
                                            select x ;

            dataGridView1.DataSource = sres;

            
        }

        private void textboxsearchNID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
