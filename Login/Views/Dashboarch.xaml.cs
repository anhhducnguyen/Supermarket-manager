using LiveCharts.Wpf;
using LiveCharts;
using Login.Oder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Login.Views.EmployeeView;
using Separator = LiveCharts.Wpf.Separator;

namespace Login.Views
{
    /// <summary>
    /// Interaction logic for Dashboarch.xaml
    /// </summary>
    public partial class Dashboarch : UserControl
    {
        public Dashboarch()
        {
            InitializeComponent();
            DataContext = this;
        }

        public class Invoice
        {
            public string InvoiceNumber { get; set; }
            public DateTime Date { get; set; }
            public decimal Amount { get; set; }
        }
        List<Invoice> recentInvoices = new List<Invoice>();
        public SeriesCollection ColumnSeriesCollection { get; set; } = new SeriesCollection();
        public List<string> Labels { get; set; } = new List<string>();


        SqlConnection Conn = new SqlConnection();
        string ConnectionString = "";

        private void UserCotrol_Loaded(object sender, RoutedEventArgs e)
        {
            cmbDashboarh.Items.Add("7 ngày trước");
            cmbDashboarh.Items.Add("Hôm qua");
            cmbDashboarh.Items.Add("Hôm nay");
            cmbDashboarh.Items.Add("Tháng này");
            cmbDashboarh.Items.Add("Tháng trước");
            cmbDashboarh.Items.Add("Lựa chọn khác");

            cmbDashboarh.SelectedIndex = 0;
            cmbDashboarh.SelectionChanged += cmbDashboarh_SelectionChanged;

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
            TotalNumberOfEmployees();
            TotalHoaDon();
            TotalDoanhThu();
            TotalDoanhThuTrongNgay();
            TotalDoanhThuTuanTruoc();
            columChart(sender, e);
            TotalHoaDonTrongNgay();
        }

        private void TotalNumberOfEmployees()
        {
            string sqlStr = "SELECT COUNT(MaNhanVien) FROM tblNhanVien";
            SqlCommand cmd = new SqlCommand(sqlStr, Conn);
            int employeeCount = (int)cmd.ExecuteScalar();
            txtTongNhanVien.Text = employeeCount.ToString();
        }

        private void TotalHoaDon()
        {
            string sqlStr = "SELECT COUNT(MaHoaDon) " +
                          "FROM tblHoaDon";
            SqlCommand cmd = new SqlCommand(sqlStr, Conn);
            int totalHoaDon = (int)cmd.ExecuteScalar();
            txtTongHoaDon.Text = totalHoaDon.ToString();

        }

        private void TotalDoanhThu()
        {

            string sqlStr = "SELECT SUM(TongTien) FROM tblHoaDon";
            SqlCommand cmd = new SqlCommand(sqlStr, Conn);
            object result = cmd.ExecuteScalar();

            if (result != DBNull.Value)
            {
                decimal totalTongTien = Convert.ToDecimal(result);
                txtDoanhThu.Text = totalTongTien.ToString("N0");
            }
            else
            {
                txtDoanhThu.Text = "0";
            }
        }

        private void TotalDoanhThuTrongNgay()
        {
            string sqlStr = "SELECT SUM(TongTien) FROM tblHoaDon WHERE NgayBan = (SELECT MAX(NgayBan) FROM tblHoaDon)";
            SqlCommand cmd = new SqlCommand(sqlStr, Conn);
            object result = cmd.ExecuteScalar();

            if (result != DBNull.Value)
            {
                decimal totalTongTienTrongNgay = Convert.ToDecimal(result);
                txtDoanhThuTrongNgay.Text = totalTongTienTrongNgay.ToString("N0");
            }
            else
            {
                txtDoanhThuTrongNgay.Text = "0";
            }
        }

        private void TotalHoaDonTrongNgay()
        {
            string sqlStr = "SELECT COUNT(MaHoaDon) FROM tblHoaDon WHERE NgayBan = (SELECT MAX(NgayBan) FROM tblHoaDon)";
            SqlCommand cmd = new SqlCommand(sqlStr, Conn);
            object result = cmd.ExecuteScalar();

            if (result != DBNull.Value)
            {
                decimal totalTongTienTrongNgay = Convert.ToDecimal(result);
                txtTongHoaDonTrongNgay.Text = totalTongTienTrongNgay.ToString();
            }
            else
            {
                txtTongHoaDonTrongNgay.Text = "0";
            }
        }

