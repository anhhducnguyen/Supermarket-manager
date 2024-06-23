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
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using static System.Resources.ResXFileRef;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.Common;
using Login.WindowView;
using System.Collections;

namespace Login.Views
{
    public class ProductItem
    {
        public bool IsSelected { get; set; }
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string MaNhom { get; set; }
        public string MaNCC { get; set; }
        public int SoLuong { get; set; }
        public Int64 DonGia { get; set; }
        public DateTime NSX { get; set; }
        public DateTime HSD { get; set; }
    }

    /// <summary>
    /// Interaction logic for SamPhamView.xaml
    /// </summary>
    public partial class SamPhamView : System.Windows.Controls.UserControl
    {
        ObservableCollection<ProductItem> products = new ObservableCollection<ProductItem>();

        public SamPhamView()
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
        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            addProduct.Closed += AddProduct_Closed;
            addProduct.Show();
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
                    string sqlStr = "DELETE FROM tblSanPham WHERE MaSanPham =  N'" + listCode[i] + "'";
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
                SqlCommand command = new SqlCommand("SELECT * FROM tblSanPham WHERE TenSanPham like '%" + tbnSearch.Text + "%'", Conn);
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

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            ProductItem dataRowView = (ProductItem)((System.Windows.Controls.Button)e.Source).DataContext;
            EditProduct editProduct = new EditProduct(dataRowView.MaSP, dataRowView.TenSP, dataRowView.MaNhom, dataRowView.MaNCC, dataRowView.SoLuong, dataRowView.DonGia, dataRowView.NSX, dataRowView.HSD);
            editProduct.Closed += AddProduct_Closed;
            editProduct.Show();

        }

        private void ButtonXoa_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Bạn có chắc chắn muốn xoá không?", "Xác nhận xoá", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ProductItem dataRowView = (ProductItem)((System.Windows.Controls.Button)e.Source).DataContext;
                string sqlStr = "DELETE FROM tblSanPham WHERE MaSanPham =  N'" + dataRowView.MaSP + "'";
                SqlCommand cmd = new SqlCommand(sqlStr, Conn);
                cmd.ExecuteNonQuery();
                NapDuLieuTuMayChu();
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {

        }
        private void AddQuantity_Closed(object sender, EventArgs e)
        {
            NapDuLieuTuMayChu();
        }

        private void btnReLoad_Click(object sender, RoutedEventArgs e)
        {
            NapDuLieuTuMayChu();
        }

        private void btnNhapHang_Click(object sender, RoutedEventArgs e)
        {
            NhapHang nhapHang = new NhapHang();
            nhapHang.Closed += AddProduct_Closed;
            nhapHang.Show();
        }

        private void btnTraHang_Click(object sender, RoutedEventArgs e)
        {
            TraHang traHang = new TraHang();
            traHang.Closed += AddProduct_Closed;
            traHang.Show();
        }
    }
}