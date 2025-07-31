using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class clsTestTypeData
    {
        public static bool GetTestTypeInfoByID(int TestTypeID, ref string TestTypeTitle, 
            ref string TestDescription,ref float TestFees)
        {
            bool Isfounded= false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = "SELECT * FROM TestTypes WHERE TestTypeID = @id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", TestTypeID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    TestTypeTitle = reader["TestTypeTitle"].ToString();
                    TestDescription = reader["TestTypeDescription"].ToString();
                    TestFees = Convert.ToSingle(reader["TestTypeFees"]);
                    Isfounded = true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                clsLogger.LogEvent(ex);
                Isfounded =false;
            }
            finally { connection.Close(); }
            return Isfounded;
        }
        public static DataTable GetAllTestTypes()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);

            string query = "SELECT * FROM TestTypes order by TestTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                clsLogger.LogEvent(ex);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }
        public static bool UpdateTestType (int TestTypeID, string TestTypeTitle,
            string TestDescription, float TestFees)
        {
            int IsUpdate = -99;
            SqlConnection connection = new SqlConnection( DataSetting.ConnctionName);
            string query = @"UPDATE TestTypes
   SET TestTypeTitle = @TestTypeTitle
      ,TestTypeDescription = @TestTypeDescription
      ,TestTypeFees = @TestTypeFees
 WHERE TestTypeID = @TestTypeID";
            SqlCommand command= new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
            command.Parameters.AddWithValue("@TestTypeDescription", TestDescription);
            command.Parameters.AddWithValue("@TestTypeFees", TestFees);
            try
            {
                connection.Open();
                IsUpdate = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                clsLogger.LogEvent(ex);
                IsUpdate = -99;
            }finally { connection.Close(); }
            return (IsUpdate > 0);  
        }
    }
}
