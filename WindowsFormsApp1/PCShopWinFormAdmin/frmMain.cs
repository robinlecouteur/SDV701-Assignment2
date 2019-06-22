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
    /// <summary>
    /// Author: Robin Le Couteur
    /// Date: 21/06/2019
    /// 
    /// This is the main form for the admin panel. It shows a summary of categories and orders on seperate tabs. 
    /// You can navigate to specific categories and orders, and you can delete orders.
    /// </summary>
    public partial class frmMain : Form, IObserver
    {
        private frmMain()
        {
            InitializeComponent();

            grdCategories.AutoGenerateColumns = false;
            grdOrders.AutoGenerateColumns = false;

            clsMQTTClient.Instance.Subscribe(this);
        }
        private static readonly frmMain _Instance = new frmMain();
        public static frmMain Instance => _Instance;

        /// <summary>
        /// Updates the data grids with data from the database.
        /// </summary>
        private async void updateDisplayFromDB()
        {
            try
            {
                grdCategories.DataSource = null;
                List<clsCategory> lcCategoryList = await ServiceClient.GetCategoryListAsync();
                grdCategories.DataSource = lcCategoryList;

                grdOrders.DataSource = null;
                List<clsOrder> lcOrderList = await ServiceClient.GetOrderListAsync();
                grdOrders.DataSource = lcOrderList;
            }
            catch (Exception)
            {
                MessageBox.Show("Error Updating Display!", "Warning!");
            }
        }



        private void OpenCategory()
        {
            try
            {
                if (grdCategories.SelectedRows.Count == 0)
                {
                    throw new Exception("No Category Selected");
                }
                else
                {
                    DataGridViewRow row = this.grdCategories.SelectedRows[0];
                    clsCategory lcCategory = row.DataBoundItem as clsCategory;

                    if (lcCategory != null)
                    {
                        frmCategory.Run(lcCategory.ID);
                        updateDisplayFromDB();    //Update the screen to reflect the changes 
                    }
                    else
                    {
                        throw new Exception("Error! Null Category");
                    }
                }         
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OpenOrder()
        {
            try
            {
                if (grdOrders.SelectedRows.Count == 0)
                {
                    throw new Exception("No Order Selected");
                }
                else if (grdOrders.SelectedRows.Count > 1)
                {
                    throw new Exception("Please select only one order to view");
                }
                else
                {    
                    DataGridViewRow row = this.grdOrders.SelectedRows[0];
                    clsOrder lcOrder = row.DataBoundItem as clsOrder;

                    if (lcOrder != null)
                    {
                        frmOrder.Run(lcOrder.OrderNo); 
                        updateDisplayFromDB();    //Update the screen to reflect the changes
                    }
                    else
                    {
                        throw new Exception("");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }









        // ########################## Events #############################
        private void frmMain_Load(object sender, EventArgs e)
        {
            updateDisplayFromDB();
        }

        private void grdCategories_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OpenCategory();
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


            try
            {
                if (grdCategories.SelectedRows.Count == 0)
                {
                    throw new Exception("No Order Selected");
                }
                else
                {
                    if (MessageBox.Show("Are you sure you want to do this?", "Warning!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        int lcNoOfRowsDeleted = grdOrders.SelectedRows.Count;
                        foreach (DataGridViewRow dr in grdOrders.SelectedRows)
                        {
                            await ServiceClient.DeleteOrderAsync(dr.DataBoundItem as clsOrder);
                        }

                        MessageBox.Show("Number of orders deleted: " + lcNoOfRowsDeleted);
                        updateDisplayFromDB();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            updateDisplayFromDB();
        }

        private void btnExit2_Click(object sender, EventArgs e)
        {
            clsMQTTClient.Instance.Unsubscribe(this);
            Application.Exit();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            clsMQTTClient.Instance.Unsubscribe(this);
            Application.Exit();
        }











        private void mqttUpdateGUI()
        {
            updateDisplayFromDB();
        }
        public void MqttUpdate(string lcMessage)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(mqttUpdateGUI));
            }
            else
            {
                // Do Something
                mqttUpdateGUI();
            }

        }
    }
}
