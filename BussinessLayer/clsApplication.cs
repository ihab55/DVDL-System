using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BussinessLayer
{
    public class clsApplication
    {
        #region Property
        public enum enApplicationType
        {
            NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicsense = 5, NewInternationalLicense = 6, RetakeTest = 7
        };
        protected enum _enMode { _enAddNew = 0, _enUpdate = 1 }
        public enum enApplicationStatus
        {
            New = 1,
            Cancelled = 2,
            Completed = 3
        }
        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }
        public clsPerson PersonInfo;
        public DateTime ApplicationDate { get; set; }
        public enApplicationType ApplicationTypeID { set; get; }
        public clsApplicationTypes AppTypeInfo;
        public enApplicationStatus ApplicationStatus { get; set; }
        public string StatusText
        {
            get
            {

                switch (ApplicationStatus)
                {
                    case enApplicationStatus.New:
                        return "New";
                    case enApplicationStatus.Cancelled:
                        return "Cancelled";
                    case enApplicationStatus.Completed:
                        return "Completed";
                    default:
                        return "Unknown";
                }
            }

        }
        public DateTime LastStatusDate { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUserID { set; get; }
        public clsUser CreatedbyInfo;
        protected _enMode _Mode;
        #endregion
        public clsApplication()
        {
            this.ApplicationID = -99;
            this.ApplicantPersonID = -99;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationTypeID = enApplicationType.NewDrivingLicense;
            this.ApplicationStatus = enApplicationStatus.New;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID=-99;
            this._Mode = _enMode._enAddNew;
        }
        private clsApplication(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate,
          enApplicationType ApplicationTypeID, enApplicationStatus ApplicationStatus
           ,DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.PersonInfo = clsPerson.Find(ApplicantPersonID);
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.AppTypeInfo = clsApplicationTypes.Find((int)ApplicationTypeID);
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedbyInfo = clsUser.FindByUserID(CreatedByUserID);

            _Mode = _enMode._enUpdate;
        }
        private bool _AddNewApplication()
        {
            ApplicationID = clsApplicationData.AddNewApplication(this.ApplicantPersonID,this.ApplicationDate,
               (int) this.ApplicationTypeID,(byte)this.ApplicationStatus,this.LastStatusDate,
               this.PaidFees,this.CreatedByUserID);
            return (ApplicationID != -99);
        }
        private bool _UpdateApplication()
        {
            return clsApplicationData.UpdateApplication(this.ApplicationID,this.ApplicantPersonID,
                this.ApplicationDate,(int)this.ApplicationTypeID,(byte)this.ApplicationStatus,
                this.LastStatusDate, this.PaidFees,this.CreatedByUserID);
        }
        public static clsApplication FindBaseApplication(int ApplicationID)
        {
            int ApplicantPersonID = -1, ApplicationTypeID = -1 , CreatedByUserID = -1;
            DateTime ApplicationDate = DateTime.Now, LastStatusDate = DateTime.Now;
            byte ApplicationStatus = 1;
            float PaidFees = 0;
            if (clsApplicationData.GetApplicationInfoByID(ApplicationID, ref ApplicantPersonID,
                ref ApplicationDate, ref ApplicationTypeID, ref ApplicationStatus, ref LastStatusDate,
                ref PaidFees, ref CreatedByUserID))
            {
                return new clsApplication(ApplicationID,ApplicantPersonID,ApplicationDate,(enApplicationType)
                    ApplicationTypeID,(enApplicationStatus)ApplicationStatus,LastStatusDate,PaidFees
                    ,CreatedByUserID);
            }
            return null;
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case _enMode._enAddNew:
                    {
                        if (_AddNewApplication())
                        {
                            _Mode = _enMode._enUpdate;
                            return true;
                        }
                        return false;
                    }
                case _enMode._enUpdate:
                    {
                        return _UpdateApplication();
                    }
            }
            return false;
        }
        public bool Cancel()
        {
            return clsApplicationData.UpdateStatus(ApplicationID, 2);
        }
        public bool SetComplete()
        {
            return clsApplicationData.UpdateStatus(ApplicationID, 3);
        }
        public bool Delete()
        {
            return clsApplicationData.DeleteApplication(this.ApplicationID);
        }
        public bool IsApplicationExists(int ApplicationID)
        {
            return clsApplicationData.IsApplicationExist(ApplicationID);
        }
        public static bool DoesPersonHaveActiveApplication(int PersonID, enApplicationType ApplicationTypeID)
        {
            return clsApplicationData.DoesPersonHaveActiveApplication(PersonID,(int)ApplicationTypeID);
        }
        public bool DoesPersonHaveActiveApplication(enApplicationType ApplicationTypeID)
        {
            return DoesPersonHaveActiveApplication(this.ApplicantPersonID, ApplicationTypeID);
        }

        public static int GetActiveApplicationID(int PersonID, enApplicationType ApplicationTypeID)
        {
            return clsApplicationData.GetActiveApplicationID(PersonID, (int)ApplicationTypeID);
        }

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, enApplicationType ApplicationTypeID, int LicenseClassID)
        {
            return clsApplicationData.GetActiveApplicationIDForLicenseClass(PersonID, (int)ApplicationTypeID, LicenseClassID);
        }

        public int GetActiveApplicationID(enApplicationType ApplicationTypeID)
        {
            return GetActiveApplicationID(this.ApplicantPersonID, ApplicationTypeID);
        }

    }
}
