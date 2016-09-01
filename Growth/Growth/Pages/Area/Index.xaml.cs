using System.Windows;
using System.Windows.Controls;
using Growth.Helper;
using Growth.Interfaces;
using System;

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
            //SQLiteDBHelper.InsertArea(new Master.Area(1, "EJ1", "Jawa Timur"));
            //SQLiteDBHelper.InsertArea(new Master.Area(2, "EJ2", "Jawa Timur"));
            //SQLiteDBHelper.InsertArea(new Master.Area(3, "WJ1", "Jawa Barat"));
            //SQLiteDBHelper.InsertArea(new Master.Area(4, "MJ", "Jawa Tengah"));
            //SQLiteDBHelper.InsertProduct(new Product(1, "desc 1", "testing1"));
            //SQLiteDBHelper.InsertProduct(new Product(2, "desc 2", "testing1"));
            //SQLiteDBHelper.InsertTipe(new Tipe(1, "testing1"));
            //SQLiteDBHelper.InsertTipe(new Tipe(2, "testing2"));
            //SQLiteDBHelper.InsertPhotoActivity(new PhotoActivity(1, 1, 1, 1, 1, "outlet1", "sby", "A", "08977907097", "sukses", "0.912594"));
            //SQLiteDBHelper.InsertPhotoActivity(new PhotoActivity(2, 1, 1, 1, 1, "outlet2", "sby", "A", "08977907097", "sukses", "0.912594"));
            //SQLiteDBHelper.InsertVisitPlan(new VisitPlan(1, 1, "nik", "ahmad",1,1, "Alamat", "08977907097", "foto"));
            //SQLiteDBHelper.InsertVisitPlan(new VisitPlan(2, 1, "nik", "mustofa", 1, 1, "Alamat", "08977907097", "foto"));

        }

        public void Done(string res)
        {
            
        }

        private void testing_Click(object sender, RoutedEventArgs e)
        {
            //ConnectionHelper.DownloadPageAsync("http://demo.growth.co.id/login/keira/asd",this);
            //ConnectionHelper.PostToPage("http://demo.growth.co.id/setIdGCM", this);
            //Master.VisitPlan city = SQLiteDBHelper.ReadVisitPlan(1);
            //city.setDate_created("ahmad ganteng");
            //SQLiteDBHelper.UpdateVisitPlan(city);
            //test.Text = SQLiteDBHelper.ReadVisitPlan(1).getDate_created();
            //List<VisitPlan> cities = SQLiteDBHelper.ReadAllVisitPlan();
            //foreach (var x in cities)
            //{
            //    test.Text += ' ' + x.getDate_created();
            //}
            //Test foo = new Test(1, "desc 1", "testing1");
            //test.Text = "";
            //foreach (var prop in foo.GetType().GetProperties())
            //{
            //    test.Text += prop.Name.ToString() + " " + prop.PropertyType.ToString() + "  " + prop.GetValue(foo, null).ToString() + "\n";
            //}
            ConnectionHandler con = new ConnectionHandler(this);
            con.getAllData();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            frameUtama.Navigate(new Uri("/Pages/Area/Area.xaml", UriKind.Relative));
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            frameUtama.Navigate(new Uri("/Pages/Area/Area_City.xaml", UriKind.Relative));
        }
    }
}
