using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BussinessLayer
{
    public class clsLicenseClass
    {
        public int ID { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public byte MinimumAllowedAge {  get; set; }
        public byte DefaultValidityLength { get; set; }
        public int Fees { get; set; }
        private clsLicenseClass(int id,string name,string description, byte minage, byte vaildlength, int fees) { 
        ID = id; 
        ClassName = name;
            ClassDescription = description;
            MinimumAllowedAge = minage;
            DefaultValidityLength = vaildlength;
            Fees = fees;
        }
        public static clsLicenseClass Find(int id)
        {
            string name = "";
            string description = "";
            byte Minage = 0;
            byte vaildlength = 0;
            decimal fees = 0;
            if (clsLicenseClassData.GetLicenseClass(id,ref name,ref description,ref Minage
                ,ref vaildlength,ref fees))
            {
                return new clsLicenseClass(id,name,description,Minage,vaildlength,(int)fees);
            }
            return null;
        }
    }
}
