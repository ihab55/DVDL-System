using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BussinessLayer
{
    public class clsTestType
    {
        #region Porerty
        public int TestTypeId;
        public string TestName;
        public string TestDescription;
        public int TestFees;
        #endregion
        private clsTestType(int id,string Name,string Description,int fees) {
            TestTypeId = id;
            TestName = Name;
            TestDescription = Description;
            TestFees = fees;
        }
        public static clsTestType Find(int id)
        {
            string Name = "";
            string Description = "";
            decimal fees = -99;
            if (clsTestTypeData.GetTestTypeId(id,ref Name,ref Description,ref fees))
            {
                return new clsTestType(id,Name,Description,(int)fees);
            }
            return null;
        }
        public bool UpdateFees(int Newfees)
        {
            TestFees = Newfees;
            return clsTestTypeData.UpdateFees(TestTypeId, TestFees);
        }
    }
}
