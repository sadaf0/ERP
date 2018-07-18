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
    public partial class po : Form
    {
        connection x = new connection();
        string[] pid = new string[50];
        int[] qty = new int[50];
        int[] pprice = new int[50];
        int counter = 0; 
        public po()
        {
            InitializeComponent();
        }

        private void po_Load(object sender, EventArgs e)
        {
            //textBox5.ReadOnly = true;
            //textBox6.ReadOnly = true;
            //textBox7.ReadOnly = false;
            //comboBox2.Enabled = false;
            //comboBox3.Enabled = false;

            //x.oleDbConnection1.Open();
            //OleDbCommand cmd = new OleDbCommand("Select vgroup from vendor", x.oleDbConnection1);
            //OleDbDataReader dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    comboBox1.Items.Add(dr["vgroup"]).ToString();
            //}

            //x.oleDbConnection1.Close();

            //----------------------------------------
            try
            {
                x.oleDbConnection1.Open();

                //Department Combo
                OleDbCommand cmd = new OleDbCommand("Select  deptname from Dept", x.oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["deptname"]).ToString();
                }

                OleDbCommand cmdd = new OleDbCommand("Select VID from PO where Approve = 'APPROVED' ", x.oleDbConnection1);
                OleDbDataReader drr = cmdd.ExecuteReader();

                while (drr.Read())
                {
                    comboBox3.Items.Add(drr["VID"]).ToString();
                }
            }
            //// Items Combo
            //OleDbCommand cm = new OleDbCommand("Select Pid from Products", x.oleDbConnection1);
            //OleDbDataReader dri = cm.ExecuteReader();

            //while (dri.Read())
            //{
            //    comboBox2.Items.Add(dri["Pid"]);
            //}
        catch(Exception ee)
      {
          MessageBox.Show("error"+ee);
        }
            x.oleDbConnection1.Close();



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //comboBox2.Enabled = true;
            //comboBox3.Enabled = true;
           
            x.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select count (POID) from PO where VDept = @VDept", x.oleDbConnection1);
            cmd.Parameters.AddWithValue("@VDept", comboBox1.Text);


            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                counter = Convert.ToInt32(dr[0]);

            }
            counter += 1;
            textBox1.Text = comboBox1.Text + "-00" + counter.ToString() + "-" + System.DateTime.Today.Year;

            ////VendorID Combo
            //OleDbCommand cmmd = new OleDbCommand("Select VID from Vendor where VStatus = 'ACTIVE'", x.oleDbConnection1);
            //cmmd.Parameters.AddWithValue("@VID", comboBox3.Text);
            //OleDbDataReader drr = cmmd.ExecuteReader();
            //comboBox3.Items.Clear();

            //while (drr.Read())
            //{
            //    comboBox3.Items.Add(drr["VID"]).ToString();
            //}

            //x.oleDbConnection1.Close();



            //x.oleDbConnection1.Open();
            //OleDbCommand cmd = new OleDbCommand("Select *from vendor where vgroup = '" + comboBox1.Text + "'", x.oleDbConnection1);
            //OleDbDataReader dr = cmd.ExecuteReader();

            //if (dr.Read())
            //{
            //    //textBox1.Text = dr["VID"].ToString();
            //    textBox2.Text = dr["Vname"].ToString();
            //    textBox3.Text = dr["Vcity"].ToString();
            //    textBox4.Text = dr["CPPH"].ToString();

            //}

            x.oleDbConnection1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pid[counter] = comboBox2.Text;

            counter++;


            x.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select Pid from Products ", x.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr["Pid"]).ToString();
            }

            x.oleDbConnection1.Close();


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            x.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select * from Products where Pid='" + comboBox2.Text + "'", x.oleDbConnection1);
            OleDbDataReader drr = cmd.ExecuteReader();
            if (drr.Read())
            {
                textBox5.Text = drr["PName"].ToString();
                textBox6.Text = drr["BasePrice"].ToString();
            }
            x.oleDbConnection1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //x.oleDbConnection1.Open();

            //for (int i = 0; i < counter; i++)
            //{

            //    OleDbCommand cmd = new OleDbCommand("insert into POProducts(POID,Pmodel,Pprice,Pqty) values(@POID,@Pmodel,@Pprice,@Pqty)", x.oleDbConnection1);

            //    cmd.Parameters.AddWithValue("@POID", comboBox2.Text);
            //    cmd.Parameters.AddWithValue("@Pmodel", comboBox2.Text);
            //    cmd.Parameters.AddWithValue("@Pprice", textBox6.Text);
            //    cmd.Parameters.AddWithValue("@Pqty", textBox7.Text);
            //    cmd.ExecuteNonQuery();

            //}
            //x.oleDbConnection1.Close();

            pid[counter] = comboBox2.Text;

            qty[counter] = Convert.ToInt32(textBox8.Text);
            pprice[counter] = Convert.ToInt32(textBox7.Text);
            counter++;





            MessageBox.Show("Transaction done!!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int s = 0;
            foreach (int p in pprice)
            {
                s += p + s;

            }

            x.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("insert into PO(POID,VDept,VName,VID,VCPPH,TotalAmount) values(@POID,@VDept,@VName,@VID,@VCPPH,@TotalAmount)", x.oleDbConnection1);

            cmd.Parameters.AddWithValue("@POID", textBox1.Text);
           // cmd.Parameters.AddWithValue("@PODate", dateTimePicker1);
            cmd.Parameters.AddWithValue("@VDept", comboBox1.Text);
            cmd.Parameters.AddWithValue("@VName", textBox2.Text);
            cmd.Parameters.AddWithValue("@VID", comboBox3.Text);
            cmd.Parameters.AddWithValue("@VCPPH", textBox4.Text);
            cmd.Parameters.AddWithValue("@TotalAmount", textBox8.Text);
            // cmd.Parameters.AddWithValue("@PPRICE", textBox7.Text);
            cmd.ExecuteNonQuery();




            //conn.oleDbConnection1.Open();
            
            
                OleDbCommand cmd1 = new OleDbCommand("insert into POProducts(POID,Pmodel,PPrice,PQty) values(@POID,@Pmodel,@pprice,@PQty)", x.oleDbConnection1);

                cmd1.Parameters.AddWithValue("@POID", textBox1.Text);
               // cmd1.Parameters.AddWithValue("@Pid", pid[i]);
                cmd1.Parameters.AddWithValue("@Pmodel", comboBox2.Text);
                cmd1.Parameters.AddWithValue("@PPrice", textBox6.Text);
                cmd1.Parameters.AddWithValue("@PQty", textBox7.Text);

               
                cmd1.ExecuteNonQuery();
                //counter++;
            

            OleDbDataAdapter da = new OleDbDataAdapter("Select  *from POProducts where Pmodel='" + this.comboBox2.Text + "'", x.oleDbConnection1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;



            x.oleDbConnection1.Close();




            MessageBox.Show("PLEASE TAKE YOUR PURCHASE ORDER SLIP");
            try
            {

            }
            catch (ArrayTypeMismatchException ax)
            {
                MessageBox.Show(ax.Message);

            }





        //    OleDbDataAdapter da = new OleDbDataAdapter("Select  *from POProducts where Pmodel='" + this.comboBox2.Text + "'", x.oleDbConnection1);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                x.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("Select *from PO where VID = '" + comboBox3.Text + "'", x.oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {

                    textBox2.Text = dr["Vname"].ToString();
                    textBox3.Text = dr["VDept"].ToString();
                    textBox4.Text = dr["VCPPH"].ToString();

                }
            }
            catch(Exception ee)
            {
            
            MessageBox.Show(""+ee);
            
            }

            x.oleDbConnection1.Close();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            int da = Convert.ToInt32(textBox6.Text) * Convert.ToInt32(textBox7.Text);
            textBox8.Text = Convert.ToString(da);
        }
    }
}
