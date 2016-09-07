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

namespace Growth.Pages.VisitPlan
{
    /// <summary>
    /// Interaction logic for Form.xaml
    /// </summary>
    public partial class Form : Page
    {
        public Form()
        {
            InitializeComponent();
            selectOutlet.ItemsSource = SQLiteDBHelper.ReadAllOutlet();
            selectOutlet.SelectedIndex = 0;
        }

        private void selectOutlet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Growth.Master.Outlet outlet = SQLiteDBHelper.ReadOutlet(int.Parse(selectOutlet.SelectedValue.ToString()));
            sales.Text = SQLiteDBHelper.ReadUser(outlet.getKode_user()).getNama();
        }
    }
}
