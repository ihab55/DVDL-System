using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BussinessLayer
{
    public class clsTestAppointment
    {
        private enum _enMode { _enAddNew = 0, _enUpdate = 1 };
        _enMode _Mode;

        public int TestAppointmentID { set; get; }
        public clsTestType.enTestType TestTypeID { set; get; }
        public int LocalDrivingLicenseApplicationID { set; get; }
        public DateTime AppointmentDate { set; get; }
        public float PaidFees { set; get; }
        public int CreatedByUserID { set; get; }
        public bool IsLocked { set; get; }

        public int RetakeTestApplicationID { set; get; }
        public clsApplication RetakeTestAppInfo { set; get; }

        public int TestID
        {
            get { return _GetTestID(); }

        }
        public clsTestAppointment()
        {
            this.TestAppointmentID = -99;
            this.TestTypeID = clsTestType.enTestType.VisionTest;
            this.LocalDrivingLicenseApplicationID = -99;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -99;
            this.IsLocked = false;
            this.RetakeTestApplicationID = -99;
            _Mode = _enMode._enAddNew;
        }
        private clsTestAppointment(int TestAppointmentID, clsTestType.enTestType TestTypeID, 
int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, float PaidFees, int CreatedByUserID, bool IsLocked
            ,int RetakeTestApplicationID)
        {
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;
            this.RetakeTestApplicationID = RetakeTestApplicationID;
            this.RetakeTestAppInfo = clsApplication.FindBaseApplication(RetakeTestApplicationID);
            _Mode = _enMode._enUpdate;
        }
        private bool _AddNewTestAppointment()
        {
         this.TestAppointmentID = clsTestAppointmentData.AddNewTestAppointment(
                (int)this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.RetakeTestApplicationID);
            return (this.TestAppointmentID != -99);
        }
        private bool _UpdateTestAppointment()
        {
           return clsTestAppointmentData.UpdateTestAppointment(this.TestAppointmentID, 
                (int)this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked, this.RetakeTestApplicationID);
        }
        public static clsTestAppointment Find(int TestAppointmentID)
        {
            int TestTypeID =0;
            int LocalDrivingLicenseApplicationID = -99, CreatedByUserID = -99 , RetakeTestApplicationID = -99;
            DateTime AppointmentDate = DateTime.MinValue;
            float PaidFees = -99;
            bool IsLocked = false;
            if (clsTestAppointmentData.GetTestAppointmentInfoByID(TestAppointmentID, ref TestTypeID,ref LocalDrivingLicenseApplicationID, 
                ref AppointmentDate, ref PaidFees,ref CreatedByUserID,ref IsLocked,ref RetakeTestApplicationID))
            {
                return new clsTestAppointment(TestAppointmentID,(clsTestType.enTestType)TestTypeID,LocalDrivingLicenseApplicationID,
                AppointmentDate,PaidFees , CreatedByUserID, IsLocked, RetakeTestApplicationID);
            }
            return null;
        }
        public static clsTestAppointment GetLastTestAppointment(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID )
        {
            int TestAppointmentID = -99, CreatedByUserID = -99, RetakeTestApplicationID = -99;
            DateTime AppointmentDate = DateTime.MinValue;
            float PaidFees = -99;
            bool IsLocked = false;
            if (clsTestAppointmentData.GetLastTestAppointment(LocalDrivingLicenseApplicationID,(int) TestTypeID,ref TestAppointmentID, 
                ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID))
            {
                return new clsTestAppointment(TestAppointmentID, (clsTestType.enTestType)TestTypeID, LocalDrivingLicenseApplicationID,
                AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);
            }
            return null;
        }
        public static DataTable GetApplicationTestAppointmentsPerTestType(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsTestAppointmentData.GetApplicationTestAppointmentsPerTestType(LocalDrivingLicenseApplicationID,(byte) TestTypeID);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case _enMode._enAddNew:
                    if (_AddNewTestAppointment())
                    {
                        _Mode = _enMode._enUpdate;
                        return true;
                    }
                    return false;
                case _enMode._enUpdate:
                    return _UpdateTestAppointment();
            }
            return false;
        }
        private int _GetTestID()
        {
            return clsTestAppointmentData.GetTestID(this.TestAppointmentID);
        }
    }
}
