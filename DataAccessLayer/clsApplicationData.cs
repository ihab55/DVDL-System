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
        public static int AddNewApplication(int PersonId,DateTime Date,int AppTypeID,
            string Status,DateTime StatusDate,int Fees,int CreatedbyId)
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
            command.Parameters.AddWithValue("@Status", 1);
            command.Parameters.AddWithValue("@GETDATE2", StatusDate);
            command.Parameters.AddWithValue("@Fees", Fees);
            command.Parameters.AddWithValue("@UserID", CreatedbyId);
            try
            {
                connection.Open();
                object Value = command.ExecuteScalar();
                ID = (Value != null && int.TryParse(Value.ToString(),out int result)) ? result : -99;
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
        public static bool GetApplicationByID(int ID ,ref string status,ref decimal fees,
            ref int type,ref DateTime Date, ref DateTime StatusDate
            ,ref int CreatedBy,ref int personid)
        {
            bool IsFouned = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"SELECT ApplicationID,ApplicantPersonID,ApplicationDate,ApplicationTypeID,CASE 
WHEN ApplicationStatus = 1 THEN 'New' WHEN ApplicationStatus = 2 THEN 'Cancel'WHEN ApplicationStatus=3 THEN 'Completeted' END AS Status,LastStatusDate
 ,PaidFees,CreatedByUserID FROM Applications WHERE ApplicationID = @ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open ();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    personid = (int)reader["ApplicantPersonID"];
                    Date = (DateTime)reader["ApplicationDate"];
                    type = (int)reader["ApplicationTypeID"];
                    status = reader["Status"].ToString();
                    StatusDate = (DateTime)reader["LastStatusDate"];
                    fees = (decimal)reader["PaidFees"];
                    CreatedBy = (int)reader["CreatedByUserID"];
                    IsFouned = true;
                }
                reader.Close ();
            }
            catch (SqlException ex)
            {
                IsFouned=false;
            }
            finally
            {
                connection.Close();
            }
            return IsFouned;
        }
        public static bool UpdateApplication(int ID,DateTime statusdate)
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
            return (rowsAffected>0);
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
    }
}
