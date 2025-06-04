using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BussinessLayer
{
    public class clsLocalDrivingLicenseApp
    {
        #region   Property
        public int LocalDrivingLicenseApplicationID { get; set; }
        public clsApplication ApplicationInfo { get; set; }
        public clsLicenseClass licenseClassInfo { get; set; }
        private enum _enMode {_enAddNew=0,_enUpdate=1}
        _enMode _Mode;
        #endregion
        public static DataTable GetAllLocalApp()
        {
            return DataAccessLayer.clsLocalDrivingLicenseAppData.GetAllLocalApp();
        }
        public clsLocalDrivingLicenseApp()
        {
            LocalDrivingLicenseApplicationID = -99;
            ApplicationInfo = new clsApplication();
            //Add Class License in presntation;
            _Mode = _enMode._enAddNew;
        }
        private clsLocalDrivingLicenseApp(int localappID,int appID,int classeID)
        {
            LocalDrivingLicenseApplicationID = localappID;
            ApplicationInfo = clsApplication.FindApp(appID);
            licenseClassInfo = clsLicenseClass.Find(classeID);
            _Mode = _enMode._enUpdate;
        }
        public static clsLocalDrivingLicenseApp GetAppByID(int id)
        {
            int appID = -99;
            int LicId = -99;
            if (clsLocalDrivingLicenseAppData.GetLocalAppByID(id,ref appID,ref LicId))
            {
                return new clsLocalDrivingLicenseApp(id, appID,LicId);
            }
            return null;
        }
        public bool IsExists()
        {
            return DataAccessLayer.clsLocalDrivingLicenseAppData.IsThisAppExist(
                ApplicationInfo.PersonInfo.Id, licenseClassInfo.ID);
        }
        private  bool AddNewLocalDrivingLicenseApp()
        {
            ApplicationInfo.Save();
            this.LocalDrivingLicenseApplicationID = 
          DataAccessLayer.clsLocalDrivingLicenseAppData.AddNewLocalDrivingLicenseApp(ApplicationInfo.ID , licenseClassInfo.ID);
            return (this.LocalDrivingLicenseApplicationID != -99);
        }
        private bool UpdateLocalDrivingLicense()
        {
            return clsLocalDrivingLicenseAppData.UpdateLocalDrivingApp(LocalDrivingLicenseApplicationID,
                ApplicationInfo.ID, licenseClassInfo.ID);
        }
        public bool CancelLocalAppStatus()
        {
            return ApplicationInfo.CancelApp();
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case _enMode._enUpdate:
                    {
                        return UpdateLocalDrivingLicense();
                    }
                case _enMode._enAddNew:
                    {
                        if (AddNewLocalDrivingLicenseApp())
                        {
                            _Mode = _enMode._enUpdate;
                            return true;
                        }
                        return false;
                    }
            }
            return false;
        }
    }
}
