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
    public partial class salesorder : Form
    {
        connection x = new connection();
        string[] prds = new string[50];
        int[] qty = new int[50];
        int[] pprice = new int[50];
        int counter = 0;
        public salesorder()
        {
            InitializeComponent();
        }

        private void salesorder_Load(object sender, EventArgs e)
        {

            {
                x.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("select deptname from Dept", x.oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["deptname"].ToString());
                }
                x.oleDbConnection1.Close();
            }
            //combo 2 ko populate karaney ka code jo customer ka hai//
            x.oleDbConnection1.Open();
            OleDbCommand cm = new OleDbCommand("Select CID from Customer where CStatus = 'Active' ", x.oleDbConnection1);
            OleDbDataReader drr = cm.ExecuteReader();
            while (drr.Read())
            {
                comboBox2.Items.Add(drr["CID"]).ToString();
            }

            x.oleDbConnection1.Close();

          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                int c = 0;
                x.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("select count(soid) from so where dnam='" + comboBox1.Text + "'", x.oleDbConnection1);

                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    c = Convert.ToInt32(dr[0]);
                    c++;
                    textBox1.Text = "SO-0" + c.ToString() + "-" + System.DateTime.Today.Year;

                }



                x.oleDbConnection1.Close();

            }










        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {  
            {
                x.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("Select *from Customer where CID = '" + comboBox2.Text + "'", x.oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    textBox2.Text = dr["Cname"].ToString();
                    textBox3.Text = dr["CAddress"].ToString();
                    textBox4.Text = dr["City"].ToString();
                    textBox8.Text = dr["ContectPerson"].ToString();

                }

                x.oleDbConnection1.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            prds[counter] = comboBox3.Text;

            counter++;


            x.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select Pid from Products ", x.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox3.Items.Add(dr["Pid"]).ToString();
            }

            x.oleDbConnection1.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            x.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select * from Products where Pid='" + comboBox3.Text + "'", x.oleDbConnection1);
            OleDbDataReader drr = cmd.ExecuteReader();
            if (drr.Read())
            {
                textBox5.Text = drr["PName"].ToString();
                textBox6.Text = drr["BasePrice"].ToString();
            }
            x.oleDbConnection1.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            x.oleDbConnection1.Open();

            for (int i = 0; i < counter; i++)
            {

                OleDbCommand cmd = new OleDbCommand("insert into so(dnam,soid,cid,cname,cadd,city,cp,pmodel,pname,pprice,pqty) values(@dnam,@soid,@cid,@cname,@cadd,@city,@cp,@pmodel,@pname,@pprice,@pqty)", x.oleDbConnection1);

                cmd.Parameters.AddWithValue("@dnam", comboBox1.Text);
                cmd.Parameters.AddWithValue("@soid", textBox1.Text);
                cmd.Parameters.AddWithValue("@cid", comboBox2.Text);
                cmd.Parameters.AddWithValue("@cname", textBox2.Text);
                cmd.Parameters.AddWithValue("@cadd", textBox3.Text);
                cmd.Parameters.AddWithValue("@city", textBox4.Text);
                cmd.Parameters.AddWithValue("@cp", textBox8.Text);
                cmd.Parameters.AddWithValue("@pmodel", comboBox3.Text);
                cmd.Parameters.AddWithValue("@pname", textBox5.Text);
                cmd.Parameters.AddWithValue("@pprice", textBox6.Text);
                cmd.Parameters.AddWithValue("@pqty", textBox7.Text);
                cmd.Parameters.AddWithValue("@cname", textBox2.Text);

                cmd.ExecuteNonQuery();

            }
            x.oleDbConnection1.Close();
            //MessageBox.Show("Transaction done!!");
            OleDbDataAdapter da = new OleDbDataAdapter("Select  * from so ", x.oleDbConnection1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;





        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
    }
}
