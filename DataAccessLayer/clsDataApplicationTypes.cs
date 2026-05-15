using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class clsDataApplicationTypes
    {

        public static int AddNewApplicationType(string Title, decimal Fees)
        {
            int ApplicationTypeID = -1;

            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"Insert Into ApplicationTypes (ApplicationTypeTitle,ApplicationFees)
                            Values (@Title,@Fees)
                            
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationTypeTitle", Title);
            command.Parameters.AddWithValue("@ApplicationFees", Fees);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ApplicationTypeID = insertedID;
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


            return ApplicationTypeID;

        }

        public static DataTable GetAllApplicationTypes()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"select * from ApplicationTypes
                                   
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

        public static bool UpdateApplicationType(int ID, string Title, decimal Fees)
        {
            bool isDone = false;
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @" Update ApplicationTypes set ApplicationTypeTitle =@Title,ApplicationFees = @Fees where ApplicationTypeID = @ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@Title", Title);
            command.Parameters.AddWithValue("@Fees", Fees);


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




        public static bool Find(int ID, ref string Title, ref decimal Fees)
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"select * FROM ApplicationTypes WHERE ApplicationTypeID = @ID; ";

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
                    Title = (string)reader["ApplicationTypeTitle"];
                    Fees = (decimal)reader["ApplicationFees"];
                 

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

    }
}
