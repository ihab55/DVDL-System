using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
namespace BussinessLayer
{
    public class clsLicense
    {
        public enum enMode
        {
            AddNew = 0, Update = 1
        }
        public enMode Mode;

        public enum enIssueReason { FirstTime = 1, Renew = 2, DamagedReplacement = 3, LostReplacement = 4 };

        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public clsDriver DriverInfo { get; set; }
        public int LicenseClass { get; set; }
        public clsLicenseClass LicenseClassInfo { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public float PaidFees { get; set; }
        public bool IsActive { get; set; }
        public enIssueReason IssueReason { get; set; }
        public int CreatedByUserID { get; set; }
        public string IssueReasonText
        {
            get
            {
                switch (IssueReason)
                {
                    case enIssueReason.FirstTime: return "First Time";
                    case enIssueReason.Renew: return "Renew";
                    case enIssueReason.DamagedReplacement: return "Replacement for Damaged";
                    case enIssueReason.LostReplacement: return "Replacement for Lost";
                    default: return "Unknown Reason";
                }
            }
        }
        public bool IsDetained
        {
            get { return clsDetainedLicenses.IsLicenseDetained(this.LicenseID); }
        }
        public clsDetainedLicenses DetainedInfo { get;  }
        public int Detain (float FineFees, int CreatedByUserID)
        {
            clsDetainedLicenses DetainedLicenses = new clsDetainedLicenses();
            DetainedLicenses.LicenseID = this.LicenseID;
            DetainedLicenses.DetainDate = DateTime.Now;
            DetainedLicenses.FineFees = FineFees;
            DetainedLicenses.CreatedByUserID = CreatedByUserID;
            if (!DetainedLicenses.Save())
            {
                return -99;
            }
            return DetainedLicenses.DetainID;
        }
        public clsLicense()
        {
            this.LicenseID = -99;
            this.ApplicationID = -99;
            this.DriverID = -99;
            this.LicenseClass = -99;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now.AddYears(10);
            this.Notes = string.Empty;
            this.PaidFees = -99;
            this.IsActive = true;
            this.IssueReason = enIssueReason.FirstTime;
            this.CreatedByUserID = -99;

            this.Mode = enMode.AddNew;
        }
        private clsLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClass,
            DateTime IssueDate, DateTime ExpirationDate, string Notes, float PaidFees, bool IsActive,
            enIssueReason IssueReason, int CreatedByUserID)
        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClass = LicenseClass;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;

            this.DriverInfo = clsDriver.FindByDriverID(DriverID);
            this.LicenseClassInfo = clsLicenseClass.Find(LicenseClass);
            this.DetainedInfo = clsDetainedLicenses.FindByLicenseID(LicenseID);

