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
        private enum _enMode
        {
            _enAdd = 0, _enUpdate = 1
        }
        private _enMode _Mode;
        public int DetainID { get; set; }
        public int LicenseID { set; get; }
        public DateTime DetainDate { get; set; }
        public float FineFees { get; set; }
        public int CreatedByUserID { set; get; }
        public bool IsReleased { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ReleasedByUserID { set; get; }
        public int ReleaseApplicationID { set; get; }

        public clsDetainedLicenses()
        {
            this.DetainID = -99;
            this.LicenseID = -99;
            this.DetainDate = DateTime.Now;
            this.FineFees = 0;
            this.CreatedByUserID = -99;
            this.IsReleased = false;
            this.ReleaseDate = DateTime.MinValue;
            this.ReleasedByUserID = -99;
            this.ReleaseApplicationID = -99;

            _Mode = _enMode._enAdd;
        }
        private clsDetainedLicenses(int DetainID, int LicenseID, DateTime DetainDate, 
            float FineFees, int CreatedByUserID,
            bool IsReleased, DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            this.DetainID = DetainID;
            this.LicenseID = LicenseID;
            this.DetainDate = DetainDate;
            this.FineFees = FineFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsReleased = IsReleased;
            this.ReleaseDate = ReleaseDate;
            this.ReleasedByUserID = ReleasedByUserID;
            this.ReleaseApplicationID = ReleaseApplicationID;

            _Mode = _enMode._enUpdate;
        }

        private bool _AddNewDetainedLicense()
        {
            this.DetainID = clsDetainedLicensesData.AddNewDetainedLicense(this.LicenseID,
                this.DetainDate,this.FineFees,this.CreatedByUserID);
            return (DetainID != -99);
        }
        private bool _UpdateDetainedLicense()
        {
            return clsDetainedLicensesData.UpdateDetainedLicense(this.DetainID,this.LicenseID
                ,this.DetainDate,this.FineFees,this.CreatedByUserID,this.IsReleased,
                this.ReleaseDate,this.ReleasedByUserID,this.ReleaseApplicationID);
        }
        public static clsDetainedLicenses Find(int DetainID)
        {
            int LicenseID = -99, CreatedByUserID = -99;
            DateTime DetainDate = DateTime.MinValue;
            float FineFees = -99;
            bool IsReleased = false;
            DateTime ReleaseDate = DateTime.MinValue;
            int ReleasedByUserID = -99, ReleaseApplicationID = -99;
            if (clsDetainedLicensesData.GetDetainedLicenseInfoByID(DetainID, ref LicenseID,
               ref DetainDate, ref FineFees, ref CreatedByUserID, ref IsReleased, ref ReleaseDate
               , ref ReleasedByUserID, ref ReleaseApplicationID))
            {
                return new clsDetainedLicenses(DetainID, LicenseID, DetainDate,FineFees, CreatedByUserID,
                    IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
            }
            return null;
        }
        public static clsDetainedLicenses FindByLicenseID(int LicenseID)
        {
            int DetainID = -99, CreatedByUserID = -99;
            DateTime DetainDate = DateTime.MinValue;
            float FineFees = -99;
            bool IsReleased = false;
            DateTime ReleaseDate = DateTime.MinValue;
            int ReleasedByUserID = -99, ReleaseApplicationID = -99;
            if (clsDetainedLicensesData.GetDetainedLicenseInfoByLicenseID(LicenseID,ref DetainID, 
               ref DetainDate, ref FineFees, ref CreatedByUserID, ref IsReleased, ref ReleaseDate
               , ref ReleasedByUserID, ref ReleaseApplicationID))
            {
                return new clsDetainedLicenses(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID,
                    IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
            }
            return null;
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
        public static bool IsLicenseDetained(int LicenseID)
        {
            return clsDetainedLicensesData.IsLicenseDetained(LicenseID);
        }
        public static DataTable GetAllDetainedLicenses()
        {
            return clsDetainedLicensesData.GetAllDetainLicese();
        }
        public bool ReleaseDetainedLicense()
        {
            return clsDetainedLicensesData.ReleaseDetainedLicense(this.DetainID,
                this.ReleasedByUserID, this.ReleaseApplicationID);
        }

    }
}
