using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BussinessLayer
{
    public class clsTestTaken
    {
        private enum _enMode { _enAddNew = 0, _enUpdate = 1 };
        _enMode _Mode;
        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public clsTestAppointment TestAppointmentInfo { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }
        public clsTestTaken()
        {
            this.TestID = -99;
            this.TestAppointmentID = -99;
            this.TestResult = false;
            this.Notes = "";
            this.CreatedByUserID = -99;
            _Mode = _enMode._enAddNew;
        }
        private clsTestTaken(int TestID, int TestAppointmentID, bool TestResult, string Notes,
            int CreatedByid)
        {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            TestAppointmentInfo = clsTestAppointment.Find(TestAppointmentID);
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;
            _Mode = _enMode._enUpdate;
        }
        private bool _AddNewTestTaken()
        {
            this.TestID = clsTestTakenData.AddNewTest(this.TestAppointmentID, this.TestResult, 
                this.Notes, this.CreatedByUserID);
            return (this.TestID != -99);
        }
        private bool _UpdateTestTaken()
        {
            return clsTestTakenData.UpdateTest(this.TestID,this.TestAppointmentID,this.TestResult, 
                this.Notes, this.CreatedByUserID);
        }
        public static clsTestTaken Find(int TestID)
        {
            int TestAppointmentID = -99, CreatedByid = -99;
            bool TestResult = false;
            string Notes = "";
            if (clsTestTakenData.GetTestInfoByID(TestID,ref TestAppointmentID,ref TestResult,
                ref Notes, ref CreatedByid))
            {
                return new clsTestTaken(TestID,TestAppointmentID,TestResult,Notes,CreatedByid);
            }
            return null;
        }
        public static clsTestTaken FindLastTestPerPersonAndLicenseClass
            (int PersonID, int LicenseClassID, clsTestType.enTestType TestTypeID)
        {
            int TestAppointmentID = -99, CreatedByid = -99, TestID = -99;
            bool TestResult = false;
            string Notes = "";
            if (clsTestTakenData.GetLastTestByPersonAndTestTypeAndLicenseClass(
                PersonID,LicenseClassID,(int) TestTypeID,ref TestID, ref TestAppointmentID, 
                ref TestResult,ref Notes, ref CreatedByid))
            {
                return new clsTestTaken(TestID, TestAppointmentID, TestResult, Notes, CreatedByid);
            }
            return null;
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case _enMode._enAddNew:
                    if (_AddNewTestTaken())
                    {
                        _Mode = _enMode._enUpdate;
                        return true;
                    }
                    return false;
                case _enMode._enUpdate:
                    return _UpdateTestTaken();
            }
            return false;
        }
        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            return clsTestTakenData.GetPassedTestCount(LocalDrivingLicenseApplicationID);
        }
        public static bool PassedAllTests(int LocalDrivingLicenseApplicationID)
        {
            return GetPassedTestCount(LocalDrivingLicenseApplicationID)==3;
        }
    }
}
