using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class clsLicenseData
    {
        public static bool IsExists(int licenseId)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"SELECT X=1 FROM Licenses WHERE LicenseID = @LicenseID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", licenseId);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                IsFound = reader.HasRows;
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }
        public static bool IsExistsOrdinary(int licenseId)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"SELECT X=1 FROM Licenses WHERE LicenseID = @LicenseID AND LicenseClass = 3";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", licenseId);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                IsFound = reader.HasRows;
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }
        public static bool GetLicenseByLocalID(int LocalID,ref int licenseId, ref int appid, 
            ref int Driverid, ref int LicenClassId, ref DateTime issusedate, ref DateTime exptiondate
                , ref string notes, ref decimal paidfees, ref bool isactive, ref short issresson, ref int userid){
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"SELECT LicenseID ,Licenses.ApplicationID ,DriverID ,LicenseClass ,IssueDate ,ExpirationDate
,Notes ,PaidFees ,IsActive ,IssueReason ,CreatedByUserID
FROM Licenses LEFT JOIN LocalDrivingLicenseApplications ON LocalDrivingLicenseApplications.ApplicationID = 
Licenses.ApplicationID WHERE LocalDrivingLicenseApplicationID = @LocalID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalID", LocalID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    licenseId = (int)reader["LicenseID"];
                    appid = (int)reader["ApplicationID"];
                    Driverid = (int)reader["DriverID"];
                    LicenClassId = (int)reader["LicenseClass"];
                    issusedate = (DateTime)reader["IssueDate"];
                    exptiondate = (DateTime)reader["ExpirationDate"];
                    notes = (reader["Notes"] == DBNull.Value) ? "" : reader["Notes"].ToString();
                    paidfees = (decimal)reader["PaidFees"];
                    isactive = (bool)reader["IsActive"];
                    issresson = (byte)reader["IssueReason"];
                    userid = (int)reader["CreatedByUserID"];
                    IsFound = true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }
        public static DataTable GetAllLicenseWithPerson(int PersonID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"SELECT LicenseID AS [Lic.ID] , ApplicationID AS [App.ID], ClassName AS [Class Name],IssueDate AS [Issue Date] , 
ExpirationDate AS [Expiration Date], IsActive AS [Is Active] FROM Licenses INNER JOIN LicenseClasses 
ON LicenseClasses.LicenseClassID = Licenses.LicenseClass INNER JOIN Drivers ON Drivers.DriverID = Licenses.DriverID
WHERE Drivers.PersonID = @PersonID ;";
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
        public static int AddLicense(int ApplicationID, int DriverID
            , int LicenseClassID, DateTime IssueDate, DateTime ExpriationDate,
            string note, decimal paidfees, bool IsActive, short IssueResson, int CreatedByUserID)
        {
            int NewLicenseID = -99;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"INSERT INTO Licenses
 (ApplicationID ,DriverID ,LicenseClass ,IssueDate
 ,ExpirationDate ,Notes ,PaidFees ,IsActive ,IssueReason ,CreatedByUserID)
 VALUES (@ApplicationID, @DriverID, @LicenseClassID, @IssueDate , @ExpriationDate, @note,
 @paidfees, @IsActive, @IssueResson, @CreatedByUserID);
 SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpriationDate", ExpriationDate);
            if (note == "")
            {
                command.Parameters.AddWithValue("@note", System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@note", note);
            }
            command.Parameters.AddWithValue("@paidfees", paidfees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueResson", IssueResson);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            try
            {
                connection.Open();
                Object Value = command.ExecuteScalar();
                NewLicenseID = (Value != null && int.TryParse(Value.ToString(),out int result)) ? result : -99;
            }
            catch (Exception ex)
            {
                NewLicenseID = -99;
            }
            finally
            {
                connection.Close();
            }
                return NewLicenseID;
        }
        public static bool UpdateLicense(int LicenseID,int ApplicationID, int DriverID
            , int LicenseClassID, DateTime IssueDate, DateTime ExpriationDate,
            string note, decimal paidfees, bool IsActive, short IssueResson, int CreatedByUserID)
        {
            int IsAffected = -99;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"UPDATE Licenses SET ApplicationID = @ApplicationID
 ,DriverID = @DriverID ,LicenseClass = @LicenseClassID ,IssueDate = @IssueDate ,
ExpirationDate = @ExpriationDate ,Notes = @note ,PaidFees = @paidfees ,IsActive = @IsActive
,IssueReason = @IssueResson ,CreatedByUserID = @CreatedByUserID WHERE LicenseID = @LicenseID";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpriationDate", ExpriationDate);
            if (note != "")
            {
                command.Parameters.AddWithValue("@note", System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@note", note);
            }
            command.Parameters.AddWithValue("@paidfees", paidfees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueResson", IssueResson);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            try
            {
                connection.Open();
                IsAffected = command.ExecuteNonQuery();
            }catch(Exception ex)
            {
                IsAffected = -99;
            }
            finally
            {
                connection.Close();
            }
            return (IsAffected > 0);
        }
        public static bool GetLicenseByID(int LicenseID, ref int ApplicationID,ref int DriverID
            ,ref int LicenseClassID,ref DateTime IssueDate,ref DateTime ExpriationDate,
            ref string note,ref decimal paidfees,ref bool IsActive,ref short IssueResson,
            ref int CreatedByUserID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"SELECT ApplicationID ,DriverID ,LicenseClass
,IssueDate ,ExpirationDate ,Notes ,PaidFees ,IsActive
 ,IssueReason ,CreatedByUserID FROM Licenses WHERE LicenseID = @LicenseID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            try {                 
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    LicenseClassID = (int)reader["LicenseClass"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpriationDate = (DateTime)reader["ExpirationDate"];
                    note = (reader["Notes"] ==DBNull.Value)?"": reader["Notes"].ToString();
                    paidfees = (decimal)reader["PaidFees"];
                    IsActive = (bool)reader["IsActive"];
                    IssueResson = (byte)reader["IssueReason"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsFound = true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }
        public static bool DeleteLicense(int LicenseID)
        {
            int IsAffected = -99;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"DELETE FROM Licenses WHERE LicenseID = @LicenseID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            try
            {
                connection.Open();
                IsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                IsAffected = -99;
            }
            finally
            {
                connection.Close();
            }
            return (IsAffected > 0);
        }
   
    }
}
