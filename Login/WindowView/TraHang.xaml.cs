using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace Login.WindowView
{
    /// <summary>
    /// Interaction logic for TraHang.xaml
    /// </summary>
    public partial class TraHang : Window
    {
        public TraHang()
        {
            InitializeComponent();
        }
        public class ProductItem
        {
            public bool IsSelected { get; set; }
            public string MaSP { get; set; }
            public string TenSP { get; set; }
            public string MaNCC { get; set; }
            public int SoLuong { get; set; }
        }
        ObservableCollection<ProductItem> products = new ObservableCollection<ProductItem>();
        SqlConnection Conn = new SqlConnection();
        string ConnectionString = "";
        public bool IsAllSelected { get; set; }
        List<String> listCode = new List<string>();
        private void NapDuLieuTuMayChu()
        {
            products.Clear();
            if (Conn.State != ConnectionState.Open) return;
            SqlCommand command = new SqlCommand("SELECT MaSanPham FROM tblSanPham", Conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cmbSanPham.Items.Add(reader.GetString(0));
            }
            reader.Close();
            //products.RemoveAt(products.Count);
            // set ItemsSource of DataGrid to List
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
                NapDuLieuTuMayChu();
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
            this.Close();
        }

        private void chkSelectAll_Checked(object sender, RoutedEventArgs e)
        {
            IsAllSelected = true;
            for (int i = 0; i < products.Count; i++)
            {
                products[i].IsSelected = true;
            }
            dgDanhSachSanPham.ItemsSource = null;
            dgDanhSachSanPham.ItemsSource = products;
        }
        private void NapDuLieuData()
        {
            dgDanhSachSanPham.ItemsSource = null;
            dgDanhSachSanPham.ItemsSource = products;
        }

        private void dg_Checked(object sender, RoutedEventArgs e)
        {
            btnDelete.Visibility = Visibility.Visible;
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].IsSelected)
                {
                    listCode.Add(products[i].MaSP);
                }
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void dg_Unchecked(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < products.Count; i++)
            {
                if (!products[i].IsSelected)
                {
                    String valueToRemove = products[i].MaSP;
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
                btnDelete.Visibility = Visibility.Hidden;
            }
        }

        private void chkSelectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            IsAllSelected = false;
            for (int i = 0; i < products.Count; i++)
            {
                products[i].IsSelected = false;
            }
            NapDuLieuData();

            for (int i = 0; i < products.Count; i++)
            {
                if (!products[i].IsSelected)
                {
                    String valueToRemove = products[i].MaSP;
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
                btnDelete.Visibility = Visibility.Hidden;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnADD_Click(object sender, RoutedEventArgs e)
        {
            ProductItem productItem = new ProductItem();

            productItem.IsSelected = false;
            productItem.MaSP = cmbSanPham.Text;
            productItem.TenSP = tbnTenSp.Text;
            productItem.MaNCC = tbMaNCC.Text;
            productItem.SoLuong = int.Parse(tbnSoLuong.Text);
            if (productItem.MaSP != "" && productItem.SoLuong != 0)
            {
                products.Add(productItem);
            }
            dgDanhSachSanPham.ItemsSource = products;
        }

        private void cmbSanPham_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnADD.Visibility = Visibility.Visible;
            if (Conn.State != ConnectionState.Open) return;
            SqlCommand command = new SqlCommand("SELECT * FROM tblSanPham WHERE MaSanPham = N'" + cmbSanPham.Text + "'", Conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                tbnTenSp.Text = reader.GetString(1);
                tbMaNCC.Text = reader.GetString(3);
            }
            reader.Close();
        }

        private void cmbSanPham_GotFocus(object sender, RoutedEventArgs e)
        {
            btnADD.Visibility = Visibility.Visible;
            if (Conn.State != ConnectionState.Open) return;
            SqlCommand command = new SqlCommand("SELECT * FROM tblSanPham WHERE MaSanPham = N'" + cmbSanPham.Text + "'", Conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                tbnTenSp.Text = reader.GetString(1);
                tbMaNCC.Text = reader.GetString(3);
            }
            reader.Close();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonXoa_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}