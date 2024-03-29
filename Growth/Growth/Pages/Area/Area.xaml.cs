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
using Growth.Helper;

namespace Growth.Pages.Area
{
    /// <summary>
    /// Interaction logic for Area.xaml
    /// </summary>
    public partial class Area : Page
    {
        public Area()
        {
            InitializeComponent();
            listArea.ItemsSource = SQLiteDBHelper.ReadAllArea();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Pages/Area/Form.xaml", UriKind.Relative));
        }
    }
}
