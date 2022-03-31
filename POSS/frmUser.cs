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
    public partial class frmUser : Form
    {
        public frmUser()
        {
            InitializeComponent();
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            Display();
            //MessageBox.Show("Test");
        }
        void Display()
        {
            try
            {
                using(SqlConnection SQLC = new SqlConnection(Koneksi.sqlConnect)) {
                    SQLC.Open();
                SqlDataAdapter sqlDisplay = new SqlDataAdapter("Select Username, Password, InputDate from tbUser order by inputdate desc", SQLC);
                sqlDisplay.SelectCommand.ExecuteNonQuery();
                DataTable data = new DataTable();
                sqlDisplay.Fill(data);
                dgData.DataSource = data;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Koneksi.Connect.Open();
                SqlDataAdapter sqlDisplay = new SqlDataAdapter("Select Username, Password from tbUser where username like '%" + textBox1.Text + "%'", Koneksi.Connect);
                sqlDisplay.SelectCommand.ExecuteNonQuery();
                DataTable data = new DataTable();
                sqlDisplay.Fill(data);
                dgData.DataSource = data;
                txtUsername.DataBindings.Add("Text", data, "username");
                txtPassword.DataBindings.Add("Text", data, "password");
                txtUsername.DataBindings.Clear();
                txtPassword.DataBindings.Clear();

                Koneksi.Connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi.Connect.Open();
                SqlDataAdapter sqlDisplay = new SqlDataAdapter("Select Username, Password from tbUser where username like '%" + textBox1.Text + "%'", Koneksi.Connect);
                sqlDisplay.SelectCommand.ExecuteNonQuery();
                DataTable data = new DataTable();
                sqlDisplay.Fill(data);
                dgData.DataSource = data;
                txtUsername.DataBindings.Add("Text", data, "username");
                txtUsername.DataBindings.Clear();

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            finally
            {
                Koneksi.Connect.Close();
            }

        }
        void InsertUser()
        {
           
           using(SqlConnection ConnectUser = new SqlConnection(Koneksi.sqlConnect))
            {
               
                DialogResult dr = MessageBox.Show("Apakah Anda yakin ingin menyimpan data ini ?","Konfirmasi",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if(dr == DialogResult.Yes)
                {
                    ConnectUser.Open();
                    SqlCommand InsertUser = new SqlCommand("INSERT INTO TBUSER VALUES(@USERNAME, @PASSWORD, NULL, GETDATE())", ConnectUser);
                    InsertUser.Parameters.AddWithValue("@USERNAME", txtUsername.Text.Trim());
                    InsertUser.Parameters.AddWithValue("@PASSWORD", txtPassword.Text.Trim());
                    InsertUser.ExecuteNonQuery();
                    MessageBox.Show("Data tersimpan");
                    txtUsername.Clear();
                    txtPassword.Clear();
                }
                else if(dr == DialogResult.No)
                {
                    
                }
            }

            
        }
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtUsername.Text.Length ==0 || txtPassword.Text.Length == 0)
                {
                    MessageBox.Show("Username atau password harus diisi!");
                }
                else
                {
                    try
                    {
                        Koneksi.Connect.Open();
                        SqlCommand CekUser = new SqlCommand("SELECT USERNAME FROM TBUSER WHERE USERNAME = '" + txtUsername.Text + "'", Koneksi.Connect);
                        SqlDataReader dr;
                        dr = CekUser.ExecuteReader();
                        if (dr.Read())
                        {
                            MessageBox.Show("Username sudah ada dalam database");
                        }
                        else
                        {
                            InsertUser();
                            Display();
                        }
                        Koneksi.Connect.Close();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                   
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using(SqlConnection Connect = new SqlConnection(Koneksi.sqlConnect))
                {
                    DialogResult dr = MessageBox.Show("Apakah Anda yakin ingin menghapus data ini ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(dr == DialogResult.Yes)
                    {
                        Connect.Open();
                        SqlCommand sqlDelete = new SqlCommand("DELETE FROM TBUSER WHERE USERNAME = '"+txtUsername.Text+"'",Connect);
                        sqlDelete.ExecuteNonQuery();
                        MessageBox.Show("Data terhapus");
                        Display();
                    }
                    else if(dr == DialogResult.No)
                    {
                        // No Action;
                    }
                }
            } 
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Apakah Anda yakin ingin mengubah data ini ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dr == DialogResult.Yes)
                {
                    using(SqlConnection Connect = new SqlConnection(Koneksi.sqlConnect))
                    {
                        Connect.Open();
                        SqlCommand sqlUpdate = new SqlCommand("UPDATE TBUSER SET PASSWORD = '"+txtPassword.Text+"' WHERE USERNAME = '"+txtUsername.Text+"'", Connect);
                        sqlUpdate.ExecuteNonQuery();
                        MessageBox.Show("Data berhasil diubah");
                        Display();
                    }
                }
                else { }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            LaporanPengguna rpt = new LaporanPengguna();
            rpt.Show();
        }
    }
}
