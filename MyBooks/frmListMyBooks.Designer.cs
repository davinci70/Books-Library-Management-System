namespace BookLibrary.MyBooks
{
    partial class frmListMyBooks
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
            this.flpnlListMyBooks = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flpnlListMyBooks
            // 
            this.flpnlListMyBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpnlListMyBooks.Location = new System.Drawing.Point(0, 0);
            this.flpnlListMyBooks.Name = "flpnlListMyBooks";
            this.flpnlListMyBooks.Size = new System.Drawing.Size(1129, 603);
            this.flpnlListMyBooks.TabIndex = 0;
            // 
            // frmListMyBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1129, 603);
            this.Controls.Add(this.flpnlListMyBooks);
            this.Name = "frmListMyBooks";
            this.Text = "frmListMyBooks";
            this.Load += new System.EventHandler(this.frmListMyBooks_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpnlListMyBooks;
    }
}