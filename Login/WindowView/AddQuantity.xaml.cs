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

namespace Login.WindowView
{
    /// <summary>
    /// Interaction logic for AddQuantity.xaml
    /// </summary>
    public partial class AddQuantity : Window
    {
        public AddQuantity(string ProductCode, string ProductName)
        {
            InitializeComponent();
            tbnMaSp.Text = ProductCode;
            tbnTenSp.Text = ProductName;
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
            if (string.IsNullOrEmpty(tbnSoLuong.Text) || string.IsNullOrEmpty(tbnGiaNhap.Text) || string.IsNullOrEmpty(dtpNgayNhap.Text) || string.IsNullOrEmpty(dtpHanSudung.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else
                try
            {
                string sqlStr = "Insert Into tblNhapHang values(" +
                    "N'" + tbnMaSp.Text + "'," +
                    "N'" + tbnTenSp.Text + "'," +
                    "N'" + tbnSoLuong.Text + "'," +
                    "N'" + tbnGiaNhap.Text + "'," +
                    "N'" + toDate(dtpNgayNhap.Text) + "'," +
                    "N'" + toDate(dtpHanSudung.Text) + "')";
                SqlCommand cmd = new SqlCommand(sqlStr, Conn);
                cmd.ExecuteNonQuery();

                    sqlStr = "UPDATE tblSanPham SET " +
             "SoLuong = SoLuong + N'" + tbnSoLuong.Text + "'," +
             "HanSuDung = (SELECT MIN(HanSuDung) FROM tblNhapHang WHERE MaSanPham = N'" + tbnMaSp.Text + "') " +
             "WHERE MaSanPham = N'" + tbnMaSp.Text + "'";
                    cmd = new SqlCommand(sqlStr, Conn);
                    cmd.ExecuteNonQuery();
                    this.Close();
            }
            catch (Exception )
            {
                MessageBox.Show("Nhập sai! Vui lòng nhập lại");
            }
        }

        private void tbnTenSp_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
