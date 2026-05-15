using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;


namespace BuisnessAccessLayer2
{
    public class clsBuisnessApplicationTypes
    {
        public int ApplicationTypeID { set; get; }

        public string ApplicationTypeTitle { set; get; }

        public decimal ApplicationFees { set; get; }

        public clsBuisnessApplicationTypes(int ID , string Title, Decimal Fees)
        {
            this.ApplicationTypeID = ID;
            this.ApplicationTypeTitle = Title;
            this.ApplicationFees = Fees;
        }

        private bool _AddNewApplicationType()
        {
            //call DataAccess Layer 

            this.ApplicationTypeID = clsDataApplicationTypes.AddNewApplicationType(this.ApplicationTypeTitle, this.ApplicationFees);


            return (this.ApplicationTypeID != -1);
        }
        public bool UpdateApplicationType()
        {
            return clsDataApplicationTypes.UpdateApplicationType(this.ApplicationTypeID, this.ApplicationTypeTitle, this.ApplicationFees);
        }
        public static clsBuisnessApplicationTypes Find(int ID)
        {
            string Title = "";
            decimal Fees = 0 ;


            if (clsDataApplicationTypes.Find(ID, ref Title, ref Fees))
            {
                return new clsBuisnessApplicationTypes( ID, Title, Fees);
            }
            else
            {
                return null;
            }

        }
        public static DataTable GetAllApplicationTypes()
        {
            return clsDataApplicationTypes.GetAllApplicationTypes();
        }
    
    }
}
