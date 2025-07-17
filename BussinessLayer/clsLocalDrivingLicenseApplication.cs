using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using static BussinessLayer.clsTestType;

namespace BussinessLayer
{
    public class clsLocalDrivingLicenseApplication : clsApplication
    {
        #region   Property
        private enum _enMode { _enAddNew = 0, _enUpdate = 1 }
        _enMode _Mode;
        public int LocalDrivingLicenseApplicationID { get; set; }
        public int LicenseClassID { get; set; }
        public clsLicenseClass licenseClassInfo;
        public string FullName
        {
            get
            {
                return base.PersonInfo.FullName;
            }
        }
        #endregion
        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return DataAccessLayer.clsLocalDrivingLicenseAppData.GetAllLocalDrivingLicenseApplications();
        }
        public clsLocalDrivingLicenseApplication()
        {
            LocalDrivingLicenseApplicationID = -99;
            LicenseClassID = -99;

            _Mode =  _enMode._enAddNew;
        }
        private clsLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID, int ApplicationID
            , int ApplicantPersonID, DateTime ApplicationDate,
          enApplicationType ApplicationTypeID, enApplicationStatus ApplicationStatus
           , DateTime LastStatusDate, float PaidFees, int CreatedByUserID, int LicenseClassID)
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.PersonInfo = clsPerson.Find(ApplicantPersonID);
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.LicenseClassID = LicenseClassID;
            licenseClassInfo = clsLicenseClass.Find(LicenseClassID);

            _Mode =_enMode._enUpdate;
        }
        private bool _AddNewLocalDrivingLicenseApplication()
        {
            this.LocalDrivingLicenseApplicationID =
          clsLocalDrivingLicenseAppData.AddNewLocalDrivingLicenseApp(this.ApplicationID,this.LicenseClassID);
            return (this.LocalDrivingLicenseApplicationID != -99);
        }
        private bool _UpdateLocalDrivingLicenseApplication()
        {
            return clsLocalDrivingLicenseAppData.UpdateLocalDrivingLicenseApplication(this.LocalDrivingLicenseApplicationID
                ,this.ApplicationID,this.LicenseClassID);
        }
        public bool IsLicenseIssued()
        {
              return (GetActiveLicenseID() != -99);
        }
        public static clsLocalDrivingLicenseApplication FindByLocalDrivingAppLicenseID(int LocalDrivingLicenseApplicationID)
        {
            int ApplicationID = -99, LicenseClassID = -99;
            if (clsLocalDrivingLicenseAppData.GetLocalDrivingLicenseApplicationInfoByID(LocalDrivingLicenseApplicationID, ref ApplicationID, ref LicenseClassID))
            {
                clsApplication Application = clsApplication.FindBaseApplication(ApplicationID);
                return new clsLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID,
                    ApplicationID, Application.ApplicantPersonID, Application.ApplicationDate,
                    Application.ApplicationTypeID, Application.ApplicationStatus,
                    Application.LastStatusDate, Application.PaidFees, Application.CreatedByUserID,LicenseClassID);
            }
            return null;
        }
        public static clsLocalDrivingLicenseApplication FindByApplicationID(int ApplicationID)
        {
            int LocalDrivingLicenseApplicationID = -99, LicenseClassID = -99;
            if (clsLocalDrivingLicenseAppData.GetLocalDrivingLicenseApplicationInfoByApplicationID(ApplicationID, ref LocalDrivingLicenseApplicationID, ref LicenseClassID))
            {
                clsApplication Application = clsApplication.FindBaseApplication(ApplicationID);
                return new clsLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID,
                    ApplicationID, Application.ApplicantPersonID, Application.ApplicationDate,
                    Application.ApplicationTypeID, Application.ApplicationStatus,
                    Application.LastStatusDate, Application.PaidFees, Application.CreatedByUserID, LicenseClassID);
            }
            return null;
        }
        public int GetActiveLicenseID()
        {
            return clsLicense.GetActiveLicenseIDByPersonID(this.ApplicantPersonID, this.LicenseClassID);
        }
        public bool Save()  
        {
            base._Mode = (clsApplication._enMode)_Mode; // Set the mode of the base class to match this class's mode
            if (!base.Save())
            {
                return false;
            }
            switch (_Mode)
            {
                case _enMode._enUpdate:
                    {
                        return _UpdateLocalDrivingLicenseApplication();
                    }
                case _enMode._enAddNew:
                    {
                        if (_AddNewLocalDrivingLicenseApplication())
                        {
                            _Mode = _enMode._enUpdate;
                            return true;
                        }
                        return false;
                    }
            }
            return false;
        }
        public bool Delete()
        {
            bool IsLocalDrivingApplicationDeleted = false;
            bool IsBaseApplicationDeleted = false;
           
            IsLocalDrivingApplicationDeleted = clsLocalDrivingLicenseAppData.DeleteLocalDrivingLicenseApplication(this.LocalDrivingLicenseApplicationID);
            if (! IsLocalDrivingApplicationDeleted)
            {
                return false;
            }
            IsBaseApplicationDeleted = base.Delete();
            return IsBaseApplicationDeleted;
        }
        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID,clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseAppData.DoesPassTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
        public byte GetPassedTestCount()
        {
            return clsTestTaken.GetPassedTestCount(this.LocalDrivingLicenseApplicationID);
        }
        public bool DoesPassTestType(clsTestType.enTestType TestTypeID)
        {
            return DoesPassTestType(this.LocalDrivingLicenseApplicationID, TestTypeID);
        }
        public int TotalTrialsPerTest(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseAppData.TotalTrialsPerTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
        public bool IsThereAnActiveScheduledTest(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseAppData.IsThereAnActiveScheduledTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
        public bool DoesAttendTestType(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseAppData.DoesAttendTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
        public clsTestTaken GetLastTestPerTestType(clsTestType.enTestType TestTypeID)
        {
            return clsTestTaken.FindLastTestPerPersonAndLicenseClass(this.ApplicantPersonID,this.LicenseClassID,TestTypeID);
        }
        public bool PassedAllTests()
        {
            return clsTestTaken.PassedAllTests(this.LocalDrivingLicenseApplicationID);
        }
        public int IssueLicenseForTheFirtTime(string Notes, int CreatedByUserID)
        {
            clsDriver DriverInfo = clsDriver.FindByPersonID(this.ApplicantPersonID);
            if (DriverInfo == null)
            {
                DriverInfo = new clsDriver();
                DriverInfo.PersonID = this.ApplicantPersonID;
                DriverInfo.CreatedByUserID = CreatedByUserID;
                if(!DriverInfo.Save())return -99;
            }
            clsLicense License = new clsLicense();
            License.ApplicationID = this.ApplicationID;
            License.DriverID = DriverInfo.DriverID;
            License.LicenseClass = this.LicenseClassID;
            License.IssueDate = DateTime.Now;
            License.ExpirationDate = DateTime.Now.AddYears(this.licenseClassInfo.DefaultValidityLength); 
            License.Notes = Notes;
            License.PaidFees = this.PaidFees;
            License.IsActive = true;
            License.IssueReason = clsLicense.enIssueReason.FirstTime;
            License.CreatedByUserID = CreatedByUserID;
            if (License.Save())
            {
                this.SetComplete();
                return License.LicenseID;
            }
            return -99;
        }
    }
}

