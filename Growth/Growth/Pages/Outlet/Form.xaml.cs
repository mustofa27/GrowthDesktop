﻿using Growth.Interfaces;
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
using System.IO;

namespace Growth.Pages.Outlet
{
    /// <summary>
    /// Interaction logic for Form.xaml
    /// </summary>
    public partial class Form : Page, Callback
    {
        Master.Outlet outlet;
        string path;
        public Form()
        {
            InitializeComponent();
            selectDistributor.ItemsSource = SQLiteDBHelper.ReadAllDistributor();
            selectArea.ItemsSource = SQLiteDBHelper.ReadAllArea();
            selectSF.ItemsSource = SQLiteDBHelper.ReadAllUser();
            selectTipe.ItemsSource = SQLiteDBHelper.ReadAllTipe();
        }

        public void Done(string res)
        {
            throw new NotImplementedException();
        }

        private void selectArea_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectKota.ItemsSource = SQLiteDBHelper.ReadAllCity(int.Parse(selectArea.SelectedValue.ToString()));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            dlg.Filter = "PNG Files (*.png)|*.png|JPEG Files (*.jpeg)|*.jpeg|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                path = dlg.FileName;
                dir.Text = path;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            BitmapImage bitmapImage = new BitmapImage(new Uri(path));
            string encodedImage = "";
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                encodedImage = Convert.ToBase64String(ms.ToArray());
            }
            outlet = new Master.Outlet(0, int.Parse(selectDistributor.SelectedValue.ToString()), int.Parse(selectKota.SelectedValue.ToString()),
                int.Parse(selectSF.SelectedValue.ToString()), nama.Text, alamat.Text, int.Parse(selectTipe.SelectedValue.ToString()), selectRank.SelectedValue.ToString(), telpPIC.Text,
                selectRegStatus.SelectedValue.ToString(), kodepos.Text, latitude.Text, longitude.Text, 0, encodedImage, nmPIC.Text, telpPIC.Text, (2*selectStatus.SelectedIndex+1)%3);
            
        }
    }
}
