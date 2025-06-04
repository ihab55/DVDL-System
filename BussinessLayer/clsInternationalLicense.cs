using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BussinessLayer
{
    public class clsInternationalLicense
    {
        public int InternationalLicenseID { get; set; }
        public clsApplication ApplicationInfo { get; set; }
        public clsDriver DriverInfo { get; set; }
        public clsLocalDrivingLicenseApp IssuedUsingLocalLicenseInfo { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public clsUser CreatedByUserInfo { get; set; }
        private enum _enMode
        {
            _enAdd = 0, _enUpdate = 1
        }
        private _enMode _Mode;
        public clsInternationalLicense()
        {
            InternationalLicenseID = -99;
            //ApplicationInfo
            //DriverInfo
            //LocalLicenseInfo
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now.AddYears(10);
            IsActive = true;
            //CreatedByUserInfo
            _Mode = _enMode._enAdd;
        }
        private clsInternationalLicense(int internationalLicenseId, int appId, int driverId, int localLicenseId,
            DateTime issueDate, DateTime expirationDate, bool isActive, int createdByUserId)
        {
            InternationalLicenseID = internationalLicenseId;
            ApplicationInfo = clsApplication.FindApp(appId);
            DriverInfo = clsDriver.Find(driverId);
            IssuedUsingLocalLicenseInfo = clsLocalDrivingLicenseApp.GetAppByID(localLicenseId);
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            IsActive = isActive;
            CreatedByUserInfo = clsUser.Find(createdByUserId);
            _Mode = _enMode._enUpdate;
        }
        public static clsInternationalLicense Find(int internationalLicenseId)
        {
            int appId = -99;
            int driverId = -99;
            int localLicenseId = -99;
            DateTime issueDate = DateTime.MinValue;
            DateTime expirationDate = DateTime.MinValue;
            bool isActive = false;
            int createdByUserId = -99;
            if (clsInternationalLicenseData.GetInternationalLicenseByID(internationalLicenseId, ref appId, ref driverId, ref localLicenseId,
                ref issueDate, ref expirationDate, ref isActive, ref createdByUserId))
            {
                return new clsInternationalLicense(internationalLicenseId, appId, driverId, localLicenseId,
                    issueDate, expirationDate, isActive, createdByUserId);
            }
            return null;
        }
        public static bool Delete(int internationalLicenseId)
        {
            return clsInternationalLicenseData.DeleteInternationalLicense(internationalLicenseId);
        }
        private bool _AddNewInternationalLicense()
        {
            this.InternationalLicenseID = clsInternationalLicenseData.AddNewInternationalLicense(
                ApplicationInfo.ID, DriverInfo.DriverID, IssuedUsingLocalLicenseInfo.LocalDrivingLicenseApplicationID,
                IssueDate, ExpirationDate, IsActive, CreatedByUserInfo.Id);
            return (InternationalLicenseID != -99);
        }
        private bool _UpdateInternationalLicense()
        {
            return clsInternationalLicenseData.UpdateInternationalLicense(
                InternationalLicenseID, ApplicationInfo.ID, DriverInfo.DriverID, IssuedUsingLocalLicenseInfo.LocalDrivingLicenseApplicationID,
                IssueDate, ExpirationDate, IsActive, CreatedByUserInfo.Id);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case _enMode._enAdd:
                    if (_AddNewInternationalLicense())
                    {
                        _Mode = _enMode._enUpdate;
                        return true;
                    }
                    break ;
                case _enMode._enUpdate:
                    return _UpdateInternationalLicense();
            }
                    return false;
        }
    }
}
