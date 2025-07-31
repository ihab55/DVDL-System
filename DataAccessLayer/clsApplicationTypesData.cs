using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class clsApplicationTypesData
    {
        public static bool GetApplicationTypesInfoByID(int ApplicationTypeID, ref string Title, ref float Fees)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = "SELECT * FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";
            SqlCommand Command = new SqlCommand(query, connection);
            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    Title = reader["ApplicationTypeTitle"].ToString();
                    Fees = Convert.ToSingle(reader["ApplicationFees"]);
                    result = true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                clsLogger.LogEvent(ex);
                result = false;
            }
            finally { connection.Close(); }
            return result;
        }
        public static DataTable GetAllApplicationTypes()
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string qeury = "SELECT * FROM ApplicationTypes";
            SqlCommand sqlCommand = new SqlCommand(qeury, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                dataTable.Load(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                clsLogger.LogEvent(ex);
                dataTable = null;
            }finally {connection.Close();}
            return dataTable;
        }
        public static bool UpdateApplicationType(int ApplicationTypeID, string Title, float Fees)
        {
            int result = 0;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = "UPDATE ApplicationTypes SET ApplicationTypeTitle = @ApplicationTypeTitle, ApplicationFees = @ApplicationFees WHERE ApplicationTypeID = @ApplicationTypeID";
            SqlCommand Command = new SqlCommand(query, connection);
            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            Command.Parameters.AddWithValue("@ApplicationTypeTitle", Title);
            Command.Parameters.AddWithValue("@ApplicationFees", Fees);
            try
            {
                connection.Open();
               result = Command.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                clsLogger.LogEvent(ex);
                result = 0;
            }
            finally { connection.Close(); }
            return (result >0);
        }
        
    }
}
