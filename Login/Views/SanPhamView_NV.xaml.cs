using Login.WindowView;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Login.Views
{
    /// <summary>
    /// Interaction logic for SanPhamView_NV.xaml
    /// </summary>
    public partial class SanPhamView_NV : UserControl
    {
        ObservableCollection<ProductItem> products = new ObservableCollection<ProductItem>();
        public SanPhamView_NV()
        {
            InitializeComponent();
        }

        SqlConnection Conn = new SqlConnection();
        string ConnectionString = "";
        private void NapDuLieuTuMayChu()
        {
            dgProduct.ItemsSource = null;
            products.Clear();
            if (Conn.State != ConnectionState.Open) return;
            SqlCommand command = new SqlCommand("SELECT * FROM tblSanPham", Conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ProductItem product = new ProductItem();
                product.IsSelected = false;
                product.MaSP = reader.GetString(0);
                product.TenSP = reader.GetString(1);
                product.MaNhom = reader.GetString(2);
                product.MaNCC = reader.GetString(3);
                product.SoLuong = reader.GetInt32(7);
                product.DonGia = reader.GetInt64(6);
                product.NSX = reader.GetDateTime(4);
                product.HSD = reader.GetDateTime(5);
                if (product.MaSP != "")
                {
                    products.Add(product);
                }
            }
            reader.Close();
            //products.RemoveAt(products.Count);
            // set ItemsSource of DataGrid to List
            dgProduct.ItemsSource = products;
        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void tbnSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tbnSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            tbnSearch.Text = "";
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            try
            {
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
        public bool IsAllSelected { get; set; }

        private void chkSelectAll_Checked(object sender, RoutedEventArgs e)
        {
            IsAllSelected = true;
            for (int i = 0; i < products.Count; i++)
            {
                products[i].IsSelected = true;
            }
            dgProduct.ItemsSource = null;
            dgProduct.ItemsSource = products;
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
        private void NapDuLieuData()
        {
            dgProduct.ItemsSource = null;
            dgProduct.ItemsSource = products;
        }
        
        private void AddProduct_Closed(object sender, EventArgs e)
        {
            NapDuLieuTuMayChu();
        }
        List<String> listCode = new List<string>();

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
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
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
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

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Bạn có chắc chắn muốn xoá không?", "Xác nhận xoá", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                for (int i = 0; i < listCode.Count; i++)
                {
                    string sqlStr = "DELETE FROM tblChiTietHoaDon WHERE MaSanPham =  N'" + listCode[i] + "'" + "DELETE FROM tblNhapHang WHERE MaSanPham =  N'" + listCode[i] + "'" + "DELETE FROM tblSanPham WHERE MaSanPham = N'" + listCode[i] + "'";
                    listCode.RemoveAt(i);
                    SqlCommand cmd = new SqlCommand(sqlStr, Conn);
                    cmd.ExecuteNonQuery();
                }
                NapDuLieuTuMayChu();
                btnDelete.Visibility = Visibility.Hidden;
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (tbnSearch.Text == "")
            {
                NapDuLieuTuMayChu();
            }
            else
            {
                dgProduct.ItemsSource = null;
                products.Clear();
                if (Conn.State != ConnectionState.Open) return;
                SqlCommand command = new SqlCommand("SELECT * FROM tblSanPham WHERE MaSanPham like '%" + tbnSearch.Text + "%'", Conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ProductItem product = new ProductItem();
                    product.IsSelected = false;
                    product.MaSP = reader.GetString(0);
                    product.TenSP = reader.GetString(1);
                    product.MaNhom = reader.GetString(2);
                    product.MaNCC = reader.GetString(3);
                    product.SoLuong = reader.GetInt32(7);
                    product.DonGia = reader.GetInt64(6);
                    product.NSX = reader.GetDateTime(4);
                    product.HSD = reader.GetDateTime(5);
                    if (product.MaSP != "")
                    {
                        products.Add(product);
                    }
                }
                reader.Close();
                //products.RemoveAt(products.Count);
                // set ItemsSource of DataGrid to List
                dgProduct.ItemsSource = products;
            }
        }

        

        

        
        private void AddQuantity_Closed(object sender, EventArgs e)
        {
            NapDuLieuTuMayChu();
        }

        private void btnReLoad_Click(object sender, RoutedEventArgs e)
        {
            NapDuLieuTuMayChu();
        }
    }
}
