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
using Growth.Master;

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
            //SQLiteDBHelper.InsertLogging(new Logging(1, "desc 1", "testing1"));
            //SQLiteDBHelper.InsertLogging(new Logging(2, "desc 2", "testing1"));
            //SQLiteDBHelper.InsertDistributor(new Distributor(1, "dist", "Distributor", 1, "testing1", "testing1", "089098098709"));
            //SQLiteDBHelper.InsertDistributor(new Distributor(2, "dist", "Distributor", 1, "testing2", "testing1", "089098098709"));
        }

        public void Done(string res)
        {
            test.Text = res;
        }

        private void testing_Click(object sender, RoutedEventArgs e)
        {
            //ConnectionHelper.DownloadPageAsync("http://demo.growth.co.id/login/keira/asd",this);
            //ConnectionHelper.PostToPage("http://demo.growth.co.id/setIdGCM", this);
            Master.Distributor city = SQLiteDBHelper.ReadDistributor(1);
            city.setNm_dist("edit baru");
            SQLiteDBHelper.UpdateDistributor(city);
            test.Text = SQLiteDBHelper.ReadDistributor(1).getNm_dist();
            //List<Distributor> cities = SQLiteDBHelper.ReadAllDistributor();
            //foreach (var city in cities)
            //{
            //    test.Text += ' ' + city.getNm_dist();
            //}
        }
    }
}
