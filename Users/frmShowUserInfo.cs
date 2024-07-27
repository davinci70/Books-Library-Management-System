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

namespace BookLibrary.Users
{
    public partial class frmShowUserInfo : Form
    {

        public frmShowUserInfo(int UserID)
        {
            InitializeComponent();
            (new DropShadow()).ApplyShadows(this);

            _UserID = UserID;

            this.FormBorderStyle = FormBorderStyle.None;
        }

        int _UserID;

        private void frmShowUserInfo_Load(object sender, EventArgs e)
        {
            ctrlUserCard1.ShowUserInfo(_UserID);
            lblUsername.Text = ctrlUserCard1.User.UserName;

            if (ctrlUserCard1.User.IsAdmin)
                lblIsAdmin.Text = "Yes";
            else
                lblIsAdmin.Text = "No";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
