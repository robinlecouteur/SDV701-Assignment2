using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PCShopUWPCustomer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class pgOrder : Page
    {
        public pgOrder()
        {
            this.InitializeComponent();
        }

        private clsAllItem _Item;

        private void updateDisplay()
        {
            txtModel.Text = _Item.Model.EmptyIfNull();
            txtDescription.Text = _Item.Description.EmptyIfNull();
            txtPricePerItem.Text = _Item.Price.ToString().EmptyIfNull();
            txtQtyInStock.Text = _Item.QtyInStock.ToString().EmptyIfNull();
            txtNewOrUsed.Text = _Item.NewOrUsed.ToString().EmptyIfNull();
            updateTotalOrderPrice(_Item);
        }

        private void updateTotalOrderPrice(clsAllItem prItem)
        {
            if (String.IsNullOrWhiteSpace(txtQtyToOrder.Text) == false )
            {
                txtTotalOrderPrice.Text = (_Item.Price * decimal.Parse(txtQtyToOrder.Text)).ToString().EmptyIfNull();
            }
            else
            {
                txtTotalOrderPrice.Text = 0.ToString();
            }
            
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            _Item = e.Parameter as clsAllItem;
            updateDisplay();
        }

        private async void btnConfirmOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                clsOrder lcOrder = new clsOrder();
                clsAllItem lcItem = _Item;



                lcOrder.Qnty = int.Parse(txtQtyToOrder.Text);
                lcOrder.PricePerItem = decimal.Parse(txtPricePerItem.Text);
                lcOrder.CustName = txtCustName.Text;
                lcOrder.CustPh = txtCustPh.Text;
                lcOrder.TimeOrdered = DateTime.Now;
                lcOrder.ItemID = lcItem.ID;

                lcItem.QtyInStock -= lcOrder.Qnty;

                string lcUpdateResult = await ServiceClient.UpdateItemAsync(lcItem);
                if (lcUpdateResult == "\"DateModifiedMismatch\"") //Check concurrency. The server will send back a notification if data is out of date.
                {
                    throw new Exception("DateModifiedMismatch");
                }
                else
                {
                    await ServiceClient.InsertOrderAsync(lcOrder);
                    reloadPage();
                }
                
            }
            catch (Exception ex)
            {
                if (ex.Message == "DateModifiedMismatch")
                {
                    // Create the message dialog and set its content
                    var messageDialog = new MessageDialog("Data displayed is out of date. Click 'Ok' to refresh the page.");

                    // Add commands and set their callbacks; both buttons use the same callback function instead of inline event handlers
                    messageDialog.Commands.Add(new UICommand(
                        "Ok",
                        new UICommandInvokedHandler(this.CommandInvokedHandler)));

                    // Set the command that will be invoked by default
                    messageDialog.DefaultCommandIndex = 1;

                    // Set the command to be invoked when escape is pressed
                    messageDialog.CancelCommandIndex = 1;

                    // Show the message dialog
                    await messageDialog.ShowAsync();
                }
                else
                {
                    throw;
                }
                
            }

        }
        private void CommandInvokedHandler(IUICommand command)
        {

            reloadPage();
        }

        private async void reloadPage()
        {
            _Item = await ServiceClient.GetItemAsync(_Item.ID);
            updateDisplay();
        }
    }
}
