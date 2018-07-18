using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace assignment
{
    public partial class customer : Form
    {
        public customer()
        {
            InitializeComponent();
        }

        private void customer_Load(object sender, EventArgs e)
        {

            button6.Text = "Add Customer";
            button7.Text = "Search Customer";
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            addcustomer aa = new addcustomer();
            aa.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SC ss = new SC();
            ss.Show();
            this.Hide();
        }
    }
}
