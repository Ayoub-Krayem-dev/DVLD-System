using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccessLayer;

namespace BuisnessAccessLayer2
{
    public class clsBuisnessDriver
    {
        public int DriverID { get; set; }

        public int PersonID { get; set; }

        public int CreatedByUserID { get; set; }

        public DateTime CreatedDate { get; set; }

        public clsBuisnessDriver()
        {
            DriverID = -1;
            PersonID = -1;
            CreatedByUserID = -1;
            CreatedDate = DateTime.Now;
        }

        public clsBuisnessDriver(int driverID, int personID, int createdByUserID, DateTime createdDate)
        {
            DriverID = driverID;
            PersonID = personID;
            CreatedByUserID = createdByUserID;
            CreatedDate = createdDate;
        }

        public bool AddNewDriver()
        {
            this.DriverID = clsDataDriver.AddNewDriver(this.PersonID, this.CreatedDate, this.CreatedByUserID);

            return (this.DriverID != -1);
        }

        public static clsBuisnessDriver FindByPersonID(int PersonID)
        {
           int  DriverID = -1;
           int CreatedByUserID = -1;
           DateTime CreatedDate = DateTime.Now;

            if(clsDataDriver.FindByPersonID(PersonID,ref DriverID,ref CreatedByUserID,ref CreatedDate)){
                return new clsBuisnessDriver (DriverID, PersonID, CreatedByUserID, CreatedDate);
            }
            else
            {
                return null;
            }
        }

        public static clsBuisnessDriver FindByDriverID(int DriverID)
        {
            int PersonID = -1;
            int CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;

            if (clsDataDriver.FindDriverID(DriverID, ref PersonID, ref CreatedByUserID, ref CreatedDate))
            {
                return new clsBuisnessDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            }
            else
            {
                return null;
            }
        }

        public static DataTable GetAllDrivers()
        {
            return clsDataDriver.GetAllDrivers();
        }

        public static DataTable FilterByInt(string Column, int value)
        {
            return clsDataDriver.FilterByInt(Column, value);
        }
        public static DataTable FilterByFullName(string Column, string value)
        {
            return clsDataDriver.FilterByFullName(Column, value);
        }

        public static DataTable FilterByNationalNo(string Column, string value)
        {
            return clsDataDriver.FilterByNationalNo(Column, value);
        }
    }
}
