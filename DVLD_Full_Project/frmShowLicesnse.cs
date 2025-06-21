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
    public partial class frmShowLicesnse : Form
    {
        public frmShowLicesnse(int LocalID)
        {
            InitializeComponent();
            if(!ucLicenseInfo1.LoadDataByLocalID(LocalID)) ucLicenseInfo1.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
