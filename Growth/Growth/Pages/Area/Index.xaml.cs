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
            //SQLiteDBHelper.InsertProduct(new Product(1, "desc 1", "testing1"));
            //SQLiteDBHelper.InsertProduct(new Product(2, "desc 2", "testing1"));
            //SQLiteDBHelper.InsertPhotoActivity(new PhotoActivity(1, 1, 1, 1, 1, "outlet1", "sby", "A", "08977907097", "sukses", "0.912594"));
            //SQLiteDBHelper.InsertPhotoActivity(new PhotoActivity(2, 1, 1, 1, 1, "outlet2", "sby", "A", "08977907097", "sukses", "0.912594"));
        }

        public void Done(string res)
        {
            test.Text = res;
        }

        private void testing_Click(object sender, RoutedEventArgs e)
        {
            //ConnectionHelper.DownloadPageAsync("http://demo.growth.co.id/login/keira/asd",this);
            //ConnectionHelper.PostToPage("http://demo.growth.co.id/setIdGCM", this);
            //Master.Product city = SQLiteDBHelper.ReadProduct(1);
            //city.setNm_produk("edit baru");
            //SQLiteDBHelper.UpdateProduct(city);
            //test.Text = SQLiteDBHelper.ReadProduct(1).getNm_produk();
            List<Product> cities = SQLiteDBHelper.ReadAllProduct();
            foreach (var city in cities)
            {
                test.Text += ' ' + city.getNm_produk();
            }
            //Test foo = new Test(1, "desc 1", "testing1");
            //test.Text = "";
            //foreach (var prop in foo.GetType().GetProperties())
            //{
            //    test.Text += prop.Name.ToString() + " " + prop.PropertyType.ToString() + "  " + prop.GetValue(foo, null).ToString() + "\n";
            //}
        }
    }
}
