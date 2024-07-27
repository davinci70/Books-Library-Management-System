using BookLibrary.Global_Classes;
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
    public partial class frmShowBookInfo : Form
    {

        public frmShowBookInfo(int bookID)
        {
            InitializeComponent();
            (new DropShadow()).ApplyShadows(this);

            _BookID = bookID;

            this.FormBorderStyle = FormBorderStyle.None;
        }
        int _BookID;
        clsRates _Rate;
        private void frmShowBookInfo_Load(object sender, EventArgs e)
        {
            ctrlBookInfo1.ShowBookDetails(_BookID);

            _LoadRates();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rtUserRate_ValueChanged(object sender, Bunifu.UI.WinForms.BunifuRating.ValueChangedEventArgs e)
        {
            if (clsRates.IsRateExistByUserIDandBookID(clsGlobal.CurrentUser.UserID, _BookID))
            {
                _Rate = clsRates.FindByUserIDandBookID(clsGlobal.CurrentUser.UserID, _BookID);

                _Rate.UserRating = rtUserRate.Value;
                _Rate.Save();

                return;
            }

            _Rate = new clsRates();

            _Rate.BookID = _BookID;
            _Rate.UserID = clsGlobal.CurrentUser.UserID;
            _Rate.UserRating = rtUserRate.Value;

            _Rate.Save();
        }

        void _LoadRates()
        {
            if (clsRates.IsRateExistByUserIDandBookID(clsGlobal.CurrentUser.UserID, _BookID))
            {
                _Rate = clsRates.FindByUserIDandBookID(clsGlobal.CurrentUser.UserID, _BookID);

                if (_Rate != null) 
                    rtUserRate.Value = _Rate.UserRating;
            }

            rtBookRate.Value = clsRates.CalculateTheRateOfTheBook(_BookID);
        }
    }
}
