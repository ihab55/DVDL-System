using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class clsTestTakenData
    {
        public static int AddNewTestTaken(int testAppoID, bool testResult,
            string notes, int createdById)
        {
            int newTestID = -99;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"INSERT INTO TestTaken ( TestAppointmentID, TestResult, 
Notes, CreatedByUserID) VALUES (@testAppoID, @testResult, @notes, @CreatedById);
    SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@testAppoID", testAppoID);
            command.Parameters.AddWithValue("@testResult", testResult);
            if (notes != "")
            {
                command.Parameters.AddWithValue("@notes", notes); 
            }
            else
            {
                command.Parameters.AddWithValue("@notes", System.DBNull.Value);
            }
            command.Parameters.AddWithValue("@CreatedById", createdById);
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
        public static bool UpdateTestTaken(int id,int testAppoId,bool testResualt,
        string notes, int createdByid)
        {
            int Affrcted = -99;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"UPDATE Tests
   SET TestAppointmentID = @testAppoId ,TestResult = @testResualt
      ,Notes = @notes ,CreatedByUserID = @createdByid
 WHERE TestID = @id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@testAppoId", testAppoId);
            command.Parameters.AddWithValue("@testResualt", testResualt);
            command.Parameters.AddWithValue("@notes", notes);
            command.Parameters.AddWithValue("@createdByid", createdByid);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                connection.Open();
                Affrcted = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Affrcted = -99;
            }
            finally { connection.Close(); } 
            return (Affrcted>0);
        }
        public static bool GetTestTakenById(int id,ref int testAppoID,ref bool testResult,
           ref string notes,ref int createdById)
        {
            bool Isfouned = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = "SELECT TestAppointmentID ,TestResult ,Notes ,CreatedByUserID FROM Tests WHERE TestID = @id";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    testAppoID = (int)reader["TestAppointmentID"];
                    testResult = (bool)reader["TestResult"];
                    notes = reader["Notes"].ToString();
                    createdById = (int)reader["CreatedByUserID"];
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
        
        public static int GetTestPassByAppID(int LDLC)
        {
            int PasTest = -99;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"SELECT COUNT(CASE WHEN TestResult = 1 THEN 1 END) FROM Tests INNER JOIN TestAppointments ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
WHERE TestAppointments.LocalDrivingLicenseApplicationID = @LDLC";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@LDLC", LDLC);
            try
            {
                connection.Open();
                object value = command.ExecuteScalar();
                PasTest = (value != null && int.TryParse(value.ToString(), out int result)) ? result : -99;
            }
            catch (Exception ex)
            {
                PasTest = -99;
            }
            finally { connection.Close(); }
            return PasTest;
        }
    } 
}
