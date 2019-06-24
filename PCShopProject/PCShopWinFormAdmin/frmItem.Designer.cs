namespace PCShopWinFormAdmin
{
    partial class frmItem
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
            this.label12 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtOS = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.nudQtyInStock = new System.Windows.Forms.NumericUpDown();
            this.txtNewOrUsed = new System.Windows.Forms.TextBox();
            this.nudPricePerItem = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudQtyInStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPricePerItem)).BeginInit();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(41, 231);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 13);
            this.label12.TabIndex = 65;
            this.label12.Text = "New or Used:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(122, 83);
            this.txtDescription.MaxLength = 150;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(277, 48);
            this.txtDescription.TabIndex = 63;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 323);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 32);
            this.btnCancel.TabIndex = 56;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(122, 57);
            this.txtModel.MaxLength = 20;
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(212, 20);
            this.txtModel.TabIndex = 54;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 48;
            this.label5.Text = "Item Model:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(119, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 18);
            this.label4.TabIndex = 47;
            this.label4.Text = "Item Details";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 168);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 50;
            this.label7.Text = "Price per Item:";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(122, 31);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(212, 20);
            this.txtID.TabIndex = 68;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 67;
            this.label1.Text = "Item ID:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(309, 323);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(81, 32);
            this.btnOK.TabIndex = 69;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtOS
            // 
            this.txtOS.Location = new System.Drawing.Point(122, 137);
            this.txtOS.MaxLength = 20;
            this.txtOS.Name = "txtOS";
            this.txtOS.Size = new System.Drawing.Size(212, 20);
            this.txtOS.TabIndex = 71;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 70;
            this.label2.Text = "Operating System:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 72;
            this.label3.Text = "Qty in Stock:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 73;
            this.label9.Text = "Item Description:";
            // 
            // nudQtyInStock
            // 
            this.nudQtyInStock.Location = new System.Drawing.Point(122, 192);
            this.nudQtyInStock.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudQtyInStock.Name = "nudQtyInStock";
            this.nudQtyInStock.Size = new System.Drawing.Size(77, 20);
            this.nudQtyInStock.TabIndex = 74;
            // 
            // txtNewOrUsed
            // 
            this.txtNewOrUsed.Location = new System.Drawing.Point(122, 228);
            this.txtNewOrUsed.Name = "txtNewOrUsed";
            this.txtNewOrUsed.Size = new System.Drawing.Size(77, 20);
            this.txtNewOrUsed.TabIndex = 75;
            // 
            // nudPricePerItem
            // 
            this.nudPricePerItem.DecimalPlaces = 2;
            this.nudPricePerItem.Location = new System.Drawing.Point(122, 166);
            this.nudPricePerItem.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudPricePerItem.Name = "nudPricePerItem";
            this.nudPricePerItem.Size = new System.Drawing.Size(77, 20);
            this.nudPricePerItem.TabIndex = 76;
            // 
            // frmItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 367);
            this.Controls.Add(this.nudPricePerItem);
            this.Controls.Add(this.txtNewOrUsed);
            this.Controls.Add(this.nudQtyInStock);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Name = "frmItem";
            this.Text = "frmItem";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmItem_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nudQtyInStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPricePerItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtOS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nudQtyInStock;
        private System.Windows.Forms.TextBox txtNewOrUsed;
        private System.Windows.Forms.NumericUpDown nudPricePerItem;
    }
}