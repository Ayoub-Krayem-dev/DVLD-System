using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class clsDataLocalDrivingApplicationLicense
    {

        public static bool Find(int LocalAppLicenseID, ref int ApplicationID,ref int LicenseClassID)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"select * from LocalDrivingLicenseApplications WHERE  LocalDrivingLicenseApplicationID = @LocalAppLicenseID; ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalAppLicenseID", LocalAppLicenseID);
            bool isFound = false;
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
                   

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


        public static int AddNewLocalDrivingApp(int ApplicationID,int ClassLicense)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"Insert into LocalDrivingLicenseApplications(ApplicationID,LicenseClassID)
                values(@ApplicationID,@ClassLicense)
                SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@ClassLicense", ClassLicense);
         






            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int LocalAppID))
                {
                    ID = LocalAppID;
                        
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

        public static bool IsAppExist(int LicenseClassID, int PersonID )
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"
                                select lc.LocalDrivingLicenseApplicationID from LocalDrivingLicenseApplications lc inner join Applications ap on
                                ap.ApplicationID = lc.ApplicationID inner join People p on p.PersonID = ap.ApplicantPersonID inner join LicenseClasses c on
                                c.LicenseClassID = lc.LicenseClassID where p.PersonID = @PersonID and c.LicenseClassID = @LicenseClassID and ApplicationStatus =1 and ap.ApplicationTypeID = 1";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@PersonID", PersonID);


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

        public static bool DeleteLocalApplication(int ID)
        {
            bool isDone = false;
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"delete from LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID = @ID";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();

                RowsAffected = command.ExecuteNonQuery();

                if (RowsAffected > 0)
                {
                    isDone = true;
                }

            }

            catch (Exception ex)
            {
                isDone = false;

            }

            finally
            {
                connection.Close();
            }

            return isDone;
        }
        public static bool UpdateLocalApplication(int ID, int LicenseClassID)
        {
            bool isDone = false;
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @" Update LocalDrivingLicenseApplications set LicenseClassID =@LicenseClassID where LocalDrivingLicenseApplicationID = @ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);


            try
            {
                connection.Open();

                RowsAffected = command.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    isDone = true;
                }


            }

            catch (Exception ex)
            {
                isDone = false;

            }

            finally
            {
                connection.Close();
            }

            return isDone;

        }



        public static byte GetAppStatus(string LicenseClassName, int PersonID)
        {
            byte StatusID = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @" select ap.ApplicationStatus from LocalDrivingLicenseApplications lc inner join Applications ap on
                                ap.ApplicationID = lc.ApplicationID inner join People p on p.PersonID = ap.ApplicantPersonID inner join LicenseClasses c on
                                c.LicenseClassID = lc.LicenseClassID where p.PersonID = @PersonID and c.ClassName = @LicenseClassName ;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseClassName", LicenseClassName);
            command.Parameters.AddWithValue("@PersonID", PersonID);








            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    StatusID = (byte)reader["ApplicationStatus"];
                }
            }

            catch (Exception ex)
            {

            }

            finally
            {
                connection.Close();
            }

            return StatusID;

        }

    }
}
