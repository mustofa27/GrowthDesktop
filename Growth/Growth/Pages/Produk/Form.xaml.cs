using Growth.Helper;
using Growth.Interfaces;
using Growth.Pages.Pageclasses;
using Newtonsoft.Json;
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

namespace Growth.Pages.Produk
{
    /// <summary>
    /// Interaction logic for Form.xaml
    /// </summary>
    public partial class Form : Page, Callback
    {
        Master.Product product;
        string state;
        public Form()
        {
            InitializeComponent();
            state = "new";
        }
        public Form(int id)
        {
            InitializeComponent();
            product = SQLiteDBHelper.ReadProduct(id);
            this.id.Text = product.kd_produk;
            nama.Text = product.nm_produk;
            state = "edit";
        }

        public void Done(string res)
        {
            Respon respon = JsonConvert.DeserializeObject<Respon>(res);
            if (respon.status == "success")
            {
                product.id = respon.id;
                if(state == "new")
                    SQLiteDBHelper.InsertProduct(product);
                else
                    SQLiteDBHelper.UpdateProduct(product);
                status.Text = state == "new" ? "Create product sukses" : "Update product sukses";
                status.Foreground = Brushes.Green;
                status.Visibility = Visibility.Visible;
            }
            else
            {
                status.Text = state == "new" ? "Create product gagal" : "Update product gagal";
                status.Foreground = Brushes.Red;
                status.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (state == "new")
            {
                product = new Master.Product(0, id.Text, nama.Text);
                string json = JsonConvert.SerializeObject(product);
                ConnectionHandler con = new ConnectionHandler(this);
                con.setProduk(json);
            }
            else
            {
                product.kd_produk = id.Text;
                product.nm_produk = nama.Text;
                string json = JsonConvert.SerializeObject(product);
                ConnectionHandler con = new ConnectionHandler(this);
                con.editProduk(json);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Produk/List.xaml", UriKind.Relative));
        }
    }
}
