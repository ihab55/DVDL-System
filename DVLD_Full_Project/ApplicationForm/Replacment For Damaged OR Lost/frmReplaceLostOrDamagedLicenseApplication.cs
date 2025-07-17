using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinessLayer;

namespace DVLD_Full_Project
{
    public partial class frmReplaceLostOrDamagedLicenseApplication : Form
    {
        private int _NewLicenseID = -99;
        private clsApplication.enApplicationType _ApplicationType;
        public frmReplaceLostOrDamagedLicenseApplication()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void RestAllValue()
        {
            ucNewInternational1.txtLicenseIDFocus();
            ucNewInternational1.RestAllValue();
            txtAppDate.Text =  txtCreatedBy.Text = "???";
            txtOldLicenseID.Text  = "???";
            lnkShowInfo.Enabled = false;
            lnkShowHistory.Enabled = false;
            btnSave.Enabled = false;
            _NewLicenseID = -99;
        }
        private void ucNewInternational1_OnLicenseSelected(int obj)
        {
            if(ucNewInternational1.LicenseInfo == null)
            {
                RestAllValue();
                return;
            }
            lnkShowHistory.Enabled = true;
            txtOldLicenseID.Text = obj.ToString();
            if (!ucNewInternational1.LicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                RestAllValue();
                return;
            }
            btnSave.Enabled = true;
            groupBox1.Enabled = true;
        }
        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            _ApplicationType = clsApplication.enApplicationType.ReplaceDamagedDrivingLicense;
            labHead.Text = "Replacement for Damaged License";
            txtFees.Text = clsApplicationTypes.Find((int)_ApplicationType).Fees.ToString();
        }
        private void rbLostLicemse_CheckedChanged(object sender, EventArgs e)
        {
            _ApplicationType = clsApplication.enApplicationType.ReplaceLostDrivingLicense;
            labHead.Text = "Replacement for Lost License";
            txtFees.Text = clsApplicationTypes.Find((int)_ApplicationType).Fees.ToString();
        }
        private void lnkShowHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ucNewInternational1.LicenseInfo == null )
            {
                MessageBox.Show("Please select a valid license to view its history.", "Invalid License", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(ucNewInternational1.LicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }
        private void lnkShowInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_NewLicenseID == -99)
            {
                MessageBox.Show("Please select a valid license to view its information.", "Invalid License", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmShowLicenseInfo showLicesnse = new frmShowLicenseInfo(_NewLicenseID);
            showLicesnse.ShowDialog();
        }
        private void frmDamageAndLost_Load(object sender, EventArgs e)
        {
            txtAppDate.Text = DateTime.Now.ToShortDateString();
            txtCreatedBy.Text = clsGlobal.CurrentUser.UserName;

            rbDamagedLicense_CheckedChanged(null,null);
            ucNewInternational1.txtLicenseIDFocus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           if (MessageBox.Show("Are you sure you want to Issue a Replacement for the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            clsLicense _NewLicense = ucNewInternational1.LicenseInfo.ReplaceLostOrDamagedLicense
                (_ApplicationType,ucNewInternational1.LicenseInfo.Notes,clsGlobal.CurrentUser.UserID);
            if (_NewLicense == null)
            {
                MessageBox.Show("Faild to Issue a replacemnet for this  License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _NewLicenseID = _NewLicense.LicenseID;
            txtID_RApp.Text = _NewLicense.ApplicationID.ToString();
            txtID_IntLicense.Text = _NewLicense.LicenseID.ToString();
            MessageBox.Show("Licensed Replaced Successfully with ID=" + _NewLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lnkShowInfo.Enabled = true;
            btnSave.Enabled = false;
            ucNewInternational1.FilterEnabled = false;
            groupBox1.Enabled = false;
        }


    }
}
