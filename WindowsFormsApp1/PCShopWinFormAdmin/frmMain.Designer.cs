namespace PCShopWinFormAdmin
{
    partial class frmMain
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
            this.Tabs = new System.Windows.Forms.TabControl();
            this.Categories = new System.Windows.Forms.TabPage();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnViewCategory = new System.Windows.Forms.Button();
            this.grdCategories = new System.Windows.Forms.DataGridView();
            this.CategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbOrders = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExit2 = new System.Windows.Forms.Button();
            this.btnViewOrder = new System.Windows.Forms.Button();
            this.btnDeleteOrder = new System.Windows.Forms.Button();
            this.grdOrders = new System.Windows.Forms.DataGridView();
            this.clmnOrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnItemOrdered = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnQtyOrdered = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnTotalOrderPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tabs.SuspendLayout();
            this.Categories.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCategories)).BeginInit();
            this.tbOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // Tabs
            // 
            this.Tabs.Controls.Add(this.Categories);
            this.Tabs.Controls.Add(this.tbOrders);
            this.Tabs.HotTrack = true;
            this.Tabs.Location = new System.Drawing.Point(-3, 12);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(825, 470);
            this.Tabs.TabIndex = 0;
            // 
            // Categories
            // 
            this.Categories.Controls.Add(this.btnExit);
            this.Categories.Controls.Add(this.btnViewCategory);
            this.Categories.Controls.Add(this.grdCategories);
            this.Categories.Location = new System.Drawing.Point(4, 22);
            this.Categories.Name = "Categories";
            this.Categories.Padding = new System.Windows.Forms.Padding(3);
            this.Categories.Size = new System.Drawing.Size(817, 444);
            this.Categories.TabIndex = 0;
            this.Categories.Text = "Categories";
            this.Categories.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(714, 377);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(97, 30);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // btnViewCategory
            // 
            this.btnViewCategory.Location = new System.Drawing.Point(289, 6);
            this.btnViewCategory.Name = "btnViewCategory";
            this.btnViewCategory.Size = new System.Drawing.Size(97, 30);
            this.btnViewCategory.TabIndex = 1;
            this.btnViewCategory.Text = "View Category";
            this.btnViewCategory.UseVisualStyleBackColor = true;
            this.btnViewCategory.Click += new System.EventHandler(this.btnViewCategory_Click);
            // 
            // grdCategories
            // 
            this.grdCategories.AllowUserToAddRows = false;
            this.grdCategories.AllowUserToDeleteRows = false;
            this.grdCategories.AllowUserToResizeColumns = false;
            this.grdCategories.AllowUserToResizeRows = false;
            this.grdCategories.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdCategories.CausesValidation = false;
            this.grdCategories.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.grdCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCategories.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CategoryName});
            this.grdCategories.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdCategories.Location = new System.Drawing.Point(11, 6);
            this.grdCategories.MultiSelect = false;
            this.grdCategories.Name = "grdCategories";
            this.grdCategories.ReadOnly = true;
            this.grdCategories.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.grdCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdCategories.ShowEditingIcon = false;
            this.grdCategories.Size = new System.Drawing.Size(272, 267);
            this.grdCategories.TabIndex = 0;
            this.grdCategories.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCategories_CellContentDoubleClick);
            // 
            // CategoryName
            // 
            this.CategoryName.DataPropertyName = "Name";
            this.CategoryName.FillWeight = 60.9137F;
            this.CategoryName.HeaderText = "Category Name";
            this.CategoryName.Name = "CategoryName";
            this.CategoryName.ReadOnly = true;
            // 
            // tbOrders
            // 
            this.tbOrders.Controls.Add(this.label3);
            this.tbOrders.Controls.Add(this.btnExit2);
            this.tbOrders.Controls.Add(this.btnViewOrder);
            this.tbOrders.Controls.Add(this.btnDeleteOrder);
            this.tbOrders.Controls.Add(this.grdOrders);
            this.tbOrders.Location = new System.Drawing.Point(4, 22);
            this.tbOrders.Name = "tbOrders";
            this.tbOrders.Padding = new System.Windows.Forms.Padding(3);
            this.tbOrders.Size = new System.Drawing.Size(817, 444);
            this.tbOrders.TabIndex = 1;
            this.tbOrders.Text = "Orders";
            this.tbOrders.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 18);
            this.label3.TabIndex = 22;
            this.label3.Text = "Orders";
            // 
            // btnExit2
            // 
            this.btnExit2.Location = new System.Drawing.Point(714, 377);
            this.btnExit2.Name = "btnExit2";
            this.btnExit2.Size = new System.Drawing.Size(97, 30);
            this.btnExit2.TabIndex = 3;
            this.btnExit2.Text = "Exit";
            this.btnExit2.UseVisualStyleBackColor = true;
            // 
            // btnViewOrder
            // 
            this.btnViewOrder.Location = new System.Drawing.Point(655, 61);
            this.btnViewOrder.Name = "btnViewOrder";
            this.btnViewOrder.Size = new System.Drawing.Size(95, 35);
            this.btnViewOrder.TabIndex = 2;
            this.btnViewOrder.Text = "View Order";
            this.btnViewOrder.UseVisualStyleBackColor = true;
            this.btnViewOrder.Click += new System.EventHandler(this.btnViewOrder_Click);
            // 
            // btnDeleteOrder
            // 
            this.btnDeleteOrder.Location = new System.Drawing.Point(655, 120);
            this.btnDeleteOrder.Name = "btnDeleteOrder";
            this.btnDeleteOrder.Size = new System.Drawing.Size(95, 35);
            this.btnDeleteOrder.TabIndex = 1;
            this.btnDeleteOrder.Text = "Delete Order";
            this.btnDeleteOrder.UseVisualStyleBackColor = true;
            this.btnDeleteOrder.Click += new System.EventHandler(this.btnDeleteOrder_Click);
            // 
            // grdOrders
            // 
            this.grdOrders.AllowUserToAddRows = false;
            this.grdOrders.AllowUserToDeleteRows = false;
            this.grdOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnOrderNo,
            this.clmnItemOrdered,
            this.clmnQtyOrdered,
            this.clmnTotalOrderPrice,
            this.clmnCustomerName});
            this.grdOrders.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdOrders.Location = new System.Drawing.Point(14, 61);
            this.grdOrders.MultiSelect = false;
            this.grdOrders.Name = "grdOrders";
            this.grdOrders.ReadOnly = true;
            this.grdOrders.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.grdOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdOrders.Size = new System.Drawing.Size(637, 346);
            this.grdOrders.TabIndex = 0;
            // 
            // clmnOrderNo
            // 
            this.clmnOrderNo.DataPropertyName = "OrderNo";
            this.clmnOrderNo.HeaderText = "OrderNo";
            this.clmnOrderNo.Name = "clmnOrderNo";
            this.clmnOrderNo.ReadOnly = true;
            // 
            // clmnItemOrdered
            // 
            this.clmnItemOrdered.DataPropertyName = "OrderItemModel";
            this.clmnItemOrdered.HeaderText = "Item Ordered";
            this.clmnItemOrdered.Name = "clmnItemOrdered";
            this.clmnItemOrdered.ReadOnly = true;
            // 
            // clmnQtyOrdered
            // 
            this.clmnQtyOrdered.DataPropertyName = "Qnty";
            this.clmnQtyOrdered.HeaderText = "Qty Ordered";
            this.clmnQtyOrdered.Name = "clmnQtyOrdered";
            this.clmnQtyOrdered.ReadOnly = true;
            // 
            // clmnTotalOrderPrice
            // 
            this.clmnTotalOrderPrice.DataPropertyName = "TotalOrderPrice";
            this.clmnTotalOrderPrice.HeaderText = "Total Order Price";
            this.clmnTotalOrderPrice.Name = "clmnTotalOrderPrice";
            this.clmnTotalOrderPrice.ReadOnly = true;
            // 
            // clmnCustomerName
            // 
            this.clmnCustomerName.DataPropertyName = "CustName";
            this.clmnCustomerName.HeaderText = "Customer Name";
            this.clmnCustomerName.Name = "clmnCustomerName";
            this.clmnCustomerName.ReadOnly = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 480);
            this.Controls.Add(this.Tabs);
            this.Name = "frmMain";
            this.Text = "PCShop Admin Main Form";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Tabs.ResumeLayout(false);
            this.Categories.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCategories)).EndInit();
            this.tbOrders.ResumeLayout(false);
            this.tbOrders.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.TabPage Categories;
        private System.Windows.Forms.TabPage tbOrders;
        private System.Windows.Forms.DataGridView grdCategories;
        private System.Windows.Forms.Button btnDeleteOrder;
        private System.Windows.Forms.DataGridView grdOrders;
        private System.Windows.Forms.Button btnViewCategory;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnViewOrder;
        private System.Windows.Forms.Button btnExit2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnOrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnItemOrdered;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnQtyOrdered;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnTotalOrderPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnCustomerName;
    }
}

