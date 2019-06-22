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
    public partial class frmItem : Form, IObserver
    {

        protected clsAllItem _Item;
        public frmItem()
        {
            InitializeComponent();
            txtNewOrUsed.Enabled = false;
            txtID.Enabled = false;
        }


        public void SetDetails(clsAllItem prItem)
        {
            clsMQTTClient.Instance.Subscribe(this);
            _Item = prItem;
            updateForm();
            ShowDialog();
            
        }


        public virtual bool isValid()
        {
            bool lcIsValid = true;
            foreach (TextBox lcTextBox in this.Controls.OfType<TextBox>())
            {
                if (String.IsNullOrWhiteSpace(lcTextBox.Text))
                {
                    lcIsValid = false;
                    break;
                }
            }
            foreach (NumericUpDown lcNumericUpDown in this.Controls.OfType<NumericUpDown>())
            if (lcNumericUpDown.Text == "")
            {
                {
                    lcIsValid = false;
                }
            }
            return lcIsValid;
        }

        protected virtual void updateForm()
        {
            txtID.Text = _Item.ID.ToString();
            txtModel.Text = _Item.Model;
            txtDescription.Text = _Item.Description;
            txtOS.Text = _Item.OperatingSystem;
            nudPricePerItem.Value = _Item.Price;
            nudQtyInStock.Value = _Item.QtyInStock;
            txtNewOrUsed.Text = _Item.NewOrUsed.ToString();

            txtModel.Enabled = string.IsNullOrEmpty(_Item.Model);
        }
        protected virtual void pushData()
        {
            _Item.ID = int.Parse(txtID.Text);
            _Item.Model = txtModel.Text;
            _Item.Description = txtDescription.Text;
            _Item.OperatingSystem = txtOS.Text;
            _Item.Price = nudPricePerItem.Value;
            _Item.QtyInStock = Convert.ToInt32(nudQtyInStock.Value);
            _Item.NewOrUsed = char.Parse(txtNewOrUsed.Text);
        }

        public delegate void LoadWorkFormDelegate(clsAllItem prItem);
        public static Dictionary<char, Delegate> _ItemsForm = new Dictionary<char, Delegate>
        {
            { 'N', new LoadWorkFormDelegate(frmNewItem.Run) },
            { 'U', new LoadWorkFormDelegate(frmUsedItem.Run) }
        };
        public static void DispatchItemForm(clsAllItem prItem)
        {
            _ItemsForm[prItem.NewOrUsed].DynamicInvoke(prItem);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            clsMQTTClient.Instance.Unsubscribe(this);
            Hide();
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                clsMQTTClient.Instance.Unsubscribe(this);
                DialogResult = DialogResult.OK;
                pushData();
                if (txtModel.Enabled)
                    MessageBox.Show(await ServiceClient.InsertItemAsync(_Item));
                else
                    MessageBox.Show(await ServiceClient.UpdateItemAsync(_Item));
                Hide();
            }
            else
            {
                MessageBox.Show("Invalid Input! Make sure all fields are filled in");
            }
        }

        private void frmItem_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                e.Cancel = true;
                clsMQTTClient.Instance.Unsubscribe(this);
                Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void RefreshFormFromDB(int lcItemID)
        {
            _Item = await ServiceClient.GetItemAsync(lcItemID);
            updateForm();
        }




        private void mqttUpdateGUI()
        {
            RefreshFormFromDB(_Item.ID);
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
