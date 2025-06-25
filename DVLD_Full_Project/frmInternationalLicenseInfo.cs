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
    public partial class frmInternationalLicenseInfo : Form
    {
        public frmInternationalLicenseInfo(clsInternationalLicense license)
        {
            InitializeComponent();
            ucInternationalLicenseInfo1.SetLicenseInfo(license);
        }
        public frmInternationalLicenseInfo(int licenseID)
        {
            InitializeComponent();
            clsInternationalLicense license = clsInternationalLicense.Find(licenseID);
            ucInternationalLicenseInfo1.SetLicenseInfo(license);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
