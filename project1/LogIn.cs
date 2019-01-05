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
                this.Hide();
            user u = new user();
            u.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Rent r = new Rent();
            r.Show();
        }
    }
}

