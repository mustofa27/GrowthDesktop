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
using Growth.Interfaces;
using Growth.Pages.Pageclasses;
using Newtonsoft.Json;

namespace Growth.Pages
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page,Callback
    {
        private class Top
        {
            public List<TopSales> top { set; get; }
            public Top(List<TopSales> top)
            {
                this.top = top;
            }
        }
        public Dashboard()
        {
            ConnectionHandler con = new ConnectionHandler(this);
            con.getTop();
            InitializeComponent();
        }

        public void Done(string res)
        {
            Top topSales = JsonConvert.DeserializeObject<Top>(res);
            int i = 1;
            foreach (TopSales item in topSales.top)
            {
                item.Urut = i++;
            }
            listSales.ItemsSource = topSales.top;
        }
    }
}
