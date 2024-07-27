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
    public class clsBooks
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int BookID { set; get; }
        public string Title { set; get; }
        public string Author { set; get; }
        public string ISBN { set; get; }
        public DateTime PublicationDate { set; get; }
        public string Genre { set; get; }
        public int Quantity { set; get; }
        public string? AdditionalDetails { set; get; }
        public string? ImagePath { set; get; }

        public clsBooks()
        {

            this.BookID = -1;
            this.Author = "";
            this.Title = "";
            this.ISBN = "";
            this.PublicationDate = DateTime.Now;
            this.Genre = "";
            this.Quantity = 0;
            this.AdditionalDetails = "";
            this.ImagePath = "";

            Mode = enMode.AddNew;
        }

        private clsBooks(int BookID, string Author, string Title, string ISBN, DateTime PublicationDate, string Genre, int Quantity, string? AdditionalDetails, string? ImagePath)
        {

            this.BookID = BookID;
            this.Author = Author;
            this.Title = Title;
            this.ISBN = ISBN;
            this.PublicationDate = PublicationDate;
            this.Genre = Genre;
            this.Quantity = Quantity;
            this.AdditionalDetails = AdditionalDetails;
            this.ImagePath = ImagePath;

            Mode = enMode.Update;
        }
        public static DataTable GetAllBooks()
        {
            return clsBooksData.GetAllBooks();
        }
        private bool _AddNewBook()
        {
            //call DataAccess Layer 

            this.BookID = clsBooksData.AddNewBook(this.Author, this.Title, this.ISBN, this.PublicationDate, this.Genre, this.Quantity, this.AdditionalDetails, this.ImagePath);

            return (this.BookID != -1);
        }
        private bool _UpdateBook()
        {
            //call DataAccess Layer 

            return clsBooksData.UpdateBook(this.BookID, this.Author, this.Title, this.ISBN, this.PublicationDate, this.Genre, this.Quantity, this.AdditionalDetails, this.ImagePath);
        }
        public static bool DeleteBook(int BookID)
        {
            return clsBooksData.DeleteBook(BookID);
        }
        public static clsBooks Find(int BookID)
        {

            string Author = ""; string Title = ""; string ISBN = ""; DateTime PublicationDate = DateTime.Now; string Genre = "";
            int Quantity = 0; string? AdditionalDetails = null; string? ImagePath = null;

            bool IsFound = clsBooksData.GetBookInfoByID
                                      (
                                          BookID, ref Author, ref Title, ref ISBN, ref PublicationDate,
      ref Genre, ref Quantity, ref AdditionalDetails, ref ImagePath
                                      );

            if (IsFound)
                //we return new object of that person with the right data
                return new clsBooks(BookID, Author, Title, ISBN, PublicationDate, Genre, Quantity, AdditionalDetails, ImagePath);
            else
                return null;
        }
        public static bool IsBookExist(int BookID)
        {
            return clsBooksData.IsBookExist(BookID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewBook())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    break;

                case enMode.Update:
                    if (_UpdateBook())
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }
        public static int NextBookToBorrow(int BookID)
        {
            return clsBooksData.NextCopyToBorrow(BookID);
        }
    }
}
