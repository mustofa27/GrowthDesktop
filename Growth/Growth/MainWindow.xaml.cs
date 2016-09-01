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
using Growth.Helper;

namespace Growth
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void area_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Uri("/Pages/Area/Index.xaml", UriKind.Relative));
        }

        private void dashboard_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Uri("/Pages/Dashboard.xaml", UriKind.Relative));
        }

        private void outlet_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Uri("/Pages/Outlet/Index.xaml", UriKind.Relative));
        }
    }
}
