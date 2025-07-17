using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics.Eventing.Reader;
namespace DataAccessLayer
{
    public static class clsUsersData
    {
        public static bool GetUserInfoByUserID(int UserID, ref int PersonID, ref string UserName, 
            ref string Password, ref bool IsActive)
        {
            bool Isfounded = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = "SELECT * FROM Users WHERE UserID = @UserID ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    PersonID = (int)reader["PersonID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];
                    Isfounded = true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                 Isfounded = false;
            }
            finally
            {
                connection.Close();
            }
            return Isfounded;
        }
        public static bool GetUserInfoByPersonID(int PersonID, ref int UserID,  ref string UserName,
            ref string Password, ref bool IsActive)
        {
            bool Isfounded = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = "SELECT * FROM Users WHERE PersonID = @PersonID ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    UserID = (int)reader["UserID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];
                    Isfounded = true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Isfounded = false;
            }
            finally
            {
                connection.Close();
            }
            return Isfounded;
        }
        public static bool GetUserInfoByUserNameAndPassword(string UserName, string Password, ref int PersonID, ref int UserID, ref bool IsActive)
        {
            bool Isfounded = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = "SELECT * FROM Users WHERE UserName = @UserName AND Password = @Password";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    PersonID = (int)reader["PersonID"];
                    UserID = (int)reader["UserID"];
                    IsActive = (bool)reader["IsActive"];
                    Isfounded = true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Isfounded = false;
            }
            finally
            {
                connection.Close();
            }
            return Isfounded;
        }
        public static int AddNewUsers(int PersonID, string UserName, string Password, bool IsActive)
        {
            int id = -99;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"INSERT INTO Users
                    (PersonID,UserName,Password,IsActive)
                    VALUES(@PersonID,@UserName,@Password,@IsActive);
                SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            try
            {
                connection.Open();
                object value = command.ExecuteScalar();
                id = (int.TryParse(value.ToString(), out int reualt) && value != null) ? reualt : -99;
            }
            catch (Exception ex)
            {
                id = -99;
            }
            finally
            {
                connection.Close();
            }
            return id;
        }
        public static bool UpdateUsers(int UserID, int PersonID, string UserName, 
            string Password, bool IsActive)
        {
            int IsAffected = 0;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"UPDATE Users SET PersonID = @PersonID, UserName = @UserName ,
Password = @Password ,IsActive = @IsActive WHERE UserID = @UserID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("IsActive", IsActive);
            try
            {
                connection.Open();
                IsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                IsAffected = 0;
            }
            finally { connection.Close(); }
            return (IsAffected > 0);

        }
        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"SELECT  Users.UserID, Users.PersonID,
                            FullName = People.FirstName + ' ' + People.SecondName + ' ' + ISNULL( People.ThirdName,'') +' ' + People.LastName,
                             Users.UserName, Users.IsActive
                             FROM  Users INNER JOIN
                                    People ON Users.PersonID = People.PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            try {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch(Exception ex)
            {
                dt = null;
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }
        public static bool DeleteUsers(int UserID)
        {
            int IsDeleted = 0;
            SqlConnection connection = new SqlConnection( DataSetting.ConnctionName);
            string query = "DELETE FROM Users WHERE UserID = @UserID";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@UserID", UserID);
            try
            {
                connection.Open();
                IsDeleted = command.ExecuteNonQuery();
            }
            catch (Exception ex) { IsDeleted = 0; }
            finally{ connection.Close(); }
            return (IsDeleted > 0);
        }
        public static bool IsUserExists(int UserID)
        {
            bool Isfounded = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = "SELECT X=1 FROM Users WHERE UserID = @UserID ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                Isfounded = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                Isfounded = false;
            }
            finally
            {
                connection.Close();
            }
            return Isfounded;
        }
        public static bool IsUserExists(string UserName)
        {
            bool Isfounded = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = "SELECT X=1 FROM Users WHERE UserName = @UserName ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                Isfounded = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                Isfounded = false;
            }
            finally
            {
                connection.Close();
            }
            return Isfounded;
        }
        public static bool IsUserExistForPersonID(int PersonID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);

            string query = "SELECT Found=1 FROM Users WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
    }
}
