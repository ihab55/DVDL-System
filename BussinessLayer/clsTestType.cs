using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BussinessLayer
{
    public class clsTestType
    {
        #region Porerty
        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };
        public enTestType TestTypeID;
        public string TestTitle;
        public string TestDescription;
        public float TestFees;
        #endregion
        private clsTestType(enTestType TestTypeID,string TestTitle,string TestDescription,float TestFees) {
            this.TestTypeID = TestTypeID;
            this.TestTitle = TestTitle;
            this.TestDescription = TestDescription;
            this.TestFees = TestFees;
        }
        public static clsTestType Find(enTestType TestTypeID)
        {
            string TestTitle = "";
            string TestDescription = "";
            float TestFees = -99;
            if (clsTestTypeData.GetTestTypeInfoByID((int)TestTypeID,ref TestTitle,ref TestDescription,ref TestFees))
            {
                return new clsTestType(TestTypeID,TestTitle,TestDescription,TestFees);
            }
            return null;
        }
        public static DataTable GetAllTestTypes()
        {
            return clsTestTypeData.GetAllTestTypes();

        }
        private bool _UpdateTestType()
        {
            return clsTestTypeData.UpdateTestType((int)this.TestTypeID, this.TestTitle, this.TestDescription, this.TestFees);
        }
        public bool Save()
        {
            return _UpdateTestType();
        }
    }
}
