using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccessLayer;

namespace BuisnessAccessLayer2
{
    public class clsBuisnessLocalDrivingApplicationLicense
    {
        public int LocalDrivingApplicationID { get; set; }

        public int ApplicaitonID { get; set; }

        public int licenseClassID { get; set; }

        public clsBuisnessLocalDrivingApplicationLicense(int localDrivingApplicationID, int applicaitonID, int licenseClassID)
        {
            LocalDrivingApplicationID = localDrivingApplicationID;
            ApplicaitonID = applicaitonID;
            this.licenseClassID = licenseClassID;
        }

        public clsBuisnessLocalDrivingApplicationLicense()
        {
            LocalDrivingApplicationID = -1;
            ApplicaitonID = -1;
            licenseClassID = -1;
        }

        public static clsBuisnessLocalDrivingApplicationLicense Find(int ID)
        {
            int ApplicationID = -1;
            int LicenseClassID = -1;



            if (clsDataLocalDrivingApplicationLicense.Find(ID, ref ApplicationID, ref LicenseClassID))
            {
                return new clsBuisnessLocalDrivingApplicationLicense(ID, ApplicationID,LicenseClassID);
            }
            else
            {
                return null;
            }

        }

        public bool AddNewLocalDrivingApp()
        {
            this.LocalDrivingApplicationID = clsDataLocalDrivingApplicationLicense.AddNewLocalDrivingApp(this.ApplicaitonID, this.licenseClassID);

            return (this.LocalDrivingApplicationID != -1);
        }
        public static bool IsAppExist(int LicenseClassID, int PeronsID)
        {
            return clsDataLocalDrivingApplicationLicense.IsAppExist(LicenseClassID, PeronsID);
        }


        public bool DeleteLocalApplication()


        {
            bool isFound =  clsDataLocalDrivingApplicationLicense.DeleteLocalApplication(this.LocalDrivingApplicationID);

            if (isFound)
            {
                return clsBuisnessApplication.Delete(this.ApplicaitonID);
            }
            return false;
        }


        public bool UpdateLocalApp()
        {
            return clsDataLocalDrivingApplicationLicense.UpdateLocalApplication(this.LocalDrivingApplicationID, this.licenseClassID);
        }


        public static byte GetAppStatus(string LicenseClass,int PersonID)
        {
            return clsDataLocalDrivingApplicationLicense.GetAppStatus(LicenseClass, PersonID);
        }

       
    }
}
