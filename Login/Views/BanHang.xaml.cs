using Login.KhachHang;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Numerics;
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
using Login.WindowView;
using System.Data.SqlTypes;
using System.Data;
using System.IO;
using System.ComponentModel;

namespace Login.Views
{
    
    public class ThongTinMatHang
    {
        public bool IsSelected { get; set; }
        public string maSanPham { get; set; }
        public string tenSanPham { get; set; }
        public int soLuong { get; set; }
        public BigInteger donGia { get; set; }
        public string khuyenMai { get; set; }
        public BigInteger thanhTien { get; set; }
    }
    public class NhanVien : INotifyPropertyChanged
    {
        private byte[] _image;
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
        public byte[] Image
        {
            get { return _image; }
            set
            {
                _image = value;
                OnPropertyChanged(nameof(Image));
                OnPropertyChanged(nameof(ImageSource));
            }
        }
        public string mk { get; set; }

        public ImageSource ImageSource
        {
            get
            {
                if (Image == null || Image.Length == 0)
                    return null;

                BitmapImage bitmap = new BitmapImage();
                using (MemoryStream stream = new MemoryStream(Image))
                {
                    bitmap.BeginInit();
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.StreamSource = stream;
                    bitmap.EndInit();
                }
                return bitmap;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    /// <summary>
    /// Interaction logic for BanHang.xaml
    /// </summary>
    public partial class BanHang : UserControl
    {
        ObservableCollection<ThongTinMatHang> oders = new ObservableCollection<ThongTinMatHang>();
        string ma = "";
        ObservableCollection<NhanVien> NhanViens = new ObservableCollection<NhanVien>();
        private SqlConnection Conn = new SqlConnection();
        private string ConnectionString;

        public BanHang(string ma)
        {
            InitializeComponent();
            this.ma = ma;
            this.DataContext = this; // Set DataContext
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            oders.Clear();
            try
            {
                ConnectionString = @"Data Source=DESKTOP-IKSFK82\SQLEXPRESS;Initial Catalog=QuanLyBanHangNhanh;Integrated Security=True;";
                Conn.ConnectionString = ConnectionString;
                Conn.Open();
                LayDuLieu();
                NapDuLieuTuMayChu();

                string sqlQuery = "SELECT TOP 1 MaHoaDon FROM tblHoaDon ORDER BY MaHoaDon DESC";
                SqlCommand cmd2 = new SqlCommand(sqlQuery, Conn);
                string lastMaDonHang = (string)cmd2.ExecuteScalar();

                if (lastMaDonHang != null)
                {
                    int lastStt = int.Parse(lastMaDonHang.Substring(2));
                    txtMaDon.Text = "DH" + (lastStt + 1).ToString("D4");
                }

                SqlCommand command = new SqlCommand("SELECT TenNhanVien FROM tblNhanVien WHERE MaNhanVien = @ma", Conn);
                command.Parameters.AddWithValue("@ma", ma);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    txt_tnv.Text = reader.GetString(0);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmbKhuyenMai.Items.Add("0%");
            cmbKhuyenMai.Items.Add("10%");
            cmbKhuyenMai.Items.Add("25%");
            cmbKhuyenMai.Items.Add("50%");

            txtNgayBan.Text = DateTime.Now.ToString("dd/MM/yyyy");
            cmbMaNhanVien.Text = ma;
            cmbMaNhanVien.IsEnabled = false;
            txt_masp.Focus();
        }

        private void NapDuLieuTuMayChu()
        {
            NhanViens.Clear();
            if (Conn.State == ConnectionState.Closed)
            {
                Conn.Open();
            }

            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM tblNhanVien WHERE MaNhanVien = 'NV001'", Conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    NhanVien nv = new NhanVien
                    {
                        IsSelected = false,
                        manv = reader.GetString(0),
                        tennv = reader.GetString(1),
                        tk = reader.GetString(2),
                        trangthailv = reader.GetString(3),
                        gt = reader.GetString(4),
                        sdt = reader.GetString(5),
                        ngaysinh = reader.GetDateTime(6),
                        diachi = reader.GetString(7),
                        cccd = reader.GetString(8),
                        noicap = reader.GetString(9),
                        ngaycap = reader.GetDateTime(10),
                        ngaylvct = reader.GetDateTime(11),
                        luong = (float)reader.GetDouble(12),
                        Image = reader.IsDBNull(13) ? null : (byte[])reader["Image"],
                        mk = reader.GetString(14)
                    };
                    NhanViens.Add(nv);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }


        private static int stt = 1;

        //SqlConnection Conn = new SqlConnection();
        //string ConnectionString = "";

        private string toDate(string date)
        {
            string[] tokens = date.Split('/');
            Array.Reverse(tokens);
            string outputString = string.Join("-", tokens);
            return outputString;
        }

        private string dateTo(string date)
        {
            string[] tokens = date.Split('-');
            Array.Reverse(tokens);
            string outputString = string.Join("/", tokens);
            return outputString;
        }
        private void defaulApp()
        {
            txtMaDon.Text = "";
            txtNgayBan.Text = DateTime.Now.ToString("dd/MM/yyyy");
            cmbMaNhanVien.Text = ma;
            txt_masp.Text = "";
            txtTenSanPham.Text = "";
            txtTenSanPham.Text = "";
            cmbKhuyenMai.SelectedItem = null;
            txtSoLuong.Text = "";
            txtDonGia.Text = "";
            
            txt_mkh.Text = string.Empty;
            txt_tkh.Text = string.Empty;

            txtThanhTien.Text = null;
            dgDanhSachSanPham.ItemsSource = null;

            totalPriceTextBlock.Text = null;
            customerPaymentTextBox.Text = null;
            changeTextBox.Text = null;
            totalPriceTextBlock.Text = null;
            customerPaymentTextBox.Text = null;
            changeTextBox.Text = null;
            customerPayment = 0;
        }

        public void LayDuLieu()
        {
            SqlCommand command = new SqlCommand("SELECT MaNhanVien FROM tblNhanVien", Conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cmbMaNhanVien.Text = reader.GetString(0).Trim();
            }
            reader.Close();
        }

        private void btThemSanPham_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_masp.Text) ||
                string.IsNullOrWhiteSpace(txtTenSanPham.Text) ||
                string.IsNullOrWhiteSpace(txtSoLuong.Text) ||
                string.IsNullOrWhiteSpace(txtDonGia.Text) ||
                string.IsNullOrWhiteSpace(txtThanhTien.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                return;
            }

            string maSanPham = txt_masp.Text;
            //Kiểm tra sản phẩm hiện có
            ThongTinMatHang existingMatHang = oders.FirstOrDefault(matHang => matHang.maSanPham == maSanPham);
            //Cập nhật hoặc thêm mới sản phẩm
            if (existingMatHang != null)
            {
                existingMatHang.soLuong += int.Parse(txtSoLuong.Text);
                existingMatHang.thanhTien = existingMatHang.soLuong * existingMatHang.donGia;
            }
            else
            {
                ThongTinMatHang matHangMoi = new ThongTinMatHang();
                matHangMoi.maSanPham = maSanPham;
                matHangMoi.tenSanPham = txtTenSanPham.Text;
                matHangMoi.soLuong = int.Parse(txtSoLuong.Text);
                matHangMoi.donGia = d;
                matHangMoi.khuyenMai = cmbKhuyenMai.SelectedItem == null ? "0%" : cmbKhuyenMai.SelectedItem.ToString();
                matHangMoi.thanhTien = tt;

                oders.Add(matHangMoi);
            }

            dgDanhSachSanPham.ItemsSource = null;
            dgDanhSachSanPham.ItemsSource = oders;
            txt_masp.Clear();
            txtTenSanPham.Clear();
            txtSoLuong.Clear();
            txtDonGia.Clear();
            txtThanhTien.Clear();
            txt_masp.Focus();
            CalculateTotalPrice();
        }


        private void btLuuDonHang_Click(object sender, RoutedEventArgs e)
        {
            //Kiểm tra xem có sản phẩm nào không
            if(oders.Count > 0)
            {
                //Nếu có chèn vào bảng tblHoaDon
                string sqlStr = "Insert Into tblHoaDon (MaHoaDon,NgayBan,MaNhanVien,MaKhachHang,TongTien) " +
                "values (@MaHoaDon, @NgayBan, @MaNhanVien, @MaKhachhang, @TongTien)";

                SqlCommand cmd = new SqlCommand(sqlStr, Conn);
                cmd.Parameters.AddWithValue("@MaHoaDon", txtMaDon.Text);
                cmd.Parameters.AddWithValue("@NgayBan", toDate(txtNgayBan.Text));
                cmd.Parameters.AddWithValue("@MaNhanVien", cmbMaNhanVien.Text);
                if (string.IsNullOrEmpty(txt_mkh.Text))
                {
                    cmd.Parameters.AddWithValue("@MaKhachhang", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@MaKhachhang", mkh);
                }

                cmd.Parameters.AddWithValue("@TongTien", decimal.Parse(totalPrice.ToString()));
                cmd.ExecuteNonQuery();
                //tongTien = 0;
                //Thêm chi tiết thông tin vào bảng tblChiTietHoaDon
                foreach (ThongTinMatHang matHang in oders)
                {
                    string sqlStr1 = "Insert Into tblChiTietHoaDon (MaHoaDon,MaSanPham,TenSanPham,SoLuong,DonGia,KhuyenMai,ThanhTien) " +
                 "values (@MaHoaDon, @MaSanPham, @TenSanPham, @SoLuong, @DonGia, @KhuyenMai, @ThanhTien)";

                    SqlCommand cmd1 = new SqlCommand(sqlStr1, Conn);
                    cmd1.Parameters.AddWithValue("@MaHoaDon", txtMaDon.Text);
                    cmd1.Parameters.AddWithValue("@MaSanPham", matHang.maSanPham);
                    cmd1.Parameters.AddWithValue("@TenSanPham", matHang.tenSanPham);
                    cmd1.Parameters.AddWithValue("@SoLuong", matHang.soLuong);
                    cmd1.Parameters.AddWithValue("@DonGia", decimal.Parse(matHang.donGia.ToString()));
                    cmd1.Parameters.AddWithValue("@KhuyenMai", matHang.khuyenMai);
                    cmd1.Parameters.AddWithValue("@ThanhTien", decimal.Parse(matHang.thanhTien.ToString()));
                    cmd1.ExecuteNonQuery();
                    string sqlStr3 = "Update tblSanPham Set " +
                            "SoLuong = SoLuong - " + matHang.soLuong + " WHERE MaSanPham = N'" + matHang.maSanPham + "'";
                    SqlCommand cmd3 = new SqlCommand(sqlStr3, Conn);
                    cmd3.ExecuteNonQuery();
                }


                //Xử lý khách hàng và điểm thưởng
                if (!string.IsNullOrEmpty(txt_mkh.Text))
                {
                    string sqlStrSelect = "SELECT TenKhachHang, DiemThuong FROM tblKhachHang WHERE MaKhachHang = N'" + mkh + "'";
                    SqlCommand cmdSelect = new SqlCommand(sqlStrSelect, Conn);
                    SqlDataReader reader = cmdSelect.ExecuteReader();
                    string tenkh = "";
                    int diemthuong = 0;
                    if (reader.Read())
                    {
                        tenkh = reader["TenKhachHang"].ToString();
                        diemthuong = Convert.ToInt32(reader["DiemThuong"]);
                    }

                    reader.Close();
                    string sqlStr4 = "Insert Into tblDiemThuong (MaKhachHang,TenKhachHang,DiemThuong,DiemCong,DiemDung,Ngay)" +
                     "values (@ma, @ten, @diem, @diemcong, @diemdung, @ngay)";
                    SqlCommand cmd4 = new SqlCommand(sqlStr4, Conn);
                    cmd4.Parameters.AddWithValue("@ma", mkh);
                    cmd4.Parameters.AddWithValue("@ten", tenkh);
                    cmd4.Parameters.AddWithValue("@diem", diemthuong);
                    cmd4.Parameters.AddWithValue("@diemcong", (int)totalPrice * 1 / 1000);
                    cmd4.Parameters.AddWithValue("@diemdung", 0);
                    cmd4.Parameters.AddWithValue("@ngay", toDate(txtNgayBan.Text));


                    cmd4.ExecuteNonQuery();

                    string sqlStr2 = "UPDATE tblKhachHang SET DiemThuong = DiemThuong + N'" + (int)totalPrice * 1 / 1000 + "' WHERE MaKhachHang like '%" + txt_mkh.Text + "%'";
                    SqlCommand cmd2 = new SqlCommand(sqlStr2, Conn);
                    cmd2.ExecuteNonQuery();
                    totalPrice = 0;
                    totalPriceTextBlock.Text = "";
                    oders.Clear();
                }
                totalPrice = 0;
                mkh = "";
                oders.Clear();
                txt_masp.Focus();

                defaulApp();
                //Làm mới id cho đơn hàng tiếp theo
                try
                {
                    string sql = "SELECT TOP 1 MaHoaDon FROM tblHoaDon ORDER BY MaHoaDon DESC";
                    SqlCommand cmd3 = new SqlCommand(sql, Conn);
                    string lastMaDonHang = (string)cmd3.ExecuteScalar();
                    if (lastMaDonHang != null)
                    {
                        int lastStt = int.Parse(lastMaDonHang.Substring(2));
                        stt = lastStt + 1;
                    }
                    txtMaDon.Text = "DH" + stt.ToString("D4");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Chưa có sản phẩm để thanh toán");
            }
        }

        private void btHuy_Click(object sender, RoutedEventArgs e)
        {
            defaulApp();
            oders.Clear();
            txt_masp.Focus();
            try
            {
                string sql = "SELECT TOP 1 MaHoaDon FROM tblHoaDon ORDER BY MaHoaDon DESC";
                SqlCommand cmd3 = new SqlCommand(sql, Conn);
                string lastMaDonHang = (string)cmd3.ExecuteScalar();
                if (lastMaDonHang != null)
                {
                    int lastStt = int.Parse(lastMaDonHang.Substring(2));
                    stt = lastStt + 1;
                }
                txtMaDon.Text = "DH" + stt.ToString("D4");
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
        }

        

        private ThongTinMatHang selected;
        private void dgDanhSachSanPham_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selected = dgDanhSachSanPham.SelectedItem as ThongTinMatHang;
        }

        private void btXoa_Click(object sender, RoutedEventArgs e)
        {
            foreach (ThongTinMatHang selectedItem in oders.Where(item => item.IsSelected).ToList())
            {
                string sqlStr = "DELETE FROM tblChiTietHoaDon WHERE MaHoaDon =  N'" + selectedItem.maSanPham + "'" +
                                "DELETE FROM tblHoaDon WHERE MaHoaDon = N'" + selectedItem.maSanPham + "'";
                SqlCommand cmd = new SqlCommand(sqlStr, Conn);
                cmd.ExecuteNonQuery();
                oders.Remove(selectedItem);
            }

            dgDanhSachSanPham.ItemsSource = null;
            dgDanhSachSanPham.ItemsSource = oders;

            CalculateTotalPrice();
        }

        private void txt_masp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // Lấy thông tin sản phẩm từ database
                string selectedMaSanPham = txt_masp.Text;
                SqlCommand command = new SqlCommand("SELECT TenSanPham, DonGia FROM tblSanPham WHERE MaSanPham = @MaSanPham", Conn);
                command.Parameters.AddWithValue("@MaSanPham", selectedMaSanPham);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    txtTenSanPham.Text = reader.GetString(0);
                    txtDonGia.Text = reader.GetInt64(1).ToString("N0");
                }
                reader.Close();
            }
        }
        private void txt_masp_KeyUp(object sender, KeyEventArgs e)
        {
            string selectedMaSanPham = txt_masp.Text;

            // Lấy thông tin sản phẩm từ database
            SqlCommand command = new SqlCommand("SELECT TenSanPham, DonGia FROM tblSanPham WHERE MaSanPham = @MaSanPham", Conn);
            command.Parameters.AddWithValue("@MaSanPham", selectedMaSanPham);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                txtTenSanPham.Text = reader.GetString(0);
                txtDonGia.Text = reader.GetInt64(1).ToString("N0");
            }
            reader.Close();
        }
        BigInteger tt = 0;
        BigInteger d = 0;
        private void txtSoLuong_KeyUp(object sender, KeyEventArgs e)
        {
            char lastChar = txtSoLuong.Text.Length > 0 ? txtSoLuong.Text[txtSoLuong.Text.Length - 1] : '\0';

            if (char.IsDigit(lastChar))
            {
                if (!string.IsNullOrEmpty(txtSoLuong.Text) && !string.IsNullOrEmpty(txtDonGia.Text))
                {
                    string msp = txt_masp.Text;
                    int sl = 0;

                    SqlCommand command = new SqlCommand("SELECT SoLuong, DonGia FROM tblSanPham WHERE MaSanPham = @MaSanPham", Conn);
                    command.Parameters.AddWithValue("@MaSanPham", msp);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        sl = reader.GetInt32(0);
                        d = reader.GetInt64(1);
                    }
                    reader.Close();

                    int s = int.Parse(txtSoLuong.Text);

                    if (s < sl)
                    {
                        BigInteger t = s * d;
                        tt = t;
                        txtThanhTien.Text = t.ToString("N0") + "đ";
                    }
                    else
                    {
                        MessageBox.Show("Số lượng sản phẩm không đủ");
                    }
                }
            }
            else if (char.IsControl(lastChar)) 
            {
                // Continue processing, as it's a control character (e.g., backspace)
            }
            else
            {
                txtSoLuong.Text = "";
                MessageBox.Show("Vui lòng nhập số.");
            }

