using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class clsDataPerson
    {


        public static int AddNewPerson(string NationalNo,string FirstName,string SecondName,string ThirdName,string LastName,
            DateTime DateOfBirth,int Gendor,string Address,string Phone,string Email,int NationalityCountryID,string ImagePath)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"Insert into People( NationalNo,FirstName,SecondName,ThirdName,LastName,DateOfBirth,Gendor,Address,Phone,Email,NationalityCountryID,ImagePath)
                values(@NationalNo,@FirstName,@SecondName,@ThirdName,@LastName,@DateOfBirth,@Gendor,@Address,@Phone,@Email,@NationalityCountryID,@ImagePath)
                SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);

            if (ThirdName != "")
            {
                command.Parameters.AddWithValue("@ThirdName", ThirdName);

            }

            else
            {
                command.Parameters.AddWithValue("@ThirdName", DBNull.Value);

            }
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);

            if (Email != "")
            {
                command.Parameters.AddWithValue("@Email", Email);

            }

            else
            {
                command.Parameters.AddWithValue("@Email", DBNull.Value);

            }
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

            if (ImagePath != "")
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);

            }

            else
            {
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);

            }


            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();

                if(Result != null&& int.TryParse(Result.ToString(),out int PersonID))
                {
                    ID = PersonID;
                }
            }

            catch(Exception ex)
            {

            }

            finally
            {
                connection.Close();
            }

            return ID;

        }

        public static bool UpdatePerson(int ID , string NationalNo, string FirstName, string SecondName,  string ThirdName, string LastName, DateTime DateOfBirth,
                int Gendor, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            bool isDone = false;
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @" Update People set NationalNo = @NationalNo,FirstName=@FirstName,SecondName =@SecondName,ThirdName = @ThirdName,
            LastName=@LastName,DateOfBirth=@DateOfBirth ,Gendor=@Gendor,Address=@Address,Phone=@Phone,Email=@Email,
            NationalityCountryID=@NationalityCountryID,ImagePath=@ImagePath where PersonID = @ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);

            if (ThirdName != "")
            {
                command.Parameters.AddWithValue("@ThirdName", ThirdName);

            }

            else
            {
                command.Parameters.AddWithValue("@ThirdName", DBNull.Value);

            }
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);

            if (Email != "")
            {
                command.Parameters.AddWithValue("@Email", Email);

            }

            else
            {
                command.Parameters.AddWithValue("@Email", DBNull.Value);

            }
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

            if (ImagePath != "")
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);

            }

            else
            {
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);

            }


            try
            {
                connection.Open();

                RowsAffected = command.ExecuteNonQuery();
                if(RowsAffected > 0)
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
        public static bool IsExist(string NationalNumber,int PersonID = -1)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"select Found=1 from People where NationalNo = @NationalNumber and PersonID <> @PersonID";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNumber", NationalNumber);
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
        public static bool DeletePerson(int ID)
        {
            bool isDone = false;
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"delete from People where PersonID = @ID";


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



        public static DataTable GetAllPeople()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = "Select * from People ";

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

        public static bool Find(int PersonID , ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref
            DateTime DateOfBirth, ref int Gendor, ref string Address, ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"select * FROM People WHERE PersonID = @PersonID; ";

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
                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];

                    if (reader["ThirdName"] != DBNull.Value)
                    {
                        ThirdName = (string)reader["ThirdName"];
                    }
                    else
                    {
                        ThirdName = "";
                    }
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = Convert.ToInt32(reader["Gendor"]);
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    if (reader["Email"] != DBNull.Value)
                    {
                        Email = (string)reader["Email"];
                    }
                    else
                    {
                        Email = "";
                    }
                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }


                }
                reader.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }

        public static bool Find(string NationalNo,ref int PersonID, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref
           DateTime DateOfBirth, ref int Gendor, ref string Address, ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = "select * from People where NationalNo = @NationalNo";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            bool isFound = false;
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    isFound = true;
                    PersonID = (int)reader["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];

                    if (reader["ThirdName"] != DBNull.Value)
                    {
                        ThirdName = (string)reader["ThirdName"];
                    }
                    else
                    {
                        ThirdName = "";
                    }
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = Convert.ToInt32(reader["Gendor"]);
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    if (reader["Email"] != DBNull.Value)
                    {
                        Email = (string)reader["Email"];
                    }
                    else
                    {
                        Email = "";
                    }
                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }


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
            return isFound;
        }

        public static DataTable FilterByString(string Column,string value)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            if(Column !="FirstName"&&Column !="SecondName"&&Column!="ThirdName"&&Column!="LastName"&&Column != "Email"&&Column!="Phone"&&Column != "NationalNo" && Column != "Nationality")
            {
                return dt;
            }
            string query = $"select * from People where {Column} like @value;";
            
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@value",  value + "%");


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
            catch(Exception ex)
            {
                throw ex;
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
            if (Column != "PersonID")
            {
                return dt;
            }
            string query = $"select * from People where {Column} like @value;";

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
        public static DataTable FilterByGendor(string Column, byte value)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            if (Column != "Gendor")
            {
                return dt;
            }
            string query = $"select * from People where {Column} = @value;";

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

        public static string GetFullName(int PersonID)
        {
            string FullName = "";
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);


            string query = "select concat (FirstName,' ',SecondName,' ' , ThirdName,' ' ,LastName) as FullName from People where PersonID =@PersonID ";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    FullName = (string)reader["FullName"];
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

            return FullName;
        }
    }
}
