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
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using Microsoft.VisualBasic;

namespace project1
{
    public partial class carmgt : Form
    {
        int n;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\source\repos\project1\project1\car.mdf;Integrated Security=True");
        SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\source\repos\project1\project1\rentcustomer.mdf;Integrated Security=True");



        public carmgt()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void carmgt_Load(object sender, EventArgs e)
        {

        }
    

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            
            cmd.CommandText="Insert into cars values(" + cid.Text + ",'" + cnm.Text + "','" + ccat.Text + "','" + ccol.Text + "','" + cdp.Text + "','" + cmil.Text + "','" + cno.Text + "','" + chp.Text + "','" + cbn.Text + "','" + this.cmdd.Text + "','" + cino.Text + "','" + cr.Text + "')";
           

            int n = cmd.ExecuteNonQuery();
            con.Close();
            if (n > 0)
            {
                MessageBox.Show("record inserted");
                
            }
            else
                MessageBox.Show("insertion failed");
        }

        private void cino_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            

        }

      

        private void genid_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select count(*) from cars";
            string str = Convert.ToString(cmd.ExecuteScalar());
            n = Convert.ToInt32(str);
            n = n +1000;
            cid.Text = Convert.ToString(n);
            con.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
            user us = new user();
            us.Show();      
        }

        private void button4_Click(object sender, EventArgs e)
        {
           

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            dispcartable k = new dispcartable();
            this.Close();
            k.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Delete from cars WHERE ID='" + cid.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("record deleted");
            con1.Open();
            SqlCommand cmdd = con1.CreateCommand();
            cmdd.CommandType = CommandType.Text;
            cmdd.CommandText = "delete from rentcust where chosen_car_id='" + cid.Text + "'";
            cmdd.ExecuteNonQuery();
            con1.Close();

            button4_Click_1(sender, e);
        }

   

        private void button2_Click(object sender, EventArgs e)
        {
            cid.Text = "";
            cnm.Text = "";
            ccat.Text = "";
            ccol.Text = "";
            cdp.Text = "";
            cmil.Text = "";
            cno.Text = "";
            chp.Text = "";
            cbn.Text = "";
            this.cmdd.Text = "";
            cino.Text = "";
            cr.Text = ""; 
        }

        private void button6_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE cars SET rented ='no' WHERE ID='" + cid.Text + "'"; 
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Updated");
        }
    }
}
