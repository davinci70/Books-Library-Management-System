using BookLibrary.Borrowings;
using BookLibrary.Global_Classes;
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

namespace BookLibrary.Books.Controls
{
    public partial class ctrlBookCover : UserControl
    {
        public ctrlBookCover()
        {
            InitializeComponent();
        }

        clsBooks _Book;

        public clsBooks Book
        { get { return _Book; } }

        public void LoadBookInfo(int bookID)
        {
            _Book = clsBooks.Find(bookID);

            if (_Book != null)
                _LoadInfo();
            else
                _SetDefaultValues();

            if (!clsGlobal.CurrentUser.IsAdmin)
            {
                tsmEditBook.Visible = false;
                tsmDeleteBook.Visible = false;
            }
        }

        void _LoadInfo()
        {
            pbBookCover.ImageLocation = _Book.ImagePath;
            lblAuthor.Text = _Book.Author;
            lblTitle.Text = _Book.Title;
            if (clsBookCopies.CountAvailableCopies(_Book.BookID) > 0)
            {
                lblAvailability.Text = "Available";
                lblAvailability.ForeColor = Color.Green;
            }
            else
            {
                lblAvailability.Text = "Not Available";
                lblAvailability.ForeColor = Color.Red;
            }
            rtBookRate.Value = clsRates.CalculateTheRateOfTheBook(_Book.BookID);
        }

        void _SetDefaultValues()
        {
            pbBookCover.Image = Resources.book__3_;
            lblAuthor.Text = "Author";
            lblTitle.Text = "Title";
            lblAvailability.Text = "Not Available";
            lblAvailability.ForeColor = Color.Red;
        }

        private void tsmShowBookDetails_Click(object sender, EventArgs e)
        {
            frmShowBookInfo frm = new frmShowBookInfo(_Book.BookID);
            frm.ShowDialog();
        }

        private void tsmEditBook_Click(object sender, EventArgs e)
        {
            frmAddEditBook frm = new frmAddEditBook(_Book.BookID);
            frm.ShowDialog();

            
        }

        private void tsmDeleteBook_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ary you sure you want to delete this book?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsBooks.DeleteBook(_Book.BookID))
                {
                    MessageBox.Show("Book has been deleted successfully", "Deleted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to delete book", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsmBorrow_Click(object sender, EventArgs e)
        {
            if (clsBookCopies.CountAvailableCopies(_Book.BookID) <= 0)
            {
                MessageBox.Show("There is no available copy from this book to borrow", "Not Available",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmBorrowBook frm = new frmBorrowBook(_Book.BookID);
            frm.ShowDialog();
        }
    }
}
