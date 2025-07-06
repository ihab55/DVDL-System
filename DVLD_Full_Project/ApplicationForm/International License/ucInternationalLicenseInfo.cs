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
    public partial class ucInternationalLicenseInfo : UserControl
    {
        public ucInternationalLicenseInfo()
        {
            InitializeComponent();
        }
        public void SetLicenseInfo(BussinessLayer.clsInternationalLicense license)
        {
            if (license == null) return;
            txtName.Text = license.DriverInfo.PersonInfo.FullName;
            txtIntLicense.Text = license.InternationalLicenseID.ToString();
            txtLicenseID.Text = license.IssuedUsingLocalLicenseInfo.LicenseID.ToString();
            txtNationalNo.Text = license.DriverInfo.PersonInfo.NationalNo.ToString();
            if (license.DriverInfo.PersonInfo.Gendor == 0)
            {
                txtGendor.Text = "Male";
                pbMain.Image = Properties.Resources.person_boy;
            }
            else
            {
                txtGendor.Text = "Female";
                pbMain.Image = Properties.Resources.person_girl;
            }
            txtIssueDate.Text = license.IssueDate.ToString("MM/MMM/yyyy");
            txtApplicationID.Text = license.ApplicationInfo.ID.ToString();
            txtIsActive.Text = license.IsActive ? "Yes" : "No";
            txtDateOfBirth.Text = license.DriverInfo.PersonInfo.DateOfBirth.ToString("MM/MMM/yyyy");
            txtDriverID.Text = license.DriverInfo.DriverID.ToString();
            txtExpirationDate.Text = license.ExpirationDate.ToString("MM/MMM/yyyy");
            if (license.DriverInfo.PersonInfo.ImagePath != "") pbMain.Image = Image.FromFile(license.DriverInfo.PersonInfo.ImagePath);
        }
    }
}