            this.Mode = enMode.AddNew;
        }
        private bool _AddNewLicense()
        {
            this.LicenseID = clsLicenseData.AddLicense(this.ApplicationID, this.DriverID
                , this.LicenseClass, this.IssueDate, this.ExpirationDate,
                this.Notes, this.PaidFees, this.IsActive, (byte)this.IssueReason, this.CreatedByUserID);
            return (this.LicenseID != -99);
        }
        private bool _UpdateLicense()
        {
            return clsLicenseData.UpdateLicense(this.LicenseID, this.ApplicationID, this.DriverID,
                this.LicenseClass, this.IssueDate, this.ExpirationDate, this.Notes,
                this.PaidFees, this.IsActive, (byte)this.IssueReason, this.CreatedByUserID);
        }
        public static clsLicense Find(int LicenseID)
        {
            int ApplicationID = -99;
            int DriverID = -99;
            int LicenseClass = -99;
            DateTime IssueDate = DateTime.MinValue;
            DateTime ExpirationDate = DateTime.MinValue;
            string Notes = "";
            float PaidFees = -99;
            bool IsActive = false;
            byte IssueReason = 0;
            int CreatedByUserID = -99;
            if (clsLicenseData.GetLicenseInfoByID(LicenseID, ref ApplicationID, ref DriverID,
                ref LicenseClass, ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees,
                ref IsActive, ref IssueReason, ref CreatedByUserID))
            {
                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate
                , Notes, PaidFees, IsActive, (enIssueReason)IssueReason, CreatedByUserID);
            }
            return null;
        }
        public bool Save()
        {
            switch (Mode)
            {
                case (enMode.AddNew):
                    if (_AddNewLicense())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    break;
                case (enMode.Update):
                    return _UpdateLicense();
            }
            return false;
        }
        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {

            return clsLicenseData.GetActiveLicenseIDByPersonID(PersonID, LicenseClassID);

        }
        public static bool IsLicenseExistByPersonID(int PersonID, int LicenseClassID)
        {
            return (GetActiveLicenseIDByPersonID(PersonID, LicenseClassID) != -99);
        }
        public static DataTable GetLocalDriverLicenses(int DriverID)
        {
            return clsLicenseData.GetDriverLicenses(DriverID);
        }
        public bool IsLicenseExpired()
        {
            return (this.ExpirationDate < DateTime.Now);
        }
        public bool DeactivateCurrentLicense()
        {
            return clsLicenseData.DeActivateLicense(this.LicenseID);
        }
        public clsLicense RenewLicense(string Notes, int CreatedByUserID)
        {
            return _CreateNewLicense(clsApplication.enApplicationType.RenewDrivingLicense, Notes, CreatedByUserID);
        }
        private clsLicense _CreateNewLicense(clsApplication.enApplicationType ApplicationType
            , string Notes, int CreatedByUserID)
        {
            clsApplication NewApplication = new clsApplication();

            NewApplication.ApplicantPersonID = this.DriverInfo.PersonID;
            NewApplication.ApplicationDate = DateTime.Now;
            NewApplication.ApplicationTypeID = ApplicationType;
            NewApplication.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            NewApplication.LastStatusDate = DateTime.Now;
            NewApplication.PaidFees = clsApplicationTypes.Find((int)ApplicationType).Fees;
            NewApplication.CreatedByUserID = CreatedByUserID;

            if (!NewApplication.Save()) return null;
            clsLicense NewLicense = new clsLicense();
            NewLicense.ApplicationID = NewApplication.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClass = this.LicenseClass;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = DateTime.Now.AddYears(this.LicenseClassInfo.DefaultValidityLength);
            NewLicense.Notes = Notes;
            NewLicense.PaidFees = this.LicenseClassInfo.ClassFees;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = (ApplicationType == clsApplication.enApplicationType.RenewDrivingLicense) ?
                enIssueReason.Renew : (ApplicationType == clsApplication.enApplicationType.ReplaceDamagedDrivingLicense)
                ? enIssueReason.DamagedReplacement : enIssueReason.LostReplacement;
            NewLicense.CreatedByUserID = CreatedByUserID;
            if (!NewLicense.Save())
            {
                return null;
            }
            this.DeactivateCurrentLicense();
            return NewLicense;
        }
        public bool ReleaseDetainedLicense(int ReleasedByUserID)
        {
            clsApplication _NewApplication = new clsApplication();
            _NewApplication.ApplicantPersonID = this.DriverInfo.PersonID;
            _NewApplication.ApplicationDate = DateTime.Now;
            _NewApplication.ApplicationTypeID = clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense;
            _NewApplication.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            _NewApplication.LastStatusDate = DateTime.Now;
            _NewApplication.PaidFees = clsApplicationTypes.Find((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense).Fees;
            _NewApplication.CreatedByUserID = ReleasedByUserID;

            if (!_NewApplication.Save()) return false;

            this.DetainedInfo.IsReleased = true;
            this.DetainedInfo.ReleaseApplicationID = _NewApplication.ApplicationID;
            this.DetainedInfo.ReleasedByUserID = ReleasedByUserID;
            return this.DetainedInfo.ReleaseDetainedLicense();
        }
        public clsLicense ReplaceLostOrDamagedLicense(clsApplication.enApplicationType ApplicationType, string Notes, int CreatedByUserID)
        {
            return _CreateNewLicense(ApplicationType, Notes, CreatedByUserID);
        }
    }
}
