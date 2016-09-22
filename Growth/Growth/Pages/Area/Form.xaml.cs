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

namespace Growth.Pages.Area
{
    /// <summary>
    /// Interaction logic for Form.xaml
    /// </summary>
    public partial class Form : Page,Callback
    {
        Master.Area area;
        public Form()
        {
            InitializeComponent();
        }

        public void Done(string res)
        {
            Respon respon = JsonConvert.DeserializeObject<Respon>(res);
            if (respon.status == "success")
            {
                area.id = respon.id;
                SQLiteDBHelper.InsertArea(area);
                status.Text = "Create area sukses";
                status.Foreground = Brushes.Green;
                status.Visibility = Visibility.Visible;
            }
            else
            {
                status.Text = "Create area gagal";
                status.Foreground = Brushes.Red;
                status.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            area = new Master.Area(0, kode.Text, nama.Text);
            string json = JsonConvert.SerializeObject(area);
            Helper.ConnectionHandler con = new Helper.ConnectionHandler(this);
            con.setArea(json);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Area/Area.xaml", UriKind.Relative));
        }
    }
}