            if (string.IsNullOrEmpty(txtSoLuong.Text))
            {
                tt = 0;
                txtThanhTien.Text = "";
            }
        }


        String mkh = "";
        private void txt_mkh_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_mkh.Text))
            {
                SqlCommand command = new SqlCommand("SELECT TenKhachHang FROM tblKhachHang WHERE MaKhachHang = @MaKhachHang", Conn);
                command.Parameters.AddWithValue("@MaKhachHang", txt_mkh.Text);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    txt_tkh.Text = reader.GetString(0);
                    mkh = txt_mkh.Text;
                }
                reader.Close();
            }
            else
            {
                txt_tkh.Text = "";
            }

        }

        private void cmbKhuyenMai_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbKhuyenMai.SelectedItem != null && !string.IsNullOrEmpty(txtSoLuong.Text) && !string.IsNullOrEmpty(txtDonGia.Text))
            {
                if (int.TryParse(txtSoLuong.Text, out int soLuong) &&
                    BigInteger.TryParse(txtDonGia.Text, out BigInteger donGia) &&
                    int.TryParse(cmbKhuyenMai.SelectedItem.ToString().TrimEnd('%'), out int khuyenMai))
                {
                    BigInteger thanhTien = soLuong * donGia * (100 - khuyenMai) / 100;
                    tt = thanhTien;
                    txtThanhTien.Text = thanhTien.ToString("N0") + "đ";
                }
                else
                {
                    MessageBox.Show("Invalid input. Please enter valid numbers.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        public bool IsAllSelected { get; set; }
        List<String> listCode = new List<string>();
        // Chọn tất cả
        private void chkSelectAll_Checked(object sender, RoutedEventArgs e)
        {
            IsAllSelected = true;
            for (int i = 0; i < oders.Count; i++)
            {
                oders[i].IsSelected = true;
            }
            dgDanhSachSanPham.ItemsSource = null;
            dgDanhSachSanPham.ItemsSource = oders;
        }
        private void chkSelectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            IsAllSelected = false;
            for (int i = 0; i < oders.Count; i++)
            {
                oders[i].IsSelected = false;
            }
            //UserControl_Loaded(sender, e);

            for (int i = 0; i < oders.Count; i++)
            {
                if (!oders[i].IsSelected)
                {
                    String valueToRemove = oders[i].maSanPham;
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
        // Chọn theo từng check box
        private void dg_Checked(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < oders.Count; i++)
            {
                if (oders[i].IsSelected)
                {
                    listCode.Add(oders[i].maSanPham);
                }
            }
        }
        private void dg_Unchecked(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < oders.Count; i++)
            {
                if (!oders[i].IsSelected)
                {
                    String valueToRemove = oders[i].maSanPham;
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



        BigInteger totalPrice = 0;
        private void CalculateTotalPrice()
        {
            totalPrice = 0;
            foreach (ThongTinMatHang item in oders)
            {
                totalPrice += item.thanhTien;
            }
            totalPriceTextBlock.Text = totalPrice.ToString("N0");

        }

        private void btxoale_Click(object sender, RoutedEventArgs e)
        {
            if (dgDanhSachSanPham.SelectedItem != null)
            {
                ThongTinMatHang itemToDelete = (ThongTinMatHang)dgDanhSachSanPham.SelectedItem;
                oders.Remove(itemToDelete);
                dgDanhSachSanPham.ItemsSource = oders;
                CalculateTotalPrice();
            }
        }

        private void bt_addKH_Click(object sender, RoutedEventArgs e)
        {
            ThemKhachHang1 themKhachHang1 = new ThemKhachHang1();
            themKhachHang1.ShowDialog();
        }
        BigInteger customerPayment = 0;
        private void AmountButton_Click(object sender, RoutedEventArgs e)
        {

            if (sender is Button button && button.Tag != null)
            {
                BigInteger amount = BigInteger.Parse(button.Tag.ToString());
                customerPayment += amount;

                customerPaymentTextBox.Text = customerPayment.ToString("N0");
                BigInteger totalAmount = totalPrice;
                BigInteger change = customerPayment - totalAmount;
                if (change >= 0)
                {
                    changeTextBox.Text = change.ToString("N0");
                    txtHienThi.Text = "Tiền thừa";
                }
                else
                {
                    changeTextBox.Text = $"- {(-change).ToString("N0")}"; 
                    txtHienThi.Text = "Ghi nợ";
                }

            }
        }

        private void CalculateChange_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(totalPriceTextBlock.Text, out decimal totalAmount) &&
                decimal.TryParse(customerPaymentTextBox.Text, out decimal customerPayment))
            {
                decimal change = customerPayment - totalAmount;
                if (change >= 0)
                {
                    changeTextBox.Text = change.ToString("N0");
                    txtHienThi.Text = "Tiền thừa";
                }
                else
                {
                    changeTextBox.Text = $"- {(-change).ToString("N0")}";
                    txtHienThi.Text = "Ghi nợ";
                }
            }
            else
            {
                changeTextBox.Text = "Nhập số không hợp lệ";
            }
        }

        private void btLoad_Click(object sender, RoutedEventArgs e)
        {
            totalPriceTextBlock.Text = null;
            customerPaymentTextBox.Text = null;
            changeTextBox.Text = null;
        }

        private void btAddProduct_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var dataContext = button.DataContext as ThongTinMatHang;

            if (dataContext != null)
            {
                dataContext.soLuong++;

                dataContext.thanhTien = dataContext.soLuong * dataContext.donGia;

                dgDanhSachSanPham.Items.Refresh();

                CalculateTotalPrice();
            }
        }

        private void btReduceProduct_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var dataContext = button.DataContext as ThongTinMatHang;

            if (dataContext != null)
            {
                dataContext.soLuong--;

                if (dataContext.soLuong == 0)
                {
                    oders.Remove(dataContext);
                }
                else
                {
                    dataContext.thanhTien = dataContext.soLuong * dataContext.donGia;
                }

                dgDanhSachSanPham.Items.Refresh();

                CalculateTotalPrice();
            }
        }





        private void btAdd_KeyDow(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btThemSanPham_Click(sender, e);
            }
        }

        private void txtSo_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (customerPaymentTextBox.Text.Length == 0) return;

            long num = 0;
            bool success = long.TryParse(customerPaymentTextBox.Text.Replace(",", ""), out num);

            if (success)
            {
                customerPaymentTextBox.Text = string.Format("{0:#,##0}", num);
                customerPaymentTextBox.SelectionStart = customerPaymentTextBox.Text.Length;
            }
            else
            {
                customerPaymentTextBox.Text = customerPaymentTextBox.Text.Substring(0, customerPaymentTextBox.Text.Length - 1);
                customerPaymentTextBox.SelectionStart = customerPaymentTextBox.Text.Length;
            }
        }

        private void bt_Print_Click(object sender, RoutedEventArgs e)
        {
            
            if (dgDanhSachSanPham.SelectedItem is ThongTinMatHang selectedItem)
            {
                Print print = new Print(selectedItem.maSanPham, selectedItem.tenSanPham, selectedItem.soLuong, selectedItem.donGia, selectedItem.khuyenMai, selectedItem.thanhTien);
                print.ShowDialog();
            }
            else
            {
                MessageBox.Show("No data available for printing.");
            }
            btLuuDonHang_Click(sender, e);
        }

        //private void bt_Print_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        // Check if there are items in the collection
        //        if (oders.Count > 0)
        //        {
        //            // Assume you want to print the first item in the collection
        //            ThongTinMatHang firstItem = oders.First();

        //            // Create an instance of the Print class with the item's details
        //            Print print = new Print(
        //                firstItem.maSanPham,
        //                firstItem.tenSanPham,
        //                firstItem.soLuong,
        //                firstItem.donGia,
        //                firstItem.khuyenMai,
        //                firstItem.thanhTien
        //            );

        //            // You might have a method or logic in your Print class to perform the actual printing
        //            // For example:
        //            print.PrintToPrinter(); // Assuming you have a method like this in your Print class
        //        }
        //        else
        //        {
        //            // Handle the case where there are no items in the collection
        //            MessageBox.Show("No items to print.", "Print Error", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle any exceptions that might occur during printing
        //        MessageBox.Show($"Error during printing: {ex.Message}", "Print Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}






    }
}
