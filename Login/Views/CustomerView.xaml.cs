using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Login.KhachHang;
using Login.WindowView;



namespace Login.Views
{
    /// <summary>
    /// Interaction logic for CustomerView.xaml
    /// </summary>
    public partial class CustomerView : UserControl
    {
        public CustomerView()
        {
            InitializeComponent();
        }
        ObservableCollection<KhachHang> khachhangs = new ObservableCollection<KhachHang>();


        public class KhachHang
        {
            public String ma { get; set; }
            public String ten { get; set; }
            public String ngaysinh { get; set; }
            public String gioitinh { get; set; }
            public String diachi { get; set; }
            public String sdt { get; set; }
            public String cccd { get; set; }
            public String noicap { get; set; }
            public String ngaycap { get; set; }
            public String ngaytao { get; set; }
            public int diem { get; set; }
            public bool IsSelected { get; set; }

        }


        SqlConnection Conn = new SqlConnection();
        string ConnectionString = "";


        private void NapDuLieuTuMayChu()
        {

            string sqlstr = "SELECT * FROM tblKhachHang";
            if (Conn.State != ConnectionState.Open) return;
            khachhangs.Clear();
            dgkhachhang.ItemsSource = null;
            if (Conn.State != ConnectionState.Open) return;
            SqlCommand command = new SqlCommand(sqlstr, Conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                KhachHang khachhang = new KhachHang();
                khachhang.IsSelected = false;
                khachhang.ma = reader.GetString(0);
                khachhang.ten = reader.GetString(1);
                DateTime dateTime = reader.GetDateTime(2);
                khachhang.ngaysinh = dateTime.ToString("dd/MM/yyyy");

                khachhang.gioitinh = reader.GetString(3);
                khachhang.diachi = reader.GetString(4);
                khachhang.sdt = reader.GetString(5);
                khachhang.cccd = reader.GetString(6);
                DateTime dateTime1 = reader.GetDateTime(7);
                khachhang.ngaycap = dateTime1.ToString("dd/MM/yyyy");
                khachhang.noicap = reader.GetString(8);

                DateTime dateTime2 = reader.GetDateTime(9);
                khachhang.ngaytao = dateTime2.ToString("dd/MM/yyyy");
                khachhang.diem = reader.GetInt32(10);
                khachhangs.Add(khachhang);


            }
            reader.Close();
            dgkhachhang.ItemsSource = khachhangs;


        }

        private void CapNhatBang()
        {
            dgkhachhang.ItemsSource = null;
            dgkhachhang.ItemsSource = khachhangs;
        }

      

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // Set the connection string
                ConnectionString = @"Data Source=DESKTOP-IKSFK82\SQLEXPRESS;Initial Catalog=QuanLyBanHangNhanh;Integrated Security=True;";
                //ConnectionString = @"Data Source=.\NAM;Initial Catalog=QuanLyBanHangNhanh;Integrated Security=True;";
                Conn.ConnectionString = ConnectionString;

                Conn.Open();

