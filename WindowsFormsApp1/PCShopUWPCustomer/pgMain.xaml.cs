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
    public sealed partial class pgMain : Page
    {
        public pgMain()
        {
            this.InitializeComponent();
            clsMQTTClient.Instance.ConnectMqttClient();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            lstCategories.ItemsSource = await ServiceClient.GetCategoryListAsync();
        }

        private void btnViewCategory_Click(object sender, RoutedEventArgs e)
        {
            if (lstCategories.SelectedItem != null)
                Frame.Navigate(typeof(pgCategory), lstCategories.SelectedItem);
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }
    }
}
