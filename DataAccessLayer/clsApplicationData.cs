using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DataAccessLayer
{
    public static class clsApplicationData
    {
        public static int AddNewApplication(int PersonId, DateTime Date, int AppTypeID,
            int Status, DateTime StatusDate, int Fees, int CreatedbyId)
        {
            int ID = -99;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"INSERT INTO Applications
(ApplicantPersonID,ApplicationDate,ApplicationTypeID,ApplicationStatus,LastStatusDate,PaidFees,CreatedByUserID)
             VALUES (@PersonID,@GETDATE1,@AppTypeID,@Status,@GETDATE2,@Fees,@UserID);
                             SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonId);
            command.Parameters.AddWithValue("@GETDATE1", Date);
            command.Parameters.AddWithValue("@AppTypeID", AppTypeID);
            command.Parameters.AddWithValue("@Status", Status);
            command.Parameters.AddWithValue("@GETDATE2", StatusDate);
            command.Parameters.AddWithValue("@Fees", Fees);
            command.Parameters.AddWithValue("@UserID", CreatedbyId);
            try
            {
                connection.Open();
                object Value = command.ExecuteScalar();
                ID = (Value != null && int.TryParse(Value.ToString(), out int result)) ? result : -99;
            }
            catch (SqlException ex)
            {
                ID = -99;
            }
            finally
            {
                connection.Close();
            }
            return ID;
        }
        public static bool GetApplicationByID(int ID, ref byte status, ref decimal fees,
            ref int type, ref DateTime Date, ref DateTime StatusDate
            , ref int CreatedBy, ref int personid)
        {
            bool IsFouned = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"SELECT ApplicationID,ApplicantPersonID,ApplicationDate,ApplicationTypeID,
ApplicationStatus AS Status,LastStatusDate
 ,PaidFees,CreatedByUserID FROM Applications WHERE ApplicationID = @ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    personid = (int)reader["ApplicantPersonID"];
                    Date = (DateTime)reader["ApplicationDate"];
                    type = (int)reader["ApplicationTypeID"];
                    status = (byte)reader["Status"];
                    StatusDate = (DateTime)reader["LastStatusDate"];
                    fees = (decimal)reader["PaidFees"];
                    CreatedBy = (int)reader["CreatedByUserID"];
                    IsFouned = true;
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                IsFouned = false;
            }
            finally
            {
                connection.Close();
            }
            return IsFouned;
        }
        public static bool UpdateApplication(int ID, DateTime statusdate)
        {
            int rowsAffected = -99;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"UPDATE Applications
                SET LastStatusDate = @statusdate 
        WHERE  ApplicationID = @ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@statusdate", statusdate);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                rowsAffected = -99;
            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }
        public static bool CancelApplication(int ID, DateTime statusdate)
        {
            int rowsAffected = -99;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"UPDATE Applications
                SET ApplicationStatus = 2 ,LastStatusDate = @statusdate 
        WHERE  ApplicationID = @ID AND ApplicationStatus = 1";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@statusdate", statusdate);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                rowsAffected = -99;
            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }
        public static bool CompleteApplication(int ID, DateTime statusdate)
        {
            int rowsAffected = -99;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"UPDATE Applications
                SET ApplicationStatus = 3 ,LastStatusDate = @statusdate 
        WHERE  ApplicationID = @ID AND ApplicationStatus = 1";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@statusdate", statusdate);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                rowsAffected = -99;
            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }
        public static bool GetApplicationIDByPersonID(int personId, ref int ID, ref byte status, ref decimal fees, ref int type,
                ref DateTime date, ref DateTime statusDate, ref int createdbyId)
        {
            bool IsFouned = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"SELECT * FROM Applications WHERE ApplicantPersonID = @personId AND 
ApplicationTypeID = 9 AND ApplicationStatus = 1";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@personId", personId);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ID = (int)reader["ApplicationID"];
                    status = 1; // New Application
                    fees = (decimal)reader["PaidFees"];
                    type = 9;
                    date = (DateTime)reader["ApplicationDate"];
                    statusDate = (DateTime)reader["LastStatusDate"];
                    createdbyId = (int)reader["CreatedByUserID"];
                    IsFouned = true;
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                IsFouned = false;
            }
            finally
            {
                connection.Close();
            }
            return IsFouned;
        }
    }
}
