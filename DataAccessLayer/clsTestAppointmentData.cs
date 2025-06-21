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
        public static DataTable GetTestTimeByLocalIDAndTestID(int localAppId, int testTypeId)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"SELECT TestAppointmentID AS [Appointment ID]
  ,AppointmentDate AS  [Appointment Date],PaidFees AS [Paid Fees] ,IsLocked
  FROM TestAppointments 
Where LocalDrivingLicenseApplicationID = @localAppId And TestTypeID = @testTypeId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@localAppId", localAppId);
            command.Parameters.AddWithValue("@testTypeId", testTypeId);
            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
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
        public static int AddNewTestAppointment(int testTypeId, int localAppId,
            DateTime appointmentDate, int fees, int userId, bool isLocked)
        {
            int newAppointmentId = -99;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"INSERT INTO TestAppointments
(TestTypeID,LocalDrivingLicenseApplicationID,AppointmentDate,PaidFees,CreatedByUserID,IsLocked)
VALUES ( @testTypeId , @localAppId , @appointmentDate , @fees , @userId , @isLocked);  
SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@testTypeId", testTypeId);
            command.Parameters.AddWithValue("@localAppId", localAppId);
            command.Parameters.AddWithValue("@appointmentDate", appointmentDate);
            command.Parameters.AddWithValue("@fees", fees);
            command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.AddWithValue("@isLocked", isLocked);
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
        public static bool GetAppoById(int id, ref int testTypeID, ref int localAppID,
                ref DateTime appoitmentDate, ref decimal paidFees, ref int createdID, ref bool isLocked)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"SELECT TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked 
                             FROM TestAppointments WHERE TestAppointmentID = @id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    testTypeID = (int)reader["TestTypeID"];
                    localAppID = (int)reader["LocalDrivingLicenseApplicationID"];
                    appoitmentDate = (DateTime)reader["AppointmentDate"];
                    paidFees = (decimal)reader["PaidFees"];
                    createdID = (int)reader["CreatedByUserID"];
                    isLocked = (bool)reader["IsLocked"];
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
        public static bool UpdateTestAppointment(int TestAppoID,int TestTypeId, 
         int LDLAID, DateTime AppoitmentDate, int PaidFees,
         int CreatedById, bool IsLocked)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"UPDATE TestAppointments
SET TestTypeID = @TestTypeId ,LocalDrivingLicenseApplicationID = @LDLAID
,AppointmentDate = @AppoitmentDate ,PaidFees = @PaidFees,CreatedByUserID = @CreatedById
,IsLocked = @IsLocked WHERE TestAppointmentID = @TestAppoID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeId", TestTypeId);
            command.Parameters.AddWithValue("@LDLAID", LDLAID);
            command.Parameters.AddWithValue("@AppoitmentDate", AppoitmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedById", CreatedById);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);
            command.Parameters.AddWithValue("@TestAppoID", TestAppoID);
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
        public static bool IsExists(int LocalID)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = "SELECT DISTINCT x=1 FROM TestAppointments WHERE (LocalDrivingLicenseApplicationID = @LocalID AND IsLocked != 1)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalID", LocalID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                result = reader.HasRows;
            }
            catch (Exception ex)
            {
                result = false;
            }
            finally { connection.Close(); }
            return result;
        }
    }
}