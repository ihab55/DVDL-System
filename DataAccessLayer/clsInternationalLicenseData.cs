using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class clsInternationalLicenseData
    {
        public static int AddNewInternationalLicense(
            int AppId, int DriverId, int LocalLicense, DateTime IssueDate,
            DateTime ExpirationDate, bool IsActive, int CreatbyID)
        {
            int InternationalLicenseID = -99;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"INSERT INTO InternationalLicense (ApplicationID, DriverID, 
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
