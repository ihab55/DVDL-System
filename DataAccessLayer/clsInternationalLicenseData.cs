using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class clsInternationalLicenseData
    {
        public static DataTable GetAllIntLicense()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"SELECT InternationalLicenseID AS [Int.License ID],ApplicationID AS [Application ID] ,DriverID AS [Driver ID]
,IssuedUsingLocalLicenseID AS [L.License ID],IssueDate AS [Issue Date] ,ExpirationDate AS [Expiration Date]
,IsActive AS [Is Active] FROM InternationalLicenses";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
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
        public static DataTable GetAllInternationalLicenseByPersonID(int PersonID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"SELECT InternationalLicenseID AS [Int.License ID],ApplicationID AS [Application ID] 
,IssuedUsingLocalLicenseID AS [L.License ID],IssueDate AS [Issue Date] ,ExpirationDate AS [Expiration Date]
,IsActive AS [Is Active] FROM InternationalLicenses INNER JOIN Drivers ON Drivers.DriverID = InternationalLicenses.DriverID
WHERE Drivers.PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                dt.Load(reader);
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
            
        public static bool IsExistsByLocalLicense(int LocalLicenseID)
        {
            bool isExists = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"SELECT X=1 FROM InternationalLicenses WHERE IssuedUsingLocalLicenseID = @LocalLicenseID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalLicenseID", LocalLicenseID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isExists = reader.HasRows;
            }
            catch (Exception ex)
            {
                isExists = false;
            }
            finally
            {
                connection.Close();
            }
            return isExists;
        }
        public static int AddNewInternationalLicense(
            int AppId, int DriverId, int LocalLicense, DateTime IssueDate,
            DateTime ExpirationDate, bool IsActive, int CreatbyID)
        {
            int InternationalLicenseID = -99;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"INSERT INTO InternationalLicenses (ApplicationID, DriverID, 
IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID)
       VALUES (@AppId, @DriverId, @LocalLicense, @IssueDate, @ExpirationDate, @IsActive, @CreatedByUser);
       SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AppId", AppId);
            command.Parameters.AddWithValue("@DriverId", DriverId);
            command.Parameters.AddWithValue("@LocalLicense", LocalLicense);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@CreatedByUser", CreatbyID);
            try
            {
                connection.Open();
                object value = command.ExecuteScalar();
                InternationalLicenseID = (value != null && int.TryParse(value.ToString(), out int result)) ? result : -99;
            }
            catch (Exception ex)
            {
                InternationalLicenseID = -99;
            }
            finally
            {
                connection.Close();
            }
            return InternationalLicenseID;
        }
        public static bool GetInternationalLicenseByLocalID(int LicenseId, ref int internationalLicenseId, 
            ref int appId, ref int driverId,  ref DateTime issueDate, ref DateTime expirationDate, 
            ref bool isActive, ref int createdByUserId)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"SELECT InternationalLicenseID, ApplicationID, DriverID, 
IssueDate, ExpirationDate, IsActive, CreatedByUserID FROM InternationalLicenses 
WHERE IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", LicenseId);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    internationalLicenseId = (int)reader["internationalLicenseId"];
                    appId = (int)reader["ApplicationID"];
                    driverId = (int)reader["DriverID"];
                    issueDate = (DateTime)reader["IssueDate"];
                    expirationDate = (DateTime)reader["ExpirationDate"];
                    isActive = (bool)reader["IsActive"];
                    createdByUserId = (int)reader["CreatedByUserID"];
                    isFound = true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }
        public static bool GetInternationalLicenseByID(int InternationalLicenseID, ref int AppId, ref int DriverId, ref int LocalLicense,
            ref DateTime IssueDate, ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"SELECT ApplicationID, DriverID, IssuedUsingLocalLicenseID, 
IssueDate, ExpirationDate, IsActive, CreatedByUserID FROM InternationalLicenses 
WHERE InternationalLicenseID = @InternationalLicenseID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    AppId = (int)reader["ApplicationID"];
                    DriverId = (int)reader["DriverID"];
                    LocalLicense = (int)reader["IssuedUsingLocalLicenseID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    IsActive = (bool)reader["IsActive"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    isFound = true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }
        public static bool UpdateInternationalLicense(int InternationalLicenseID, int AppId, int DriverId, int LocalLicense, DateTime IssueDate,
            DateTime ExpirationDate, bool IsActive, int UpdatedByUserID)
        {
            int isUpdated = -99;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"UPDATE InternationalLicenses
   SET ApplicationID = @AppId ,DriverID = @DriverId ,IssuedUsingLocalLicenseID = @LocalLicense
,IssueDate = @IssueDate , ExpirationDate = @ExpirationDate ,IsActive = @IsActive ,
CreatedByUserID = @UpdatedByUserID WHERE InternationalLicenseID = @InternationalLicenseID ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AppId", AppId);
            command.Parameters.AddWithValue("@DriverId", DriverId);
            command.Parameters.AddWithValue("@LocalLicense", LocalLicense);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@UpdatedByUserID", UpdatedByUserID);
            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
            try
            {
                connection.Open();
                isUpdated = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                isUpdated = -99;
            }
            finally
            {
                connection.Close();
            }
            return (isUpdated>0);
        }
        public static bool DeleteInternationalLicense(int InternationalLicenseID)
        {
            int isDeleted = -99;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"DELETE FROM InternationalLicenses WHERE InternationalLicenseID = @InternationalLicenseID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
            try
            {
                connection.Open();
                isDeleted = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                isDeleted = -99;
            }
            finally
            {
                connection.Close();
            }
            return (isDeleted > 0);
        }
    } 
}
