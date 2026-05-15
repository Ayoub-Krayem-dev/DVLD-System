using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class clsDataInternationalLicense
    {

        public static bool Find(int internationalLicenseID, ref int applicationID, ref int driverID,
            ref int issuedUsingLocalLicenseID, ref DateTime issueDate, ref DateTime expirationDate, ref bool isActive, ref int createdByUserID)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"select * FROM InternationalLicenses WHERE internationalLicenseID = @internationalLicenseID; ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@internationalLicenseID", internationalLicenseID);
            bool isFound = false;
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    applicationID = (int)reader["applicationID"];
                    driverID = (int)reader["driverID"];
                    issuedUsingLocalLicenseID = (int)reader["issuedUsingLocalLicenseID"];
                    issueDate = (DateTime)reader["issueDate"];
                    expirationDate = (DateTime)reader["expirationDate"];
                    isActive = (bool)reader["isActive"];
                    createdByUserID = (int)reader["createdByUserID"];



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


        public static int AddNewLicense( int applicationID, int driverID, int issuedUsingLocalLicenseID,
            DateTime issueDate, DateTime expirationDate, bool isActive, int createdByUserID)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"

                 Update InternationalLicenses 
                               set IsActive=0
                               where DriverID=@DriverID;

                Insert into InternationalLicenses( applicationID,driverID,issuedUsingLocalLicenseID,issueDate,expirationDate,isActive,createdByUserID)
                values(@applicationID,@driverID,@issuedUsingLocalLicenseID,@issueDate,@expirationDate,@isActive,@createdByUserID)
                SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@applicationID", applicationID);
            command.Parameters.AddWithValue("@driverID", driverID);
            command.Parameters.AddWithValue("@issuedUsingLocalLicenseID", issuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@issueDate", issueDate);
            command.Parameters.AddWithValue("@expirationDate", expirationDate);
            command.Parameters.AddWithValue("@isActive", isActive);
            command.Parameters.AddWithValue("@createdByUserID", createdByUserID);






            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int AppID))
                {
                    ID = AppID
                        ;
                }
            }

            catch (Exception ex)
            {

            }

            finally
            {
                connection.Close();
            }

            return ID;

        
        }

        public static DataTable GetLicenseHistory(int ID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"select  l.InternationalLicenseID,l.ApplicationID,l.IssuedUsingLocalLicenseID,l.IssueDate, l.ExpirationDate ,l.IsActive from InternationalLicenses l 
                            inner join Drivers d on d.DriverID = l.DriverID 
                            inner join People p  on p.PersonID = d.PersonID 
                            where p.PersonID = @ID ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);
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

        public static bool IsThereInternationalLicenseActive(int DriverID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"select I.IsActive from InternationalLicenses I where I.DriverID = @DriverID and I.IsActive = 1 and getdate() between IssueDate and  ExpirationDate ";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    isFound = true;
                }
                reader.Close();
            }

            catch (Exception ex)
            {
                isFound = false;

            }

            finally
            {
                connection.Close();
            }

            return isFound;
        }

      

        public static DataTable GetAllInternationalLicense()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = "select InternationalLicenseID,ApplicationID,DriverID,IssuedUsingLocalLicenseID as LocalLicenseID,IssueDate,ExpirationDate,IsActive from InternationalLicenses";

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

        public static DataTable FilterByInt(string Column, int value)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString); 
            if (Column != "DriverID" && Column != "IssuedUsingLocalLicenseID" && Column !="InternationalLicenseID" && Column != "ApplicationID")
            {
                return dt;
            }
            string query = $@"
 								select InternationalLicenseID,ApplicationID,DriverID,IssuedUsingLocalLicenseID as 
                                LocalLicenseID,ExpirationDate,IsActive from InternationalLicenses where {Column} = @Value";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@value", value);


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
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return dt;


        }
    }
}
