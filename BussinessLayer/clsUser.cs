using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BussinessLayer
{
    public class clsUser
    {
        private enum _enMode
        {
            _Update = 0, _Add = 1
        }
        private _enMode _Mode;
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public clsPerson PersonInfo { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public clsUser()
        {
            UserID = -99;
            UserName = string.Empty;
            Password = string.Empty;
            IsActive = false;
            _Mode = _enMode._Add;
        }
        private clsUser(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            PersonInfo = clsPerson.Find(PersonID);
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;
            _Mode = _enMode._Update;
        }
        private bool _AddNewUsers()
        {
            this.UserID = clsUsersData.AddNewUsers(this.PersonID, this.UserName, this.Password, this.IsActive);
            return (this.UserID != -99);
        }
        private bool _UpdateUsers()
        {
            return clsUsersData.UpdateUsers(this.UserID, this.PersonID, this.UserName,
                this.Password, this.IsActive);
        }
        public static clsUser FindByUserID(int UserID)
        {
            int PersonID = -99;
            string UserName = "", Password = "";
            bool IsActive = false;
            if (clsUsersData.GetUserInfoByUserID(UserID, ref PersonID, ref UserName, ref Password, ref IsActive))
            {
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            }
            return null;
        }
        public static clsUser FindByPersonID(int PersonID)
        {
            int UserID = -99;
            string UserName = "", Password = "";
            bool IsActive = false;
            if (clsUsersData.GetUserInfoByPersonID(PersonID, ref UserID, ref UserName, ref Password, ref IsActive))
            {
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            }
            return null;
        }
        public static clsUser FindByUserNameAndPassword(string UserName, string Password)
        {
            int PersonID = -99, UserID = -99;
            bool IsActive = false;
            if (clsUsersData.GetUserInfoByUserNameAndPassword(UserName, Password, ref PersonID,
                ref UserID, ref IsActive))
            {
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            }
            return null;
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case _enMode._Add:
                    if (_AddNewUsers())
                    {
                        _Mode = _enMode._Update;
                        return true;
                    }
                    return false;
                case _enMode._Update:
                    return _UpdateUsers();
            }
            return false;
        }
        public static DataTable GetAllUsers()
        {
            return clsUsersData.GetAllUsers();
        }
        public static bool DeleteUsers(int id)
        {
            return clsUsersData.DeleteUsers(id);
        }
        public static bool IsUserExists(int UserID)
        {
            return clsUsersData.IsUserExists(UserID);
        }
        public static bool IsUserExists(string UserName)
        {
            return clsUsersData.IsUserExists(UserName);
        }
        public static bool IsUserExistForPersonID(int PersonID)
        {
            return clsUsersData.IsUserExistForPersonID(PersonID);
        } 
    }
}
