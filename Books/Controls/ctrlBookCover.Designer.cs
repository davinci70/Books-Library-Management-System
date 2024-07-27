namespace BookLibrary.Books.Controls
{
    partial class ctrlBookCover
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlBookCover));
            this.cmsBooks = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmShowBookDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmBorrow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmEditBook = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDeleteBook = new System.Windows.Forms.ToolStripMenuItem();
            this.bunifuPanel1 = new Bunifu.UI.WinForms.BunifuPanel();
            this.lblAvailability = new System.Windows.Forms.Label();
            this.rtBookRate = new Bunifu.UI.WinForms.BunifuRating();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pbBookCover = new System.Windows.Forms.PictureBox();
            this.cmsBooks.SuspendLayout();
            this.bunifuPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBookCover)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsBooks
            // 
            this.cmsBooks.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsBooks.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmShowBookDetails,
            this.toolStripSeparator1,
            this.tsmBorrow,
            this.toolStripSeparator2,
            this.tsmEditBook,
            this.tsmDeleteBook});
            this.cmsBooks.Name = "cmsBooks";
            this.cmsBooks.Size = new System.Drawing.Size(210, 120);
            // 
            // tsmShowBookDetails
            // 
            this.tsmShowBookDetails.Image = global::BookLibrary.Properties.Resources.book__4_;
            this.tsmShowBookDetails.Name = "tsmShowBookDetails";
            this.tsmShowBookDetails.Size = new System.Drawing.Size(209, 26);
            this.tsmShowBookDetails.Text = "Show Book Details";
            this.tsmShowBookDetails.Click += new System.EventHandler(this.tsmShowBookDetails_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(206, 6);
            // 
            // tsmBorrow
            // 
            this.tsmBorrow.Image = global::BookLibrary.Properties.Resources.borrow;
            this.tsmBorrow.Name = "tsmBorrow";
            this.tsmBorrow.Size = new System.Drawing.Size(209, 26);
            this.tsmBorrow.Text = "Borrow";
            this.tsmBorrow.Click += new System.EventHandler(this.tsmBorrow_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(206, 6);
            // 
            // tsmEditBook
            // 
            this.tsmEditBook.Image = global::BookLibrary.Properties.Resources.book_with_a_pencil_sign;
            this.tsmEditBook.Name = "tsmEditBook";
            this.tsmEditBook.Size = new System.Drawing.Size(209, 26);
            this.tsmEditBook.Text = "Edit Book";
            this.tsmEditBook.Click += new System.EventHandler(this.tsmEditBook_Click);
            // 
            // tsmDeleteBook
            // 
            this.tsmDeleteBook.Image = global::BookLibrary.Properties.Resources.delete_book;
            this.tsmDeleteBook.Name = "tsmDeleteBook";
            this.tsmDeleteBook.Size = new System.Drawing.Size(209, 26);
            this.tsmDeleteBook.Text = "Delete Book";
            this.tsmDeleteBook.Click += new System.EventHandler(this.tsmDeleteBook_Click);
            // 
            // bunifuPanel1
            // 
            this.bunifuPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuPanel1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(229)))), ((int)(((byte)(205)))));
            this.bunifuPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel1.BackgroundImage")));
            this.bunifuPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel1.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuPanel1.BorderRadius = 20;
            this.bunifuPanel1.BorderThickness = 0;
            this.bunifuPanel1.Controls.Add(this.lblAvailability);
            this.bunifuPanel1.Controls.Add(this.rtBookRate);
            this.bunifuPanel1.Controls.Add(this.lblAuthor);
            this.bunifuPanel1.Controls.Add(this.lblTitle);
            this.bunifuPanel1.Controls.Add(this.pbBookCover);
            this.bunifuPanel1.Location = new System.Drawing.Point(3, 3);
            this.bunifuPanel1.Name = "bunifuPanel1";
            this.bunifuPanel1.ShowBorders = true;
            this.bunifuPanel1.Size = new System.Drawing.Size(176, 256);
            this.bunifuPanel1.TabIndex = 0;
            // 
            // lblAvailability
            // 
            this.lblAvailability.AutoSize = true;
            this.lblAvailability.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(229)))), ((int)(((byte)(205)))));
            this.lblAvailability.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblAvailability.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailability.ForeColor = System.Drawing.Color.Red;
            this.lblAvailability.Location = new System.Drawing.Point(73, 0);
            this.lblAvailability.Name = "lblAvailability";
            this.lblAvailability.Size = new System.Drawing.Size(103, 19);
            this.lblAvailability.TabIndex = 4;
            this.lblAvailability.Text = "Not Available";
            this.lblAvailability.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // rtBookRate
            // 
            this.rtBookRate.BackColor = System.Drawing.Color.Transparent;
            this.rtBookRate.DisabledEmptyFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.rtBookRate.DisabledRatedFillColor = System.Drawing.Color.DarkGray;
            this.rtBookRate.EmptyBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.rtBookRate.EmptyFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.rtBookRate.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(217)))), ((int)(((byte)(20)))));
            this.rtBookRate.HoverFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(217)))), ((int)(((byte)(20)))));
            this.rtBookRate.InnerRadius = 2F;
            this.rtBookRate.Location = new System.Drawing.Point(52, 231);
            this.rtBookRate.Name = "rtBookRate";
            this.rtBookRate.OuterRadius = 10F;
            this.rtBookRate.RatedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(217)))), ((int)(((byte)(20)))));
            this.rtBookRate.RatedFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(217)))), ((int)(((byte)(20)))));
            this.rtBookRate.ReadOnly = true;
            this.rtBookRate.RightClickToClear = true;
            this.rtBookRate.Size = new System.Drawing.Size(121, 22);
            this.rtBookRate.TabIndex = 3;
            this.rtBookRate.Text = "bunifuRating1";
            this.rtBookRate.Value = 0;
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.BackColor = System.Drawing.Color.Transparent;
            this.lblAuthor.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuthor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(66)))), ((int)(((byte)(14)))));
            this.lblAuthor.Location = new System.Drawing.Point(4, 211);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(45, 16);
            this.lblAuthor.TabIndex = 2;
            this.lblAuthor.Text = "Author";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(66)))), ((int)(((byte)(14)))));
            this.lblTitle.Location = new System.Drawing.Point(3, 192);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(40, 19);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Title";
            // 
            // pbBookCover
            // 
            this.pbBookCover.Location = new System.Drawing.Point(0, 0);
            this.pbBookCover.Name = "pbBookCover";
            this.pbBookCover.Size = new System.Drawing.Size(176, 189);
            this.pbBookCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBookCover.TabIndex = 0;
            this.pbBookCover.TabStop = false;
            // 
            // ctrlBookCover
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ContextMenuStrip = this.cmsBooks;
            this.Controls.Add(this.bunifuPanel1);
            this.Name = "ctrlBookCover";
            this.Size = new System.Drawing.Size(182, 262);
            this.cmsBooks.ResumeLayout(false);
            this.bunifuPanel1.ResumeLayout(false);
            this.bunifuPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBookCover)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel1;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pbBookCover;
        private Bunifu.UI.WinForms.BunifuRating rtBookRate;
        private System.Windows.Forms.ContextMenuStrip cmsBooks;
        private System.Windows.Forms.ToolStripMenuItem tsmShowBookDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmBorrow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmEditBook;
        private System.Windows.Forms.ToolStripMenuItem tsmDeleteBook;
        private System.Windows.Forms.Label lblAvailability;
    }
}
