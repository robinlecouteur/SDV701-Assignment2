namespace PCShopWinFormAdmin
{
    partial class frmNewItem
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
            this.txtImportCountry = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtImportCountry
            // 
            this.txtImportCountry.Location = new System.Drawing.Point(122, 264);
            this.txtImportCountry.MaxLength = 20;
            this.txtImportCountry.Name = "txtImportCountry";
            this.txtImportCountry.Size = new System.Drawing.Size(212, 20);
            this.txtImportCountry.TabIndex = 76;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 267);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 77;
            this.label6.Text = "Import Country:";
            // 
            // frmNewItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(411, 364);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtImportCountry);
            this.Name = "frmNewItem";
            this.Controls.SetChildIndex(this.txtImportCountry, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtImportCountry;
        private System.Windows.Forms.Label label6;
    }
}
