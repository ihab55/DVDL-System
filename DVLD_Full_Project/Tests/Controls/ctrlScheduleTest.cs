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

namespace DVLD_Full_Project.Tests
{
    public partial class ctrlScheduleTest : UserControl
    {
        public enum enMode { AddNew = 0, Update = 1 }
        private enMode _enMode ;
        
        public enum enCreationMode { FirstTimeSchedule = 0, RetakeTestSchedule = 1 };
        private enCreationMode _enCreationMode = enCreationMode.FirstTimeSchedule;

        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        private clsTestAppointment _TestAppointment;

        public clsTestType.enTestType TestTypeID
        {
            get { return _TestTypeID; }
            set { _TestTypeID = value;
                switch (_TestTypeID) {
                    case clsTestType.enTestType.VisionTest:
                        pbTestType.Image = Properties.Resources.eye_72;
                        gbTestType.Text = "Vision Test";
                        break;
                    case clsTestType.enTestType.WrittenTest:
                        pbTestType.Image = Properties.Resources.exam72;
                        gbTestType.Text = "Written Test";
                        break;
                    case clsTestType.enTestType.StreetTest:
                        pbTestType.Image = Properties.Resources.car_check72;
                        gbTestType.Text = "Street Test";
                        break;
                } 
            }
        }
        public ctrlScheduleTest()
        {
            InitializeComponent();
        }
        public void LoadInfo (int LocalDrivingLicenseApplicationID, int TestAppointmentID = -99)
        {
            _enMode = (TestAppointmentID == -99) ? enMode.AddNew : enMode.Update;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);
            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Invalid Local Driving License Application ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Enabled = false;
                return;
            }
             _enCreationMode =_LocalDrivingLicenseApplication.DoesAttendTestType(_TestTypeID)?enCreationMode.RetakeTestSchedule : enCreationMode.FirstTimeSchedule;
            if (_enCreationMode == enCreationMode.RetakeTestSchedule)
            {
                txtRetakeFess.Text = clsApplicationTypes.Find((int)clsApplication.enApplicationType.RetakeTest).Fees.ToString();
                gbRetakeTest.Enabled = true;
                lblTitle.Text = "Schedule Retake Test";
            }
            else
            {
                gbRetakeTest.Enabled = false;
                lblTitle.Text = "Schedule Test";
            }

            lblLocalDrivingLicenseAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblDrivingClass.Text = _LocalDrivingLicenseApplication.licenseClassInfo.ClassName;
            lblFullName.Text = _LocalDrivingLicenseApplication.FullName;

            lblTrial.Text = _LocalDrivingLicenseApplication.TotalTrialsPerTest(_TestTypeID).ToString();

            if (_enMode == enMode.AddNew)
            {
                lblFees.Text = clsTestType.Find(_TestTypeID).TestFees.ToString();
                dtpTestDate.MinDate = DateTime.Now;
                _TestAppointment = new clsTestAppointment();
            }
            else
            {
                _TestAppointment = clsTestAppointment.Find(TestAppointmentID);
                _LoadTestAppointmentData();
            }
            txtTotalFees.Text = (Convert.ToSingle(lblFees.Text) + Convert.ToSingle(txtRetakeFess.Text)).ToString();

            if (!_HandleActiveTestAppointmentConstraint()) return;

            if(!_HandleAppointmentLockedConstraint()) return;
            if (!_HandleAppointmentLockedConstraint()) return;
        }
        private bool _HandlePrviousTestConstraint()
        {
            switch (_TestTypeID)
            {
                case clsTestType.enTestType.VisionTest:
                    return true; // Vision test can be scheduled any time
                case clsTestType.enTestType.WrittenTest:
                    if (!_LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.VisionTest))
                    {
                        lblUserMessage.Text = "Cannot Sechule, Vision Test should be passed first";
                        lblUserMessage.Visible = true;
                        btnSave.Enabled = false;
                        dtpTestDate.Enabled = false;
                        return false;
                    }
                    break;
                case clsTestType.enTestType.StreetTest:
                    if (!_LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.WrittenTest))
                    {
                        lblUserMessage.Text = "Cannot Sechule, Vision Test should be passed first";
                        lblUserMessage.Visible = true;
                        btnSave.Enabled = false;
                        dtpTestDate.Enabled = false;
                        return false;
                    }
                    break;
            }
            return true;
        }
        private bool _HandleAppointmentLockedConstraint()
        {
            if (this._TestAppointment.IsLocked)
            {
                lblUserMessage.Visible = true;
                lblUserMessage.Text = "Person already sat for the test, appointment loacked.";
                dtpTestDate.Enabled = false;
                btnSave.Enabled = false;
                return false;
            }
            return true;
        }
        private bool _HandleActiveTestAppointmentConstraint()
        {
            if (_enMode==enMode.AddNew && _LocalDrivingLicenseApplication.IsThereAnActiveScheduledTest(TestTypeID))
            {
                lblUserMessage.Text = "Person Already have an active appointment for this test";
                btnSave.Enabled = false;
                dtpTestDate.Enabled = false;
                return false;
            }
            return true;
        }
        private void _LoadTestAppointmentData()
        {
            if (_TestAppointment == null)
            {
                MessageBox.Show("Invalid Test Appointment ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Enabled = false;
                return;
            }
            lblFees.Text = _TestAppointment.PaidFees.ToString();
            dtpTestDate.MinDate = (DateTime.Compare(DateTime.Now,_TestAppointment.AppointmentDate)<0)?DateTime.Now:_TestAppointment.AppointmentDate;
            dtpTestDate.Value = _TestAppointment.AppointmentDate;
            if(_TestAppointment.RetakeTestApplicationID != -99)
            {
                txtRetakeFess.Text = _TestAppointment.RetakeTestAppInfo.PaidFees.ToString();
                gbRetakeTest.Enabled = true;
                lblTitle.Text = "Schedule Retake Test";
                RetakeID.Text = _TestAppointment.RetakeTestApplicationID.ToString();
            }
            else
            {
                txtRetakeFess.Text = "0";
                RetakeID.Text = "N/A";
            }
        }
        private bool _HandleRetakeApplication()
        {
            if (_enCreationMode == enCreationMode.RetakeTestSchedule && _enMode == enMode.AddNew)
            {
                clsApplication RetakeApp = new clsApplication();

                RetakeApp.ApplicantPersonID = _LocalDrivingLicenseApplication.ApplicantPersonID;
                RetakeApp.ApplicationDate = DateTime.Now;
                RetakeApp.ApplicationTypeID = clsApplication.enApplicationType.RetakeTest;
                RetakeApp.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
                RetakeApp.LastStatusDate = DateTime.Now;
                RetakeApp.PaidFees = clsApplicationTypes.Find((int)clsApplication.enApplicationType.RetakeTest).Fees;
                RetakeApp.CreatedByUserID = clsGlobal.CurrentUser.UserID;

                if (!RetakeApp.Save())
                {
                    _TestAppointment.RetakeTestApplicationID = -99;
                    MessageBox.Show("Faild to Create application", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                _TestAppointment.RetakeTestApplicationID = RetakeApp.ApplicationID;
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_HandleRetakeApplication()) return;

            _TestAppointment.TestTypeID = _TestTypeID;
            _TestAppointment.LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;
            _TestAppointment.AppointmentDate = dtpTestDate.Value;
            _TestAppointment.PaidFees = Convert.ToSingle(lblFees.Text);
            _TestAppointment.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (_TestAppointment.Save())
            {
                _enMode = enMode.Update;
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
