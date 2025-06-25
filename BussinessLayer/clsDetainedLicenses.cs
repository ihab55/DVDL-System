using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BussinessLayer
{
    public class clsDetainedLicenses
    {
        public int DetainedLicenseID { get; set; }
        public clsLicense LicenseInfo { get; set; }
        public DateTime DetainDate { get; set; }
        public int FineFees { get; set; }
        public clsUser CreatedByUserInfo { get; set; }
        public bool IsReleased { get; set; }
        public DateTime ReleaseDate { get; set; }
        public clsUser ReleasedByUserInfo { get; set; }
        public clsApplication ReleaseApplicationInfo { get; set; }
        private enum _enMode
        {
            _enAdd = 0, _enUpdate = 1
        }
        private _enMode _Mode;
        public clsDetainedLicenses()
        {
            DetainedLicenseID = -99;
            //LicenseInfo ;
            DetainDate = DateTime.Now;
            FineFees = -99;
            //CreatedByUserInfo ;
            IsReleased = false;
            ReleaseDate = DateTime.MinValue;
            //ReleasedByUserInfo;
            //ReleaseApplicationInfo ;
            _Mode = _enMode._enAdd;
        }
        private clsDetainedLicenses(int detainedLicenseId, int licenseId, DateTime detainDate, int fineFees, int createdByUserId,
            bool isReleased, DateTime releaseDate, int releasedByUserId, int releaseApplicationId)
        {
            DetainedLicenseID = detainedLicenseId;
            LicenseInfo = clsLicense.Find(licenseId);
            DetainDate = detainDate;
            FineFees = fineFees;
            CreatedByUserInfo = clsUser.Find(createdByUserId);
            IsReleased = isReleased;
            ReleaseDate = releaseDate;
            ReleasedByUserInfo = clsUser.Find(releasedByUserId);
            ReleaseApplicationInfo = clsApplication.FindApp(releaseApplicationId);
            _Mode = _enMode._enUpdate;
        }
        public static clsDetainedLicenses Find(int detainedLicenseId)
        {
            int licenseId = -99;
            DateTime detainDate = DateTime.MinValue;
            decimal fineFees = -99;
            int createdByUserId = -99;
            bool isReleased = false;
            DateTime releaseDate = DateTime.MinValue;
            int releasedByUserId = -99;
            int releaseApplicationId = -99;
            if (clsDetainedLicensesData.GetDetainedLicenseByID(detainedLicenseId, ref licenseId, ref detainDate, ref fineFees,
                ref createdByUserId, ref isReleased, ref releaseDate, ref releasedByUserId, ref releaseApplicationId))
            {
                return new clsDetainedLicenses(detainedLicenseId, licenseId, detainDate, (int)fineFees, createdByUserId,
                    isReleased, releaseDate, releasedByUserId, releaseApplicationId);
            }
            return null;
        }
        public static clsDetainedLicenses FindByLicenseID(int LicenseID)
        {
            int detainedLicenseId = -99;
            DateTime detainDate = DateTime.MinValue;
            decimal fineFees = -99;
            int createdByUserId = -99;
            bool isReleased = false;
            DateTime releaseDate = DateTime.MinValue;
            int releasedByUserId = -99;
            int releaseApplicationId = -99;
            if (clsDetainedLicensesData.GetDetainedLicenseByID(ref detainedLicenseId, LicenseID, ref detainDate, ref fineFees,
                ref createdByUserId, ref isReleased, ref releaseDate, ref releasedByUserId, ref releaseApplicationId))
            {
                return new clsDetainedLicenses(detainedLicenseId, LicenseID, detainDate, (int)fineFees, createdByUserId,
                    isReleased, releaseDate, releasedByUserId, releaseApplicationId);
            }
            return null;
        }
        public static bool delete(int detainedLicenseId)
        {
            return clsDetainedLicensesData.DeleteDetainedLicense(detainedLicenseId);
        }
        public static bool IsDetained(int licenseId)
        {
            return clsDetainedLicensesData.IsDetained(licenseId);
        }
        public bool IsDetained()
        {
            return clsDetainedLicensesData.IsDetained(this.LicenseInfo.LicenseID);
        }
        private bool _AddNewDetainedLicense()
        {
            this.DetainedLicenseID = clsDetainedLicensesData.AddNewDetainedLicense(this.LicenseInfo.LicenseID, this.DetainDate,
                this.FineFees, this.CreatedByUserInfo.Id);
            return (DetainedLicenseID != -99);
        }
        private bool _UpdateDetainedLicense()
        {
            return clsDetainedLicensesData.UpdateDetainedLicense(this.DetainedLicenseID, this.LicenseInfo.LicenseID, this.DetainDate,
                this.FineFees, this.CreatedByUserInfo.Id, this.IsReleased, this.ReleaseDate, this.ReleasedByUserInfo.Id,
                this.ReleaseApplicationInfo.ID);
        }
        public static DataTable GetAllDetainLicese()
        {
            return clsDetainedLicensesData.GetAllDetainLicese();
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case _enMode._enAdd:
                    if (_AddNewDetainedLicense())
                    {
                        _Mode = _enMode._enUpdate;
                        return true;
                    }
                    break;
                case _enMode._enUpdate:
                    return _UpdateDetainedLicense();
            }
            return false;
        }

    }
}
