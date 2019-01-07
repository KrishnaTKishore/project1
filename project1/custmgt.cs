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
using System.Data;


namespace project1
{
    public partial class custmgt : Form
    {
       
        SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\source\repos\project1\project1\customerdb.mdf;Integrated Security=True");
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\source\repos\project1\project1\rentcustomer.mdf;Integrated Security=True");

        public custmgt()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cmd = "Select Cust_Id,Cust_name,Cust_email,Cust_mobile,Cust_car,Cust_cost from customer  ";
            SqlDataAdapter dp = new SqlDataAdapter(cmd, con1);
            
            DataTable dt = new DataTable();
            dp.Fill(dt);
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            dataGridView1.DataSource = bs;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            user f3 = new user();
            f3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string cmd = "Select * from rentcust  ";
            SqlDataAdapter dp = new SqlDataAdapter(cmd, con);

            DataTable dt = new DataTable();
            dp.Fill(dt);
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            dataGridView1.DataSource = bs;
        }
    }
}
