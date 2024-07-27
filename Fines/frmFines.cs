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

namespace BookLibrary.Fines
{
    public partial class frmFines : Form
    {
        public frmFines()
        {
            InitializeComponent();
        }

        DataTable _dtFines = clsFines.GetAllFines();
        clsFines _Fine;

        private void frmFines_Load(object sender, EventArgs e)
        {
            dgvFines.DataSource = _dtFines;

            if (dgvFines.Rows.Count > 0)
            {
                dgvFines.Columns[0].Width = 80;
                dgvFines.Columns[1].Width = 80;
            }
        }

        void _RefreshData()
        {
            _dtFines = clsFines.GetAllFines();
            dgvFines.DataSource = _dtFines;
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            if (txtFilterValue.Text.Trim() == "")
            {
                _dtFines.DefaultView.RowFilter = "";
                return;
            }

            if (int.TryParse(txtFilterValue.Text, out int value))
                _dtFines.DefaultView.RowFilter = string.Format("[{0}] = {1}", dgvFines.Columns[1].Name, value);
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void setAsPaidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Fine = clsFines.Find((int)dgvFines.CurrentRow.Cells[0].Value);

            if (_Fine == null)
                return;

            _Fine.PaymentStatus = true;
            _Fine.Save();

            _RefreshData();
        }
    }
}
