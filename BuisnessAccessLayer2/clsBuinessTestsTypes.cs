using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;
using DataAccessLayer;


namespace BuisnessAccessLayer2
{
    public class clsBuinessTestTypes
    {
        public int TestTypeID { get; set; }
        public string TestTypeTitle { set; get; }
        public string TestTypeDescription { set; get; }

        public decimal TestTypeFees { set; get; }
        public static DataTable GetAllTests()
        {
            return clsDataTestTypes.GetAllTests();
        }

        private bool _AddNewTestType()
        {
            //call DataAccess Layer 

            this.TestTypeID = clsDataTestTypes.AddNewTestType(this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);

            return (this.TestTypeID != -1);
        }
        public bool UpdateTestTypes()
        {
            return clsDataTestTypes.UpdateTestType(this.TestTypeID, this.TestTypeTitle,this.TestTypeDescription, this.TestTypeFees);
        }

        public clsBuinessTestTypes(int ID, string Title,string Description ,Decimal Fees)
        {
            this.TestTypeID = ID;
            this.TestTypeTitle = Title;
            this.TestTypeDescription = Description;
            this.TestTypeFees = Fees;
        }

      
        public static clsBuinessTestTypes Find(int ID)
        {
            string Title = "";
            string Description = "";
            decimal Fees = 0;


            if (clsDataTestTypes.Find(ID, ref Title, ref Description, ref Fees))
            {
                return new clsBuinessTestTypes(ID, Title, Description,Fees);
            }
            else
            {
                return null;
            }

        }
    }
}
