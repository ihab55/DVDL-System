using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class clsDriverData
    {
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
    }
}
