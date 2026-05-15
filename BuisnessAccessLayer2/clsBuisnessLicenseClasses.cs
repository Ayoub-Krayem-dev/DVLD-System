using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccessLayer;

namespace BuisnessAccessLayer2
{
    public class clsBuisnessLicenseClasses
    {
        public string ClassName{ get; set; }

        public int LicenseClassID { get; set; }

        public string ClassDescription { get; set; }

        public byte MinimumAllowedAge { get; set; }

        public byte DefaultValidityLength { set; get; }

        public decimal ClassFees { get; set; }


        public clsBuisnessLicenseClasses(string className, int licenseClassID, string classDescription, byte minimumAllowedAge, byte defaultValidityLength, decimal classFees)
        {
            ClassName = className;
            LicenseClassID = licenseClassID;
            ClassDescription = classDescription;
            MinimumAllowedAge = minimumAllowedAge;
            DefaultValidityLength = defaultValidityLength;
            ClassFees = classFees;
        }


        public static clsBuisnessLicenseClasses Find(int ID)
        {
            string ClassName = "";
            string ClassDescription = "";
            byte MinimumAllowedAge = 0;
            byte DefaultValidityLength = 0;
            decimal  ClassFees = -1;



            if (clsDataLicenseClasses.Find(ID, ref ClassName, ref ClassDescription,ref MinimumAllowedAge,ref DefaultValidityLength,ref ClassFees))
            {
                return new clsBuisnessLicenseClasses(ClassName, ID, ClassDescription,MinimumAllowedAge,DefaultValidityLength,ClassFees);
            }
            else
            {
                return null;
            }

            
        }

        public static clsBuisnessLicenseClasses Find(string ClassName)
        {
            int ClassID = -1;
            string ClassDescription = "";
            byte MinimumAllowedAge = 0;
            byte DefaultValidityLength = 0;
            decimal ClassFees = -1;



            if (clsDataLicenseClasses.Find(ClassName, ref ClassID, ref ClassDescription, ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees))
            {
                return new clsBuisnessLicenseClasses(ClassName, ClassID, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees);
            }
            else
            {
                return null;
            }


        }

   

        public static DataTable GetAllLicensesClasses()
        {
            return clsDataLicenseClasses.GetAllLicensesClasses();
        }
    }
}
