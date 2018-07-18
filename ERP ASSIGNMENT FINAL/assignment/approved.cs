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
    public partial class approved : Form
    {
        connection c = new connection();
        public approved()
        {
            InitializeComponent();
        }

        private void approved_Load(object sender, EventArgs e)
        {
            button2.Text = "Back To Main";
            this.label1.Text = "Vendor ID ";
            this.label2.Text = "Vendor Name ";
            this.label3.Text = "Vendor Code ";
            this.label4.Text = "Vendor City ";
            this.label5.Text = "Phone #01";
            this.label6.Text = "Phone #02";
            this.label7.Text = "Vendor Address ";
            this.label8.Text = "CP Name ";
            this.label9.Text = "CP PH# ";
            this.label10.Text = "Vendor Email ";
            this.label11.Text = "Vendor Fax";
            this.label12.Text = "Vendor Group";
            this.label13.Text = "Vendor Status";

            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox9.ReadOnly = true;
            textBox10.ReadOnly = true;
            textBox11.ReadOnly = true;
            textBox12.ReadOnly = true;

            {
                c.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("select VID from Vendor", c.oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["VID"].ToString());
                }
                c.oleDbConnection1.Close();
            }









        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                c.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("Select * from Vendor where VID='" + comboBox1.Text + "'", c.oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBox1.Text = dr["VName"].ToString();
                    textBox2.Text = dr["VCode"].ToString();
                    textBox3.Text = dr["VCity"].ToString();
                    textBox4.Text = dr["PH1"].ToString();
                    textBox5.Text = dr["PH2"].ToString();
                    textBox6.Text = dr["VAddress"].ToString();
                    textBox7.Text = dr["CPName"].ToString();
                    textBox8.Text = dr["CPPH"].ToString();
                    textBox9.Text = dr["VEmail"].ToString();
                    textBox10.Text = dr["VFax"].ToString();
                    textBox11.Text = dr["VGroup"].ToString();
                    textBox12.Text = dr["VStatus"].ToString();


                }
            }
            catch(Exception ee)
            {
                MessageBox.Show("Error"+ee);
           
            }
             c.oleDbConnection1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Update Vendor set Vname=@vname,Vcode=@vcode,vcity=@vcity,ph1=@ph1,ph2=@ph2,vaddress=@vaddress,cpname=@cpname,cpph=@cpph,Vemail=@vemail,vfax=@vfax,vgroup=@vgroup,Vstatus=@vstatus where vid=@vid",c.oleDbConnection1);
            cmd.Parameters.AddWithValue("@vid", comboBox1.Text);
            cmd.Parameters.AddWithValue("@vname",textBox1.Text);
            cmd.Parameters.AddWithValue("@vcode", textBox2.Text);
            cmd.Parameters.AddWithValue("@vcity", textBox3.Text);
            cmd.Parameters.AddWithValue("@ph1", textBox4.Text);
            cmd.Parameters.AddWithValue("@ph2", textBox5.Text);
            cmd.Parameters.AddWithValue("@vaddress", textBox6.Text);
            cmd.Parameters.AddWithValue("@cpname", textBox7.Text);
            cmd.Parameters.AddWithValue("@cpph", textBox8.Text);
            cmd.Parameters.AddWithValue("@vemail", textBox9.Text);
            cmd.Parameters.AddWithValue("@vfax", textBox10.Text);
            cmd.Parameters.AddWithValue("@vgroup", textBox11.Text);
            cmd.Parameters.AddWithValue("@vstatus", textBox12.Text);
            cmd.ExecuteNonQuery();

            c.oleDbConnection1.Close();
            MessageBox.Show("Successfully Approved");
            Form1 f = new Form1();
            f.Show();
            this.Hide();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            eidtvendor z = new eidtvendor();
            z.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 ff = new Form1();
            ff.Show();
            this.Hide();
        }
    }
}
