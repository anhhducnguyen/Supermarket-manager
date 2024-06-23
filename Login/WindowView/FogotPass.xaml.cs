using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for FogotPass.xaml
    /// </summary>
    public partial class FogotPass : Window
    {
        class Mahoa
        {
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
        }
        string id;
        public FogotPass(string id)
        {
            InitializeComponent();
            this.id = id.Trim();
        }

        private void btMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        string ConnectionStrin = "";
        SqlConnection Conn = new SqlConnection();

        private void bt_doimk_Click(object sender, RoutedEventArgs e)
        {
            if ((txt_mkcu.Password.Trim() != "") && (txt_mkmoi1.Password.Trim() != "") && (txt_mkmoi2.Password.Trim() != ""))
            {
                if (txt_mkmoi1.Password != txt_mkmoi2.Password)
                {
                    lb_thongbao.Content = "Mật khẩu nhập lại không khớp";
                }
                else
                {
                    try
                    {
                        ConnectionStrin = @"Data Source=DESKTOP-IKSFK82\SQLEXPRESS;Initial Catalog=QuanLyBanHangNhanh;Integrated Security=True;";
                        //ConnectionStrin = @"Data Source=.\NAM;Initial Catalog=QuanLyBanHangNhanh;Integrated Security=True;";
                        Conn.ConnectionString = ConnectionStrin;
                        Conn.Open();

                        string sql = "Select * From tblNhanVien Where (MaNhanVien = '" + id + "') and (MatKhau = '" + Mahoa.EncodeMD5(txt_mkcu.Password) + "')";
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, Conn);
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet);
                        if (dataSet.Tables[0].Rows.Count <= 0)
                        {
                            lb_thongbao.Content = "Mật khẩu cũ không chính xác";
                        }
                        else
                        {
                            string sqlStr = "";
                            sqlStr = "Update tblNhanVien Set MatKhau = '" + Mahoa.EncodeMD5(txt_mkmoi2.Password) + "' Where MaNhanVien ='" + id + "'";
                            SqlCommand cmd = new SqlCommand(sqlStr, Conn);
                            cmd.ExecuteNonQuery();
                            this.Close();
                            MessageBox.Show("Đổi mật khẩu thành công");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi kết nối đến máy chủ\n" + ex.Message);
                    }
                    Conn.Close();
                }

            }
            else
            {
                lb_thongbao.Content = "Chưa nhập mật khẩu cũ hoặc mật khẩu mới";
                if (txt_mkmoi2.Password.Trim() == "")
                {
                    txt_mkmoi2.Focus();
                }
                if (txt_mkmoi1.Password.Trim() == "")
                {
                    txt_mkmoi1.Focus();
                }
                if (txt_mkcu.Password.Trim() == "")
                {
                    txt_mkcu.Focus();
                }
            }
            

        }

        private void txt_mkcu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txt_mkmoi1.Focus();
            }
        }

        private void txt_mkmoi1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txt_mkmoi2.Focus();
            }
        }
        private void bt_boqua_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
