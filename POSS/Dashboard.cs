using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSS
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUser fUser = new frmUser();
            fUser.MdiParent = this;
            fUser.Show();
        }
    }
}
