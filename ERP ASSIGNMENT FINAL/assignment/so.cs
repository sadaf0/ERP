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
    public partial class so : Form
    {
        connection x = new connection();
        public so()
        {
            InitializeComponent();
        }

        private void so_Load(object sender, EventArgs e)
        {
            button4.Visible = false;
            button5.Visible = false;
            {
                x.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("select CID from Customer", x.oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["CID"].ToString());
                }
                x.oleDbConnection1.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            x.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Update Customer set Cname=@Cname,CAddress=@CAddress,City=@City,PH1=@PH1,PH2=@PH2,ContectPerson=@ContectPerson,CPPH=@CPPH,CEmail=@CEmail,CreditLimit=@CreditLimit,CStatus=@CStatus,CGroup=@CGroup where CID='" + comboBox1.Text + "'", x.oleDbConnection1);


            cmd.Parameters.AddWithValue("@Cname", textBox1.Text);
            cmd.Parameters.AddWithValue("@CAddress", textBox2.Text);
            cmd.Parameters.AddWithValue("@City", textBox3.Text);
            cmd.Parameters.AddWithValue("@PH1", textBox4.Text);
            cmd.Parameters.AddWithValue("@PH2", textBox5.Text);
            cmd.Parameters.AddWithValue("@ContectPerson", textBox6.Text);
            cmd.Parameters.AddWithValue("@CPPH", textBox7.Text);
            cmd.Parameters.AddWithValue("@CEmail", textBox8.Text);
            cmd.Parameters.AddWithValue("@CreditLimit", textBox9.Text);
            cmd.Parameters.AddWithValue("@CStatus", textBox10.Text);
            cmd.Parameters.AddWithValue("@CGroup", textBox11.Text);
            //cmd.Parameters.AddWithValue("@VStatus", textBox12.Text);


            cmd.ExecuteNonQuery();
            MessageBox.Show("Selected Data has been Updated ");
            x.oleDbConnection1.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            x.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select * from Customer where CID='" + comboBox1.Text + "'", x.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr["Cname"].ToString();
                textBox2.Text = dr["CAddress"].ToString();
                textBox3.Text = dr["City"].ToString();
                textBox4.Text = dr["PH1"].ToString();
                textBox5.Text = dr["PH2"].ToString();
                textBox6.Text = dr["ContectPerson"].ToString();
                textBox7.Text = dr["CPPH"].ToString();
                textBox8.Text = dr["CEmail"].ToString();
                textBox9.Text = dr["CreditLimit"].ToString();
                textBox10.Text = dr["CStatus"].ToString();
                textBox11.Text = dr["CGroup"].ToString();
                


            }
            x.oleDbConnection1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
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
            button4.Visible = true;
            button5.Visible = true;
            button1.Visible = false;
            button3.Visible = false;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button3.Visible = false;
            MessageBox.Show("Approved Successfully");
            salesorder s = new salesorder();
            s.Show();
            this.Hide();
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
            textBox5.ReadOnly = false;
            textBox6.ReadOnly = false;
            textBox7.ReadOnly = false;
            textBox8.ReadOnly = false;
            textBox9.ReadOnly = false;
            textBox10.ReadOnly = false;
            textBox11.ReadOnly = false;
            button4.Visible = false;
            button5.Visible = false;
            button1.Visible = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }
    }
}
