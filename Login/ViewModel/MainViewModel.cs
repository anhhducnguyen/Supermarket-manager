using FontAwesome.Sharp;
using Login.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Login.ViewModel
{
    class MainViewModel : ObservableObject
    {
        private string _caption;
        private IconChar _icon;
        private ObservableObject _currentChildView;

        public ObservableObject CurrentChildView
        {
            get
            {
                return _currentChildView;
            }
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }
        public string Caption
        {
            get
            {
                return _caption;
            }
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }
        public IconChar Icon { get => _icon; set { _icon = value; OnPropertyChanged(nameof(Icon)); } }

        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowSanPhamViewCommand { get; }
        public ICommand ShowCustomerViewCommand { get; }
        public ICommand ShowEmployeeViewCommand { get; }
        public ICommand ShowOrderViewCommand { get; }
        public ICommand ShowSalesViewCommand { get; }
        public MainViewModel() {
            
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowSanPhamViewCommand = new ViewModelCommand(ExecuteShowSanPhamViewCommand);
            ShowCustomerViewCommand = new ViewModelCommand(ExecuteShowCustomerViewCommand);
            ShowEmployeeViewCommand = new ViewModelCommand(ExecuteShowEmployeemViewCommand);
            ShowOrderViewCommand = new ViewModelCommand(ExecuteShowOrderViewCommand);
            ShowSalesViewCommand = new ViewModelCommand(ExecuteShowSalesViewCommand);

            ExecuteShowHomeViewCommand(null);
        }

        private void ExecuteShowSalesViewCommand(object obj)
        {
            CurrentChildView = new SalesViewModel();
            Caption = "Thu Chi";
            Icon = IconChar.MoneyCheckDollar;
        }

        private void ExecuteShowOrderViewCommand(object obj)
        {
            CurrentChildView = new OrderViewModel();
            Caption = "Đơn Hàng";
            Icon = IconChar.FileInvoiceDollar;
            
        }

        private void ExecuteShowEmployeemViewCommand(object obj)
        {
            CurrentChildView = new EmployeeViewModel();
            Caption = "Nhân Viên";
            Icon = IconChar.Headset;
        }

        private void ExecuteShowCustomerViewCommand(object obj)
        {
            CurrentChildView = new CustomerViewModel();
            Caption = "Khách Hàng";
            Icon = IconChar.UserGroup;

        }

        private void ExecuteShowSanPhamViewCommand(object obj)
        {
            CurrentChildView = new SamPhamViewModel();
            Caption = "Sản Phẩm";
            Icon = IconChar.Box;
        }

        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
            Caption = "Tổng Quát";
            Icon = IconChar.Home;
        }
    }
}
