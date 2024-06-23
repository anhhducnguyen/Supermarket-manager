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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.Cryptography;

namespace Login
{
    /// <summary>
    /// Interaction logic for ThongKeNhanVien.xaml
    /// </summary>
    public partial class ThongKeNhanVien : Window
    {
        public ThongKeNhanVien()
        {
            InitializeComponent();
        }
        DataTable DataSource = null;
        SqlConnection Conn = new SqlConnection();
        string ConnectionString = "";
        private void NapDuLieuTuMayChu()
        {
            LoadDg();
            LoadCMB();
            top1();
            top1_name();
            Salary_Sum();

        }
        // hiển thị thông tin kết nối giữa bảng Nhân Viên và bảng Hóa Đơn
        private void LoadDg()
        {
            dgUser.ItemsSource = null;
            if (Conn.State != ConnectionState.Open) return;
            string SqlStr = "SELECT tblNhanVien.[Mã nhân viên], [Tài khoản],[Tên nhân viên],[Mã hóa đơn],[Ngày bán],[Tổng tiền] " +
                "FROM tblNhanVien LEFT OUTER JOIN tblHoaDon " +
                "ON tblNhanVien.[Mã nhân viên] = tblHoaDon.[Mã nhân viên]";
            SqlDataAdapter adapter = new SqlDataAdapter(SqlStr, Conn);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            DataSource = dataSet.Tables[0];
            //Thiết lập cho hiển thị lên DataGrid

            dgUser.ItemsSource = DataSource.DefaultView;
        }

        private void LoadCMB()
        {
            cmbDanhMuc.ItemsSource = null;
            if (Conn.State != ConnectionState.Open) return;

            string SqlStr = "Select [Mã nhân viên] from tblNhanVien";
            SqlDataAdapter adapter = new SqlDataAdapter(SqlStr, Conn);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            DataTable dataTable = dataSet.Tables[0];

            cmbDanhMuc.ItemsSource = dataTable.AsEnumerable().Select(row => row.Field<string>("Mã nhân viên")).ToList();
        }

        private void cmbDanhMuc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbDanhMuc.SelectedItem == null)
            {
                return;
            }

            // Lấy tên danh mục được chọn từ ComboBox
            string MaNhanVien = cmbDanhMuc.SelectedItem.ToString();

