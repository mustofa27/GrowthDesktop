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
            //SQLiteDBHelper.InsertOutlet(new Outlet(1, 1, 1, 1, "outlet", "sby", 1, "A", "08977907097", "sukses", "0.912594", "12.090923","PIC","0871328741",1));
            //SQLiteDBHelper.InsertOutlet(new Outlet(2, 1, 1, 1, "outlet", "sby", 1, "A", "08977907097", "sukses", "0.912594", "12.090923", "PIC", "0871328741", 1));
        }

        public void Done(string res)
        {
            test.Text = res;
        }

        private void testing_Click(object sender, RoutedEventArgs e)
        {
            //ConnectionHelper.DownloadPageAsync("http://demo.growth.co.id/login/keira/asd",this);
            //ConnectionHelper.PostToPage("http://demo.growth.co.id/setIdGCM", this);
            //Master.Outlet city = SQLiteDBHelper.ReadOutlet(1);
            //city.setNama("edit baru");
            //SQLiteDBHelper.UpdateOutlet(city);
            //test.Text = SQLiteDBHelper.ReadOutlet(1).getNama();
            List<Outlet> cities = SQLiteDBHelper.ReadAllOutlet();
            foreach (var city in cities)
            {
                test.Text += ' ' + city.getNama();
            }
        }
    }
}
