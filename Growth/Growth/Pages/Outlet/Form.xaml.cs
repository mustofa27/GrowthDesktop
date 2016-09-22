using Growth.Interfaces;
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
using System.IO;
using Newtonsoft.Json;
using Growth.Pages.Pageclasses;
using Growth.Master;

namespace Growth.Pages.Outlet
{
    /// <summary>
    /// Interaction logic for Form.xaml
    /// </summary>
    public partial class Form : Page, Callback
    {
        Master.Outlet outlet;
        string path="",state;
        public Form()
        {
            InitializeComponent();
            selectDistributor.ItemsSource = SQLiteDBHelper.ReadAllDistributor();
            selectArea.ItemsSource = SQLiteDBHelper.ReadAllArea();
            selectSF.ItemsSource = SQLiteDBHelper.ReadAllUser();
            selectTipe.ItemsSource = SQLiteDBHelper.ReadAllTipe();
            state = "new";
        }
        public Form(int id)
        {
            InitializeComponent();
            selectDistributor.ItemsSource = SQLiteDBHelper.ReadAllDistributor();
            selectArea.ItemsSource = SQLiteDBHelper.ReadAllArea();
            selectSF.ItemsSource = SQLiteDBHelper.ReadAllUser();
            selectTipe.ItemsSource = SQLiteDBHelper.ReadAllTipe();
            outlet = SQLiteDBHelper.ReadOutlet(id);
            City kota = SQLiteDBHelper.ReadCity(outlet.kd_kota);
            selectDistributor.SelectedValue = outlet.kd_dist.ToString();
            selectArea.SelectedValue = kota.kd_area.ToString();
            selectKota.SelectedValue = kota.id.ToString();
            selectSF.SelectedValue = outlet.kd_user;
            nama.Text = outlet.nm_outlet;
            alamat.Text = outlet.almt_outlet;
            kodepos.Text = outlet.kodepos;
            selectTipe.SelectedValue = outlet.kd_tipe;
            nmPIC.Text = outlet.nm_pic;
            telpPIC.Text = outlet.tlp_pic;
            switch (outlet.rank_outlet)
            {
                case "A":
                    selectRank.SelectedIndex = 0;
                    break;
                case "B":
                    selectRank.SelectedIndex = 1;
                    break;
                case "C":
                    selectRank.SelectedIndex = 2;
                    break;
                case "D":
                    selectRank.SelectedIndex = 3;
                    break;
                case "E":
                    selectRank.SelectedIndex = 4;
                    break;
                case "F":
                    selectRank.SelectedIndex = 5;
                    break;
            }
            switch (outlet.reg_status)
            {
                case "YES":
                    selectRank.SelectedIndex = 0;
                    break;
                case "NO":
                    selectRank.SelectedIndex = 1;
                    break;
            }
            selectStatus.SelectedIndex = (int)Math.Pow(0, outlet.status_area);
            latitude.Text = outlet.latitude;
            longitude.Text = outlet.longitude;
            dir.Text = outlet.foto_outlet;
            state = "edit";
        }
        public void Done(string res)
        {
            ResponOutlet respon = JsonConvert.DeserializeObject<ResponOutlet>(res);
            if (respon.status == "success")
            {
                outlet.kd_outlet = respon.id;
                outlet.toleransi_long = respon.toleransi;
                outlet.foto_outlet = respon.foto;
                if (state == "new")
                {
                    SQLiteDBHelper.InsertOutlet(outlet);
                    status.Text = "Create outlet sukses";
                }
                else
                {
                    SQLiteDBHelper.UpdateOutlet(outlet);
                    status.Text = "Update outlet sukses";
                }
                status.Foreground = Brushes.Green;
                status.Visibility = Visibility.Visible;
            }
            else
            {
                if (state == "new")
                {
                    status.Text = "Create outlet gagal";
                }
                else
                {
                    status.Text = "Update outlet gagal";
                }
                status.Foreground = Brushes.Red;
                status.Visibility = Visibility.Visible;
            }
        }

        private void selectArea_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(state == "new")
                selectKota.ItemsSource = SQLiteDBHelper.ReadAllCity(int.Parse(selectArea.SelectedValue.ToString()));
            else
            {
                City kota = SQLiteDBHelper.ReadCity(outlet.kd_kota);
                selectKota.ItemsSource = SQLiteDBHelper.ReadAllCity(kota.kd_area);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            dlg.Filter = "PNG Files (*.png)|*.png|JPEG Files (*.jpeg)|*.jpeg|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                path = dlg.FileName;
                dir.Text = path;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (state == "new")
            {
                BitmapImage bitmapImage = new BitmapImage(new Uri(path));
                string encodedImage = "";
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
                using (MemoryStream ms = new MemoryStream())
                {
                    encoder.Save(ms);
                    encodedImage = Convert.ToBase64String(ms.ToArray());
                }
                outlet = new Master.Outlet(0, int.Parse(selectDistributor.SelectedValue.ToString()), int.Parse(selectKota.SelectedValue.ToString()),
                    int.Parse(selectSF.SelectedValue.ToString()), nama.Text, alamat.Text, int.Parse(selectTipe.SelectedValue.ToString()), selectRank.Text, telpPIC.Text,
                    selectRegStatus.Text, kodepos.Text, latitude.Text, longitude.Text, 0, encodedImage, nmPIC.Text, telpPIC.Text, (2 * selectStatus.SelectedIndex + 1) % 3);
                string json = JsonConvert.SerializeObject(outlet);
                ConnectionHandler con = new ConnectionHandler(this);
                con.setOutlet(json);
            }
            else
            {
                string encodedImage = "";
                if (path != "")
                {
                    BitmapImage bitmapImage = new BitmapImage(new Uri(path));
                    JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
                    using (MemoryStream ms = new MemoryStream())
                    {
                        encoder.Save(ms);
                        encodedImage = Convert.ToBase64String(ms.ToArray());
                    }
                    outlet.foto_outlet = encodedImage;
                }
                outlet.kd_dist = int.Parse(selectDistributor.SelectedValue.ToString());
                outlet.kd_kota = int.Parse(selectKota.SelectedValue.ToString());
                outlet.kd_user = int.Parse(selectSF.SelectedValue.ToString());
                outlet.nm_outlet = nama.Text;
                outlet.almt_outlet = alamat.Text;
                outlet.kodepos = kodepos.Text;
                outlet.kd_tipe = int.Parse(selectTipe.SelectedValue.ToString());
                outlet.nm_pic = nmPIC.Text;
                outlet.tlp_pic = telpPIC.Text;
                outlet.rank_outlet = selectRank.Text;
                outlet.reg_status = selectRegStatus.Text;
                outlet.status_area = (2 * selectStatus.SelectedIndex + 1) % 3;
                outlet.latitude = latitude.Text;
                outlet.longitude = longitude.Text;
                string json = JsonConvert.SerializeObject(outlet);
                ConnectionHandler con = new ConnectionHandler(this);
                con.editOutlet(json);
            }
        }
    }
}