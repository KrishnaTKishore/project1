using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project1
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lognm.Text == "user" && logid.Text == "123")
            {
                this.Hide();
                user u = new user();
                u.Show();
            }
            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            book r = new book();
            r.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Confirm if you want to exit", "car sales", MessageBoxButtons.YesNo);
            if (iExit == DialogResult.Yes)
            {
                Application.Exit();                    
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            rent rt = new rent();
            rt.Show();

        }
    }
}

