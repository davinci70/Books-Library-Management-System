#nullable enable

using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsUsers
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int UserID { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public DateTime DateOfBirth { set; get; }
        public byte Gender { set; get; }
        public string PhoneNumber { set; get; }
        public string Email { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public bool IsAdmin { set; get; }
        public string? ImagePath { set; get; }

        public clsUsers()
        {

            this.UserID = -1;
            this.FirstName = "";
            this.LastName = "";
            this.DateOfBirth = DateTime.Now;
            this.Gender = 0;
            this.PhoneNumber = "";
            this.Email = "";
            this.UserName = "";
            this.Password = "";
            this.IsAdmin = false;
            this.ImagePath = "";

            Mode = enMode.AddNew;
        }

        private clsUsers(int UserID, string FirstName, string LastName, DateTime DateOfBirth, byte Gender, string PhoneNumber, string Email, string UserName, string Password, bool IsAdmin, string? ImagePath)
        {

            this.UserID = UserID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.PhoneNumber = PhoneNumber;
            this.Email = Email;
            this.UserName = UserName;
            this.Password = Password;
            this.IsAdmin = IsAdmin;
            this.ImagePath = ImagePath;

            Mode = enMode.Update;
        }
        public static DataTable GetAllUsers()
        {
            return clsUsersData.GetAllUsers();
        }
        private bool _AddNewUser()
        {
            //call DataAccess Layer 

            this.UserID = clsUsersData.AddNewUser(this.FirstName, this.LastName, this.DateOfBirth, this.Gender, this.PhoneNumber, this.Email, this.UserName, this.Password, this.IsAdmin, this.ImagePath);

            return (this.UserID != -1);
        }
        private bool _UpdateUser()
        {
            //call DataAccess Layer 

            return clsUsersData.UpdateUser(this.UserID, this.FirstName, this.LastName, this.DateOfBirth, this.Gender, this.PhoneNumber, this.Email, this.UserName, this.Password, this.IsAdmin, this.ImagePath);
        }
        public static bool DeleteUser(int UserID)
        {
            return clsUsersData.DeleteUser(UserID);
        }
        public static clsUsers Find(int UserID)
        {

            string FirstName = ""; string LastName = ""; DateTime DateOfBirth = DateTime.Now; byte Gender = 0;
            string PhoneNumber = ""; string Email = ""; string UserName = ""; string Password = "";
            bool IsAdmin = false; string? ImagePath = null;

            bool IsFound = clsUsersData.GetUserInfoByID
                                      (
                                          UserID, ref FirstName, ref LastName, ref DateOfBirth,
      ref Gender, ref PhoneNumber, ref Email, ref UserName,
      ref Password, ref IsAdmin, ref ImagePath
                                      );

            if (IsFound)
                //we return new object of that person with the right data
                return new clsUsers(UserID, FirstName, LastName, DateOfBirth, Gender, PhoneNumber, Email, UserName, Password, IsAdmin, ImagePath);
            else
                return null;
        }
        public static bool IsUserExist(int UserID)
        {
            return clsUsersData.IsUserExist(UserID);
        }

        public static clsUsers FindByUsernameAndPassword(string UserName, string Password)
        {
            int UserID = -1; string FirstName = ""; string LastName = ""; DateTime DateOfBirth = DateTime.Now; byte Gender = 0;
            string PhoneNumber = ""; string Email = ""; 
            bool IsAdmin = false; string? ImagePath = null;

            bool IsFound = clsUsersData.GetUserInfoByUsernameAndPassword
                                (ref UserID, ref FirstName, ref LastName, ref DateOfBirth,
            ref Gender, ref PhoneNumber, ref Email, UserName,
            Password, ref IsAdmin, ref ImagePath);

            if (IsFound)
                //we return new object of that User with the right data
                return new clsUsers(UserID, FirstName, LastName, DateOfBirth, Gender, PhoneNumber, Email, UserName, Password, IsAdmin, ImagePath);
            else
                return null;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    break;

                case enMode.Update:
                    if (_UpdateUser())
                        return true;
                    break;
            }

            return false;
        }
    }
}
