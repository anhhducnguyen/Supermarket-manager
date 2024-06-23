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
using System.Xml.Linq;
using System.Security.Cryptography;
using Microsoft.Win32;
using System.IO;
using System;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.ObjectModel;
using Login.WindowView;
using System.Data.SqlTypes;
using System.Collections.Generic;
using System.Security;


namespace Login.Views
{
    /// <summary>
    /// Interaction logic for EmployeeView.xaml
    /// </summary>
    public partial class EmployeeView : UserControl
    {
        public EmployeeView()
        {
            InitializeComponent();
        }
        ObservableCollection<NhanVien> NhanViens = new ObservableCollection<NhanVien>();
        public class NhanVien
        {
            public bool IsSelected { get; set; }
            public string manv { get; set; }
            public string tennv { get; set; }
            public string tk { get; set; }
            public string trangthailv { get; set; }
            public string gt { get; set; }
            public string sdt { get; set; }
            public DateTime ngaysinh { get; set; }
            public string diachi { get; set; }
            public string cccd { get; set; }
            public string noicap { get; set; }
            public DateTime ngaycap { get; set; }
            public DateTime ngaylvct { get; set; }
            public float luong { get; set; }
            public byte[] anh { get; set; }
            public string mk { get; set; }
            public ImageSource anhImage
            {
                get
                {
                    if (anh == null || anh.Length == 0)
                        return null;

                    BitmapImage image = new BitmapImage();
                    using (MemoryStream stream = new MemoryStream(anh))
                    {
                        image.BeginInit();
                        image.StreamSource = stream;
                        image.CacheOption = BitmapCacheOption.OnLoad;
                        image.EndInit();
                    }
                    return image;
                }
            }
        }
        bool isNew = false;
        SqlConnection Conn = new SqlConnection();
        string ConnectionString = "";

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            defaultApp();

            try
            {
                ConnectionString = @"Data Source=DESKTOP-IKSFK82\SQLEXPRESS;Initial Catalog=QuanLyBanHangNhanh;Integrated Security=True;";
                Conn.ConnectionString = ConnectionString;
                Conn.Open();
                NapDuLieuTuMayChu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở kết nối: " + ex.ToString());
            }
            finally
            {
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
            }
        }  

