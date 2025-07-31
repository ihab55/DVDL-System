using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class clsLicenseClassData
    {
        public static bool GetLicenseClassInfoByID(int LicenseClassID, ref string ClassName, 
            ref string ClassDescription
    , ref byte MinimumAllowedAge, ref byte DefaultValidityLength, ref float ClassFees)
        {
            bool IsFouned = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = "SELECT ClassName,ClassDescription,MinimumAllowedAge,DefaultValidityLength,ClassFees FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ClassName = (string)reader["ClassName"];
                    ClassDescription = (string)reader["ClassDescription"];
                    MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                    DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                    ClassFees = Convert.ToSingle(reader["ClassFees"]);
                    IsFouned = true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                clsLogger.LogEvent(ex);
                IsFouned = false;
            }
            finally { connection.Close(); }
            return IsFouned;
        }
        public static bool GetLicenseClassInfoByClassName(string ClassName,ref int LicenseClassID, 
            ref string ClassDescription
    , ref byte MinimumAllowedAge, ref byte DefaultValidityLength, ref float ClassFees)
        {
            bool IsFouned = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = "SELECT LicenseClassID,ClassDescription,MinimumAllowedAge,DefaultValidityLength,ClassFees FROM LicenseClasses WHERE ClassName = @ClassName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClassName", ClassName);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    LicenseClassID = (int)reader["LicenseClassID"];
                    ClassDescription = (string)reader["ClassDescription"];
                    MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                    DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                    ClassFees = Convert.ToSingle(reader["ClassFees"]);
                    IsFouned = true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                clsLogger.LogEvent(ex);
                IsFouned = false;
            }
            finally { connection.Close(); }
            return IsFouned;
        }
        public static DataTable GetAllLicenseClasses()
        {
            DataTable dtAllLicenseClass = new DataTable();
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = "SELECT * FROM LicenseClasses order by ClassName";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                dtAllLicenseClass.Load(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                clsLogger.LogEvent(ex);
                dtAllLicenseClass = null;
            }
            finally { connection.Close(); }
            return dtAllLicenseClass;
        }
        public static int AddNewLicenseClass(string ClassName, string ClassDescription, 
            byte MinimumAllowedAge, byte DefaultValidityLength, float ClassFees)
        {
            int LicenseClassID = -99;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"INSERT INTO LicenseClasses (ClassName,ClassDescription,MinimumAllowedAge,DefaultValidityLength,ClassFees)
                VALUES (@ClassName,@ClassDescription,@MinimumAllowedAge,@DefaultValidityLength,@ClassFees);
                SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClassName", ClassName);
            command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
            command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
            command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
            command.Parameters.AddWithValue("@ClassFees", ClassFees);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                LicenseClassID = (result != null && int.TryParse(result.ToString(), out int InsertedID))?InsertedID:-99;
            }
            catch (Exception ex)
            {
                clsLogger.LogEvent(ex);
                LicenseClassID = -99;
            }
            finally { connection.Close(); }
            return LicenseClassID;
        }
        public static bool UpdateLicenseClass(int LicenseClassID, string ClassName, string ClassDescription, 
            byte MinimumAllowedAge, byte DefaultValidityLength, float ClassFees)
        {
            bool IsUpdated = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"UPDATE LicenseClasses SET ClassName = @ClassName, ClassDescription = @ClassDescription,
                MinimumAllowedAge = @MinimumAllowedAge, DefaultValidityLength = @DefaultValidityLength, ClassFees = @ClassFees
                WHERE LicenseClassID = @LicenseClassID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@ClassName", ClassName);
            command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
            command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
            command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
            command.Parameters.AddWithValue("@ClassFees", ClassFees);
            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                IsUpdated = (rowsAffected > 0);
            }
            catch (Exception ex)
            {
                clsLogger.LogEvent(ex);
                IsUpdated = false;
            }
            finally { connection.Close(); }
            return IsUpdated;
        }

    }
}
