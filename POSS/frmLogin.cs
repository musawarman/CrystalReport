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

namespace POSS
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtUsername.Text.Length == 0 || txtPassword.Text.Length == 0)
                {
                    MessageBox.Show("Invalid username or password");
                }
                else
                {
                    Koneksi.Connect.Open();
                    SqlCommand sqlLogin = new SqlCommand("Select username, password from tbUser where username = '"+txtUsername.Text+"' and password = @password", Koneksi.Connect);
                    sqlLogin.Parameters.AddWithValue("@password", txtPassword.Text);
                    SqlDataReader dr;
                    dr = sqlLogin.ExecuteReader();
                    if (dr.Read())
                    {
                        MessageBox.Show("Login berhasil...");
                        Dashboard db = new Dashboard();
                        db.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Login gagal...");
                    }
                    Koneksi.Connect.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }
    }
}
