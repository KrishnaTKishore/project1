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

namespace project1
{
    public partial class rent : Form
    {
        int n;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\source\repos\project1\project1\car.mdf;Integrated Security=True");
        SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\source\repos\project1\project1\rentcustomer.mdf;Integrated Security=True");

        public rent()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            LogIn r = new LogIn();
            r.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText("***************************************************\n");
            richTextBox1.AppendText("***********Butter General Transport***********\n");
            richTextBox1.AppendText("***************************************************\n");
            richTextBox1.AppendText("Name: \t\t\t" + tbname.Text + "\n");
            richTextBox1.AppendText("Email: \t\t" + tbadd.Text + "\n");
            richTextBox1.AppendText("Mobile: \t\t\t" + tbmob.Text + "\n\n");
            richTextBox1.AppendText("***************************************************\n");
            richTextBox1.AppendText("***************************************************\n\n\n");
          
           
            richTextBox1.AppendText("Total: \t\t\t" + tot.Text + "\n");

        }

        private void button7_Click(object sender, EventArgs e)
        {
            con1.Open();
            SqlCommand cmd = con1.CreateCommand();
            cmd.CommandText = "select count(*) from rentcust";
            string str = Convert.ToString(cmd.ExecuteScalar());
            n = Convert.ToInt32(str);
            n = n + 100;
            tbcid.Text = Convert.ToString(n);
            con1.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void rent_Load(object sender, EventArgs e)
        {
            try
            {
                string qry = "select id,car_name,car_category,colour,daily_price,mileage,car_no,horse_power,brand_name,mfd_date,insurance_no,rented from cars where rented = 'no'";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            double[] carcost = new double[5];

            carcost[0] = Convert.ToDouble(tbcost.Text);
            carcost[1] = Convert.ToDouble(tbnod.Text);
           
           
            carcost[2] = carcost[0] * carcost[1] ;
            
            tot.Text = String.Format("{0:C2}", carcost[2]);
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con1.Open();
            SqlCommand cmd = con1.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into rentcust values(" + tbcid.Text + ",'" + tbname.Text + "','" + tbadd.Text + "','" + tbmob.Text + "','" + tbcarchosen.Text + "','" + from.Text + "','" + tbnod.Text + "','" + tbcost.Text + "','" + tot.Text + "')";
            cmd.ExecuteNonQuery();
            con1.Close();
            
            con.Open();
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "UPDATE cars SET rented ='yes' WHERE ID='" + tbcarchosen.Text + "'";
            cmd1.ExecuteNonQuery();
            
            con.Close(); 

            MessageBox.Show("Booking Successful!!");
            try
            {
                string qry = "select id,car_name,car_category,colour,daily_price,mileage,car_no,horse_power,brand_name,mfd_date,insurance_no,rented from cars where rented = 'no'";
                SqlCommand cmd11 = new SqlCommand(qry, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd11);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tbcid.Text = "";
            tbname.Text = "";
            tbadd.Text = "";
            tbmob.Text = "";
            tbcarchosen.Text = "";
            from.Text = "";
            tbnod.Text = "";
            tbcost.Text = "";
            tot.Text= "";
            richTextBox1.Text = "";
        }

        private void tbcarchosen_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            string cmd = "Select daily_price from cars where Id='"+tbcarchosen.Text+ "'";
            try
            {
                SqlCommand se = new SqlCommand(cmd, con);
                SqlDataReader rd = se.ExecuteReader();
                while (rd.Read())
                    tbcost.Text = rd.GetValue(0).ToString();
                se.Dispose();
            }
            
           
            catch(Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            con.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
