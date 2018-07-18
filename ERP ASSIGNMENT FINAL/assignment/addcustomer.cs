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
    public partial class addcustomer : Form
    {
        connection conn = new connection();
        public addcustomer()
        {
            InitializeComponent();
        }

        private void addcustomer_Load(object sender, EventArgs e)
        {
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

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            conn.oleDbConnection1.Open();
            
                OleDbCommand cmd = new OleDbCommand("insert into Customer (CID,Cname,CAddress,City,PH1,CEmail,CStatus,CGroup) values (@CID,@Cname,@CAddress,@City,@PH1,@CEmail,@CStatus,@CGroup)", conn.oleDbConnection1);
                cmd.Parameters.AddWithValue("@CID", textBox1.Text);
                cmd.Parameters.AddWithValue("@Cname", textBox2.Text);
                cmd.Parameters.AddWithValue("@CAddress", textBox3.Text);
                cmd.Parameters.AddWithValue("@City", textBox4.Text);
                cmd.Parameters.AddWithValue("@PH", textBox5.Text);
                cmd.Parameters.AddWithValue("@CEmail", textBox6.Text);
                cmd.Parameters.AddWithValue("@CStatus", textBox7.Text);
                cmd.Parameters.AddWithValue("@CGroup", comboBox1.Text);
               try{
                   
                   cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Successfully Edit");
            }
            catch(Exception ee)
            {
           
                MessageBox.Show("Failed"+ee);
            
            }

            conn.oleDbConnection1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
    }
}
