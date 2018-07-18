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
    public partial class Invoice : Form
    {
        connection x = new connection();
        string[] prds = new string[50];
        int[] qty = new int[50];
        int[] pprice = new int[50];
        int counter = 0;

        public Invoice()
        {
            InitializeComponent();
        }

        private void Invoice_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
            //-----------------------------//
            textBox11.ReadOnly = true;
            label12.Visible = false;
            textBox11.Visible = false;




            try
            {
                x.oleDbConnection1.Open();
                OleDbCommand f = new OleDbCommand("select GRNID from GRN where Status='Open'", x.oleDbConnection1);
                OleDbDataReader dm = f.ExecuteReader();
                while (dm.Read())
                {
                    comboBox1.Items.Add(dm["GRNID"].ToString());
                }
                OleDbCommand cmd = new OleDbCommand("select count(InvoiceID) from Invoice", x.oleDbConnection1);

                OleDbDataReader dr = cmd.ExecuteReader();


                if (dr.Read())
                {
                    counter = Convert.ToInt32(dr[0]);

                }
                counter += 1;
                textBox1.Text = "INV-0" + counter.ToString() + "-" + System.DateTime.Today.Year;
            }
            catch(Exception ee)
            {
                MessageBox.Show("Error"+ee);

            }
                

                x.oleDbConnection1.Close();

            





        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label12.Visible = true;
            textBox11.Visible = true;

            try
            {

                x.oleDbConnection1.Open();
                OleDbCommand cm = new OleDbCommand("Select VID,VContectPerson,VCPPH,TotalAmount from PO", x.oleDbConnection1);
                OleDbDataReader ds = cm.ExecuteReader();
                if (ds.Read())
                {
                    textBox2.Text = ds["VID"].ToString();
                    textBox4.Text = ds["VContectPerson"].ToString();
                    textBox5.Text = ds["VCPPH"].ToString();
                    textBox9.Text = ds["TotalAmount"].ToString();


                }
            
                OleDbCommand cc = new OleDbCommand("Select POID,VName,DDate,GRDate,SNO from GRN where GRNID='" + comboBox1.Text + "'", x.oleDbConnection1);
                OleDbDataReader drr = cc.ExecuteReader();
                if (drr.Read())
                {
                    textBox11.Text = drr["POID"].ToString();
                    textBox3.Text = drr["VName"].ToString();
                    textBox6.Text = drr["DDate"].ToString();
                    textBox7.Text = drr["GRDate"].ToString();
                    textBox10.Text = drr["SNO"].ToString();


                }
            }
            catch(Exception ee)
            {

                MessageBox.Show("Error"+ee);
            }

                x.oleDbConnection1.Close();
         

           

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                x.oleDbConnection1.Open();
                OleDbCommand cx = new OleDbCommand("insert into Invoice (InvoiceID,VendorID,VendorName,ContectPerson,CPPH,DCDate,GRNDate,CDate,Amountpayable,GRNID) values(@InvoiceID,@VendorID,@VendorName,@ContectPerson,@CPPH,@DCDate,@GRNDate,@CDate,@total,@GRNID)", x.oleDbConnection1);
                cx.Parameters.AddWithValue("@InvoiceID", textBox1.Text);
                cx.Parameters.AddWithValue("@VendorID", textBox2.Text);
                cx.Parameters.AddWithValue("@VendorName", textBox3.Text);
                cx.Parameters.AddWithValue("@ContectPerson", textBox4.Text);
                cx.Parameters.AddWithValue("@CPPH", textBox5.Text);
                cx.Parameters.AddWithValue("@DCDate", textBox6.Text);
                cx.Parameters.AddWithValue("@GRNDate", textBox7.Text);
                cx.Parameters.AddWithValue("@CDate", dateTimePicker1.Text);
                cx.Parameters.AddWithValue("@AmountPayable", textBox12.Text);
                cx.Parameters.AddWithValue("@GRNID", comboBox1.Text);

                cx.ExecuteNonQuery();
                //textBox5.Text += "PO-ID: " + comboBox1.Text + Environment.NewLine + "V-Status: " + textBox7.Text + Environment.NewLine + "V-Name: " + textBox6.Text + Environment.NewLine + "DDate: " + textBox4.Text + Environment.NewLine + "GR-Date: " + dateTimePicker1.Text + Environment.NewLine + "SNO: " + textBox3.Text;
                //OleDbCommand p = new OleDbCommand("Update GRN set Status='Close' where GRNID=@GRNID", x.oleDbConnection1);
                //p.Parameters.AddWithValue("@GRNID", comboBox1.Text);
                OleDbDataAdapter da = new OleDbDataAdapter("Select  * from Invoice", x.oleDbConnection1);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
           // int df = Convert.ToInt32(textBox9.Text) * Convert.ToInt32(textBox8.Text) / 100;
            catch(Exception ee)
            {
                MessageBox.Show("Error"+ee);
            }
            x.oleDbConnection1.Close();

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            int da = Convert.ToInt32(textBox9.Text) * Convert.ToInt32(textBox8.Text)/100;
            textBox12.Text = Convert.ToString(da);
            //da = Convert.ToInt32(textBox12.Text);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

      
    }
}
