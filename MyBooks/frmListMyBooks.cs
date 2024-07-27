using BookLibrary.Books.Controls;
using BookLibrary.Borrowings.Controls;
using BookLibrary.Global_Classes;
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

namespace BookLibrary.MyBooks
{
    public partial class frmListMyBooks : Form
    {
        public frmListMyBooks()
        {
            InitializeComponent();
        }

        DataTable _dtMyBooks = clsBorrowingRecords.GetAllBorrowingRecordsByUserID(clsGlobal.CurrentUser.UserID);

        ctrlBorrowedBook ctrl;

        private void frmListMyBooks_Load(object sender, EventArgs e)
        {
            _ListMyBooks();
        }

        void _ListMyBooks()
        {
            for (int i = 0; i < _dtMyBooks.Rows.Count; i++)
            {
                ctrl = new ctrlBorrowedBook();
                this.flpnlListMyBooks.Controls.Add(ctrl);
                ctrl.LoadBorrowedBookInfo(Convert.ToInt32(_dtMyBooks.Rows[i][0]));
                ctrl = null;
            }
        }
    }
}
