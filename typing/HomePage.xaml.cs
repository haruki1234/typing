﻿using System;
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

namespace typing
{
    /// <summary>
    /// Page1.xaml の相互作用ロジック
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void Go_title(object sender, RoutedEventArgs e)
        {
            var tpage = new TitlePage();
            NavigationService.Navigate(tpage);
        }

        private void Go_setting(object sender, RoutedEventArgs e)
        {
            var tpage = new SettingPage();
            NavigationService.Navigate(tpage);
        }

        private void Go_play(object sender, RoutedEventArgs e)
        {
            var tpage = new PlayPage();
            NavigationService.Navigate(tpage);
        }
    }
}