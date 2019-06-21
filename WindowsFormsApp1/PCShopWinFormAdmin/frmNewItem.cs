using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PCShopWinFormAdmin
{
    public partial class frmNewItem : PCShopWinFormAdmin.frmItem
    {
        private frmNewItem()
        {
            InitializeComponent();
        }


        private static readonly frmNewItem _Instance = new frmNewItem();

        public static frmNewItem Instance => _Instance;

        protected override void updateForm()
        {
            base.updateForm();
            txtImportCountry.Text = _Item.ImportCountry;
        }

        protected override void pushData()
        {
            base.pushData();
            _Item.ImportCountry = txtImportCountry.Text;
        }

        public static void Run(clsAllItem prItem)
        {
            Instance.SetDetails(prItem);
        }
    }
}
