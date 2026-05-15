using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccessLayer;

namespace BuisnessAccessLayer2
{
    public class clsUserBuisness
    {
        public int UserID { set; get; }

        public string UserName { set; get; }

        public int PersonID { set; get; }

        public bool IsActive { set; get; }

        public string Password { set; get; }


        public clsUserBuisness()
        {
            this.UserID = -1;
            this.UserName = "";
            this.Password = "";
            this.IsActive = false;
            this.PersonID = -1;
            _Mode = enMode.AddNew;
        }
        enum enMode { AddNew = 1, Update = 2 }

        enMode _Mode = enMode.AddNew;

        public bool UpdateUser()
        {
            return clsDataUser.UpdateUser(this.UserID, this.UserName, this.Password, this.PersonID,this.IsActive);


        }
        public clsUserBuisness(int UserID,int PersonID ,string UserName,string Password,bool IsActive)
        {
            this.UserID = UserID;
            this.IsActive=IsActive;
            this.UserName = UserName;
            this.Password = Password;
            this.PersonID = PersonID;

            _Mode = enMode.Update;
        }
        public static clsUserBuisness FindByUserID(int ID)
        {
            string UserName = "";
            string Password = "";
            int PersonID = 0;
            bool IsActive = true;


            if (clsDataUser.FindByUserID(ID, ref UserName, ref Password, ref PersonID, ref IsActive))
            {
                return new clsUserBuisness(ID, PersonID, UserName, Password, IsActive);
            }
            else
            {
                return null; 
            }

        }

        public static clsUserBuisness FindByPersonID(int ID)
        {
            string UserName = "";
            string Password = "";
            int UserID = 0;
            bool IsActive = true;


            if (clsDataUser.FindByPersonID(ID, ref UserName, ref Password, ref UserID, ref IsActive))
            {
                return new clsUserBuisness(UserID, ID, UserName, Password, IsActive);
            }
            else
            {
                return null;
            }

        }

        public static clsUserBuisness FindByUserNameAndPassword(string UserName, string Password)
        {
            int PersonID = 0;
            int UserID = 0;
            bool IsActive = true;


            if (clsDataUser.FindByUserNameAndPassword(UserName, Password, ref UserID, ref PersonID, ref IsActive))
            {
                return new clsUserBuisness(UserID, PersonID, UserName, Password, IsActive);
            }
            else
            {
                return null;
            }

        }
        public static DataTable FilterByInt(string Column,int ID)
        {
            return clsDataUser.FilterByInt(Column, ID);
        }

        public static DataTable FilterByUserName(string Column, string UserName)
        {
            return clsDataUser.FilterByUserName(Column, UserName);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        return _AddNewUser();
                    }
                    return false;

                case enMode.Update:
                    {
                        return UpdateUser();
                        return false;
                    }
                    return false;

            }
            return false;
        }
        private bool _AddNewUser()
        {
            this.UserID = clsDataUser.AddNewUser(this.UserName,this.Password,this.PersonID,this.IsActive);

            return (this.UserID != -1);
        }
        public static DataTable GetAllUsers()
        {
            return clsDataUser.GetAllUsers();
        }
        public static bool DeleteUser(int ID)


        {

           
            return clsDataUser.DeleteUser(ID);
        }
        public static DataTable FilterByFullName(string Column,string value)
        {
            return clsDataUser.FilterByFullName(Column,value);
        }

        public static DataTable FilterByIsActive(string Column, bool value)
        {
            return clsDataUser.FilterByIsActive(Column, value);
        }

        public static bool isUserExist(string UserName)
        {
            return clsDataUser.IsUserExist(UserName);
        }
    }
}
