using Growth.Helper;
using Growth.Interfaces;
using Growth.Master;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Growth
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window,Callback
    {
        [DllImport("user32.dll")]

        static extern int GetWindowLong(IntPtr hwnd, int index);



        [DllImport("user32.dll")]

        static extern int SetWindowLong(IntPtr hwnd, int index, int newStyle);



        [DllImport("user32.dll")]

        static extern bool SetWindowPos(IntPtr hwnd, IntPtr hwndInsertAfter, int x, int y, int width, int height, uint flags);



        [DllImport("user32.dll")]

        static extern IntPtr SendMessage(IntPtr hwnd, uint msg, IntPtr wParam, IntPtr lParam);



        const int GWL_EXSTYLE = -20;

        const int WS_EX_DLGMODALFRAME = 0x0001;



        const int SWP_NOSIZE = 0x0001;

        const int SWP_NOMOVE = 0x0002;

        const int SWP_NOZORDER = 0x0004;

        const int SWP_FRAMECHANGED = 0x0020;



        const uint WM_SETICON = 0x0080;
        public Login()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }
        protected override void OnSourceInitialized(EventArgs e)

        {

            base.OnSourceInitialized(e);

 

            // Get this window’s handle

            IntPtr hwnd = new WindowInteropHelper(this).Handle;

 

            // Change the extended window style to not show a window icon

            int extendedStyle = GetWindowLong(hwnd, GWL_EXSTYLE);

            SetWindowLong(hwnd, GWL_EXSTYLE, extendedStyle | WS_EX_DLGMODALFRAME);

 

            // Update the window’s non-client area to reflect the changes

            SetWindowPos(hwnd, IntPtr.Zero, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOZORDER | SWP_FRAMECHANGED);

        }

        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void TextBlock_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ConnectionHandler con = new ConnectionHandler(this);
            con.authUser(username.Text, password.Password);
        }

        public void Done(string res)
        {
            DataUser dataUser = JsonConvert.DeserializeObject<DataUser>(res);
            if(dataUser.status == "success")
            {
                SQLiteDBHelper.InsertLoginUser(dataUser.user);
                MainWindow win2 = new MainWindow();
                win2.Show();
                this.Close();
            }
            else
            {
                if (dataUser.status == "not found")
                {
                    MessageBoxResult result = MessageBox.Show("Wrong account, please try again", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Wrong password, please try again", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        private class DataUser
        {
            public string status { set; get; }
            public User  user { set; get; }
        }
    }
}
