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

//This Form Page is for the user to create a secured login form that verify that the username and password are correct.
//Author: Hoda Abokhadra, August, 2021

namespace Group_7_Assignemnt2
{
    public partial class Login : Form
    {
        //Backend Connection
        SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-ME5NTSG; Initial Catalog = STORE_PRODUCTS; Integrated Security = True");

        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        //Setting the connection status
        private void Login_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        //This method is getting the user input for the username and password and verifiyng them with the info stored in the USERS table
        private void button1_Click(object sender, EventArgs e)
        {

            int i = 0;
            SqlCommand command = con.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from USERS where USERID = '" +textBox1.Text + "' and USERPASSWORD ='" + textBox2.Text + "'";
            command.ExecuteNonQuery();
            DataTable DT = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter(command);
            DA.Fill(DT);
            i = Convert.ToInt32(DT.Rows.Count.ToString());

            if(i == 0)
            {
                //Displaying a warning message to the user when entering wrong inputs
                MessageBox.Show("Invalid Username or Password .. Please try again! ", "Warning! ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {

                this.Hide(); //hiding the Login Form when entering correct inputs
                Purchase purchase = new Purchase(); // Showing the Purchase form
                purchase.ShowDialog();

            }

           
        }

        //terminating the applicaton by clicking EXIT
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
