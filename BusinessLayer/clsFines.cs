using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsFines
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int FineID { set; get; }
        public int UserID { set; get; }
        public int BorrowingRecordID { set; get; }
        public int NumberOfLateDays { set; get; }
        public decimal FineAmount { set; get; }
        public bool PaymentStatus { set; get; }

        public clsFines()
        {

            this.FineID = -1;
            this.UserID = -1;
            this.BorrowingRecordID = -1;
            this.NumberOfLateDays = -1;
            this.FineAmount = 0;
            this.PaymentStatus = false;

            Mode = enMode.AddNew;
        }

        private clsFines(int FineID, int UserID, int BorrowingRecordID, int NumberOfLateDays, decimal FineAmount, bool PaymentStatus)
        {

            this.FineID = FineID;
            this.UserID = UserID;
            this.BorrowingRecordID = BorrowingRecordID;
            this.NumberOfLateDays = NumberOfLateDays;
            this.FineAmount = FineAmount;
            this.PaymentStatus = PaymentStatus;

            Mode = enMode.Update;
        }
        public static DataTable GetAllFines()
        {
            return clsFinesData.GetAllFines();
        }
        private bool _AddNewFine()
        {
            //call DataAccess Layer 

            this.FineID = clsFinesData.AddNewFine(this.UserID, this.BorrowingRecordID, this.NumberOfLateDays, this.FineAmount, this.PaymentStatus);

            return (this.FineID != -1);
        }
        private bool _UpdateFine()
        {
            //call DataAccess Layer 

            return clsFinesData.UpdateFine(this.FineID, this.UserID, this.BorrowingRecordID, this.NumberOfLateDays, this.FineAmount, this.PaymentStatus);
        }
        public static bool DeleteFine(int FineID)
        {
            return clsFinesData.DeleteFine(FineID);
        }
        public static clsFines Find(int FineID)
        {

            int UserID = -1; int BorrowingRecordID = -1; int NumberOfLateDays = -1; decimal FineAmount = 0;
            bool PaymentStatus = false;

            bool IsFound = clsFinesData.GetFineInfoByID
                                      (
                                          FineID, ref UserID, ref BorrowingRecordID, ref NumberOfLateDays,
      ref FineAmount, ref PaymentStatus
                                      );

            if (IsFound)
                //we return new object of that person with the right data
                return new clsFines(FineID, UserID, BorrowingRecordID, NumberOfLateDays, FineAmount, PaymentStatus);
            else
                return null;
        }
        public static bool IsFineExist(int FineID)
        {
            return clsFinesData.IsFineExist(FineID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewFine())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    break;

                case enMode.Update:
                    if (_UpdateFine())
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }
    }
}
