using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public static class clsApplicationData
    {
        public static int AddNewApplication(int PersonID,decimal Fees,int UserID)
        {
            int ID = -99;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"INSERT INTO Applications
(ApplicantPersonID,ApplicationDate,ApplicationTypeID,ApplicationStatus,LastStatusDate,PaidFees,CreatedByUserID)
             VALUES (@PersonID,@GETDATE1,1,1,@GETDATE2,@Fees,@UserID);
                             SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@GETDATE1", DateTime.Now);
            command.Parameters.AddWithValue("@GETDATE2", DateTime.Now);
            command.Parameters.AddWithValue("@Fees", Fees);
            command.Parameters.AddWithValue("@UserID", UserID);
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
    }
}
