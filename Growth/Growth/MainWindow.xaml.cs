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
            if(!SQLiteDBHelper.checkDB())
            {
                ConnectionHandler con = new ConnectionHandler(this);
                con.getAllData();
            }
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
            int i = 0;
            DataUser dataUser = JsonConvert.DeserializeObject<DataUser>(res);
            InsertToDB("area", dataUser.Area);
            InsertToDB("competitor", dataUser.Competitor);
            InsertToDB("distributor", dataUser.Distributor);
            InsertToDB("konfigurasi", dataUser.Konfigurasi);
            InsertToDB("kota", dataUser.Kota);
            InsertToDB("logging", dataUser.Logging);
            InsertToDB("outlet", dataUser.Outlet);
            InsertToDB("photoact", dataUser.PhotoActivity);
            InsertToDB("produk", dataUser.Produk);
            InsertToDB("takeorder", dataUser.TakeOrder);
            InsertToDB("tipe", dataUser.Tipe);
            InsertToDB("tipephoto", dataUser.TipePhoto);
            InsertToDB("user", dataUser.User);
            InsertToDB("visitplan", dataUser.VisitPlan);

        }
        private class DataUser
        {
            public string Area { get; set; }
            public string Competitor { get; set; }
            public string Distributor { get; set; }
            public string Konfigurasi { get; set; }
            public string Kota { get; set; }
            public string Logging { get; set; }
            public string Outlet { get; set; }
            public string PhotoActivity { get; set; }
            public string Produk { get; set; }
            public string TakeOrder { get; set; }
            public string Tipe { get; set; }
            public string TipePhoto { get; set; }
            public string User { get; set; }
            public string VisitPlan { get; set; }
        }
        private void InsertToDB(string tipe,string json)
        {
            JsonTextReader reader = new JsonTextReader(new StringReader(json));
            reader.SupportMultipleContent = true;
            while (true)
            {
                if (!reader.Read())
                    {
                        break;
                    }
                
                JsonSerializer serializer = new JsonSerializer();
                switch (tipe)
                {
                    case "area":
                        SQLiteDBHelper.InsertArea(serializer.Deserialize<Area>(reader));
                        break;
                    case "competitor":
                        SQLiteDBHelper.InsertCompetitor(serializer.Deserialize<Competitor>(reader));
                        break;
                    case "distributor":
                        SQLiteDBHelper.InsertDistributor(serializer.Deserialize<Distributor>(reader));
                        break;
                    case "konfigurasi":
                        SQLiteDBHelper.InsertKonfigurasi(int.Parse(reader.Value.ToString()));
                        break;
                    case "kota":
                        SQLiteDBHelper.InsertCity(serializer.Deserialize<City>(reader));
                        break;
                    case "logging":
                        SQLiteDBHelper.InsertLogging(serializer.Deserialize<Logging>(reader));
                        break;
                    case "outlet":
                        SQLiteDBHelper.InsertOutlet(serializer.Deserialize<Outlet>(reader));
                        break;
                    case "photoact":
                        SQLiteDBHelper.InsertPhotoActivity(serializer.Deserialize<PhotoActivity>(reader));
                        break;
                    case "produk":
                        SQLiteDBHelper.InsertProduct(serializer.Deserialize<Product>(reader));
                        break;
                    case "takeorder":
                        SQLiteDBHelper.InsertTakeOrder(serializer.Deserialize<TakeOrder>(reader));
                        break;
                    case "tipe":
                        SQLiteDBHelper.InsertTipe(serializer.Deserialize<Tipe>(reader));
                        break;
                    case "tipephoto":
                        SQLiteDBHelper.InsertTipePhoto(serializer.Deserialize<TipePhoto>(reader));
                        break;
                    case "user":
                        SQLiteDBHelper.InsertUser(serializer.Deserialize<User>(reader));
                        break;
                    default:
                        SQLiteDBHelper.InsertVisitPlan(serializer.Deserialize<VisitPlan>(reader));
                        break;
                }
            }
        }
    }
}
