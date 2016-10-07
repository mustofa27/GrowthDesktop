using Growth.Helper;
using Growth.Interfaces;
using Growth.Pages.Pageclasses;
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
    /// Interaction logic for ForgotPassword.xaml
    /// </summary>
    public partial class ForgotPassword : Window,Callback
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
        public ForgotPassword()
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            toLogin();
        }
        private void toLogin()
        {
            Login win2 = new Login();
            win2.Show();
            this.Close();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(isNotNull(email)&& isNotNull(nik)&& isNotNull(phone))
            {
                //change pass;
                ConnectionHandler con = new ConnectionHandler(this);
                con.changePassword(email.Text,nik.Text,phone.Text);
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("You must fill all field", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private bool isNotNull(TextBox txt)
        {
            return txt != null && !string.IsNullOrWhiteSpace(txt.Text);
        }

        public void Done(string res)
        {
            Respon respon = JsonConvert.DeserializeObject<Respon>(res);
            if (respon.status == "success")
            {
                MessageBoxResult result = MessageBox.Show("Password has been changed. Please check your email.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                if(result == MessageBoxResult.OK)
                {
                    toLogin();
                }
            }
            else
            {
                if (respon.status == "not found")
                {
                    MessageBoxResult result = MessageBox.Show("Wrong credential, please try again", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}
