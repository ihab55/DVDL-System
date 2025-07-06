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

        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get{ return $"{FirstName} {SecondName} {ThirdName} {LastName}"; }
        }
        public string NationalNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public short Gendor { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int NationalityCountryID { set; get; }
        public clsCountry CountryInfo { get; set; }
        private string _ImagePath { get; set; }
        public string ImagePath
        {
            get { return _ImagePath; }
            set
            {
                if (value == null)
                    _ImagePath = "";
                else
                    _ImagePath = value;
            }
        }
        /// <summary>
        /// Private constructor to create a person object with all properties initialized
        /// </summary>
        /// <param name="PersonID">Unique identifier for the person</param>
        /// <param name="FirstName">Person's first name</param>
        /// <param name="SecondName">Person's second name</param>
        /// <param name="ThirdName">Person's third name</param>
        /// <param name="LastName">Person's last name</param>
        /// <param name="NationalNo">Person's national identification number</param>
        /// <param name="DateOfBirth">Person's date of birth</param>
        /// <param name="Gendor">Person's gender (0 for Male, 1 for Female)</param>
        /// <param name="Address">Person's address</param>
        /// <param name="Phone">Person's phone number</param>
        /// <param name="Email">Person's email address</param>
        /// <param name="NationalityCountryID">ID of the person's nationality country</param>
        /// <param name="ImagePath">Path to the person's image</param>
        private clsPerson(int PersonID, string FirstName, string SecondName, string ThirdName,
            string LastName, string NationalNo, DateTime DateOfBirth, short Gendor,
             string Address, string Phone, string Email,
            int NationalityCountryID, string ImagePath)
        {
            this.PersonID = PersonID;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gendor = Gendor;
            this.Address = Address;
            this.Email = Email;
            this.Phone = Phone;
            this.NationalityCountryID = NationalityCountryID;
            CountryInfo = clsCountry.Find(NationalityCountryID);
            this.ImagePath = ImagePath;
            this.NationalNo = NationalNo;
            this._Mode = _enMode._Update;
        }
        
        /// <summary>
        /// Default constructor that initializes a new person with default values
        /// </summary>
        public clsPerson()
        {
            this.PersonID = -99;
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.DateOfBirth = DateTime.Now;
            this.Gendor = 0;
            this.Address = "";
            this.Email = "";
            this.Phone = "";
            this.NationalityCountryID = -99;
            this.ImagePath = "";
            this.NationalNo = "";
            this._Mode = _enMode._Add;
        }
        /// <summary>
        /// Finds a person by their ID
        /// </summary>
        /// <param name="PersonID">The unique identifier of the person to find</param>
        /// <returns>A clsPerson object if found; otherwise, null</returns>
        public static clsPerson Find(int PersonID)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", NationalNo = "", Email = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int NationalityCountryID = -99;
            short Gendor = 0;
            if (clsPersonData.GetPersonInfoByID(PersonID,ref FirstName,ref SecondName,ref ThirdName,
               ref LastName,ref NationalNo,ref DateOfBirth,ref Gendor,ref Address,ref Phone,
               ref Email,ref NationalityCountryID,ref ImagePath))
            {
                return new clsPerson(PersonID,FirstName,SecondName,ThirdName,LastName,NationalNo,DateOfBirth,
                    Gendor,Address,Phone,Email,NationalityCountryID,ImagePath);
            }
            return null;
        }
        /// <summary>
        /// Finds a person by their National Number
        /// </summary>
        /// <param name="NationalNo">The national identification number of the person to find</param>
        /// <returns>A clsPerson object if found; otherwise, null</returns>
        public static clsPerson Find(string NationalNo)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Email = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int NationalityCountryID = -99, PersonID = -99;
            short Gendor = 0;
            if (clsPersonData.GetPersonInfoByNationalID(NationalNo,ref PersonID,ref FirstName,
                ref SecondName,ref ThirdName,ref LastName,ref DateOfBirth,ref Gendor,
                ref Address,ref Phone,ref Email,ref NationalityCountryID,ref ImagePath))
            {
                return new clsPerson(PersonID, FirstName, SecondName, ThirdName, LastName, NationalNo, DateOfBirth,
                    Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
            }
            return null;
        }

        /// <summary>
        /// Adds a new person to the database
        /// </summary>
        /// <returns>True if the person was added successfully; otherwise, false</returns>
        private bool _AddNewPerson()
        {
            this.PersonID = clsPersonData.AddNewPerson(
this.FirstName,this.SecondName,this.ThirdName,this.LastName,this.NationalNo,this.DateOfBirth,
this.Gendor,this.Address,this.Phone,this.Email,this.NationalityCountryID,this.ImagePath);
            return (this.PersonID != -99);
        }
        /// <summary>
        /// Updates an existing person's information in the database
        /// </summary>
        /// <returns>True if the person was updated successfully; otherwise, false</returns>
        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePerson(this.PersonID,this.FirstName,this.SecondName,
                this.ThirdName,this.LastName,this.NationalNo,this.DateOfBirth,this.Gendor,
                this.Address,this.Phone,this.Email,this.NationalityCountryID,this.ImagePath);
        }
        /// <summary>
        /// Retrieves all people from the database
        /// </summary>
        /// <returns>A DataTable containing all people records</returns>
        public static DataTable GetAllPeople()
        {
            return clsPersonData.GetAllPeople();
        }
        /// <summary>
        /// Deletes a person from the database by their ID
        /// </summary>
        /// <param name="ID">The unique identifier of the person to delete</param>
        /// <returns>True if the person was deleted successfully; otherwise, false</returns>
        static public bool Delete(int ID)
        {
            return clsPersonData.DeletePerson(ID);
        }
        /// <summary>
        /// Checks if a person exists in the database by their ID
        /// </summary>
        /// <param name="ID">The unique identifier of the person to check</param>
        /// <returns>True if the person exists; otherwise, false</returns>
        public static bool IsExist(int ID)
        {
            return clsPersonData.IsPersonExist(ID);
        }
        /// <summary>
        /// Checks if a person exists in the database by their National Number
        /// </summary>
        /// <param name="NationlNo">The national identification number of the person to check</param>
        /// <returns>True if the person exists; otherwise, false</returns>
        public static bool IsExist(string NationlNo)
        {
            return clsPersonData.IsPersonExist(NationlNo);
        }
        /// <summary>
        /// Saves the current person object to the database (either adds a new record or updates an existing one)
        /// </summary>
        /// <returns>True if the operation was successful; otherwise, false</returns>
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
