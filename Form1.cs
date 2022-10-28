using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace lab6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }



        public static ListView list_view = new ListView();



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string gender = " ";

            if (radioButton1.Checked == true)
            {
                gender = "Male";
            }
            else
            {

                gender = "Female";
            }
            ListViewItem list = new ListViewItem(firstname.Text + " " + lastname.Text);
            list.SubItems.Add(gender);

            list.SubItems.Add(contact.Text);
            list.SubItems.Add(address.Text);
            list.SubItems.Add(warehouseno.Text);
            list.SubItems.Add(warehousename.Text);

            list_view.Items.Add(list);

            firstname.Text = "";
            lastname.Text = "";
            contact.Text = "";
            address.Text = "";
            warehouseno.Text = "";
            warehousename.Text = "";

            MessageBox.Show("Record saved");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Madina Laptop\Desktop\VP Asi 1\lab6\lab6\Database1.mdf"";Integrated Security=True";

            SqlConnection con = new SqlConnection(Connection);
            con.Open();

            string fname = firstname.Text;
            string lname = lastname.Text;
            string cont = contact.Text;
            string addr = address.Text;
            string wareno = warehouseno.Text;
            string warename = warehousename.Text;

            string query = "INSERT INTO DataBaseapp(fullname,gender,contactno,address,warehouseno,warehousename)VALUES( '" + fname + "','" + lname + "','" + cont + "','" + addr + "' , '" + wareno + "','" + warename + "')";

            SqlCommand cmd = new SqlCommand(query, con);

            int i = cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Record is Saved");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem itm in list_view.Items)
            {
                string warehouse_no = itm.SubItems[4].Text.ToString();
                if (warehouseno.Text == warehouse_no)
                {
                    itm.SubItems[0].Text = firstname.Text;
                    itm.SubItems[1].Text = lastname.Text;
                    itm.SubItems[2].Text = contact.Text;
                    itm.SubItems[3].Text = address.Text;
                    itm.SubItems[4].Text = warehouseno.Text;
                    itm.SubItems[5].Text = warehousename.Text;
                    firstname.Text = "";
                    lastname.Text = "";
                    address.Text = "";
                    contact.Text = "";
                    warehouseno.Text = "";
                    warehousename.Text = "";

                    MessageBox.Show("Updated Successfully");

                }

            }
        }
    }
}
