using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BussinessLayer
{
    public class clsInternationalLicense : clsApplication
    {
        private enum _enMode
        {
            _enAdd = 0, _enUpdate = 1
        }
        private _enMode _Mode;
        public int InternationalLicenseID { get; set; }
        public int DriverID { set; get; }
        public clsDriver DriverInfo { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int LicenseCreatedByUserID { get; set; }

        public clsInternationalLicense()
        {
            this.ApplicationTypeID = clsApplication.enApplicationType.NewInternationalLicense;

            this.InternationalLicenseID = -99;
            this.DriverID = -99;
            this.IssuedUsingLocalLicenseID = -99;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;

            _Mode = _enMode._enAdd;
        }
        private clsInternationalLicense(int ApplicationID, int ApplicantPersonID,
            DateTime ApplicationDate,
             enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
             float PaidFees, int CreatedByUserID,
             int InternationalLicenseID, int DriverID, int IssuedUsingLocalLicenseID,
            DateTime IssueDate, DateTime ExpirationDate, bool IsActive,int
            LicenseCreatedByUserID)
        {
            base.ApplicationID = ApplicationID;
            base.ApplicantPersonID = ApplicantPersonID;
            base.ApplicationDate = ApplicationDate;
            base.ApplicationTypeID = clsApplication.enApplicationType.NewInternationalLicense;
            base.ApplicationStatus = ApplicationStatus;
            base.LastStatusDate = LastStatusDate;
            base.PaidFees = PaidFees;
            base.CreatedByUserID = CreatedByUserID;

            this.InternationalLicenseID = InternationalLicenseID;
            this.DriverID = DriverID;
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.LicenseCreatedByUserID = LicenseCreatedByUserID;

            this.DriverInfo = clsDriver.FindByDriverID(DriverID);

            _Mode = _enMode._enUpdate;
        }

        private bool _AddNewInternationalLicense()
        {
            this.InternationalLicenseID = clsInternationalLicenseData.AddNewInternationalLicense(
                this.ApplicationID, this.DriverID,this.IssuedUsingLocalLicenseID,
                this.IssueDate, this.ExpirationDate, this.IsActive, this.LicenseCreatedByUserID);
            return (InternationalLicenseID != -99);
        }
        private bool _UpdateInternationalLicense()
        {
            return clsInternationalLicenseData.UpdateInternationalLicense(
                this.InternationalLicenseID, this.ApplicationID, this.DriverID, 
                this.IssuedUsingLocalLicenseID,this.IssueDate, this.ExpirationDate,
                this.IsActive, this.LicenseCreatedByUserID);
        }
        public static clsInternationalLicense Find(int InternationalLicenseID)
        {
            int ApplicationID = -99,DriverID = -99, IssuedUsingLocalLicenseID = -99;
            DateTime IssueDate = DateTime.MinValue, ExpirationDate = DateTime.MinValue;
            bool IsActive = false;
            int LicenseCreatedByUserID = -99;
            if (clsInternationalLicenseData.GetInternationalLicenseInfoByID
                (InternationalLicenseID, ref ApplicationID, ref DriverID, ref IssuedUsingLocalLicenseID,
                ref IssueDate, ref ExpirationDate, ref IsActive, ref LicenseCreatedByUserID))
            {
                clsApplication Application = clsApplication.FindBaseApplication(ApplicationID);
                return new clsInternationalLicense(ApplicationID,Application.ApplicationID
                    ,Application.ApplicationDate,Application.ApplicationStatus,Application.LastStatusDate
                    ,Application.PaidFees,Application.CreatedByUserID,InternationalLicenseID,DriverID
                    , IssuedUsingLocalLicenseID,
                    IssueDate, ExpirationDate, IsActive, LicenseCreatedByUserID);
            }
            return null;
        }
        public static DataTable GetAllIntLicense()
        {
            return clsInternationalLicenseData.GetAllInternationalLicenses();
        }
        public bool Save()
        {
            base._Mode = (clsApplication._enMode)this._Mode;
            if(!base.Save())
            {
                return false;
            }
            switch (_Mode)
            {
                case _enMode._enAdd:
                    if ( this._AddNewInternationalLicense())
                    {
                        _Mode = _enMode._enUpdate;
                        return true;
                    }
                    break;
                case _enMode._enUpdate:
                    return this._UpdateInternationalLicense();
            }
            return false;
        }
        public static DataTable GetDriverInternationalLicenses(int DriverID)
        {
            return clsInternationalLicenseData.GetDriverInternationalLicenses(DriverID);
        }
        public static int GetActiveInternationalLicenseIDByDriverID(int DriverID)
        {
            return clsInternationalLicenseData.GetActiveInternationalLicenseIDByDriverID(DriverID);
        }

    }
}
