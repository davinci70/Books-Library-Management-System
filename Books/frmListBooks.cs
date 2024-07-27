using BookLibrary.Books.Controls;
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

namespace BookLibrary.Books
{
    public partial class frmListBooks : Form
    {
        DataTable _dtBooks = clsBooks.GetAllBooks();

        public frmListBooks()
        {
            InitializeComponent();
        }

        ctrlBookCover ctrl;
        private void frmListBooks_Load(object sender, EventArgs e)
        {
            ListBooks();            
        }

        private void ListBooks()
        {
            for (int i = 0; i < _dtBooks.Rows.Count; i++)
            {
                ctrl = new ctrlBookCover();
                this.flpnlListBooks.Controls.Add(ctrl);
                ctrl.LoadBookInfo(Convert.ToInt32(_dtBooks.Rows[i][0]));
                ctrl = null;
            }
        }
    }
}
