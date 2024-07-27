using BookLibrary.Books;
using BookLibrary.Borrowings;
using BookLibrary.Fines;
using BookLibrary.Global_Classes;
using BookLibrary.Login;
using BookLibrary.MyBooks;
using BookLibrary.Properties;
using BookLibrary.Users;
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

namespace BookLibrary
{
    public partial class frmMain : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        public frmMain()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
        }


        void OpenChildForm(Form ChildForm)
        {
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;

            pnlDesktop.Controls.Add(ChildForm);
            ChildForm.BringToFront();
            ChildForm.Show();

        }

        private void btnAddNewBook_Click(object sender, EventArgs e)
        {
            frmAddEditBook frm = new frmAddEditBook();
            frm.ShowDialog();
       
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmListBooks());  
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmListUsers());
        }

        private void pbLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
            clsGlobal.CurrentUser = null;           
            frmLogin frm = new frmLogin();
            frm.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            _LoadCurrentUserInfo();
            btnBooks.PerformClick();
        }

        void _LoadCurrentUserInfo()
        {
            lblCurrentUsername.Text = clsGlobal.CurrentUser.UserName;

            if (!clsGlobal.CurrentUser.IsAdmin)
            {
                lblAdmin.Visible = false;
                btnUsers.Visible = false;
                btnBorrowings.Visible = false;
                btnFines.Visible = false;
                btnAddNewBook.Visible = false;
            }

            if (clsGlobal.CurrentUser.ImagePath == null || clsGlobal.CurrentUser.ImagePath == "")
            {
                if (clsGlobal.CurrentUser.Gender == 1)
                    pbCurrentUserImage.Image = Resources.man_avatar;
                else
                    pbCurrentUserImage.Image= Resources.woman_avatar;
            }
            else
                pbCurrentUserImage.ImageLocation = clsGlobal.CurrentUser.ImagePath;
        }

        private void btnMyBooks_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmListMyBooks());
        }

        private void btnBorrowings_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmListBorrowingRecords());
        }

        private void btnFines_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmFines());
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
