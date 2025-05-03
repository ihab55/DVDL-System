using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BussinessLayer
{
    public class clsPerson
    {
        private enum _enMode
        {
            _Update = 0, _Add = 1
        }

        private _enMode _Mode;
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }

        public string FullName()
        {
            return $"{FirstName} {SecondName} {ThirdName} {LastName}";
        }
        public string NationalID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gendor { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int CountryId { get; set; }
        public string ImagePath { get; set; }
        private clsPerson(int id, string nationaliD, string firstname, string secondname, string thirdname, string lastname, DateTime dateofbirth, int gendor, string address,
            string email, string phone, int countryid, string imagepath)
        {
            Id = id;
            FirstName = firstname;
            SecondName = secondname;
            ThirdName = thirdname;
            LastName = lastname;
            DateOfBirth = dateofbirth;
            Gendor = gendor;
            Address = address;
            Email = email;
            Phone = phone;
            CountryId = countryid;
            ImagePath = imagepath;
            NationalID = nationaliD;
            _Mode = _enMode._Update;
        }

        public clsPerson()
        {
            Id = -99;
            FirstName = "";
            SecondName = "";
            ThirdName = "";
            LastName = "";
            DateOfBirth = DateTime.Now;
            Gendor = -9;
            Address = "";
            Email = "";
            Phone = "";
            CountryId = -99;
            ImagePath = "";
            NationalID = "";
            _Mode = _enMode._Add;
        }
        public static clsPerson Find(int ID)
        {
            string firstname = "";
            string secondname = "";
            string thirdname = "";
            string lastname = "";
            DateTime dateofbirth = DateTime.Now;
            int gendor = -99;
            string address = "";
            string email = "";
            string phone = "";
            int countryid = -99;
            string imagepath = "";
            string nationalid = "";
            if (clsPersonData.GetPersonByID(ID, ref nationalid, ref firstname, ref secondname, ref thirdname, ref lastname, ref dateofbirth, ref gendor, ref address
            , ref phone, ref email, ref countryid, ref imagepath))
            {
                return new clsPerson(ID, nationalid, firstname, secondname, thirdname, lastname, dateofbirth, gendor, address, email, phone, countryid, imagepath);
            }
            return null;
        }
        public static clsPerson Find(string nationalid)
        {
            string firstname = "";
            string secondname = "";
            string thirdname = "";
            string lastname = "";
            DateTime dateofbirth = DateTime.Now;
            int gendor = -99;
            string address = "";
            string email = "";
            string phone = "";
            int countryid = -99;
            string imagepath = "";
            int ID = -99;
            if (clsPersonData.GetPersonByNationalID(ref ID, nationalid, ref firstname, ref secondname, ref thirdname, ref lastname, ref dateofbirth, ref gendor, ref address
            , ref phone, ref email, ref countryid, ref imagepath))
            {
                return new clsPerson(ID, nationalid, firstname, secondname, thirdname, lastname, dateofbirth, gendor, address, email, phone, countryid, imagepath);
            }
            return null;
        }

        private bool _AddNewPerson()
        {
            Id = clsPersonData.AddNewPerson(NationalID, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, CountryId, ImagePath);
            return (Id != -99);
        }
        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePerson(Id,NationalID,FirstName,SecondName,ThirdName,LastName,DateOfBirth,Gendor,Address,Phone,Email,CountryId,ImagePath);
        }
        public static DataTable GetAllPeople()
        {
            return clsPersonData.GetAllPeople();
        }
        public bool Delete()
        {
            return clsPersonData.DeletePerson(Id);
        }
        static public bool Delete(int id)
        {
            return clsPersonData.DeletePerson(id);
        }
        public static bool IsExist(int id)
        {
            return clsPersonData.IsPersonExist(id);
        }
        public static bool IsExist(string natid)
        {
            return clsPersonData.IsPersonExist(natid);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case _enMode._Update:
                    return _UpdatePerson();
                case _enMode._Add:
                    if (_AddNewPerson())
                    {
                        _Mode = _enMode._Update;
                        return true;
                    }
                    return false;
            }
            return false;
        }
    }
}