        private void TotalDoanhThuTuanTruoc()
        {
            DateTime today = DateTime.Now;
            int daysUntilPreviousWeek = (int)today.DayOfWeek + 7; // Ngày hôm nay + 7 ngày
            DateTime startOfWeek = today.AddDays(-daysUntilPreviousWeek);
            DateTime endOfWeek = startOfWeek.AddDays(6); // Tuần kết thúc vào ngày thứ 6 (Chủ Nhật).

            string sqlStr = "SELECT SUM(TongTien) FROM tblHoaDon WHERE NgayBan >= @StartOfWeek AND NgayBan <= @EndOfWeek";

            SqlCommand cmd = new SqlCommand(sqlStr, Conn);
            cmd.Parameters.AddWithValue("@StartOfWeek", startOfWeek);
            cmd.Parameters.AddWithValue("@EndOfWeek", endOfWeek);

            object result = cmd.ExecuteScalar();

            if (result != DBNull.Value)
            {
                decimal totalTongTienTuanTruoc = Convert.ToDecimal(result);
                txtDoanhThuTuanTruoc.Text = totalTongTienTuanTruoc.ToString("N0");
            }
            else
            {
                txtDoanhThuTuanTruoc.Text = "0";
            }
        }


        private void cmbDashboarh_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbDashboarh.SelectedItem != null)
            {
                string selectedValue = cmbDashboarh.SelectedItem.ToString();

                txtSelectedValue.Text = selectedValue.ToUpper();

                if (selectedValue == "7 ngày trước")
                {
                    columChart(sender, e);
                }
                else if (selectedValue == "Tháng trước")
                {
                    ColumnChart2(sender, e);
                }
            }

        }

        private void ListBox_Loaded(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT TOP 20 MaHoaDon,NgayBan,TongTien FROM [tblHoaDon] WHERE DAY(NgayBan) = DAY(GETDATE()) AND MONTH(NgayBan) = MONTH(GETDATE()) AND YEAR(NgayBan) = YEAR(GETDATE()) ORDER BY NgayBan DESC";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Invoice invoice = new Invoice();
                    invoice.InvoiceNumber = reader.GetString(0);
                    invoice.Date = reader.GetDateTime(1);
                    invoice.Amount = (decimal)reader.GetInt64(2);

                    recentInvoices.Add(invoice);
                }
                lbHoaDon.ItemsSource = recentInvoices;
                reader.Close();
            }

        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            OrderItem dataRowView = (OrderItem)((Button)e.Source).DataContext;
            OderDetails orderDetails = new OderDetails(dataRowView.OrderCode, dataRowView.OrderDate, dataRowView.EmployeeCode, dataRowView.CustomerCode, dataRowView.TotalMoney);
            orderDetails.Show();
        }

        private DataTable GetDoanhThu7NgayTruoc()
        {
            DataTable data = new DataTable();

            try
            {
                if (Conn.State != ConnectionState.Open) return data;

                DateTime today = DateTime.Now;
                DateTime startDate = today.AddDays(-7);
                DateTime endDate = today;

                string query = "SELECT CAST(tblHoaDon.[NgayBan] AS DATE) AS NgayBan, " +
                               "SUM(tblHoaDon.[TongTien]) AS TongTienNgay " +
                               "FROM tblHoaDon " +
                               "WHERE tblHoaDon.[NgayBan] >= @StartDate AND tblHoaDon.[NgayBan] <= @EndDate " +
                               "GROUP BY CAST(tblHoaDon.[NgayBan] AS DATE) " +
                               "ORDER BY CAST(tblHoaDon.[NgayBan] AS DATE);";

                using (SqlCommand command = new SqlCommand(query, Conn))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(data);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu từ cơ sở dữ liệu: " + ex.ToString());
            }
            return data;
        }

        private DataTable GetDoanhThuNgayHomQua()
        {
            DataTable data = new DataTable();

            try
            {
                if (Conn.State != ConnectionState.Open) return data;

                DateTime today = DateTime.Now;
                DateTime startDate = today.AddDays(-1); 
                DateTime endDate = today;

                string query = "SELECT CAST(tblHoaDon.[NgayBan] AS DATE) AS NgayBan, " +
                               "SUM(tblHoaDon.[TongTien]) AS TongTienNgay " +
                               "FROM tblHoaDon " +
                               "WHERE tblHoaDon.[NgayBan] >= @StartDate AND tblHoaDon.[NgayBan] <= @EndDate " +
                               "GROUP BY CAST(tblHoaDon.[NgayBan] AS DATE) " +
                               "ORDER BY CAST(tblHoaDon.[NgayBan] AS DATE);";

                using (SqlCommand command = new SqlCommand(query, Conn))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(data);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu từ cơ sở dữ liệu: " + ex.ToString());
            }
            return data;
        }

        private DataTable GetDoanhThuThangTruoc()
        {
            DataTable data = new DataTable();

            try
            {
                if (Conn.State != ConnectionState.Open) return data;

                DateTime today = DateTime.Now;
                DateTime startDate = new DateTime(today.Year, today.Month, 1).AddMonths(-1); // Ngày đầu tiên của tháng trước
                DateTime endDate = new DateTime(today.Year, today.Month, 1).AddDays(-1); // Ngày cuối cùng của tháng trước

                string query = "SELECT CONVERT(VARCHAR(10), tblHoaDon.[NgayBan], 103) AS NgayBan, " +
               "SUM(tblHoaDon.[TongTien]) AS TongTienNgay " +
               "FROM tblHoaDon " +
               "WHERE tblHoaDon.[NgayBan] >= @StartDate AND tblHoaDon.[NgayBan] <= @EndDate " +
               "GROUP BY CONVERT(VARCHAR(10), tblHoaDon.[NgayBan], 103) " +
               "ORDER BY CONVERT(VARCHAR(10), tblHoaDon.[NgayBan], 103);";

                using (SqlCommand command = new SqlCommand(query, Conn))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(data);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu từ cơ sở dữ liệu: " + ex.ToString());
            }
            return data;
        }

        private void ColumnChart2(object sender, RoutedEventArgs e)
        {
            ColumnSeriesCollection.Clear();

            try
            {
                if (Conn.State != ConnectionState.Open) return;

                DataTable data = GetDoanhThuThangTruoc();
                List<string> dateLabels = new List<string>();

                ColumnSeries columnSeries = new ColumnSeries
                {
                    Title = "Tổng",
                    Values = new ChartValues<int>(),
                    DataLabels = false,
                    Fill = new SolidColorBrush(Color.FromRgb(6, 148, 26)),
                    Stroke = new SolidColorBrush(Colors.White),
                };

                foreach (DataRow row in data.Rows)
                {
                    int total = int.Parse(row["TongTienNgay"].ToString());
                    DateTime date = DateTime.Parse(row["NgayBan"].ToString());
                    dateLabels.Add(date.ToString("dd/MM"));
                    columnSeries.Values.Add(total);
                }

                Labels = dateLabels;
                Axis axisX = new Axis
                {
                    Title = "Date",
                    Labels = Labels,
                    Separator = new Separator
                    {
                        Step = 1,
                        IsEnabled = false
                    },
                    MinValue = 0,
                    MaxValue = Labels.Count - 1,
                };
                Axis axisY = new Axis
                {
                    Title = "Total",
                    LabelFormatter = value => FormatYAxisLabel(value),
                    MinValue = 0
                };

                columnSeries.DataLabels = false;
                columnSeries.LabelPoint = point => point.Y.ToString("N0");

                ColumnSeriesCollection.Add(columnSeries);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu từ cơ sở dữ liệu: " + ex.ToString());
            }
            DataContext = this;
        }


        private void columChart(object sender, RoutedEventArgs e)
        {
            ColumnSeriesCollection.Clear();

            try
            {
                if (Conn.State != ConnectionState.Open) return;
                DataTable data = GetDoanhThu7NgayTruoc();
                List<string> dateLabels = new List<string>();

                ColumnSeries columnSeries = new ColumnSeries
                {
                    Title = "Tổng",
                    Values = new ChartValues<decimal>(), // Change int to decimal to match your data
                    DataLabels = false,
                    //Fill = new SolidColorBrush(Color.FromRgb(0, 102, 204)),
                    Fill = new SolidColorBrush(Color.FromRgb(6, 148, 26)),
                    Stroke = new SolidColorBrush(Colors.White),
                };

                foreach (DataRow row in data.Rows)
                {
                    decimal total = Convert.ToDecimal(row["TongTienNgay"]);
                    DateTime date = DateTime.Parse(row["NgayBan"].ToString());
                    dateLabels.Add(date.ToString("dd/MM"));
                    columnSeries.Values.Add(total);
                }
                Labels = dateLabels;

                Axis axisX = new Axis
                {
                    //Title = "Date",
                    Labels = Labels,
                    Separator = new Separator
                    {
                        Step = 1,
                        IsEnabled = false
                    },
                    MinValue = 0,
                    MaxValue = Labels.Count - 1,
                };

                Axis axisY = new Axis
                {
                    //Title = "Total",
                    //LabelFormatter = value => FormatYAxisLabel(value),
                    MinValue = 0
                };

                columnSeries.DataLabels = false;
                columnSeries.LabelPoint = point => point.Y.ToString("N0");

                ColumnSeriesCollection.Add(columnSeries);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu từ cơ sở dữ liệu: " + ex.ToString());
            }

            DataContext = this;
        }


        private string FormatYAxisLabel(double value)
        {
            if (value >= 1000000) // 1,000,000 (1 million)
            {
                return (value / 1000000).ToString("N0") + "tr"; // Format as "5tr" for 5,000,000
            }
            else if (value >= 1000) // 1,000 (1 thousand)
            {
                return (value / 1000).ToString("N0") + "k"; // Format as "500k" for 500,000
            }
            else
            {
                return value.ToString("N0"); // Format as a regular number
            }
        }

        public string YourFormatMethod(double value)
        {
            return value.ToString("N0");
        }

        public double YourInverseFormatMethod(string value)
        {
            if (double.TryParse(value, out double result))
            {
                return result;
            }
            return 0.0;
        }



    }
}
