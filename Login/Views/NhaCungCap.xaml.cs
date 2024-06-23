using Login.WindowView;
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

namespace Login.Views
{
    public class nhacungcap
    {
        public string id { get; set; }
        public string name { get; set; }
        public bool IsSelected { get; set; }
    }
    /// <summary>
    /// Interaction logic for NhaCungCap.xaml
    /// </summary>
    public partial class NhaCungCap : UserControl
    {
        ObservableCollection<nhacungcap> ncc = new ObservableCollection<nhacungcap>();
        public NhaCungCap()
        {
            InitializeComponent();
        }
        SqlConnection Conn = new SqlConnection();
        string ConnectionString = "";
        private void NapDuLieuTuMayChu()
        {
            dgProduct.ItemsSource = null;
            ncc.Clear();
            if (Conn.State != ConnectionState.Open) return;
            SqlCommand command = new SqlCommand("SELECT * FROM tblNhaCungCap", Conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                nhacungcap nhacungcap = new nhacungcap();
                nhacungcap.id = reader.GetString(0);
                nhacungcap.name = reader.GetString(1);
                if (nhacungcap.id != "")
                {
                    ncc.Add(nhacungcap);
                }
            }
            reader.Close();
            //products.RemoveAt(products.Count);
            // set ItemsSource of DataGrid to List
            dgProduct.ItemsSource = ncc;
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
            for (int i = 0; i < ncc.Count; i++)
            {
                ncc[i].IsSelected = true;
            }
            dgProduct.ItemsSource = null;
            dgProduct.ItemsSource = ncc;
        }

        private void chkSelectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            IsAllSelected = false;
            for (int i = 0; i < ncc.Count; i++)
            {
                ncc[i].IsSelected = false;
            }
            NapDuLieuData();

            for (int i = 0; i < ncc.Count; i++)
            {
                if (!ncc[i].IsSelected)
                {
                    String valueToRemove = ncc[i].id;
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
            dgProduct.ItemsSource = ncc;
        }
        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            addNCC addNCC = new addNCC();
            addNCC.Closed += AddProduct_Closed;
            addNCC.Show();
        }
        private void AddProduct_Closed(object sender, EventArgs e)
        {
            NapDuLieuTuMayChu();
        }
        List<String> listCode = new List<string>();

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            btnDelete.Visibility = Visibility.Visible;
            for (int i = 0; i < ncc.Count; i++)
            {
                if (ncc[i].IsSelected)
                {
                    listCode.Add(ncc[i].id);
                }
            }
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < ncc.Count; i++)
            {
                if (!ncc[i].IsSelected)
                {
                    String valueToRemove = ncc[i].id;
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
                ncc.Clear();
                if (Conn.State != ConnectionState.Open) return;
                SqlCommand command = new SqlCommand("SELECT * FROM tblNhaCungCap WHERE MaNhaCungCap like '%" + tbnSearch.Text + "%'", Conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    nhacungcap nhacungcap = new nhacungcap();
                    nhacungcap.id = reader.GetString(0);
                    nhacungcap.name = reader.GetString(1);
                    if (nhacungcap.id != "")
                    {
                        ncc.Add(nhacungcap);
                    }
                }
                reader.Close();
                //products.RemoveAt(products.Count);
                // set ItemsSource of DataGrid to List
                dgProduct.ItemsSource = ncc;
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            nhacungcap dataRowView = (nhacungcap)((System.Windows.Controls.Button)e.Source).DataContext;
            editNcc editNcc = new editNcc(dataRowView.id, dataRowView.name);
            editNcc.Closed += AddProduct_Closed;
            editNcc.Show();

        }

        private void ButtonXoa_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Bạn có chắc chắn muốn xoá không?", "Xác nhận xoá", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                nhacungcap dataRowView = (nhacungcap)((System.Windows.Controls.Button)e.Source).DataContext;
                string sqlStr = "DELETE FROM tblNhaCungCap WHERE MaNhaCungCap =  N'" + dataRowView.id + "'";
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
    }
}
