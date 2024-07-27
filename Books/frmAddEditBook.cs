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

namespace BookLibrary.Books
{
    public partial class frmAddEditBook : Form
    {

        public frmAddEditBook()
        {
            InitializeComponent();
            (new DropShadow()).ApplyShadows(this);

            _Mode = enMode.AddNew;

            this.FormBorderStyle = FormBorderStyle.None;
        }
        
        public frmAddEditBook(int BookID)
        {
            InitializeComponent();
            (new DropShadow()).ApplyShadows(this);

            _BookID = BookID;
            _Mode = enMode.Update;

            this.FormBorderStyle = FormBorderStyle.None;
        }

        enum enMode { AddNew = 0, Update = 1 }
        enMode _Mode = enMode.AddNew;

        int _BookID;
        public clsBooks _Book;
        public clsBookCopies _BookCopy;

        void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Book";
                this.Text = "Add New Book";
                _Book = new clsBooks();
            }

            if (_Mode == enMode.Update)
            {
                lblTitle.Text = "Update Book";
                this.Text = "Update Book";
            }

            txtAuthor.Text = "";
            txtTitle.Text = "";
            txtISBN.Text = "";
            txtQuantity.Text = "";
            dtpPublicationDate.Value = DateTime.Now;
            cbGenre.SelectedItem = "";
            txtAdditionalDetails.Text = "";
            pbBookImage.ImageLocation = null;
            pbBookImage.Image = Resources.book__3_;

            llRemove.Visible = (pbBookImage.ImageLocation != null);
        }

        void _LoadDate()
        {
            _Book = clsBooks.Find(_BookID);

            if (_Book == null)
            {
                MessageBox.Show("Book with id = " +  _BookID + " was not found!", 
                    "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            txtAuthor.Text = _Book.Author;
            txtTitle.Text = _Book.Title;
            txtISBN.Text = _Book.ISBN;
            dtpPublicationDate.Value = _Book.PublicationDate;
            cbGenre.SelectedItem = _Book.Genre;
            txtQuantity.Text = _Book.Quantity.ToString();
            txtAdditionalDetails.Text = _Book.AdditionalDetails;
            pbBookImage.ImageLocation = _Book.ImagePath;
            llRemove.Visible = (pbBookImage.ImageLocation != null);
        }

        private void frmAddEditBook_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
                _LoadDate();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Book.Author = txtAuthor.Text;
            _Book.Title = txtTitle.Text;
            _Book.ISBN = txtISBN.Text;
            _Book.Genre = cbGenre.SelectedItem.ToString();
            _Book.PublicationDate = dtpPublicationDate.Value;
            //_Book.Quantity = Convert.ToInt32(txtQuantity.Text);
            _Book.AdditionalDetails = txtAdditionalDetails.Text;
            _Book.ImagePath = pbBookImage.ImageLocation;

            if (_Book.Save())
            {
                _HandleQuantities();

                _Mode = enMode.Update;
                lblTitle.Text = "Update Book";

                MessageBox.Show("Book saved successfully!", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to save book!", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _HandleQuantities()
        {
            if (_Mode == enMode.Update)
            {
                if (_Book.Quantity < Convert.ToInt32(txtQuantity.Text))
                {
                    int newCopies = Convert.ToInt32(txtQuantity.Text) - _Book.Quantity;
                    bool Added = false;

                    for (int i = 0; i < newCopies; i++)
                    {
                        _BookCopy = new clsBookCopies();

                        _BookCopy.BookID = _Book.BookID;
                        _BookCopy.AvailabilityStatus = true;

                        Added = _BookCopy._AddNewCopy();

                        _BookCopy = null;
                    }

                    if (Added)
                    {
                        MessageBox.Show(newCopies + " copies has been added to the library",
                        "New Copies", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        _Book.Quantity += newCopies;
                        _Book.Save();
                    }
                }
                else if (_Book.Quantity > Convert.ToInt32(txtQuantity.Text))
                {
                    int UpdatedCopies = _Book.Quantity - Convert.ToInt32(txtQuantity.Text);

                    int DeletedCopies = clsBookCopies.CountCopiesThatWillBeDeleted(_BookID, UpdatedCopies);

                    if (UpdatedCopies > DeletedCopies)
                    {
                        if (MessageBox.Show($"Not all copies will be deleted, " +
                            "because some of them are borrowed.\n\n" +
                            "Copies that will not be deleted: " + (UpdatedCopies - DeletedCopies) +
                            "\nCopies that will be deleted: " + DeletedCopies, "Warning",
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            clsBookCopies.DeleteCopy(_Book.BookID, UpdatedCopies);

                            MessageBox.Show(DeletedCopies + " copies has been deleted from the library",
                                "Delete Copies", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        clsBookCopies.DeleteCopy(_Book.BookID, UpdatedCopies);

                        MessageBox.Show(UpdatedCopies + " copies has been deleted from the library",
                            "Delete Copies", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    

                    _Book.Quantity -= DeletedCopies;
                    _Book.Save();
                }
            }
            else
            {
                for (int i = 0; i < Convert.ToInt32(txtQuantity.Text); i++)
                {
                    _BookCopy = new clsBookCopies();

                    _BookCopy.BookID = _Book.BookID;
                    _BookCopy.AvailabilityStatus = true;

                    _BookCopy._AddNewCopy();

                    _BookCopy = null;
                }

                _Book.Quantity = Convert.ToInt32(txtQuantity.Text);
                _Book.Save();
            }
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
                pbBookImage.Load(selectedFilePath);
                llRemove.Visible = true;
                // ...
            }
        }

        private void llRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbBookImage.ImageLocation = null;
            pbBookImage.Image = Resources.book__3_;
            llRemove.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (txtQuantity.Text == "0")
                txtQuantity.Text = "1";
        }
    }
}
