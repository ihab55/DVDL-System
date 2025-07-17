using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BussinessLayer
{
    public class clsDriver
    {
        public enum enMode
        {
            _enAdd = 0, _enUpdate = 1
        }
        public enMode Mode;

        public clsPerson PersonInfo;

        public int DriverID { set; get; }
        public int PersonID { set; get; }
        public int CreatedByUserID { set; get; }
        public DateTime CreatedDate { get; }
        public clsDriver()
        {
            this.DriverID = -99;
            this.PersonID = -99;
            this.CreatedByUserID = -99;
            this.CreatedDate = DateTime.Now;
            Mode = enMode._enAdd;
        }
        private clsDriver(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;

            PersonInfo = clsPerson.Find(PersonID);
            Mode = enMode._enUpdate;
        }
        private bool _AddNewDriver()
        {
            this.DriverID = clsDriverData.AddNewDriver(this.PersonID, this.CreatedByUserID);
            return (this.DriverID != -99);
        }
        private bool _UpdateDriver()
        {
            return clsDriverData.UpdateDriver(this.DriverID, this.PersonID, this.CreatedByUserID);
        }
        public static DataTable GetDriver()
        {
            return clsDriverData.GetAllDrivers();
        }
        public static clsDriver FindByDriverID(int DriverID)
        {
            int PersonID = -99;
            int CreatedByUserID = -99;
            DateTime CreatedDate = DateTime.MinValue;
            if (clsDriverData.GetDriverInfoByDriverID(DriverID, ref PersonID, ref CreatedByUserID, ref CreatedDate))
            {
                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            }
            return null;
        }
        public static bool IsExistsByPersonID(int PersonID)
        {
            return clsDriverData.IsExistsByPersonID(PersonID);
        }
        public static clsDriver FindByPersonID(int PersonID)
        {
            int DriverID = -99, CreatedByUserID = -99;
            DateTime CreatedDate = DateTime.MinValue;
            if (clsDriverData.GetDriverInfoByPersonID(PersonID, ref DriverID, ref CreatedByUserID, ref CreatedDate))
            {
                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            }
            return null;
        }
        public bool Save()
        {
            switch (Mode)
            {
                case (enMode._enAdd):
                    if (_AddNewDriver())
                    {
                        Mode = enMode._enUpdate;
                        return true;
                    }
                    break;
                case (enMode._enUpdate):
                    return _UpdateDriver();
            }
            return false;
        }
        public DataTable GetLocalDriverLicenses()
        {
            return clsLicenseData.GetDriverLicenses(this.DriverID);
        }
        public DataTable GetInternationalDriverLicenses()
        {
            return clsInternationalLicense.GetDriverInternationalLicenses(this.DriverID);
        }
    }
}
