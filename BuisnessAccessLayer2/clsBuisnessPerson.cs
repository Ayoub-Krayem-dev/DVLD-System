using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccessLayer;
using System.IO;

namespace BuisnessAccessLayer2
{
    public class clsBuisnessPerson
    {
        public int PersonID { set; get; }
        public string NationalNo { set; get; }

        public string FirstName { set; get; }

        public string SecondName { set; get; }

        public string ThirdName { set; get; }

        public string LastName { set; get; }

        public DateTime DateOfBirth { set; get; }

        public int Gendor { set; get; }

        public string Address { set; get; }

        public string Phone { set; get; }

        public string Email { set; get; }

        public int NationalityCountryID { set; get; }

        public string ImagePath { set; get; }

        enum enMode { AddNew = 1, Update = 2 }

        enMode _Mode = enMode.AddNew;

        private bool _AddNewPerson()
        {
            this.PersonID = clsDataPerson.AddNewPerson(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName,
                this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);

            return (this.PersonID != -1);
        }

     
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        return _AddNewPerson();
                    }
                    return false;

                case enMode.Update:
                    {
                        return UpdatePerson();
                    }
                    return false;

            }
            return false;
        }

        public static bool IsExist(string NationalNumber,int PeronsID)
        {
            return clsDataPerson.IsExist(NationalNumber,PeronsID);
        }

        public static bool DeletePerson(int ID)


        {

            clsBuisnessPerson person = clsBuisnessPerson.Find(ID);

            if(person != null)
            {
                if (!string.IsNullOrEmpty(person.ImagePath) && File.Exists(person.ImagePath)){
                    try
                    {
                        File.Delete(person.ImagePath);
                    }
                    catch
                    {

                    }
                }
            }
            return clsDataPerson.DeletePerson(ID);
        }
        public static DataTable FilterByString(string Column,string value)
        {
            return clsDataPerson.FilterByString(Column,value);
        }

        public static DataTable FilterByPersonID(string Column, int value)
        {
            return clsDataPerson.FilterByInt(Column, value);
        }

        public static DataTable FilterByGendor(string Column, byte value)
        {
            return clsDataPerson.FilterByGendor(Column, value);
        }
        public static DataTable GetAllPeople()
        {
            return clsDataPerson.GetAllPeople();
        }

        public clsBuisnessPerson(int personID, string nationalNo, string firstName, string secondName, string thirdName, string lastName, DateTime dateOfBirth,
            int gendor, string address, string phone, string email, int nationalityCountryID, string imagePath)
        {
            PersonID = personID;
            NationalNo = nationalNo;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gendor = gendor;
            Address = address;
            Phone = phone;
            Email = email;
            NationalityCountryID = nationalityCountryID;
            ImagePath = imagePath;
            _Mode = enMode.Update;
        }

        public clsBuisnessPerson()
        {
            PersonID = -1;
            NationalNo = "";
            FirstName = "";
            SecondName = "";
            ThirdName = "";
            LastName = "";
            DateOfBirth = DateTime.Now;
            Gendor = 0;
            Address = "";
            Phone = "";
            Email = "";
            NationalityCountryID = 0;
            ImagePath = "";
            _Mode = enMode.AddNew;
        }

        public static clsBuisnessPerson Find(int ID)
        {
            string NationalNo = "";
            string FirstName = "";
            string SecondName = "";
            string ThirdName = "";
            string LastName = "";
            DateTime DateOfBirth = DateTime.Now;
            int Gendor = 0;
            string Address = "";
            string Phone = "";
            string Email = "";
            int NationalityCountryID = 0;
            string ImagePath = "";


            if (clsDataPerson.Find(ID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth,
                ref Gendor, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
            {
                return new clsBuisnessPerson(ID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
            }
            else
            {
                return null;
            }

        }
        
            public bool UpdatePerson()
             {
                return clsDataPerson.UpdatePerson(this.PersonID, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName,
                        this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);


             }
            public static clsBuisnessPerson Find(string NationalNo)
            {
                int ID = -1;
                string FirstName = "";
                string SecondName = "";
                string ThirdName = "";
                string LastName = "";
                DateTime DateOfBirth = DateTime.Now;
                int Gendor = 0;
                string Address = "";
                string Phone = "";
                string Email = "";
                int NationalityCountryID = 0;
                string ImagePath = "";


                if (clsDataPerson.Find(NationalNo, ref ID, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth,
                    ref Gendor, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
                {
                    return new clsBuisnessPerson(ID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email,
                        NationalityCountryID, ImagePath);
                }
                else
                {
                    return null;
                }
            }
        public string GetFullName()
        {
            return clsDataPerson.GetFullName(this.PersonID);
        }

        }
    }

    

