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
    public partial class addvendor : Form
    {
        connection conn = new connection();
        public addvendor()
        {
            InitializeComponent();
        }

        private void addvendor_Load(object sender, EventArgs e)
        {
            this.button2.Text = "Back\nTo Main";
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select deptname from Dept", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                this.comboBox1.Items.Add(dr["deptname"]).ToString();
            }
            conn.oleDbConnection1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("insert into Vendor (VID,VName,VCode,PH1,CPName,VGroup,VStatus) values (@VID,@VName,@VCode,@PH1,@CPName,@VGroup,@VStatus)",conn.oleDbConnection1);
            cmd.Parameters.AddWithValue("@VID", textBox1.Text);
            cmd.Parameters.AddWithValue("@VName", textBox2.Text);
            cmd.Parameters.AddWithValue("@VCode", textBox3.Text);
            cmd.Parameters.AddWithValue("@PH1", textBox4.Text);
            cmd.Parameters.AddWithValue("@CPName", textBox5.Text);
            cmd.Parameters.AddWithValue("@VGroup", textBox6.Text);
            cmd.Parameters.AddWithValue("@VStatus",textBox7.Text);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Vendor Successfully Edit");
            }

            catch (Exception ee)
            {
                MessageBox.Show("Vendor Error"+ee);
                
            }

            conn.oleDbConnection1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //conn.oleDbConnection1.Open();
            //OleDbCommand cmd = new OleDbCommand("Select VID,Vname,vcode,ph,cpname,vgroup,vstatus from Vendor where VID='" + comboBox1.Text + "'", conn.oleDbConnection1);
            //OleDbDataReader dr = cmd.ExecuteReader();
            //if (dr.Read())
            //{

            //    textBox1.Text = dr["VID"].ToString();
            //    textBox2.Text = dr["Vname"].ToString();
            //    textBox3.Text = dr["Vcode"].ToString();
            //    textBox4.Text = dr["ph"].ToString();
            //    textBox5.Text = dr["Cpname"].ToString();
            //    textBox6.Text = dr["vgroup"].ToString();
            //    textBox7.Text = dr["vstatus"].ToString();



            //}


            //conn.oleDbConnection1.Close();
        }
    }
}
