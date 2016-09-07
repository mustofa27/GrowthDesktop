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
using Newtonsoft.Json;
using System.IO;
using Growth.Master;

namespace Growth
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,Callback
    {
        public MainWindow()
        {
            //MessageBoxResult result = MessageBox.Show("Do you want to close this window?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            //if (result == MessageBoxResult.Yes)
            //{
            //    Application.Current.Shutdown();
            //}
            InitializeComponent();
            if (!SQLiteDBHelper.checkDB())
            {
                ConnectionHandler con = new ConnectionHandler(this);
                con.getAllData();
                loading.Visibility = Visibility.Visible;
            }
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

        private void distributor_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Uri("/Pages/Distributor/Index.xaml", UriKind.Relative));
        }

        private void produk_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Uri("/Pages/Produk/Index.xaml", UriKind.Relative));
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Uri("/Pages/VisitPlan/Form.xaml", UriKind.Relative));
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Uri("/Pages/VisitPlan/List.xaml", UriKind.Relative));
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Uri("/Pages/VisitPlan/Monitor.xaml", UriKind.Relative));
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Uri("/Pages/VisitPlan/TakeOrderList.xaml", UriKind.Relative));
        }

        public void Done(string res)
        {
            DataUser dataUser = JsonConvert.DeserializeObject<DataUser>(res);
            InsertToDB(dataUser.area);
            InsertToDB(dataUser.competitor);
            InsertToDB(dataUser.distributor);
            //InsertToDB(dataUser.konfigurasi);
            InsertToDB(dataUser.kota);
            InsertToDB(dataUser.logging);
            InsertToDB(dataUser.outlet);
            InsertToDB(dataUser.photoactivity);
            InsertToDB(dataUser.produk);
            InsertToDB(dataUser.takeorder);
            InsertToDB(dataUser.tipe);
            InsertToDB(dataUser.tipe_photo);
            InsertToDB(dataUser.user);
            InsertToDB(dataUser.visitplan);
            loading.Visibility = Visibility.Collapsed;
        }
        private class DataUser
        {
            public List<Area> area { get; set; }
            public List<Competitor> competitor { get; set; }
            public List<Distributor> distributor { get; set; }
            //public string konfigurasi { get; set; }
            public List<City> kota { get; set; }
            public List<Logging> logging { get; set; }
            public List<Outlet> outlet { get; set; }
            public List<PhotoActivity> photoactivity { get; set; }
            public List<Product> produk { get; set; }
            public List<TakeOrder> takeorder { get; set; }
            public List<Tipe> tipe { get; set; }
            public List<TipePhoto> tipe_photo { get; set; }
            public List<User> user { get; set; }
            public List<VisitPlan> visitplan { get; set; }
        }
        private void InsertToDB(List<Area> area)
        {
            if(area != null)
                foreach (Area item in area)
                {
                    SQLiteDBHelper.InsertArea(item);
                }
        }
        private void InsertToDB(List<Competitor> competitor)
        {
            if (competitor != null)
                foreach (Competitor item in competitor)
                {
                    SQLiteDBHelper.InsertCompetitor(item);
                }
        }
        private void InsertToDB(List<Distributor> distributor)
        {
            if (distributor != null)
                foreach (Distributor item in distributor)
                {
                    SQLiteDBHelper.InsertDistributor(item);
                }
        }
        private void InsertToDB(string konfigurasi)
        {
            SQLiteDBHelper.InsertKonfigurasi(int.Parse(konfigurasi));
        }
        private void InsertToDB(List<City> kota)
        {
            if (kota != null)
                foreach (City item in kota)
                {
                    SQLiteDBHelper.InsertCity(item);
                }
        }
        private void InsertToDB(List<Logging> logging)
        {
            if (logging != null)
                foreach (Logging item in logging)
                {
                    SQLiteDBHelper.InsertLogging(item);
                }
        }
        private void InsertToDB(List<Outlet> outlet)
        {
            if (outlet != null)
                foreach (Outlet item in outlet)
                {
                    SQLiteDBHelper.InsertOutlet(item);
                }
        }
        private void InsertToDB(List<PhotoActivity> photoact)
        {
            if (photoact != null)
                foreach (PhotoActivity item in photoact)
                {
                    SQLiteDBHelper.InsertPhotoActivity(item);
                }
        }
        private void InsertToDB(List<Product> produk)
        {
            if (produk != null)
                foreach (Product item in produk)
                {
                    SQLiteDBHelper.InsertProduct(item);
                }
        }
        private void InsertToDB(List<TakeOrder> takeorder)
        {
            if (takeorder != null)
                foreach (TakeOrder item in takeorder)
                {
                    SQLiteDBHelper.InsertTakeOrder(item);
                }
        }
        private void InsertToDB(List<Tipe> tipe)
        {
            if (tipe != null)
                foreach (Tipe item in tipe)
                {
                    SQLiteDBHelper.InsertTipe(item);
                }
        }
        private void InsertToDB(List<TipePhoto> tipephoto)
        {
            if (tipephoto != null)
                foreach (TipePhoto item in tipephoto)
                {
                    SQLiteDBHelper.InsertTipePhoto(item);
                }
        }
        private void InsertToDB(List<User> user)
        {
            if (user != null)
                foreach (User item in user)
                {
                    SQLiteDBHelper.InsertUser(item);
                }
        }
        private void InsertToDB(List<VisitPlan> visitplan)
        {
            if (visitplan != null)
                foreach (VisitPlan item in visitplan)
                {
                    SQLiteDBHelper.InsertVisitPlan(item);
                }
        }
    }
}