                // Fetch data from the server
                NapDuLieuTuMayChu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở kết nối: " + ex.ToString());

            }
            //finally
            //{
            //    // Ensure the connection is closed, especially if an exception occurs
            //    if (Conn.State == ConnectionState.Open)
            //    {
            //        Conn.Close();
            //    }
            //}
        }


        private void txttimkiem_GotFocus(object sender, RoutedEventArgs e)
        {
            txttimkiem.Text = "";
        }

        private void dataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {

            if (e.PropertyName == "Ngày sinh" || e.PropertyName == "Ngày cấp" || e.PropertyName == "Ngày tạo thẻ")
            {
                DataGridTextColumn column = e.Column as DataGridTextColumn;
                Binding binding = column.Binding as Binding;
                binding.StringFormat = "dd-MM-yyyy";
            }
        }
        private string toDate(string date)
        {
            string[] tokens = date.Split('/');
            Array.Reverse(tokens);
            string outputString = string.Join("-", tokens);
            return outputString;
        }

        private void btthemkhachhang_Click(object sender, RoutedEventArgs e)
        {
            ThemKhachHang1 themkhachhang = new ThemKhachHang1();
            themkhachhang.ShowDialog();
            NapDuLieuTuMayChu();

        }
        List<String> listCode = new List<String>();
        private void btxoakhachhang_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa đối tượng đã chọn không?", "Xác nhận xóa", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    for (int i = 0; i < listCode.Count; i++)
                    {
                        string sqlStr1 = "Select [MaHoaDon] from tblHoaDon WHERE MaKhachHang =  N'" + listCode[i] + "'";
                        string sqlStr = "DELETE FROM tblChiTietHoaDon WHERE MaHoaDon IN (" + sqlStr1 + ") DELETE FROM tblHoaDon WHERE MaKhachHang =  N'" + listCode[i] + "' " + "DELETE FROM tblDiemThuong WHERE MaKhachHang =  N'" + listCode[i] + "' " + "DELETE FROM tblKhachHang WHERE MaKhachHang = N'" + listCode[i] + "'";
                        listCode.RemoveAt(i);
                        SqlCommand cmd = new SqlCommand(sqlStr, Conn);
                        cmd.ExecuteNonQuery();
                    }
                    NapDuLieuTuMayChu();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);

                }

            }
        }



        private void bttimkiem_Click(object sender, RoutedEventArgs e)
        {
            if (txttimkiem.Text == "")
            {
                NapDuLieuTuMayChu();
            }
            else
            {
                dgkhachhang.ItemsSource = null;
                khachhangs.Clear();
                if (Conn.State != ConnectionState.Open) return;
                SqlCommand command = new SqlCommand("SELECT * FROM tblKhachHang WHERE MaKhachHang like '%" + txttimkiem.Text.Trim() + "%'", Conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    KhachHang khachhang = new KhachHang();
                    khachhang.IsSelected = false;
                    khachhang.ma = reader.GetString(0);
                    khachhang.ten = reader.GetString(1);
                    DateTime dateTime = reader.GetDateTime(2);
                    khachhang.ngaysinh = dateTime.ToString("dd/MM/yyyy");

                    khachhang.gioitinh = reader.GetString(3);
                    khachhang.diachi = reader.GetString(4);
                    khachhang.sdt = reader.GetString(5);
                    khachhang.cccd = reader.GetString(6);
                    DateTime dateTime1 = reader.GetDateTime(7);
                    khachhang.ngaycap = dateTime.ToString("dd/MM/yyyy");
                    khachhang.noicap = reader.GetString(8);

                    DateTime dateTime2 = reader.GetDateTime(9);
                    khachhang.ngaytao = dateTime.ToString("dd/MM/yyyy");
                    khachhang.diem = reader.GetInt32(10);
                    khachhangs.Add(khachhang);

                }
                reader.Close();
                dgkhachhang.ItemsSource = khachhangs;
            }
        }

        private void btload_Click(object sender, RoutedEventArgs e)
        {
            NapDuLieuTuMayChu();
            txttimkiem.Text = "Nhập";
        }


        private void btdgxoa_Click(object sender, RoutedEventArgs e)
        {
            KhachHang dataRowView = (KhachHang)((System.Windows.Controls.Button)e.Source).DataContext;
            string sqlStr1 = "Select MaHoaDon from tblHoaDon WHERE MaKhachHang =  N'" + dataRowView.ma + "'";
            string sqlStr = "DELETE FROM tblChiTietHoaDon WHERE MaHoaDon IN (" + sqlStr1 + ") DELETE FROM tblHoaDon WHERE MaKhachHang =  N'" + dataRowView.ma + "' " + "DELETE FROM tblDiemThuong WHERE MaKhachHang =  N'" + dataRowView.ma + "' " + "DELETE FROM tblKhachHang WHERE MaKhachHang = N'" + dataRowView.ma + "'";
            SqlCommand cmd = new SqlCommand(sqlStr, Conn);
            cmd.ExecuteNonQuery();
            NapDuLieuTuMayChu();
        }


        private void btdgsua_Click(object sender, RoutedEventArgs e)
        {
            KhachHang dataRowView = (KhachHang)((System.Windows.Controls.Button)e.Source).DataContext;
            SuaKhachHang1 editkhachhang = new SuaKhachHang1(dataRowView.ma, dataRowView.ten, dataRowView.ngaysinh, dataRowView.gioitinh, dataRowView.diachi, dataRowView.sdt, dataRowView.cccd, dataRowView.ngaycap, dataRowView.noicap, dataRowView.ngaytao);
            editkhachhang.ShowDialog();
            NapDuLieuTuMayChu();

        }

        private void chkSelectAll_Checked(object sender, RoutedEventArgs e)
        {
            IsAllSelected = true;
            for (int i = 0; i < khachhangs.Count; i++)
            {
                khachhangs[i].IsSelected = true;
            }
            dgkhachhang.ItemsSource = null;
            dgkhachhang.ItemsSource = khachhangs;
        }
        public bool IsAllSelected { get; set; }

        private void chkSelectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            IsAllSelected = false;
            for (int i = 0; i < khachhangs.Count; i++)
            {
                khachhangs[i].IsSelected = false;
            }
            CapNhatBang();

            for (int i = 0; i < khachhangs.Count; i++)
            {
                if (!khachhangs[i].IsSelected)
                {
                    String valueToRemove = khachhangs[i].ma;
                    for (int j = listCode.Count - 1; j >= 0; j--)
                    {
                        if (listCode[j] == valueToRemove)
                        {
                            listCode.RemoveAt(j);
                        }
                    }
                }
            }

            if (listCode.Count == 0)
            {
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < khachhangs.Count; i++)
            {
                if (!khachhangs[i].IsSelected)
                {
                    String valueToRemove = khachhangs[i].ma;
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

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {


            btxoakhachhang.Visibility = Visibility.Visible;
            for (int i = 0; i < khachhangs.Count; i++)
            {
                if (khachhangs[i].IsSelected)
                {
                    listCode.Add(khachhangs[i].ma);
                }
            }
        }

        

        
    }
}
