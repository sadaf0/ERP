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
    public partial class eidtvendor : Form
    {
        connection c = new connection();

        public eidtvendor()
        {
            InitializeComponent();
        }

        private void eidtvendor_Load(object sender, EventArgs e)
        {
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


            
                c.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("select VID from Vendor", c.oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["VID"].ToString());
                }
                c.oleDbConnection1.Close();
            








        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
          
            c.oleDbConnection1.Close();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                c.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("Update Vendor set VName=@VName,VCode=@VCode,VCity=@VCity,PH1=@PH1,PH2=@PH2,VAddress=@VAddress,CPName=@CPName,CPPH=@CPPH,VEmail=@VEmail,VFax=@VFax,VGroup=@VGroup,VStatus=@VStatus where VID='" + comboBox1.Text + "'", c.oleDbConnection1);
            

                cmd.Parameters.AddWithValue("@VName", textBox1.Text);
                cmd.Parameters.AddWithValue("@VCode", textBox2.Text);
                cmd.Parameters.AddWithValue("@VCity", textBox3.Text);
                cmd.Parameters.AddWithValue("@PH1", textBox4.Text);
                cmd.Parameters.AddWithValue("@PH2", textBox5.Text);
                cmd.Parameters.AddWithValue("@VAddress", textBox6.Text);
                cmd.Parameters.AddWithValue("@CPName", textBox7.Text);
                cmd.Parameters.AddWithValue("@CPPH", textBox8.Text);
                cmd.Parameters.AddWithValue("@VEmail", textBox9.Text);
                cmd.Parameters.AddWithValue("@VFax", textBox10.Text);
                cmd.Parameters.AddWithValue("@VGroup", textBox11.Text);
                cmd.Parameters.AddWithValue("@VStatus", textBox12.Text);


                cmd.ExecuteNonQuery();
            
                MessageBox.Show("Selected Data has been Updated ");

            
         
               c.oleDbConnection1.Close();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            approved a = new approved();
            a.Show();
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
