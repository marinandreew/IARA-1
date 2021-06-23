using IARA.Views;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IARA
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string connection = "server=localhost;user=root;database=iara;port=3306;password='';pooling = false; convert zero datetime = True";
            string sql = $"SELECT * FROM users";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            int x = 0;
            while(rdr.Read())
            {
                if(rdr[1].ToString() == (usernameTxt.Text).ToLower())
                {
                    x = 1;
                    if (rdr[2].ToString() == (passwordTxt.Text).ToLower())
                    {
                        UserMenu userMenu = new UserMenu();
                        userMenu.Show();
                    }
                    else
                    {
                        MessageBox.Show("KYS pls");
                    }
                }
            }
            if(x == 0)
            {
                MessageBox.Show("LOGIN INCORRECT!!!1!");
            }

            rdr.Close();
            conn.Close();
        }
    }
}
