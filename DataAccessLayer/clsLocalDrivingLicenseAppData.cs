using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public static class clsLocalDrivingLicenseAppData
    {
        public static bool GetLocalDrivingLicenseApplicationInfoByID
            (int LocalDrivingLicenseApplicationID,ref int ApplicationID
            ,ref int LicenseClassID)
        {
            bool Isfound = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"SELECT * FROM LocalDrivingLicenseApplications 
        WHERE LocalDrivingLicenseApplicationID = @ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", LocalDrivingLicenseApplicationID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ApplicationID = (int)reader["ApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
                    Isfound = true;
                }
                else
                {
                    Isfound = false;
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                clsLogger.LogEvent(ex);
                Isfound = false;
            }
            finally
            {
                connection.Close();
            }
            return Isfound;
        }
        public static bool GetLocalDrivingLicenseApplicationInfoByApplicationID
            (int ApplicationID,ref int LocalDrivingLicenseApplicationID
            , ref int LicenseClassID)
        {
            bool Isfound = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"SELECT * FROM LocalDrivingLicenseApplications 
        WHERE ApplicationID = @ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ApplicationID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
                    Isfound = true;
                }
                else
                {
                    Isfound = false;
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                clsLogger.LogEvent(ex);
                Isfound = false;
            }
            finally
            {
                connection.Close();
            }
            return Isfound;
        }
        public static DataTable GetAllLocalDrivingLicenseApplications()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);

            string query = @"SELECT *
                              FROM LocalDrivingLicenseApplications_View
                              order by ApplicationDate Desc";

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
                clsLogger.LogEvent(ex);
                dt = null;
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }
        public static int AddNewLocalDrivingLicenseApp(int ApplicationID,int LicenseClassID)
        {
            int LocalDrivingLicenseApplicationID = -99;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"INSERT INTO LocalDrivingLicenseApplications
           (ApplicationID,LicenseClassID) VALUES(@AppID,@ClassID); 
             SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AppID", ApplicationID);
            command.Parameters.AddWithValue("@ClassID", LicenseClassID);
            try
            {
                connection.Open();
                object Value = command.ExecuteScalar();
                LocalDrivingLicenseApplicationID = (Value!=null &&int.TryParse(Value.ToString(),out int result)?result:-99);
            }
            catch (SqlException ex)
            {
                clsLogger.LogEvent(ex);
                LocalDrivingLicenseApplicationID = -99;
            }
            finally
            {
                connection.Close();
            }
            return LocalDrivingLicenseApplicationID;
        }
        public static bool UpdateLocalDrivingLicenseApplication
            (int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID)
        {
            int Affcted = -99;
            SqlConnection connection = new SqlConnection( DataSetting.ConnctionName);
            string query = @"UPDATE LocalDrivingLicenseApplications
   SET ApplicationID = @AppID
      ,LicenseClassID = @ClassID
 WHERE  LocalDrivingLicenseApplicationID = @Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@AppID", ApplicationID);
            command.Parameters.AddWithValue("@ClassID", LicenseClassID);
            try
            {
                connection.Open();
                Affcted = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                clsLogger.LogEvent(ex);
                Affcted = -99;
            }finally {connection.Close(); }
            return (Affcted > 0);
        }
        public static bool DeleteLocalDrivingLicenseApplication
            (int LocalDrivingLicenseApplicationID)
        {
            int Affcted = -99;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"Delete LocalDrivingLicenseApplications 
                                where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            try
            {
                connection.Open();
                Affcted = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                clsLogger.LogEvent(ex);
                Affcted = -99;
            }
            finally { connection.Close(); }
            return (Affcted > 0);
        }

        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)

        {


            bool Result = false;

            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);

            string query = @" SELECT top 1 TestResult
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                            ORDER BY TestAppointments.TestAppointmentID desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && bool.TryParse(result.ToString(), out bool returnedResult))
                {
                    Result = returnedResult;
                }
            }

            catch (Exception ex)
            {

                clsLogger.LogEvent(ex);
                Result = false;
            }

            finally
            {
                connection.Close();
            }

            return Result;

        }
        public static bool DoesAttendTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)

        {


            bool IsFound = false;

            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);

            string query = @" SELECT top 1 Found=1
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                            ORDER BY TestAppointments.TestAppointmentID desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    IsFound = true;
                }
            }

            catch (Exception ex)
            {
                clsLogger.LogEvent(ex);
                IsFound = false;
            }

            finally
            {
                connection.Close();
            }

            return IsFound;

        }
        public static byte TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, int TestTypeID)

        {


            byte TotalTrialsPerTest = 0;

            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);

            string query = @" SELECT TotalTrialsPerTest = count(TestID)
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                       ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && byte.TryParse(result.ToString(), out byte Trials))
                {
                    TotalTrialsPerTest = Trials;
                }
            }

            catch (Exception ex)
            {
                clsLogger.LogEvent(ex);
            }

            finally
            {
                connection.Close();
            }

            return TotalTrialsPerTest;

        }

        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, int TestTypeID)

        {

            bool Result = false;

            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);

            string query = @" SELECT top 1 Found=1
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID 
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID)  
                            AND(TestAppointments.TestTypeID = @TestTypeID) and isLocked=0
                            ORDER BY TestAppointments.TestAppointmentID desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null)
                {
                    Result = true;
                }

            }

            catch (Exception ex)
            {
                clsLogger.LogEvent(ex);
            }

            finally
            {
                connection.Close();
            }

            return Result;

        }
    }
}
