using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinessLayer;
using DVLD_Full_Project.Properties;

namespace DVLD_Full_Project
{
    public partial class ctrlDriverLicenseInfo : UserControl
    {
        private int _LicenseID = -99;
        private clsLicense _License ;
        public int LicenseID
        {
            get { return _LicenseID; }
        }
        public clsLicense License
        {
            get { return _License; }
        }
        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();

        }
        public void RestAllValue()
        {
            txtClass.Text = txtName.Text = txtLicenseID.Text = txtNationalNo.Text= "???";
            txtGendor.Text = txtIssueDate.Text = txtIssueReason.Text =txtDateOfBirth.Text = "???";
            txtDriverId.Text = txtExpirationDate.Text = "???";
            txtIsActive.Text = txtDenatied.Text = "NO";
            txtNotes.Text = "No Notes";
            MainImage.ImageLocation = null;
        }
        private void _LoadPersonImage()
        {
            MainImage.Image = (_License.DriverInfo.PersonInfo.Gendor == 0) ?
              Resources.person_boy : Resources.person_girl;
            string ImagePath = _License.DriverInfo.PersonInfo.ImagePath;
            if (ImagePath!="")
            {
                if (File.Exists(ImagePath))
                {
                    MainImage.ImageLocation = ImagePath;
                }
                else
                {
                    MessageBox.Show("Image file not found: " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
        public void LoadInfo(int LicenseID)
        {
            _LicenseID = LicenseID;
            _License = clsLicense.Find(LicenseID);
            if (_License == null)
            {
                MessageBox.Show("Could not find License ID = " + _LicenseID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ;
            }

            txtLicenseID.Text = _License.LicenseID.ToString();
            txtIsActive.Text = _License.IsActive ? "Yes" : "No";
            txtDenatied.Text = _License.IsDetained ? "Yes" : "No";
            txtClass.Text = _License.LicenseClassInfo.ClassName;
            txtName.Text = _License.DriverInfo.PersonInfo.FullName;
            txtNationalNo.Text = _License.DriverInfo.PersonInfo.NationalNo.ToString();
            txtGendor.Text = _License.DriverInfo.PersonInfo.Gendor == 0? "Male" : "Female";
            txtDateOfBirth.Text = _License.DriverInfo.PersonInfo.DateOfBirth.ToShortDateString();
            txtDriverId.Text = _License.DriverID.ToString();
            txtIssueDate.Text = _License.IssueDate.ToShortDateString();
            txtExpirationDate.Text = _License.ExpirationDate.ToShortDateString();
            txtIssueReason.Text = _License.IssueReasonText;
            txtNotes.Text = _License.Notes==""?"No Notes":_License.Notes;

            _LoadPersonImage();
        }
    }
}
