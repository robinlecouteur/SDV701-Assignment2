namespace PCShopWinFormAdmin
{
    partial class frmUsedItem
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
            this.txtCondition = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpDateOfManufacture = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // txtCondition
            // 
            this.txtCondition.Location = new System.Drawing.Point(122, 293);
            this.txtCondition.MaxLength = 40;
            this.txtCondition.Name = "txtCondition";
            this.txtCondition.Size = new System.Drawing.Size(268, 20);
            this.txtCondition.TabIndex = 83;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(59, 296);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 82;
            this.label10.Text = "Condition:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 273);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(108, 13);
            this.label11.TabIndex = 81;
            this.label11.Text = "Date of Manufacture:";
            // 
            // dtpDateOfManufacture
            // 
            this.dtpDateOfManufacture.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateOfManufacture.Location = new System.Drawing.Point(122, 267);
            this.dtpDateOfManufacture.MaxDate = new System.DateTime(2019, 6, 21, 0, 0, 0, 0);
            this.dtpDateOfManufacture.MinDate = new System.DateTime(1960, 1, 1, 0, 0, 0, 0);
            this.dtpDateOfManufacture.Name = "dtpDateOfManufacture";
            this.dtpDateOfManufacture.Size = new System.Drawing.Size(96, 20);
            this.dtpDateOfManufacture.TabIndex = 80;
            this.dtpDateOfManufacture.Value = new System.DateTime(2019, 6, 21, 0, 0, 0, 0);
            // 
            // frmUsedItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(411, 363);
            this.Controls.Add(this.txtCondition);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dtpDateOfManufacture);
            this.Name = "frmUsedItem";
            this.Controls.SetChildIndex(this.dtpDateOfManufacture, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.txtCondition, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCondition;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpDateOfManufacture;
    }
}
