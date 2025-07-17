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
    public partial class frmListTestAppointments : Form
    {
        private int _LocalDrivingLicenseApplicationID = -99;
        private clsTestType.enTestType _TestType = clsTestType.enTestType.VisionTest;
        private DataTable _dtLicenseTestAppointments;
        public frmListTestAppointments(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestType)
        {
            InitializeComponent();
            this._LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this._TestType = TestType;
        }
        private void _LoadTestTypeImageAndTitle()
        {
            switch(_TestType)
            {
                case clsTestType.enTestType.VisionTest:
                    labHead.Text = "Vision Test Appointments";
                    pictureBox1.Image = Properties.Resources.eye_72;
                    break;
                case clsTestType.enTestType.WrittenTest:
                    labHead.Text = "Written Test Appointments";
                    pictureBox1.Image = Properties.Resources.exam72;
                    break;
                case clsTestType.enTestType.StreetTest:
                    labHead.Text = "Street Test Appointments";
                    pictureBox1.Image = Properties.Resources.car_check72;
                    break;
            }
        }
        private void frmListTestAppointments_Load(object sender, EventArgs e)
        {
            _LoadTestTypeImageAndTitle();

            ctrlDrivingLicenseApplicationInfo1.LoadApplicationInfoByLocalDrivingAppID(_LocalDrivingLicenseApplicationID);
            _dtLicenseTestAppointments = clsTestAppointment.GetApplicationTestAppointmentsPerTestType(_LocalDrivingLicenseApplicationID, _TestType);

            dgvLicenseTestAppointments.DataSource = _dtLicenseTestAppointments;
            labNum.Text = dgvLicenseTestAppointments.Rows.Count.ToString();


            dgvLicenseTestAppointments.Columns[0].HeaderText = "Appointment ID";
            dgvLicenseTestAppointments.Columns[0].Width = 150;

            dgvLicenseTestAppointments.Columns[1].HeaderText = "Appointment Date";
            dgvLicenseTestAppointments.Columns[1].Width = 200;

            dgvLicenseTestAppointments.Columns[2].HeaderText = "Paid Fees";
            dgvLicenseTestAppointments.Columns[2].Width = 150;

            dgvLicenseTestAppointments.Columns[3].HeaderText = "Is Locked";
            dgvLicenseTestAppointments.Columns[3].Width = 100;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication localDrivingLicenseApplication =
                clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);
            if (localDrivingLicenseApplication.IsThereAnActiveScheduledTest(_TestType))
            {
                MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsTestTaken LastTest = localDrivingLicenseApplication.GetLastTestPerTestType(_TestType);

            if (LastTest == null)
            {
                frmScheduleTest frm1 = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestType);
                frm1.ShowDialog();
                frmListTestAppointments_Load(null, null);
                return;
            }
            if (LastTest.TestResult == true)
            {
                MessageBox.Show("This person already passed this test before, you can only retake faild test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmScheduleTest frm2 = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestType);
            frm2.ShowDialog();
            frmListTestAppointments_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmScheduleTest editVison = new frmScheduleTest(_LocalDrivingLicenseApplicationID,_TestType,
                (int)dgvLicenseTestAppointments.CurrentRow.Cells[0].Value);
            editVison.ShowDialog();
            frmListTestAppointments_Load(null,null);
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTakeTest takeTest = new frmTakeTest((int)dgvLicenseTestAppointments.CurrentRow.Cells[0].Value, _TestType);
            takeTest.ShowDialog();
            frmListTestAppointments_Load(null,null);
        }

        
    }
}
