using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using Login.Oder;
using Login.WindowView;

namespace Login.Views
{
    /// <summary>
    /// Interaction logic for OrderView.xaml
    /// </summary>

    public class OrderItem
    {
        public bool IsSelected { get; set; }
        public string OrderCode { get; set; }
        public DateTime OrderDate { get; set; }
        public string EmployeeCode { get; set; }
        public string CustomerCode { get; set; }
        public decimal TotalMoney { get; set; }
    }
    public partial class OrderView : UserControl
    {
        ObservableCollection<OrderItem> orders = new ObservableCollection<OrderItem>();
        public OrderView()
        {
            InitializeComponent();
        }

        SqlConnection Conn = new SqlConnection();
        string ConnectionString = "";

        private void NapDuLieuHoaDon()
        {
            dgOrder.ItemsSource = null;
            orders.Clear();
            if (Conn.State != ConnectionState.Open) return;
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblHoaDon ORDER BY NgayBan DESC, MaHoaDon DESC", Conn);

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
                order.TotalMoney = (decimal)reader.GetInt64(4);
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

        private void btAddProduct_Click(object sender, RoutedEventArgs e)
        {
            //AddOder order = new AddOder("Admin");
            //order.Closed += AddOder_Closed;
            //order.Show();
        }

        private void AddOder_Closed(object sender, EventArgs e)
        {
            NapDuLieuHoaDon();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            NapDuLieuHoaDon();
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

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < listCode.Count; i++)
            {
                string sqlStr = "DELETE FROM tblChiTietHoaDon WHERE MaHoaDon =  N'" + listCode[i] + "'" +
                    "DELETE FROM tblHoaDon WHERE MaHoaDon = N'" + listCode[i] + "'";
                listCode.RemoveAt(i);
                SqlCommand cmd = new SqlCommand(sqlStr, Conn);
                cmd.ExecuteNonQuery();
            }
            NapDuLieuHoaDon();
            //btnDelete.Visibility = Visibility.Hidden;
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
                SqlCommand command = new SqlCommand("SELECT * FROM tblHoaDon WHERE MaHoaDon like '%" + txtSearch.Text + "%'", Conn);
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
                    order.TotalMoney = (decimal)reader.GetInt64(4);
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

        private void ButtonXoa_Click(object sender, RoutedEventArgs e)
        {
            OrderItem dataRowView = (OrderItem)((Button)e.Source).DataContext;
            string sqlStr = "DELETE FROM tblChiTietHoaDon WHERE MaHoaDon =  N'" + dataRowView.OrderCode + "'" +
                "DELETE FROM tblHoaDon WHERE MaHoaDon = N'" + dataRowView.OrderCode + "'";
            SqlCommand cmd = new SqlCommand(sqlStr, Conn);
            cmd.ExecuteNonQuery();
            NapDuLieuHoaDon();
        }

        private void btload_Click(object sender, RoutedEventArgs e)
        {
            NapDuLieuHoaDon();
            //txtSearch.Text = string.Empty;
            txtSearch.Text = "Tìm theo mã hóa đơn...";
        }
    }
}