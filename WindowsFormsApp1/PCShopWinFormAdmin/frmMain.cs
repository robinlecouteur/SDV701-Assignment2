using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCShopWinFormAdmin
{
    public partial class frmMain : Form
    {
        private frmMain()
        {
            InitializeComponent();
        }
        private static readonly frmMain _Instance = new frmMain();
        public static frmMain Instance => _Instance;

        public async void UpdateDisplay()
        {
            try
            {
                grdCategories.AutoGenerateColumns = false;
                grdCategories.DataSource = null;

                List<clsCategory> lcCategoryList = await ServiceClient.GetCategoriesAsync();
                //lcCategoryList.Sort(_Comparer[cboSortChoice.SelectedIndex]);
                grdCategories.DataSource = lcCategoryList;
            }
            catch (Exception)
            {

                MessageBox.Show("Error Updating Display!", "Warning!");
            }



        }
    }
}
