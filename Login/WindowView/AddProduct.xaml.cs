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
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        public AddProduct()
        {
            InitializeComponent();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        SqlConnection Conn = new SqlConnection();
        string ConnectionString = "";
        private void btnCancelProduct_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private string toDate(string date)
        {
            string[] tokens = date.Split('/');
            Array.Reverse(tokens);
            string outputString = string.Join("-", tokens);
            return outputString;
        }
        private void btnSaveProduct_Click(object sender, RoutedEventArgs e)
        {
            string sqlStr = "";
            if (string.IsNullOrEmpty(tbnMaSp.Text) || string.IsNullOrEmpty(tbnTenSP.Text) || string.IsNullOrEmpty(tbnMaNhom.Text) || string.IsNullOrEmpty(tbnMaNCC.Text) || string.IsNullOrEmpty(tbnGiaBan.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else
            {
                try
                {
                    sqlStr = "Insert Into tblSanPham (MaSanPham,TenSanPham,MaNhomHang,MaNhaCungCap,SoLuong,DonGia,NSX,HSD)" +
             "values (@masp, @tensp, @pl, @dv, @sl, @gb, @nsx, @hsd)";

                    SqlCommand cmd = new SqlCommand(sqlStr, Conn);
                    cmd.Parameters.AddWithValue("@masp", tbnMaSp.Text);
                    cmd.Parameters.AddWithValue("@tensp", tbnTenSP.Text);
                    cmd.Parameters.AddWithValue("@pl", tbnMaNhom.Text);
                    cmd.Parameters.AddWithValue("@dv", tbnMaNCC.Text);
                    cmd.Parameters.AddWithValue("@sl", "0");
                    cmd.Parameters.AddWithValue("@gb", tbnGiaBan.Text);
                    cmd.Parameters.AddWithValue("@nsx", "1111-11-11");
                    cmd.Parameters.AddWithValue("@hsd", "1111-11-11");

                    cmd.ExecuteNonQuery();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Mã Sản Phẩm đã tồn tại vui lòng nhập lại" + ex.ToString());
                }
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
    }
}