using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinessLayer;

namespace DVLD_Full_Project
{
    public partial class frmShowLicesnse : Form
    {
        public frmShowLicesnse(int LocalID)
        {
            InitializeComponent();
            if(!ucLicenseInfo1.LoadDataByLocalID(LocalID)) ucLicenseInfo1.Enabled = false;
        }
        public frmShowLicesnse(int LiceID, bool LicID )
        {
            InitializeComponent();
            ucLicenseInfo1.LoadDataByLicenseID(LiceID);
        }
        public frmShowLicesnse(clsLicense license)
        {
            InitializeComponent();
            ucLicenseInfo1.LoadDataByLicense(license);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
