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
    public partial class frmTakeTest : Form
    {
        private clsTestTaken testTaken ;
        public frmTakeTest(int AppoTest, bool Islocked = false)
        {
            InitializeComponent();
            
            if (Islocked)
            {
                testTaken = clsTestTaken.Find(AppoTest);
                _EnableForm();
            }
            else
            {
                testTaken = new clsTestTaken();
                testTaken.TestAppointmentInfo = clsTestAppointment.Find(AppoTest);
                txtTestID.Text = "Not Taken Yet";
                testTaken.CreatedByInfo = clsCurrentUsersInfo.CurrentUser;
                testTaken.TestResualt = true;
            }
        }

        private void _EnableForm()
        {
            rbFail.Checked = testTaken.TestResualt?false: true;
            btnSave.Enabled = txtNotes.Enabled = rbPass.Enabled = rbFail.Enabled = false;
            txtTestID.Text = testTaken.TestID.ToString();
            labMeesage.Visible = true;
            txtNotes.Text = testTaken.Notes;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            testTaken.TestAppointmentInfo.IsLocked = true;
            testTaken.Notes = txtNotes.Text.Trim();
            clsApplication appInfo = clsApplication.FindAppByPersonID(testTaken.TestAppointmentInfo.LocalAppInfo.ApplicationInfo.PersonInfo.Id);
            if (appInfo != null)
            {
                appInfo.Status = clsApplication.enStatus.Completed;
                appInfo.StatusDate = DateTime.Now;
                appInfo.CompleteApp();
            }
            if (testTaken.Save())
            {
                testTaken.TestAppointmentInfo.Save();
                MessageBox.Show("Test Take Succsesfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error in Saving Test", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            txtID.Text = testTaken.TestAppointmentInfo.LocalAppInfo.LocalDrivingLicenseApplicationID.ToString();
            txtClass.Text = testTaken.TestAppointmentInfo.LocalAppInfo.licenseClassInfo.ClassName;
            txtName.Text = testTaken.TestAppointmentInfo.LocalAppInfo.ApplicationInfo.PersonInfo.FullName();
            txtTrail.Text = clsTestTaken.GetNumOfTrailByAppID(testTaken.TestAppointmentInfo.LocalAppInfo.LocalDrivingLicenseApplicationID,testTaken.TestAppointmentInfo.TestTypeInfo.TestTypeId).ToString();
            txtDate.Text = testTaken.TestAppointmentInfo.AppoitmentDate.ToString("MM/MMM/yyyy");
            txtFees.Text = testTaken.TestAppointmentInfo.PaidFees.ToString();
            switch (testTaken.TestAppointmentInfo.TestTypeInfo.TestTypeId)
            {
                case 2: // Written Test
                    pictureBox1.Image = Properties.Resources.exam72;
                    break;
                case 3: // Street Test
                    pictureBox1.Image = Properties.Resources.car_check72;
                    break;
            }
        }

        private void rbPass_CheckedChanged(object sender, EventArgs e)
        {
           testTaken.TestResualt = rbPass.Checked;
        }
    }
}
