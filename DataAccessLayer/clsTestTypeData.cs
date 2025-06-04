using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class clsTestTypeData
    {
        public static bool GetTestTypeId(int id, ref string name, ref string descr
            ,ref decimal fees)
        {
            bool Isfounded= false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = "SELECT TestTypeTitle,TestTypeDescription,TestTypeFees FROM TestTypes WHERE TestTypeID = @id";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    name = reader["TestTypeTitle"].ToString();
                    descr = reader["TestTypeDescription"].ToString();
                    fees = (decimal)reader["TestTypeFees"];
                    Isfounded = true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Isfounded=false;
            }
            finally { connection.Close(); }
            return Isfounded;
        }
        public static bool UpdateFees (int id, int fees)
        {
            int IsUpdate = -99;
            SqlConnection connection = new SqlConnection( DataSetting.ConnctionName);
            string query = "UPDATE TestTypes SET TestTypeFees = @fees WHERE TestTypeID = @id";
            SqlCommand command= new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@fees", fees);
            try
            {
                connection.Open();
                IsUpdate = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                IsUpdate = -99;
            }finally { connection.Close(); }
            return (IsUpdate > 0);  
        }
    }
}
