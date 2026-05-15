using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccessLayer;

namespace BuisnessAccessLayer2
{
    public class clsBuisnessTests
    {
        public int TestID { get; set; }

        public int AppointmentID { get; set; }

        public bool Result { get; set; }

        public string Notes { get; set; }

        public int CreatedByUserID { get; set; }


        public clsBuisnessTests(int testID, int appointmentID, bool result, string notes, int createdByUserID)
        {
            TestID = testID;
            AppointmentID = appointmentID;
            Result = result;
            Notes = notes;
            CreatedByUserID = createdByUserID;
        }

        public clsBuisnessTests()
        {
            TestID = -1;
            AppointmentID = -1;
            Result = false;
            Notes = "";
            CreatedByUserID = -1;

        }


        public bool AddNewApplication()
        {
            this.TestID = clsDataTests.AddNewTest(this.AppointmentID, this.Result, this.Notes,
                this.CreatedByUserID);

            return (this.TestID != -1);
        }

        public static bool IsTestPassed(int LocalAppID,int TestTypeID)
        {
            return clsDataTests.IsTestPassed(LocalAppID, TestTypeID);
        }
        public static bool IsTestLocked(int AppointmentID, int TestTypeID)
        {
            return clsDataTests.IsTestLocked(AppointmentID, TestTypeID);
        }

        public static bool IsTestFailed(int LocalAppID, int TestTypeID)
        {
            return clsDataTests.IsTestFailed(LocalAppID, TestTypeID);
        }

        public static bool IsThereAnyAppointmentUnLocked(int LocalAppID,int TestTypeID)
        {
            return clsDataTests.IsThereAnyAppointmentUnLocked(LocalAppID, TestTypeID);
        }

        public static bool IsAppointmentLocked(int AppointmentID,int TestTypeID)
        {
            return clsDataTests.IsAppointmentLocked(AppointmentID, TestTypeID);
        }

        public static clsBuisnessTests GetTestInfoByAppointmentID(int AppointmentID)
        {
            int TestID = -1;
            bool TestResult = false; string Notes = ""; int CreatedByUserID = -1;

            if (clsDataTests.GetTestInfoByAppointmentID(AppointmentID,
            ref TestID, ref TestResult,
            ref Notes, ref CreatedByUserID))

                return new clsBuisnessTests(TestID,
                        AppointmentID, TestResult,
                        Notes, CreatedByUserID);
            else
                return null;

        }

        public bool UpdateTest()
        {
            //call DataAccess Layer 

            return clsDataTests.UpdateTest(this.TestID, this.AppointmentID,
                this.Result, this.Notes, this.CreatedByUserID);
        }
    }
}
