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
            DataUser dataUser = JsonConvert.DeserializeObject<DataUser>(res);
            
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
            List<Area> areas = null;
            List<Competitor> competitors = null;
            List<Distributor> distributors = null;
            List<City> cities = null;
            List<Logging> loggings = null;
            List<Outlet> outlets = null;
            List<PhotoActivity> photoacts = null;
            List<Product> products = null;
            List<TakeOrder> takeorders = null;
            List<Tipe> tipes = null;
            List<TipePhoto> tipephotos = null;
            List<User> users = null;
            List<VisitPlan> visitplans = null;
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
                        if(areas == null)
                            areas = new List<Area>();
                        else
                        {
                            areas.Add(serializer.Deserialize<Area>(reader));
                        }
                        break;
                    case "competitor":
                        if (competitors == null)
                            competitors = new List<Competitor>();
                        else
                        {
                            competitors.Add(serializer.Deserialize<Competitor>(reader));
                        }
                        break;
                    case "distributor":
                        if (distributors == null)
                            distributors = new List<Distributor>();
                        else
                        {
                            distributors.Add(serializer.Deserialize<Distributor>(reader));
                        }
                        break;
                    case "konfigurasi":
                        
                        break;
                    case "kota":
                        if (cities == null)
                            cities = new List<City>();
                        else
                        {
                            cities.Add(serializer.Deserialize<City>(reader));
                        }
                        break;
                    case "logging":
                        if (loggings == null)
                            loggings = new List<Logging>();
                        else
                        {
                            loggings.Add(serializer.Deserialize<Logging>(reader));
                        }
                        break;
                    case "outlet":
                        if (outlets == null)
                            outlets = new List<Outlet>();
                        else
                        {
                            outlets.Add(serializer.Deserialize<Outlet>(reader));
                        }
                        break;
                    case "photoact":
                        if (photoacts == null)
                            photoacts = new List<PhotoActivity>();
                        else
                        {
                            photoacts.Add(serializer.Deserialize<PhotoActivity>(reader));
                        }
                        break;
                    case "produk":
                        if (products == null)
                            products = new List<Product>();
                        else
                        {
                            products.Add(serializer.Deserialize<Product>(reader));
                        }
                        break;
                    case "takeorder":
                        if (takeorders == null)
                            takeorders = new List<TakeOrder>();
                        else
                        {
                            takeorders.Add(serializer.Deserialize<TakeOrder>(reader));
                        }
                        break;
                    case "tipe":
                        if (tipes == null)
                            tipes = new List<Tipe>();
                        else
                        {
                            tipes.Add(serializer.Deserialize<Tipe>(reader));
                        }
                        break;
                    case "tipephoto":
                        if ( tipephotos == null)
                            tipephotos = new List<TipePhoto>();
                        else
                        {
                            tipephotos.Add(serializer.Deserialize<TipePhoto>(reader));
                        }
                        break;
                    case "user":
                        if (users == null)
                            users = new List<User>();
                        else
                        {
                            users.Add(serializer.Deserialize<User>(reader));
                        }
                        break;
                    default:
                        if (visitplans == null)
                            visitplans = new List<VisitPlan>();
                        else
                        {
                            visitplans.Add(serializer.Deserialize<VisitPlan>(reader));
                        }
                        break;
                }
            }
        }
    }
}
