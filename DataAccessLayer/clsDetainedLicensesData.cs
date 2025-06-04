using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class clsDetainedLicensesData
    {
        public static int AddNewDetainedLicense(int LicenseID, DateTime DetainDate , 
            decimal FineFees, int CreatedByUserID, bool IsReleased, DateTime ReleaseDate,
            int ReleasedByUserID,int ReleaseApplicationID)
        {
            int DetainedLicenseID = -99;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"INSERT INTO DetainedLicenses (LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID)
                             VALUES (@LicenseID, @DetainDate, @FineFees, @CreatedByUserID, @IsReleased, @ReleaseDate, @ReleasedByUserID, @ReleaseApplicationID);
                             SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsReleased", IsReleased);
            if (IsReleased)
            {
                command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
                command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
                command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
            }
            else
            {
                command.Parameters.AddWithValue("@ReleaseDate", System.DBNull.Value);
                command.Parameters.AddWithValue("@ReleasedByUserID", System.DBNull.Value);
                command.Parameters.AddWithValue("@ReleaseApplicationID", System.DBNull.Value);
            }
            try {                 
                connection.Open();
                object value = command.ExecuteScalar();
                DetainedLicenseID = (value != null && int.TryParse(value.ToString(), out int result)) ? result : -99;
            }
            catch (Exception ex)
            {
                DetainedLicenseID = -99;
            }
            finally
            {
                connection.Close();
            }
            return DetainedLicenseID;
        }
        public static bool GetDetainedLicenseByID(int DetainedLicenseID, ref int LicenseID, ref DateTime DetainDate, ref decimal FineFees,
            ref int CreatedByUserID, ref bool IsReleased, ref DateTime ReleaseDate, ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"SELECT LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID 
                             FROM DetainedLicenses WHERE DetainedLicenseID = @DetainedLicenseID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DetainedLicenseID", DetainedLicenseID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    LicenseID = (int)reader["LicenseID"];
                    DetainDate = (DateTime)reader["DetainDate"];
                    FineFees = (decimal)reader["FineFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsReleased = (bool)reader["IsReleased"];
                    if (IsReleased)
                    {
                        ReleaseDate = (DateTime)reader["ReleaseDate"];
                        ReleasedByUserID = (int)reader["ReleasedByUserID"];
                        ReleaseApplicationID = (int)reader["ReleaseApplicationID"];
                    }
                    else
                    {
                        ReleaseDate = DateTime.MinValue;
                        ReleasedByUserID = -99;
                        ReleaseApplicationID = -99;
                    }
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
        public static bool UpdateDetainedLicense(int DetainedLicenseID, int LicenseID, DateTime DetainDate, decimal FineFees,
            int CreatedByUserID, bool IsReleased, DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            int rowsAffected = -99;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"UPDATE DetainedLicenses SET LicenseID = @LicenseID, DetainDate = @DetainDate, FineFees = @FineFees,
                             CreatedByUserID = @CreatedByUserID, IsReleased = @IsReleased, ReleaseDate = @ReleaseDate,
                             ReleasedByUserID = @ReleasedByUserID, ReleaseApplicationID = @ReleaseApplicationID
                             WHERE DetainedLicenseID = @DetainedLicenseID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DetainedLicenseID", DetainedLicenseID);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsReleased", IsReleased);
            if (IsReleased)
            {
                command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
                command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
                command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
            }
            else
            {
                command.Parameters.AddWithValue("@ReleaseDate", System.DBNull.Value);
                command.Parameters.AddWithValue("@ReleasedByUserID", System.DBNull.Value);
                command.Parameters.AddWithValue("@ReleaseApplicationID", System.DBNull.Value);
            }
            
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                rowsAffected = -99;
            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected>0);
        }
        public static bool DeleteDetainedLicense(int DetainedLicenseID)
        {
            int rowsAffected = -99;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"DELETE FROM DetainedLicenses WHERE DetainedLicenseID = @DetainedLicenseID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DetainedLicenseID", DetainedLicenseID);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                rowsAffected = -99;
            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }

    }
}
