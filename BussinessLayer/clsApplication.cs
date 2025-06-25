using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BussinessLayer
{
    public class clsApplication
    {
        #region Property
        public int ID { get; set; }
        public clsPerson PersonInfo { get; set; }
        public DateTime Date { get; set; }
        public clsApplicationTypes AppTypeInfo { get; set; }
        public enum enStatus
        {
            New = 1,
            Cancelled = 2,
            Completed = 3
        }
        public enStatus Status { get; set; }
        public DateTime StatusDate { get; set; }
        public int Fees { get; set; }
        public clsUser CreatedbyInfo { get; set; }
        private enum _enMode { _enAddNew = 0, _enUpdate = 1 }
        private _enMode _Mode;
        #endregion
        private clsApplication(int id, short status, int fees, int typeID,
            DateTime date, DateTime statusdate, int createbyId, int personid)
        {
            ID = id;
            Status = (enStatus)status;
            Fees = fees;
            AppTypeInfo = clsApplicationTypes.Find(typeID);
            Date = date;
            StatusDate = statusdate;
            CreatedbyInfo = clsUser.Find(createbyId);
            PersonInfo = clsPerson.Find(personid);
            _Mode = _enMode._enUpdate;
        }
        public clsApplication()
        {
            ID = -99;
            //PersonInfo
            Date = DateTime.Now;
            AppTypeInfo = clsApplicationTypes.Find(1);
            Status = enStatus.New;
            StatusDate = DateTime.Now;
            Fees = AppTypeInfo.Fees;
            //CreatedbyInfo;
            _Mode = _enMode._enAddNew;
        }
        private bool _AddNewApplication()
        {
            ID = clsApplicationData.AddNewApplication(PersonInfo.Id, Date, AppTypeInfo.ID,
               (int)Status, StatusDate, Fees, CreatedbyInfo.Id);
            return (ID != -99);
        }
        private bool _UpdateApplication()
        {
            return clsApplicationData.UpdateApplication(ID, StatusDate);
        }
        public static clsApplication FindApp(int id)
        {
            byte status = 55;
            decimal fees = 0;
            int type = -99;
            DateTime date = DateTime.MinValue;
            DateTime statusDate = DateTime.MinValue;
            int personid = -99;
            int createdbyId = -99;
            if (clsApplicationData.GetApplicationByID(id, ref status, ref fees, ref type,
                ref date, ref statusDate, ref createdbyId, ref personid))
            {
                return new clsApplication(id, status, (int)fees, type, date, statusDate, createdbyId, personid);
            }
            return null;
        }
        public static clsApplication FindAppByPersonID(int personId)
        {
            byte status = 55;
            decimal fees = -99;
            int type = -99;
            DateTime date = DateTime.MinValue;
            DateTime statusDate = DateTime.MinValue;
            int createdbyId = -99;
            int id = -99;
            if (clsApplicationData.GetApplicationIDByPersonID(personId, ref id, ref status, ref fees, ref type,
                ref date, ref statusDate, ref createdbyId))
            {
                return new clsApplication(id, status, (int)fees, type, date, statusDate, createdbyId, personId);
            }
            return null;
        }
        public bool Save()
        {
            Fees = AppTypeInfo.Fees; // Update Fees based on Application Type
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
        public bool CancelApp()
        {
            StatusDate = DateTime.Now;
            return clsApplicationData.CancelApplication(ID, StatusDate);
        }
        public bool CompleteApp()
        {
            Status = enStatus.Completed;
            StatusDate = DateTime.Now;
            return clsApplicationData.CompleteApplication(ID, StatusDate);
        }
    }
}
