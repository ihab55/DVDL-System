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
        public int TestID { get; set; }
        public clsTestAppointment TestAppointmentInfo { get; set; }
        public bool TestResualt { get; set; }
        public string Notes { get; set; }
        public clsUser CreatedByInfo { get; set; }
        private enum _enMode { _enAddNew = 0, _enUpdate = 1 };
        _enMode _Mode;
        public clsTestTaken()
        {
            TestID = -99;
            //TestAppointmentInfo
            TestResualt = false;
            Notes = "";
            //CreatedByInfo
            _Mode = _enMode._enAddNew;
        }
        private clsTestTaken(int testID, int TestAppoId, bool testResualt, string notes,
            int CreatedByid)
        {
            TestID = testID;
            TestAppointmentInfo = clsTestAppointment.Find(TestAppoId);
            TestResualt = testResualt;
            Notes = notes;
            CreatedByInfo = clsUser.Find(CreatedByid);
            _Mode = _enMode._enUpdate;
        }
        private bool _AddNewTestTaken()
        {
            this.TestID = clsTestTakenData.AddNewTestTaken(TestAppointmentInfo.TestAppointmentID, TestResualt, Notes, CreatedByInfo.Id);
            return (this.TestID != -99);
        }
        public static clsTestTaken Find(int TestAppo)
        {
            int id = -99;
            bool testResualt = false;
            string notes = "";
            int createdByid = -99;
            if (clsTestTakenData.GetTestTakenByAppoId(ref id, TestAppo, ref testResualt,
                ref notes, ref createdByid))
            {
                return new clsTestTaken(id, TestAppo, testResualt,
                notes, createdByid);
            }
            return null;
        }
        private bool _UpdateTestTaken()
        {
            return clsTestTakenData.UpdateTestTaken(this.TestID,
                TestAppointmentInfo.TestAppointmentID,
                TestResualt, Notes, CreatedByInfo.Id);
        }
        int GetPassTest()
        {
            return clsTestTakenData.GetTestPassByAppID(this.TestAppointmentInfo.LocalAppInfo.LocalDrivingLicenseApplicationID);
        }
        public static int GetPassTestByAppID(int LocalappID)
        {
            return clsTestTakenData.GetTestPassByAppID(LocalappID);
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
        public static int GetNumOfTrailByAppID(int LclappID, int TestId)
        {
            return clsTestTakenData.GetNumOfTrailByAppID(LclappID, TestId);
        }
    }
}
