using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class clsLocalDrivingLicenseApp
    {
        public int LocalDrivingLicenseApplicationID { get; set; }
        public int personID { get; set; }
        public int Fees { get; set; }
        public int ClassID { get; set; }   
        public static DataTable GetAllLocalApp()
        {
            return DataAccessLayer.clsLocalDrivingLicenseAppData.GetAllLocalApp();
        }
        public clsLocalDrivingLicenseApp()
        {
            LocalDrivingLicenseApplicationID = -99;
            personID = -99;
            Fees = LocalLicenseFees();
            ClassID = -99;
        }
        private  int LocalLicenseFees()
        {
            return DataAccessLayer.clsLocalDrivingLicenseAppData.GetLocalAppFees();
        }
        public bool IsExists()
        {
            return DataAccessLayer.clsLocalDrivingLicenseAppData.IsThisAppExist(this.personID, this.ClassID);
        }
        public  bool AddNewLocalDrivingLicenseApp(int userid)
        {
            this.LocalDrivingLicenseApplicationID = 
          DataAccessLayer.clsLocalDrivingLicenseAppData.AddNewLocalDrivingLicenseApp(this.personID,this.Fees,userid, ClassID);
            return (this.LocalDrivingLicenseApplicationID != -99);
        }
        public static bool CancelLocalAppStatus(int LocalID)
        {
            return DataAccessLayer.clsLocalDrivingLicenseAppData.CancelLocalAppStatus(LocalID);
        }
    }
}
