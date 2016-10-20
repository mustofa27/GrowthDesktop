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
using Growth.Pages.Pageclasses;

namespace Growth.Pages.VisitPlan
{
    /// <summary>
    /// Interaction logic for Form.xaml
    /// </summary>
    public partial class Form : Page,Callback
    {
        Growth.Master.VisitPlan visitplan;
        string state,jenis;
        public Form()
        {
            InitializeComponent();
            selectOutlet.ItemsSource = SQLiteDBHelper.ReadAllOutlet();
            selectOutlet.SelectedIndex = 0;
            state = "new";
            statusVisit.Visibility = Visibility.Collapsed;
            tanggalVisit.Visibility = Visibility.Collapsed;
            skipVisit.Visibility = Visibility.Collapsed;
            statusApproval.Visibility = Visibility.Collapsed;
        }
        public Form(int id,string jenis)
        {
            InitializeComponent();
            selectOutlet.ItemsSource = SQLiteDBHelper.ReadAllOutlet();
            visitplan = SQLiteDBHelper.ReadVisitPlan(id);
            selectOutlet.Text = SQLiteDBHelper.ReadOutlet(visitplan.kd_outlet).nm_outlet;
            DateTime dt = Convert.ToDateTime(visitplan.date_visit);
            tanggal.SelectedDate = dt;
            state = "edit";
            this.jenis = jenis;
            if (jenis.Equals("list"))
            {
                selectStatusApproval.Text = visitplan.approve_visit == 1 ? "YES" : "NO";
                statusVisit.Visibility = Visibility.Collapsed;
                tanggalVisit.Visibility = Visibility.Collapsed;
                skipVisit.Visibility = Visibility.Collapsed;
            }
            else if (jenis.Equals("monitor"))
            {
                selectStatusVisit.Text = visitplan.status_visit == 1 ? "YES" : "NO";
                if (visitplan.date_visiting != "0000-00-00 00:00:00" && visitplan.date_visiting != "")
                {
                    DateTime dt1 = Convert.ToDateTime(visitplan.date_visiting);
                    tanggalVisiting.SelectedDate = dt1;
                }
                skipReason.Text = visitplan.skip_reason;
                statusApproval.Visibility = Visibility.Collapsed;
            }
        }
        private void selectOutlet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Growth.Master.Outlet outlet = SQLiteDBHelper.ReadOutlet(int.Parse(selectOutlet.SelectedValue.ToString()));
            sales.Text = SQLiteDBHelper.ReadUser(outlet.getKode_user()).getNama();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string bulan = tanggal.SelectedDate.Value.Month < 10 ? "0" + tanggal.SelectedDate.Value.Month.ToString() : tanggal.SelectedDate.Value.Month.ToString();
            string tgl = tanggal.SelectedDate.Value.Day < 10 ? "0" + tanggal.SelectedDate.Value.Day.ToString() : tanggal.SelectedDate.Value.Day.ToString();
            string jam = tanggal.SelectedDate.Value.Hour < 10 ? "0" + tanggal.SelectedDate.Value.Hour.ToString() : tanggal.SelectedDate.Value.Hour.ToString();
            string menit = tanggal.SelectedDate.Value.Minute < 10 ? "0" + tanggal.SelectedDate.Value.Minute.ToString() : tanggal.SelectedDate.Value.Minute.ToString();
            string detik = tanggal.SelectedDate.Value.Second < 10 ? "0" + tanggal.SelectedDate.Value.Second.ToString() : tanggal.SelectedDate.Value.Second.ToString();
            string date_visit = tanggal.SelectedDate.Value.Year + "-" + bulan + "-" + tgl + " " +
                jam + ":" + menit + ":" + detik;
            if (state.Equals("new"))
            {
                bulan = DateTime.Now.Month < 10 ? "0" + DateTime.Now.Month.ToString() : DateTime.Now.Month.ToString();
                tgl = DateTime.Now.Day < 10 ? "0" + DateTime.Now.Day.ToString() : DateTime.Now.Day.ToString();
                jam = DateTime.Now.Hour < 10 ? "0" + DateTime.Now.Hour.ToString() : DateTime.Now.Hour.ToString();
                menit = DateTime.Now.Minute < 10 ? "0" + DateTime.Now.Minute.ToString() : DateTime.Now.Minute.ToString();
                detik = DateTime.Now.Second < 10 ? "0" + DateTime.Now.Second.ToString() : DateTime.Now.Second.ToString();
                string date_create_visit = DateTime.Now.Year + "-" + bulan + "-" + tgl + " " +
                    jam + ":" + menit + ":" + detik;
                int kd_outlet = int.Parse(selectOutlet.SelectedValue.ToString());
                int approve_visit = 1;
                visitplan = new Master.VisitPlan(0, kd_outlet, date_visit, date_create_visit, approve_visit, 0, "", "", "");
                string json = JsonConvert.SerializeObject(visitplan);
                ConnectionHandler con = new ConnectionHandler(this);
                con.setVisit(json);
            }
            else
            {
                visitplan.date_visit = date_visit;
                visitplan.kd_outlet = int.Parse(selectOutlet.SelectedValue.ToString());
                if (jenis.Equals("list"))
                {
                    visitplan.approve_visit = selectStatusApproval.Text == "YES" ? 1 : 0;
                    string json = JsonConvert.SerializeObject(visitplan);
                    ConnectionHandler con = new ConnectionHandler(this);
                    con.editVisit(json);
                }
                else if (jenis.Equals("monitor"))
                {
                    visitplan.status_visit = selectStatusVisit.Text == "YES" ? 1 : 0;
                    if (selectStatusVisit.Text == "YES")
                    {
                        bulan = tanggalVisiting.SelectedDate.Value.Month < 10 ? "0" + tanggalVisiting.SelectedDate.Value.Month.ToString() : tanggalVisiting.SelectedDate.Value.Month.ToString();
                        tgl = tanggalVisiting.SelectedDate.Value.Day < 10 ? "0" + tanggalVisiting.SelectedDate.Value.Day.ToString() : tanggalVisiting.SelectedDate.Value.Day.ToString();
                        jam = tanggalVisiting.SelectedDate.Value.Hour < 10 ? "0" + tanggalVisiting.SelectedDate.Value.Hour.ToString() : tanggalVisiting.SelectedDate.Value.Hour.ToString();
                        menit = tanggalVisiting.SelectedDate.Value.Minute < 10 ? "0" + tanggalVisiting.SelectedDate.Value.Minute.ToString() : tanggalVisiting.SelectedDate.Value.Minute.ToString();
                        detik = tanggalVisiting.SelectedDate.Value.Second < 10 ? "0" + tanggalVisiting.SelectedDate.Value.Second.ToString() : tanggalVisiting.SelectedDate.Value.Second.ToString();
                        visitplan.date_visiting = tanggalVisiting.SelectedDate.Value.Year + "-" + bulan + "-" + tgl + " " +
                              jam + ":" + menit + ":" + detik;
                    }
                    visitplan.skip_reason = skipReason.Text;
                    string json = JsonConvert.SerializeObject(visitplan);
                    ConnectionHandler con = new ConnectionHandler(this);
                    con.editVisit(json);
                }
            }
        }

        public void Done(string res)
        {
            Respon respon = JsonConvert.DeserializeObject<Respon>(res);
            if(respon.status == "success")
            {
                if(state.Equals("new"))
                {
                    visitplan.id = respon.id;
                    SQLiteDBHelper.InsertVisitPlan(visitplan);
                    status.Text = "Create visit plan sukses";
                    status.Foreground = Brushes.Green;
                    status.Visibility = Visibility.Visible;
                }
                else
                {
                    SQLiteDBHelper.UpdateVisitPlan(visitplan);
                    status.Text = "Update visit plan sukses";
                    status.Foreground = Brushes.Green;
                    status.Visibility = Visibility.Visible;
                }
            }
            else
            {
                if (state.Equals("new"))
                    status.Text = "Create visit plan gagal";
                else
                    status.Text = "Update visit plan gagal";
                status.Foreground = Brushes.Red;
                status.Visibility = Visibility.Visible;
            }
        }
    }
}
