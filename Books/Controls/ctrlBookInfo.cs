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

namespace BookLibrary.Books.Controls
{
    public partial class ctrlBookInfo : UserControl
    {
        public ctrlBookInfo()
        {
            InitializeComponent();
        }

        clsBooks _Book;

        private void ctrlBookInfo_Load(object sender, EventArgs e)
        {

        }

        public void ShowBookDetails(int BookID)
        {
            _Book = clsBooks.Find(BookID);

            if ( _Book != null )
            {
                _ShowDetails();
            }
            else
            {
                _ResetDefaultDetails();
            }
        }

        void _ShowDetails()
        {
            lblBookTitle.Text = _Book.Title;
            lblAuthor.Text = _Book.Author;
            lblGenre.Text = _Book.Genre;
            lblISBN.Text = _Book.ISBN;
            lblPublicationDate.Text = _Book.PublicationDate.ToString("d");
            lblQuantity.Text = _Book.Quantity.ToString();
            lblAdditioinalDetails.Text = _Book.AdditionalDetails;

            pbBookImage.ImageLocation = _Book.ImagePath;
        }

        void _ResetDefaultDetails()
        {
            lblBookTitle.Text = "[????]";
            lblAuthor.Text = "[????]";
            lblGenre.Text = "[????]";
            lblISBN.Text = "[????]";
            lblPublicationDate.Text = "dd/mm/yyyy";
            lblQuantity.Text = "0";
            lblAdditioinalDetails.Text = "[????]";

            pbBookImage.Image = Resources.book__3_;
        }
    }
}
