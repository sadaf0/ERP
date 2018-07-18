﻿using System;
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
    public partial class pofinal : Form
    {
        connection conn = new connection();
        string[] pid = new string[50];
        int[] qty = new int[50];
        int[] pprice = new int[50];
        //string[] POIDD = new string[50];

        int counter = 0;
        public pofinal()
        {
            InitializeComponent();
        }

        private void pofinal_Load(object sender, EventArgs e)
        {
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox9.ReadOnly = true;

            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select Deptname from Dept ", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox3.Items.Add(dr["Deptname"]).ToString();
            }


            OleDbCommand cmdd = new OleDbCommand("Select VID from Vendor where VStatus = 'ACTIVE' ", conn.oleDbConnection1);
            OleDbDataReader drr = cmdd.ExecuteReader();

            while (drr.Read())
            {
                comboBox1.Items.Add(drr["VID"]).ToString();
            }


            OleDbCommand cd = new OleDbCommand("Select Pid from Products ", conn.oleDbConnection1);
            OleDbDataReader dnr = cd.ExecuteReader();
            while (dnr.Read())
            {

                comboBox2.Items.Add(dnr["Pid"]).ToString();
            }

            conn.oleDbConnection1.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select *from Vendor where VID = '" + comboBox1.Text + "'", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                // textBox1.Text = dr["VID"].ToString();
                textBox2.Text = dr["VName"].ToString();
                textBox4.Text = dr["CPPH"].ToString();
                textBox3.Text = dr["VGroup"].ToString();


            }

            conn.oleDbConnection1.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox8.Clear();
            textBox10.Clear();
            conn.oleDbConnection1.Open();
            OleDbCommand cd = new OleDbCommand("Select *from Products where Pid = '" + comboBox2.Text + "'", conn.oleDbConnection1);
            OleDbDataReader dnr = cd.ExecuteReader();

            if (dnr.Read())
            {

                textBox5.Text = dnr["ProductModel"].ToString();
                textBox6.Text = dnr["PName"].ToString();
                textBox7.Text = dnr["BasePrice"].ToString();


            }

            conn.oleDbConnection1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int tprice;
            int puprice = Convert.ToInt32(textBox7.Text);
            int pqty = Convert.ToInt32(textBox8.Text);

            tprice = pqty * puprice;
            textBox10.Text = tprice.ToString();


            textBox9.Text += label8.Text + " : " + comboBox2.Text + Environment.NewLine;
            textBox9.Text += label11.Text + " : " + textBox5.Text + Environment.NewLine;
            textBox9.Text += label13.Text + " : " + textBox6.Text + Environment.NewLine;
            textBox9.Text += label12.Text + " : " + textBox7.Text + Environment.NewLine;
            textBox9.Text += label10.Text + " : " + textBox8.Text + Environment.NewLine;
            textBox9.Text += label6.Text + " : " + textBox10.Text + Environment.NewLine;
            textBox9.Text += "                                                            ";

            //pid[counter] = Convert.ToInt32(comboBox2.Text);
            pid[counter] = comboBox2.Text.ToString();
            qty[counter] = Convert.ToInt32(textBox8.Text);
            pprice[counter] = Convert.ToInt32(textBox10.Text);
            //  POIDD[counter] = textBox1.Text.ToString();
            counter++;

            MessageBox.Show("Products has been added");
            // MessageBox.Show("Transaction done!!");
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int c = 0;
            conn.oleDbConnection1.Open();

            OleDbCommand cmdd = new OleDbCommand("select count(POID) from PO where VDept= '" + comboBox3.Text + "'", conn.oleDbConnection1);
            OleDbDataReader drr = cmdd.ExecuteReader();
            if (drr.Read())
            {
                c = Convert.ToInt32(drr[0]);
                c++;
            }

            textBox1.Text = comboBox3.Text + "-" + c.ToString() + "-" + System.DateTime.Today.Year;

            conn.oleDbConnection1.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int s = 0;
            foreach (int p in pprice)
            {
                s += p + s;
                // s++;

            }

            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("insert into PO(POID,PODate,VDept,VName,VID,VCPPH,PPRICE) values(@POID,@PODate,@VDept,@VName,@VID,@VCPPH,@PPRICE)", conn.oleDbConnection1);

            cmd.Parameters.AddWithValue("@POID", textBox1.Text);
            cmd.Parameters.AddWithValue("@PODate", dateTimePicker1);
            cmd.Parameters.AddWithValue("@VDept", textBox3.Text);
            cmd.Parameters.AddWithValue("@VName", textBox2.Text);
            cmd.Parameters.AddWithValue("@VID", comboBox1.Text);
            cmd.Parameters.AddWithValue("@VCPPH", textBox4.Text);
            cmd.Parameters.AddWithValue("@PPRICE", s);

            cmd.ExecuteNonQuery();


            for (int i = 0; i < counter; i++)
            {
                OleDbCommand cmd1 = new OleDbCommand("insert into POProducts(POID,Pid,PQty,TPPRICE,PNAME,PMODEL) values(@POID,@Pid,@PQty,@TPPRICE,@PNAME,@PMODEL)", conn.oleDbConnection1);

                cmd1.Parameters.AddWithValue("@POID", textBox1.Text);
                cmd1.Parameters.AddWithValue("@Pid", pid[i]);
                cmd1.Parameters.AddWithValue("@PQty", qty[i]);
                cmd1.Parameters.AddWithValue("@TPPRICE", pprice[i]);
                cmd1.Parameters.AddWithValue("@PNAME", textBox6.Text);
                cmd1.Parameters.AddWithValue("@PMODEL", textBox5.Text);
                cmd1.ExecuteNonQuery();
                // counter++;
            }

            conn.oleDbConnection1.Close();
            MessageBox.Show("PLEASE TAKE YOUR PURCHASE ORDER SLIP");

          
        }
    }
}
