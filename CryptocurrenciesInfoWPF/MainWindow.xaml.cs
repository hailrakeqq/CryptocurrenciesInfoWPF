using CryptocurrenciesInfoWPF.Models;
using CryptocurrenciesInfoWPF.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace CryptocurrenciesInfoWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InsertTopCryptocurrencyToListBox();
        }
        private async void InsertTopCryptocurrencyToListBox()
        {
            var cryptocurrencyCollection = await GetFirstTenCryptocurrencyByRank();
            foreach(var item in cryptocurrencyCollection)
            {
                if(item.changePercent24Hr > 0)
                    topCryptocurrencyCollection.Items.Insert(Convert.ToInt16(item.rank) - 1, $"{item.name} \t\t +{item.changePercent24Hr} % 📈");
                else
                    topCryptocurrencyCollection.Items.Insert(Convert.ToInt16(item.rank) - 1, $"{item.name} \t\t {item.changePercent24Hr} % 📉");
            }
        }
        public async Task<List<Cryptocurrency>> GetFirstTenCryptocurrencyByRank()
        {
            var data = await HttpClientService.GetJsonFromAPIResponseAsync("http://api.coincap.io/v2/assets?limit=10");
            return  Toolchain.GetCryptocurrencyCollectionFromJson(data);

        }
    }
}
