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
        public static bool GetUserById(int id, ref int person_id, ref string user_name, ref string pass_word, ref bool is_active)
        {
            bool Isfounded = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = "SELECT * FROM Users WHERE UserID = @UserID ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", id);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    person_id = (int)reader["PersonID"];
                    user_name = (string)reader["UserName"];
                    pass_word = (string)reader["Password"];
                    is_active = (bool)reader["IsActive"];
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
        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"SELECT Users.UserID, Users.PersonID, (People.FirstName + ' '+ People.SecondName+' '+ People.ThirdName+ ' ' + People.LastName)AS FullName
            , Users.UserName, Users.IsActive FROM Users INNER JOIN People ON Users.PersonID = People.PersonID";
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
        public static bool UpdateUsers(int id,int person_id,string user_name,string pass_word,bool is_active)
        {
            int IsAffected = 0;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = "UPDATE Users SET PersonID = @PersonID, UserName = @UserName ,Password = @Password ,IsActive = @IsActive WHERE UserID = @UserID";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@PersonID", person_id);
            command.Parameters.AddWithValue("@UserID", id);
            command.Parameters.AddWithValue("@UserName", user_name);
            command.Parameters.AddWithValue("@Password", pass_word);
            command.Parameters.AddWithValue("IsActive",is_active);
            try
            {
                connection.Open() ;
                IsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex) {
                IsAffected = 0;
            }
            finally {  connection.Close(); }
            return (IsAffected > 0);
            
        }
        public static int AddNewUsers(int person_id,string user_name,string password,bool is_active)
        {
            int id = -99;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"INSERT INTO [dbo].[Users]
                    (PersonID,UserName,Password,IsActive)
                    VALUES(@PersonID,@UserName,@Password,@IsActive);
                SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", person_id);
            command.Parameters.AddWithValue("@UserName", user_name);
            command.Parameters.AddWithValue("@Password", password);
            command.Parameters.AddWithValue("@IsActive", is_active);
            try
            {
                connection.Open();
                object value = command.ExecuteScalar();
                id = (int.TryParse(value.ToString(),out int reualt)&&value != null) ? reualt : -99;
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
        public static bool DeleteUsers(int Id)
        {
            int IsDeleted = 0;
            SqlConnection connection = new SqlConnection( DataSetting.ConnctionName);
            string query = "DELETE FROM Users WHERE UserID = @UserID";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@UserID", Id);
            try
            {
                connection.Open();
                IsDeleted = command.ExecuteNonQuery();
            }
            catch (Exception ex) { IsDeleted = 0; }
            finally{ connection.Close(); }
            return (IsDeleted > 0);
        }
        public static bool IsUserExists(int Id)
        {
            bool Isfounded = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = "SELECT X=1 FROM Users WHERE UserID = @UserID ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", Id);
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
        public static bool IsUserExists(string user_name,string password)
        {
            bool Isfounded = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = "SELECT x = 1 FROM Users WHERE UserName= @UserName AND Password = @Password";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", user_name);
            command.Parameters.AddWithValue("@Password", password);
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
        public static bool GetUserByUserName(string user_name, ref int person_id, ref int id, ref string pass_word, ref bool is_active)
        {
            bool Isfounded = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = "SELECT * FROM Users WHERE UserName = @UserName ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", user_name);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    person_id = (int)reader["PersonID"];
                    id = (int)reader["UserID"];
                    pass_word = (string)reader["Password"];
                    is_active = (bool)reader["IsActive"];
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
    }
}
