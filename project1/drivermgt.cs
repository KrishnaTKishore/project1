using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace project1
{
    public partial class drivermgt : Form
    {
        int n;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\source\repos\project1\project1\Driverdata.mdf;Integrated Security=True");

        public drivermgt()
        {
            InitializeComponent();
        }

        private void save_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Insert into drivers values(" + ID.Text + ",'" + name.Text + "','" + mob.Text + "','" + salary.Text + "','" + email.Text + "','" + doj.Text + "','" + city.Text + "','" + country.Text + "','" + homaddr.Text + "','" + hommob.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("saved");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void salary_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void update_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE drivers SET salary='" + salary.Text + "' WHERE ID='" + ID.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Updated");
        }

        private void delete_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Delete from drivers WHERE ID='" + ID.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            display_Click(sender, e);
        }

        private void display_Click(object sender, EventArgs e)
        {
            
            string cmd = "Select * from drivers";
            SqlDataAdapter dp = new SqlDataAdapter(cmd, con);
            
            DataTable dt = new DataTable();
            dp.Fill(dt);
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;

            dataGridView2.DataSource = bs;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
            user u = new user();
            u.Show();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select count(*) from drivers";
            string str = Convert.ToString(cmd.ExecuteScalar());
            n = Convert.ToInt32(str);
            n = n + 200;
            ID.Text = Convert.ToString(n);
            con.Close();
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            ID.Text = "";
            name.Text = "";
            mob.Text = "";
            salary.Text = "";
            email.Text = "";
            doj.Text = "";
            city.Text = "";
            country.Text = "";
            homaddr.Text = "";
            hommob.Text = "";

        }
    }
}
