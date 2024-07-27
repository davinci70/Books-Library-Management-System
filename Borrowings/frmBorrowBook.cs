using BookLibrary.Global_Classes;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookLibrary.Borrowings
{
    public partial class frmBorrowBook : Form
    {

        public frmBorrowBook(int BookID)
        {
            InitializeComponent();
            (new DropShadow()).ApplyShadows(this);

            _BookID = BookID;

            this.FormBorderStyle = FormBorderStyle.None;
        }

        int _BookID;
        clsBorrowingRecords _BorrowingRecord;

        private void frmBorrowBook_Load(object sender, EventArgs e)
        {
            ctrlBookInfo1.ShowBookDetails(_BookID);
            lblBorrowingDate.Text = DateTime.Now.ToString("d");
            lblDueDate.Text = DateTime.Now.AddDays(7).ToString("d");
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            if (clsBookCopies.IsBookBorrowedByUser(_BookID, clsGlobal.CurrentUser.UserID))
            {
                MessageBox.Show("You already borrowed a copy from this book, \n" +
                    "you can only borrow one copy.", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _BorrowingRecord = new clsBorrowingRecords();

            _BorrowingRecord.UserID = clsGlobal.CurrentUser.UserID;
            _BorrowingRecord.BorrowingDate = Convert.ToDateTime(lblBorrowingDate.Text);
            _BorrowingRecord.DueDate = Convert.ToDateTime(lblDueDate.Text);
            _BorrowingRecord.ActualReturnDate = null;
            _BorrowingRecord.CopyID = clsBooks.NextBookToBorrow(_BookID);            

            if (_BorrowingRecord.Save())
            {
                clsBookCopies.SetCopyAsNotAvailable(_BorrowingRecord.CopyID);

                MessageBox.Show("Book has been borrowed successfuly", "Done",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to borrow the book", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
