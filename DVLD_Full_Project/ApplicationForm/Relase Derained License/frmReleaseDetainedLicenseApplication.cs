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
    public partial class frmReleaseDetainedLicenseApplication : Form
    {
        public frmReleaseDetainedLicenseApplication()
        {
            InitializeComponent();
        }
        public frmReleaseDetainedLicenseApplication(int LicenseID)
        {
            InitializeComponent();
            ucNewInternational1.Enabled = false;
            ucNewInternational1.LoadLicenseInfo(LicenseID);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void lnkShowInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          frmShowLicenseInfo showLicesnse = new frmShowLicenseInfo(ucNewInternational1.LicenseID);
          showLicesnse.ShowDialog();
        }
        private void lnkShowHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           frmShowPersonLicenseHistory licenseHistory = new frmShowPersonLicenseHistory(ucNewInternational1.LicenseInfo.DriverInfo.PersonID);
           licenseHistory.ShowDialog();
        }
 private void _RestAllValues()
        {
            txtDetainID.Text = txtDetainDate.Text = txtLicenseID.Text = "???";
            txtFineFees.Text = txtTotalFees.Text = "???"; 
            btnSave.Enabled = lnkShowHistory.Enabled = lnkShowInfo.Enabled = false;
            ucNewInternational1.RestAllValue();
        }
        private void ucNewInternational1_OnLicenseSelected(int obj)
        {
            if(ucNewInternational1.LicenseInfo == null)
            {
                _RestAllValues();
                return;
            }
            lnkShowHistory.Enabled = lnkShowInfo.Enabled = true;
            if (!ucNewInternational1.LicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License i is not detained, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtDetainID.Text = ucNewInternational1.LicenseInfo.DetainedInfo.DetainID.ToString();
            txtDetainDate.Text = ucNewInternational1.LicenseInfo.DetainedInfo.DetainDate.ToShortDateString();
            txtLicenseID.Text = ucNewInternational1.LicenseID.ToString();
            txtFineFees.Text = ucNewInternational1.LicenseInfo.DetainedInfo.FineFees.ToString();
            txtTotalFees.Text = (Convert.ToSingle(txtFineFees.Text) + Convert.ToSingle(txtAppFees.Text)).ToString();
            
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to release this detained  license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            if (!ucNewInternational1.LicenseInfo.ReleaseDetainedLicense(clsGlobal.CurrentUser.UserID))
            {
                MessageBox.Show("Failed to release detained license, please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } 
            txtID_DApp.Text = ucNewInternational1.LicenseInfo.DetainedInfo.ReleaseApplicationID.ToString();
            btnSave.Enabled = ucNewInternational1.FilterEnabled = false;
        }

        private void frmReleaseDetainedLicenseApplication_Load(object sender, EventArgs e)
        {
            ucNewInternational1.txtLicenseIDFocus();
            txtAppFees.Text = clsApplicationTypes.Find((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense).Fees.ToString();
            txtCreatedBy.Text = clsGlobal.CurrentUser.UserName;
        }
    }
}
