﻿#pragma checksum "..\..\..\..\..\MVVM\Views\OrderClientView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A4EF4F06847D707B8E81B7C0F20B3CD0472942DA"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using CourseProj.MVVM.Views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace CourseProj.MVVM.Views {
    
    
    /// <summary>
    /// OrderClientView
    /// </summary>
    public partial class OrderClientView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 139 "..\..\..\..\..\MVVM\Views\OrderClientView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PhoneTextBox;
        
        #line default
        #line hidden
        
        
        #line 174 "..\..\..\..\..\MVVM\Views\OrderClientView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox MaterialComboBox;
        
        #line default
        #line hidden
        
        
        #line 249 "..\..\..\..\..\MVVM\Views\OrderClientView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CardMonthTextBox;
        
        #line default
        #line hidden
        
        
        #line 270 "..\..\..\..\..\MVVM\Views\OrderClientView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CardYearTextBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CourseProj;component/mvvm/views/orderclientview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\MVVM\Views\OrderClientView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.PhoneTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 149 "..\..\..\..\..\MVVM\Views\OrderClientView.xaml"
            this.PhoneTextBox.LostFocus += new System.Windows.RoutedEventHandler(this.PhoneTextBox_OnLostFocus);
            
            #line default
            #line hidden
            return;
            case 2:
            this.MaterialComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            
            #line 233 "..\..\..\..\..\MVVM\Views\OrderClientView.xaml"
            ((System.Windows.Controls.TextBox)(target)).PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.CardNumberValidation);
            
            #line default
            #line hidden
            return;
            case 4:
            this.CardMonthTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 256 "..\..\..\..\..\MVVM\Views\OrderClientView.xaml"
            this.CardMonthTextBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.CardMonthValidation);
            
            #line default
            #line hidden
            
            #line 257 "..\..\..\..\..\MVVM\Views\OrderClientView.xaml"
            this.CardMonthTextBox.LostFocus += new System.Windows.RoutedEventHandler(this.CardMonthTextBox_OnLostFocus);
            
            #line default
            #line hidden
            return;
            case 5:
            this.CardYearTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 276 "..\..\..\..\..\MVVM\Views\OrderClientView.xaml"
            this.CardYearTextBox.LostFocus += new System.Windows.RoutedEventHandler(this.CardYearTextBox_OnLostFocus);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

