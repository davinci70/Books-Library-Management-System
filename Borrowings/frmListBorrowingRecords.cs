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

namespace BookLibrary.Borrowings
{
    public partial class frmListBorrowingRecords : Form
    {
        public frmListBorrowingRecords()
        {
            InitializeComponent();
        }

        DataTable _dtBorrowings = clsBorrowingRecords.GetAllBorrowingRecords();

        private void frmListBorrowingRecords_Load(object sender, EventArgs e)
        {
            dgvBorrowingRecords.DataSource = _dtBorrowings;

            if (dgvBorrowingRecords.Rows.Count > 0)
            {
                dgvBorrowingRecords.Columns[0].Width = 200;
                dgvBorrowingRecords.Columns[1].Width = 80;
                dgvBorrowingRecords.Columns[2].Width = 80;
                
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            if (txtFilterValue.Text.Trim() == "")
            { 
                _dtBorrowings.DefaultView.RowFilter = "";
                return;
            }

            if (int.TryParse(txtFilterValue.Text, out int value))
                _dtBorrowings.DefaultView.RowFilter = string.Format("[{0}] = {1}", dgvBorrowingRecords.Columns[1].Name, value);      
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
