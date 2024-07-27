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

namespace BookLibrary.Users.Controls
{
    public partial class ctrlUserCard : UserControl
    {
        public ctrlUserCard()
        {
            InitializeComponent();
        }

        clsUsers _User;

        public clsUsers User
        { get { return _User; } }

        public void ShowUserInfo(int UserID)
        {
            _User = clsUsers.Find(UserID);

            if (_User != null)
                _LoadInfo();
            else
                _ResetDefaultInfo();
        }

        void _LoadInfo()
        {
            lblUserID.Text = _User.UserID.ToString();
            lblDateOfBirth.Text = _User.DateOfBirth.ToString("d");
            lblEmail.Text = _User.Email;
            lblPhoneNumber.Text = _User.PhoneNumber;
            lblFullName.Text = _User.FirstName + " " + _User.LastName;

            if (_User.Gender == 1)
                lblGender.Text = "Male";
            else
                lblGender.Text = "Female";

            if (_User.ImagePath != null)
            {
                pbUserImage.ImageLocation = _User.ImagePath;
                return;
            }

            if (_User.Gender == 1)
                pbUserImage.Image = Resources.man_avatar;
            else
                pbUserImage.Image = Resources.woman_avatar;
        }
        void _ResetDefaultInfo()
        {
            lblUserID.Text = "N/A";
            lblDateOfBirth.Text = "[????]";
            lblEmail.Text = "[????]";
            lblPhoneNumber.Text = "[????]";
            lblFullName.Text = "[????]";
            lblGender.Text = "[????]";
            pbUserImage.Image = Resources.man_avatar;
        }
    }
}
