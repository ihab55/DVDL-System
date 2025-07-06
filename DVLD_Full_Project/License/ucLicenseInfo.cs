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
    public partial class ucLicenseInfo : UserControl
    {
        public ucLicenseInfo()
        {
            InitializeComponent();

        }
        public bool LoadDataByLocalID(int LocalID)
        {
            clsLicense license = clsLicense.GetLicenseByLocalID(LocalID);
            if (license != null)
            {
                txtClass.Text = license.LicenseClassInfo.ClassName;
                txtName.Text = license.DriverInfo.PersonInfo.FullName;
                txtLicenseID.Text = license.LicenseID.ToString();
                txtNationalNo.Text = license.DriverInfo.PersonInfo.NationalNo;
                if (license.DriverInfo.PersonInfo.Gendor == 0)
                {
                    txtGendor.Text = "Male";
                    MainImage.Image = Properties.Resources.person_boy;
                }
                else
                {
                    txtGendor.Text = "Female";
                    MainImage.Image = Properties.Resources.person_girl;
                }
                txtIssueDate.Text = license.IssueDate.ToString("MM/MMM/yyyy");
                txtIssueReason.Text = license.IssueReasonText;
                if (license.Note != "") txtNotes.Text = license.Note;
                txtIsActive.Text = license.IsActive ? "Yes" : "No";
                txtDateOfBirth.Text = license.DriverInfo.PersonInfo.DateOfBirth.ToString("MM/MMM/yyyy");
                txtDriverId.Text = license.DriverInfo.DriverID.ToString();
                txtExpirationDate.Text = license.ExpriationDate.ToString("MM/MMM/yyyy");
                txtDenatied.Text = clsDetainedLicenses.IsDetained(license.LicenseID) ? "Yes" : "No";
                if (license.DriverInfo.PersonInfo.ImagePath != "")
                {
                    MainImage.Image = System.Drawing.Image.FromFile(license.DriverInfo.PersonInfo.ImagePath);
                }
            }
            else
            {
                MessageBox.Show("License not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return license != null;
        }
        public bool LoadDataByLicenseID(int licenseID)
        {
            clsLicense license = clsLicense.Find(licenseID);
            if (license != null){
                return LoadDataByLicense(license);
            }
            return false;
        }
        public bool LoadDataByLicense(clsLicense license)
        {
            if (license != null)
            {
                txtClass.Text = license.LicenseClassInfo.ClassName;
                txtName.Text = license.DriverInfo.PersonInfo.FullName;
                txtLicenseID.Text = license.LicenseID.ToString();
                txtNationalNo.Text = license.DriverInfo.PersonInfo.NationalNo;
                if (license.DriverInfo.PersonInfo.Gendor == 0)
                {
                    txtGendor.Text = "Male";
                    MainImage.Image = Properties.Resources.person_boy;
                }
                else
                {
                    txtGendor.Text = "Female";
                    MainImage.Image = Properties.Resources.person_girl;
                }
                txtIssueDate.Text = license.IssueDate.ToString("MM/MMM/yyyy");
                txtIssueReason.Text = license.IssueReasonText;
                if (license.Note != "") txtNotes.Text = license.Note;
                txtIsActive.Text = license.IsActive ? "Yes" : "No";
                txtDateOfBirth.Text = license.DriverInfo.PersonInfo.DateOfBirth.ToString("MM/MMM/yyyy");
                txtDriverId.Text = license.DriverInfo.DriverID.ToString();
                txtExpirationDate.Text = license.ExpriationDate.ToString("MM/MMM/yyyy");
                txtDenatied.Text = clsDetainedLicenses.IsDetained(license.LicenseID) ? "Yes" : "No";
                if (license.DriverInfo.PersonInfo.ImagePath != "")
                {
                    MainImage.Image = System.Drawing.Image.FromFile(license.DriverInfo.PersonInfo.ImagePath);
                }
            }
            else
            {
                MessageBox.Show("License not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return license != null;
        }
    }
}
