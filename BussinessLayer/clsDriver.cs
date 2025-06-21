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
        public int DriverID;
        public clsPerson PersonInfo;
        public clsUser CreatedByInfo;
        public DateTime CreatedDate;
        private enum _enMode
        {
            _enAdd = 0,_enUpdate = 1
        }
        private _enMode _Mode;
        public clsDriver() {
            DriverID = -99;
            //PersonInfo
            //CreatedByInfo
            CreatedDate = DateTime.Now;
            _Mode = _enMode._enAdd;
        }
        private clsDriver(int driverID, int personId, int createdByid, DateTime createdDate)
        {
            DriverID = driverID;
            PersonInfo = clsPerson.Find(personId);
            CreatedByInfo = clsUser.Find(createdByid);
            CreatedDate = createdDate;
            _Mode = _enMode._enUpdate;
        }
        public static DataTable GetDriver()
        {
            return clsDriverData.GetDriver();
        }
        public static clsDriver Find(int driverID)
        {
         int personid=-99;
         int createdByid = -99;
         DateTime createdDate = DateTime.MinValue;
            if (clsDriverData.GetDriverByID(driverID,ref personid,ref createdByid,ref createdDate))
            {
                return new clsDriver(driverID,personid,createdByid,createdDate);
            }
            return null;
        }
        public static bool DeleteDriver(int Id)
        {
            return clsDriverData.DeleteDriverById(Id);
        }
        private bool _AddNewDriver()
        {
            this.DriverID = clsDriverData.AddNewDriver(this.PersonInfo.Id,this.CreatedByInfo.Id,this.CreatedDate);
            return (this.DriverID != -99);
        }
        private bool _UpdateDriver()
        {
            return clsDriverData.UpdateDriver(this.DriverID,this.PersonInfo.Id, this.CreatedByInfo.Id, this.CreatedDate);
        }
        public bool Save()
        {
            switch (_Mode)
            {
            case (_enMode._enAdd):
                    if (_AddNewDriver())
                    {
                        _Mode = _enMode._enUpdate;
                        return true;
                    }
                    break;
                case (_enMode._enUpdate):
                return _UpdateDriver();
            }
            return false;
        }
        public static bool IsExist(int personId)
        {
            return clsDriverData.IsExist(personId);
        }
        public static clsDriver FindByPersonId(int personid)
        {
            int driverID = -99;
            int createdByid = -99;
            DateTime createdDate = DateTime.MinValue;
            if (clsDriverData.FindByPersonId(personid, ref driverID, ref createdByid, ref createdDate))
            {
                return new clsDriver(driverID, personid, createdByid, createdDate);
            }
            return null;
        }
    }
}
