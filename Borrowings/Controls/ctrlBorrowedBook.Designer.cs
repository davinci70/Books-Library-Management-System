namespace BookLibrary.Borrowings.Controls
{
    partial class ctrlBorrowedBook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlBorrowedBook));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.bunifuPanel1 = new Bunifu.UI.WinForms.BunifuPanel();
            this.lblLateDays = new System.Windows.Forms.Label();
            this.btnReturn = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblBorrowDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pbBookCover = new System.Windows.Forms.PictureBox();
            this.bunifuPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBookCover)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuPanel1
            // 
            this.bunifuPanel1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(241)))), ((int)(((byte)(226)))));
            this.bunifuPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel1.BackgroundImage")));
            this.bunifuPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel1.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuPanel1.BorderRadius = 20;
            this.bunifuPanel1.BorderThickness = 1;
            this.bunifuPanel1.Controls.Add(this.lblLateDays);
            this.bunifuPanel1.Controls.Add(this.btnReturn);
            this.bunifuPanel1.Controls.Add(this.label2);
            this.bunifuPanel1.Controls.Add(this.lblDueDate);
            this.bunifuPanel1.Controls.Add(this.label3);
            this.bunifuPanel1.Controls.Add(this.lblBorrowDate);
            this.bunifuPanel1.Controls.Add(this.label1);
            this.bunifuPanel1.Controls.Add(this.lblAuthor);
            this.bunifuPanel1.Controls.Add(this.lblTitle);
            this.bunifuPanel1.Controls.Add(this.pbBookCover);
            this.bunifuPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuPanel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(59)))), ((int)(((byte)(8)))));
            this.bunifuPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuPanel1.Name = "bunifuPanel1";
            this.bunifuPanel1.ShowBorders = true;
            this.bunifuPanel1.Size = new System.Drawing.Size(366, 256);
            this.bunifuPanel1.TabIndex = 0;
            // 
            // lblLateDays
            // 
            this.lblLateDays.AutoSize = true;
            this.lblLateDays.BackColor = System.Drawing.Color.Transparent;
            this.lblLateDays.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLateDays.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(66)))), ((int)(((byte)(14)))));
            this.lblLateDays.Location = new System.Drawing.Point(276, 178);
            this.lblLateDays.Name = "lblLateDays";
            this.lblLateDays.Size = new System.Drawing.Size(27, 19);
            this.lblLateDays.TabIndex = 18;
            this.lblLateDays.Text = "dd";
            // 
            // btnReturn
            // 
            this.btnReturn.AllowAnimations = true;
            this.btnReturn.AllowMouseEffects = true;
            this.btnReturn.AllowToggling = false;
            this.btnReturn.AnimationSpeed = 200;
            this.btnReturn.AutoGenerateColors = false;
            this.btnReturn.AutoRoundBorders = false;
            this.btnReturn.AutoSizeLeftIcon = true;
            this.btnReturn.AutoSizeRightIcon = true;
            this.btnReturn.BackColor = System.Drawing.Color.Transparent;
            this.btnReturn.BackColor1 = System.Drawing.Color.White;
            this.btnReturn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReturn.BackgroundImage")));
            this.btnReturn.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnReturn.ButtonText = "Return";
            this.btnReturn.ButtonTextMarginLeft = 0;
            this.btnReturn.ColorContrastOnClick = 45;
            this.btnReturn.ColorContrastOnHover = 45;
            this.btnReturn.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnReturn.CustomizableEdges = borderEdges1;
            this.btnReturn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnReturn.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnReturn.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnReturn.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnReturn.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnReturn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(66)))), ((int)(((byte)(14)))));
            this.btnReturn.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReturn.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnReturn.IconLeftPadding = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.btnReturn.IconMarginLeft = 11;
            this.btnReturn.IconPadding = 10;
            this.btnReturn.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReturn.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnReturn.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnReturn.IconSize = 25;
            this.btnReturn.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(66)))), ((int)(((byte)(14)))));
            this.btnReturn.IdleBorderRadius = 30;
            this.btnReturn.IdleBorderThickness = 2;
            this.btnReturn.IdleFillColor = System.Drawing.Color.White;
            this.btnReturn.IdleIconLeftImage = null;
            this.btnReturn.IdleIconRightImage = null;
            this.btnReturn.IndicateFocus = false;
            this.btnReturn.Location = new System.Drawing.Point(208, 211);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnReturn.OnDisabledState.BorderRadius = 30;
            this.btnReturn.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnReturn.OnDisabledState.BorderThickness = 2;
            this.btnReturn.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnReturn.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnReturn.OnDisabledState.IconLeftImage = null;
            this.btnReturn.OnDisabledState.IconRightImage = null;
            this.btnReturn.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(229)))), ((int)(((byte)(205)))));
            this.btnReturn.onHoverState.BorderRadius = 30;
            this.btnReturn.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnReturn.onHoverState.BorderThickness = 2;
            this.btnReturn.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(66)))), ((int)(((byte)(14)))));
            this.btnReturn.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnReturn.onHoverState.IconLeftImage = null;
            this.btnReturn.onHoverState.IconRightImage = null;
            this.btnReturn.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(66)))), ((int)(((byte)(14)))));
            this.btnReturn.OnIdleState.BorderRadius = 30;
            this.btnReturn.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnReturn.OnIdleState.BorderThickness = 2;
            this.btnReturn.OnIdleState.FillColor = System.Drawing.Color.White;
            this.btnReturn.OnIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(66)))), ((int)(((byte)(14)))));
            this.btnReturn.OnIdleState.IconLeftImage = null;
            this.btnReturn.OnIdleState.IconRightImage = null;
            this.btnReturn.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(229)))), ((int)(((byte)(205)))));
            this.btnReturn.OnPressedState.BorderRadius = 30;
            this.btnReturn.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnReturn.OnPressedState.BorderThickness = 2;
            this.btnReturn.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(66)))), ((int)(((byte)(14)))));
            this.btnReturn.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnReturn.OnPressedState.IconLeftImage = null;
            this.btnReturn.OnPressedState.IconRightImage = null;
            this.btnReturn.Size = new System.Drawing.Size(110, 35);
            this.btnReturn.TabIndex = 17;
            this.btnReturn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnReturn.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnReturn.TextMarginLeft = 0;
            this.btnReturn.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnReturn.UseDefaultRadiusAndThickness = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(59)))), ((int)(((byte)(8)))));
            this.label2.Location = new System.Drawing.Point(180, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 23);
            this.label2.TabIndex = 9;
            this.label2.Text = "Late Days:";
            // 
            // lblDueDate
            // 
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDueDate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDueDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(66)))), ((int)(((byte)(14)))));
            this.lblDueDate.Location = new System.Drawing.Point(222, 140);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(99, 19);
            this.lblDueDate.TabIndex = 8;
            this.lblDueDate.Text = "dd/mm/yyyy";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(59)))), ((int)(((byte)(8)))));
            this.label3.Location = new System.Drawing.Point(180, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Due Date:";
            // 
            // lblBorrowDate
            // 
            this.lblBorrowDate.AutoSize = true;
            this.lblBorrowDate.BackColor = System.Drawing.Color.Transparent;
            this.lblBorrowDate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBorrowDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(66)))), ((int)(((byte)(14)))));
            this.lblBorrowDate.Location = new System.Drawing.Point(222, 82);
            this.lblBorrowDate.Name = "lblBorrowDate";
            this.lblBorrowDate.Size = new System.Drawing.Size(99, 19);
            this.lblBorrowDate.TabIndex = 6;
            this.lblBorrowDate.Text = "dd/mm/yyyy";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(59)))), ((int)(((byte)(8)))));
            this.label1.Location = new System.Drawing.Point(180, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Borrow Date:";
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.BackColor = System.Drawing.Color.Transparent;
            this.lblAuthor.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuthor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(66)))), ((int)(((byte)(14)))));
            this.lblAuthor.Location = new System.Drawing.Point(181, 32);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(45, 16);
            this.lblAuthor.TabIndex = 4;
            this.lblAuthor.Text = "Author";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(59)))), ((int)(((byte)(8)))));
            this.lblTitle.Location = new System.Drawing.Point(180, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(40, 19);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Title";
            // 
            // pbBookCover
            // 
            this.pbBookCover.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbBookCover.Location = new System.Drawing.Point(0, 0);
            this.pbBookCover.Name = "pbBookCover";
            this.pbBookCover.Size = new System.Drawing.Size(173, 256);
            this.pbBookCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBookCover.TabIndex = 1;
            this.pbBookCover.TabStop = false;
            // 
            // ctrlBorrowedBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.bunifuPanel1);
            this.Name = "ctrlBorrowedBook";
            this.Size = new System.Drawing.Size(366, 256);
            this.bunifuPanel1.ResumeLayout(false);
            this.bunifuPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBookCover)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel1;
        private System.Windows.Forms.PictureBox pbBookCover;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblBorrowDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblTitle;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnReturn;
        private System.Windows.Forms.Label lblLateDays;
    }
}
