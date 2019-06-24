using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PCShopUWPCustomer
{
    /// <summary>
    /// Order page
    /// </summary>
    public sealed partial class pgOrder : Page,IObserver
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

            if (String.IsNullOrEmpty(txtQtyToOrder.Text) == false)
            {
                if (int.Parse(txtQtyToOrder.Text) > _Item.QtyInStock)
                {
                    txtQtyToOrder.Text = _Item.QtyInStock.ToString();
                }
            }

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


        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            _Item = await ServiceClient.GetItemAsync((e.Parameter as clsAllItem).ID);
            updateDisplay();
            clsMQTTClient.Instance.Subscribe(this);
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            clsMQTTClient.Instance.Unsubscribe(this);
        }


        private bool userInputIsValid()
        {
            bool lcIsValid = true;
            List<TextBox> lcLstTextBoxes = new List<TextBox> { txtCustName, txtCustPh, txtQtyToOrder};
            foreach (TextBox lcTextBox in lcLstTextBoxes)
            {
                if (String.IsNullOrWhiteSpace(lcTextBox.Text))
                {
                    lcIsValid = false;
                    break;
                }
            }
            return lcIsValid;
        }
        private async void btnConfirmOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (userInputIsValid())
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

                    if (await ServiceClient.UpdateItemAsync(lcItem) == "\"DateModifiedMismatch\"") //Check concurrency. The server will send back a notification if data is out of date.
                    {
                        throw new Exception("DateModifiedMismatch");
                    }
                    else
                    {
                        await ServiceClient.InsertOrderAsync(lcOrder);

                        await DisplayOrderSuccessMbox();
                    }
                }
                else
                {
                    await DisplayInvalidInputMbox();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "DateModifiedMismatch")
                {
                    await DisplayMismatchMbox();
                }
                else
                {
                    throw;
                }           
            }
        }


        //Messageboxes
        private async System.Threading.Tasks.Task DisplayOrderSuccessMbox()
        {
            //Show Messagebox
            var messageDialog = new MessageDialog("Order placed successfully! Thank you for shopping at PCShop.");
            messageDialog.Commands.Add(new UICommand(
                "OK",
                new UICommandInvokedHandler(this.CommandInvokedHandlerB)));
            messageDialog.DefaultCommandIndex = 1;
            messageDialog.CancelCommandIndex = 1;
            await messageDialog.ShowAsync();
        }
        private async System.Threading.Tasks.Task DisplayInvalidInputMbox()
        {
            var messageDialog = new MessageDialog("Invalid Input! Make sure all fields are filled out.");
            messageDialog.Commands.Add(new UICommand(
                "OK",
                new UICommandInvokedHandler(this.CommandInvokedHandler)));
            messageDialog.DefaultCommandIndex = 1;
            messageDialog.CancelCommandIndex = 1;
            await messageDialog.ShowAsync();
        }
        private async System.Threading.Tasks.Task DisplayMismatchMbox()
        {
            var messageDialog = new MessageDialog("Data displayed is out of date. Click 'Ok' to refresh the page.");
            messageDialog.Commands.Add(new UICommand(
                "Ok",
                new UICommandInvokedHandler(this.CommandInvokedHandler)));
            messageDialog.DefaultCommandIndex = 1;
            messageDialog.CancelCommandIndex = 1;
            await messageDialog.ShowAsync();
        }
        

        private void CommandInvokedHandler(IUICommand command)
        {
            refreshFormFromDB();
        }
        private void CommandInvokedHandlerB(IUICommand command)
        {
            Frame.GoBack();
        }
        //-------------

        private async void refreshFormFromDB()
        {
            _Item = await ServiceClient.GetItemAsync(_Item.ID);
            if (_Item != null)
            {
                _Item = await ServiceClient.GetItemAsync(_Item.ID);
                updateDisplay();
            }
            else
            {
                Frame.GoBack();
            }    
        }




        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            refreshFormFromDB();
        }

        private void txtQtyToOrder_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            if (args.NewText.Any(c => !char.IsDigit(c)) || (int.Parse(args.NewText)) > _Item.QtyInStock )
            {
                args.Cancel = true;
            }
            
        }

        private void txtCustName_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsLetter(c));
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void txtQtyToOrder_TextChanged(object sender, TextChangedEventArgs e)
        {
            updateTotalOrderPrice(_Item);
        }



        private void mqttUpdateGUI()
        {
            refreshFormFromDB();
        }
        public async void MqttUpdate(string lcMessage)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () =>
            {
                mqttUpdateGUI();
            });
        }
    }
}
