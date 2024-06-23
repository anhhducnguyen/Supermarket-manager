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
using Login.Oder;
using System.Security.Cryptography;
using Login.Views;
using Login.WindowView;

namespace Login
{
    internal static class User
    {
        public static string id { get; set; }
        public static string name { get; set; }
        public static string quyen { get; set; }
        public static string tendangnhap { get; set; }

    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtUser.Focus();
        }
        //DataTable DataSource = null;
        SqlConnection Conn = new SqlConnection();
        string ConnectionString = "";


        public static string EncodeMD5(string InportData)
        {
            MD5 mh = MD5.Create();
            //Chuyển kiểu chuổi thành kiểu byte
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(InportData);
            //mã hóa chuỗi đã chuyển
            byte[] hash = mh.ComputeHash(inputBytes);
            //tạo đối tượng StringBuilder (làm việc với kiểu dữ liệu lớn)
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2").ToUpper());
            }

            return sb.ToString();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void btQuit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //Home2 main = new Home2("12334");
            //main.Show();
            //this.Close();
            //return;
            string username = txtUser.Text;
            string password = EncodeMD5(pwbPassWord.Password);
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đăng nhập.");
                return;
            }
            if (username == "admin" && pwbPassWord.Password == "1234")
            {

                Home2 main = new Home2("12334");
                main.Show();
                this.Close();
                return;
            }

            //try
            //{
            //    string query = "Select * from tblNhanVien Where (TaiKhoan like '" +
            //    username + "')and(MatKhau like '" +
            //    password + "')";
            //    SqlDataAdapter adapter = new SqlDataAdapter(query, Conn);
            //    DataSet dataSet = new DataSet();
            //    adapter.Fill(dataSet);

            //    if (dataSet.Tables[0].Rows.Count > 0)
            //    {
            //        SqlCommand command = new SqlCommand("Select MaNhanVien from tblNhanVien Where (TaiKhoan like '" + username + "')and(MatKhau like '" + password + "')", Conn);
            //        SqlDataReader reader = command.ExecuteReader();
            //        string ma = "";
            //        while (reader.Read())
            //        {
            //            ma = reader.GetString(0);
            //        }

            //        return;
            //    }
            //    else
            //    {
            //        MessageBox.Show("Thông tin đăng nhập không chính xác.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi khi truy vấn cơ sở dữ liệu: " + ex.Message);
            //}
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            // Sao chép giá trị của PasswordBox vào TextBox
            txtMatKhau.Text = pwbPassWord.Password;
            // Ẩn PasswordBox
            pwbPassWord.IsHitTestVisible = false;
            pwbPassWord.Visibility = Visibility.Collapsed;
            // Hiển thị TextBox
            txtMatKhau.IsHitTestVisible = true;
            txtMatKhau.Visibility = Visibility.Visible;
        }
        // function 2
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            // Sao chép giá trị của TextBox vào PasswordBox
            pwbPassWord.Password = txtMatKhau.Text;
            // Ẩn TextBox
            txtMatKhau.IsHitTestVisible = false;
            txtMatKhau.Visibility = Visibility.Collapsed;
            // Hiển thị PasswordBox
            pwbPassWord.IsHitTestVisible = true;
            pwbPassWord.Visibility = Visibility.Visible;
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
                MessageBox.Show("Lỗi khi mở kết nối" + ex.ToString());
            }
        }

        //private void btnLogin2_Click(object sender, RoutedEventArgs e)
        //{

        //    string username = txtUser.Text;
        //    string password = EncodeMD5(pwbPassWord.Password);
        //    if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        //    {
        //        MessageBox.Show("Vui lòng nhập đầy đủ thông tin đăng nhập.");
        //        return;
        //    }

        //    try
        //    {
        //        string query = "Select * from tblNhanVien Where (TaiKhoan like '" +
        //        username + "')and(MatKhau like '" +
        //        password + "')";
        //        SqlDataAdapter adapter = new SqlDataAdapter(query, Conn);
        //        DataSet dataSet = new DataSet();
        //        adapter.Fill(dataSet);

        //        if (dataSet.Tables[0].Rows.Count > 0)
        //        {
        //            SqlCommand command = new SqlCommand("Select MaNhanVien, TrangThaiLamViec from tblNhanVien Where (TaiKhoan like '" + username + "')and(MatKhau like '" + password + "')", Conn);
        //            SqlDataReader reader = command.ExecuteReader();
        //            string ma = "";
        //            string cv = "";
        //            while (reader.Read())
        //            {
        //                ma = reader.GetString(0);
        //                cv = reader.GetString(1);
        //            }
        //            reader.Close();
        //            if(cv == "Nhân viên bán hàng")
        //            {
        //                Home3 main = new Home3(ma);
        //                main.Show();
        //                this.Close();
        //            }
        //            else if(cv == "Nhân viên kho")
        //            {

        //            }

        //        }
        //        else
        //        {
        //            MessageBox.Show("Thông tin đăng nhập không chính xác.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi khi truy vấn cơ sở dữ liệu: " + ex.Message);
        //    }
        //}
        private void btnLogin2_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUser.Text;
            string password = EncodeMD5(pwbPassWord.Password);

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đăng nhập.");
                return;
            }

            try
            {
                string query = "Select * from tblNhanVien Where TaiKhoan = @username and MatKhau = @password";

                using (SqlCommand command = new SqlCommand(query, Conn))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
                        string secondQuery = "Select MaNhanVien, TrangThaiLamViec from tblNhanVien Where TaiKhoan = @username and MatKhau = @password";

                        using (SqlCommand secondCommand = new SqlCommand(secondQuery, Conn))
                        {
                            secondCommand.Parameters.AddWithValue("@username", username);
                            secondCommand.Parameters.AddWithValue("@password", password);

                            using (SqlDataReader reader = secondCommand.ExecuteReader())
                            {
                                string ma = "";
                                string cv = "";

                                while (reader.Read())
                                {
                                    ma = reader.GetString(0);
                                    cv = reader.GetString(1);
                                }

                                if (cv == "Nhân viên bán hàng")
                                {
                                    Home3 main = new Home3(ma);
                                    main.Show();
                                    this.Close();
                                }
                                else if (cv == "Nhân viên kho")
                                {
                                    // Code to handle "Nhân viên kho"
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Thông tin đăng nhập không chính xác.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi truy vấn cơ sở dữ liệu: " + ex.Message);
            }
        }

    }
}
