using CryptocurrenciesInfoWPF.Models.Entities;
using CryptocurrenciesInfoWPF.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace CryptocurrenciesInfoWPF.Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public Cryptocurrency[] _top10CryptocurrenciesCollection { get; set; }
        public MainPage()
        {
            InitializeComponent();
            InsertTopCryptocurrencyToListBox();
        }
       
        private async void InsertTopCryptocurrencyToListBox()
        {
            _top10CryptocurrenciesCollection = await APIRequests.GetCryptocurrencyCollection("http://api.coincap.io/v2/assets", "limit=10");
            foreach (var item in _top10CryptocurrenciesCollection)
            {
                if (item.changePercent24Hr > 0)
                    topCryptocurrencyCollection.Items.Insert(Convert.ToInt16(item.rank) - 1, $"{Convert.ToInt16(item.rank)}. {item.name} \t\t +{item.changePercent24Hr} % 📈");
                else
                    topCryptocurrencyCollection.Items.Insert(Convert.ToInt16(item.rank) - 1, $"{Convert.ToInt16(item.rank)}. {item.name} \t\t {item.changePercent24Hr} % 📉");
            }
        }

        private void GetIDAndRedirectToCryptocurrencyPage(object sender, SelectionChangedEventArgs e)
        {
            // example output string: "1. bitcoin \t\t +1,4767562808276802 % 📈"
            // we must get cryptocurrency name from string => 
            var selectedCryptocurrencyName = topCryptocurrencyCollection.SelectedItem?.ToString()?.Split(new char[] { '.', '\t' })[1].Trim();
            var selectedCryptocurrencyId = _top10CryptocurrenciesCollection.Where(c => c.name == selectedCryptocurrencyName).FirstOrDefault();
            NavigationService.Navigate(new CryptocurrencyPage(selectedCryptocurrencyId?.id));
        }

        private void RedirectToAllCryptocurrencyCollectionPage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AllCryptocurrencyCollection());
        }
        private void GoToSettings(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Settings());
        }
    }
}
