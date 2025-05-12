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

        public static DataTable GetAllApplicationTypes()
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string qeury = "SELECT ApplicationTypeID AS ID ,ApplicationTypeTitle AS Title,ApplicationFees As Fees FROM ApplicationTypes";
            SqlCommand sqlCommand = new SqlCommand(qeury, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                dataTable.Load(reader);
                reader.Close();
            }
            catch (Exception ex) {
                dataTable = null;
            }finally {connection.Close();}
            return dataTable;
        }
        public static bool UpdateApplicationType(int id, string title, decimal fees)
        {
            int result = 0;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = "UPDATE ApplicationTypes SET ApplicationTypeTitle = @ApplicationTypeTitle, ApplicationFees = @ApplicationFees WHERE ApplicationTypeID = @ApplicationTypeID";
            SqlCommand Command = new SqlCommand(query, connection);
            Command.Parameters.AddWithValue("@ApplicationTypeID", id);
            Command.Parameters.AddWithValue("@ApplicationTypeTitle", title);
            Command.Parameters.AddWithValue("@ApplicationFees", fees);
            try
            {
                connection.Open();
               result = Command.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                result = 0;
            }
            finally { connection.Close(); }
            return (result >0);
        }
        public static bool GetApplicationTypesByID(int id,ref string title,ref decimal fees)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = "SELECT * FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";
            SqlCommand Command = new SqlCommand(query, connection);
            Command.Parameters.AddWithValue("@ApplicationTypeID", id);
            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    title = reader["ApplicationTypeTitle"].ToString();
                    fees = (decimal)reader["ApplicationFees"];
                    result = true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                result = false;
            }
            finally { connection.Close(); }
            return result;
        }
        
    }
}
