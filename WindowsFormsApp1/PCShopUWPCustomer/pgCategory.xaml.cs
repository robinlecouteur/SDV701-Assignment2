using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using System;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PCShopUWPCustomer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class pgCategory : Page, IObserver
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
            clsMQTTClient.Instance.Subscribe(this);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            clsMQTTClient.Instance.Unsubscribe(this);
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

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            refreshDisplay();
        }

        private void refreshDisplay()
        {
             refreshFormFromDB();
        }

        private async void refreshFormFromDB()
        {
            _Category = await ServiceClient.GetCategoryAsync(_Category.ID);
            updateDisplay();
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
