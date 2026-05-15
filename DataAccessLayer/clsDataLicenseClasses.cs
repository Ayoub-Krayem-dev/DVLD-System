using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class clsDataLicenseClasses
    {
        public static bool Find(int LicenseClassID, ref string ClassName, ref string ClassDescription,ref byte AllowedAge,ref byte  validityLength, ref decimal Fees )
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"select * from LicenseClasses WHERE  LicenseClassID = @LicenseClassID; ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            bool isFound = false;
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    ClassName = (string)reader["ClassName"];
                    ClassDescription = (string)reader["ClassDescription"];
                    AllowedAge = (byte)reader["MinimumAllowedAge"];
                    validityLength = (byte)reader["DefaultValidityLength"];
                    Fees = (decimal)reader["ClassFees"];




                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }
        public static bool Find(string ClassName , ref  int LicenseClassID, ref string ClassDescription, ref byte AllowedAge, ref byte validityLength, ref decimal Fees)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"select * from LicenseClasses WHERE  ClassName = @ClassName; ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ClassName", ClassName);
            bool isFound = false;
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    LicenseClassID = (int)reader["LicenseClassID"];
                    ClassDescription = (string)reader["ClassDescription"];
                    AllowedAge = (byte)reader["MinimumAllowedAge"];
                    validityLength = (byte)reader["DefaultValidityLength"];
                    Fees = (decimal)reader["ClassFees"];




                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }
        public static DataTable GetAllLicensesClasses()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = "Select * from LicenseClasses ";

            SqlCommand command = new SqlCommand(query, connection);
            int rowsaffected = 0;
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

            }
            finally
            {
                connection.Close();
            }

            return dt;

        }
    }
}
