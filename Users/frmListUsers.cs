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

namespace BookLibrary.Users
{
    public partial class frmListUsers : Form
    {
        public frmListUsers()
        {
            InitializeComponent();
        }

        private static DataTable _dtUsers = clsUsers.GetAllUsers();

        private void _RefreshData()
        {
            _dtUsers = clsUsers.GetAllUsers();
            dgvUsers.DataSource = _dtUsers;
        }

        private void frmListUsers_Load(object sender, EventArgs e)
        {
            dgvUsers.DataSource = _dtUsers;

            if (dgvUsers.Rows.Count > 0)
            {
                dgvUsers.Columns[0].Width = 60;
                dgvUsers.Columns[1].Width = 150;
                dgvUsers.Columns[3].Width = 65;
                dgvUsers.Columns[5].Width = 150;
            }
;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser();
            frm.ShowDialog();
            _RefreshData();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

                if (int.TryParse(txtFilterValue.Text, out int value))
                    _dtUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", dgvUsers.Columns[0].Name, value);
                else
                    _dtUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", dgvUsers.Columns[1].Name, txtFilterValue.Text.Trim());
        }

        private void showUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowUserInfo frm = new frmShowUserInfo((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser();
            frm.ShowDialog();
            _RefreshData();
        }

        private void editUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshData();
        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete User [" + dgvUsers.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                //Perform Delete and refresh
                if (clsUsers.DeleteUser((int)dgvUsers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("User Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshData();
                }

                else
                    MessageBox.Show("User was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
