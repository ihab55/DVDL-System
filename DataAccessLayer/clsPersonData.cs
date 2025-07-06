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
        /// <summary>
        /// Retrieves person information from the database by person ID
        /// </summary>
        /// <param name="PersonID">The unique identifier of the person</param>
        /// <param name="FirstName">Reference parameter to store the person's first name</param>
        /// <param name="SecondName">Reference parameter to store the person's second name</param>
        /// <param name="ThirdName">Reference parameter to store the person's third name</param>
        /// <param name="LastName">Reference parameter to store the person's last name</param>
        /// <param name="NationalNo">Reference parameter to store the person's national identification number</param>
        /// <param name="DateOfBirth">Reference parameter to store the person's date of birth</param>
        /// <param name="Gendor">Reference parameter to store the person's gender (0 for Male, 1 for Female)</param>
        /// <param name="Address">Reference parameter to store the person's address</param>
        /// <param name="Phone">Reference parameter to store the person's phone number</param>
        /// <param name="Email">Reference parameter to store the person's email address</param>
        /// <param name="NationalityCountryID">Reference parameter to store the ID of the person's nationality country</param>
        /// <param name="ImagePath">Reference parameter to store the path to the person's image</param>
        /// <returns>True if the person was found; otherwise, false</returns>
        public static bool GetPersonInfoByID(int PersonID, ref string FirstName, ref string SecondName,
          ref string ThirdName, ref string LastName, ref string NationalNo, ref DateTime DateOfBirth,
           ref short Gendor, ref string Address, ref string Phone, ref string Email,
           ref int NationalityCountryID, ref string ImagePath)
        {
            bool isFounded = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = "SELECT * FROM People WHERE PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read()) {
                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    ThirdName = (reader["ThirdName"]==DBNull.Value)?"":(string)reader["ThirdName"];        //Null
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = (byte)reader["Gendor"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    Email = (reader["Email"]==DBNull.Value)?"":(string)reader["Email"];        //NUll
                    NationalityCountryID = (int)reader["NationalityCountryID"];
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

       /// <summary>
       /// Retrieves person information from the database by national identification number
       /// </summary>
       /// <param name="NationalNo">The national identification number of the person</param>
       /// <param name="PersonID">Reference parameter to store the person's unique identifier</param>
       /// <param name="FirstName">Reference parameter to store the person's first name</param>
       /// <param name="SecondName">Reference parameter to store the person's second name</param>
       /// <param name="ThirdName">Reference parameter to store the person's third name</param>
       /// <param name="LastName">Reference parameter to store the person's last name</param>
       /// <param name="DateOfBirth">Reference parameter to store the person's date of birth</param>
       /// <param name="Gendor">Reference parameter to store the person's gender (0 for Male, 1 for Female)</param>
       /// <param name="Address">Reference parameter to store the person's address</param>
       /// <param name="Phone">Reference parameter to store the person's phone number</param>
       /// <param name="Email">Reference parameter to store the person's email address</param>
       /// <param name="NationalityCountryID">Reference parameter to store the ID of the person's nationality country</param>
       /// <param name="ImagePath">Reference parameter to store the path to the person's image</param>
       /// <returns>True if the person was found; otherwise, false</returns>
       public static bool GetPersonInfoByNationalID(string NationalNo, ref int PersonID, ref string FirstName, ref string SecondName,
        ref string ThirdName, ref string LastName, ref DateTime DateOfBirth,
         ref short Gendor, ref string Address, ref string Phone, ref string Email,
         ref int NationalityCountryID, ref string ImagePath)
        {
            bool isFounded = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = "SELECT * FROM People WHERE NationalNo = @NationalNo";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read()) {
                    isFounded = true;
                    PersonID = (int)reader["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    ThirdName = (reader["ThirdName"] == DBNull.Value) ? "" : (string)reader["ThirdName"];        //Null
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = (byte)reader["Gendor"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    Email = (reader["Email"] == DBNull.Value) ? "" : (string)reader["Email"];        //NUll
                    NationalityCountryID = (int)reader["NationalityCountryID"];
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
       
        /// <summary>
        /// Adds a new person to the database
        /// </summary>
        /// <param name="FirstName">The person's first name</param>
        /// <param name="SecondName">The person's second name</param>
        /// <param name="ThirdName">The person's third name</param>
        /// <param name="LastName">The person's last name</param>
        /// <param name="NationalNo">The person's national identification number</param>
        /// <param name="DateOfBirth">The person's date of birth</param>
        /// <param name="Gendor">The person's gender (0 for Male, 1 for Female)</param>
        /// <param name="Address">The person's address</param>
        /// <param name="Phone">The person's phone number</param>
        /// <param name="Email">The person's email address</param>
        /// <param name="NationalityCountryID">The ID of the person's nationality country</param>
        /// <param name="ImagePath">The path to the person's image</param>
        /// <returns>The ID of the newly added person if successful; otherwise, -99</returns>
        public static int AddNewPerson(string FirstName, string SecondName,
           string ThirdName, string LastName, string NationalNo, DateTime DateOfBirth,
           short Gendor, string Address, string Phone, string Email,
            int NationalityCountryID, string ImagePath)
        {
            int id = -99;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"INSERT INTO People(NationalNo,FirstName,SecondName,ThirdName,LastName,DateOfBirth,Gendor,
                Address,Phone,Email,NationalityCountryID,ImagePath) VALUES(@NationalNo,@FirstName,@SecondName,@ThirdName,@LastName,
                @DateOfBirth,@Gendor,@Address,@Phone,@Email,@NationalityCountryID,@ImagePath);
SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
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
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
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

        /// <summary>
        /// Updates an existing person's information in the database
        /// </summary>
        /// <param name="PersonID">The unique identifier of the person to update</param>
        /// <param name="FirstName">The updated first name</param>
        /// <param name="SecondName">The updated second name</param>
        /// <param name="ThirdName">The updated third name</param>
        /// <param name="LastName">The updated last name</param>
        /// <param name="NationalNo">The updated national identification number</param>
        /// <param name="DateOfBirth">The updated date of birth</param>
        /// <param name="Gendor">The updated gender (0 for Male, 1 for Female)</param>
        /// <param name="Address">The updated address</param>
        /// <param name="Phone">The updated phone number</param>
        /// <param name="Email">The updated email address</param>
        /// <param name="NationalityCountryID">The updated ID of the nationality country</param>
        /// <param name="ImagePath">The updated path to the person's image</param>
        /// <returns>True if the update was successful; otherwise, false</returns>
        public static bool UpdatePerson(int PersonID, string FirstName, string SecondName,
           string ThirdName, string LastName, string NationalNo, DateTime DateOfBirth,
           short Gendor, string Address, string Phone, string Email,
            int NationalityCountryID, string ImagePath)
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
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
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
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
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
        
        /// <summary>
        /// Retrieves all people from the database
        /// </summary>
        /// <returns>A DataTable containing all people records with their country information</returns>
        public static DataTable GetAllPeople()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"SELECT People.PersonID, People.NationalNo,
              People.FirstName, People.SecondName, People.ThirdName, People.LastName,
			  People.DateOfBirth, People.Gendor,  
				  CASE
                  WHEN People.Gendor = 0 THEN 'Male'
                  ELSE 'Female'
                  END as GendorCaption ,
			  People.Address, People.Phone, People.Email, 
              People.NationalityCountryID, Countries.CountryName, People.ImagePath
              FROM            People INNER JOIN
                         Countries ON People.NationalityCountryID = Countries.CountryID
                ORDER BY People.FirstName";
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

        /// <summary>
        /// Deletes a person from the database by their ID
        /// </summary>
        /// <param name="PersonID">The unique identifier of the person to delete</param>
        /// <returns>True if the deletion was successful; otherwise, false</returns>
        public static bool DeletePerson(int PersonID)
        {
            int Affected = 0;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = "DELETE FROM People WHERE PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
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

        /// <summary>
        /// Checks if a person exists in the database by their national identification number
        /// </summary>
        /// <param name="NationalNo">The national identification number to check</param>
        /// <returns>True if the person exists; otherwise, false</returns>
        public static bool IsPersonExist(string NationalNo)
        {
            bool isFounded = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = "SELECT X=1 FROM People WHERE NationalNo = @NationalNo";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
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

        /// <summary>
        /// Checks if a person exists in the database by their ID
        /// </summary>
        /// <param name="PersonID">The unique identifier of the person to check</param>
        /// <returns>True if the person exists; otherwise, false</returns>
        public static bool IsPersonExist(int PersonID)
        {
            bool isFounded = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = "SELECT X=1 FROM People WHERE PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
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
