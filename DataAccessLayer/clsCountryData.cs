using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    static public class clsCountryData
    {
        static public DataTable GetAllCountry()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = "SELECT * FROM Countries";
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
                // Handle exception
                return null;
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
        static public bool GetCountryById(int id,ref string CountryName)
        {
            bool Isfounded= false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = "SELECT * FROM Countries WHERE CountryID = @CountryID";
            SqlCommand command= new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryID",id);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    CountryName = (string)reader["CountryName"];
                    Isfounded = true;
                }
                reader.Close();
            }
            catch (Exception ex) { 
                Isfounded = false;
            }finally { connection.Close(); }
            return Isfounded;
        }
    }
}
