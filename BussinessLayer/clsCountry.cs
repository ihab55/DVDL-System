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
        public int CountryId { get; }
        public string CountryName { get; }
        static public DataTable GetAllCountry() {
        return clsCountryData.GetAllCountry();
        }
        private clsCountry(int Id, string Name)
        {
            CountryName = Name;
            CountryId = Id;
        }
        static public clsCountry Find(int Id)
        {
            string Name = "";
            if (clsCountryData.GetCountryById(Id,ref Name))
            {
                return new clsCountry(Id, Name);
            }
            return null;
        }
    }
}
