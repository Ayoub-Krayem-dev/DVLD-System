using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;

namespace BuisnessAccessLayer2
{
    public class clsBuisnessLicense
    {
        public int LicenseID { get; set; }

        public int ApplicationID { get; set; }

        public int DriverID { get; set; }

        public int LicenseClassID { get; set; }

        public DateTime IssueDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string Notes { get; set; }

        public Decimal PaidFees { get; set; }

        public bool IsActive { get; set; }

        public byte IssueReason { get; set; }  //1-FirstTime, 2-Renew, 3-Replacement for Damaged, 4- Replacement for Lost.

        public int CreatedByUserID { get; set; }

        public clsBuisnessLicense(int licenseID, int applicationID, int driverID, int licenseClassID, DateTime issueDate, DateTime expirationDate, string notes, decimal paidFees, bool isActive, byte issueReason, int createdByUserID)
        {
            LicenseID = licenseID;
            ApplicationID = applicationID;
            DriverID = driverID;
            LicenseClassID = licenseClassID;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            Notes = notes;
            PaidFees = paidFees;
            IsActive = isActive;
            IssueReason = issueReason;
            CreatedByUserID = createdByUserID;
        }

        public clsBuisnessLicense()
        {
            LicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LicenseClassID = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            Notes = "";
            PaidFees = 0;
            IsActive = false;
            IssueReason = 0;
            CreatedByUserID = -1;
        }


        public static clsBuisnessLicense Find(int ID)
        {


            int ApplicationID = -1;
            int DriverID = -1;
            int LicenseClassID = -1;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            string Notes = "";
            Decimal PaidFees = 0;
            bool IsActive = false;
            byte IssueReason = 0;
            int CreatedByUserID = -1;


            if (clsDataLicense.Find(ID, ref ApplicationID, ref DriverID, ref LicenseClassID, ref IssueDate,
                ref ExpirationDate, ref Notes, ref PaidFees,ref IsActive,ref IssueReason,ref CreatedByUserID))
            {
                return new clsBuisnessLicense(ID, ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate,
                    Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
            }
            else
            {
                return null;
            }


        }


        public bool AddNewLicense()
        {
            this.LicenseID = clsDataLicense.AddNewLicense(this.ApplicationID, this.DriverID, this.LicenseClassID, this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive, this.IssueReason, this.CreatedByUserID);

            return (this.LicenseID != -1);
        }

        public static bool IsExist(int ApplicationID,int DriverID,int LicenseClassID)
        {
            return clsDataLicense.IsExist(ApplicationID, DriverID, LicenseClassID);
        }
        public static int GetLicenseID(int ApplicationID, int DriverID, int LicenseClassID)
        {
            return clsDataLicense.GetLicenseID(ApplicationID, DriverID, LicenseClassID);
        }
      

        public static DataTable GetLicenseHistory(int PersonID)
        {
            return clsDataLicense.GetLicenseHistory(PersonID);
        }

        public static bool IsThirdClassLicense(int LicenseID)
        {
            return clsDataLicense.IsThirdClassLicense(LicenseID);
            
        }

        public bool DisActiveLicense()
        {
            return clsDataLicense.DisActiveLicense(this.LicenseID);
        }

        public static bool IsLicenseExistByPersonID(int PersonID, int LicenseClassID)
        {
            return (GetActiveLicenseIDByPersonID(PersonID, LicenseClassID) != -1);
        }

        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {

            return clsDataLicense.GetActiveLicenseIDByPersonID(PersonID, LicenseClassID);

        }

        public int GetActiveLicenseID(int PersonID, int LicenseClassID)
        {//this will get the license id that belongs to this application
            return clsBuisnessLicense.GetActiveLicenseIDByPersonID(PersonID, LicenseClassID);
        }
    }
}
