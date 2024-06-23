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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Login.WindowView
{
    /// <summary>
    /// Interaction logic for EditEmployee.xaml
    /// </summary>
    public partial class EditEmployee : Window
    {
        public EditEmployee(
         String manv,
         String tennv,
         String tk,
         String trangthailv,
         String gt,
         String sdt, 
         String ngaysinh, 
         String diachi, 
         String cccd, 
         String noicap,
         String ngaycap,
         String ngaylvct,
         String luong,
         String anh,
         String mk
            )
        {
            InitializeComponent();
            txtMaNhanVien.Text = manv;
            txtTenNhanVien.Text = tennv;
            txtTenTaiKhoan.Text = tk;
            txtSoDienThoai.Text = sdt;
            txtSoCMND.Text = cccd;
            txtNoiCapCMND.Text = noicap;
            txtDiaChi.Text = diachi;
            txtNgayCap.Text = ngaycap;
            txtNgaySinh.Text = ngaysinh;
            txtNgayLamChinhThuc.Text = ngaylvct;
            cmbGioiTinh.Text = gt;
            cmbTrangThaiLamViec.Text = trangthailv;
            txtLuong.Text = luong;

            try
            {
                ConnectionString = @"Data Source=DESKTOP-IKSFK82\SQLEXPRESS;Initial Catalog=QuanLyBanHangNhanh;Integrated Security=True;";
                Conn.ConnectionString = ConnectionString;
                Conn.Open();
                string sqlStr = "SELECT Image FROM tblNhanVien WHERE MaNhanVien = '" + manv + "'";
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
        private void btHuy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btOpenFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
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
        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            string sqlStr = "";
            if (isNew)
            {
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
                // Kiểm tra các điều kiện khác ở đây

            //    try
            //    {
            //        Conn.Open();

            //        // Kiểm tra tồn tại của Mã nhân viên
            //        string checkExistQuery = "SELECT COUNT(*) FROM tblNhanVien WHERE MaNhanVien = @ma";
            //        SqlCommand checkExistCmd = new SqlCommand(checkExistQuery, Conn);
            //        checkExistCmd.Parameters.AddWithValue("@ma", txtMaNhanVien.Text);
            //        int existingCount = (int)checkExistCmd.ExecuteScalar();

            //        if (existingCount > 0)
            //        {
            //            MessageBox.Show("Mã nhân viên đã tồn tại.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            //            return;
            //        }

            //        // Chuyển đổi hình ảnh sang mảng byte
            //        byte[] imageData;
            //        using (MemoryStream ms = new MemoryStream())
            //        {
            //            BitmapEncoder encoder = new PngBitmapEncoder();
            //            encoder.Frames.Add(BitmapFrame.Create(image));
            //            encoder.Save(ms);
            //            imageData = ms.ToArray();
            //        }

            //        // Thêm nhân viên mới
            //        sqlStr = "Insert Into tblNhanVien (MaNhanVien,TenNhanVien,TaiKhoan,MatKhau,TrangThaiLamViec,SoDienThoai,GioiTinh,DiaChi,NgaySinh,SoCMND,NoiCap,NgayCap,NgayLamViecChinhThuc,Luong,[Image]) " +
            //            "values (@ma,@ten,@tk,@mk,@ttlamviec,@sđt,@gioitinh,@diachi,@ngaysinh,@soCMND,@noicap,@ngaycap,@ngaylamchinhthuc,@luong, @Image)";
            //        SqlCommand cmd = new SqlCommand(sqlStr, Conn);
            //        cmd.Parameters.AddWithValue("@ma", txtMaNhanVien.Text);
            //        cmd.Parameters.AddWithValue("@ten", txtTenNhanVien.Text);
            //        cmd.Parameters.AddWithValue("@tk", txtTenTaiKhoan.Text);
            //        cmd.Parameters.AddWithValue("@mk", EncodeMD5(txtMatKhau.Text));
            //        cmd.Parameters.AddWithValue("@ttlamviec", cmbTrangThaiLamViec.SelectedItem);
            //        cmd.Parameters.AddWithValue("@sđt", txtSoDienThoai.Text);
            //        cmd.Parameters.AddWithValue("@gioitinh", cmbGioiTinh.SelectedItem);
            //        cmd.Parameters.AddWithValue("@diachi", txtDiaChi.Text);
            //        cmd.Parameters.AddWithValue("@ngaysinh", toDate(txtNgaySinh.Text));
            //        cmd.Parameters.AddWithValue("@soCMND", txtSoCMND.Text);
            //        cmd.Parameters.AddWithValue("@noicap", txtNoiCapCMND.Text);
            //        cmd.Parameters.AddWithValue("@ngaycap", toDate(txtNgayCap.Text));
            //        cmd.Parameters.AddWithValue("@ngaylamchinhthuc", toDate(txtNgayLamChinhThuc.Text));
            //        cmd.Parameters.AddWithValue("@luong", ConvertToFloat(txtLuong.Text));
            //        cmd.Parameters.Add("@Image", SqlDbType.Image, imageData.Length).Value = imageData;

            //        cmd.ExecuteNonQuery();
            //        NapDuLieuTuMayChu();
            //        MessageBox.Show("Đã lưu nhân viên thành công.", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.ToString());
            //    }
            //    finally
            //    {
            //        if (Conn.State == ConnectionState.Open)
            //        {
            //            Conn.Close();
            //        }
            //    }
            //}
            //else
            //{
                try
                {
                    Conn.Open();

                    sqlStr = "UPDATE tblNhanVien SET " +
                   "TenNhanVien = N'" + txtTenNhanVien.Text + "', " +
                   "TaiKhoan = N'" + txtTenTaiKhoan.Text + "', " +
                   //"MatKhau = N'" + EncodeMD5(txtMatKhau.Text) + "', " +
                   "TrangThaiLamViec = N'" + cmbTrangThaiLamViec.SelectedItem + "', " +
                   "SoDienThoai = N'" + txtSoDienThoai.Text + "', " +
                   "GioiTinh = N'" + cmbGioiTinh.SelectedItem + "', " +
                   "DiaChi = N'" + txtDiaChi.Text + "', " +
                   "NgaySinh = '" + toDate(txtNgaySinh.Text) + "', " +
                   "SoCMND = N'" + txtSoCMND.Text + "', " +
                   "NoiCap = N'" + txtNoiCapCMND.Text + "', " +
                   "NgayCap = '" + toDate(txtNgayCap.Text) + "', " +
                   "NgayLamViecChinhThuc = '" + toDate(txtNgayLamChinhThuc.Text) + "', " +
                   "Luong = " + ConvertToFloat(txtLuong.Text) +
                   " WHERE MaNhanVien = '" + txtMaNhanVien.Text + "'";


                    SqlCommand cmd = new SqlCommand(sqlStr, Conn);
                    cmd.ExecuteNonQuery();
                    NapDuLieuTuMayChu();
                    MessageBox.Show("Nhân viên được cập nhật thành công.", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật dữ liệu: " + ex.ToString());
                }
                finally
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                    }
                }
            }
            defaultApp();
        }
        private void NapDuLieuTuMayChu()
        {

        }
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

            SetButtonsState(false);
        }
        private void SetButtonsState(bool Editing)
        {
            btSave.IsEnabled = Editing;
        }
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
        private string toDate(string date)
        {
            string[] tokens = date.Split('/');
            Array.Reverse(tokens);
            string outputString = string.Join("-", tokens);
            return outputString;
        }
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

      
    }
}
