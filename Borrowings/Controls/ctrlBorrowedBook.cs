using BookLibrary.Properties;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookLibrary.Borrowings.Controls
{
    public partial class ctrlBorrowedBook : UserControl
    {
        public ctrlBorrowedBook()
        {
            InitializeComponent();
        }

        clsBorrowingRecords _BorrowingRecord;

        public clsBorrowingRecords BorrowingRecord
        { get { return _BorrowingRecord; } }

        public void LoadBorrowedBookInfo(int BorrowingRecordID)
        {
            _BorrowingRecord = clsBorrowingRecords.Find(BorrowingRecordID);

            if (_BorrowingRecord != null)
                _LoadData();
            else
                _ResetDefaultValues();
        }

        void _LoadData()
        {
            pbBookCover.ImageLocation = _BorrowingRecord.BookCopyInfo.BookInfo.ImagePath;
            lblTitle.Text = _BorrowingRecord.BookCopyInfo.BookInfo.Title;
            lblAuthor.Text = _BorrowingRecord.BookCopyInfo.BookInfo.Author;
            lblBorrowDate.Text = _BorrowingRecord.BorrowingDate.ToString("d");
            lblDueDate.Text = _BorrowingRecord.DueDate.ToString("d");
            lblLateDays.Text = _CalculateLateDays(_BorrowingRecord.DueDate).ToString();
        }

        int _CalculateLateDays(DateTime DueDate)
        {
            double LateDays = 0;

            if (DateTime.Now >  DueDate)
            {
                LateDays = DateTime.Now.Subtract(DueDate).TotalDays;
            }

            return Convert.ToInt16(Math.Floor(Convert.ToDecimal(LateDays)));
        }

        void _ResetDefaultValues()
        {
            pbBookCover.Image = Resources.book__3_;
            lblTitle.Text = "Title";
            lblAuthor.Text = "Author";
            lblBorrowDate.Text = "dd/mm/yyyy";
            lblDueDate.Text = "dd//mm/yyyy";
            lblLateDays.Text = "0";
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (_CalculateLateDays(_BorrowingRecord.DueDate) > 0)
            {
                MessageBox.Show("You are " + _CalculateLateDays(_BorrowingRecord.DueDate) +
                    " days late!\n" + "You will be charged " + (_CalculateLateDays(_BorrowingRecord.DueDate) * 3) + "$",
                    "Fine", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                _IssueFine();
                _ReturnBook();
                return;
            }

            _ReturnBook();           
        }

        void _IssueFine()
        {
            clsFines Fine = new clsFines();

            Fine.UserID = _BorrowingRecord.UserID;
            Fine.BorrowingRecordID = _BorrowingRecord.BorrowingRecordID;
            Fine.NumberOfLateDays = _CalculateLateDays(_BorrowingRecord.DueDate);
            Fine.FineAmount = (_CalculateLateDays(_BorrowingRecord.DueDate) * 3);
            Fine.PaymentStatus = false;

            Fine.Save();
        }
        void _ReturnBook()
        {
            if (
                clsBookCopies.SetCopyAsAvailable(_BorrowingRecord.BookCopyInfo.CopyID))
            {
                _BorrowingRecord.ActualReturnDate = DateTime.Now;
                _BorrowingRecord.Save();

                MessageBox.Show("Book has been returned successfully.", "Returned",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
