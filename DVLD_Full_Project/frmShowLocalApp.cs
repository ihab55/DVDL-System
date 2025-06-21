using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Full_Project
{
    public partial class frmShowLocalApp : Form
    {
        public frmShowLocalApp(int LocalID)
        {
            InitializeComponent();
            ucDLAppInfo1.FillLocalAppInfo(LocalID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
