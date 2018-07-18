using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace assignment
{
    public partial class Form1 : Form
    {
        connection c = new connection();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button6.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            po p = new po();
            p.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            grn g = new grn();
            g.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Invoice i = new Invoice();
            i.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            salesorder s = new salesorder();
            s.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            vstart v = new vstart();
            v.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            approved a = new approved();
            a.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            addvendor a = new addvendor();
            a.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            dc dd = new dc();
            dd.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ir i = new ir();
            i.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            customer aa = new customer();
            aa.Show();
            this.Hide();
            //button6.Visible = true;
            //button7.Visible = true;
            //button8.Visible = true;

            //button6.Text = "Add Customer";
            //button7.Text = "Search Customer";
            //button8.Text = "Approve Customer";


        }
    }
}
