﻿using CryptocurrenciesInfoWPF.Pages;
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
            MainFrame.Content = new MainPage();
        }
    }
}
