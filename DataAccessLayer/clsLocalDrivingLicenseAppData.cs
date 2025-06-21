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
        public static DataTable GetAllLocalApp()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"SELECT 
    LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID AS [L.D.LAppID], 
    LicenseClasses.ClassName AS [Driving Class], 
    People.NationalNo,
    (People.FirstName + ' ' +
    People.SecondName + ' '+
    People.ThirdName + ' '+ 
    People.LastName) AS [FULL Name], 
    Applications.ApplicationDate,
     COUNT(CASE WHEN Tests.TestResult = 1 THEN 1 END) AS [Passed Tests], 
  CASE WHEN Applications.ApplicationStatus = 1 THEN 'New'
  WHEN Applications.ApplicationStatus = 2 THEN 'Canceled' 
  WHEN Applications.ApplicationStatus = 3 THEN 'Completed' END AS Status
FROM LocalDrivingLicenseApplications 
LEFT JOIN Applications 
    ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID 
LEFT JOIN LicenseClasses 
    ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID 
LEFT JOIN People 
    ON Applications.ApplicantPersonID = People.PersonID 
LEFT JOIN TestAppointments 
    ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID 
LEFT JOIN Tests 
    ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
GROUP BY 
    LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID,
    LicenseClasses.ClassName,
    People.NationalNo,
    (People.FirstName + ' ' +
    People.SecondName + ' '+
    People.ThirdName + ' '+ 
    People.LastName),
    Applications.ApplicationDate,
    Applications.ApplicationStatus";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                dt.Load(reader);
                reader.Close();
            }
            catch (SqlException ex)
            {
                dt = null;
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
        public static bool GetLocalAppByID(int LocalAppID,ref int AppID,ref int LicID)
        {
            bool Isfound = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"SELECT ApplicationID ,LicenseClassID FROM LocalDrivingLicenseApplications 
        WHERE LocalDrivingLicenseApplicationID = @ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", LocalAppID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    AppID = (int)reader["ApplicationID"];
                    LicID = (int)reader["LicenseClassID"];
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
                Isfound = false;
            }
            finally
            {
                connection.Close();
            }
            return Isfound;
        }
        public static bool IsThisAppExist(int PersonID,int ClassID)
        {
            bool IsExist = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"SELECT X=1 From LocalDrivingLicenseApplications INNER JOIN Applications ON LocalDrivingLicenseApplications.ApplicationID
            = Applications.ApplicationID WHERE ApplicantPersonID = @PersonID AND ApplicationStatus != 2 AND LicenseClassID= @ClassID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@ClassID", ClassID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                IsExist = reader.HasRows;
            }
            catch (SqlException ex)
            {
                IsExist = false;
            }
            finally
            {
                connection.Close();
            }
            return IsExist ;
        }
        public static int AddNewLocalDrivingLicenseApp(int AppID,int ClassID)
        {
            int LocalAppID = -99;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"INSERT INTO LocalDrivingLicenseApplications
           (ApplicationID,LicenseClassID) VALUES(@AppID,@ClassID); 
             SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AppID", AppID);
            command.Parameters.AddWithValue("@ClassID", ClassID);
            try
            {
                connection.Open();
                object Value = command.ExecuteScalar();
                LocalAppID = (Value!=null &&int.TryParse(Value.ToString(),out int result)?result:-99);
            }
            catch (SqlException ex)
            {
                LocalAppID = -99;
            }
            finally
            {
                connection.Close();
            }
            return LocalAppID;
        }
        public static bool UpdateLocalDrivingApp(int Id,int AppID, int ClassID)
        {
            int Affcted = -99;
            SqlConnection connection = new SqlConnection( DataSetting.ConnctionName);
            string query = @"UPDATE LocalDrivingLicenseApplications
   SET ApplicationID = @AppID
      ,LicenseClassID = @ClassID
 WHERE  LocalDrivingLicenseApplicationID = @Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", Id);
            command.Parameters.AddWithValue("@AppID", AppID);
            command.Parameters.AddWithValue("@ClassID", ClassID);
            try
            {
                connection.Open();
                Affcted = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Affcted = -99;
            }finally {connection.Close(); }
            return (Affcted > 0);
        }
        public static bool DeleteLocalApp(int Id)
        {
            int Affcted = -99;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"DECLARE @appID INT;
SELECT @appID = ApplicationID FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @Id;
DELETE FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @Id;
DELETE FROM Applications  WHERE ApplicationID = @appID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", Id);
            try
            {
                connection.Open();
                Affcted = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Affcted = -99;
            }
            finally { connection.Close(); }
            return (Affcted > 0);
        }
    }
}
