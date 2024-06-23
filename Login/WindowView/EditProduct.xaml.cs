using Microsoft.VisualStudio.RpcContracts.Commands;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Xml.Linq;

namespace Login.WindowView
{
    /// <summary>
    /// Interaction logic for EditProduct.xaml
    /// </summary>
    public partial class EditProduct : Window
    {
        string ProductCode;
        public EditProduct(string MaSP, string TenSP, string MaNhom, string MaNCC, int SoLuong, Int64 GiaBan, DateTime NSX, DateTime HSD)
        {
            InitializeComponent();
            tbnMaSp.Text = MaSP;
            this.ProductCode = MaSP;
            tbnTenSp.Text = TenSP;
            tbnMaNhom.Text = MaNhom;
            tbnMaNCC.Text = MaNCC;
            tbnSoLuong.Text = SoLuong.ToString();
            tbnGiaBan.Text = GiaBan.ToString();
            dtpNgaySanXuat.SelectedDate = NSX;
            dtpHanSuDung.SelectedDate = NSX;
        }
        SqlConnection Conn = new SqlConnection();
        string ConnectionString = "";
        private string toDate(string date)
        {
            string[] tokens = date.Split('/');
            Array.Reverse(tokens);
            string outputString = string.Join("-", tokens);
            return outputString;
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
                //ConnectionString = @"Data Source=DESKTOP-OEJ88PI\CUONG;Initial Catalog=QuanLyBanHangNhanh;Integrated Security=True;";
                ConnectionString = @"Data Source=DESKTOP-IKSFK82\SQLEXPRESS;Initial Catalog=QuanLyBanHangNhanh;Integrated Security=True;";
                //ConnectionString = @"Data Source=.\NAM;Initial Catalog=QuanLyBanHangNhanh;Integrated Security=True;";
                Conn.ConnectionString = ConnectionString;
                Conn.Open();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Lỗi khi mở kết nối" + ex.ToString());
            }
        }

        private void btnCancelProduct_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSaveProduct_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbnMaSp.Text) || string.IsNullOrEmpty(tbnTenSp.Text) || string.IsNullOrEmpty(tbnMaNhom.Text) || string.IsNullOrEmpty(tbnMaNCC.Text) || string.IsNullOrEmpty(tbnGiaBan.Text) || string.IsNullOrEmpty(tbnSoLuong.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else
            {
                try
                {
                    string sqlStr =
                        "Update tblSanPham Set " +
                        "MaSanPham = N'" + tbnMaSp.Text + "'," +
                        "TenSanPham = N'" + tbnTenSp.Text + "'," +
                        "MaNhomHang = N'" + tbnMaNhom.Text + "'," +
                        "MaNhaCungCap = N'" + tbnMaNCC.Text + "'," +
                        "DonGia = N'" + tbnGiaBan.Text + "'," +
                        "NSX = N'" + dtpNgaySanXuat.SelectedDate.Value.ToString("yyyy-MM-dd") + "'," +
                        "HSD = N'" + dtpHanSuDung.SelectedDate.Value.ToString("yyyy-MM-dd") + "'," +
                        "SoLuong = N'" + tbnSoLuong.Text + "' WHERE MaSanPham = N'" + ProductCode + "'";

                    SqlCommand cmd = new SqlCommand(sqlStr, Conn);
                    cmd.ExecuteNonQuery();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Mã Sản Phẩm đã tồn tại vui lòng nhập lại" + ex.ToString());
                }
            }
        }
    }
}