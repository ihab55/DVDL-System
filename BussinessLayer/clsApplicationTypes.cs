using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
namespace BussinessLayer
{
    public class clsApplicationTypes
    {
        public int ApplicationTypeID;
        public string Title;
        public float Fees;
        public static DataTable GetAllApplicationTypes()
        {
            return DataAccessLayer.clsApplicationTypesData.GetAllApplicationTypes();
        }
        private clsApplicationTypes (int ID , string Title, float Fees)
        {
            this.ApplicationTypeID = ID;
            this.Title = Title;
            this.Fees = Fees;
        }  
        public static clsApplicationTypes Find (int ID)
        {
            string Title = "";
            float Fees = 0;
            if (clsApplicationTypesData.GetApplicationTypesInfoByID(ID,ref Title,ref Fees))
            {
                return new clsApplicationTypes(ID, Title, Fees);
            }
            return null;
        }
        private bool _UpdateApplicationType()
        {
            return clsApplicationTypesData.UpdateApplicationType(this.ApplicationTypeID, this.Title, this.Fees);
        }
        public bool Save()
        {
            return _UpdateApplicationType();
        }
    }
}
