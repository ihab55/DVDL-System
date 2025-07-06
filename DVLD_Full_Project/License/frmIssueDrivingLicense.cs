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
    public partial class frmIssueDrivingLicense : Form
    {
        clsLocalDrivingLicenseApp LocalApp ;
        public frmIssueDrivingLicense(int LocalID)
        {
            InitializeComponent();
            ucDLAppInfo1.FillLocalAppInfo(LocalID);
            LocalApp = clsLocalDrivingLicenseApp.GetAppByID(LocalID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsDriver driver;
            if (clsDriver.IsExist(LocalApp.ApplicationInfo.PersonInfo.PersonID))
            {
                driver = clsDriver.FindByPersonId(LocalApp.ApplicationInfo.PersonInfo.PersonID);
            }
            else
            {
                driver = new clsDriver();
                driver.PersonInfo = LocalApp.ApplicationInfo.PersonInfo;
                driver.CreatedByInfo = clsGlobal.CurrentUser;
                driver.CreatedDate = DateTime.Now;
            }
            if (driver.Save())
            {
                clsLicense license = new clsLicense();
                license.ApplicationInfo = LocalApp.ApplicationInfo;
                license.DriverInfo = driver;
                license.LicenseClassInfo = LocalApp.licenseClassInfo;
                license.IssueDate = DateTime.Now;
                license.ExpriationDate = DateTime.Now.AddYears(LocalApp.licenseClassInfo.DefaultValidityLength);
                license.Note = txtNotes.Text.Trim();
                license.PaidFees = LocalApp.licenseClassInfo.Fees;
                license.IsActive = true;
                license.IssueReason = 1;
                license.CreatedByUserInfo = clsGlobal.CurrentUser;
                LocalApp.ApplicationInfo.Status = clsApplication.enStatus.Completed;
                if (license.Save() && LocalApp.ApplicationInfo.CompleteApp())
                {
                    MessageBox.Show($"License {license.LicenseID} Issued Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to issue license. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
