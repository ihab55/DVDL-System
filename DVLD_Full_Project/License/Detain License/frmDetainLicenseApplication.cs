using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinessLayer;
using DVLD_Full_Project.Global_Class;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace DVLD_Full_Project
{
    public partial class frmDetainLicenseApplication : Form
    {
        public frmDetainLicenseApplication()
        {
            InitializeComponent();
        }

        private void lnkShowHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frmLicenseHistory = new frmShowPersonLicenseHistory(ucNewInternational1.LicenseInfo.DriverInfo.PersonID);
            frmLicenseHistory.ShowDialog();
        }
        private void lnkShowInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frmShowLicesnse = new frmShowLicenseInfo(ucNewInternational1.LicenseID);
            frmShowLicesnse.ShowDialog();
        }
        private void RestAllValue()
        {
            ucNewInternational1.RestAllValue();
            txtLicenseID.Text = txtDetainID.Text = "???";
            txtFine.Text = string.Empty;
            lnkShowHistory.Enabled = lnkShowInfo.Enabled = btnSave.Enabled =false;
        }
        private void ucNewInternational1_OnLicenseSelected(int obj)
        {
            if (ucNewInternational1.LicenseInfo == null)
            {
                RestAllValue();
                return;
            }
            lnkShowHistory.Enabled = lnkShowInfo.Enabled = true;
            if (ucNewInternational1.LicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License i already detained, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!ucNewInternational1.LicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not active, choose another one.",
                    "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtFine.Focus();
            txtLicenseID.Text = ucNewInternational1.LicenseID.ToString();
            btnSave.Enabled = true;
        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {   
            txtAppDate.Text = DateTime.Now.ToShortDateString();
            txtCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            ucNewInternational1.FilterEnabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Please correct the errors before saving.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Are you sure you want to detain this license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            int _DetainID = ucNewInternational1.LicenseInfo.Detain(Convert.ToSingle(txtFine.Text.Trim()), clsGlobal.CurrentUser.UserID);
            if (_DetainID == -99)
            {
                MessageBox.Show("Faild to Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            labDetainID.Text = _DetainID.ToString();
            MessageBox.Show("License Detained Successfully with ID=" + _DetainID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnSave.Enabled = false;
            ucNewInternational1.FilterEnabled = false;
            txtFine.Enabled = false;
        }

        private void txtFine_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFine.Text.Trim()))
            {e.Cancel = true;
                errorProvider1.SetError(txtFine, "Please enter the fine amount.");
                return;
            }
            if (!clsValidatoin.IsNumber(txtFine.Text))
            {e.Cancel = true;   
                errorProvider1.SetError(txtFine, "Please enter a valid number for the fine amount.");
                return;
            }

            errorProvider1.SetError(txtFine, null);
        }
    }
}
