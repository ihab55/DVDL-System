using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class clsLicenseClassData
    {
        public static bool GetLicenseClass(int ID,ref string ClassName,ref string Description
            ,ref byte MinimumAllowedAge,ref byte DefaultValidityLength,ref decimal Fees)
        {
            bool IsFouned = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnctionName);
            string query = "SELECT ClassName,ClassDescription,MinimumAllowedAge,DefaultValidityLength,ClassFees FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseClassID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ClassName =(string) reader["ClassName"];
                    Description =(string) reader["ClassDescription"];
                    MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                    DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                    Fees = (decimal)reader["ClassFees"];
                    IsFouned=true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IsFouned = false;
            }
            finally { connection.Close(); }
            return IsFouned;
        }
    }
}
