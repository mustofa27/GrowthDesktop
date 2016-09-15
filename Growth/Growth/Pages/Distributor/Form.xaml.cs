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
using Growth.Master;
using Growth.Interfaces;
using Newtonsoft.Json;
using Growth.Pages.Pageclasses;

namespace Growth.Pages.Distributor
{
    /// <summary>
    /// Interaction logic for Form.xaml
    /// </summary>
    public partial class Form : Page, Callback
    {
        Master.Distributor dist;
        public Form()
        {
            InitializeComponent();
            selectKota.ItemsSource = SQLiteDBHelper.ReadAllCityRegistered();
        }

        public void Done(string res)
        {
            Respon respon = JsonConvert.DeserializeObject<Respon>(res);
            if (respon.status == "success")
            {
                dist.setId(respon.id);
                SQLiteDBHelper.InsertDistributor(dist);
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
            dist = new Master.Distributor(0, id.Text, "Distributor", int.Parse(selectKota.SelectedValue.ToString()), nama.Text, alamat.Text, telepon.Text);
            string json = JsonConvert.SerializeObject(dist);
            ConnectionHandler con = new ConnectionHandler(this);
            con.setDistributor(json);
        }
    }
}
