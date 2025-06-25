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
    public partial class frmRelaseDetainLicense : Form
    {
        private clsDetainedLicenses detainedLicenses;
        public frmRelaseDetainLicense()
        {
            InitializeComponent();
        }
        public frmRelaseDetainLicense(int DetainID)
        {
            InitializeComponent();
            detainedLicenses = clsDetainedLicenses.Find(DetainID);

            detainedLicenses.ReleaseApplicationInfo = new clsApplication();
            detainedLicenses.ReleaseApplicationInfo.AppTypeInfo = clsApplicationTypes.Find(5);
            detainedLicenses.ReleaseApplicationInfo.Status = clsApplication.enStatus.Completed;
            detainedLicenses.ReleaseApplicationInfo.PersonInfo = detainedLicenses.LicenseInfo.DriverInfo.PersonInfo;
            detainedLicenses.ReleasedByUserInfo = detainedLicenses.ReleaseApplicationInfo.CreatedbyInfo = clsCurrentUsersInfo.CurrentUser;
            detainedLicenses.ReleaseDate = DateTime.Now;

            ucNewInternational1.LoadDataByLicenseID(detainedLicenses.LicenseInfo.LicenseID);
            txtDetainID.Text = detainedLicenses.DetainedLicenseID.ToString();
            txtDetainDate.Text = detainedLicenses.DetainDate.ToString("MM/MMM/yyyy");
            txtFineFees.Text = detainedLicenses.FineFees.ToString();
            txtLicenseID.Text = detainedLicenses.LicenseInfo.LicenseID.ToString();
            txtAppFees.Text = detainedLicenses.ReleaseApplicationInfo.AppTypeInfo.Fees.ToString();
            txtTotalFees.Text = (detainedLicenses.FineFees + detainedLicenses.ReleaseApplicationInfo.AppTypeInfo.Fees).ToString();
            txtCreatedBy.Text = clsCurrentUsersInfo.CurrentUser.UserName;
            btnSave.Enabled = lnkShowHistory.Enabled = lnkShowInfo.Enabled = true;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void lnkShowInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicesnse showLicesnse = new frmShowLicesnse(detainedLicenses.LicenseInfo);
            showLicesnse.ShowDialog();
        }
        private void lnkShowHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory licenseHistory = new frmLicenseHistory(detainedLicenses.LicenseInfo.DriverInfo.PersonInfo.Id);
            licenseHistory.ShowDialog();
        }
        private void ucNewInternational1_OnLicenseSelected(int obj)
        {
            if (clsDetainedLicenses.IsDetained(obj))
            {
                btnSave.Enabled = lnkShowHistory.Enabled = lnkShowInfo.Enabled = true;
                detainedLicenses = clsDetainedLicenses.FindByLicenseID(obj);

                detainedLicenses.ReleaseApplicationInfo = new clsApplication();
                detainedLicenses.ReleaseApplicationInfo.AppTypeInfo = clsApplicationTypes.Find(5);
                detainedLicenses.ReleaseApplicationInfo.Status = clsApplication.enStatus.Completed;
                detainedLicenses.ReleaseApplicationInfo.PersonInfo = detainedLicenses.LicenseInfo.DriverInfo.PersonInfo;
                detainedLicenses.ReleasedByUserInfo = detainedLicenses.ReleaseApplicationInfo.CreatedbyInfo = clsCurrentUsersInfo.CurrentUser;
                detainedLicenses.ReleaseDate = DateTime.Now;

                txtDetainID.Text = detainedLicenses.DetainedLicenseID.ToString();
                txtDetainDate.Text = detainedLicenses.DetainDate.ToString("MM/MMM/yyyy");
                txtFineFees.Text = detainedLicenses.FineFees.ToString();
                txtLicenseID.Text = detainedLicenses.LicenseInfo.LicenseID.ToString();
                txtAppFees.Text = detainedLicenses.ReleaseApplicationInfo.AppTypeInfo.Fees.ToString();
                txtTotalFees.Text = (detainedLicenses.FineFees + detainedLicenses.ReleaseApplicationInfo.AppTypeInfo.Fees).ToString();
                txtCreatedBy.Text = clsCurrentUsersInfo.CurrentUser.UserName;
            }
            else
            {
                btnSave.Enabled = lnkShowHistory.Enabled = lnkShowInfo.Enabled = false;
                MessageBox.Show("License is not deatined","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            detainedLicenses.IsReleased = true;
            if (MessageBox.Show("Do you want to relase.", "Cheak", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                if (detainedLicenses.ReleaseApplicationInfo.Save() && detainedLicenses.Save())
                {
                    txtID_DApp.Text = detainedLicenses.ReleaseApplicationInfo.ID.ToString();
                    btnSave.Enabled = false;
                    ucNewInternational1.EnableFilter(false);
                    MessageBox.Show("Detained License Released Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to release detained license", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
    }
}
