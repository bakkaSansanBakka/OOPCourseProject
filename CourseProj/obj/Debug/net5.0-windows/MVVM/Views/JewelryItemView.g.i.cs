﻿#pragma checksum "..\..\..\..\..\MVVM\Views\JewelryItemView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3154088A42DA87DD2760C490B6C0D516CFF00380"
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
    /// JewelryItemView
    /// </summary>
    public partial class JewelryItemView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 111 "..\..\..\..\..\MVVM\Views\JewelryItemView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ImageDownloadButton;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\..\..\..\MVVM\Views\JewelryItemView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Img;
        
        #line default
        #line hidden
        
        
        #line 134 "..\..\..\..\..\MVVM\Views\JewelryItemView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddOrEditButton;
        
        #line default
        #line hidden
        
        
        #line 146 "..\..\..\..\..\MVVM\Views\JewelryItemView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackButton;
        
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
            System.Uri resourceLocater = new System.Uri("/CourseProj;component/mvvm/views/jewelryitemview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\MVVM\Views\JewelryItemView.xaml"
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
            
            #line 97 "..\..\..\..\..\MVVM\Views\JewelryItemView.xaml"
            ((System.Windows.Controls.TextBox)(target)).PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.PriceValidationTextBox);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ImageDownloadButton = ((System.Windows.Controls.Button)(target));
            
            #line 121 "..\..\..\..\..\MVVM\Views\JewelryItemView.xaml"
            this.ImageDownloadButton.Click += new System.Windows.RoutedEventHandler(this.ImageDownloadButton_OnClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Img = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.AddOrEditButton = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.BackButton = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

