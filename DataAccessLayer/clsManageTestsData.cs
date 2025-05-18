using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class clsManageTestsData
    {
        public static DataTable GetAllManageTests()
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string qeury = "SELECT ID = TestTypeID ,Title = TestTypeTitle ,Description = TestTypeDescription ,Fees = TestTypeFees FROM TestTypes";
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
                dataTable = null;
            }
            finally { connection.Close(); }
            return dataTable;
        }
        public static bool UpdateManageTestType(int id, string title, string description, decimal fees)
        {
            int result = 0;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = @"UPDATE TestTypes
             SET 
             TestTypeTitle = @TestTypeTitle
            ,TestTypeDescription = @TestTypeDescription
            ,TestTypeFees = @TestTypeFees
             WHERE TestTypeID = @TestTypeID";
            SqlCommand Command = new SqlCommand(query, connection);
            Command.Parameters.AddWithValue("@TestTypeID", id);
            Command.Parameters.AddWithValue("@TestTypeTitle", title);
            Command.Parameters.AddWithValue("@TestTypeDescription", description);
            Command.Parameters.AddWithValue("@TestTypeFees", fees);
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
            return (result > 0);
        }
        public static bool GetManageTestByID(int id, ref string title,ref string description ,ref decimal fees)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = "SELECT * FROM TestTypes WHERE TestTypeID = @TestTypeID";
            SqlCommand Command = new SqlCommand(query, connection);
            Command.Parameters.AddWithValue("@TestTypeID", id);
            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    title = reader["TestTypeTitle"].ToString();
                    description = reader["TestTypeDescription"].ToString();
                    fees = (decimal)reader["TestTypeFees"];
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
