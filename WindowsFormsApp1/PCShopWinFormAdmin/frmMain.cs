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
            grdCategories.AutoGenerateColumns = false;
            grdOrders.AutoGenerateColumns = false;
        }
        private static readonly frmMain _Instance = new frmMain();
        public static frmMain Instance => _Instance;

        public async void UpdateDisplay()
        {
            try
            {
                
                grdCategories.DataSource = null;
                List<clsCategory> lcCategoryList = await ServiceClient.GetCategoryListAsync();
                //lcCategoryList.Sort(_Comparer[cboSortChoice.SelectedIndex]);
                grdCategories.DataSource = lcCategoryList;


                grdOrders.DataSource = null;
                List<clsOrder> lcOrderList = await ServiceClient.GetOrderListAsync();
                //lcOrderList.Sort(_Comparer[cboSortChoice.SelectedIndex]);
                grdOrders.DataSource = lcOrderList;
            }
            catch (Exception)
            {
                MessageBox.Show("Error Updating Display!", "Warning!");
            }
        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        private void grdCategories_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OpenCategory();
        }

        private void OpenCategory()
        {
            try
            {
               DataGridViewRow row = this.grdCategories.SelectedRows[0];
                clsCategory lcCategory = row.DataBoundItem as clsCategory;

                if (lcCategory != null)                                     
                {
                    frmCategory.Run(lcCategory.ID);
                    UpdateDisplay();    //Update the screen to reflect the changes 
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error Opening Category!");
            }
        }

        private void OpenOrder()
        {
            try
            {
                DataGridViewRow row = this.grdOrders.SelectedRows[0];
                clsOrder lcOrder = row.DataBoundItem as clsOrder;

                if (lcOrder != null)
                {
                    frmOrder.Run(lcOrder.OrderNo);
                    UpdateDisplay();    //Update the screen to reflect the changes 
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error Opening Category!");
            }
        }

        private void btnViewCategory_Click(object sender, EventArgs e)
        {
            OpenCategory();
        }

        private void btnViewOrder_Click(object sender, EventArgs e)
        {
            OpenOrder();
        }

        private async void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            MessageBox.Show(await ServiceClient.DeleteOrderAsync(grdOrders.SelectedRows[0].DataBoundItem as clsOrder));
            UpdateDisplay();
            frmMain.Instance.UpdateDisplay();
        }
    }
}
