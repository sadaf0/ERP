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
    public partial class grn : Form
    {
        connection x = new connection();
         int counter = 0; 

        public grn()
        {
            InitializeComponent();
        }

        private void grn_Load(object sender, EventArgs e)
        {
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            label2.Visible = false;
            textBox1.Visible = false;


            try
            {
                x.oleDbConnection1.Open();

                OleDbCommand cm = new OleDbCommand("select count(GRNID) from grn", x.oleDbConnection1);
                OleDbDataReader d = cm.ExecuteReader();

                if (d.Read())
                {
                    counter = Convert.ToInt32(d[0]);

                }
                counter += 1;
                textBox1.Text = "GRN-00" + counter.ToString() + "-" + System.DateTime.Today.Year;

                OleDbCommand cmd = new OleDbCommand("select POID from PO where Status='Open'", x.oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["POID"].ToString());
                }



            }
            catch(Exception ee)
            {
                MessageBox.Show("Error"+ee);
            
            }
            

            x.oleDbConnection1.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Visible = true;
            textBox1.Visible = true;

            try
            {
                x.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("Select VID,SNO,DDate,VName,Status from PO where POID='" + comboBox1.Text + "'", x.oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    textBox2.Text = dr["VID"].ToString();
                    textBox3.Text = dr["SNO"].ToString();
                    textBox4.Text = dr["DDate"].ToString();
                    textBox6.Text = dr["VName"].ToString();
                    textBox5.Text = dr["Status"].ToString();



                }



                OleDbCommand cm = new OleDbCommand("Select pmodel,pqty from POProducts where POID='" + comboBox1.Text + "'", x.oleDbConnection1);
                OleDbDataReader drr = cm.ExecuteReader();
                if (drr.Read())
                {
                    textBox7.Text = drr["pmodel"].ToString();
                    textBox8.Text = drr["pqty"].ToString();
                }

            }
            catch(Exception ee)
            {
                MessageBox.Show("Eror"+ee);
            
            }

            x.oleDbConnection1.Close();

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            x.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("insert into GRN (GRNID,POID,Status,VName,DDate,GRDate,SNO) values(@GRNID,@POID,@Status,@VName,@DDate,@GRDate,@SNO)", x.oleDbConnection1);
            cmd.Parameters.AddWithValue("@GRNID", textBox1.Text);
            cmd.Parameters.AddWithValue("@POID", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Status", textBox5.Text);
            cmd.Parameters.AddWithValue("@VName", textBox4.Text);
            cmd.Parameters.AddWithValue("@DDate", textBox6.Text);
            cmd.Parameters.AddWithValue("@GRDate", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@SNO", textBox3.Text);
            

            cmd.ExecuteNonQuery();
            OleDbCommand cnd = new OleDbCommand("Update PO set status='Close' where poid='" + comboBox1.Text + "'", x.oleDbConnection1);
            cnd.ExecuteNonQuery();
            //textBox5.Text += "PO-ID: " + comboBox1.Text + Environment.NewLine + "V-Status: " + textBox7.Text + Environment.NewLine + "V-Name: " + textBox6.Text + Environment.NewLine + "DDate: " + textBox4.Text + Environment.NewLine + "GR-Date: " + dateTimePicker1.Text + Environment.NewLine + "SNO: " + textBox3.Text;
            //MessageBox.Show("Successfully Created GRN");



            
            OleDbCommand cmdd = new OleDbCommand("insert into GRNProducts (GRNID,Pmodel,PQty) values(@GRNID,@Pmodel,@PQty)", x.oleDbConnection1);
            cmdd.Parameters.AddWithValue("@GRNID", textBox1.Text);
            cmdd.Parameters.AddWithValue("@Pmodel", textBox7.Text);
            cmdd.Parameters.AddWithValue("@PQty", textBox8.Text);
           

            cmd.ExecuteNonQuery();

            MessageBox.Show("Successfully Created GRN");


            OleDbDataAdapter da = new OleDbDataAdapter("Select  *from POProducts ", x.oleDbConnection1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            x.oleDbConnection1.Close();



        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 ff = new Form1();
            ff.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
