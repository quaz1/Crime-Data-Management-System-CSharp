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
    public partial class Criminal_Registration : Form
    {
        DDBDataContext DB = new DDBDataContext();
        public Criminal_Registration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Criminal obp = new Criminal();
            obp.DOB = textboxDOB.Text;
            obp.date = textboxregDate.Text;
            obp.regno = textboxregno.Text;           
            obp.NID = textBoxNID.Text;
            obp.name = textBoxName.Text;
            obp.gender = textBoxGender.Text;
            obp.age = textBoxAge.Text;
            obp.phone = textBoxPhone.Text;
            obp.address = textBoxAddress.Text;
            obp.Crime = textboxCrime.Text;
            obp.bloodgroup = textBoxBlood.Text;

            DB.Criminals.InsertOnSubmit(obp);

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

        private void Criminal_Registration_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string nid = textboxsearchNID.Text;

            Criminal obp = DB.Criminals.SingleOrDefault(x => x.NID == nid);

            //Criminal obp = DB.Criminals.SingleOrDefault(st => st.NID == textboxsearchNID);
        
            if (obp != null)
            {
                textboxregno.Text = obp.regno;
                textBoxNID.Text = obp.NID;
                textboxregDate.Text = obp.date;
                textboxDOB.Text = obp.DOB;
                textBoxName.Text = obp.name;
                textBoxGender.Text = obp.gender; 
                textBoxAge.Text = obp.age;
                textBoxPhone.Text = obp.phone;
                textBoxAddress.Text = obp.address;
                textboxCrime.Text = obp.Crime;
                textBoxBlood.Text = obp.bloodgroup;
         
            }
            else
            {
                MessageBox.Show("Invalid Search");
            } 
        }

        private void textboxsearchNID_TextChanged(object sender, EventArgs e)
        {

        }

        private void Update_Click(object sender, EventArgs e)
        {
            string nid = textboxsearchNID.Text;

            Criminal obp = DB.Criminals.SingleOrDefault(x => x.NID == nid);
      // Criminal obp = DB.Criminals.SingleOrDefault(st => st.NID == textboxsearchNID);
            if (obp != null)
            {
                obp.DOB = textboxDOB.Text;
                obp.date = textboxregDate.Text;
                obp.regno = textboxregno.Text;
                obp.NID = textBoxNID.Text;
                obp.name = textBoxName.Text;
                obp.gender = textBoxGender.Text;
                obp.age = textBoxAge.Text;
                obp.phone = textBoxPhone.Text;
                obp.address = textBoxAddress.Text;
                obp.Crime = textboxCrime.Text;
                obp.bloodgroup = textBoxBlood.Text;
                DB.SubmitChanges();
                MessageBox.Show("Criminal Updated");
            }
            else
            {
                MessageBox.Show("Error");
            } 
        }

        private void button5_Click(object sender, EventArgs e)
        {
         string nid = textboxsearchNID.Text;

            Criminal ob = DB.Criminals.SingleOrDefault(x => x.NID == nid);   
       //    Criminal ob = DB.Criminals.SingleOrDefault(st => st.NID ==textboxsearchNID);
            if (ob != null)
            {
                DB.Criminals.DeleteOnSubmit(ob);
                DB.SubmitChanges();
                MessageBox.Show("Criminal Deleted");
            }
            else
            {
                MessageBox.Show("Error");
            } 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            (new LoginOption()).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new MenuAd()).Show();
        } 
    }
}
