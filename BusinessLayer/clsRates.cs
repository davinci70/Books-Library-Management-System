using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsRates
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int RateID { set; get; }
        public int BookID { set; get; }
        public int UserID { set; get; }
        public int UserRating { set; get; }

        public clsRates()
        {

            this.RateID = -1;
            this.BookID = -1;
            this.UserID = -1;
            this.UserRating = -1;

            Mode = enMode.AddNew;
        }

        private clsRates(int RateID, int BookID, int UserID, int UserRating)
        {

            this.RateID = RateID;
            this.BookID = BookID;
            this.UserID = UserID;
            this.UserRating = UserRating;

            Mode = enMode.Update;
        }
        public static DataTable GetAllRates()
        {
            return clsRatesData.GetAllRates();
        }
        private bool _AddNewRate()
        {
            //call DataAccess Layer 

            this.RateID = clsRatesData.AddNewRate(this.BookID, this.UserID, this.UserRating);

            return (this.RateID != -1);
        }
        private bool _UpdateRate()
        {
            //call DataAccess Layer 

            return clsRatesData.UpdateRate(this.RateID, this.BookID, this.UserID, this.UserRating);
        }
        public static bool DeleteRate(int RateID)
        {
            return clsRatesData.DeleteRate(RateID);
        }
        public static clsRates Find(int RateID)
        {

            int BookID = -1; int UserID = -1; int UserRating = -1;

            bool IsFound = clsRatesData.GetRateInfoByID
                                      (
                                          RateID, ref BookID, ref UserID, ref UserRating
                                      );

            if (IsFound)
                //we return new object of that person with the right data
                return new clsRates(RateID, BookID, UserID, UserRating);
            else
                return null;
        }
        
        public static clsRates FindByUserIDandBookID(int UserID, int BookID)
        {

            int RateID = -1; int UserRating = -1;

            bool IsFound = clsRatesData.GetRateInfoByUserIDandBookID
                                      (
                                          ref RateID, BookID, UserID, ref UserRating
                                      );

            if (IsFound)
                //we return new object of that person with the right data
                return new clsRates(RateID, BookID, UserID, UserRating);
            else
                return null;
        }
        public static bool IsRateExistByUserIDandBookID(int UserID, int BookID)
        {
            return clsRatesData.IsRateExistByUserIDandBookID(UserID, BookID);
        }
        
        public static bool IsRateExistByBookID(int BookID)
        {
            return clsRatesData.IsRateExistByBookID(BookID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewRate())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    break;

                case enMode.Update:
                    if (_UpdateRate())
                        return true;
                    break;
            }

            return false;
        }

        public static int CalculateTheRateOfTheBook(int BookID)
        {
            if (IsRateExistByBookID(BookID))

            return ((clsRatesData.CalculateRate(BookID, 5) * 5) + (clsRatesData.CalculateRate(BookID, 4) * 4) +
                (clsRatesData.CalculateRate(BookID, 3) * 3) + (clsRatesData.CalculateRate(BookID, 2) * 2) +
                clsRatesData.CalculateRate(BookID, 1))
                
                / 
                
                (clsRatesData.CalculateRate(BookID, 5) + clsRatesData.CalculateRate(BookID, 4) +
                clsRatesData.CalculateRate(BookID, 3) + clsRatesData.CalculateRate(BookID, 2) +
                clsRatesData.CalculateRate(BookID, 1));
            
            return 0;
        }
    }
}
