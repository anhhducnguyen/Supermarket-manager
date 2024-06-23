using Login.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
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

namespace Login.Oder
{
    /// <summary>
    /// Interaction logic for OderDetails.xaml
    /// </summary>

    public class MatHang
    {
        public string maHD { get; set; }
        public string maSP { get; set; }
        public string tenSP { get; set; }
        public int soL { get; set; }
        public decimal donG { get; set; }
        public string khuyenM { get; set; }
        public decimal thanhT { get; set; }
    }

    public partial class OderDetails : Window
    {
        ObservableCollection<MatHang> orders = new ObservableCollection<MatHang>();
        public OderDetails(string OrderCode, DateTime OrderDate, string EmployeeCode, string CustomerCode, decimal TotalMoney)
        {
            InitializeComponent();
            txtMaDonHang.Text = OrderCode;
            txtNgayBan.Text = OrderDate.ToString("dd/MM/yyyy");
            txtMaNhanVien.Text = EmployeeCode;
            txtMaKhachHang.Text = CustomerCode;
            txtTongTien.Text = TotalMoney.ToString("N0");
        }
        //DataTable DataSource = null;
        SqlConnection Conn = new SqlConnection();
        string ConnectionString = "";

        private void NapDuLieuTuMayChu()
        {
            dgProducts.ItemsSource = null;
            orders.Clear();
            if (Conn.State != ConnectionState.Open) return;
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblChiTietHoaDon WHERE MaHoaDon like '%" + txtMaDonHang.Text + "%'", Conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                MatHang order = new MatHang();
                order.maHD = reader.GetString(0);
                order.maSP = reader.GetString(1);
                order.tenSP = reader.GetString(2);
                order.soL = reader.GetInt32(3);
                order.donG = (decimal)reader.GetInt64(4);
                order.khuyenM = reader.GetString(5);
                order.thanhT = (decimal)reader.GetInt64(6);
                orders.Add(order);
            }
            reader.Close();
            //Thiết lập cho hiển thị trên DataGrid
            dgProducts.ItemsSource = orders;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {

                ConnectionString = @"Data Source=DESKTOP-IKSFK82\SQLEXPRESS;Initial Catalog=QuanLyBanHangNhanh;Integrated Security=True;";
                //ConnectionString = @"Data Source=.\NAM;Initial Catalog=QuanLyBanHangNhanh;Integrated Security=True;";
                Conn.ConnectionString = ConnectionString;
                Conn.Open();
                NapDuLieuTuMayChu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kết nối dữ liệu " + ex.ToString());
            }
        }

        private void In_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(print, "invoice");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }

        private void Thoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}