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
using Growth.Interfaces;

namespace Growth.Pages.Area
{
    /// <summary>
    /// Interaction logic for Index.xaml
    /// </summary>
    public partial class Index : Page,Callback
    {
        public Index()
        {
            InitializeComponent();
        }

        public void Done(string res)
        {
            test.Text = res;
        }

        private void testing_Click(object sender, RoutedEventArgs e)
        {
            //ConnectionHelper.DownloadPageAsync("http://demo.growth.co.id/login/keira/asd",this);
            ConnectionHelper.PostToPage("http://demo.growth.co.id/setIdGCM", this);
        }
    }
}
