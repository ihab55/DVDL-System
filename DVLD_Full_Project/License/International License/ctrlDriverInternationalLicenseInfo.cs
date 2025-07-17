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
using DVLD_Full_Project.Properties;

namespace DVLD_Full_Project
{
    public partial class ctrlDriverInternationalLicenseInfo : UserControl
    {
        private clsInternationalLicense _InternationalLicense;
        public clsInternationalLicense InternationalLicense
        {
            get { return _InternationalLicense; }
        }
        public ctrlDriverInternationalLicenseInfo()
        {
            InitializeComponent();
        }
        private void _HandelImage()
        {
            pbMain.Image = (_InternationalLicense.DriverInfo.PersonInfo.Gendor == 0) ?
                Resources.person_boy : Resources.person_girl;
            string imagePath = _InternationalLicense.DriverInfo.PersonInfo.ImagePath;
            if (!string.IsNullOrEmpty(imagePath))
            {
                if (!System.IO.File.Exists(imagePath))
                {
                    MessageBox.Show("Image file not found: " + imagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                pbMain.ImageLocation = imagePath;
            }
        }
        public void LoadInfo(int InternationalLicenseID)
        {
            _InternationalLicense = clsInternationalLicense.Find(InternationalLicenseID);
            if (_InternationalLicense == null)
            {
                MessageBox.Show("Could not find Internationa License ID = " + InternationalLicenseID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtIntLicense.Text = InternationalLicenseID.ToString();
            txtApplicationID.Text = _InternationalLicense.ApplicationID.ToString();
            txtIsActive.Text = _InternationalLicense.IsActive ? "Yes" : "No";
            txtLicenseID.Text = _InternationalLicense.IssuedUsingLocalLicenseID.ToString();
            txtName.Text = _InternationalLicense.DriverInfo.PersonInfo.FullName;
            txtNationalNo.Text = _InternationalLicense.DriverInfo.PersonInfo.NationalNo;
            txtGendor.Text = _InternationalLicense.DriverInfo.PersonInfo.Gendor == 0? "Male" : "Female";
            txtDateOfBirth.Text = _InternationalLicense.DriverInfo.PersonInfo.DateOfBirth.ToShortDateString();
            txtDriverID.Text = _InternationalLicense.DriverID.ToString();
            txtIssueDate.Text = _InternationalLicense.IssueDate.ToShortDateString();
            txtExpirationDate.Text = _InternationalLicense.ExpirationDate.ToShortDateString();

            _HandelImage();

        }
    }
}
