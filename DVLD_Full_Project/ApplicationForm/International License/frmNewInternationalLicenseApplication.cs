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
    public partial class frmNewInternationalLicenseApplication : Form
    {
        private clsInternationalLicense internationalLicense = new clsInternationalLicense();
        public frmNewInternationalLicenseApplication()
        {
            InitializeComponent();
            ucNewInternational1.OnLicenseSelected += ucNewInternational1_OnLicenseSelected;
        }
        ~frmNewInternationalLicenseApplication()
        {
            ucNewInternational1.OnLicenseSelected -= ucNewInternational1_OnLicenseSelected;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ucNewInternational1_OnLicenseSelected(int obj)
        {
            internationalLicense.IssuedUsingLocalLicenseInfo = clsLicense.Find(obj);
            internationalLicense.IsActive = internationalLicense.IssuedUsingLocalLicenseInfo.IsActive;
            txtLocalLicenseID.Text = obj.ToString();
            internationalLicense.DriverInfo = internationalLicense.IssuedUsingLocalLicenseInfo.DriverInfo;
            btnSave.Enabled =lnkShowHistory.Enabled = true;
            internationalLicense.ApplicationInfo.PersonInfo = internationalLicense.DriverInfo.PersonInfo;
        }

        private void lnkShowHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory frm = new frmLicenseHistory(internationalLicense.DriverInfo.PersonInfo.PersonID);
            frm.ShowDialog();
        }

        private void frmNewInternational_Load(object sender, EventArgs e)
        {
            txtAppDate.Text = internationalLicense.ApplicationInfo.Date.ToString("MM/MMM/yyyy");
            txtFees.Text = internationalLicense.ApplicationInfo.Fees.ToString();
            txtIssueDate.Text = internationalLicense.IssueDate.ToString("MM/MMM/yyyy");
            txtExpirationDate.Text = internationalLicense.ExpirationDate.ToString("MM/MMM/yyyy");
            internationalLicense.CreatedByUserInfo = internationalLicense.ApplicationInfo.CreatedbyInfo = clsGlobal.CurrentUser;
            txtCreatedBy.Text = clsGlobal.CurrentUser.UserName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!clsInternationalLicense.IsExistsByLocalLicense(internationalLicense.IssuedUsingLocalLicenseInfo.LicenseID))
            {
                if (clsLicense.IsExistsOrdinary(internationalLicense.IssuedUsingLocalLicenseInfo.LicenseID))
                {
                    internationalLicense.ApplicationInfo.Status = clsApplication.enStatus.Completed;
                    if (internationalLicense.IsActive && internationalLicense.Save())
                    {
                        MessageBox.Show($"Internation ID {internationalLicense.InternationalLicenseID} Add succesfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error local License not Active.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                   MessageBox.Show("This Local License is not an Ordinary License, please select an Ordinary License.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                internationalLicense = clsInternationalLicense.FindByLocalLicense(internationalLicense.IssuedUsingLocalLicenseInfo.LicenseID);
                MessageBox.Show($"This International License already exists with ID : {internationalLicense.InternationalLicenseID}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtID_IntApp.Text = internationalLicense.ApplicationInfo.ID.ToString();
            txtID_IntLicense.Text = internationalLicense.InternationalLicenseID.ToString();
            ucNewInternational1.EnableFilter(false);
            btnSave.Enabled = false;
            lnkShowInfo.Enabled = true;
        }

        private void lnkShowInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmInternationalLicenseInfo frm = new frmInternationalLicenseInfo(internationalLicense);
            frm.ShowDialog();
        }
    }
}
