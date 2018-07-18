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
    public partial class SC : Form
    {
        connection conn = new connection();
        public SC()
        {
            InitializeComponent();
        }

        private void SC_Load(object sender, EventArgs e)
        {
            comboBox2.Visible = false;
            label2.Visible = false;
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select deptname from Dept", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                this.comboBox1.Items.Add(dr["deptname"]).ToString();
            }
            conn.oleDbConnection1.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Visible = true;
            label2.Visible = true;
            //comboBox1.Items.Clear();
            //comboBox2.Items.Clear();
            this.comboBox1.Show();
            this.dataGridView1.Show();


           

            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select * from Customer where CGroup='" + this.comboBox1.Text + "'", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                this.comboBox2.Items.Add(dr["CName"]).ToString();
            }
            conn.oleDbConnection1.Close();
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbDataAdapter da = new OleDbDataAdapter("Select  *from Customer where CGroup='" + this.comboBox1.Text + "'", conn.oleDbConnection1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }
    }
}
