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
    public sealed partial class pgItem : Page, IObserver
    {
        public pgItem()
        {
            this.InitializeComponent();
            _ItemsContent = new Dictionary<char, Delegate>
            {
                { 'N', new LoadItemControlDelegate(RunNewItem) },
                { 'U', new LoadItemControlDelegate(RunUsedItem) }
            };
        }
        private clsAllItem _Item;

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
        private void updatePage(clsAllItem prItem)
        {
            txtID.Text = _Item.ID.ToString().EmptyIfNull();
            txtModel.Text = _Item.Model.EmptyIfNull();
            txtDescription.Text = _Item.Description.EmptyIfNull();
            txtOS.Text = _Item.OperatingSystem.EmptyIfNull();
            txtPricePerItem.Text = _Item.Price.ToString().EmptyIfNull();
            txtQtyInStock.Text = _Item.QtyInStock.ToString().EmptyIfNull();
            txtNewOrUsed.Text = _Item.NewOrUsed.ToString().EmptyIfNull();
            (ctcItemSpecs.Content as IItemControl).UpdateControl(prItem);
        }

        private void RunNewItem(clsAllItem prItem)
        {
            ctcItemSpecs.Content = new ucNewItem();
            txbPageTitle.Text = "New Item";
        }

        private void RunUsedItem(clsAllItem prItem)
        {
            ctcItemSpecs.Content = new ucUsedItem();
            txbPageTitle.Text = "Used Item";
        }

        private delegate void LoadItemControlDelegate(clsAllItem prWork);
        private Dictionary<char, Delegate> _ItemsContent;

        private void dispatchItemContent(clsAllItem prItem)
        {
            _ItemsContent[prItem.NewOrUsed].DynamicInvoke(prItem);
            updatePage(prItem);
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            _Item = e.Parameter as clsAllItem;
            await updateScreen();
            clsMQTTClient.Instance.Subscribe(this);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            clsMQTTClient.Instance.Unsubscribe(this);
        }
        private async System.Threading.Tasks.Task updateScreen()
        {
            _Item = await ServiceClient.GetItemAsync(_Item.ID);
            if (_Item != null)
            {
                dispatchItemContent(_Item);
            }
            else
            {
                var messageDialog = new MessageDialog("Item no longer exists!");
                messageDialog.Commands.Add(new UICommand(
                    "OK",
                    new UICommandInvokedHandler(this.CommandInvokedHandler)));
                messageDialog.DefaultCommandIndex = 1;
                messageDialog.CancelCommandIndex = 1;
                await messageDialog.ShowAsync();
            }
            
        }

        private void CommandInvokedHandler(IUICommand command)
        {
            Frame.GoBack();
        }

        private void btnOrderItem_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(pgOrder), _Item);
        }

        private async void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            await updateScreen();
        }

        private async void refreshFormFromDB()
        {
            await updateScreen();
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
