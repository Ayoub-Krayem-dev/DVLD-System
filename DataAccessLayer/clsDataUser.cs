using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class clsDataUser
    {
        public static int AddNewUser(string UserName,string Password, int PersonID, bool IsActive)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"Insert into Users( UserName,PersonID,Password,IsActive)
                values(@UserName,@PersonID,@Password,@IsActive)
                SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);



          

            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int UserID))
                {
                    ID = UserID;
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
        public static DataTable FilterByInt(string Column, int value)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            if (Column != "PersonID"&&Column!="UserID")
            {
                return dt;
            }
            string query = $"select * from Users where {Column} like @value;";

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

        public static bool DeleteUser(int ID)
        {
            bool isDone = false;
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"delete from Users where UserID = @ID";


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


        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"
                                    select UserID,
                                    u.PersonID,
                                    concat(p.FirstName , ' ' , p.SecondName , ' ' , p.ThirdName , ' ' , p.LastName )as FullName ,
                                    UserName
                                    ,IsActive
                                    from Users  u inner join People p on u.PersonID = p.PersonID;
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

        public static DataTable FilterByUserName(string Column, string value)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            if (Column != "UserName" )
            {
                return dt;
            }
            string query = $"select * from Users where {Column} like @value;";

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
        
        public static string GetFullName(int PersonID)
        {
            string FullName = "";
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);


            string query = "select FirstName + ' '  + SecondName +' ' + ThirdName + ' ' + LastName as FullName from People where PersonID =@PersonID ";
            SqlCommand command = new SqlCommand(query,connection);

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

            catch(Exception ex)
            {

            }

            finally
            {
                connection.Close();
            }

            return FullName;
        }

        public static DataTable FilterByFullName(string Column, string value)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            if (Column != "FullName")
            {
                return dt;
            }
            string query = @"
                                select UserID, Users.PersonID,FirstName + ' ' + SecondName + ' ' + ThirdName + ' ' + LastName as fullName ,UserName
                                    ,IsActive from Users inner join People on Users.PersonID = People.PersonID
									where FirstName + ' ' + SecondName + ' ' + ThirdName + ' ' + LastName Like @value;
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

        public static DataTable FilterByIsActive(string Column, bool value)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);
            if (Column != "IsActive")
            {
                return dt;
            }

            string query = @"
                               select UserID, Users.PersonID,FirstName + ' ' + SecondName + ' ' + ThirdName + ' ' + LastName as fullName ,UserName
                                    ,IsActive from Users inner join People on Users.PersonID = People.PersonID
									where IsActive = @value
            ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@value", value );


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

        public static bool FindByUserID(int UserID, ref string UserName, ref string Password,ref int PersonID ,ref bool IsActive)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"select * FROM Users WHERE UserID = @UserID; ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);
            bool isFound = false;
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    PersonID = (int)reader["PersonID"];
                    IsActive = (bool)reader["IsActive"];
              

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


        public static bool FindByUserNameAndPassword(string UserName, string Password, ref int UserID, ref int PersonID, ref bool IsActive)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"select * FROM Users WHERE UserName = @UserName and Password = @Password; ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);

            bool isFound = false;
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    UserID = (int)reader["UserID"];

                    PersonID = (int)reader["PersonID"];
                    IsActive = (bool)reader["IsActive"];


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

        public static bool UpdateUser(int ID, string UserName, string Password, int PersonID, bool IsActive)
        {
            bool isDone = false;
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @" Update Users set UserName = @UserName,Password=@Password,IsActive = @IsActive where UserID = @ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);
           

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
        public static bool FindByPersonID(int PersonID, ref string UserName, ref string Password, ref int UserID, ref bool IsActive)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"select * FROM Users WHERE PersonID = @PersonID; ";

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
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    UserID = (int)reader["UserID"];
                    IsActive = (bool)reader["IsActive"];


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

        public static bool IsUserExist(string UserName)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = "SELECT Found=1 FROM Users WHERE UserName = @UserName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

    }
}
