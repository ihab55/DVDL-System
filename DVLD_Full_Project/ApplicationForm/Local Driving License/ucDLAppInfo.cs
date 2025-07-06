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
    public partial class ucDLAppInfo : UserControl
    {
        public ucDLAppInfo()
        {
            InitializeComponent();
        }
        public void FillLocalAppInfo(int LocalappID)
        {
            clsLocalDrivingLicenseApp app = clsLocalDrivingLicenseApp.GetAppByID(LocalappID);
            if (app != null)
            {
                txtID.Text = app.LocalDrivingLicenseApplicationID.ToString();
                txtClass.Text = app.licenseClassInfo.ClassName;
                txtPassed.Text = clsTestTaken.GetPassTestByAppID(LocalappID).ToString() + "/3";
                ucApplicationInfo1.FillApplication(app.ApplicationInfo.ID);
            }
        }

    }
}
