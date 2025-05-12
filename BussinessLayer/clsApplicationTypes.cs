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
        public int ID;
        public string Title;
        public decimal Fees;
        public static DataTable GetAllApplicationTypes()
        {
            return DataAccessLayer.clsApplicationTypesData.GetAllApplicationTypes();
        }
        private clsApplicationTypes (int id , string title, decimal fees)
        {
            ID = id;
            Title = title;
            Fees = fees;
        }  
        public static clsApplicationTypes Find (int id)
        {
            string title = "";
            decimal fees = 0;
            if (clsApplicationTypesData.GetApplicationTypesByID(id,ref title,ref fees))
            {
                return new clsApplicationTypes(id, title, fees);
            }
            return null;
        }
        private bool _UpdateApplicationType()
        {
            return clsApplicationTypesData.UpdateApplicationType(ID, Title, Fees);
        }
        public bool Save()
        {
            return _UpdateApplicationType();
        }
    }
}
