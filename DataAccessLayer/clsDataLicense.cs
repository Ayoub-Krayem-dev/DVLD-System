using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class clsDataLicense
    {
        public static bool Find(int ID,ref int applicationID, ref int driverID, ref int licenseClassID, ref DateTime issueDate,
           ref DateTime expirationDate, ref string notes, ref decimal paidFees, ref bool isActive, ref byte issueReason, ref int createdByUserID)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"select * from Licenses WHERE  LicenseID = @ID; ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);
            bool isFound = false;
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    applicationID = (int)reader["ApplicationID"];
                    driverID = (int)reader["driverID"];
                    licenseClassID = (int)reader["licenseClass"];
                    issueDate = (DateTime)reader["issueDate"];
                    expirationDate = (DateTime)reader["expirationDate"];
                    paidFees = (decimal)reader["paidFees"];
                    isActive = (bool)reader["isActive"];
                    issueReason = (byte)reader["issueReason"];
                    createdByUserID = (int)reader["createdByUserID"];

                    if (reader["notes"] != System.DBNull.Value)
                    {
                        notes = (string)reader["notes"];

                    }
                    else
                    {
                        notes = "";
                    }





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



        public static int AddNewLicense( int applicationID, int driverID, int licenseClassID, DateTime issueDate,
            DateTime expirationDate, string notes, decimal paidFees, bool isActive, byte issueReason, int createdByUserID)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"Insert into Licenses(applicationID,driverID,licenseClass,issueDate,
                            expirationDate,notes,paidFees,isActive,issueReason,createdByUserID)
                values(@applicationID,@driverID,@licenseClassID,@issueDate,@expirationDate,@notes,@paidFees,@isActive,@issueReason,@createdByUserID)
                SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@applicationID", applicationID);
            command.Parameters.AddWithValue("@driverID", driverID);
            command.Parameters.AddWithValue("@licenseClassID", licenseClassID);
            command.Parameters.AddWithValue("@issueDate", issueDate);
            command.Parameters.AddWithValue("@expirationDate", expirationDate);
            command.Parameters.AddWithValue("@paidFees", paidFees);
            command.Parameters.AddWithValue("@isActive", isActive);
            command.Parameters.AddWithValue("@issueReason", issueReason);
            command.Parameters.AddWithValue("@createdByUserID", createdByUserID);

            if(notes != "")
            {
                command.Parameters.AddWithValue("@notes", notes);

            }

            else
            {
                command.Parameters.AddWithValue("@notes", System.DBNull.Value);

            }




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

        
        public static bool IsExist(int ApplicationID, int DriverID,int LicenseClassID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @" select * from Licenses where ApplicationID = @ApplicationID and
                                DriverID = @DriverID and LicenseClass = @LicenseClassID
";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);



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

        public static bool IsThirdClassLicense(int LicenseID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @" 	select Found = 1  from Licenses where LicenseID = @LicenseID and
                                LicenseClass = 3
";


            SqlCommand command = new SqlCommand(query, connection);

   
            command.Parameters.AddWithValue("@LicenseID", LicenseID);



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

        public static int GetLicenseID(int ApplicationID, int DriverID, int LicenseClassID)
        {
            int LicenseID = -1;

            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @" select LicenseID from Licenses where ApplicationID = @ApplicationID and
                                DriverID = @DriverID and LicenseClass = @LicenseClassID
";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);


            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    LicenseID = ID;

                }
            }
            catch (Exception ex)
            {

            }

            finally
            {
                connection.Close();
            }

            return LicenseID ;
        }



        public static DataTable GetLicenseHistory(int ID)
        {
     
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"select  l.LicenseID,l.ApplicationID,lc.ClassName,l.IssueDate, l.ExpirationDate,l.IsActive from Licenses l 
                            inner join Drivers d on d.DriverID = l.DriverID 
                            inner join People p  on p.PersonID = d.PersonID 
							inner join LicenseClasses lc on l.LicenseClass = lc.LicenseClassID

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

        public static bool DisActiveLicense(int ID)
        {
            bool isDone = false;
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @" Update Licenses set IsActive =0 where LicenseID = @ID";

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


        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {
            int LicenseID = -1;

            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"SELECT        Licenses.LicenseID
                            FROM Licenses INNER JOIN
                                                     Drivers ON Licenses.DriverID = Drivers.DriverID
                            WHERE  
                             
                             Licenses.LicenseClass = @LicenseClass 
                              AND Drivers.PersonID = @PersonID
                              And IsActive=1;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClassID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    LicenseID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return LicenseID;
        }


    }
}
