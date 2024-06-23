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
    /// Interaction logic for addNCC.xaml
    /// </summary>
    public partial class addNCC : Window
    {
        public addNCC()
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
            if (string.IsNullOrEmpty(tbnMaSp.Text) || string.IsNullOrEmpty(tbnTenSp.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else
            {
                try
                {
                    sqlStr = "Insert Into tblNhaCungCap (MaNhaCungCap,TenNhaCungCap)" +
             "values (@masp, @tensp)";

                    SqlCommand cmd = new SqlCommand(sqlStr, Conn);
                    cmd.Parameters.AddWithValue("@masp", tbnMaSp.Text);
                    cmd.Parameters.AddWithValue("@tensp", tbnTenSp.Text);


                    cmd.ExecuteNonQuery();
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Mã nhà cung cấp đã tồn tại vui lòng nhập lại");
                }
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
    }
}
