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
    public partial class frmCategory : Form
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
                lcCategoryForm.Show();
            }
            else
            {
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
            frmMain.Instance.UpdateDisplay();
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
            frmItem.DispatchItemForm(grdItems.SelectedRows[0].DataBoundItem as clsAllItem);
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmItem.DispatchItemForm(grdItems.SelectedRows[0].DataBoundItem as clsAllItem);
        }
        // --------------------------------------------------------------------------------------/

        private void rbByDate_CheckedChanged(object sender, EventArgs e)
        {
            //_WorksList.SortOrder = Convert.ToByte(rbByDate.Checked);
            //updateDisplay();
        }

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
            catch (Exception)
            {
                throw;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
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
                e.Cancel = true;
                Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show(await ServiceClient.DeleteItemAsync(grdItems.SelectedRows[0].DataBoundItem as clsAllItem));
            refreshFormFromDB(_Category.ID);
            frmMain.Instance.UpdateDisplay();
        }



        //private void updateTitle(string prGalleryName)
        //{
        //    if (!string.IsNullOrEmpty(prGalleryName))

        //        Text = "ArtistDetails - " + prGalleryName;
        //}
    }
}