            // Tạo câu truy vấn SQL với tham số
            string query = "SELECT tblNhanVien.[Mã nhân viên], [Tài khoản],[Tên nhân viên],[Mã hóa đơn],[Ngày bán],[Tổng tiền] " +
                "FROM tblNhanVien LEFT OUTER JOIN tblHoaDon " +
                "ON tblNhanVien.[Mã nhân viên] = tblHoaDon.[Mã nhân viên] " +
                "WHERE tblNhanVien.[Mã nhân viên] = @manhanvien";
            // Tạo đối tượng SqlCommand và thiết lập tham số
            using (SqlCommand command = new SqlCommand(query, Conn))
            {
                command.Parameters.AddWithValue("@manhanvien", MaNhanVien);

                // Tạo đối tượng SqlDataAdapter để lấy dữ liệu từ SqlCommand và đưa chúng vào DataTable
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Thiết lập ItemsSource của DataGrid để hiển thị dữ liệu từ DataTable
                    dgUser.ItemsSource = dataTable.DefaultView;
                }
            }
            TotalHoaDon(sender, e);
            TotalTien(sender, e);
            Avg(sender, e);

        }

        private void TotalHoaDon(object sender, SelectionChangedEventArgs e)
        {
            if (cmbDanhMuc.SelectedItem == null)
            {
                return;
            }

            // Lấy tên danh mục được chọn từ ComboBox
            string MaNhanVien = cmbDanhMuc.SelectedItem.ToString();
            // Tạo câu truy vấn SQL với tham số
            string query = "SELECT COUNT(tblHoaDon.[Mã hóa đơn]) " +
                  "FROM tblHoaDon LEFT OUTER JOIN tblNhanVien " +
                  "ON tblNhanVien.[Mã nhân viên] = tblHoaDon.[Mã nhân viên] " +
                  "WHERE tblNhanVien.[Mã nhân viên] = @maNhanVien";
            using (SqlCommand command = new SqlCommand(query, Conn))
            {
                command.Parameters.AddWithValue("@maNhanVien", MaNhanVien);
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    txtTongHoaDon.Text = result.ToString();
                }
                else
                {
                    txtTongHoaDon.Text = "0";
                }
            }

        }

        private void TotalTien(object sender, SelectionChangedEventArgs e)
        {
            if (cmbDanhMuc.SelectedItem == null)
            {
                return;
            }

            // Lấy tên danh mục được chọn từ ComboBox
            string MaNhanVien = cmbDanhMuc.SelectedItem.ToString();
            // Tạo câu truy vấn SQL với tham số
            string query = "select sum(tblHoaDon.[Tổng tiền]) " +
                "from tblHoaDon left outer join tblNhanVien " +
                "on tblNhanVien.[Mã nhân viên] = tblHoaDon.[Mã nhân viên] " +
                "where tblNhanVien.[Mã nhân viên] = @maNhanVien";
            using (SqlCommand command = new SqlCommand(query, Conn))
            {
                command.Parameters.AddWithValue("@maNhanVien", MaNhanVien);
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    decimal tongTien = Convert.ToDecimal(result);
                    string formattedTongTien = tongTien.ToString("#,##0") + " VND";
                    txtTongTien.Text = formattedTongTien;
                }
                else
                {
                    txtTongTien.Text = "0 VND";
                }
            }
        }


        private void Avg(object sender, SelectionChangedEventArgs e)
        {
            if (cmbDanhMuc.SelectedItem == null)
            {
                return;
            }
            string query = "select avg(tblHoaDon.[Tổng tiền]) " +
               "from tblHoaDon left outer join tblNhanVien " +
               "on tblNhanVien.[Mã nhân viên] = tblHoaDon.[Mã nhân viên] " +
               "where tblNhanVien.[Mã nhân viên] = @maNhanVien";
            // Lấy tên danh mục được chọn từ ComboBox
            string MaNhanVien = cmbDanhMuc.SelectedItem.ToString();
            // Tạo câu truy vấn SQL với tham số

            using (SqlCommand command = new SqlCommand(query, Conn))
            {
                command.Parameters.AddWithValue("@maNhanVien", MaNhanVien);
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    decimal tongTien = Convert.ToDecimal(result);
                    string formattedTongTien = tongTien.ToString("#,##0") + " VND";
                    txtGiaTriTrungBinh.Text = formattedTongTien;
                }
                else
                {
                    txtGiaTriTrungBinh.Text = "0 VND";
                }
            }

        }

        private void defaultApp()
        {
            txtTongHoaDon.Text = "";
            txtTongTien.Text = "";
            txtGiaTriTrungBinh.Text = "";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //////defaultApp();
            try
            {
                ConnectionString = @"Data Source=DESKTOP-IKSFK82\SQLEXPRESS;Initial Catalog=QuanLyBanHangNhanh;Integrated Security=True;";
                Conn.ConnectionString = ConnectionString;
                Conn.Open();
                NapDuLieuTuMayChu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở kết nối" + ex.ToString());
            }


        }
        private void SetButtonsState(bool Editing)
        {

        }

        private void btThoat_Click(object sender, RoutedEventArgs e)
        {
            //Application.Current.Shutdown();
            this.Close();
        }

        private void dgUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            NapDuLieuTuMayChu();
            defaultApp();
        }

        private void top1()
        {
            string query = "SELECT TOP 1 tblNhanVien.[Mã nhân viên] " +
                "FROM tblHoaDon INNER JOIN tblNhanVien " +
                "ON tblHoaDon.[Mã nhân viên] = tblNhanVien.[Mã nhân viên] " +
                "GROUP BY tblNhanVien.[Mã nhân viên], tblNhanVien.[Tên nhân viên] " +
                "ORDER BY COUNT(tblHoaDon.[Mã hóa đơn]) DESC";
            using (SqlCommand command = new SqlCommand(query, Conn))
            {
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    txtTopNhanVien.Text = result.ToString();
                }
                else
                {
                    txtTopNhanVien.Text = "0";
                }
            }

        }

        private void top1_name()
        {
            string query = "SELECT TOP 1 tblNhanVien.[Tên nhân viên] " +
                "FROM tblHoaDon INNER JOIN tblNhanVien " +
                "ON tblHoaDon.[Mã nhân viên] = tblNhanVien.[Mã nhân viên] " +
                "GROUP BY tblNhanVien.[Mã nhân viên], tblNhanVien.[Tên nhân viên] " +
                "ORDER BY COUNT(tblHoaDon.[Mã hóa đơn]) DESC";
            using (SqlCommand command = new SqlCommand(query, Conn))
            {
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    txtTenNhanVien.Text = result.ToString();
                }
                else
                {
                    txtTenNhanVien.Text = "0";
                }
            }
        }

        private void Salary_Sum()
        {
            if (cmbDanhMuc.SelectedItem == null)
            {
                return;
            }
            string query = "SELECT sum(tblNhanVien.Lương) " +
                            "FROM tblNhanVien";
            // Lấy tên danh mục được chọn từ ComboBox
            string MaNhanVien = cmbDanhMuc.SelectedItem.ToString();
            // Tạo câu truy vấn SQL với tham số

            using (SqlCommand command = new SqlCommand(query, Conn))
            {
                command.Parameters.AddWithValue("@maNhanVien", MaNhanVien);
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    decimal tongTien = Convert.ToDecimal(result);
                    string formattedTongTien = tongTien.ToString("#,##0") + " VND";
                    txtTienLuong.Text = formattedTongTien;
                }
                else
                {
                    txtTienLuong.Text = "0 VND";
                }
            }

        }
    }
}