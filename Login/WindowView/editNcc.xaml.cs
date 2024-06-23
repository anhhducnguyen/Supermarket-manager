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
    /// Interaction logic for editNcc.xaml
    /// </summary>
    public partial class editNcc : Window
    {
        string id;
        public editNcc(string id, string name)
        {
            InitializeComponent();
            this.id = id;
            tbnMaSp.Text = id;
            tbnTenSp.Text = name;
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
            if (string.IsNullOrEmpty(tbnMaSp.Text) || string.IsNullOrEmpty(tbnTenSp.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else
            {
                try
                {
                    string sqlStr =
                        "Update tblNhaCungCap Set " +
                        "MaNhaCungCap = N'" + tbnMaSp.Text + "'," +
                        "TenNhaCungCap = N'" + tbnTenSp.Text + "' " +
                        "WHERE MaNhaCungCap = '" + id + "'";

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
