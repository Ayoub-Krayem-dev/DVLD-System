using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsDataTestAppoinment
    {

        public static DataTable GetAllAppoinmentTests(int LocalAppID,int TestTypeID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = "select TestAppointmentID ,AppointmentDate,PaidFees,IsLocked from TestAppointments where TestTypeID = @TestTypeID and LocalDrivingLicenseApplicationID = @LocalAppID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalAppID", LocalAppID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

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



        public static bool Find(int ID,ref  int testTypeID, ref int localDrivingLicenseID, ref DateTime appoinmentDate, ref decimal paidFees, ref int createdByUserID, ref bool isLocked,ref int RetakeTestApplicationID )
        {
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"select * from TestAppointments where TestAppointmentID = @ID; ";

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
                    testTypeID = (int)reader["TestTypeID"];
                    localDrivingLicenseID = (int)reader["LocalDrivingLicenseApplicationID"];
                    appoinmentDate = (DateTime)reader["AppointmentDate"];
                    paidFees = (decimal)reader["PaidFees"];
                    createdByUserID = (int)reader["createdByUserID"];
                    isLocked = (bool)reader["isLocked"];
                    if(reader["RetakeTestApplicationID"] != DBNull.Value)
                    {
                        RetakeTestApplicationID = (int)reader["RetakeTestApplicationID"];

                    }
                    else
                    {
                        RetakeTestApplicationID = -1;

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

        public static int AddNewTestApp( int testTypeID, int localDrivingLicenseID, DateTime appoinmentDate, decimal paidFees, int createdByUserID, bool isLocked, int RetakeTestApplicationID = -1)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"Insert into TestAppointments( TestTypeID,LocalDrivingLicenseApplicationID,AppointmentDate,PaidFees,CreatedByUserID,IsLocked,RetakeTestApplicationID)
                values(@TestTypeID,@LocalDrivingLicenseApplicationID,@AppointmentDate,@PaidFees,@CreatedByUserID,@IsLocked,@RetakeTestApplicationID)
                SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", testTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseID);
            command.Parameters.AddWithValue("@AppointmentDate", appoinmentDate);
            command.Parameters.AddWithValue("@PaidFees", paidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
            command.Parameters.AddWithValue("@IsLocked", isLocked);

            if(RetakeTestApplicationID != -1)
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);

            }
            else
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", System.DBNull.Value);

            }







            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int TestAppID))
                {
                    ID = TestAppID;
                        
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



        public static bool UpdateAppointmentTest(int ID,DateTime AppointmentDate, decimal PaidFees, bool IsLocked,int RetakeTestApplicationID = -1)
        {
            bool isDone = false;
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @" Update TestAppointments set AppointmentDate = @AppointmentDate,PaidFees=@PaidFees,IsLocked = @IsLocked,RetakeTestApplicationID = @RetakeTestApplicationID where TestAppointmentID = @ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);
            if (RetakeTestApplicationID != -1)
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);

            }
            else
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", System.DBNull.Value);

            }



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

        public static DataTable GetTrials(int LocalAppID, int TestTypeID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = "select TestAppointmentID ,AppointmentDate,PaidFees,IsLocked from TestAppointments where TestTypeID = @TestTypeID and LocalDrivingLicenseApplicationID = @LocalAppID and IsLocked = 1";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalAppID", LocalAppID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

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
