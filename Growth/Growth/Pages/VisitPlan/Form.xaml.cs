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
using Newtonsoft.Json;
using Growth.Interfaces;

namespace Growth.Pages.VisitPlan
{
    /// <summary>
    /// Interaction logic for Form.xaml
    /// </summary>
    public partial class Form : Page,Callback
    {
        Growth.Master.VisitPlan visitplan;
        public Form()
        {
            InitializeComponent();
            selectOutlet.ItemsSource = SQLiteDBHelper.ReadAllOutlet();
            selectOutlet.SelectedIndex = 0;
        }
        private class Respon
        {
            public string status { set; get; }
            public int id { set; get; }
            public Respon(int id, string status)
            {
                this.status = status;
                this.id = id;
            }
        }
        private void selectOutlet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Growth.Master.Outlet outlet = SQLiteDBHelper.ReadOutlet(int.Parse(selectOutlet.SelectedValue.ToString()));
            sales.Text = SQLiteDBHelper.ReadUser(outlet.getKode_user()).getNama();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string date_visit = tanggal.SelectedDate.Value.Year+"-"+ tanggal.SelectedDate.Value.Month+"-"+ 
                tanggal.SelectedDate.Value.Day+" "+ tanggal.SelectedDate.Value.Hour+":"+ 
                tanggal.SelectedDate.Value.Minute+":"+ tanggal.SelectedDate.Value.Second;
            string date_create_visit = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + " " + 
                DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
            int kd_outlet = int.Parse(selectOutlet.SelectedValue.ToString());
            int approve_visit = 1;
            visitplan = new Master.VisitPlan(0, kd_outlet, date_visit, date_create_visit, approve_visit, 0, "", "", "");
            string json = JsonConvert.SerializeObject(visitplan);
            ConnectionHandler con = new ConnectionHandler(this);
            con.setVisit(json);
        }

        public void Done(string res)
        {
            Respon respon = JsonConvert.DeserializeObject<Respon>(res);
            if(respon.status == "success")
            {
                visitplan.id = respon.id;
                SQLiteDBHelper.InsertVisitPlan(visitplan);
                status.Text = "Create visit plan sukses";
                status.Foreground = Brushes.Green;
                status.Visibility = Visibility.Visible;
            }
            else
            {
                status.Text = "Create visit plan gagal";
                status.Foreground = Brushes.Red;
                status.Visibility = Visibility.Visible;
            }
        }
    }
}
