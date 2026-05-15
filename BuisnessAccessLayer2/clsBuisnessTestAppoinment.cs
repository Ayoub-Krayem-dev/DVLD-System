using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;


namespace BuisnessAccessLayer2
{
    public class clsBuisnessTestAppoinment
    {

        public int TestAppoinmentID { get; set; }

        public int TestTypeID { get; set; }

        public int LocalDrivingLicenseID { get; set; }

        public DateTime AppoinmentDate { get; set; }

        public Decimal paidFees { get; set; }

        public int CreatedByUserID { get; set; }

        public bool IsLocked { get; set; }

        public int RetakeTestApplicationID { get; set; }


        public static DataTable GetTrials(int ID, int TestTypeID)
        {
            return clsDataTestAppoinment.GetTrials(ID, TestTypeID);
        }
        public static DataTable GetAllTests(int ID,int TestTypeID)
        {
            return clsDataTestAppoinment.GetAllAppoinmentTests(ID, TestTypeID);
        }
        public clsBuisnessTestAppoinment(int testAppoinmentID, int testTypeID, int localDrivingLicenseID, DateTime appoinmentDate, decimal paidFees, int createdByUserID, bool isLocked, int retakeTestApplicationID)
        {
            TestAppoinmentID = testAppoinmentID;
            TestTypeID = testTypeID;
            LocalDrivingLicenseID = localDrivingLicenseID;
            AppoinmentDate = appoinmentDate;
            this.paidFees = paidFees;
            CreatedByUserID = createdByUserID;
            IsLocked = isLocked;
            RetakeTestApplicationID = retakeTestApplicationID;
        }

        public clsBuisnessTestAppoinment()
        {
            TestAppoinmentID = -1;
            TestTypeID = -1;
            LocalDrivingLicenseID = -1;
            AppoinmentDate = DateTime.Now;
            this.paidFees = -1;
            CreatedByUserID = -1;
            IsLocked = false;
            RetakeTestApplicationID = -1;
        }



        public static clsBuisnessTestAppoinment Find(int ID)
        {


            int TestTypeID = -1;
            int LocalDrivingLicenseID = -1;
            DateTime AppoinmentDate = DateTime.Now;
            Decimal paidFees = 0;
            int CreatedByUserID = -1;
            bool IsLocked = false;
            int RetakeTestApplicationID = -1;


            if (clsDataTestAppoinment.Find(ID, ref TestTypeID, ref LocalDrivingLicenseID, ref AppoinmentDate, ref paidFees, ref CreatedByUserID, ref IsLocked,ref RetakeTestApplicationID))
            {
                return new clsBuisnessTestAppoinment(ID, TestTypeID, LocalDrivingLicenseID, AppoinmentDate, paidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);
            }
            else
            {
                return null;
            }


        }

        public bool AddNewAppointmentTest()
        {
            this.TestAppoinmentID = clsDataTestAppoinment.AddNewTestApp(this.TestTypeID, this.LocalDrivingLicenseID,this.AppoinmentDate,this.paidFees,this.CreatedByUserID,this.IsLocked,this.RetakeTestApplicationID);

            return (this.TestAppoinmentID != -1);
        }

        public bool UpdateTestAppointment()
        {
            return clsDataTestAppoinment.UpdateAppointmentTest(this.TestAppoinmentID, this.AppoinmentDate, this.paidFees, this.IsLocked,this.RetakeTestApplicationID);
            

        }
    }
}
