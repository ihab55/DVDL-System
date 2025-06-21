using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
namespace BussinessLayer
{
    public class clsLicense
    {
        public int LicenseID { get; set; }
        public clsApplication ApplicationInfo { get; set; }
        public clsDriver DriverInfo { get; set; }
        public clsLicenseClass LicenseClassInfo { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpriationDate { get; set; }
        public string Note { get; set; }
        public int PaidFees { get; set; }
        public bool IsActive { get; set; }
        public short IssueReason { get; set; }
        public clsUser CreatedByUserInfo { get; set; }
        
        private enum _enMode
        {
            _enAdd = 0, _enUpdate = 1
        }
        private _enMode _Mode;
        public clsLicense()
        {
            LicenseID = -99;
            //ApplicationInfo
            //DriverInfo
            //LicenseClassInfo
            IssueDate = DateTime.Now;
            ExpriationDate = DateTime.Now.AddYears(10);
            Note = string.Empty;
            PaidFees = -99;
            IsActive = true;
            IssueReason = 0;
            //CreatedByUserInfo
        }
        public string IssueReasonText
        {
            get
            {
                switch (IssueReason)
                {
                    case 1: return "First Time";
                    case 2: return "Replacement";
                    case 3: return "Correction";
                    default: return "Unknown Reason";
                }
            }
        }
        private clsLicense(int licenseId,int appid,int Driverid,int LiceneseId,DateTime issusedate,
            DateTime exptiondate,string notes,int paidfees,bool isactive, short issresson, int userid)
        {
            LicenseID = licenseId;
            ApplicationInfo = clsApplication.FindApp(appid);
            DriverInfo = clsDriver.Find(Driverid);
            LicenseClassInfo = clsLicenseClass.Find(LiceneseId);
            IssueDate = issusedate;
            ExpriationDate = exptiondate;
            Note = notes;
            PaidFees = paidfees;
            IsActive = isactive;
            IssueReason = issresson;
            CreatedByUserInfo = clsUser.Find(userid);
            _Mode = _enMode._enUpdate;
        }
        public static DataTable GetAllLicebseByPersonID(int prsonid)
        {
            return clsLicenseData.GetAllLicenseWithPerson(prsonid);
        }
        public static clsLicense Find(int licenseId)
        {
            int appid = -99;
            int Driverid = -99;
            int LicenClassId = -99;
            DateTime issusedate = DateTime.MinValue;
            DateTime exptiondate = DateTime.MinValue;
            string notes = "";
            decimal paidfees = -99;
            bool isactive = false;
            short issresson = -99;
            int userid = -99;
            if (clsLicenseData.GetLicenseByID(licenseId, ref appid,ref Driverid,ref LicenClassId,ref issusedate,ref exptiondate
                ,ref notes,ref paidfees,ref isactive,ref issresson,ref userid))
            {
                return new clsLicense(licenseId, appid, Driverid,LicenClassId,issusedate,exptiondate
                ,notes,(int)paidfees,isactive,issresson,userid);
            }
            return null;
        }
        public static clsLicense GetLicenseByLocalID(int LocalID)
        {
            int licenseId = -99;
            int appid = -99;
            int Driverid = -99;
            int LicenClassId = -99;
            DateTime issusedate = DateTime.MinValue;
            DateTime exptiondate = DateTime.MinValue;
            string notes = "";
            decimal paidfees = -99;
            bool isactive = false;
            short issresson = -99;
            int userid = -99;
            if (clsLicenseData.GetLicenseByLocalID(LocalID,ref licenseId,ref appid, ref Driverid, ref LicenClassId, ref issusedate, ref exptiondate
                , ref notes, ref paidfees, ref isactive, ref issresson, ref userid))
            {
                return new clsLicense(licenseId, appid, Driverid, LicenClassId, issusedate, exptiondate
                , notes, (int)paidfees, isactive, issresson, userid);
            }
            return null;
        }
        public static bool DeleteLicense(int Id)
        {
            return clsLicense.DeleteLicense(Id);
        }
        private bool _AddNewLicense()
        {
            this.LicenseID = clsLicenseData.AddLicense(this.ApplicationInfo.ID, this.DriverInfo.DriverID
                , this.LicenseClassInfo.ID, this.IssueDate, this.ExpriationDate,
                this.Note, this.PaidFees, this.IsActive, this.IssueReason, this.CreatedByUserInfo.Id);
            return (this.LicenseID != -99);
        }
        private bool _UpdateLicense()
        {
            return clsLicenseData.UpdateLicense(this.LicenseID,this.ApplicationInfo.ID,this.DriverInfo.DriverID,
                this.LicenseClassInfo.ID,this.IssueDate,this.ExpriationDate,this.Note,
                this.PaidFees,this.IsActive,this.IssueReason,this.CreatedByUserInfo.Id);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case (_enMode._enAdd):
                    if (_AddNewLicense())
                    {
                        _Mode = _enMode._enUpdate;
                        return true;
                    }
                    break;
                case (_enMode._enUpdate):
                    return _UpdateLicense();
            }
            return false;
        }
    }
}
