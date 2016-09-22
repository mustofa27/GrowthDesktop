using Growth.Interfaces;
using Growth.Master;
using Growth.Pages.Pageclasses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Growth.Pages.Outlet
{
    /// <summary>
    /// Interaction logic for View.xaml
    /// </summary>
    public partial class View : Page,Callback
    {
        Master.Outlet outlet;
        public View(int id)
        {
            InitializeComponent();
            Helper.ConnectionHandler con = new Helper.ConnectionHandler(this);
            outlet = Helper.SQLiteDBHelper.ReadOutlet(id);
            con.getFoto(outlet.kd_outlet);
            nama.Text = outlet.nm_outlet;
            user.Text = Helper.SQLiteDBHelper.ReadUser(outlet.kd_user).nama;
            kd_outlet.Text = outlet.kd_outlet.ToString();
            City kota = Helper.SQLiteDBHelper.ReadCity(outlet.kd_kota);
            area.Text = Helper.SQLiteDBHelper.ReadArea(kota.kd_area).nm_area;
            alamat.Text = outlet.almt_outlet;
            this.kota.Text = kota.nm_kota;
            kodepos.Text = outlet.kodepos;
            distributor.Text = Helper.SQLiteDBHelper.ReadDistributor(outlet.kd_dist).Nm_dist;
            nm_pic.Text = outlet.nm_pic;
            tlp_pic.Text = outlet.tlp_pic;
            tipe.Text = Helper.SQLiteDBHelper.ReadTipe(outlet.kd_tipe).nm_tipe;
            rank.Text = outlet.rank_outlet;
            longitude.Text = outlet.longitude;
            latitude.Text = outlet.latitude;
            toleransi.Text = outlet.toleransi_long.ToString() + " Meter";
            status.Text = outlet.status_area == 1 ? "Good Coverage" : "Bad Coverage";
        }

        public void Done(string res)
        {
            ResponFoto respon = JsonConvert.DeserializeObject<ResponFoto>(res);
            if (respon.status == "success")
            {
                byte[] binaryData = Convert.FromBase64String(respon.foto);

                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = new MemoryStream(binaryData);
                bi.EndInit();
                foto.Source = bi;
            }
            loading.Visibility = Visibility.Collapsed;
        }
    }
}
