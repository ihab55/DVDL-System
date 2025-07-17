using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsTestAppointmentData
    {
        public static bool GetTestAppointmentInfoByID(int TestAppointmentID, ref int TestTypeID, ref int LocalDrivingLicenseApplicationID,
                ref DateTime AppointmentDate, ref float PaidFees, ref int CreatedByUserID, ref bool IsLocked,
                ref int RetakeTestApplicationID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"SELECT TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked 
                            ,RetakeTestApplicationID FROM TestAppointments WHERE TestAppointmentID = @id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", TestAppointmentID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    TestTypeID = (int)reader["TestTypeID"];
                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = Convert.ToSingle(reader["PaidFees"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsLocked = (bool)reader["IsLocked"];
                    RetakeTestApplicationID = reader["RetakeTestApplicationID"] != DBNull.Value ? (int)reader["RetakeTestApplicationID"] : -99;
                    isFound = true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }
        public static bool GetLastTestAppointment(int LocalDrivingLicenseApplicationID, int TestTypeID, 
            ref int TestAppointmentID,ref DateTime AppointmentDate, ref float PaidFees, ref int CreatedByUserID, 
            ref bool IsLocked, ref int RetakeTestApplicationID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"SELECT  TOP 1 *  FROM TestAppointments WHERE LocalDrivingLicenseApplicationID = 
@LocalDrivingLicenseApplicationID AND TestTypeID  = @TestTypeID ORDER BY TestAppointmentID DESC";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = Convert.ToSingle(reader["PaidFees"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsLocked = (bool)reader["IsLocked"];
                    RetakeTestApplicationID = reader["RetakeTestApplicationID"] != DBNull.Value ? (int)reader["RetakeTestApplicationID"] : -99;
                    isFound = true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }
        public static DataTable GetApplicationTestAppointmentsPerTestType(int LocalDrivingLicenseApplicationID, byte TestTypeID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"SELECT TestAppointmentID  ,AppointmentDate ,PaidFees ,IsLocked FROM TestAppointments 
Where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID And TestTypeID = @TestTypeID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                dt.Load(reader);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                dt = null;
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
        public static int AddNewTestAppointment(int TestTypeID, int LocalDrivingLicenseApplicationID,
            DateTime AppointmentDate, float PaidFees, int CreatedByUserID, int RetakeTestApplicationID)
        {
            int newAppointmentId = -99;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"INSERT INTO TestAppointments
(TestTypeID,LocalDrivingLicenseApplicationID,AppointmentDate,PaidFees,CreatedByUserID,IsLocked,RetakeTestApplicationID)
VALUES ( @TestTypeID , @LocalDrivingLicenseApplicationID , @AppointmentDate , @PaidFees , @CreatedByUserID
,0,@RetakeTestApplicationID);  
SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            if (RetakeTestApplicationID == -99)
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value); }
            else
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);
            }
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                newAppointmentId = (int.TryParse(result.ToString(), out int value) && result != null) ? value : -99;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                newAppointmentId = -99;
            }
            finally
            {
                connection.Close();
            }
            return newAppointmentId;
        }

        public static bool UpdateTestAppointment(int TestAppointmentID, int TestTypeID,
         int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, float PaidFees,
         int CreatedByUserID, bool IsLocked,int RetakeTestApplicationID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"UPDATE TestAppointments
SET TestTypeID = @TestTypeID ,LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
,AppointmentDate = @AppointmentDate , PaidFees = @PaidFees, CreatedByUserID = @CreatedByUserID
,IsLocked = @IsLocked, RetakeTestApplicationID = @RetakeTestApplicationID WHERE TestAppointmentID = @TestAppointmentID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID",TestAppointmentID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);
            if (RetakeTestApplicationID == -99)
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);
            }
            command.Parameters.AddWithValue("@TestAppoID", TestAppointmentID);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                rowsAffected = 0;
            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }
        public static int GetTestID(int TestAppointmentID)
        {
            int TestTypeID = -99;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = "SELECT TestID FROM Tests WHERE TestAppointmentID = @TestAppointmentID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if(result != null && int.TryParse(result.ToString(), out int testId))
                {
                    TestTypeID = testId;
                }
            }
            catch (Exception ex)
            {
                TestTypeID = -99;
            }
            finally
            {
                connection.Close();
            }
            return TestTypeID;
        }
    }
}