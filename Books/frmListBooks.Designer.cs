namespace BookLibrary.Books
{
    partial class frmListBooks
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
            this.flpnlListBooks = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flpnlListBooks
            // 
            this.flpnlListBooks.AutoScroll = true;
            this.flpnlListBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpnlListBooks.Location = new System.Drawing.Point(0, 0);
            this.flpnlListBooks.Name = "flpnlListBooks";
            this.flpnlListBooks.Size = new System.Drawing.Size(1129, 603);
            this.flpnlListBooks.TabIndex = 0;
            // 
            // frmListBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1129, 603);
            this.Controls.Add(this.flpnlListBooks);
            this.Name = "frmListBooks";
            this.Text = "frmListBooks";
            this.Load += new System.EventHandler(this.frmListBooks_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpnlListBooks;
    }
}