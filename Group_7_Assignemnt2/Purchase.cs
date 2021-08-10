using System;
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
        DataTable table = new DataTable();


        public Purchase()
        {
            InitializeComponent();
        }

        int num = 0;
        string product;
        int uprice, toprice, qty;

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

            table.Columns.Add("Num", typeof(int));
            table.Columns.Add("Product", typeof(string));
            table.Columns.Add("Quantity", typeof(int));
            table.Columns.Add("Uprice", typeof(int));
            table.Columns.Add("ToPrice", typeof(int));

            dataGridView2.DataSource = table;

         //   con.Close();

        }

        //Method for Search function
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

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The total amount for your purchase is: ", "Thank you! ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        int flag = 0;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

           // MessageBox.Show("bingo");
            product = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            // qty = Convert.ToInt32(textBox2.Text);
            uprice = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
            // toprice = qty * uprice;
            flag = 1;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        int sum = 0;
        private void button3_Click(object sender, EventArgs e)
        {
           
            if (textBox2.Text == "")
            {

                MessageBox.Show("Please enter the quantity ");
            }

            else if (flag == 0)
            {
                MessageBox.Show("Please select a product to add to cart ");

            }
            else
            {

                num = num + 1;
                qty = Convert.ToInt32(textBox2.Text);
                toprice = qty * uprice;
                table.Rows.Add(num, qty, uprice, toprice);
                dataGridView2.DataSource = table;
                flag = 0;

            }

           // sum = sum + toprice;

            }
        }
    }

