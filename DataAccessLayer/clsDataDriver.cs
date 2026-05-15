using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class clsDataDriver
    {
        public static int AddNewDriver(int PersonID,DateTime CreatedDate, int createdByUserID)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"Insert into Drivers(PersonID,CreatedDate,CreatedByUserID)
                values(@PersonID,@CreatedDate,@createdByUserID)
                SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CreatedDate", CreatedDate);
            command.Parameters.AddWithValue("@createdByUserID", createdByUserID);




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

        public static bool FindByPersonID(int PersonID, ref int DriverID, ref int CreatedByUserID, ref DateTime CreateDate)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @" select * from Drivers where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            bool isFound = false;
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    DriverID = (int)reader["DriverID"];
                    CreateDate = (DateTime)reader["CreatedDate"];
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
        public static bool FindDriverID(int DriverID, ref int PersonID, ref int CreatedByUserID, ref DateTime CreateDate)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @" select * from Drivers where DriverID = @DriverID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);
            bool isFound = false;
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    PersonID = (int)reader["PersonID"];
                    CreateDate = (DateTime)reader["CreatedDate"];
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

        public static DataTable GetAllDrivers()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"
                              
								select  d.DriverID,p.PersonID,p.NationalNo,
                                concat (FirstName,' ',SecondName,' ' , ThirdName,' ' ,LastName) as FullName
                                ,d.CreatedDate,ISNULL(l.ActiveLicense,0) as ActiveLicenses 
								from Drivers d 
								inner join people p on p.PersonID = d.PersonID 
								inner join ( select driverID, count (case when IsActive = 1 then 1 end ) as ActiveLicense from Licenses  group by driverID) l on l.DriverID = d.DriverID ";

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
            if (Column != "PersonID" && Column != "DriverID")
            {
                return dt;
            }
            if(Column == "PersonID")
            {
                Column = "p.PersonID";
            }
            else
            {
                Column = "d.DriverID";
            }

            string query = $@"
  select distinct d.DriverID,p.PersonID,p.NationalNo,
                                concat (FirstName,' ',SecondName,' ' , ThirdName,' ' ,LastName) as FullName
                                ,d.CreatedDate,count(case when l.IsActive = 1 then 1 end)as ActiveLicense  from  Drivers d
                                inner join People p on p.PersonID = d.PersonID 
                                inner join Licenses l on l.DriverID = d.DriverID
                                group by 
                                d.DriverID,p.PersonID,p.NationalNo,FirstName,SecondName,ThirdName,LastName,d.CreatedDate 
								having {Column} = @value";

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
            string query = $@" select distinct d.DriverID,p.PersonID,p.NationalNo,
                                concat (FirstName,' ',SecondName,' ' , ThirdName,' ' ,LastName) as FullName
                                ,d.CreatedDate,count(case when l.IsActive = 1 then 1 end)as ActiveLicense  from  Drivers d
                                inner join People p on p.PersonID = d.PersonID 
                                inner join Licenses l on l.DriverID = d.DriverID
                                group by 
                                d.DriverID,p.PersonID,p.NationalNo,FirstName,SecondName,ThirdName,LastName,d.CreatedDate
								having  concat (FirstName,' ',SecondName,' ' , ThirdName,' ' ,LastName) like @value
								";

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
            Column = "p.NationalNo";
            string query = $@"
 select distinct d.DriverID,p.PersonID,p.NationalNo,
                                concat (FirstName,' ',SecondName,' ' , ThirdName,' ' ,LastName) as FullName
                                ,d.CreatedDate,count(case when l.IsActive = 1 then 1 end)as ActiveLicense  from  Drivers d
                                inner join People p on p.PersonID = d.PersonID 
                                inner join Licenses l on l.DriverID = d.DriverID
                                group by 
                                d.DriverID,p.PersonID,p.NationalNo,FirstName,SecondName,ThirdName,LastName,d.CreatedDate
								having  {Column} like @value";
								

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
    }
}
