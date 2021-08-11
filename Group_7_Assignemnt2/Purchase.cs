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


//This Form Page is for the user to create a purchace using DataGridView property.
//Author: Hoda Abokhadra, August, 2021

namespace Group_7_Assignemnt2
{
    public partial class Purchase : Form
    {   
        //Creating the Database connection
        SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-ME5NTSG; Initial Catalog = STORE_PRODUCTS; Integrated Security = True");
        //Table to display the cart to the user
        DataTable table = new DataTable();

        //initializing vriables to store the value in the cart table
        int num = 0;
        string product;
        int uprice, toprice, qty;

        public Purchase()
        {
            InitializeComponent();
        }

       
        
        private void Purchase_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open) //setting the connections status
            {
                con.Close();
            }
            con.Open();

            //Query for displaying all the products in DataGridView1 using the backend connection
            String query = "select * from [dbo].[PRODUCTS]";
            SqlCommand command = new SqlCommand(query, con);

            SqlDataAdapter DA = new SqlDataAdapter(command);
            DataTable DT = new DataTable();
            DA.Fill(DT);

            dataGridView1.DataSource = DT;

            //Adding the table columns for displaying the cart
            table.Columns.Add("Num", typeof(int));
            table.Columns.Add("Product", typeof(string));
            table.Columns.Add("Quantity", typeof(int));
            table.Columns.Add("Unit price", typeof(int));
            table.Columns.Add("Total Price", typeof(int));

            dataGridView2.DataSource = table;

        }

        //This a comment
        
        //Method for Search function
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            String query = "select * from [dbo].[PRODUCTS] where PRD_NAME like '" + textBox1.Text + "%'";
            SqlCommand command = new SqlCommand(query, con);

            SqlDataAdapter DA = new SqlDataAdapter(command);
            DataTable DT = new DataTable();

            DA.Fill(DT);
           
            dataGridView1.DataSource = DT;

            con.Close();
        }
        //Exit button terminate the application
        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //Button2 (checkout) Display the total (sum) for the user once he clicks it 
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"The total amount for your purchase is: {sum}$", "Thank you! ^^ ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        int flag = 0;

        //This method for storing the values of the product the user has clicked to add to cart
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

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        //initializing the sum variable for storing the total amoun of the cart

        int sum = 0;

        //Verifiying that the user will select a product before adding the quantity to the cart and that the user enters the amount as well
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
                //adding the item or the product that the user selected into the cart bi displaying it in DataGridView2

                num = num + 1;
                qty = Convert.ToInt32(textBox2.Text);
                toprice = qty * uprice;
                table.Rows.Add(num, product, qty, uprice, toprice);
                dataGridView2.DataSource = table;
                flag = 0;

            }
            // calculating and displaying the sum to the user
           sum = sum + toprice;
           label3.Text = "$ " + sum.ToString();

            }
        }
    }

