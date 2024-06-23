using Login.Oder;
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
    /// Interaction logic for LichSuNV.xaml
    /// </summary>
    public partial class LichSuNV : UserControl
    {
        ObservableCollection<OrderItem> orders = new ObservableCollection<OrderItem>();
        string id = string.Empty;
        public LichSuNV(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        SqlConnection Conn = new SqlConnection();
        string ConnectionString = "";

        private void NapDuLieuHoaDon()
        {
            dgOrder.ItemsSource = null;
            orders.Clear();
            if (Conn.State != ConnectionState.Open) return;
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblHoaDon where MaNhanVien ='" + id + "' ORDER BY NgayBan DESC, MaHoaDon DESC", Conn);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                OrderItem order = new OrderItem();
                order.IsSelected = false;
                order.OrderCode = reader.GetString(0);
                order.OrderDate = reader.GetDateTime(1);
                order.EmployeeCode = reader.GetString(2);
                if (reader.IsDBNull(3))
                {
                    order.CustomerCode = null;
                }
                else
                {
                    order.CustomerCode = reader.GetString(3);
                }
                order.TotalMoney = (Decimal)reader.GetInt64(4);
                if (order.OrderCode != "")
                {
                    orders.Add(order);
                }
            }
            reader.Close();
            //Thiết lập cho hiển thị trên DataGrid
            dgOrder.ItemsSource = orders;
        }







        private void txtSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            txtSearch.Text = "";

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                ConnectionString = @"Data Source=DESKTOP-IKSFK82\SQLEXPRESS;Initial Catalog=QuanLyBanHangNhanh;Integrated Security=True;";
                //ConnectionString = @"Data Source=.\NAM;Initial Catalog=QuanLyBanHangNhanh;Integrated Security=True;";
                Conn.ConnectionString = ConnectionString;
                Conn.Open();
                NapDuLieuHoaDon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kết nối dữ liệu " + ex.ToString());
            }
        }

        public bool IsAllSelected { get; set; }

        private void chkSelectAll_Checked(object sender, RoutedEventArgs e)
        {
            IsAllSelected = true;
            for (int i = 0; i < orders.Count; i++)
            {
                orders[i].IsSelected = true;
            }
            dgOrder.ItemsSource = null;
            dgOrder.ItemsSource = orders;
        }

        private void chkSelectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            IsAllSelected = false;
            for (int i = 0; i < orders.Count; i++)
            {
                orders[i].IsSelected = false;
            }
            dgOrder.ItemsSource = null;
            dgOrder.ItemsSource = orders;

            for (int i = 0; i < orders.Count; i++)
            {
                if (!orders[i].IsSelected)
                {
                    String valueToRemove = orders[i].OrderCode;
                    for (int j = listCode.Count - 1; j >= 0; j--)
                    {
                        if (listCode[i] == valueToRemove)
                        {
                            listCode.RemoveAt(j);
                        }
                    }
                }
            }
            if (listCode.Count == 0)
            {
                //btnDelete.Visibility = Visibility.Hidden;
            }
        }

        List<String> listCode = new List<String>();

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            //btnDelete.Visibility = Visibility.Visible;
            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].IsSelected)
                {
                    listCode.Add(orders[i].OrderCode);
                }
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < orders.Count; i++)
            {
                if (!orders[i].IsSelected)
                {
                    String valueToRemove = orders[i].OrderCode;
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
                //btnDelete.Visibility = Visibility.Hidden;
            }
        }

        private void btSearch_Click(object sender, RoutedEventArgs e)
        {
            if (txtSearch.Text == "")
            {
                NapDuLieuHoaDon();
            }
            else
            {
                dgOrder.ItemsSource = null;
                orders.Clear();
                if (Conn.State != ConnectionState.Open) return;
                SqlCommand command = new SqlCommand("SELECT * FROM tblHoaDon WHERE MaHoaDon like '%" + txtSearch.Text + "%' and MaNhanVien like '%" + id + "%'", Conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    OrderItem order = new OrderItem();
                    order.IsSelected = false;
                    order.OrderCode = reader.GetString(0);
                    order.OrderDate = reader.GetDateTime(1);
                    order.EmployeeCode = reader.GetString(2);
                    if (reader.IsDBNull(3))
                    {
                        order.CustomerCode = null;
                    }
                    else
                    {
                        order.CustomerCode = reader.GetString(3);
                    }
                    order.TotalMoney = (Decimal)reader.GetInt64(4);
                    if (order.OrderCode != "")
                    {
                        orders.Add(order);
                    }
                }
                reader.Close();
                dgOrder.ItemsSource = orders;
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            OrderItem dataRowView = (OrderItem)((Button)e.Source).DataContext;
            OderDetails orderDetails = new OderDetails(dataRowView.OrderCode, dataRowView.OrderDate, dataRowView.EmployeeCode, dataRowView.CustomerCode, dataRowView.TotalMoney);
            orderDetails.Show();
        }

        

        private void btload_Click(object sender, RoutedEventArgs e)
        {
            NapDuLieuHoaDon();
            //txtSearch.Text = string.Empty;
            txtSearch.Text = "Tìm theo mã hóa đơn...";
        }

    }
}
