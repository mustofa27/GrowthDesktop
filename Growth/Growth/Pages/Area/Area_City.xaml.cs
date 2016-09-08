using Growth.Helper;
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
        public Area_City()
        {
            InitializeComponent();
            listArea.ItemsSource = SQLiteDBHelper.ReadAllCity();
        }
    }
}
