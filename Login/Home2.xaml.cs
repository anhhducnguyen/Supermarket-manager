using Login.Views;
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
using Login.WindowView;

namespace Login
{
    /// <summary>
    /// Interaction logic for Home2.xaml
    /// </summary>
    public partial class Home2 : Window
    {
        String id;
        public Home2(string id)
        {
            InitializeComponent();
            contentControl.Content = new Dashboarch();
            this.id = id;
        }

        private void MenuItem_NhanVien_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new EmployeeView();
        }

        private void MenuItem_KhachHangf_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new CustomerView();
        }

        private void MenuItem_TongQuan_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new Dashboarch();
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

        private void MenuItem_ThongKeNhanVien_Click(object sender, RoutedEventArgs e)
        {
            //contentControl.Content = new EmployeeStatistics();
        }

        private void MenuItem_HoaDon_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new OrderView();
        }

        private void MenuItem_KhoHang_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new SamPhamView();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ForgotPassWorld forgotPassWorld = new ForgotPassWorld(id);
            forgotPassWorld.ShowDialog();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new NhaCungCap();
        }

        private void MenuIte_BanHang_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new BanHang(id);
        }
    }
}
