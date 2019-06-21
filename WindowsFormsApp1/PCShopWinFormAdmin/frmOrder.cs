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
    public partial class frmOrder : Form
    {
        public frmOrder()
        {
            InitializeComponent();
        }
        private clsOrder _Order;
        private static Dictionary<int, frmOrder> _OrderFormList = new Dictionary<int, frmOrder>();


        public static void Run(int prOrderNo)
        {
            frmOrder lcOrderForm;
            if (!_OrderFormList.TryGetValue(prOrderNo, out lcOrderForm))
            {
                lcOrderForm = new frmOrder();
                _OrderFormList.Add(prOrderNo, lcOrderForm);

                lcOrderForm.refreshFormFromDB(prOrderNo);
                lcOrderForm.Show();
            }
            else
            {
                lcOrderForm.Show();
                lcOrderForm.Activate();
            }
        }

        private async void refreshFormFromDB(int prOrderNo)
        {
            SetDetails(await ServiceClient.GetOrderAsync(prOrderNo));
        }


        private void updateDisplay()
        {
            txtCustName.Text = _Order.CustName;
            txtCustPh.Text = _Order.CustPh;
            txtItemModel.Text = _Order.OrderItem.Model;
            txtItemDesc.Text = _Order.OrderItem.Description;
            txtItemNewOrUsed.Text = _Order.OrderItem.NewOrUsed.ToString();
            txtPricePerItem.Text = _Order.PricePerItem.ToString();
            txtQnty.Text = _Order.Qnty.ToString();
            txtTimeOrdered.Text = _Order.TimeOrdered.ToString();
            txtTotalOrderPrice.Text = _Order.TotalOrderPrice.ToString();

        }

        public void SetDetails(clsOrder prOrder)
        {
            _Order = prOrder;
            updateDisplay();
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

        private void frmOrder_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
