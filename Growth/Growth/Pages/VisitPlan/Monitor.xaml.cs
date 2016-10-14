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
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Growth.Pages.VisitPlan
{
    /// <summary>
    /// Interaction logic for Monitor.xaml
    /// </summary>
    public partial class Monitor : Page,Callback
    {
        public Monitor()
        {
            InitializeComponent();
            listVisit.ItemsSource = SQLiteDBHelper.MonitorVisitPlan();
        }
        private void Edit_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                if (vis is DataGridRow)
                {
                    var row = (DataGridRow)vis;
                    DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(row);
                    // find grid cell object for the cell with index 0
                    DataGridCell cell = presenter.ItemContainerGenerator.ContainerFromIndex(0) as DataGridCell;
                    if (cell != null)
                    {
                        //Console.WriteLine(((TextBlock)cell.Content).Text);
                        this.NavigationService.Navigate(new Form(int.Parse(((TextBlock)cell.Content).Text)));
                    }
                    break;
                }
        }

        private void Delete_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to delete this record?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                    if (vis is DataGridRow)
                    {
                        var row = (DataGridRow)vis;
                        DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(row);
                        // find grid cell object for the cell with index 0
                        DataGridCell cell = presenter.ItemContainerGenerator.ContainerFromIndex(0) as DataGridCell;
                        if (cell != null)
                        {
                            //Console.WriteLine(((TextBlock)cell.Content).Text);
                            ConnectionHandler con = new ConnectionHandler(this);
                            con.delVisit(int.Parse(((TextBlock)cell.Content).Text));
                        }
                        break;
                    }
            }
        }

        private void ImageAwesome_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void ImageAwesome_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }
        static T GetVisualChild<T>(Visual parent) where T : Visual
        {
            T child = default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = v as T;
                if (child == null) child = GetVisualChild<T>(v);
                if (child != null) break;
            }
            return child;
        }

        public void Done(string res)
        {
            Respon respon = JsonConvert.DeserializeObject<Respon>(res);
            if (respon.status == "success")
            {
                SQLiteDBHelper.DeleteVisitPlan(respon.id);
                listVisit.ItemsSource = SQLiteDBHelper.MonitorVisitPlan();
                MessageBoxResult result = MessageBox.Show("Delete data success", "Status", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Delete data failed", "Status", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
