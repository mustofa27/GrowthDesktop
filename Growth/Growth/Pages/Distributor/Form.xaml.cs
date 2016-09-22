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
        string parameter = string.Empty;
        string state;
        public Form()
        {
            InitializeComponent();
            selectKota.ItemsSource = SQLiteDBHelper.ReadAllCityRegistered();
            state = "new";
        }
        public Form(int id)
        {
            InitializeComponent();
            selectKota.ItemsSource = SQLiteDBHelper.ReadAllCityRegistered();
            dist = SQLiteDBHelper.ReadDistributor(id);
            this.id.Text = dist.getKd_dist();
            nama.Text = dist.getNm_dist();
            alamat.Text = dist.getAlmt_dist();
            selectKota.SelectedValue = dist.getKd_kota().ToString();
            telepon.Text = dist.getTelp_dist();
            state = "edit";
        }
        public void Done(string res)
        {
            Respon respon = JsonConvert.DeserializeObject<Respon>(res);
            if (respon.status == "success")
            {
                dist.setId(respon.id);
                if (state == "new")
                {
                    SQLiteDBHelper.InsertDistributor(dist);
                    status.Text = "Create distributor sukses";
                }
                else
                {
                    SQLiteDBHelper.UpdateDistributor(dist);
                    status.Text = "Update distributor sukses";
                }
                status.Foreground = Brushes.Green;
                status.Visibility = Visibility.Visible;
            }
            else
            {
                if (state == "new")
                {
                    status.Text = "Create distributor gagal";
                }
                else
                {
                    status.Text = "Update distributor gagal";
                }
                status.Foreground = Brushes.Red;
                status.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(state == "new")
            {
                dist = new Master.Distributor(0, id.Text, "Distributor", int.Parse(selectKota.SelectedValue.ToString()), nama.Text, alamat.Text, telepon.Text);
                string json = JsonConvert.SerializeObject(dist);
                ConnectionHandler con = new ConnectionHandler(this);
                con.setDistributor(json);
            }
            else
            {
                dist.setKd_dist(id.Text);
                dist.setNm_dist(nama.Text);
                dist.setAlmt_dist(alamat.Text);
                dist.setKd_kota(int.Parse(selectKota.SelectedValue.ToString()));
                dist.setTelp_dist(telepon.Text);
                string json = JsonConvert.SerializeObject(dist);
                ConnectionHandler con = new ConnectionHandler(this);
                con.editDistributor(json);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Distributor/List.xaml", UriKind.Relative));
        }
    }
}