        //2. Nạp data và xuất các trường thông tin từ sql server lên data grid
        private void NapDuLieuTuMayChu()
        {
            dgNhanVien.ItemsSource = null;
            NhanViens.Clear();
            //if (Conn.State != ConnectionState.Open) return;
            if (Conn.State == ConnectionState.Closed)
            {
                Conn.Open();
            }
            SqlCommand command = new SqlCommand("SELECT * FROM tblNhanVien", Conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                NhanVien nv = new NhanVien();
                nv.IsSelected = false;
                nv.manv = reader.GetString(0);
                nv.tennv = reader.GetString(1);
                nv.tk = reader.GetString(2);
                nv.trangthailv = reader.GetString(3);
                nv.gt = reader.GetString(4);
                nv.sdt = reader.GetString(5);
                nv.ngaysinh = reader.GetDateTime(6);
                nv.diachi = reader.GetString(7);
                nv.cccd = reader.GetString(8);
                nv.noicap = reader.GetString(9);
                nv.ngaycap = reader.GetDateTime(10);
                nv.ngaylvct = reader.GetDateTime(11);
                nv.luong = (float)reader.GetDouble(12);
                SqlBinary varbinaryData = reader.GetSqlBinary(13);
                nv.anh = varbinaryData.Value;
                nv.mk = reader.GetString(14);
                NhanViens.Add(nv);
            }
            reader.Close();
            dgNhanVien.ItemsSource = NhanViens;
            TotalNumberOfEmployees();
        }
        // Tổng số nhân viên
        private void TotalNumberOfEmployees()
        {
            string sqlStr = "SELECT COUNT(MaNhanVien) FROM tblNhanVien";
            SqlCommand cmd = new SqlCommand(sqlStr, Conn);
            int employeeCount = (int)cmd.ExecuteScalar();
            txtTongNV.Text = employeeCount.ToString();
        }
        //4.Đặt mặc định cho các trường thông tin
        private void defaultApp()
        {
            SetButtonsState(false);
        }
        private void SetButtonsState(bool Editing)
        {
            btHuy.IsEnabled = Editing;
           
            Editing = !Editing;
            btAdd.IsEnabled = Editing;
            btDelete.IsEnabled = Editing;

        }
        // Xử lí button
        //1.Nút thêm
        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            ViewEmployee addEmployee = new ViewEmployee();
            addEmployee.ShowDialog();
            NapDuLieuTuMayChu();
        }
        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {

                    conn.Open();

                    MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên đã chọn không?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        for (int i = 0; i < listCode.Count; i++)
                        {
                            string sqlStr = "DELETE FROM tblChiTietHoaDon WHERE MaHoaDon IN (SELECT MaHoaDon FROM tblHoaDon WHERE MaNhanVien IN ('" + string.Join("','", listCode) + "')) " +
                           "DELETE FROM tblHoaDon WHERE MaNhanVien IN ('" + string.Join("','", listCode) + "') " +
                           "DELETE FROM tblNhanVien WHERE MaNhanVien IN ('" + string.Join("','", listCode) + "')";

                            SqlCommand cmd = new SqlCommand(sqlStr, conn);
                            cmd.ExecuteNonQuery();
                        }
                        Window_Loaded(sender, e);
                        MessageBox.Show("Đã xóa nhân viên thành công các nhân viên được chọn.", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực hiện xóa: " + ex.ToString());
            }
        }
        //2.Nút cập nhật
        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Conn.State == ConnectionState.Closed)
                {
                    Conn.Open();
                }

                defaultApp();
                NapDuLieuTuMayChu();
                txtSearch.Text = "Tìm theo tên, mã nhân viên...";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở kết nối: " + ex.ToString());
            }
            finally
            {
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
            }
        }
        private void btSua_Click(object sender, RoutedEventArgs e)
        {
            SetButtonsState(true);
            isNew = false;
        }
        //3.Nút hủy
        private void btHuy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Conn.State == ConnectionState.Closed)
                {
                    Conn.Open();
                }
                defaultApp();
                NapDuLieuTuMayChu();
                txtSearch.Text = "Tìm theo tên, mã nhân viên...";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở kết nối: " + ex.ToString());
            }
            finally
            {
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
            }
        }
        private void btedit_Click(object sender, RoutedEventArgs e)
        {
            NhanVien dataRowView = (NhanVien)((System.Windows.Controls.Button)e.Source).DataContext;
            EditEmployee editEmployee = new EditEmployee(
                 dataRowView.manv.ToString().Trim(), 
                 dataRowView.tennv, 
                 dataRowView.tk,
                 dataRowView.trangthailv,
                 dataRowView.gt,
                 dataRowView.sdt,
                 dataRowView.ngaysinh.ToString(),
                 dataRowView.diachi, dataRowView.cccd, 
                 dataRowView.noicap,
                 dataRowView.ngaycap.ToString(),
                 dataRowView.ngaylvct.ToString(),
                 dataRowView.luong.ToString(),
                 dataRowView.anh.ToString(),
                 dataRowView.mk
            );
            editEmployee.ShowDialog();
        }
        private void dgNhanVien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgNhanVien.SelectedItem == null)
                return;

            NhanVien nv = (NhanVien)dgNhanVien.SelectedItem;
        }
        //6. Nút search
        private void btSearch(object sender, RoutedEventArgs e)
        {
            if (txtSearch.Text == "")
            {
                NapDuLieuTuMayChu();
                //Window_Loaded(sender, e);
            }
            else
            {
                dgNhanVien.ItemsSource = null;
                NhanViens.Clear();

                try
                {
                    // Mở kết nối
                    Conn.Open();
                    if (Conn.State != ConnectionState.Open) return;

                    string searchText = txtSearch.Text.ToLower();
                    string sqlQuery = "SELECT * FROM tblNhanVien WHERE LOWER(TenNhanVien) LIKE @searchText OR MaNhanVien LIKE @searchText";

                    using (SqlCommand command = new SqlCommand(sqlQuery, Conn))
                    {
                        command.Parameters.Add(new SqlParameter("@searchText", "%" + searchText + "%"));
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            NhanVien nv = new NhanVien();
                            nv.IsSelected = false;
                            nv.manv = reader.GetString(0);
                            nv.tennv = reader.GetString(1);
                            nv.tk = reader.GetString(2);
                            nv.trangthailv = reader.GetString(3);
                            nv.gt = reader.GetString(4);
                            nv.sdt = reader.GetString(5);
                            nv.ngaysinh = reader.GetDateTime(6);
                            nv.diachi = reader.GetString(7);
                            nv.cccd = reader.GetString(8);
                            nv.noicap = reader.GetString(9);
                            nv.ngaycap = reader.GetDateTime(10);
                            nv.ngaylvct = reader.GetDateTime(11);
                            nv.luong = (float)reader.GetDouble(12);
                            nv.anh = reader["Image"] != DBNull.Value ? (byte[])reader["Image"] : null; // Assumes the image column name is "Image"
                            if (nv.manv != "")
                            {
                                NhanViens.Add(nv);
                            }
                        }
                        reader.Close();
                        dgNhanVien.ItemsSource = NhanViens;
                        txtTongNV.Text = NhanViens.Count.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm dữ liệu: " + ex.ToString());
                }
                finally
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                    }
                }
            }
        }


        private NhanVien selected;
        private void dgNhanvien_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            selected = dgNhanVien.SelectedItem as NhanVien;
        }

        private void btxoale_Click(object sender, RoutedEventArgs e)
        {
            NhanVien dataRowView = (NhanVien)((Button)e.Source).DataContext;

            MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            string deleteChiTietHoaDon = "DELETE FROM tblChiTietHoaDon WHERE MaHoaDon IN (SELECT MaHoaDon FROM tblHoaDon WHERE MaNhanVien = @manv)";
                            string deleteHoaDon = "DELETE FROM tblHoaDon WHERE MaNhanVien = @manv";
                            string deleteNhanVien = "DELETE FROM tblNhanVien WHERE MaNhanVien = @manv";

                            using (SqlCommand cmd = new SqlCommand(deleteChiTietHoaDon, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@manv", dataRowView.manv);
                                cmd.ExecuteNonQuery();
                            }

                            using (SqlCommand cmd = new SqlCommand(deleteHoaDon, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@manv", dataRowView.manv);
                                cmd.ExecuteNonQuery();
                            }

                            using (SqlCommand cmd = new SqlCommand(deleteNhanVien, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@manv", dataRowView.manv);
                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            Window_Loaded(sender, e);
                            MessageBox.Show("Đã xóa nhân viên thành công.", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                            defaultApp();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.ToString());
                        }
                    }
                }
            }
        }

        public bool IsAllSelected { get; set; }
        List<String> listCode = new List<string>();
        private void chkSelectAll_Checked(object sender, RoutedEventArgs e)
        {
            IsAllSelected = true;
            for (int i = 0; i < NhanViens.Count; i++)
            {
                NhanViens[i].IsSelected = true;
            }
            dgNhanVien.ItemsSource = null;
            dgNhanVien.ItemsSource = NhanViens;
        }
        private void chkSelectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            IsAllSelected = false;
            for (int i = 0; i < NhanViens.Count; i++)
            {
                NhanViens[i].IsSelected = false;
            }
            //NapDuLieuTuMayChu();
            Window_Loaded(sender, e);

            for (int i = 0; i < NhanViens.Count; i++)
            {
                if (!NhanViens[i].IsSelected)
                {
                    String valueToRemove = NhanViens[i].manv;
                    for (int j = listCode.Count - 1; j >= 0; j--)
                    {
                        if (listCode[j] == valueToRemove)
                        {
                            listCode.RemoveAt(j);
                        }
                    }
                }
            }
        }
        private void dg_Checked(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < NhanViens.Count; i++)
            {
                if (NhanViens[i].IsSelected)
                {
                    listCode.Add(NhanViens[i].manv);
                }
            }
        }
        private void dg_Unchecked(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < NhanViens.Count; i++)
            {
                if (!NhanViens[i].IsSelected)
                {
                    String valueToRemove = NhanViens[i].manv;
                    for (int j = listCode.Count - 1; j >= 0; j--)
                    {
                        if (listCode[j] == valueToRemove)
                        {
                            listCode.RemoveAt(j);
                        }
                    }
                }
            }
        }
        private void tbnSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            txtSearch.Text = "";
        }


    }
}