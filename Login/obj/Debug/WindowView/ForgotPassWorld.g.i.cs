﻿#pragma checksum "..\..\..\WindowView\ForgotPassWorld.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2DB1317DCB6EF47BF69DEC5455F0A3B69217EEDCA34A6DDA0CAF1AFA5F6195C8"
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


namespace Login.WindowView {
    
    
    /// <summary>
    /// ForgotPassWorld
    /// </summary>
    public partial class ForgotPassWorld : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\WindowView\ForgotPassWorld.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txt_mkcu;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\WindowView\ForgotPassWorld.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txt_mkmoi1;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\WindowView\ForgotPassWorld.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txt_mkmoi2;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\WindowView\ForgotPassWorld.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lb_thongbao;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\WindowView\ForgotPassWorld.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_boqua;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\WindowView\ForgotPassWorld.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_doimk;
        
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
            System.Uri resourceLocater = new System.Uri("/Login;component/windowview/forgotpassworld.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\WindowView\ForgotPassWorld.xaml"
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
            this.txt_mkcu = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 10 "..\..\..\WindowView\ForgotPassWorld.xaml"
            this.txt_mkcu.KeyDown += new System.Windows.Input.KeyEventHandler(this.txt_mkcu_KeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txt_mkmoi1 = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 11 "..\..\..\WindowView\ForgotPassWorld.xaml"
            this.txt_mkmoi1.KeyDown += new System.Windows.Input.KeyEventHandler(this.txt_mkmoi1_KeyDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txt_mkmoi2 = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 4:
            this.lb_thongbao = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.bt_boqua = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\WindowView\ForgotPassWorld.xaml"
            this.bt_boqua.Click += new System.Windows.RoutedEventHandler(this.bt_boqua_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.bt_doimk = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\WindowView\ForgotPassWorld.xaml"
            this.bt_doimk.Click += new System.Windows.RoutedEventHandler(this.bt_doimk_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
