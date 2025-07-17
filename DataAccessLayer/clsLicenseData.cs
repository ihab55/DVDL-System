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
        public static bool GetLicenseInfoByID(int LicenseID, ref int ApplicationID, ref int DriverID,
            ref int LicenseClass, ref DateTime IssueDate, ref DateTime ExpirationDate
 , ref string Notes, ref float PaidFees, ref bool IsActive, ref byte IssueReason, ref int CreatedByUserID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"SELECT ApplicationID ,DriverID ,LicenseClass ,IssueDate ,ExpirationDate
 ,Notes ,PaidFees ,IsActive ,IssueReason ,CreatedByUserID
  FROM Licenses WHERE LicenseID = @LicenseID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    LicenseClass = (int)reader["LicenseClass"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    Notes = (reader["Notes"] == DBNull.Value) ? "" : reader["Notes"].ToString();
                    PaidFees = Convert.ToSingle(reader["PaidFees"]);
                    IsActive = (bool)reader["IsActive"];
                    IssueReason = (byte)reader["IssueReason"];
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
        public static DataTable GetDriverLicenses(int DriverID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"
 SELECT     
      Licenses.LicenseID, ApplicationID, LicenseClasses.ClassName, Licenses.IssueDate, 
Licenses.ExpirationDate, Licenses.IsActive FROM Licenses INNER JOIN
  LicenseClasses ON Licenses.LicenseClass = LicenseClasses.LicenseClassID
   where DriverID=@DriverID  Order By IsActive Desc, ExpirationDate Desc";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);
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
            , int LicenseClass, DateTime IssueDate, DateTime ExpirationDate,
            string Notes, float PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            int NewLicenseID = -99;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"INSERT INTO Licenses
 (ApplicationID ,DriverID ,LicenseClass ,IssueDate
 ,ExpirationDate ,Notes ,PaidFees ,IsActive ,IssueReason ,CreatedByUserID)
 VALUES (@ApplicationID, @DriverID, @LicenseClassID, @IssueDate , @ExpirationDate, @Notes,
 @PaidFees, @IsActive, @IssueReason, @CreatedByUserID);
 SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClass);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            if (Notes == "")
            {
                command.Parameters.AddWithValue("@Notes", System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Notes", Notes);
            }
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            try
            {
                connection.Open();
                object Value = command.ExecuteScalar();
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
            , int LicenseClass, DateTime IssueDate, DateTime ExpirationDate,
            string Notes, float PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            int IsAffected = -99;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"UPDATE Licenses SET ApplicationID = @ApplicationID
 ,DriverID = @DriverID ,LicenseClass = @LicenseClass ,IssueDate = @IssueDate ,
ExpirationDate = @ExpirationDate ,Notes = @Notes ,PaidFees = @PaidFees ,IsActive = @IsActive
,IssueReason = @IssueReason ,CreatedByUserID = @CreatedByUserID WHERE LicenseID = @LicenseID";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            if (Notes != "")
            {
                command.Parameters.AddWithValue("@Notes", System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Notes", Notes);
            }
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
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
        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {
            int LicenseID = -99;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"SELECT  Licenses.LicenseID
                            FROM Licenses INNER JOIN
                            Drivers ON Licenses.DriverID = Drivers.DriverID
                            WHERE  
                            Licenses.LicenseClass = @LicenseClass 
                            AND Drivers.PersonID = @PersonID
                            And IsActive=1;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClassID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    LicenseID = insertedID;
                }
            }
            catch (Exception ex)
            {
                LicenseID = -99;
            }
            finally
            {
                connection.Close();
            }
            return LicenseID;
        }
 
        public static bool DeActivateLicense(int LicenseID)
        {
            int IsAffected = -99;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"UPDATE Licenses SET IsActive = 0 WHERE LicenseID = @LicenseID";
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
