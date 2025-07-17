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
using static BussinessLayer.clsTestType;

namespace DVLD_Full_Project.Tests.Controls
{
    public partial class ctrlSecheduledTest : UserControl
    {
        private clsTestType.enTestType _TestTypeID = enTestType.VisionTest;
        public clsTestType.enTestType TestTypeID
        {
            get { return _TestTypeID; }
            set
            {
                _TestTypeID = value;
                switch (_TestTypeID)
                {
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
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplicationInfo;
        private clsTestAppointment _TestAppointmentInfo;
        private int _TestID=-99;
        public int TestID { get {return _TestID; } }
        public ctrlSecheduledTest()
        {
            InitializeComponent();
        }

        public void LoadInfo(int TestAppointment)
        {
            this._TestAppointmentInfo = clsTestAppointment.Find(TestAppointment);
            this._TestID = this._TestAppointmentInfo.TestID;
            this._LocalDrivingLicenseApplicationInfo = 
                clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID
                (this._TestAppointmentInfo.LocalDrivingLicenseApplicationID);
            lblLocalDrivingLicenseAppID.Text = _LocalDrivingLicenseApplicationInfo.LocalDrivingLicenseApplicationID.ToString();
            lblDrivingClass.Text = _LocalDrivingLicenseApplicationInfo.licenseClassInfo.ClassName;
            lblFullName.Text = _LocalDrivingLicenseApplicationInfo.FullName;
            lblTrial.Text = _LocalDrivingLicenseApplicationInfo.TotalTrialsPerTest(_TestTypeID).ToString();
            lblDate.Text = _TestAppointmentInfo.AppointmentDate.ToShortDateString();
            lblFees.Text = _TestAppointmentInfo.PaidFees.ToString();
            lblTestID.Text = (_TestID == -99) ? "Not Taken Yet" : _TestID.ToString();
        }
    }
}
