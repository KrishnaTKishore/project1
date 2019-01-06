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

            Byte[] Imagebytes = File.ReadAllBytes(openFileDialog1.FileName);
            cmd.CommandText="Insert into car values(" + cid.Text + ",'" + cnm.Text + "','" + ccat.Text + "','" + ccol.Text + "','" + cdp.Text + "','" + cmil.Text + "','" + cno.Text + "','" + chp.Text + "','" + cbn.Text + "','" + this.cmdd.Text + "','" + cino.Text + "','" + cr.Text + "',@iloc)";
            SqlParameter prm = new SqlParameter("@iloc", SqlDbType.VarBinary, Imagebytes.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, Imagebytes);
            cmd.Parameters.Add(prm);

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
            

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                iloc.Text = openFileDialog1.FileName;
           // pictureBox1.ImageLocation = iloc.Text;
/*PictureBox pictureBox1 = new PictureBox();
            pictureBox1.ImageLocation = iloc.Text;
            pictureBox1.Image = Image.FromFile("@iloc.text");*/
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void genid_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select count(*) from car";
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
            cmd.CommandText = "Delete from car WHERE ID='" + cid.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("record deleted");
            button4_Click_1(sender, e);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from car where Id=" + cid.Text, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            byte[] mydata = new byte[0];
            mydata = (byte[])dt.Rows[0][12];
            MemoryStream ms = new MemoryStream(mydata);
            pictureBox1.Image = Image.FromStream(ms);
            con.Close();
            
            /* string str = "SELECT model FROM car  WHERE Id='" + cid.Text + "'";
            SqlDataAdapter sd = new SqlDataAdapter(str, con);
            DataSet ds = new DataSet();
            sd.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
               MemoryStream ms=new MemoryStream(mydata);
                pictureBox1.Image = Image.FromStream(ms);

            }

        
            else
            {
                MessageBox.Show("ID not found");
            }

    con.Close();*/


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
    }
}
