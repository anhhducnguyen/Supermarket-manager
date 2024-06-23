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
    public partial class ThemKhachHang1 : Window
    {
        public ThemKhachHang1()
        {
            InitializeComponent();
        }

        DataTable DataSource = null;
        SqlConnection Conn = new SqlConnection();
        string ConnectionString = "";
        private void NapDuLieuTuMayChu()
        {

            if (Conn.State != ConnectionState.Open) return;

            string SqlStr = "Select * from tblKhachHang";

            SqlDataAdapter adapter = new SqlDataAdapter(SqlStr, Conn);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            DataSource = dataSet.Tables[0];
            //dgkhachhang.ItemsSource = DataSource.DefaultView;
        }
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
            string sqlStr = "";
            String strGioitinh = "";
            if (nam.IsChecked == true)
            {
                strGioitinh = "Nam";
            }
            else if (nu.IsChecked == true)
            {
                strGioitinh = "Nu";
            }
            List<String> dsmakh = new List<string>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {

                sqlStr = "Select MaKhachHang from tblKhachHang";

                SqlCommand command = new SqlCommand(sqlStr, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    dsmakh.Add(reader.GetString(reader.GetOrdinal("MaKhachHang")).Trim());


                }

                reader.Close();
            }
            if (dsmakh.Contains(txtMaKhachHang.Text.ToString()) == true)
            {
                MessageBox.Show("Đã có khách hàng này trong danh sánh khách hàng thân thiết");
                return;
            }





            if (txtMaKhachHang.Text == "" || txtTenKhachHang.Text == "" || txtDiaChi.Text == "" || strGioitinh == "" || txtSoDienThoai.Text == "" || txtSoCCCD.Text == "" || txtNoiCapCCCD.Text == "" || txtNgayCap.SelectedDate.Value.ToString("yyyy-MM-dd") == "" || txtNgayTaoThe.SelectedDate.Value.ToString("yyyy-MM-dd") == "")
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

            MessageBoxResult result = MessageBox.Show("Bạn có muốn lưu các thay đổi không?", "Xác nhận", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {


                sqlStr = "Insert Into tblKhachHang (MaKhachHang,TenKhachHang,NgaySinh,GioiTinh,DiaChi,SoDienThoai,SoCCCD,NgayCap,NoiCap,NgayTaoThe,DiemThuong) " +
             "values (@ma, @ten, @ngaysinh, @gioitinh, @diachi, @sdt,@socccd,@ngaycap,@noicap,@ngaytaothe,@diem )";

                SqlCommand cmd = new SqlCommand(sqlStr, Conn);
                cmd.Parameters.AddWithValue("@ma", txtMaKhachHang.Text);
                cmd.Parameters.AddWithValue("@ten", txtTenKhachHang.Text);
                cmd.Parameters.AddWithValue("@ngaysinh", toDate(txtNgaySinh.Text));
                cmd.Parameters.AddWithValue("@gioitinh", strGioitinh);
                cmd.Parameters.AddWithValue("@diachi", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@sdt", txtSoDienThoai.Text);
                cmd.Parameters.AddWithValue("@socccd", txtSoCCCD.Text);
                cmd.Parameters.AddWithValue("@ngaycap", toDate(txtNgayCap.Text));
                cmd.Parameters.AddWithValue("@noicap", txtNoiCapCCCD.Text);
                cmd.Parameters.AddWithValue("@ngaytaothe", toDate(txtNgayTaoThe.Text));
                cmd.Parameters.AddWithValue("@diem", 0);

                cmd.ExecuteNonQuery();
                NapDuLieuTuMayChu();

                this.Close();
            }
            else
            {
                // Không lưu và tiếp tục làm việc
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
                // Không lưu và tiếp tục làm việc
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                txtMaKhachHang.Focus();
                //Mở kết nối
                ConnectionString = @"Data Source=DESKTOP-IKSFK82\SQLEXPRESS;Initial Catalog=QuanLyBanHangNhanh;Integrated Security=True;";
                //ConnectionString = @"Data Source=.\NAM;Initial Catalog=QuanLyBanHangNhanh;Integrated Security=True;";
                Conn.ConnectionString = ConnectionString;
                Conn.Open();
                NapDuLieuTuMayChu();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở kết nối" + ex.ToString());
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
    }
}
