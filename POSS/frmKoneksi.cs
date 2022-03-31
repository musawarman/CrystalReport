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
    public partial class frmKoneksi : Form
    {
        public frmKoneksi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection Koneksi = new SqlConnection("Data Source = 192.168.80.130, 1433; Initial Catalog = dbPOS; UID = sa; password = Auruman1.");
                Koneksi.Open();
                MessageBox.Show("Koneksi Berhasil");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Connection Error : " + ex.Message);
            }
        }
    }
}
