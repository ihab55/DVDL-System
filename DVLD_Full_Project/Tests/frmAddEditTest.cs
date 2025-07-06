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
    public partial class frmAddEditTest : Form
    {
        clsTestAppointment testAppointment;
        clsApplication Retakeapplication = null;
        public frmAddEditTest(int _LocaIDORAppointmentID, int enMode, bool LookeFlage = false, bool FlageUpdate = false)
        {
            InitializeComponent();
            if (FlageUpdate)
            {
                testAppointment = clsTestAppointment.Find(_LocaIDORAppointmentID);
                dateTimePicker1.MinDate = testAppointment.AppoitmentDate;
                dateTimePicker1.Value = testAppointment.AppoitmentDate;
            }
            else
            {
                dateTimePicker1.MinDate = DateTime.Now;
                testAppointment = new clsTestAppointment();
                testAppointment.LocalAppInfo = clsLocalDrivingLicenseApp.GetAppByID(_LocaIDORAppointmentID);
                testAppointment.TestTypeInfo = clsTestType.Find(enMode);
                testAppointment.CreatedByInfo = clsGlobal.CurrentUser;
            }
            switch(enMode)
            {
                case 2: // Written Test
                    pictureBox1.Image = Properties.Resources.exam72;
                    break;
                case 3: // Street Test
                    pictureBox1.Image = Properties.Resources.car_check72;
                    break;
            }
            if (LookeFlage)
            {
                btnSave.Enabled = dateTimePicker1.Enabled = false;
                labMeesage.Visible = true;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmEditVison_Load(object sender, EventArgs e)
        {
            int NumOfTrail = clsTestTaken.GetNumOfTrailByAppID(testAppointment.LocalAppInfo.LocalDrivingLicenseApplicationID, testAppointment.TestTypeInfo.TestTypeId);
            txtID.Text = testAppointment.LocalAppInfo.LocalDrivingLicenseApplicationID.ToString();
            txtClass.Text = testAppointment.LocalAppInfo.licenseClassInfo.ClassName;
            txtName.Text = testAppointment.LocalAppInfo.ApplicationInfo.PersonInfo.FullName;
            txtTrail.Text = NumOfTrail.ToString();
            txtFees.Text = testAppointment.TestTypeInfo.TestFees.ToString();
            dateTimePicker1.MaxDate = DateTime.Now.AddYears(5);
            if (NumOfTrail > 0)
            {
                groupBox2.Enabled = true;
                Retakeapplication  = clsApplication.FindAppByPersonID(testAppointment.LocalAppInfo.ApplicationInfo.PersonInfo.PersonID);
                if (Retakeapplication == null)
                {
                    Retakeapplication = new clsApplication();
                    Retakeapplication.AppTypeInfo = clsApplicationTypes.Find(9);
                    Retakeapplication.Date = DateTime.Now;
                    Retakeapplication.CreatedbyInfo = clsGlobal.CurrentUser;
                    Retakeapplication.PersonInfo = testAppointment.LocalAppInfo.ApplicationInfo.PersonInfo;
                    Retakeapplication.Status = clsApplication.enStatus.New;
                    Retakeapplication.Fees = Retakeapplication.AppTypeInfo.Fees + testAppointment.TestTypeInfo.TestFees;
                }
                else { RetakeID.Text = Retakeapplication.ID.ToString(); }
                txtRetakeFess.Text = Retakeapplication.AppTypeInfo.Fees.ToString();
                    txtTotalFees.Text = Retakeapplication.Fees.ToString();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            testAppointment.AppoitmentDate = dateTimePicker1.Value;
            if (Retakeapplication != null)
            {
                Retakeapplication.StatusDate = DateTime.Now;
                Retakeapplication.Save();       
            }
            if (testAppointment.Save())
            {
                MessageBox.Show("Done", "Test time is Register", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error","Something went error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
