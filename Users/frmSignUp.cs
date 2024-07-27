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
    public partial class frmSignUp : Form
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

        public frmSignUp()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
        }

        int _UserID;
        clsUsers _User;

        private void frmAddNewUser_Load(object sender, EventArgs e)
        {
            btnBack.Visible = false;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (tcLoginInfo.SelectedTab == tcLoginInfo.TabPages["tabBasicInfo"])
            {
                tcLoginInfo.SelectedTab = tcLoginInfo.TabPages["tabLoginInfo"];
                btnBack.Visible = true;
                btnNext.Visible = true;
                btnFinish.Visible = false;
                return;
            }
            
            if (tcLoginInfo.SelectedTab == tcLoginInfo.TabPages["tabLoginInfo"])
            {
                tcLoginInfo.SelectedTab = tcLoginInfo.TabPages["tabSetImage"];
                llRemove.Visible = (pbUserImage.ImageLocation != null);
                btnBack.Visible = true;
                btnNext.Visible = false;
                btnFinish.Visible = true;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (tcLoginInfo.SelectedTab == tcLoginInfo.TabPages["tabSetImage"])
            {
                tcLoginInfo.SelectedTab = tcLoginInfo.TabPages["tabLoginInfo"];
                btnBack.Visible = true;
                btnNext.Visible = true;
                btnFinish.Visible = false;
                return;
            }

            if (tcLoginInfo.SelectedTab == tcLoginInfo.TabPages["tabLoginInfo"])
            { 
                tcLoginInfo.SelectedTab = tcLoginInfo.TabPages["tabBasicInfo"];
                btnBack.Visible = false;
                btnNext.Visible = true;
                btnFinish.Visible = false;
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _User = new clsUsers();

            _User.FirstName = txtFirstName.Text.Trim();
            _User.LastName = txtLastName.Text.Trim();
            _User.DateOfBirth = dtpPublicationDate.Value;
            _User.Email = txtEmail.Text.Trim();
            _User.Password = txtPassword.Text.Trim();
            _User.PhoneNumber = txtPhoneNumber.Text.Trim();
            _User.Email = txtEmail.Text.Trim();
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
                MessageBox.Show("User has been added successfuly!", "Added",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
                frmLogin frm = new frmLogin();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Failed to add user!", "Failed",
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
                e.Cancel = true;
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
                e.Cancel = true;
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
                e.Cancel = true;
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
                e.Cancel = true;
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
                e.Cancel = true;
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
                e.Cancel = true;
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
                e.Cancel = true;
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

        private void pbExit_Click(object sender, EventArgs e)
        {
            this.Close();
            frmLogin frm = new frmLogin();
            frm.Show();
        }
    }
}
