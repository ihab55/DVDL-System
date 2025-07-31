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
        public static bool IsExistsByPersonID(int PersonID)
        {
            bool IsExists = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"SELECT X=1 FROM Drivers WHERE PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                IsExists = reader.HasRows;
            }
            catch (Exception ex)
            {
                clsLogger.LogEvent(ex); IsExists = false; }
            finally { connection.Close(); }
            return IsExists;
        }
        public static bool GetDriverInfoByDriverID(int DriverID,ref int PersonID,
            ref int CreatedByUserID ,ref DateTime CreatedDate) {
            bool IsFounded = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"SELECT PersonID ,CreatedByUserID ,CreatedDate
  FROM Drivers WHERE DriverID = @DriverID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);
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
            catch (Exception ex)
            {
                clsLogger.LogEvent(ex); IsFounded = false; }
            finally { connection.Close(); }
            return IsFounded;
        }
        public static bool GetDriverInfoByPersonID(int PersonID, ref int DriverID, 
            ref int CreatedByUserID , ref DateTime CreatedDate)
        {
            bool IsFounded = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"SELECT DriverID ,CreatedByUserID ,CreatedDate
  FROM Drivers WHERE PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    DriverID = (int)reader["DriverID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];
                    IsFounded = true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                clsLogger.LogEvent(ex); IsFounded = false; }
            finally { connection.Close(); }
            return IsFounded;
        }
        public static DataTable GetAllDrivers()
        {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"SELECT * FROM Drivers_View order by FullName";
            SqlCommand command = new SqlCommand(query, connection);    
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                table.Load(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                clsLogger.LogEvent(ex);
                table = null;
            }
            finally { connection.Close(); }
            return table;
        }
        public static int AddNewDriver( int PersonID, int CreatedByUserID)
        {
            int DriverID = -99;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"INSERT INTO Drivers
           (PersonID ,CreatedByUserID ,CreatedDate)
     VALUES (@PersonID,@CreatedByUserID,@CreatedDate);SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
            try
            {
                connection.Open();
                object value = command.ExecuteScalar();
                DriverID = (value != null && int.TryParse(value.ToString(), out int result)) ? result : -99;
            }
            catch (Exception ex)
            {
                clsLogger.LogEvent(ex);
                DriverID = -99;
            }
            finally { connection.Close(); }
            return DriverID;
        }
        public static bool UpdateDriver(int DriverID,int PersonID, int CreatedByUserID)
        {
            int Affected = -99;
            SqlConnection connection = new SqlConnection( DataSetting.ConnctionName);
            string query = @"UPDATE Drivers SET PersonID =  @PersonID,CreatedByUserID =  
@CreatedByUserID  WHERE DriverID = @DriverID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            try
            {
                connection.Open();
                Affected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                clsLogger.LogEvent(ex);
                Affected = -99;
            }finally { connection.Close(); }
            return (Affected>0);
        }


    }
}
