using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsBookCopies
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int CopyID { set; get; }
        public int BookID { set; get; }
        public clsBooks BookInfo { set; get; }
        public bool AvailabilityStatus { set; get; }

        public clsBookCopies()
        {

            this.CopyID = -1;
            this.BookID = -1;
            this.AvailabilityStatus = false;

            Mode = enMode.AddNew;
        }

        private clsBookCopies(int CopyID, int BookID, bool AvailabilityStatus)
        {

            this.CopyID = CopyID;
            this.BookID = BookID;
            this.BookInfo = clsBooks.Find(BookID);
            this.AvailabilityStatus = AvailabilityStatus;

            Mode = enMode.Update;
        }
        public static DataTable GetAllBookCopies()
        {
            return clsBookCopiesData.GetAllBookCopies();
        }
        public bool _AddNewCopy()
        {
            //call DataAccess Layer 

            this.CopyID = clsBookCopiesData.AddNewCopy(this.BookID, this.AvailabilityStatus);

            return (this.CopyID != -1);
        }
        public bool _UpdateCopy()
        {
            //call DataAccess Layer 

            return clsBookCopiesData.UpdateCopy(this.CopyID, this.BookID, this.AvailabilityStatus);
        }
        public static bool DeleteCopy(int BookID, int deletedCopies)
        {
            return clsBookCopiesData.DeleteCopy(BookID, deletedCopies);
        }
        public static clsBookCopies Find(int CopyID)
        {

            int BookID = -1; bool AvailabilityStatus = false;

            bool IsFound = clsBookCopiesData.GetCopyInfoByID
                                      (
                                          CopyID, ref BookID, ref AvailabilityStatus
                                      );

            if (IsFound)
                //we return new object of that person with the right data
                return new clsBookCopies(CopyID, BookID, AvailabilityStatus);
            else
                return null;
        }
        public static bool IsCopyExist(int CopyID)
        {
            return clsBookCopiesData.IsCopyExist(CopyID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCopy())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    break;

                case enMode.Update:
                    if (_UpdateCopy())
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }
        public static bool SetCopyAsNotAvailable(int CopyID)
        {
            return clsBookCopiesData.SetCopyAsNotAvailable(CopyID);
        }
        public static bool SetCopyAsAvailable(int CopyID)
        {
            return clsBookCopiesData.SetCopyAsAvailable(CopyID);
        }
        public static int CountAvailableCopies(int BookID)
        {
            return clsBookCopiesData.CountAvailableCopies(BookID);
        }
        public static int CountCopiesThatWillBeDeleted(int BookID, int deletedBooks)
        {
            return clsBookCopiesData.CountCopiesThatWillNotBeDeleted(BookID, deletedBooks);
        }
        public static bool IsBookBorrowedByUser(int BookID, int UserID)
        {
            return clsBookCopiesData.IsBookBorrowedByUser(BookID, UserID);
        }
    }
}
