using Login.Views;
using Login.WindowView;
using Microsoft.VisualStudio.Settings;
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
using System.Windows.Shapes;

namespace Login
{
    /// <summary>
    /// Interaction logic for Home3.xaml
    /// </summary>
    public partial class Home3 : Window
    {
        string id = "";
        public Home3(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void MenuItem_NhanVien_Click(object sender, RoutedEventArgs e)
        {
            //contentControl.Content = new EmployeeView();
        }

        private void MenuItem_KhachHangf_Click(object sender, RoutedEventArgs e)
        {
            //contentControl.Content = new CustomerView();
        }

        private void MenuItem_TongQuan_Click(object sender, RoutedEventArgs e)
        {
            //contentControl.Content = new Dashboarch();
        }

        private void MenuItem_DangXuat_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void MenuItem_Thoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuIte_BanHang_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new BanHang(id);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new BanHang(id);
        }

        private void MenuItem_RePass_Click(object sender, RoutedEventArgs e)
        {
            FogotPass forgotPassWorld = new FogotPass(id);
            forgotPassWorld.ShowDialog();
        }

        private void MenuItem_lichsu_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new LichSuNV(id);
        }

        private void MenuItem_kho_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new SanPhamView_NV();
        }
    }
}
