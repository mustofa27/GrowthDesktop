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
    /// Interaction logic for Area_City.xaml
    /// </summary>
    public partial class Area_City : Page
    {
        private class Area_City_Helper
        {
            public string Kode_area { set; get; }
            public string Nama_area { set; get; }
            public string Nama_kota { set; get; }
            public Area_City_Helper(string kode, string nama_area, string nama)
            {
                Kode_area = kode;
                Nama_area = nama_area;
                Nama_kota = nama;
            }
        }
        public Area_City()
        {
            InitializeComponent();
            List<Area_City_Helper> tmp = new List<Area_City_Helper>();
            tmp.Add(new Area_City_Helper("EJ1", "Jawa Timur", "Surabaya"));
            tmp.Add(new Area_City_Helper("EJ2", "Jawa Timur", "Magetan"));
            tmp.Add(new Area_City_Helper("WJ", "Jawa Barat", "Bandung"));
            tmp.Add(new Area_City_Helper("MJ", "Jawa Tengah", "Solo"));
            listArea.ItemsSource = tmp;
        }
    }
}
