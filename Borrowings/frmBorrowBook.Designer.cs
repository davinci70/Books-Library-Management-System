namespace BookLibrary.Borrowings
{
    partial class frmBorrowBook
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBorrowBook));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.lblTitle = new System.Windows.Forms.Label();
            this.bunifuGroupBox1 = new Bunifu.UI.WinForms.BunifuGroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBorrowingDate = new System.Windows.Forms.Label();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.btnBorrow = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.ctrlBookInfo1 = new BookLibrary.Books.Controls.ctrlBookInfo();
            this.bunifuGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Unispace", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(59)))), ((int)(((byte)(8)))));
            this.lblTitle.Location = new System.Drawing.Point(335, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(199, 58);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Borrow";
            // 
            // bunifuGroupBox1
            // 
            this.bunifuGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(66)))), ((int)(((byte)(14)))));
            this.bunifuGroupBox1.BorderRadius = 1;
            this.bunifuGroupBox1.BorderThickness = 1;
            this.bunifuGroupBox1.Controls.Add(this.ctrlBookInfo1);
            this.bunifuGroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bunifuGroupBox1.LabelAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bunifuGroupBox1.LabelIndent = 10;
            this.bunifuGroupBox1.LineStyle = Bunifu.UI.WinForms.BunifuGroupBox.LineStyles.Solid;
            this.bunifuGroupBox1.Location = new System.Drawing.Point(39, 103);
            this.bunifuGroupBox1.Name = "bunifuGroupBox1";
            this.bunifuGroupBox1.Size = new System.Drawing.Size(805, 455);
            this.bunifuGroupBox1.TabIndex = 3;
            this.bunifuGroupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(66)))), ((int)(((byte)(14)))));
            this.label1.Location = new System.Drawing.Point(35, 573);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Borrowing Date:";
            // 
            // lblBorrowingDate
            // 
            this.lblBorrowingDate.AutoSize = true;
            this.lblBorrowingDate.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBorrowingDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(66)))), ((int)(((byte)(14)))));
            this.lblBorrowingDate.Location = new System.Drawing.Point(188, 573);
            this.lblBorrowingDate.Name = "lblBorrowingDate";
            this.lblBorrowingDate.Size = new System.Drawing.Size(114, 23);
            this.lblBorrowingDate.TabIndex = 5;
            this.lblBorrowingDate.Text = "dd/mm/yyyy";
            // 
            // lblDueDate
            // 
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDueDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(66)))), ((int)(((byte)(14)))));
            this.lblDueDate.Location = new System.Drawing.Point(188, 605);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(114, 23);
            this.lblDueDate.TabIndex = 7;
            this.lblDueDate.Text = "dd/mm/yyyy";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(66)))), ((int)(((byte)(14)))));
            this.label3.Location = new System.Drawing.Point(35, 605);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Due Date:";
            // 
            // btnClose
            // 
            this.btnClose.AllowAnimations = true;
            this.btnClose.AllowMouseEffects = true;
            this.btnClose.AllowToggling = false;
            this.btnClose.AnimationSpeed = 200;
            this.btnClose.AutoGenerateColors = false;
            this.btnClose.AutoRoundBorders = false;
            this.btnClose.AutoSizeLeftIcon = true;
            this.btnClose.AutoSizeRightIcon = true;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackColor1 = System.Drawing.Color.White;
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnClose.ButtonText = "   Cancel";
            this.btnClose.ButtonTextMarginLeft = 0;
            this.btnClose.ColorContrastOnClick = 45;
            this.btnClose.ColorContrastOnHover = 45;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnClose.CustomizableEdges = borderEdges1;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClose.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnClose.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnClose.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnClose.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(66)))), ((int)(((byte)(14)))));
            this.btnClose.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnClose.IconLeftPadding = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.btnClose.IconMarginLeft = 11;
            this.btnClose.IconPadding = 10;
            this.btnClose.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnClose.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnClose.IconSize = 25;
            this.btnClose.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(66)))), ((int)(((byte)(14)))));
            this.btnClose.IdleBorderRadius = 30;
            this.btnClose.IdleBorderThickness = 2;
            this.btnClose.IdleFillColor = System.Drawing.Color.White;
            this.btnClose.IdleIconLeftImage = global::BookLibrary.Properties.Resources.cross;
            this.btnClose.IdleIconRightImage = null;
            this.btnClose.IndicateFocus = false;
            this.btnClose.Location = new System.Drawing.Point(584, 637);
            this.btnClose.Name = "btnClose";
            this.btnClose.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnClose.OnDisabledState.BorderRadius = 30;
            this.btnClose.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnClose.OnDisabledState.BorderThickness = 2;
            this.btnClose.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnClose.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnClose.OnDisabledState.IconLeftImage = null;
            this.btnClose.OnDisabledState.IconRightImage = null;
            this.btnClose.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(229)))), ((int)(((byte)(205)))));
            this.btnClose.onHoverState.BorderRadius = 30;
            this.btnClose.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnClose.onHoverState.BorderThickness = 2;
            this.btnClose.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(66)))), ((int)(((byte)(14)))));
            this.btnClose.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnClose.onHoverState.IconLeftImage = global::BookLibrary.Properties.Resources.cross__1_;
            this.btnClose.onHoverState.IconRightImage = null;
            this.btnClose.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(66)))), ((int)(((byte)(14)))));
            this.btnClose.OnIdleState.BorderRadius = 30;
            this.btnClose.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnClose.OnIdleState.BorderThickness = 2;
            this.btnClose.OnIdleState.FillColor = System.Drawing.Color.White;
            this.btnClose.OnIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(66)))), ((int)(((byte)(14)))));
            this.btnClose.OnIdleState.IconLeftImage = global::BookLibrary.Properties.Resources.cross;
            this.btnClose.OnIdleState.IconRightImage = null;
            this.btnClose.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(229)))), ((int)(((byte)(205)))));
            this.btnClose.OnPressedState.BorderRadius = 30;
            this.btnClose.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnClose.OnPressedState.BorderThickness = 2;
            this.btnClose.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(66)))), ((int)(((byte)(14)))));
            this.btnClose.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnClose.OnPressedState.IconLeftImage = global::BookLibrary.Properties.Resources.cross__1_;
            this.btnClose.OnPressedState.IconRightImage = null;
            this.btnClose.Size = new System.Drawing.Size(142, 39);
            this.btnClose.TabIndex = 17;
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClose.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnClose.TextMarginLeft = 0;
            this.btnClose.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnClose.UseDefaultRadiusAndThickness = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnBorrow
            // 
            this.btnBorrow.AllowAnimations = true;
            this.btnBorrow.AllowMouseEffects = true;
            this.btnBorrow.AllowToggling = false;
            this.btnBorrow.AnimationSpeed = 200;
            this.btnBorrow.AutoGenerateColors = false;
            this.btnBorrow.AutoRoundBorders = false;
            this.btnBorrow.AutoSizeLeftIcon = true;
            this.btnBorrow.AutoSizeRightIcon = true;
            this.btnBorrow.BackColor = System.Drawing.Color.Transparent;
            this.btnBorrow.BackColor1 = System.Drawing.Color.White;
            this.btnBorrow.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBorrow.BackgroundImage")));
            this.btnBorrow.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnBorrow.ButtonText = "   Borrow";
            this.btnBorrow.ButtonTextMarginLeft = 0;
            this.btnBorrow.ColorContrastOnClick = 45;
            this.btnBorrow.ColorContrastOnHover = 45;
            this.btnBorrow.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.btnBorrow.CustomizableEdges = borderEdges2;
            this.btnBorrow.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnBorrow.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnBorrow.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnBorrow.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnBorrow.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnBorrow.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(66)))), ((int)(((byte)(14)))));
            this.btnBorrow.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBorrow.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnBorrow.IconLeftPadding = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.btnBorrow.IconMarginLeft = 11;
            this.btnBorrow.IconPadding = 10;
            this.btnBorrow.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBorrow.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnBorrow.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnBorrow.IconSize = 25;
            this.btnBorrow.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(66)))), ((int)(((byte)(14)))));
            this.btnBorrow.IdleBorderRadius = 30;
            this.btnBorrow.IdleBorderThickness = 2;
            this.btnBorrow.IdleFillColor = System.Drawing.Color.White;
            this.btnBorrow.IdleIconLeftImage = global::BookLibrary.Properties.Resources.borrow_1;
            this.btnBorrow.IdleIconRightImage = null;
            this.btnBorrow.IndicateFocus = false;
            this.btnBorrow.Location = new System.Drawing.Point(732, 637);
            this.btnBorrow.Name = "btnBorrow";
            this.btnBorrow.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnBorrow.OnDisabledState.BorderRadius = 30;
            this.btnBorrow.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnBorrow.OnDisabledState.BorderThickness = 2;
            this.btnBorrow.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnBorrow.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnBorrow.OnDisabledState.IconLeftImage = null;
            this.btnBorrow.OnDisabledState.IconRightImage = null;
            this.btnBorrow.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(229)))), ((int)(((byte)(205)))));
            this.btnBorrow.onHoverState.BorderRadius = 30;
            this.btnBorrow.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnBorrow.onHoverState.BorderThickness = 2;
            this.btnBorrow.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(66)))), ((int)(((byte)(14)))));
            this.btnBorrow.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnBorrow.onHoverState.IconLeftImage = global::BookLibrary.Properties.Resources.borrow_2;
            this.btnBorrow.onHoverState.IconRightImage = null;
            this.btnBorrow.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(66)))), ((int)(((byte)(14)))));
            this.btnBorrow.OnIdleState.BorderRadius = 30;
            this.btnBorrow.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnBorrow.OnIdleState.BorderThickness = 2;
            this.btnBorrow.OnIdleState.FillColor = System.Drawing.Color.White;
            this.btnBorrow.OnIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(66)))), ((int)(((byte)(14)))));
            this.btnBorrow.OnIdleState.IconLeftImage = global::BookLibrary.Properties.Resources.borrow_1;
            this.btnBorrow.OnIdleState.IconRightImage = null;
            this.btnBorrow.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(229)))), ((int)(((byte)(205)))));
            this.btnBorrow.OnPressedState.BorderRadius = 30;
            this.btnBorrow.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnBorrow.OnPressedState.BorderThickness = 2;
            this.btnBorrow.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(66)))), ((int)(((byte)(14)))));
            this.btnBorrow.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnBorrow.OnPressedState.IconLeftImage = global::BookLibrary.Properties.Resources.borrow_2;
            this.btnBorrow.OnPressedState.IconRightImage = null;
            this.btnBorrow.Size = new System.Drawing.Size(142, 39);
            this.btnBorrow.TabIndex = 16;
            this.btnBorrow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBorrow.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnBorrow.TextMarginLeft = 0;
            this.btnBorrow.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnBorrow.UseDefaultRadiusAndThickness = true;
            this.btnBorrow.Click += new System.EventHandler(this.btnBorrow_Click);
            // 
            // ctrlBookInfo1
            // 
            this.ctrlBookInfo1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(229)))), ((int)(((byte)(205)))));
            this.ctrlBookInfo1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlBookInfo1.Location = new System.Drawing.Point(3, 2);
            this.ctrlBookInfo1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ctrlBookInfo1.Name = "ctrlBookInfo1";
            this.ctrlBookInfo1.Size = new System.Drawing.Size(799, 450);
            this.ctrlBookInfo1.TabIndex = 0;
            // 
            // frmBorrowBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(886, 688);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnBorrow);
            this.Controls.Add(this.lblDueDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblBorrowingDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bunifuGroupBox1);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmBorrowBook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Borrow";
            this.Load += new System.EventHandler(this.frmBorrowBook_Load);
            this.bunifuGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private Bunifu.UI.WinForms.BunifuGroupBox bunifuGroupBox1;
        private Books.Controls.ctrlBookInfo ctrlBookInfo1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBorrowingDate;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.Label label3;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnClose;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnBorrow;
    }
}