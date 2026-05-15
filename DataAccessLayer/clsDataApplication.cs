using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class clsDataApplication
    {

        public static int AddNewApp(int AppPersonID, DateTime AppDate, int AppTypeID, byte AppStatus, DateTime LastStatusDate, Decimal PaidFees, int CreatedByUserID)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"Insert into Applications( ApplicantPersonID,ApplicationDate,ApplicationTypeID,ApplicationStatus,LastStatusDate,PaidFees,CreatedbyUserID)
                values(@AppPersonID,@AppDate,@AppTypeID,@AppStatus,@LastStatusDate,@PaidFees,@CreatedByUserID)
                SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AppPersonID", AppPersonID);
            command.Parameters.AddWithValue("@AppDate", AppDate);
            command.Parameters.AddWithValue("@AppTypeID", AppTypeID);
            command.Parameters.AddWithValue("@AppStatus", AppStatus);
            command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);






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


        public static DataTable GetAllApplications()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"select L.LocalDrivingLicenseApplicationID, a.ApplicationDate ,p.NationalNo,lc.ClassName,
concat(p.FirstName , ' ' , p.SecondName , ' ' , p.ThirdName , ' ' , p.LastName )as FullName,
case 
when a.ApplicationStatus = 1 then 'New'
when a.ApplicationStatus = 2 then 'Cancelled'
when a.ApplicationStatus = 3 then 'Complete'
else 'Other' end as Status
from Applications a 
inner join People p on p.PersonID =  a.ApplicantPersonID
inner join LocalDrivingLicenseApplications L on L.ApplicationID =a.ApplicationID
inner join LicenseClasses lc on lc.LicenseClassID = L.LicenseClassID 
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

        public static bool Find(int ApplicationID, ref int AppPersonID, ref DateTime AppDate, ref int AppTypeID, ref byte AppStatus, ref DateTime LastStatusDate, ref Decimal PaidFees, ref int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"select * from Applications WHERE  ApplicationID = @ApplicationID; ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            bool isFound = false;
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    AppPersonID = (int)reader["ApplicantPersonID"];
                    AppDate = (DateTime)reader["ApplicationDate"];
                    AppTypeID = (int)reader["ApplicationTypeID"];
                    AppStatus = (byte)reader["ApplicationStatus"];
                    LastStatusDate = (DateTime)reader["LastStatusDate"];
                    PaidFees = (decimal)reader["PaidFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];





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


        public static bool CancelApplication(int ID,DateTime LastDate)
        {
            bool isDone = false;
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @" Update Applications set ApplicationStatus =2, LastStatusDate = @LastDate where ApplicationID = @ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@LastDate", LastDate);



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
        public static bool CompleteApplication(int ID,DateTime LastDate)
        {
            bool isDone = false;
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @" Update Applications set ApplicationStatus = 3, LastStatusDate = @LastDate where applicationID = @ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@LastDate", LastDate);



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

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, int ApplicationTypeID, int LicenseClassID)
        {
            int ActiveApplicationID = -1;

            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"SELECT ActiveApplicationID=Applications.ApplicationID  
                            From
                            Applications INNER JOIN
                            LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                            WHERE ApplicantPersonID = @ApplicantPersonID 
                            and ApplicationTypeID=@ApplicationTypeID 
							and LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID
                            and ApplicationStatus=1";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", PersonID);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int AppID))
                {
                    ActiveApplicationID = AppID;
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return ActiveApplicationID;
            }
            finally
            {
                connection.Close();
            }

            return ActiveApplicationID;
        }
        public static bool DeleteApplication(int ApplicationID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"Delete Applications 
                                where ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {

                connection.Close();

            }

            return (rowsAffected > 0);

        }
        public static DataTable FilterByInt(string Column, int value)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            if (Column != "ApplicationStatus" && Column != "LocalDrivingLicenseApplicationID")
            {
                return dt;
            }
            string query = $@"
 select L.LocalDrivingLicenseApplicationID, a.ApplicationDate ,p.NationalNo,lc.ClassName,
concat(p.FirstName, ' ', p.SecondName, ' ', p.ThirdName, ' ', p.LastName) as FullName,
case 
when a.ApplicationStatus = 1 then 'New'
when a.ApplicationStatus = 2 then 'Cancelled'
when a.ApplicationStatus = 3 then 'Complete'
else 'Other' end as Status
from Applications a
inner
join People p on p.PersonID = a.ApplicantPersonID
inner
join LocalDrivingLicenseApplications L on L.ApplicationID = a.ApplicationID
inner
join LicenseClasses lc on lc.LicenseClassID = L.LicenseClassID
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
        public static DataTable FilterByFullName(string Column, string value) {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            if (Column != "FullName"  )
            {
                return dt;
            }
            string query = $@"select L.LocalDrivingLicenseApplicationID, a.ApplicationDate ,p.NationalNo,lc.ClassName,
concat(p.FirstName , ' ' , p.SecondName , ' ' , p.ThirdName , ' ' , p.LastName )as FullName,
case 
when a.ApplicationStatus = 1 then 'New'
when a.ApplicationStatus = 2 then 'Cancelled'
when a.ApplicationStatus = 3 then 'Complete'
else 'Other' end as Status
from Applications a 
inner join People p on p.PersonID =  a.ApplicantPersonID
inner join LocalDrivingLicenseApplications L on L.ApplicationID =a.ApplicationID
inner join LicenseClasses lc on lc.LicenseClassID = L.LicenseClassID 
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
            string query = $@"select L.LocalDrivingLicenseApplicationID, a.ApplicationDate ,p.NationalNo,lc.ClassName,
concat(p.FirstName , ' ' , p.SecondName , ' ' , p.ThirdName , ' ' , p.LastName )as FullName,
case 
when a.ApplicationStatus = 1 then 'New'
when a.ApplicationStatus = 2 then 'Cancelled'
when a.ApplicationStatus = 3 then 'Complete'
else 'Other' end as Status
from Applications a 
inner join People p on p.PersonID =  a.ApplicantPersonID
inner join LocalDrivingLicenseApplications L on L.ApplicationID =a.ApplicationID
inner join LicenseClasses lc on lc.LicenseClassID = L.LicenseClassID 
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
    } }

