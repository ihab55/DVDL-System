using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAccessLayer
{
    public static class clsDriverData
    {
        public static bool IsActive(int DriverID)
        {
            bool Active = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = "SELECT X=1 FROM Licenses WHERE DriverID = @DriverID AND IsActive =1";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                Active = reader.HasRows;
            }
            catch (Exception ex) { Active = false; }
            finally { connection.Close(); }
            return Active;
        }
        public static DataTable GetDriver()
        {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"SELECT  [Driver ID] = Drivers.DriverID ,[Person ID] = Drivers.PersonID , 
[National No] = NationalNo , [Full Name] = 
(People.FirstName + ' ' + People.SecondName + ' ' + CASE WHEN People.ThirdName IS NULL THEN '' ELSE People.ThirdName END + ' ' + People.LastName)
,Date = CreatedDate FROM Drivers LEFT JOIN People ON People.PersonID = Drivers.PersonID ";
            SqlCommand command = new SqlCommand(query, connection);
            table.Columns.Add("Driver ID", typeof(int));      
            table.Columns.Add("Person ID", typeof(int));
            table.Columns.Add("National No", typeof(string));
            table.Columns.Add("Full Name", typeof(string));   
            table.Columns.Add("Date", typeof(DateTime));      
            table.Columns.Add("IsActive", typeof(bool));      
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    table.Rows.Add(reader.GetInt32(0), reader.GetInt32(1),reader.GetString(2), reader.GetString(3)
                       , reader.GetDateTime(4),IsActive(reader.GetInt32(0)));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                table = null;
            }
            finally { connection.Close(); }
            return table;
        }
        public static int AddNewDriver( int PersonID, int CreatedByID, DateTime CreatDate)
        {
            int Driverid = -99;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"INSERT INTO Drivers
           (PersonID ,CreatedByUserID ,CreatedDate)
     VALUES (@PersonID,@CreatedByID,@CreatDate);SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CreatedByID", CreatedByID);
            command.Parameters.AddWithValue("@CreatDate", CreatDate);
            try
            {
                connection.Open();
                object value = command.ExecuteScalar();
                Driverid = (value != null && int.TryParse(value.ToString(), out int result)) ? result : -99;
            }
            catch (Exception ex)
            {
                Driverid = -99;
            }
            finally { connection.Close(); }
            return Driverid;
        }
        public static bool UpdateDriver(int DriverId,int PersonID, int CreatedByID, DateTime CreatDate)
        {
            int Affected = -99;
            SqlConnection connection = new SqlConnection( DataSetting.ConnctionName);
            string query = @"UPDATE Drivers SET PersonID =  @PersonID,CreatedByUserID =  
@CreatedByID ,CreatedDate = @CreatDate WHERE DriverID = @DriverId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CreatedByID", CreatedByID);
            command.Parameters.AddWithValue("@CreatDate", CreatDate);
            command.Parameters.AddWithValue("@DriverId", DriverId);
            try
            {
                connection.Open();
                Affected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Affected = -99;
            }finally { connection.Close(); }
            return (Affected>0);
        }
        public static bool GetDriverByID(int DriverId,ref int PersonID,ref int CreatedByUserID
            ,ref DateTime CreatedDate) {
            bool IsFounded = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"SELECT PersonID ,CreatedByUserID ,CreatedDate
  FROM Drivers WHERE DriverID = @DriverId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverId", DriverId);
            try
            {
                connection.Open ();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    PersonID = (int)reader["PersonID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];
                    IsFounded = true;
                }
                reader.Close ();
            }
            catch (Exception ex) { IsFounded = false; }
            finally { connection.Close(); }
            return IsFounded;
        }
        public static bool DeleteDriverById(int DriverId)
        {
            int Affected = -99;
            SqlConnection connection = new SqlConnection( DataSetting.ConnctionName);
            string query = "DELETE FROM Drivers WHERE DriverID = @DriverId";
            SqlCommand command = new SqlCommand (query, connection);
            command.Parameters.AddWithValue("@DriverId", DriverId);
            try
            {
                connection.Open();
                Affected = command.ExecuteNonQuery();
            }
            catch (Exception ex) { Affected = -99; }
            finally { connection.Close(); }
            return (Affected > 0);
        }
        public static bool IsExist (int personid)
        {
            bool IsFounded = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = "SELECT X=1 FROM Drivers WHERE PersonID = @personid";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@personid", personid);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                IsFounded = reader.HasRows;
            }
            catch {  IsFounded = false; }
            finally { connection.Close(); }
            return IsFounded;
        }
        public static bool FindByPersonId(int PersonID, ref int DriverId, ref int CreatedByUserID
            , ref DateTime CreatedDate)
        {
            bool IsFounded = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"SELECT PersonID ,CreatedByUserID ,CreatedDate
  FROM Drivers WHERE DriverID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    DriverId = (int)reader["DriverID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];
                    IsFounded = true;
                }
                reader.Close();
            }
            catch (Exception ex) { IsFounded = false; }
            finally { connection.Close(); }
            return IsFounded;
        }

    }
}
