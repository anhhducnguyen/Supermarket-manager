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

namespace Login.WindowView
{
    /// <summary>
    /// Interaction logic for ViewEmployee.xaml
    /// </summary>
    public partial class ViewEmployee : Window
    {
        public ViewEmployee()
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

        private bool gioiTinhItemsAdded = false;
        private bool trangThaiLamViecItemsAdded = false;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!gioiTinhItemsAdded)
            {
                cmbGioiTinh.Items.Add("Nam");
                cmbGioiTinh.Items.Add("Nữ");
                gioiTinhItemsAdded = true;
            }

            if (!trangThaiLamViecItemsAdded)
            {
                cmbTrangThaiLamViec.Items.Add("Nhân viên bán hàng");
                cmbTrangThaiLamViec.Items.Add("Nhân viên kho");
                trangThaiLamViecItemsAdded = true;
            }

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

        // Xử lí đầu vào
        //1. Mật khẩu
        public static string EncodeMD5(string InportData)
        {
            MD5 mh = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(InportData);
            byte[] hash = mh.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2").ToUpper());
            }
            return sb.ToString();
        }

        //2. Nạp data và xuất các trường thông tin từ sql server lên data grid
        private void NapDuLieuTuMayChu()
        {

            NhanViens.Clear();
            if (Conn.State != ConnectionState.Open) return;
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

        //3.Chuyển định dạng ngày từ form / sang - phù hợp với SQL server
        private string toDate(string date)
        {
            string[] tokens = date.Split('/');
            Array.Reverse(tokens);
            string outputString = string.Join("-", tokens);
            return outputString;
        }
        //4.Đặt mặc định cho các trường thông tin
        private void defaultApp()
        {
            txtMaNhanVien.Text = "";
            txtTenTaiKhoan.Text = "";
            txtTenNhanVien.Text = "";
            txtMatKhau.Text = "";
            txtSoDienThoai.Text = "";
            txtSoCMND.Text = "";
            txtNoiCapCMND.Text = "";
            txtDiaChi.Text = "";
            cmbTrangThaiLamViec.SelectedItem = null;
            cmbGioiTinh.SelectedItem = null;
            txtNgayCap.Text = null;
            txtNgaySinh.Text = null;
            txtNgayLamChinhThuc.Text = "";
            txtLuong.Text = ""; pictureBoxSource.Source = null;
            pictureBox2Des.Source = null;
            passwordBox.Password = null;

            SetButtonsState(true);
        }
        private void SetButtonsState(bool Editing)
        {
            btOpen.IsEnabled = Editing;
            btSave.IsEnabled = Editing;
            btHuy.IsEnabled = Editing;
            txtMaNhanVien.IsEnabled = Editing;
            txtTenTaiKhoan.IsEnabled = Editing;
            txtTenNhanVien.IsEnabled = Editing;
            txtMatKhau.IsEnabled = Editing;
            txtSoDienThoai.IsEnabled = Editing;
            txtSoCMND.IsEnabled = Editing;
            txtNoiCapCMND.IsEnabled = Editing;
            txtDiaChi.IsEnabled = Editing;
            cmbTrangThaiLamViec.IsEnabled = Editing;
            cmbGioiTinh.IsEnabled = Editing;
            txtNgayCap.IsEnabled = Editing;
            txtNgaySinh.IsEnabled = Editing;
            txtNgayLamChinhThuc.IsEnabled = Editing;
            txtLuong.IsEnabled = Editing;

            Editing = !Editing;

        }
        // Chuyển string sang float
        private float ConvertToFloat(string input)
        {
            string cleanedInput = input.Replace(",", "");
            float result = 0;

            if (float.TryParse(cleanedInput, out result))
            {
                return result;
            }
            else
            {
                return 0;
            }
        }
        // Xử lí button
        //1.Nút thêm
        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            defaultApp();
            cmbGioiTinh.SelectedItem = "Nam";
            cmbTrangThaiLamViec.SelectedItem = "Nhân viên bán hàng";
            SetButtonsState(true);
            isNew = true;
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
            txtMatKhau.IsEnabled = false;
            txtMaNhanVien.IsEnabled = false;
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
        //4.Nút lưu
        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            string sqlStr = "";
                BitmapImage image = pictureBoxSource.Source as BitmapImage;
                if (string.IsNullOrEmpty(txtMaNhanVien.Text))
                {
                    MessageBox.Show("Vui lòng nhập thông tin cho ô Mã nhân viên");
                    return;
                }
                else if (string.IsNullOrEmpty(txtTenNhanVien.Text))
                {
                    MessageBox.Show("Vui lòng nhập thông tin cho ô Tên nhân viên");
                    return;
                }
                else if (string.IsNullOrEmpty(txtSoDienThoai.Text))
                {
                    MessageBox.Show("Vui lòng chọn thông tin cho ô Số điện thoại");
                    return;
                }
                else if (string.IsNullOrEmpty(txtTenTaiKhoan.Text))
                {
                    MessageBox.Show("Vui lòng nhập thông tin cho ô Tên tài khoản");
                    return;
                }
                else if (string.IsNullOrEmpty(txtSoCMND.Text))
                {
                    MessageBox.Show("Vui lòng chọn thông tin cho ô Số chứng minh nhân dân");
                    return;
                }
                else if (string.IsNullOrEmpty(txtNoiCapCMND.Text))
                {
                    MessageBox.Show("Vui lòng chọn thông tin cho ô Nơi cấp chứng minh nhân dân");
                    return;
                }
                else if (string.IsNullOrEmpty(cmbGioiTinh.Text))
                {
                    MessageBox.Show("Vui lòng chọn thông tin Giới tính");
                    return;
                }
                else if (string.IsNullOrEmpty(txtNgaySinh.Text))
                {
                    MessageBox.Show("Vui lòng chọn thông tin cho ô Ngày sinh");
                    return;
                }
                else if (string.IsNullOrEmpty(txtDiaChi.Text))
                {
                    MessageBox.Show("Vui lòng chọn thông tin cho ô Địa chỉ");
                    return;
                }
                else if (string.IsNullOrEmpty(passwordBox.Password))
                {
                    MessageBox.Show("Vui lòng chọn thông tin cho ô Mật khẩu");
                    return;
                }
                else if (string.IsNullOrEmpty(cmbTrangThaiLamViec.Text))
                {
                    MessageBox.Show("Vui lòng chọn thông tin Trạng thái làm việc");
                    return;
                }

                else if (string.IsNullOrEmpty(txtNgayCap.Text))
                {
                    MessageBox.Show("Vui lòng chọn thông tin cho ô Ngày cấp chứng minh nhân dân ");
                    return;
                }
                else if (string.IsNullOrEmpty(txtNgayLamChinhThuc.Text))
                {
                    MessageBox.Show("Vui lòng chọn thông tin cho ô Ngày làm chính thức");
                    return;
                }
                else if (string.IsNullOrEmpty(txtLuong.Text))
                {
                    MessageBox.Show("Vui lòng chọn thông tin cho ô Tiền Lương ");
                    return;
                }

                else if (image == null)
                {
                    MessageBox.Show("Vui lòng chọn ảnh để lưu.");
                    return;
                }
                try
                {
                    Conn.Open();

                    string checkExistQuery = "SELECT COUNT(*) FROM tblNhanVien WHERE MaNhanVien = @ma";
                    SqlCommand checkExistCmd = new SqlCommand(checkExistQuery, Conn);
                    checkExistCmd.Parameters.AddWithValue("@ma", txtMaNhanVien.Text);
                    int existingCount = (int)checkExistCmd.ExecuteScalar();

                    if (existingCount > 0)
                    {
                        MessageBox.Show("Mã nhân viên đã tồn tại.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    // Chuyển đổi hình ảnh sang mảng byte
                    byte[] imageData;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        BitmapEncoder encoder = new PngBitmapEncoder();
                        encoder.Frames.Add(BitmapFrame.Create(image));
                        encoder.Save(ms);
                        imageData = ms.ToArray();
                    }

                    // Thêm nhân viên mới
                    sqlStr = "Insert Into tblNhanVien (MaNhanVien,TenNhanVien,TaiKhoan,MatKhau,TrangThaiLamViec,SoDienThoai,GioiTinh,DiaChi,NgaySinh,SoCMND,NoiCap,NgayCap,NgayLamViecChinhThuc,Luong,[Image]) " +
                        "values (@ma,@ten,@tk,@mk,@ttlamviec,@sđt,@gioitinh,@diachi,@ngaysinh,@soCMND,@noicap,@ngaycap,@ngaylamchinhthuc,@luong, @Image)";
                    SqlCommand cmd = new SqlCommand(sqlStr, Conn);
                    cmd.Parameters.AddWithValue("@ma", txtMaNhanVien.Text);
                    cmd.Parameters.AddWithValue("@ten", txtTenNhanVien.Text);
                    cmd.Parameters.AddWithValue("@tk", txtTenTaiKhoan.Text);
                    cmd.Parameters.AddWithValue("@mk", EncodeMD5(txtMatKhau.Text));
                    cmd.Parameters.AddWithValue("@ttlamviec", cmbTrangThaiLamViec.SelectedItem);
                    cmd.Parameters.AddWithValue("@sđt", txtSoDienThoai.Text);
                    cmd.Parameters.AddWithValue("@gioitinh", cmbGioiTinh.SelectedItem);
                    cmd.Parameters.AddWithValue("@diachi", txtDiaChi.Text);
                    cmd.Parameters.AddWithValue("@ngaysinh", toDate(txtNgaySinh.Text));
                    cmd.Parameters.AddWithValue("@soCMND", txtSoCMND.Text);
                    cmd.Parameters.AddWithValue("@noicap", txtNoiCapCMND.Text);
                    cmd.Parameters.AddWithValue("@ngaycap", toDate(txtNgayCap.Text));
                    cmd.Parameters.AddWithValue("@ngaylamchinhthuc", toDate(txtNgayLamChinhThuc.Text));
                    cmd.Parameters.AddWithValue("@luong", ConvertToFloat(txtLuong.Text));
                    cmd.Parameters.Add("@Image", SqlDbType.Image, imageData.Length).Value = imageData;

                    cmd.ExecuteNonQuery();
                    NapDuLieuTuMayChu();
                    MessageBox.Show("Đã lưu nhân viên thành công.", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.ToString());
                }
                finally
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                    }
                }
            defaultApp();
        }


        //5.Nút chọn ảnh
        private void btOpenFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            openFileDialog.Filter = "Image files (*.png;*.jpg)|*.png;*.jpg|All files (*.*)|*.*";


            if (openFileDialog.ShowDialog() == true)
            {
                string imagePath = openFileDialog.FileName;
                using (FileStream stream = new FileStream(imagePath, FileMode.Open))
                {
                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.StreamSource = stream;
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.EndInit();
                    pictureBoxSource.Source = image;
                }
            }
        }


        private void btedit_Click(object sender, RoutedEventArgs e)
        {
            NhanVien dataRowView = (NhanVien)((Button)e.Source).DataContext;
            SetButtonsState(true);
            txtMatKhau.IsEnabled = false;
            txtMaNhanVien.IsEnabled = false;
            isNew = false;

            txtMaNhanVien.Text = dataRowView.manv;
            txtTenNhanVien.Text = dataRowView.tennv;
            txtTenTaiKhoan.Text = dataRowView.tk;
            cmbTrangThaiLamViec.SelectedItem = dataRowView.trangthailv;
            txtSoDienThoai.Text = dataRowView.sdt;
            cmbGioiTinh.SelectedItem = dataRowView.gt;
            txtDiaChi.Text = dataRowView.diachi;
            txtNgaySinh.Text = dataRowView.ngaysinh.ToString();
            txtSoCMND.Text = dataRowView.cccd;
            txtNoiCapCMND.Text = dataRowView.noicap;
            txtNgayCap.Text = dataRowView.ngaycap.ToString();
            txtNgayLamChinhThuc.Text = dataRowView.ngaylvct.ToString();
            passwordBox.Password = dataRowView.mk;

            float luong = dataRowView.luong;
            string luongFormatted = luong.ToString("#,##0");
            txtLuong.Text = luongFormatted;
            try
            {
                Conn.Open();

                string sqlStr = "SELECT Image FROM tblNhanVien WHERE MaNhanVien = '" + dataRowView.manv + "'";
                SqlCommand cmd = new SqlCommand(sqlStr, Conn);
                byte[] imageData = (byte[])cmd.ExecuteScalar();

                if (imageData != null)
                {
                    BitmapImage image = new BitmapImage();
                    using (MemoryStream stream = new MemoryStream(imageData))
                    {
                        image.BeginInit();
                        image.StreamSource = stream;
                        image.CacheOption = BitmapCacheOption.OnLoad;
                        image.EndInit();
                    }
                    pictureBox2Des.Source = image;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi truy vấn dữ liệu: " + ex.ToString());
            }
            finally
            {
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
            }
        }
        // Ẩn hiện Password
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            txtMatKhau.Text = passwordBox.Password;
            passwordBox.IsHitTestVisible = false;
            passwordBox.Visibility = Visibility.Collapsed;
            txtMatKhau.IsHitTestVisible = true;
            txtMatKhau.Visibility = Visibility.Visible;
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            passwordBox.Password = txtMatKhau.Text;
            txtMatKhau.IsHitTestVisible = false;
            txtMatKhau.Visibility = Visibility.Collapsed;
            passwordBox.IsHitTestVisible = true;
            passwordBox.Visibility = Visibility.Visible;
        }
        private void txtLuong_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtLuong.Text.Length == 0) return;

            long num = 0;
            bool success = long.TryParse(txtLuong.Text.Replace(",", ""), out num);

            if (success)
            {
                txtLuong.Text = string.Format("{0:#,##0}", num);
            }
        }
        private void txtLuong_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtLuong.Text.Length == 0) return;

            string input = txtLuong.Text.Replace(".", "");
            long num = 0;
            bool success = long.TryParse(input, out num);

            if (success)
            {
                string formattedText = string.Format("{0:#,##0}", num);
                txtLuong.Text = formattedText;
                txtLuong.SelectionStart = formattedText.Length;
            }
            else if (txtLuong.Text.Length > 1)
            {
                string tempText = txtLuong.Text.Substring(0, txtLuong.Text.Length - 1);
                long tempNum = 0;
                bool tempSuccess = long.TryParse(tempText.Replace(".", ""), out tempNum);

                if (tempSuccess)
                {
                    string formattedTempText = string.Format("{0:#,##0}", tempNum);
                    txtLuong.Text = formattedTempText;
                    txtLuong.SelectionStart = formattedTempText.Length;
                }
            }

        }

        public bool IsAllSelected { get; set; }
        List<String> listCode = new List<string>();
        
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
