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
    /// This form shows a category and a summary of all items related to it. 
    /// You can add, edit, and delete items in this form.
    /// </summary>
    public partial class frmCategory : Form, IObserver
    {


        public frmCategory()
        {
            InitializeComponent();
            cboItemType.DataSource = clsAllItem.LstNewOrUsed;
            cboItemType.SelectedIndex = 0;
            grdItems.AutoGenerateColumns = false;
        }
        private clsCategory _Category;
        private static Dictionary<int, frmCategory> _CategoryFormList = new Dictionary<int, frmCategory>();

        public static void Run(int prCategoryID)
        {
            
            frmCategory lcCategoryForm;
            if (!_CategoryFormList.TryGetValue(prCategoryID, out lcCategoryForm))
            {
                lcCategoryForm = new frmCategory();
                _CategoryFormList.Add(prCategoryID, lcCategoryForm);

                lcCategoryForm.refreshFormFromDB(prCategoryID);
                clsMQTTClient.Instance.Subscribe(lcCategoryForm);
                lcCategoryForm.Show();
            }
            else
            {
                clsMQTTClient.Instance.Subscribe(lcCategoryForm);
                lcCategoryForm.Show();
                lcCategoryForm.Activate();
            }
        }

        private async void refreshFormFromDB(int prCategoryID)
        {
            SetDetails(await ServiceClient.GetCategoryAsync(prCategoryID));
        }


        private void updateDisplay()
        {
            txtCategoryName.Text = _Category.Name;
            txtCategoryDesc.Text = _Category.Description;

            grdItems.DataSource = null;
            if (_Category.ItemsList != null)
                grdItems.DataSource = _Category.ItemsList;
        }

        public void SetDetails(clsCategory prCategory)
        {
            _Category = prCategory;
            updateDisplay();
        }

        private char getReply()
        {
            switch (cboItemType.SelectedItem)
            {
                case "New": return 'N';
                case "Used": return 'U';
                default: throw new Exception("Bad Item Type");
            }
        }

        //Edit Item -----------------------------------------------------------------------------\
        private void lstWorks_DoubleClick(object sender, EventArgs e)
        {
            editItem();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            editItem();
        }

        private async void editItem()
        {
            try
            {
                if (grdItems.SelectedRows.Count == 0)
                {
                    throw new Exception("No Item Selected");
                }
                else
                {
                    DataGridViewRow row = this.grdItems.SelectedRows[0];
                    clsAllItem lcItem = row.DataBoundItem as clsAllItem;

                    if (lcItem != null)
                    {
                        frmItem.DispatchItemForm(lcItem);
                        SetDetails(await ServiceClient.GetCategoryAsync(_Category.ID));
                    }
                    else
                    {
                        throw new Exception("Error! Null Item");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        // --------------------------------------------------------------------------------------/


        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                char lcReply = getReply();
                clsAllItem lcItem = clsAllItem.NewItem(lcReply);
                if (lcItem != null)
                {
                    lcItem.CategoryID = _Category.ID;
                    frmItem.DispatchItemForm(lcItem);
                    if (!string.IsNullOrEmpty(lcItem.Model))
                    {
                        refreshFormFromDB(_Category.ID);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                clsMQTTClient.Instance.Unsubscribe(this);
                Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmCategory_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                clsMQTTClient.Instance.Unsubscribe(this);
                e.Cancel = true;
                Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Deletes an item out of the database and refreshes the screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                if (grdItems.SelectedRows.Count == 0)
                {
                    throw new Exception("No Item Selected");
                }
                else
                {
                    if (MessageBox.Show("Are you sure you want to do this?", "Warning!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        MessageBox.Show(await ServiceClient.DeleteItemAsync(grdItems.SelectedRows[0].DataBoundItem as clsAllItem));
                        refreshFormFromDB(_Category.ID);
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
            refreshFormFromDB(_Category.ID);
        }




        private void mqttUpdateGUI()
        {
            refreshFormFromDB(_Category.ID);
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
