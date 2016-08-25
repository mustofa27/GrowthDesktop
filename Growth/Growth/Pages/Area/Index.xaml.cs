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
            //SQLiteDBHelper.InsertCity(new City(1, 1, "testing1"));
            //SQLiteDBHelper.InsertCity(new City(2, 2, "testing1"));
            //SQLiteDBHelper.InsertCompetitor(new Competitor(1, 1, "testing1", "testing1"));
            //SQLiteDBHelper.InsertCompetitor(new Competitor(2, 2, "testing1", "testing1"));
        }

        public void Done(string res)
        {
            test.Text = res;
        }

        private void testing_Click(object sender, RoutedEventArgs e)
        {
            //ConnectionHelper.DownloadPageAsync("http://demo.growth.co.id/login/keira/asd",this);
            //ConnectionHelper.PostToPage("http://demo.growth.co.id/setIdGCM", this);
            Master.Competitor city = SQLiteDBHelper.ReadCompetitor(1);
            city.setNm_competitor("edit baru");
            SQLiteDBHelper.UpdateCompetitor(city);
            test.Text = SQLiteDBHelper.ReadCompetitor(1).getNm_competitor();
            //List<Competitor> cities = SQLiteDBHelper.ReadAllCompetitor();
            //foreach (var city in cities)
            //{
            //    test.Text += ' ' + city.getNm_competitor();
            //}
        }
    }
}
