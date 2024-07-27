using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsBorrowingRecords
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int BorrowingRecordID { set; get; }
        public int UserID { set; get; }
        public int CopyID { set; get; }
        public clsBookCopies BookCopyInfo { set; get; }
        public DateTime BorrowingDate { set; get; }
        public DateTime DueDate { set; get; }
        public DateTime? ActualReturnDate { set; get; }

        public clsBorrowingRecords()
        {

            this.BorrowingRecordID = -1;
            this.UserID = -1;
            this.CopyID = -1;            
            this.BorrowingDate = DateTime.Now;
            this.DueDate = DateTime.Now;
            this.ActualReturnDate = DateTime.Now;

            Mode = enMode.AddNew;
        }

        private clsBorrowingRecords(int BorrowingRecordID, int UserID, int CopyID, DateTime BorrowingDate, DateTime DueDate, DateTime? ActualReturnDate)
        {

            this.BorrowingRecordID = BorrowingRecordID;
            this.UserID = UserID;
            this.CopyID = CopyID;
            this.BookCopyInfo = clsBookCopies.Find(CopyID);
            this.BorrowingDate = BorrowingDate;
            this.DueDate = DueDate;
            this.ActualReturnDate = ActualReturnDate;

            Mode = enMode.Update;
        }
        public static DataTable GetAllBorrowingRecords()
        {
            return clsBorrowingRecordsData.GetAllBorrowingRecords();
        }
        public static DataTable GetAllBorrowingRecordsByUserID(int UserID)
        {
            return clsBorrowingRecordsData.GetAllBorrowingRecordsByUserID(UserID);
        }
        private bool _AddNewBorrowingRecord()
        {
            //call DataAccess Layer 

            this.BorrowingRecordID = clsBorrowingRecordsData.AddNewBorrowingRecord(this.UserID, this.CopyID, this.BorrowingDate, this.DueDate, this.ActualReturnDate);

            return (this.BorrowingRecordID != -1);
        }
        private bool _UpdateBorrowingRecord()
        {
            //call DataAccess Layer 

            return clsBorrowingRecordsData.UpdateBorrowingRecord(this.BorrowingRecordID, this.UserID, this.CopyID, this.BorrowingDate, this.DueDate, this.ActualReturnDate);
        }
        public static bool DeleteBorrowingRecord(int BorrowingRecordID)
        {
            return clsBorrowingRecordsData.DeleteBorrowingRecord(BorrowingRecordID);
        }
        public static clsBorrowingRecords Find(int BorrowingRecordID)
        {

            int UserID = -1; int CopyID = -1; DateTime BorrowingDate = DateTime.Now; DateTime DueDate = DateTime.Now;
            DateTime? ActualReturnDate = null;

            bool IsFound = clsBorrowingRecordsData.GetBorrowingRecordInfoByID
                                      (
                                          BorrowingRecordID, ref UserID, ref CopyID, ref BorrowingDate,
      ref DueDate, ref ActualReturnDate
                                      );

            if (IsFound)
                //we return new object of that person with the right data
                return new clsBorrowingRecords(BorrowingRecordID, UserID, CopyID, BorrowingDate, DueDate, ActualReturnDate);
            else
                return null;
        }
        public static bool IsBorrowingRecordExist(int BorrowingRecordID)
        {
            return clsBorrowingRecordsData.IsBorrowingRecordExist(BorrowingRecordID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewBorrowingRecord())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    break;

                case enMode.Update:
                    if (_UpdateBorrowingRecord())
                        return true;
                    break;
            }

            return false;
        }
    }
}
