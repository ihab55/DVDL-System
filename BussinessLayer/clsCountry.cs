using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BussinessLayer
{
    public class clsCountry
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public static DataTable GetAllCountry() {
        return clsCountryData.GetAllCountries();
        }
        private clsCountry(int ID, string Name)
        {
            this.Name = Name;
            this.ID = ID;
        }
        public static clsCountry Find(int ID)
        {
            string Name = "";
            if (clsCountryData.GetCountryInfoByID(ID,ref Name))
            {
                return new clsCountry(ID, Name);
            }
            return null;
        }
        public static clsCountry Find(string Name)
        {
            int ID = -99;
            if (clsCountryData.GetCountryInfoByName(Name,ref ID))
            {
                return new clsCountry(ID, Name);
            }
            return null;
        }
        public clsCountry()
        {
            ID = -99;
            Name = string.Empty;
        }
    }
}
