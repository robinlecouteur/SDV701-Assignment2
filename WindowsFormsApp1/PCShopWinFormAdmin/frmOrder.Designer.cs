namespace PCShopWinFormAdmin
{
    partial class frmOrder
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
            this.txtItemModel = new System.Windows.Forms.TextBox();
            this.txtTotalOrderPrice = new System.Windows.Forms.TextBox();
            this.txtPricePerItem = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.txtCustPh = new System.Windows.Forms.TextBox();
            this.txtQnty = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtItemDesc = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtItemNewOrUsed = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTimeOrdered = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtItemModel
            // 
            this.txtItemModel.BackColor = System.Drawing.SystemColors.Menu;
            this.txtItemModel.Location = new System.Drawing.Point(111, 141);
            this.txtItemModel.Name = "txtItemModel";
            this.txtItemModel.Size = new System.Drawing.Size(212, 20);
            this.txtItemModel.TabIndex = 29;
            // 
            // txtTotalOrderPrice
            // 
            this.txtTotalOrderPrice.BackColor = System.Drawing.SystemColors.Menu;
            this.txtTotalOrderPrice.Location = new System.Drawing.Point(113, 382);
            this.txtTotalOrderPrice.Name = "txtTotalOrderPrice";
            this.txtTotalOrderPrice.Size = new System.Drawing.Size(134, 20);
            this.txtTotalOrderPrice.TabIndex = 28;
            // 
            // txtPricePerItem
            // 
            this.txtPricePerItem.BackColor = System.Drawing.SystemColors.Menu;
            this.txtPricePerItem.Location = new System.Drawing.Point(113, 304);
            this.txtPricePerItem.Name = "txtPricePerItem";
            this.txtPricePerItem.Size = new System.Drawing.Size(94, 20);
            this.txtPricePerItem.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 385);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Total Order Price:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 307);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Price per Item:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 333);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Quantity Ordered:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Item Model:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(108, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 18);
            this.label4.TabIndex = 22;
            this.label4.Text = "Item Details";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Phone:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(108, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 18);
            this.label1.TabIndex = 19;
            this.label1.Text = "Customer Details";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(12, 418);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 32);
            this.btnClose.TabIndex = 33;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtCustName
            // 
            this.txtCustName.BackColor = System.Drawing.SystemColors.Menu;
            this.txtCustName.Location = new System.Drawing.Point(111, 38);
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.Size = new System.Drawing.Size(212, 20);
            this.txtCustName.TabIndex = 34;
            // 
            // txtCustPh
            // 
            this.txtCustPh.BackColor = System.Drawing.SystemColors.Menu;
            this.txtCustPh.Location = new System.Drawing.Point(111, 64);
            this.txtCustPh.Name = "txtCustPh";
            this.txtCustPh.Size = new System.Drawing.Size(212, 20);
            this.txtCustPh.TabIndex = 35;
            // 
            // txtQnty
            // 
            this.txtQnty.BackColor = System.Drawing.SystemColors.Menu;
            this.txtQnty.Location = new System.Drawing.Point(113, 330);
            this.txtQnty.Name = "txtQnty";
            this.txtQnty.Size = new System.Drawing.Size(134, 20);
            this.txtQnty.TabIndex = 36;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(110, 274);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 18);
            this.label9.TabIndex = 37;
            this.label9.Text = "Order Details";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(32, 359);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 13);
            this.label10.TabIndex = 38;
            this.label10.Text = "Time Ordered:";
            // 
            // txtItemDesc
            // 
            this.txtItemDesc.BackColor = System.Drawing.SystemColors.Menu;
            this.txtItemDesc.Location = new System.Drawing.Point(111, 167);
            this.txtItemDesc.Multiline = true;
            this.txtItemDesc.Name = "txtItemDesc";
            this.txtItemDesc.Size = new System.Drawing.Size(277, 48);
            this.txtItemDesc.TabIndex = 40;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 170);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 13);
            this.label11.TabIndex = 41;
            this.label11.Text = "Item Description:";
            // 
            // txtItemNewOrUsed
            // 
            this.txtItemNewOrUsed.BackColor = System.Drawing.SystemColors.Menu;
            this.txtItemNewOrUsed.Location = new System.Drawing.Point(111, 221);
            this.txtItemNewOrUsed.Name = "txtItemNewOrUsed";
            this.txtItemNewOrUsed.Size = new System.Drawing.Size(54, 20);
            this.txtItemNewOrUsed.TabIndex = 43;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(30, 224);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 13);
            this.label12.TabIndex = 42;
            this.label12.Text = "New or Used:";
            // 
            // txtTimeOrdered
            // 
            this.txtTimeOrdered.BackColor = System.Drawing.SystemColors.Menu;
            this.txtTimeOrdered.Location = new System.Drawing.Point(113, 356);
            this.txtTimeOrdered.Name = "txtTimeOrdered";
            this.txtTimeOrdered.Size = new System.Drawing.Size(134, 20);
            this.txtTimeOrdered.TabIndex = 39;
            this.txtTimeOrdered.Text = "9/05/2019 1:39 PM";
            // 
            // frmOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 462);
            this.Controls.Add(this.txtItemNewOrUsed);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtItemDesc);
            this.Controls.Add(this.txtTimeOrdered);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtQnty);
            this.Controls.Add(this.txtCustPh);
            this.Controls.Add(this.txtCustName);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtItemModel);
            this.Controls.Add(this.txtTotalOrderPrice);
            this.Controls.Add(this.txtPricePerItem);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmOrder";
            this.Text = "frmOrder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOrder_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtItemModel;
        private System.Windows.Forms.TextBox txtTotalOrderPrice;
        private System.Windows.Forms.TextBox txtPricePerItem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtCustName;
        private System.Windows.Forms.TextBox txtCustPh;
        private System.Windows.Forms.TextBox txtQnty;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtItemDesc;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtItemNewOrUsed;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTimeOrdered;
    }
}