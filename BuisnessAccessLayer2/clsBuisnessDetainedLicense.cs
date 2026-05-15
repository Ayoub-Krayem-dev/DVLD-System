using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;

namespace BuisnessAccessLayer2
{
    public class clsBuisnessDetainedLicense
    {
        public int DetainID { get; set; }

        public int LicneseID { get; set; }

        public DateTime DetainDate { get; set; }

        public decimal FineFees { get; set; }

        public int CreatedByUserID { get; set; }

        public bool IsRealesed { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int ReleaseApplicationID { get; set; }


        public int ReleasedByUserID { get; set; }


        public clsBuisnessDetainedLicense(int detainID, int licneseID, DateTime detainDate, decimal fineFees, int createdByUserID, bool isRealesed, DateTime releaseDate, int releaseApplicationID, int releasedByUserID)
        {
            DetainID = detainID;
            LicneseID = licneseID;
            DetainDate = detainDate;
            FineFees = fineFees;
            CreatedByUserID = createdByUserID;
            IsRealesed = isRealesed;
            ReleaseDate = releaseDate;
            ReleaseApplicationID = releaseApplicationID;
            ReleasedByUserID = releasedByUserID;
        }

        public clsBuisnessDetainedLicense()
        {
            DetainID = -1;
            LicneseID = -1;
            DetainDate = DateTime.Now;
            FineFees = 0;
            CreatedByUserID = -1;
            IsRealesed = false;
            ReleaseDate = DateTime.Now;
            ReleaseApplicationID = -1;
            ReleasedByUserID = -1;
        }

        public bool AddNewDetainApplication()
        {
            this.DetainID = clsDataDetainedLicense.AddNewDetainApp(this.LicneseID, this.DetainDate, this.FineFees,
                this.CreatedByUserID, this.IsRealesed);

            return (this.LicneseID != -1);
        }

        public static bool IsDetained(int DetainID)
        {
            return clsDataDetainedLicense.IsDetained(DetainID);
        }

        public static int GetID(int LicneseID)
        {
            return clsDataDetainedLicense.GetID(LicneseID);
        }

        public static decimal GetFineFees(int DetainID)
        {
            return clsDataDetainedLicense.GetFineFees(DetainID);
        }

        public bool ReleaseLicense()
        {
            return clsDataDetainedLicense.ReleaseLicense(this.DetainID, this.ReleaseDate, this.ReleasedByUserID, this.ReleaseApplicationID);
        }
        public static DataTable GetAllDetainedLicense()
        {
            return clsDataDetainedLicense.GetAllDetainedLicense();

        }

        public static bool IsDetainedByLicense(int LicenseID)
        {
            return clsDataDetainedLicense.IsDetainedByLicense(LicenseID);
        }

        public static DataTable FilterByInt(string Column,int Value)
        {
            return clsDataDetainedLicense.FilterByInt(Column,Value);

        }

        public static DataTable FilterByFullName(string Column, string Value)
        {
            return clsDataDetainedLicense.FilterByFullName(Column, Value);

        }

        public static DataTable FilterByNationalNo(string Column, string Value)
        {
            return clsDataDetainedLicense.FilterByNationalNo(Column, Value);

        }

        public static DataTable FilterByIsReleased(string Column, bool Value)
        {
            return clsDataDetainedLicense.FilterByIsReleased(Column, Value);

        }
    }

    
}
