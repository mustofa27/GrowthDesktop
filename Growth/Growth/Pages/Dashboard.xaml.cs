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
using Growth.Master;
using Growth.Helper;
using System.Collections.ObjectModel;

namespace Growth.Pages
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        private class Sales
        {
            public string Name { set; get; }
            public string Area { set; get; }
            public int TotalVisit { set; get; }
            public int EffectiveCall { set; get; }
            public Sales(string nama, string area, int total, int effect)
            {
                Name = nama;
                Area = area;
                TotalVisit = total;
                EffectiveCall = effect;
            }
        }
        public Dashboard()
        {
            InitializeComponent();
            //List<Sales> sales = new List<Sales>();
            //sales.Add(new Sales("ahmad", "sumenep", 10, 5));
            //sales.Add(new Sales("mustofa", "sumenep", 7, 3));
            listSales.ItemsSource = SQLiteDBHelper.ReadAllVisitPlan();
        }
    }
}
