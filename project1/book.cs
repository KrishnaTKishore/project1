using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace project1
{
    public partial class book : Form
    {
        int n;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\source\repos\project1\project1\customerdb.mdf;Integrated Security=True");
        public book()
        {
            InitializeComponent();
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbcar.Text == "Maruti Vitara Brezza")
                tbcost.Text = "758000";
            if (cbcar.Text == "Hyundai Creta")
                tbcost.Text = "950000";
            if (cbcar.Text == "Mahindra Scorpio")
                tbcost.Text = "1000000";
            if (cbcar.Text == "Toyota Fortuner")
                tbcost.Text = "2727000";
            if (cbcar.Text == "Tata Nexon")
                tbcost.Text = "623000";
            if (cbcar.Text == "Mahindra XUV500")
                tbcost.Text = "1257000";
            if (cbcar.Text == "Ford EcoSport")
                tbcost.Text = "782000";
            if (cbcar.Text == "Toyota Innova Crysta")
                tbcost.Text = "1465000";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Confirm if you want to exit", "car sales", MessageBoxButtons.YesNo);
            if (iExit == DialogResult.Yes)
            {
                this.Close();
                LogIn l = new LogIn();
                l.Show();



            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            tbname.Text = "";
            tbmob.Text = "";
            tbadd.Text = "";
            tot.Text = "";
            tax.Text = "";
            subtot.Text = "";
            richTextBox1.Text = "";
            tbcost.Text = "";
            cbcar.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "0";




        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText("***************************************************\n");
            richTextBox1.AppendText("***********Butter General Transport***********\n");
            richTextBox1.AppendText("***************************************************\n");
            richTextBox1.AppendText("Name: \t\t\t" + tbname.Text+"\n");
            richTextBox1.AppendText("Email: \t\t" + tbadd.Text + "\n");
            richTextBox1.AppendText("Mobile: \t\t\t" + tbmob.Text + "\n\n");
            richTextBox1.AppendText("***************************************************\n");
            richTextBox1.AppendText("***************************************************\n\n\n");
            richTextBox1.AppendText("Tax: \t\t\t" + tax.Text + "\n");
            richTextBox1.AppendText("Sub Total: \t\t" + subtot.Text + "\n");
            richTextBox1.AppendText("Total: \t\t\t" + tot.Text + "\n");

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox1.Text = "8000";
                textBox1.Enabled = true;
            }
            else if (checkBox1.Checked == false)
            {
                textBox1.Text ="0";
                textBox1.Enabled = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            { 
                textBox2.Text = "4000";
                textBox2.Enabled = true;
            }
            else if (checkBox2.Checked == false)
            {
                textBox2.Text = "0";
                textBox2.Enabled = false;
            }

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            { 
                textBox3.Text = "10000";
                textBox3.Enabled = true;
            }
            else if (checkBox3.Checked == false)
            {
                textBox3.Text = "0";
                textBox3.Enabled = false;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            { 
                textBox4.Text = "7000";
                textBox4.Enabled = true;
            }
            else if (checkBox4.Checked == false)
            {
                textBox4.Text = "0";
                textBox4.Enabled = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            { 
                textBox5.Text = "9000";
                textBox5.Enabled = true;
            }
            else if (checkBox5.Checked == false)
            {
                textBox5.Text = "0";
                textBox5.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double[] carcost = new double[12];
            
            carcost[0] = Convert.ToDouble(textBox1.Text);
            carcost[1] = Convert.ToDouble(textBox2.Text);
            carcost[2] = Convert.ToDouble(textBox3.Text);
            carcost[3] = Convert.ToDouble(textBox4.Text);
            carcost[4] = Convert.ToDouble(textBox5.Text);
            carcost[5] = Convert.ToDouble(tbcost.Text);
            carcost[6] = carcost[0] + carcost[1] + carcost[2] + carcost[3] + carcost[4] + carcost[5];
            carcost[7] = (carcost[6] * 0.45) / 100;
            tax.Text = String.Format("{0:C2}", carcost[7]);
            subtot.Text=String.Format("{0:C2}", carcost[6]);
            tot.Text= String.Format("{0:C2}", (carcost[7]+carcost[6]));


        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into customer values(" + tbcid.Text + ",'" + tbname.Text + "','" + tbadd.Text + "','" + tbmob.Text + "','" + cbcar.Text + "','" + tot.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            
            MessageBox.Show("Booking Successful!!");
        }

        private void button6_Click(object sender, EventArgs e)
        { 
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select count(*) from customer";
            string str = Convert.ToString(cmd.ExecuteScalar());
            n = Convert.ToInt32(str);
            n = n + 100;
            tbcid.Text = Convert.ToString(n);
            con.Close();


        }
    }
}
