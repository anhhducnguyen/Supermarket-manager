﻿#pragma checksum "..\..\..\Views\SamPhamView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A214A73344B982DDC1BEF4AAFE188D0433550275D535522D1B486AC5196BD653"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FontAwesome.Sharp;
using Login.Views;
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


namespace Login.Views {
    
    
    /// <summary>
    /// SamPhamView
    /// </summary>
    public partial class SamPhamView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 156 "..\..\..\Views\SamPhamView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddProduct;
        
        #line default
        #line hidden
        
        
        #line 189 "..\..\..\Views\SamPhamView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDelete;
        
        #line default
        #line hidden
        
        
        #line 223 "..\..\..\Views\SamPhamView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNhapHang;
        
        #line default
        #line hidden
        
        
        #line 256 "..\..\..\Views\SamPhamView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnTraHang;
        
        #line default
        #line hidden
        
        
        #line 293 "..\..\..\Views\SamPhamView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbnSearch;
        
        #line default
        #line hidden
        
        
        #line 307 "..\..\..\Views\SamPhamView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSearch;
        
        #line default
        #line hidden
        
        
        #line 341 "..\..\..\Views\SamPhamView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnReLoad;
        
        #line default
        #line hidden
        
        
        #line 378 "..\..\..\Views\SamPhamView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgProduct;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Login;component/views/samphamview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\SamPhamView.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\Views\SamPhamView.xaml"
            ((Login.Views.SamPhamView)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnAddProduct = ((System.Windows.Controls.Button)(target));
            
            #line 165 "..\..\..\Views\SamPhamView.xaml"
            this.btnAddProduct.Click += new System.Windows.RoutedEventHandler(this.btnAddProduct_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnDelete = ((System.Windows.Controls.Button)(target));
            
            #line 199 "..\..\..\Views\SamPhamView.xaml"
            this.btnDelete.Click += new System.Windows.RoutedEventHandler(this.btnDelete_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnNhapHang = ((System.Windows.Controls.Button)(target));
            
            #line 232 "..\..\..\Views\SamPhamView.xaml"
            this.btnNhapHang.Click += new System.Windows.RoutedEventHandler(this.btnNhapHang_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnTraHang = ((System.Windows.Controls.Button)(target));
            
            #line 265 "..\..\..\Views\SamPhamView.xaml"
            this.btnTraHang.Click += new System.Windows.RoutedEventHandler(this.btnTraHang_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.tbnSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 305 "..\..\..\Views\SamPhamView.xaml"
            this.tbnSearch.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tbnSearch_TextChanged);
            
            #line default
            #line hidden
            
            #line 305 "..\..\..\Views\SamPhamView.xaml"
            this.tbnSearch.GotFocus += new System.Windows.RoutedEventHandler(this.tbnSearch_GotFocus);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnSearch = ((System.Windows.Controls.Button)(target));
            
            #line 317 "..\..\..\Views\SamPhamView.xaml"
            this.btnSearch.Click += new System.Windows.RoutedEventHandler(this.btnSearch_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnReLoad = ((System.Windows.Controls.Button)(target));
            
            #line 346 "..\..\..\Views\SamPhamView.xaml"
            this.btnReLoad.Click += new System.Windows.RoutedEventHandler(this.btnReLoad_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.dgProduct = ((System.Windows.Controls.DataGrid)(target));
            
            #line 380 "..\..\..\Views\SamPhamView.xaml"
            this.dgProduct.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 10:
            
            #line 386 "..\..\..\Views\SamPhamView.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.chkSelectAll_Checked);
            
            #line default
            #line hidden
            
            #line 386 "..\..\..\Views\SamPhamView.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.chkSelectAll_Unchecked);
            
            #line default
            #line hidden
            break;
            case 11:
            
            #line 391 "..\..\..\Views\SamPhamView.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.CheckBox_Unchecked);
            
            #line default
            #line hidden
            
            #line 391 "..\..\..\Views\SamPhamView.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.CheckBox_Checked);
            
            #line default
            #line hidden
            break;
            case 12:
            
            #line 407 "..\..\..\Views\SamPhamView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonEdit_Click);
            
            #line default
            #line hidden
            break;
            case 13:
            
            #line 410 "..\..\..\Views\SamPhamView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonXoa_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

