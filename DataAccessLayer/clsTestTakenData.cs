using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class clsTestTakenData
    {      
        public static bool GetTestInfoByID(int TestID,ref int TestAppointmentID,ref bool TestResult,
           ref string Notes,ref int CreatedByUserID)
        {
            bool Isfouned = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"SELECT * FROM Tests WHERE TestID = @TestID";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@TestID", TestID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    TestResult = (bool)reader["TestResult"];
                    Notes = (reader["Notes"]== DBNull.Value)?"": reader["Notes"].ToString();
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    Isfouned = true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Isfouned = false;
            }
            finally { connection.Close(); }
            return Isfouned;
        }
        public static bool GetLastTestByPersonAndTestTypeAndLicenseClass(int PersonID,int LicenseClassID
            ,int TestTypeID,ref int TestID, ref int TestAppointmentID, ref bool TestResult,
           ref string Notes, ref int CreatedByUserID)
        {
            bool Isfouned = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"SELECT  top 1 Tests.TestID, 
                Tests.TestAppointmentID, Tests.TestResult, 
			    Tests.Notes, Tests.CreatedByUserID, Applications.ApplicantPersonID
                FROM            LocalDrivingLicenseApplications INNER JOIN
                                         Tests INNER JOIN
                                         TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                         Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
                WHERE        (Applications.ApplicantPersonID = @PersonID) 
                        AND (LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID)
                        AND ( TestAppointments.TestTypeID=@TestTypeID)
                ORDER BY Tests.TestAppointmentID DESC";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Isfouned = true;
                    TestID = (int)reader["TestID"];
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    TestResult = (bool)reader["TestResult"];
                    Notes =(reader["Notes"] == DBNull.Value)? "": (string)reader["Notes"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Isfouned = false;
            }
            finally
            {
                connection.Close();
            }
            return Isfouned;
        }

        public static DataTable GetAllTests()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = "SELECT * FROM Tests order by TestID";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                dt.Load(reader);
                reader.Close();
            }

            catch (Exception ex)
            {
                dt = null;
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
        public static int AddNewTest(int TestAppointmentID, bool TestResult,
            string Notes, int CreatedByUserID)
        {
            int newTestID = -99;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"INSERT INTO Tests ( TestAppointmentID, TestResult, 
Notes, CreatedByUserID) VALUES (@TestAppointmentID, @TestResult, @Notes, @CreatedByUserID);

UPDATE TestAppointments  SET IsLocked=1 where TestAppointmentID = @TestAppointmentID;
    SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            if (Notes != "")
            {
                command.Parameters.AddWithValue("@Notes", Notes); 
            }
            else
            {
                command.Parameters.AddWithValue("@notes", System.DBNull.Value);
            }
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            try
            {
                connection.Open();
                object Value = command.ExecuteScalar();
                newTestID = (Value != null && int.TryParse(Value.ToString(),out int resualt))? resualt : -99;
            }
            catch (Exception ex)
            {
                newTestID = -99;
            }
            finally
            {
                connection.Close();
            }
            return newTestID;
        }
        public static bool UpdateTest(int TestID,int TestAppointmentID,bool TestResult,
        string Notes, int CreatedByUserID)
        {
            int Affected = -99;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"UPDATE Tests
   SET TestAppointmentID = @TestAppointmentID ,TestResult = @TestResult
      ,Notes = @Notes ,CreatedByUserID = @CreatedByUserID
 WHERE TestID = @TestID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            command.Parameters.AddWithValue("@Notes", Notes);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@TestID", TestID);
            try
            {
                connection.Open();
                Affected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Affected = -99;
            }
            finally { connection.Close(); } 
            return (Affected>0);
        }
        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            byte PassedCount = 0;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"SELECT PassedTestCount = count(TestTypeID)
                         FROM Tests INNER JOIN
                         TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
						 where LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID and TestResult=1";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            try
            {
                connection.Open();
                object value = command.ExecuteScalar();
                PassedCount = (value != null && byte.TryParse(value.ToString(), out byte result)) ? result : (byte)0;
            }
            catch (Exception ex)
            {
                PassedCount = 0;
            }
            finally { connection.Close(); }
            return PassedCount;
        }


    } 
}
