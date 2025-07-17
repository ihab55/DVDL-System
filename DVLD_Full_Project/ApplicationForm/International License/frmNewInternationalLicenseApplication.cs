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
        private int _InternationalLicenseID = -99;
        public frmNewInternationalLicenseApplication()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void RestAllValue()
        {
            ucNewInternational1.RestAllValue();
            txtID_IntApp.Text = txtID_IntLicense.Text = txtLocalLicenseID.Text = "???";
            lnkShowHistory.Enabled = lnkShowInfo.Enabled = btnSave.Enabled = false;
        }
        private void ucNewInternational1_OnLicenseSelected(int obj)
        {
            if(ucNewInternational1.LicenseInfo == null)
            {
                RestAllValue();
                return;
            }
            lnkShowHistory.Enabled = true;
            txtLocalLicenseID.Text = ucNewInternational1.LicenseID.ToString();
            if (ucNewInternational1.LicenseInfo.LicenseClass != 3)
            {
                MessageBox.Show("Selected License should be Class 3, select another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int ActiveInternationalLicense = clsInternationalLicense.GetActiveInternationalLicenseIDByDriverID(ucNewInternational1.LicenseInfo.DriverID);
            if (ActiveInternationalLicense != -99)
            {
                MessageBox.Show("Person already have an active international license with ID = " + ActiveInternationalLicense.ToString(), "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }
            btnSave.Enabled = true;
        }

        private void lnkShowHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(ucNewInternational1.LicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void frmNewInternational_Load(object sender, EventArgs e)
        {
            txtAppDate.Text = DateTime.Now.ToShortDateString();
            txtIssueDate.Text = txtAppDate.Text;
            txtExpirationDate.Text = DateTime.Now.AddYears(1).ToShortDateString();
            txtFees.Text = clsApplicationTypes.Find((int)clsApplication.enApplicationType.NewInternationalLicense).Fees.ToString();
            txtCreatedBy.Text = clsGlobal.CurrentUser.UserName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to issue the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            clsInternationalLicense InternationalLicense = new clsInternationalLicense();
            //fill base application
            InternationalLicense.ApplicantPersonID = ucNewInternational1.LicenseInfo.DriverInfo.PersonID;
            InternationalLicense.ApplicationDate = DateTime.Now;
            InternationalLicense.ApplicationTypeID = clsApplication.enApplicationType.NewInternationalLicense;
            InternationalLicense.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            InternationalLicense.LastStatusDate = DateTime.Now;
            InternationalLicense.PaidFees = Convert.ToSingle(txtFees.Text);
            InternationalLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            //fill international license info
            InternationalLicense.DriverID = ucNewInternational1.LicenseInfo.DriverID;
            InternationalLicense.IssuedUsingLocalLicenseID = ucNewInternational1.LicenseID;
            InternationalLicense.IssueDate = DateTime.Now;
            InternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
            InternationalLicense.IsActive = true;
            InternationalLicense.LicenseCreatedByUserID = clsGlobal.CurrentUser.UserID;
            if (!InternationalLicense.Save())
            {
                MessageBox.Show("Faild to Issue International License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } 
            _InternationalLicenseID = InternationalLicense.InternationalLicenseID;

            txtID_IntApp.Text = InternationalLicense.ApplicationID.ToString();
            txtID_IntLicense.Text = InternationalLicense.InternationalLicenseID.ToString();

            MessageBox.Show("International License Issued Successfully with ID=" + InternationalLicense.InternationalLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnSave.Enabled = ucNewInternational1.FilterEnabled = false;
            lnkShowInfo.Enabled = true;

        }

        private void lnkShowInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmInternationalLicenseInfo frm = new frmInternationalLicenseInfo(_InternationalLicenseID);
            frm.ShowDialog();
        }
    }
}
