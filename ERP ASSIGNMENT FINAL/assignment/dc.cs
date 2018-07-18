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
    public partial class dc : Form
    {
        connection x = new connection();
        public dc()
        {
            InitializeComponent();
        }

        private void dc_Load(object sender, EventArgs e)
        {
            {
                x.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("select soid from so", x.oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["soid"].ToString());
                }
                x.oleDbConnection1.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            x.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select cid,cname,cadd,city,cp from so where soid='" + comboBox1.Text + "'", x.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                textBox1.Text = dr["cid"].ToString();
                textBox2.Text = dr["cname"].ToString();
                textBox3.Text = dr["cadd"].ToString();
                textBox6.Text = dr["city"].ToString();
                textBox4.Text = dr["cp"].ToString();



            }


            x.oleDbConnection1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                x.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("insert into dc (soid,cid,cname,cadd,city,cp,dcdate) values(@soid,@cid,@cname,@cadd,@city,@cp,@dcdate)", x.oleDbConnection1);
                cmd.Parameters.AddWithValue("@soid", comboBox1.Text);
                cmd.Parameters.AddWithValue("@cid", textBox1.Text);
                cmd.Parameters.AddWithValue("@cname", textBox2.Text);
                cmd.Parameters.AddWithValue("@cadd", textBox3.Text);
                cmd.Parameters.AddWithValue("@city", textBox6.Text);
                cmd.Parameters.AddWithValue("@cp", textBox4.Text);
                cmd.Parameters.AddWithValue("@dcdate", dateTimePicker1.Text);



                cmd.ExecuteNonQuery();
                MessageBox.Show("Delievery Chalan Successfully Created");
                textBox7.Text += "SO-ID: " + comboBox1.Text + Environment.NewLine + "C-Id: " + textBox1.Text + Environment.NewLine + "C-Name: " + textBox2.Text + Environment.NewLine + "C-Address: " + textBox3.Text + Environment.NewLine + "City: " + textBox6.Text + Environment.NewLine + "CP: " + textBox4.Text + Environment.NewLine + "Delievery Chalan Date: " + dateTimePicker1.Text;
            }
            catch (Exception ee)
            {
                MessageBox.Show("Cannot Created" + ee);
                
                x.oleDbConnection1.Close();
            
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
    }
}
