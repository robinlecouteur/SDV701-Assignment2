using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class pgItem : Page
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
            _Item = prItem;
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
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            dispatchItemContent(e.Parameter as clsAllItem);
        }

        private void btnOrderItem_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(pgOrder), _Item);
        }
    }
}
