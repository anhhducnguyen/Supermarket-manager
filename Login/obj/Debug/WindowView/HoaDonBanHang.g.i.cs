// Updated by XamlIntelliSenseFileGenerator 12/11/2023 08:35:38
#pragma checksum "..\..\..\WindowView\HoaDonBanHang.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C66B1C922EED84F1766C4E5A6BE862C557BC4C595534912769434C6DADC9DAC9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Login.WindowView;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Login.WindowView
{


    /// <summary>
    /// HoaDonBanHang
    /// </summary>
    public partial class HoaDonBanHang : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Login;component/windowview/hoadonbanhang.xaml", System.UriKind.Relative);

#line 1 "..\..\..\WindowView\HoaDonBanHang.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:

#line 12 "..\..\..\WindowView\HoaDonBanHang.xaml"
                    ((Login.WindowView.HoaDonBanHang)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);

#line default
#line hidden

#line 13 "..\..\..\WindowView\HoaDonBanHang.xaml"
                    ((Login.WindowView.HoaDonBanHang)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);

#line default
#line hidden
                    return;
                case 2:
                    this.print = ((System.Windows.Controls.Grid)(target));
                    return;
                case 3:
                    this.btMinimize = ((System.Windows.Controls.Button)(target));

#line 36 "..\..\..\WindowView\HoaDonBanHang.xaml"
                    this.btMinimize.Click += new System.Windows.RoutedEventHandler(this.btMinimize_Click);

#line default
#line hidden
                    return;
                case 4:
                    this.btQuit = ((System.Windows.Controls.Button)(target));

#line 67 "..\..\..\WindowView\HoaDonBanHang.xaml"
                    this.btQuit.Click += new System.Windows.RoutedEventHandler(this.btQuit_Click);

#line default
#line hidden
                    return;
                case 5:
                    this.txtMaDonHang = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 6:
                    this.txtNgayBan = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 7:
                    this.txtMaNhanVien = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 8:
                    this.txtMaKhachHang = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 9:
                    this.dgProducts = ((System.Windows.Controls.DataGrid)(target));
                    return;
                case 10:
                    this.btIn = ((System.Windows.Controls.Button)(target));

#line 177 "..\..\..\WindowView\HoaDonBanHang.xaml"
                    this.btIn.Click += new System.Windows.RoutedEventHandler(this.In_Click);

#line default
#line hidden
                    return;
                case 11:
                    this.btThoat = ((System.Windows.Controls.Button)(target));

#line 210 "..\..\..\WindowView\HoaDonBanHang.xaml"
                    this.btThoat.Click += new System.Windows.RoutedEventHandler(this.Thoat_Click);

#line default
#line hidden
                    return;
                case 12:
                    this.txtTongTien = ((System.Windows.Controls.TextBox)(target));
                    return;
            }
            this._contentLoaded = true;
        }
    }
}

