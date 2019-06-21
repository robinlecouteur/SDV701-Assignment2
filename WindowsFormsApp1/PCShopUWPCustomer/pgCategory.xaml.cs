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
    public sealed partial class pgCategory : Page
    {
        public pgCategory()
        {
            this.InitializeComponent();
            grdItems.AutoGenerateColumns = false;
        }

        private clsCategory _Category;

        private void updateDisplay()
        {
            grdItems.ItemsSource = null;
            if (_Category.ItemsList != null)
                grdItems.ItemsSource = _Category.ItemsList;       
            
            txtName.Text = _Category.Name;
            txtDescription.Text = _Category.Description;
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            clsCategory lcCategory = (clsCategory)e.Parameter;
            _Category = await ServiceClient.GetCategoryAsync(lcCategory.ID);
            updateDisplay();
        }

        private void btnViewItem_Click(object sender, RoutedEventArgs e)
        {
            viewWork(grdItems.SelectedItem as clsAllItem);
        }


        private void viewWork(clsAllItem prItem)
        {
            if (prItem != null)
                Frame.Navigate(typeof(pgItem), prItem);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
