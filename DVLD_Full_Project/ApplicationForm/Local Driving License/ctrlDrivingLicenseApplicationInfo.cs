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
    public partial class ctrlDrivingLicenseApplicationInfo : UserControl
    {
        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        private int _LicenseID;
        public int LocalDrivingLicenseApplicationID
        {
            get
            {
                if (_LocalDrivingLicenseApplication != null)
                {
                    return _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;
                }
                return -99;
            }
        }
        public ctrlDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }
        private void _FillLocalDrivingLicenseApplicationInfo()
        {
            //Trick for license ; 
            _LicenseID = _LocalDrivingLicenseApplication.GetActiveLicenseID();
            linkLabel1.Enabled = (_LicenseID != -99);

            txtID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            txtClass.Text = _LocalDrivingLicenseApplication.licenseClassInfo.ClassName;
            txtPassed.Text = _LocalDrivingLicenseApplication.GetPassedTestCount().ToString() + "/3";
            ucApplicationInfo1.LoadApplicationInfo(_LocalDrivingLicenseApplication.ApplicationID);
        }
        public void LoadApplicationInfoByLocalDrivingAppID(int LocalDrivingLicenseApplicationID)
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);
            if (_LocalDrivingLicenseApplication == null)
            {
                _ResetLocalDrivingLicenseApplicationInfo();


                MessageBox.Show("No Application with ApplicationID = " + this.LocalDrivingLicenseApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillLocalDrivingLicenseApplicationInfo();
        }
        private void _ResetLocalDrivingLicenseApplicationInfo()
        {
            _LocalDrivingLicenseApplication = null;
            ucApplicationInfo1.ResetApplicationInfo(); 
            txtID.Text = "???";
            txtClass.Text = "???";
            txtPassed.Text = "???";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_LicenseID);
            frm.ShowDialog();
        }
    }
}
