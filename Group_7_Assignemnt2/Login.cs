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
    public partial class Login : Form
    {
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

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Backend Connection
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source = DESKTOP-ME5NTSG; Initial Catalog = STORE_PRODUCTS; Integrated Security = True";

            //Opening the connection
            con.Open();

            //Getting data

            SqlDataAdapter SQLCMD = new SqlDataAdapter("Select * from USERS", con);

            DataTable DT = new DataTable();

            SQLCMD.Fill(DT);
        }
    }
}
