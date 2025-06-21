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
        public int TestAppointmentID;
        public clsTestType TestTypeInfo;
        public clsLocalDrivingLicenseApp LocalAppInfo;
        public DateTime AppoitmentDate;
        public int PaidFees;
        public clsUser CreatedByInfo;
        public bool IsLocked ;
        private enum _enMode {_enAddNew=0, _enUpdate=1};
        _enMode _Mode;
        public static DataTable GetTestTimeByLocalIDAndTestID(int localAppId, int testTypeId)
        {
            return clsTestAppointmentData.GetTestTimeByLocalIDAndTestID(localAppId, testTypeId);
        }
        public clsTestAppointment()
        {
            TestAppointmentID = -99;
            //TestTypeinfo
            //LocalAppInfo
            AppoitmentDate = DateTime.Now;
            PaidFees = -99;
            //CreatedByInfo
            IsLocked = false;
            _Mode = _enMode._enAddNew;
        }
        private clsTestAppointment(int id, int testtypeId, int LocalAppid,DateTime AppoDate,
            int fees,int userid,bool islock)
        {
            TestAppointmentID = id;
            TestTypeInfo = clsTestType.Find(testtypeId);
            LocalAppInfo = clsLocalDrivingLicenseApp.GetAppByID(LocalAppid);
            AppoitmentDate = AppoDate;
            PaidFees = fees;
            CreatedByInfo = clsUser.Find(userid);
            IsLocked = islock;
            _Mode = _enMode._enUpdate;
        }
        private bool _AddNewTestAppotment()
        {
            this.PaidFees = this.TestTypeInfo.TestFees;
            this.TestAppointmentID = clsTestAppointmentData.AddNewTestAppointment(TestTypeInfo.TestTypeId, this.LocalAppInfo.LocalDrivingLicenseApplicationID,
                this.AppoitmentDate, this.PaidFees, this.CreatedByInfo.Id, this.IsLocked);
            return (this.TestAppointmentID != -99);
        }
        public static clsTestAppointment Find(int id)
        {
            int testTypeID =-99;
            int localAppID = -99;
            DateTime appoitmentDate = DateTime.MinValue;
            decimal paidFees = -99;
            int createdByID = -99;
            bool isLocked = false;
            if (clsTestAppointmentData.GetAppoById(id, ref testTypeID,ref localAppID, 
                ref appoitmentDate, ref paidFees,ref createdByID,ref isLocked))
            {
                return new clsTestAppointment(id,testTypeID,localAppID,
                appoitmentDate,(int)paidFees , createdByID, isLocked);
            }
            return null;
        }
        private bool _UpdateTestAppointment()
        {
            return clsTestAppointmentData.UpdateTestAppointment(TestAppointmentID, 
         TestTypeInfo.TestTypeId,LocalAppInfo.LocalDrivingLicenseApplicationID, 
         AppoitmentDate,PaidFees,CreatedByInfo.Id,IsLocked);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case _enMode._enAddNew:
                    if (_AddNewTestAppotment())
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
        public static bool IsExists(int LocId)
        {
            return clsTestAppointmentData.IsExists(LocId);
        }
    }
}
