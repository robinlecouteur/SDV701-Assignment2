using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PCShopWinFormAdmin
{
    public partial class frmUsedItem : PCShopWinFormAdmin.frmItem
    {
        private frmUsedItem()
        {
            InitializeComponent();
        }


        private static readonly frmUsedItem _Instance = new frmUsedItem();

        public static frmUsedItem Instance => _Instance;

        protected override void updateForm()
        {
            base.updateForm();
            dtpDateOfManufacture.Value = Convert.ToDateTime(_Item.ManufactureDate);
            txtCondition.Text = _Item.Condition;
        }

        protected override void pushData()
        {
            base.pushData();
            _Item.ManufactureDate = dtpDateOfManufacture.Value;
            _Item.Condition = txtCondition.Text;
        }

        public static void Run(clsAllItem prItem)
        {
            Instance.SetDetails(prItem);
        }
    }
}
