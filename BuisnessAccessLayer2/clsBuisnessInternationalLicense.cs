using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccessLayer;
namespace BuisnessAccessLayer2
{
    public class clsBuisnessInternationalLicense
    {
        public int InternationalLicenseID { get; set; }

        public int ApplicationID { get; set; }

        public int DriverID { get; set; }

        public int IssuedUsingLocalLicenseID { get; set; }

        public DateTime IssueDate   { get; set; }

        public DateTime ExpirationDate { get; set; }

        public bool IsActive { get; set; }

        public int CreatedByUserID { get; set; }


        public clsBuisnessInternationalLicense(int internationalLicenseID, int applicationID, int driverID, int issuedUsingLocalLicenseID, DateTime issueDate, DateTime expirationDate, bool isActive, int createdByUserID)
        {
            InternationalLicenseID = internationalLicenseID;
            ApplicationID = applicationID;
            DriverID = driverID;
            IssuedUsingLocalLicenseID = issuedUsingLocalLicenseID;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            IsActive = isActive;
            CreatedByUserID = createdByUserID;
        }
        public clsBuisnessInternationalLicense()
        {

            InternationalLicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            IssuedUsingLocalLicenseID = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            IsActive = false;
            CreatedByUserID = -1;
        }

        public static clsBuisnessInternationalLicense Find(int ID)
        {
           int ApplicationID = -1;
           int DriverID = -1;
           int IssuedUsingLocalLicenseID = -1;
           DateTime IssueDate = DateTime.Now;
           DateTime ExpirationDate = DateTime.Now;
           bool IsActive = false;
           int CreatedByUserID = -1;


            if(clsDataInternationalLicense.Find( ID, ref ApplicationID, ref DriverID, ref IssuedUsingLocalLicenseID,
                ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserID))
            {
                return new clsBuisnessInternationalLicense(ID, ApplicationID, DriverID, IssuedUsingLocalLicenseID,
                 IssueDate, ExpirationDate, IsActive, CreatedByUserID);
            }
            else
            {
                return null;
            }
        }

        public bool AddNewLicense()
        {
            this.InternationalLicenseID = clsDataInternationalLicense.AddNewLicense(this.ApplicationID, this.DriverID, this.IssuedUsingLocalLicenseID,
                this.IssueDate, this.ExpirationDate, this.IsActive, this.CreatedByUserID);

            return (this.InternationalLicenseID != -1);
        }


        public static DataTable GetLicenseHistory(int PersonID)
        {
            return clsDataInternationalLicense.GetLicenseHistory(PersonID);
        }

        public static bool IsThereInternationalLicenseActive(int DriverID)
        {
            return clsDataInternationalLicense.IsThereInternationalLicenseActive(DriverID);
        }

        public static DataTable GetAllInternationalLicense()
        {
            return clsDataInternationalLicense.GetAllInternationalLicense();    
        }

        public static DataTable FilterByInt(string Column, int value)
        {
            return clsDataInternationalLicense.FilterByInt(Column, value);
        }

    }
}
