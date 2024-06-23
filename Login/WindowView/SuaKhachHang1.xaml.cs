using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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

namespace Login.KhachHang
{
    /// <summary>
    /// Interaction logic for SuaKhachHang1.xaml
    /// </summary>
    public partial class SuaKhachHang1 : Window
    {
        

        

        
        public SuaKhachHang1(String makh, String tenkh, String ngaysinh, String strGioitinh, String diachi, string sdt, String cccd, String ngaycap, String noicap, String ngaytao)
        {
            InitializeComponent();
            txtMaKhachHang.Text = makh;
            txtMaKhachHang.IsEnabled = false;
            txtTenKhachHang.Text = tenkh;
            txtNgaySinh.Text = ngaysinh;
            if (strGioitinh.Contains('a'))
            {
                nam.IsChecked = true;
            }
            else
            {
                nu.IsChecked = true;
            }
            txtDiaChi.Text = diachi;
            txtSoDienThoai.Text = sdt;
            txtSoCCCD.Text = cccd;
            txtNoiCapCCCD.Text = noicap;
            txtNgayCap.Text = ngaycap;
            txtNgayTaoThe.Text = ngaytao;
        }

        //DataTable DataSource = null;
        SqlConnection Conn = new SqlConnection();
        string ConnectionString = "";
        
        private string toDate(string date)
        {
            string[] tokens = date.Split('/');
            Array.Reverse(tokens);
            string outputString = string.Join("-", tokens);
            return outputString;
        }

 
        private void btluukhachhang_Click(object sender, RoutedEventArgs e)
        {
            bool b = false;
            bool c = false;
            String strGioitinh = "";

            if (nam.IsChecked == true)
            {
                strGioitinh = "Nam";
            }
            else if (nu.IsChecked == true)
            {
                strGioitinh = "Nu";
            }
            if (txtMaKhachHang.Text == "" || txtTenKhachHang.Text == "" || txtDiaChi.Text == "" || strGioitinh == "" || txtSoDienThoai.Text == "" || txtSoCCCD.Text == "" || txtNoiCapCCCD.Text == "" || txtNgayCap.Text == "" || txtNgayTaoThe.Text == "")
            {
                b = false;
            }
            else
            {
                b = true;
            }
            while (!c)
            {
                if (!b)
                {
                    MessageBox.Show("Bạn nhập thiếu thông tin." + "\nVui lòng nhập đủ thông tin!");
                    return;
                }
                else
                {
                    c = true;
                }
            }
            MessageBoxResult result = MessageBox.Show("Bạn có muốn lưu và thoát không?", "Xác nhận", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {

                string sqlStr = "UPDATE tblKhachHang " +
                "SET TenKhachHang = N'" +txtTenKhachHang.Text+"',"+
                "NgaySinh = N'" + toDate(txtNgaySinh.Text) + "'," +
                "GioiTinh = N'" +strGioitinh +"'," +
                "DiaChi =  N'" +txtDiaChi.Text+"'," +
                "SoDienThoai = N'" + txtSoDienThoai.Text + "'," +
                "SoCCCD = N'" + txtSoCCCD.Text + "'," +
                "NgayCap = N'" + toDate(txtNgayCap.Text) + "'," +
                "NoiCap = N'" + txtNoiCapCCCD.Text + "'," +
                "NgayTaoThe = N'" + toDate(txtNgayTaoThe.Text) + "'" +
                "WHERE MaKhachHang = N'" + txtMaKhachHang.Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand(sqlStr, Conn);
                cmd.ExecuteNonQuery();

                string sqlStr1 = "UPDATE tblDiemThuong " +
                "SET TenKhachHang = N'" + txtTenKhachHang.Text + "' " +
                "WHERE MaKhachHang = N'" + txtMaKhachHang.Text.Trim() + "'";
                SqlCommand cmd1 = new SqlCommand(sqlStr1, Conn);
                cmd1.ExecuteNonQuery();


                this.Close();
            }
            else
            {


            }





        }



        private void btthoat_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                this.Close();
            }
            else
            {
                // Hủy bỏ xác nhận và tiếp tục làm việc
            }



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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                txtTenKhachHang.Focus();
                //Mở kết nối
                ConnectionString = @"Data Source=DESKTOP-IKSFK82\SQLEXPRESS;Initial Catalog=QuanLyBanHangNhanh;Integrated Security=True;";
                //ConnectionString = @"Data Source=.\NAM;Initial Catalog=QuanLyBanHangNhanh;Integrated Security=True;";
                Conn.ConnectionString = ConnectionString;
                Conn.Open();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở kết nối" + ex.ToString());
            }
        }
    }
}
