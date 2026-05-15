using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;

namespace BuisnessAccessLayer2
{
    public class clsBuisnessCountry
    {
        public int CountryID { get; set; }

        public clsBuisnessCountry(int CountryID , string CountryName)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
        }
        public string CountryName { get; set; }

        public static clsBuisnessCountry Find(int ID)
        {
            string CountryName = "";
            
            if(clsDataCountry.Find(ID, ref CountryName))
            {
                return new clsBuisnessCountry(ID, CountryName);
            }
            else
            {
                return null;
            }
        }
        public static clsBuisnessCountry Find(string CountryName)
        {
            int ID  = -1;

            if (clsDataCountry.Find(CountryName, ref ID))
            {
                return new clsBuisnessCountry(ID, CountryName);
            }
            else
            {
                return null;
            }
        }
        public static DataTable GetAllCountries()
        {
            return clsDataCountry.GetAllCountries();
        }
    }
}
