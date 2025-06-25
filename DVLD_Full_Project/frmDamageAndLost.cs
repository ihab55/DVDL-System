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
    public partial class frmDamageAndLost : Form
    {
        private clsLicense _NewclsLicense = new clsLicense();
        private clsLicense OldLicense;
        public frmDamageAndLost()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ucNewInternational1_OnLicenseSelected(int obj)
        {
            OldLicense = clsLicense.Find(obj);
            _NewclsLicense.ApplicationInfo.PersonInfo = OldLicense.ApplicationInfo.PersonInfo;

            _NewclsLicense.DriverInfo = OldLicense.DriverInfo;
            _NewclsLicense.LicenseClassInfo = OldLicense.LicenseClassInfo;
            _NewclsLicense.ExpriationDate = _NewclsLicense.IssueDate.AddYears(_NewclsLicense.LicenseClassInfo.DefaultValidityLength);
            _NewclsLicense.PaidFees = _NewclsLicense.LicenseClassInfo.Fees;
            _NewclsLicense.IssueReason = 3;

            if (OldLicense.IsActive)
            {
                groupBox1.Enabled = btnSave.Enabled = true;
            }
            else
            {
                MessageBox.Show("The selected license is not active and cannot be Replacement.", "Inactive License", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                groupBox1.Enabled = btnSave.Enabled = false;
            }
            txtOldLicenseID.Text = OldLicense.LicenseID.ToString();
            lnkShowHistory.Enabled = true;
        }
        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            _NewclsLicense.ApplicationInfo.AppTypeInfo = clsApplicationTypes.Find(rbDamagedLicense.Checked?4:3);
            _NewclsLicense.ApplicationInfo.Fees = _NewclsLicense.ApplicationInfo.AppTypeInfo.Fees;
            _NewclsLicense.IssueReason = (short)(rbDamagedLicense.Checked ? 3 : 2);
            txtFees.Text = _NewclsLicense.ApplicationInfo.Fees.ToString();
        }
        private void lnkShowHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory frm = new frmLicenseHistory(OldLicense.DriverInfo.PersonInfo.Id);
            frm.ShowDialog();
        }
        private void lnkShowInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicesnse showLicesnse = new frmShowLicesnse(_NewclsLicense);
            showLicesnse.ShowDialog();
        }
        private void frmDamageAndLost_Load(object sender, EventArgs e)
        {
            _NewclsLicense.ApplicationInfo = new clsApplication();
            _NewclsLicense.ApplicationInfo.Status = clsApplication.enStatus.Completed;
            _NewclsLicense.ApplicationInfo.AppTypeInfo = clsApplicationTypes.Find(4); // Assuming 4 is the ID for damage/
            _NewclsLicense.ApplicationInfo.Fees = _NewclsLicense.ApplicationInfo.AppTypeInfo.Fees;
            _NewclsLicense.CreatedByUserInfo = _NewclsLicense.ApplicationInfo.CreatedbyInfo = clsCurrentUsersInfo.CurrentUser;

            txtAppDate.Text = _NewclsLicense.ApplicationInfo.Date.ToString("MM/MMM/yyyy");
            txtFees.Text = _NewclsLicense.ApplicationInfo.Fees.ToString();
            txtCreatedBy.Text = _NewclsLicense.CreatedByUserInfo.UserName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            OldLicense.IsActive = false; // Deactivate the old license
            if (MessageBox.Show("Do you want to Renew?", "Quesion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (_NewclsLicense.ApplicationInfo.Save() && OldLicense.Save() && _NewclsLicense.Save())
                {
                    MessageBox.Show($"Replacment License {_NewclsLicense.LicenseID} Succes.", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lnkShowInfo.Enabled = true;
                    ucNewInternational1.EnableFilter(false);
                    btnSave.Enabled = groupBox1.Enabled = false;
                    txtID_RApp.Text = _NewclsLicense.ApplicationInfo.ID.ToString();
                    txtID_IntLicense.Text = _NewclsLicense.LicenseID.ToString();
                }
                else
                {
                    MessageBox.Show("Failed to replacment the license. Please check the details and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
