﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Group_7_Assignemnt2
{
    public partial class Purchase : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-ME5NTSG; Initial Catalog = STORE_PRODUCTS; Integrated Security = True");


        public Purchase()
        {
            InitializeComponent();
        }

        private void Purchase_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            String query = "select * from [dbo].[PRODUCTS]";
            SqlCommand command = new SqlCommand(query, con);

            SqlDataAdapter DA = new SqlDataAdapter(command);
            DataTable DT = new DataTable();

            DA.Fill(DT);
            dataGridView1.DataSource = DT;

            con.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            String query = "select * from [dbo].[PRODUCTS] where PRD_NAME like '" + textBox1.Text + "%'";
            con.Open();
            SqlCommand command = new SqlCommand(query, con);

            SqlDataAdapter DA = new SqlDataAdapter(command);
            DataTable DT = new DataTable();

            DA.Fill(DT);
            dataGridView1.DataSource = DT;

            con.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
