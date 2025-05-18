using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class clsPersonData
    {
        public static bool GetPersonByID(int id,ref string NationalId,ref string FirstName,ref string SecondName,ref string ThirdName,ref string LastName,
           ref DateTime DateOfBirth,ref int Gendor,ref string Address,ref string Phone,ref string Email,ref int CountryId,ref string ImagePath)
        {
            bool isFounded = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = "SELECT * FROM People WHERE PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", id);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read()) {
                    NationalId = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    ThirdName = (reader["ThirdName"]==DBNull.Value)?"":(string)reader["ThirdName"];        //Null
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = int.Parse(reader["Gendor"].ToString());
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    Email = (reader["Email"]==DBNull.Value)?"":(string)reader["Email"];        //NUll
                    CountryId = int.Parse(reader["NationalityCountryID"].ToString());
                    ImagePath = (reader["ImagePath"]==DBNull.Value)?"":(string)reader["ImagePath"];       //Null
                    
                isFounded = true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                isFounded = false;
                //Error Message
            }
            finally { 
            connection.Close();
            }
            return isFounded;
        }

       public static bool GetPersonByNationalID(ref int id,string NationalId, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName,
           ref DateTime DateOfBirth, ref int Gendor, ref string Address, ref string Phone, ref string Email, ref int CountryId, ref string ImagePath)
        {
            bool isFounded = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = "SELECT * FROM People WHERE NationalNo = @NationalNo";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalId);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read()) {
                    isFounded = true;
                    id = int.Parse(reader["PersonID"].ToString());
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    ThirdName = (reader["ThirdName"] == DBNull.Value) ? "" : (string)reader["ThirdName"];        //Null
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = int.Parse(reader["Gendor"].ToString());
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    Email = (reader["Email"] == DBNull.Value) ? "" : (string)reader["Email"];        //NUll
                    CountryId = int.Parse(reader["NationalityCountryID"].ToString());
                    ImagePath = (reader["ImagePath"] == DBNull.Value) ? "" : (string)reader["ImagePath"];       //Null
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                isFounded = false;
                //Error Message
            }
            finally
            {
                
                connection.Close();
            }
            return isFounded;
        }
       
        public static int AddNewPerson(string NationalId, string FirstName, string SecondName, string ThirdName, string LastName,
           DateTime DateOfBirth, int Gendor, string Address, string Phone, string Email, int CountryId, string ImagePath)
        {
            int id = -99;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"INSERT INTO People(NationalNo,FirstName,SecondName,ThirdName,LastName,DateOfBirth,Gendor,
                Address,Phone,Email,NationalityCountryID,ImagePath) VALUES(@NationalNo,@FirstName,@SecondName,@ThirdName,@LastName,
                @DateOfBirth,@Gendor,@Address,@Phone,@Email,@NationalityCountryID,@ImagePath);SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalId);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            if (ThirdName != "")
            {
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
            }
            else
            {
                command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);
            }
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            if (Email != "")
            {
                command.Parameters.AddWithValue("@Email", Email);
            }
            else
            {
                command.Parameters.AddWithValue("@Email", System.DBNull.Value);
            }
            command.Parameters.AddWithValue("@NationalityCountryID", CountryId);
            if (ImagePath != "")
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            }
            try
            {
                connection.Open();
                object value = command.ExecuteScalar();
                id = ((int.TryParse(value.ToString(), out int resualt)&& value!=null )? resualt : -99);
            }
            catch (Exception ex)
            {
                id = -99;
                //Error Message
            }
            finally
            {
                connection.Close();
            }
            return id;
        }

        public static bool UpdatePerson(int id,string NationalId, string FirstName, string SecondName, string ThirdName, string LastName,
           DateTime DateOfBirth,int Gendor,string Address, string Phone,string Email,int CountryId, string ImagePath)
        {
            int Affected =0;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
           string query = @"UPDATE People
            SET NationalNo = @NationalNo
                ,FirstName = @FirstName
                ,SecondName = @SecondName
                ,ThirdName = @ThirdName
                ,LastName = @LastName
                ,DateOfBirth = @DateOfBirth
                ,Gendor = @Gendor
                ,Address = @Address
                ,Phone = @Phone
                ,Email = @Email
                ,NationalityCountryID = @NationalityCountryID
                ,ImagePath = @ImagePath
            WHERE PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", id);
            command.Parameters.AddWithValue("@NationalNo", NationalId);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            if (ThirdName != "")
            {
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
            }
            else
            {
                command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);
            }
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            if (Email != "")
            {
                command.Parameters.AddWithValue("@Email", Email);
            }
            else
            {
                command.Parameters.AddWithValue("@Email", System.DBNull.Value);
            }
            command.Parameters.AddWithValue("@NationalityCountryID", CountryId);
            if (ImagePath != "")
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            }
            try
            {
                connection.Open();
                Affected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Affected = 0 ;
                //Error Message
            }
            finally
            {

                connection.Close();
            }
            return (Affected > 0);
        }
        
        public static DataTable GetAllPeople()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"SELECT PersonID
      ,NationalNo AS [National No]
      ,FirstName As [First Name]
      ,SecondName As [Second Name]
      ,ThirdName As [Third Name]
      ,LastName As [Last Name]
      ,CASE WHEN Gendor = 0 THEN 'Male' 
	  WHEN Gendor = 1 THEN 'Female' end AS [Gendor]
      ,DateOfBirth AS [Date Of Birth]
      ,Countries.CountryName AS Nationality
      ,Phone
      ,Email
  FROM People INNER JOIN Countries ON People.NationalityCountryID = Countries.CountryID";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                dt = null;
                //Error Message
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        public static bool DeletePerson(int id)
        {
            int Affected = 0;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = "DELETE FROM People WHERE PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", id);
            try
            {
                connection.Open();
                Affected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Affected = 0;
                //Error Message
            }
            finally
            {
                connection.Close();
            }
            return (Affected > 0);
        }

        public static bool IsPersonExist(string NationalId)
        {
            bool isFounded = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = "SELECT X=1 FROM People WHERE NationalNo = @NationalNo";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalId);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFounded = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                isFounded = false;
                //Error Message
            }
            finally
            {
                connection.Close();
            }
            return isFounded;
        }

        public static bool IsPersonExist(int id)
        {
            bool isFounded = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = "SELECT X=1 FROM People WHERE PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", id);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFounded = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                isFounded = false;
                //Error Message
            }
            finally
            {
                connection.Close();
            }
            return isFounded;
        }

    }
}
