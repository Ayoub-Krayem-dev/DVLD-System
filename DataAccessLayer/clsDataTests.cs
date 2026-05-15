using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class clsDataTests
    {
        public static int AddNewTest(int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"Insert into Tests( TestAppointmentID,TestResult,Notes,CreatedByUserID)
                values(@TestAppointmentID,@TestResult,@Notes,@CreatedByUserID)
                SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


            if (Notes != "")
            {
                command.Parameters.AddWithValue("@Notes", Notes);
            }


            else
            {
                command.Parameters.AddWithValue("@Notes", System.DBNull.Value);

            }







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

        public static bool IsTestPassed(int LocalAppID, int TestTypeID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"
                                select T.TestResult from LocalDrivingLicenseApplications lc
                                inner join TestAppointments tap on tap.LocalDrivingLicenseApplicationID = lc.LocalDrivingLicenseApplicationID 
                                inner join Tests T on T.TestAppointmentID = Tap.TestAppointmentID 
                                where tap.TestTypeID = @TestTypeID and lc.LocalDrivingLicenseApplicationID = @AppointmentID and T.TestResult =1";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AppointmentID", LocalAppID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


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


        public static bool IsTestLocked(int AppointmentID, int TestTypeID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"
                                select tap.IsLocked from TestAppointments tap
                                where tap.TestTypeID = @TestTypeID and tap.TestAppointmentID = @AppointmentID and tap.IsLocked =1";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AppointmentID", AppointmentID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


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
        public static bool IsTestFailed(int LocalAppID, int TestTypeID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"
                                select T.TestResult from LocalDrivingLicenseApplications lc
                                inner join TestAppointments tap on tap.LocalDrivingLicenseApplicationID = lc.LocalDrivingLicenseApplicationID 
                                inner join Tests T on T.TestAppointmentID = Tap.TestAppointmentID 
                                where tap.TestTypeID = @TestTypeID and lc.LocalDrivingLicenseApplicationID = @AppointmentID and T.TestResult = 0";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AppointmentID", LocalAppID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


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
        public static bool IsThereAnyAppointmentUnLocked(int LocalAppID,int TestTypeID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"  
                                select Tap.IsLocked from LocalDrivingLicenseApplications lc
                                inner join TestAppointments tap on tap.LocalDrivingLicenseApplicationID = lc.LocalDrivingLicenseApplicationID 
                                where tap.TestTypeID = @TestTypeID and lc.LocalDrivingLicenseApplicationID = @AppointmentID and Tap.IsLocked = 0";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AppointmentID", LocalAppID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


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




        public static bool IsAppointmentLocked(int AppointmentID,int TestTypeID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"  
                                   select IsLocked from TestAppointments 
                                where TestTypeID = TestTypeID and TestAppointmentID = @AppointmentID and IsLocked = 1";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AppointmentID", AppointmentID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);



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

        public static bool GetTestInfoByAppointmentID(int TestAppointmentID,
            ref int TestID , ref bool TestResult,
            ref string Notes, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = "SELECT * FROM Tests WHERE TestAppointmentID = @TestAppointmentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    TestID = (int)reader["TestID"];
                    TestResult = (bool)reader["TestResult"];
                    if (reader["Notes"] == DBNull.Value)

                        Notes = "";
                    else
                        Notes = (string)reader["Notes"];

                    CreatedByUserID = (int)reader["CreatedByUserID"];

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

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
        public static bool UpdateTest(int TestID, int TestAppointmentID, bool TestResult,
             string Notes, int CreatedByUserID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataSettings.connectionString);

            string query = @"Update  Tests  
                            set TestAppointmentID = @TestAppointmentID,
                                TestResult=@TestResult,
                                Notes = @Notes,
                                CreatedByUserID=@CreatedByUserID
                                where TestID = @TestID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestID", TestID);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            if(Notes == "")
            {
                command.Parameters.AddWithValue("@Notes", System.DBNull.Value);

            }
            else
            {
                command.Parameters.AddWithValue("@Notes", Notes);

            }
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

    }
}
