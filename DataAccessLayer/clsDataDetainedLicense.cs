using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class clsDataDetainedLicense
    {

        public static int AddNewDetainApp(int licneseID, DateTime detainDate, decimal fineFees, int createdByUserID, bool isRealesed)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"Insert into DetainedLicenses( LicenseID,detainDate,fineFees,createdByUserID,IsReleased)
                values(@licneseID,@detainDate,@fineFees,@createdByUserID,@isRealesed)
                SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@licneseID", licneseID);
            command.Parameters.AddWithValue("@detainDate", detainDate);
            command.Parameters.AddWithValue("@fineFees", fineFees);
            command.Parameters.AddWithValue("@createdByUserID", createdByUserID);
            command.Parameters.AddWithValue("@isRealesed", isRealesed);



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

        public static bool IsDetained(int DetainedID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"select found= 1 from DetainedLicenses where DetainID = @DetainID and IsReleased <> 1";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DetainID", DetainedID);


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

        public static bool IsDetainedByLicense(int LicenseID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"select found= 1 from DetainedLicenses where LicenseID = @LicenseID and IsReleased <> 1";


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



        public static bool ReleaseLicense(int DetainID,DateTime ReleaseDate,int ReleasedByUserID,int ReleaseApplicationID)
        {
            bool isDone = false;
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @" Update DetainedLicenses set IsReleased = 1,ReleaseDate = @ReleaseDate,
                ReleasedByUserID = @ReleasedByUserID ,ReleaseApplicationID = @ReleaseApplicationID where DetainID = @DetainID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DetainID", DetainID);
            command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);






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

        public static int GetID(int licenseID)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"select DetainID from DetainedLicenses where LicenseID = @licenseID and IsReleased <> 1 ";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@licenseID", licenseID);
   



            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    ID = (int)reader["DetainID"];
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

        public static decimal GetFineFees(int DetainID)
        {
            decimal FineFees = -1;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"select FineFees from DetainedLicenses where DetainID = @DetainID ";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@DetainID", DetainID);




            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    FineFees = (decimal)reader["FineFees"];
                }
            }

            catch (Exception ex)
            {

            }

            finally
            {
                connection.Close();
            }

            return FineFees;

        }

        public static DataTable GetAllDetainedLicense()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"			select dl.DetainID,dl.LicenseID,dl.DetainDate,dl.IsReleased,dl.FineFees,dl.ReleaseDate,p.NationalNo, concat (p.FirstName,' ',p.SecondName,' ' , p.ThirdName,' ' ,p.LastName) as FullName,dl.ReleaseApplicationID from DetainedLicenses dl 
				inner join Licenses l on l.LicenseID = dl.LicenseID 
				inner join Drivers d on d.DriverID = l.DriverID 
				inner join People p on p.PersonID =  d.PersonID 
  ";

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
            if (Column != "DetainID" && Column != "ReleaseApplicationID")
            {
                return dt;
            }
            string query = $@"	select dl.DetainID,dl.LicenseID,dl.DetainDate,dl.IsReleased,dl.FineFees,dl.ReleaseDate,p.NationalNo, concat (p.FirstName,' ',p.SecondName,' ' , p.ThirdName,' ' ,p.LastName) as FullName,dl.ReleaseApplicationID from DetainedLicenses dl 
				inner join Licenses l on l.LicenseID = dl.LicenseID 
				inner join Drivers d on d.DriverID = l.DriverID 
				inner join People p on p.PersonID =  d.PersonID 
where {Column} like @Value; ";

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

        public static DataTable FilterByFullName(string Column, string value)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            if (Column != "FullName")
            {
                return dt;
            }
            string query = $@"select dl.DetainID,dl.LicenseID,dl.DetainDate,dl.IsReleased,dl.FineFees,dl.ReleaseDate,p.NationalNo, concat (p.FirstName,' ',p.SecondName,' ' , p.ThirdName,' ' ,p.LastName) as FullName,dl.ReleaseApplicationID from DetainedLicenses dl 
				inner join Licenses l on l.LicenseID = dl.LicenseID 
				inner join Drivers d on d.DriverID = l.DriverID 
				inner join People p on p.PersonID =  d.PersonID 
where concat(p.FirstName , ' ' , p.SecondName , ' ' , p.ThirdName , ' ' , p.LastName ) like @value";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@value", value + "%");


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

        public static DataTable FilterByNationalNo(string Column, string value)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            if (Column != "NationalNo")
            {
                return dt;
            }
            string query = $@"select dl.DetainID,dl.LicenseID,dl.DetainDate,dl.IsReleased,dl.FineFees,dl.ReleaseDate,p.NationalNo, concat (p.FirstName,' ',p.SecondName,' ' , p.ThirdName,' ' ,p.LastName) as FullName,dl.ReleaseApplicationID from DetainedLicenses dl 
				inner join Licenses l on l.LicenseID = dl.LicenseID 
				inner join Drivers d on d.DriverID = l.DriverID 
				inner join People p on p.PersonID =  d.PersonID 
where p.NationalNo like @value";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@value", value + "%");


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

        public static DataTable FilterByIsReleased(string Column, bool value)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            if (Column != "IsReleased")
            {
                return dt;
            }

            string query = @"
                              select dl.DetainID,dl.LicenseID,dl.DetainDate,dl.IsReleased,dl.FineFees,dl.ReleaseDate,p.NationalNo, concat (p.FirstName,' ',p.SecondName,' ' , p.ThirdName,' ' ,p.LastName) as FullName,dl.ReleaseApplicationID from DetainedLicenses dl 
				inner join Licenses l on l.LicenseID = dl.LicenseID 
				inner join Drivers d on d.DriverID = l.DriverID 
				inner join People p on p.PersonID =  d.PersonID 
									where IsReleased = @value
            ";

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
