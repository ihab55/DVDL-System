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
        public int Id { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public clsUser()
        {
            Id = -99;
            PersonID = -99;
            UserName = string.Empty;
            Password = string.Empty;
            IsActive = false;
            _Mode = _enMode._Add;
        }
        private clsUser(int id,int person_id,string username,string password,bool isactive)
        {
            Id =id; PersonID=person_id; UserName =username; Password =password; IsActive = isactive; _Mode = _enMode._Update;
        }
        private bool _AddNewUsers()
        {
            this.Id = clsUsersData.AddNewUsers(this.PersonID, this.UserName, this.Password, this.IsActive);
            return (this.Id != -99);
        }
        public static clsUser Find(int id)
        {
            int person_id = -99;
            string user_name = "";
            string pass_word="";
            bool is_active = false;
            if (clsUsersData.GetUserById(id,ref person_id,ref user_name,ref pass_word,ref is_active))
            {
                return new clsUser(id,person_id,user_name,pass_word,is_active);
            }
            return null;
        }
        public static clsUser Find(string username)
        {
            int person_id = -99;
            int id = -99;
            string pass_word = "";
            bool is_active = false;
            if (clsUsersData.GetUserByUserName(username, ref person_id, ref id, ref pass_word, ref is_active))
            {
                return new clsUser(id, person_id, username, pass_word, is_active);
            }
            return null;
        }
        public static bool DeleteUsers(int id)
        {
            return clsUsersData.DeleteUsers(id);
        }
        public static bool IsExists(int id)
        {
            return clsUsersData.IsUserExists(id);
        }
        private bool _UpdateUsers()
        {
            return clsUsersData.UpdateUsers(this.Id,this.PersonID,this.UserName,this.Password,this.IsActive);
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
        public static bool IsUserRight(string username, string password, ref bool Active)
        {
            return clsUsersData.IsUserExistsIsActive(username,password,ref Active);
        }
    }
}
