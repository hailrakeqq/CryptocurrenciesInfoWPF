using CryptocurrenciesInfoWPF.Models.Entities;
using CryptocurrenciesInfoWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace CryptocurrenciesInfoWPF.Pages
{
    /// <summary>
    /// Interaction logic for AllCryptocurrencyCollection.xaml
    /// </summary>
    public partial class AllCryptocurrencyCollection : Page
    {
        private Cryptocurrency[] _cryptocurrencyCollection { get; set; }



        public AllCryptocurrencyCollection()
        {
            InitializeComponent();
            InsertTopCryptocurrencyToListBox();
        }
        
        private void GoBackToMainMenu(object  sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private async void InsertTopCryptocurrencyToListBox()
        {
            _cryptocurrencyCollection = await APIRequests.GetCryptocurrencyCollection("http://api.coincap.io/v2/assets");
            foreach (var item in _cryptocurrencyCollection)
            {
                if (item.changePercent24Hr > 0)
                    cryptocurrencyCollection.Items.Insert(Convert.ToInt16(item.rank) - 1, $"{item.name} \t\t +{item.changePercent24Hr} % 📈");
                else
                    cryptocurrencyCollection.Items.Insert(Convert.ToInt16(item.rank) - 1, $"{item.name} \t\t {item.changePercent24Hr} % 📉");
            }
        }

        private void GetIDAndRedirectToCryptocurrencyPage(object sender, SelectionChangedEventArgs e)
        {
            // example output string: " \t\t +1,4767562808276802 % 📈"
            // we must get cryptocurrency name from string => 
            var selectedCryptocurrencyName = cryptocurrencyCollection.SelectedItem?.ToString()?.Split('\t')[0].Trim();
            var selectedCryptocurrencyId = _cryptocurrencyCollection.Where(c => c.name == selectedCryptocurrencyName).FirstOrDefault();
            NavigationService.Navigate(new CryptocurrencyPage(selectedCryptocurrencyId?.id));
        }
    }
}
