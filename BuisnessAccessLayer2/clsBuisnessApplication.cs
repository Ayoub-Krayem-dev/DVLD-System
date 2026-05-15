using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;
namespace BuisnessAccessLayer2
{
    public class clsBuisnessApplication
    {
        public int ApplicationID { get; set; }

        public int ApplicationPersonID { get; set; }

        public DateTime ApplicationDate { get; set; }

        public int ApplicationTypeID { set; get; }

        public byte ApplicationStatus { set; get; } // 1 AddNew | 2 Cancelled | 3 Completed

        public DateTime LastStatusDate { set; get; }

        public Decimal PaidFees { set; get; }

        public int CreatedByUserID { set; get; }


         public clsBuisnessApplication(int applicationID, int applicationPersonID, DateTime applicationDate, int applicationTypeID, byte applicationStatus, DateTime lastStatusDate, decimal paidFees, int userID)
        {
            ApplicationID = applicationID;
            ApplicationPersonID = applicationPersonID;
            ApplicationDate = applicationDate;
            ApplicationTypeID = applicationTypeID;
            ApplicationStatus = applicationStatus;
            LastStatusDate = lastStatusDate;
            PaidFees = paidFees; 
            CreatedByUserID = userID;
        }

        public clsBuisnessApplication()
        {
            ApplicationID = 0;
            ApplicationPersonID = 0;
            ApplicationDate = DateTime.Now;
            ApplicationTypeID = 0;
            ApplicationStatus = 0;
            LastStatusDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = 0;


        }

        public bool AddNewApplication()
        {
            this.ApplicationID = clsDataApplication.AddNewApp(this.ApplicationPersonID,this.ApplicationDate,this.ApplicationTypeID,
                this.ApplicationStatus,this.LastStatusDate,this.PaidFees,this.CreatedByUserID);

            return (this.ApplicationID != -1);
        }

        public static DataTable GetAllApplications()
        {
            return clsDataApplication.GetAllApplications();
        }

        public static DataTable FilterByInt(string Column,int value)
        {
            return clsDataApplication.FilterByInt(Column,value);
        }

        public static DataTable FilterByFullName(string Column, string value)
        {
            return clsDataApplication.FilterByFullName(Column, value);
        }

        public static DataTable FilterByNationalNo(string Column, string value)
        {
            return clsDataApplication.FilterByNationalNo(Column, value);
        }
        public static clsBuisnessApplication Find(int ID)
        {


          int ApplicationPersonID = 0;
          DateTime ApplicationDate = DateTime.Now;
          int  ApplicationTypeID = 0;
          byte ApplicationStatus = 0;
          DateTime  LastStatusDate = DateTime.Now;
          decimal  PaidFees = 0;
          int  CreatedByUserID = 0;

            if (clsDataApplication.Find(ID, ref ApplicationPersonID, ref ApplicationDate,ref ApplicationTypeID,ref ApplicationStatus,ref LastStatusDate,ref PaidFees,ref CreatedByUserID))
            {
                return new clsBuisnessApplication(ID, ApplicationPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
            }
            else
            {
                return null;
            }

           
        }

        public static bool CancelApplication(int ID,DateTime LastDate)
        {
            return clsDataApplication.CancelApplication(ID,LastDate);
        }


        public bool CompleteApplication()
        {
            return clsDataApplication.CompleteApplication(this.ApplicationID,DateTime.Now);
        }

        public static bool Delete(int ApplicationID)
        {
            return clsDataApplication.DeleteApplication(ApplicationID);
        }

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, int ApplicationTypeID, int LicenseClassID)
        {
            return clsDataApplication.GetActiveApplicationIDForLicenseClass(PersonID, ApplicationTypeID, LicenseClassID);
        }

      
    }
}
