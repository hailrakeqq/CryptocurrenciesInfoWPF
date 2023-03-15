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

namespace CryptocurrenciesInfoWPF.Pages
{
    /// <summary>
    /// Interaction logic for CryptocurrencyPage.xaml
    /// </summary>
    public partial class CryptocurrencyPage : Page
    {
        private readonly string _cryptocurrencyId;
        private Cryptocurrency currentCryptocurrency;
        public CryptocurrencyPage(string cryptocurrencyId)
        {
            InitializeComponent();
            _cryptocurrencyId = cryptocurrencyId;
            GetCurrentCryptocurrency();
        }

        private async void GetCurrentCryptocurrency()
        {
            currentCryptocurrency = await APIRequests.GetCryptocurrencyInfoById("http://api.coincap.io/v2/assets", _cryptocurrencyId);
        }

        private void ReturnLastPage(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
