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
    public partial class frmRenewLocalDrivingLicenseApplication : Form
    {
        private int _NewLicenseID = -99;
        public frmRenewLocalDrivingLicenseApplication()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRenewLicenseApp_Load(object sender, EventArgs e)
        {
            ucNewInternational1.txtLicenseIDFocus();
            txtAppDate.Text = DateTime.Now.ToShortDateString();
            txtIssueDate.Text = txtAppDate.Text;

            txtCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            txtlAppFees.Text = clsApplicationTypes.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).Fees.ToString();

        }
        private void RestAllValue() {
            ucNewInternational1.RestAllValue();
            txtID_RenewLicense.Text = txtLicenseFees.Text = txtID_IntApp.Text = "???";
            txtOldLicenseID.Text = txtExpirationDate.Text = txtTotalFees.Text ="???";
        }
        private void ucNewInternational1_OnLicenseSelected(int obj)
        {
            if (ucNewInternational1.LicenseInfo == null)
            {
                RestAllValue();
                return;
            }
            lnkShowHistory.Enabled = true;
            txtOldLicenseID.Text = ucNewInternational1.LicenseID.ToString();
            txtExpirationDate.Text = DateTime.Now.AddYears(ucNewInternational1.LicenseInfo.LicenseClassInfo.DefaultValidityLength).ToShortDateString();
            txtLicenseFees.Text = ucNewInternational1.LicenseInfo.LicenseClassInfo.ClassFees.ToString();
            txtTotalFees.Text = (Convert.ToSingle(txtlAppFees.Text) + Convert.ToSingle(txtLicenseFees.Text)).ToString();
            txtNotes.Text = ucNewInternational1.LicenseInfo.Notes;
            if (!ucNewInternational1.LicenseInfo.IsLicenseExpired())
            {
                MessageBox.Show("Selected License is not yet expiared, it will expire on: " + (ucNewInternational1.LicenseInfo.ExpirationDate).ToShortDateString() 
                    , "License Not Expired", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }
            if (ucNewInternational1.LicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License is Detained, you cannot renew it until it is released", "License Detained", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            if (!ucNewInternational1.LicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not active, you cannot renew it", "License Active", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            btnSave.Enabled = true;
        }

        private void lnkShowHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory historyForm = new frmShowPersonLicenseHistory(ucNewInternational1.LicenseInfo.DriverInfo.PersonID);
            historyForm.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            if (MessageBox.Show("Are you sure you want to Renew the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            clsLicense _NewLicense = ucNewInternational1.LicenseInfo.RenewLicense(
                txtNotes.Text.Trim(),clsGlobal.CurrentUser.UserID);
            if (_NewLicense == null)
            {
                MessageBox.Show("Faild to Renew the License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            txtID_IntApp.Text = _NewLicense.ApplicationID.ToString();
            txtID_RenewLicense.Text = _NewLicense.LicenseID.ToString();
            MessageBox.Show("Licensed Renewed Successfully with ID=" + _NewLicense.LicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ucNewInternational1.Enabled = false;
            lnkShowInfo.Enabled = true;
            _NewLicenseID = _NewLicense.LicenseID;
        }

        private void lnkShowInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_NewLicenseID == -99)
            {
                MessageBox.Show("No License has been issued yet.", "No License", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmShowLicenseInfo showLicesnse = new frmShowLicenseInfo(_NewLicenseID);
            showLicesnse.ShowDialog();
        }
    }
}
