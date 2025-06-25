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
    public partial class frmRenewLicenseApp : Form
    {
        private clsLicense _NewclsLicense = new clsLicense();
        private clsLicense OldLicense;


        public frmRenewLicenseApp()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRenewLicenseApp_Load(object sender, EventArgs e)
        {
            _NewclsLicense.ApplicationInfo = new clsApplication();
            _NewclsLicense.ApplicationInfo.AppTypeInfo = clsApplicationTypes.Find(2); // Assuming 2 is the ID for renewal application type
            _NewclsLicense.ApplicationInfo.Status = clsApplication.enStatus.Completed;
            _NewclsLicense.ApplicationInfo.Fees = _NewclsLicense.ApplicationInfo.AppTypeInfo.Fees;
            _NewclsLicense.CreatedByUserInfo = _NewclsLicense.ApplicationInfo.CreatedbyInfo = clsCurrentUsersInfo.CurrentUser;

            _NewclsLicense.IssueReason = 4; // Assuming 4 is the code for renewal reason
            txtAppDate.Text = _NewclsLicense.ApplicationInfo.Date.ToString("MM/MMM/yyyy");
            txtlAppFees.Text = _NewclsLicense.ApplicationInfo.Fees.ToString();
            txtIssueDate.Text = _NewclsLicense.IssueDate.ToString("MM/MMM/yyyy");
            txtCreatedBy.Text = _NewclsLicense.CreatedByUserInfo.UserName;
        }

        private void ucNewInternational1_OnLicenseSelected(int obj)
        {
            OldLicense = clsLicense.Find(obj);
            _NewclsLicense.DriverInfo = OldLicense.DriverInfo;
            _NewclsLicense.ApplicationInfo.PersonInfo = OldLicense.ApplicationInfo.PersonInfo;
            _NewclsLicense.LicenseClassInfo = OldLicense.LicenseClassInfo;
            _NewclsLicense.ExpriationDate = _NewclsLicense.IssueDate.AddYears(_NewclsLicense.LicenseClassInfo.DefaultValidityLength);
            _NewclsLicense.PaidFees = _NewclsLicense.LicenseClassInfo.Fees;

            txtOldLicenseID.Text = OldLicense.LicenseID.ToString();
            txtExpirationDate.Text = _NewclsLicense.ExpriationDate.ToString("MM/MMM/yyyy");
            txtLicenseFees.Text = (_NewclsLicense.LicenseClassInfo.Fees+ _NewclsLicense.ApplicationInfo.Fees).ToString();
            txtTotalFees.Text = _NewclsLicense.PaidFees.ToString();
            if (OldLicense.IsActive)
            {
                if (OldLicense.ExpriationDate >= DateTime.Now)
                {
                    MessageBox.Show("The selected license is valid and can be renewed.", "Valid License", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSave.Enabled = false;
                }
                else
                {
                    btnSave.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("The selected license is not active and cannot be renewed.", "Inactive License", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnSave.Enabled = false;
            }
            lnkShowHistory.Enabled = true;
        }

        private void lnkShowHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory historyForm = new frmLicenseHistory(_NewclsLicense.DriverInfo.PersonInfo.Id);
            historyForm.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            OldLicense.IsActive = false; // Deactivate the old license
            _NewclsLicense.Note = txtNotes.Text.Trim();
            if (MessageBox.Show("Do you want to Renew?", "Quesion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (_NewclsLicense.ApplicationInfo.Save() && OldLicense.Save() && _NewclsLicense.Save())
                {
                    MessageBox.Show($"Renew License {_NewclsLicense.LicenseID} Succes.", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lnkShowInfo.Enabled = true;
                    ucNewInternational1.EnableFilter(false);
                    txtID_IntApp.Text = _NewclsLicense.ApplicationInfo.ID.ToString();
                    txtID_RenewLicense.Text = _NewclsLicense.LicenseID.ToString();
                }
                else
                {
                    MessageBox.Show("Failed to renew the license. Please check the details and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            btnSave.Enabled = false;
        }

        private void lnkShowInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicesnse showLicesnse = new frmShowLicesnse(_NewclsLicense);
            showLicesnse.ShowDialog();
        }
    }
}
