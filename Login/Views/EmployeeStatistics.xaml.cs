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
using static Login.Views.EmployeeView;
using System.Data.SqlTypes;
using System.Collections.ObjectModel;

namespace Login.Views
{
    /// <summary>
    /// Interaction logic for EmployeeStatistics.xaml
    /// </summary>
    public partial class EmployeeStatistics : UserControl
    {
        public EmployeeStatistics()
        {
            InitializeComponent();
        }

        public class TK_NhanVien 
        {
            public bool IsSelected { get; set; }
            public string manv { get; set; }
            public string tk { get; set; }
            public string ten { get; set; }
            public string mhd { get; set; }
            public DateTime ngayban { get; set; }
            public decimal tongtien { get; set; }
        }

        ObservableCollection<TK_NhanVien> tkNhanVien = new ObservableCollection<TK_NhanVien>();

        //DataTable DataSource = null;
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
            tkNhanVien.Clear();
            if (Conn.State != ConnectionState.Open) return;
            SqlCommand command = new SqlCommand("SELECT tblNhanVien.MaNhanVien, TaiKhoan, TenNhanVien,MaHoaDon, NgayBan, TongTien " +
                "FROM tblNhanVien LEFT OUTER JOIN tblHoaDon " +
                "ON tblNhanVien.MaNhanVien = tblHoaDon.MaNhanVien", Conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                TK_NhanVien nv = new TK_NhanVien();
                nv.IsSelected = false;
                nv.manv = reader.GetString(0);
                nv.tk = reader.GetString(1);
                nv.ten = reader.GetString(2);
                nv.mhd = reader.GetString(3);
                nv.ngayban = reader.GetDateTime(4);
                nv.tongtien = (decimal)reader.GetInt64(5);
                tkNhanVien.Add(nv);
            }
            reader.Close();
            dgUser.ItemsSource = tkNhanVien;
        }

        private void LoadCMB()
        {
            cmbDanhMuc.ItemsSource = null;
            if (Conn.State != ConnectionState.Open) return;

            string SqlStr = "Select MaNhanVien from tblNhanVien";
            SqlDataAdapter adapter = new SqlDataAdapter(SqlStr, Conn);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            DataTable dataTable = dataSet.Tables[0];

            cmbDanhMuc.ItemsSource = dataTable.AsEnumerable().Select(row => row.Field<string>("MaNhanVien")).ToList();
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
            string query = "SELECT tblNhanVien.MaNhanVien, TaiKhoan, TenNhanVien, MaHoaDon, NgayBan, TongTien " +
                "FROM tblNhanVien LEFT OUTER JOIN tblHoaDon " +
                "ON tblNhanVien.MaNhanVien = tblHoaDon.MaNhanVien " +
                "WHERE tblNhanVien.[MaNhanVien] = @manhanvien";

            // Tạo đối tượng SqlCommand và thiết lập tham số
            using (SqlCommand command = new SqlCommand(query, Conn))
            {
                command.Parameters.AddWithValue("@manhanvien", MaNhanVien);

                // Tạo đối tượng SqlDataAdapter để lấy dữ liệu từ SqlCommand và đưa chúng vào DataTable
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Create a list of TK_NhanVien and populate it with the data from DataTable
                    List<TK_NhanVien> selectedData = new List<TK_NhanVien>();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        TK_NhanVien nv = new TK_NhanVien();
                        nv.IsSelected = false;
                        nv.manv = row.Field<string>(0);
                        nv.tk = row.Field<string>(1);
                        nv.ten = row.Field<string>(2);
                        nv.mhd = row.Field<string>(3);
                        nv.ngayban = row.Field<DateTime>(4);
                        nv.tongtien = row.Field<decimal>(5);
                        selectedData.Add(nv);
                    }

                    // Set the ItemsSource of DataGrid to the list of TK_NhanVien
                    dgUser.ItemsSource = selectedData;
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
            string query = "SELECT COUNT(tblHoaDon.MaHoaDon) " +
                  "FROM tblHoaDon LEFT OUTER JOIN tblNhanVien " +
                  "ON tblNhanVien.MaNhanVien = tblHoaDon.MaNhanVien " +
                  "WHERE tblNhanVien.MaNhanVien = @maNhanVien";
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
            string query = "select sum(tblHoaDon.TongTien) " +
                "from tblHoaDon left outer join tblNhanVien " +
                "on tblNhanVien.MaNhanVien = tblHoaDon.MaNhanVien " +
                "where tblNhanVien.MaNhanVien = @maNhanVien";
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
            string query = "select avg(tblHoaDon.TongTien) " +
               "from tblHoaDon left outer join tblNhanVien " +
               "on tblNhanVien.MaNhanVien = tblHoaDon.MaNhanVien " +
               "where tblNhanVien.MaNhanVien = @maNhanVien";
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
        private void SetButtonsState(bool Editing)
        {

        }

        private void btThoat_Click(object sender, RoutedEventArgs e)
        {
            //Application.Current.Shutdown();
            //this.Close();
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
            string query = "SELECT TOP 1 tblNhanVien.MaNhanVien " +
                "FROM tblHoaDon INNER JOIN tblNhanVien " +
                "ON tblHoaDon.MaNhanVien = tblNhanVien.MaNhanVien " +
                "GROUP BY tblNhanVien.MaNhanVien, tblNhanVien.TenNhanVien " +
                "ORDER BY COUNT(tblHoaDon.MaHoaDon) DESC";
            using (SqlCommand command = new SqlCommand(query, Conn))
            {
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    //txtTopNhanVien.Text = result.ToString();
                }
                else
                {
                    //txtTopNhanVien.Text = "0";
                }
            }

        }

        private void top1_name()
        {
            string query = "SELECT TOP 1 tblNhanVien.TenNhanVien " +
                "FROM tblHoaDon INNER JOIN tblNhanVien " +
                "ON tblHoaDon.MaNhanVien = tblNhanVien.MaNhanVien " +
                "GROUP BY tblNhanVien.MaNhanVien, tblNhanVien.TenNhanVien " +
                "ORDER BY COUNT(tblHoaDon.MaHoaDon) DESC";
            using (SqlCommand command = new SqlCommand(query, Conn))
            {
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    //txtTenNhanVien.Text = result.ToString();
                }
                else
                {
                    //txtTenNhanVien.Text = "0";
                }
            }
        }

        private void Salary_Sum()
        {
            //if (cmbDanhMuc.SelectedItem == null)
            //{
            //    return;
            //}
            //string query = "SELECT sum(tblNhanVien.Lương) " +
            //                "FROM tblNhanVien";
            //// Lấy tên danh mục được chọn từ ComboBox
            //string MaNhanVien = cmbDanhMuc.SelectedItem.ToString();
            //// Tạo câu truy vấn SQL với tham số

            //using (SqlCommand command = new SqlCommand(query, Conn))
            //{
            //    command.Parameters.AddWithValue("@maNhanVien", MaNhanVien);
            //    object result = command.ExecuteScalar();
            //    if (result != null && result != DBNull.Value)
            //    {
            //        decimal tongTien = Convert.ToDecimal(result);
            //        string formattedTongTien = tongTien.ToString("#,##0") + " VND";
            //        txtTienLuong.Text = formattedTongTien;
            //    }
            //    else
            //    {
            //        txtTienLuong.Text = "0 VND";
            //    }
            //}

        }
    }
}
