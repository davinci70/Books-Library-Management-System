using BookLibrary.Global_Classes;
using BookLibrary.Login;
using BookLibrary.Properties;
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

namespace BookLibrary.Users
{
    public partial class frmAddUpdateUser : Form
    {

        public frmAddUpdateUser()
        {
            InitializeComponent();
            (new DropShadow()).ApplyShadows(this);

            _Mode = enMode.AddNew;

            this.FormBorderStyle = FormBorderStyle.None;         
        }
        
        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();
            (new DropShadow()).ApplyShadows(this);

            _UserID = UserID;
            _Mode = enMode.Update;

            this.FormBorderStyle = FormBorderStyle.None;           
        }

        int _UserID;
        clsUsers _User;

        enum enMode { AddNew =  0, Update = 1 }
        enMode _Mode = enMode.AddNew;

        void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew)
            {
                _User = new clsUsers();
                this.Text = "Add New User";
                lblTitle.Text = "Add New User";
            }
            else
            {
                this.Text = "Update User";
                lblTitle.Text = "Update User";
            }

            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtPhoneNumber.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtUsername.Text = "";
            rbMale.Checked = true;
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-10);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;
            pbUserImage.Image = Resources.man_avatar;
            chkIsAdmin.Checked = false;
            llRemove.Visible = (pbUserImage.ImageLocation != null);
        }

        void _LoadData()
        {
            _User = clsUsers.Find(_UserID);

            if (_User == null)
            {
                MessageBox.Show("No User with ID = " + _UserID, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            txtFirstName.Text = _User.FirstName;
            txtLastName.Text = _User.LastName;
            txtEmail.Text = _User.Email;
            txtPhoneNumber.Text = _User.PhoneNumber;
            txtPassword.Text = _User.Password;
            txtConfirmPassword.Text = _User.Password;
            txtUsername.Text = _User.UserName;           
            chkIsAdmin.Checked = (_User.IsAdmin);
            
            if (_User.Gender == 1)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            if (_User.ImagePath == null)
            {
                if (_User.Gender == 1)
                { 
                    rbMale.Checked = true;
                    rbFemale.Checked = false;
                    pbUserImage.Image = Resources.man_avatar;
                }
                else
                {
                    rbFemale.Checked = true;
                    rbMale.Checked = false;
                    pbUserImage.Image = Resources.woman_avatar;
                }
            }
            else
                pbUserImage.ImageLocation = _User.ImagePath; 

            dtpDateOfBirth.Value = _User.DateOfBirth;
            llRemove.Visible = (_User.ImagePath != null);
        }

        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _User.FirstName = txtFirstName.Text.Trim();
            _User.LastName = txtLastName.Text.Trim();
            _User.DateOfBirth = dtpDateOfBirth.Value;
            _User.Email = txtEmail.Text.Trim();
            _User.Password = txtPassword.Text.Trim();
            _User.PhoneNumber = txtPhoneNumber.Text.Trim();
            _User.UserName = txtUsername.Text.Trim();

            if (pbUserImage.ImageLocation != null)
                _User.ImagePath = pbUserImage.ImageLocation.ToString();
            else
                _User.ImagePath = null;

            _User.IsAdmin = chkIsAdmin.Checked;

            if (rbFemale.Checked)
                _User.Gender = 2;
            else
                _User.Gender = 1;

            if (_User.Save())
            {
                MessageBox.Show("User has been saved successfuly!", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to save user!", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbMale_Click(object sender, EventArgs e)
        {
            if (pbUserImage.ImageLocation == null)
                pbUserImage.Image = Resources.man_avatar;
        }

        private void rbFemale_Click(object sender, EventArgs e)
        {
            if (pbUserImage.ImageLocation == null)
                pbUserImage.Image = Resources.woman_avatar;
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!clsValidation.ValidateEmail(txtEmail.Text.Trim()))
            {
                //e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Invalid Email Address Format!");
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            };
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                //e.Cancel = true;
                errorProvider1.SetError(txtFirstName, "this field is required!");
            }
            else
            {
                errorProvider1.SetError(txtFirstName, null);
            };
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                //e.Cancel = true;
                errorProvider1.SetError(txtLastName, "this field is required!");
            }
            else
            {
                errorProvider1.SetError(txtLastName, null);
            };
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtPhoneNumber_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                //e.Cancel = true;
                errorProvider1.SetError(txtPhoneNumber, "this field is required!");
            }
            else
            {
                errorProvider1.SetError(txtPhoneNumber, null);
            };
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                //e.Cancel = true;
                errorProvider1.SetError(txtUsername, "this field is required!");
            }
            else
            {
                errorProvider1.SetError(txtUsername, null);
            };
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                //e.Cancel = true;
                errorProvider1.SetError(txtPassword, "this field is required!");
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            };
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                //e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "this field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            };

            if (txtConfirmPassword.Text.Trim() != txtPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Password Confirmation does not match Password!");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            };
        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                pbUserImage.Load(selectedFilePath);
                llRemove.Visible = true;
                // ...
            }
        }

        private void llRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbUserImage.ImageLocation = null;

            if (rbFemale.Checked)
            {
                pbUserImage.Image = Resources.woman_avatar;
            }
            else
            {
                pbUserImage.Image = Resources.man_avatar;
            }

            llRemove.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbShowPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar != '\0')
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '•';
            }
        }

        private void pbShowConfirmPassword_Click(object sender, EventArgs e)
        {
            if (txtConfirmPassword.PasswordChar != '\0')
            {
                txtConfirmPassword.PasswordChar = '\0';
            }
            else
            {
                txtConfirmPassword.PasswordChar = '•';
            }
        }
    }
}
