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
    public partial class frmDetainLicense : Form
    {
        private clsDetainedLicenses _clsDetainedLicenses = new clsDetainedLicenses();
        public frmDetainLicense()
        {
            InitializeComponent();
        }

        private void lnkShowHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory frmLicenseHistory = new frmLicenseHistory(_clsDetainedLicenses.LicenseInfo.DriverInfo.PersonInfo.Id);
            frmLicenseHistory.ShowDialog();
        }
        private void lnkShowInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicesnse frmShowLicesnse = new frmShowLicesnse(_clsDetainedLicenses.LicenseInfo);
            frmShowLicesnse.ShowDialog();
        }
        private void ucNewInternational1_OnLicenseSelected(int obj)
        {
            _clsDetainedLicenses.LicenseInfo = clsLicense.Find(obj);
            txtLicenseID.Text = _clsDetainedLicenses.LicenseInfo.LicenseID.ToString();
            if (_clsDetainedLicenses.LicenseInfo.IsActive)
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
                MessageBox.Show("This license is not active.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            lnkShowHistory.Enabled = true;
        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            _clsDetainedLicenses.DetainDate = DateTime.Now;
            _clsDetainedLicenses.CreatedByUserInfo = clsCurrentUsersInfo.CurrentUser;

            txtAppDate.Text = _clsDetainedLicenses.DetainDate.ToString("MM/MMM/YYYY");
            txtCreatedBy.Text = _clsDetainedLicenses.CreatedByUserInfo.UserName;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_clsDetainedLicenses.IsDetained())
            {
                if (string.IsNullOrEmpty(txtFine.Text))
                {
                    MessageBox.Show("Please Enter Fine Fees", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                _clsDetainedLicenses.FineFees = int.Parse(txtFine.Text);
                if ( _clsDetainedLicenses.Save())
                {
                    ucNewInternational1.EnableFilter(false);
                    txtFine.Enabled = false;
                    MessageBox.Show("License detained  successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to detain the license. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("This license is already detained.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            btnSave.Enabled = false;
            lnkShowInfo.Enabled = true;
            txtDetainID.Text = _clsDetainedLicenses.DetainedLicenseID.ToString();
        }

        private void txtFine_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)||char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
    }
}
