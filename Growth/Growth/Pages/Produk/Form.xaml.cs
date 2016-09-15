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
        public Form()
        {
            InitializeComponent();
        }

        public void Done(string res)
        {
            Respon respon = JsonConvert.DeserializeObject<Respon>(res);
            if (respon.status == "success")
            {
                product.id = respon.id;
                SQLiteDBHelper.InsertProduct(product);
                status.Text = "Create product sukses";
                status.Foreground = Brushes.Green;
                status.Visibility = Visibility.Visible;
            }
            else
            {
                status.Text = "Create product gagal";
                status.Foreground = Brushes.Red;
                status.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            product = new Master.Product(0, id.Text, nama.Text);
            string json = JsonConvert.SerializeObject(product);
            Helper.ConnectionHandler con = new Helper.ConnectionHandler(this);
            con.setProduk(json);
        }
    }
}
