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
    public partial class LaporanPengguna : Form
    {
        public LaporanPengguna()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            display();
        }
        public void display()
        {
            using (SqlConnection sqlConnection = new SqlConnection(Koneksi.sqlConnect))
            {
                LaporanUserbyParams report = new LaporanUserbyParams();

                var ds = new dsPengguna();
                var table = ds.tbUser;

                sqlConnection.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter("SELECT * FROM tbUser where username = '"+txtCari.Text+"'", sqlConnection);
                sqlda.SelectCommand.ExecuteNonQuery();
                sqlda.Fill(table);

                report.SetDataSource(ds);
                crystalReportViewer1.ReportSource = report;
                crystalReportViewer1.RefreshReport();

            }
        }
        public void displayAll()
        {
            using (SqlConnection sqlConnection = new SqlConnection(Koneksi.sqlConnect))
            {
                LaporanUserbyParams report = new LaporanUserbyParams();

                var ds = new dsPengguna();
                var table = ds.tbUser;

                sqlConnection.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter("SELECT * FROM tbUser", sqlConnection);
                sqlda.SelectCommand.ExecuteNonQuery();
                sqlda.Fill(table);

                report.SetDataSource(ds);
                crystalReportViewer1.ReportSource = report;
                crystalReportViewer1.RefreshReport();

            }
        }
        private void crystalReportViewer1_ReportRefresh(object source, CrystalDecisions.Windows.Forms.ViewerEventArgs e)
        {
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            displayAll();
        }
    }

}
