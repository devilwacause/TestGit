﻿#pragma checksum "..\..\HDDs.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "EAAFACB23BC3EA520A3C4DCED9836DC38C461B9E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace WidgetDesktop {
    
    
    /// <summary>
    /// HDDs
    /// </summary>
    public partial class HDDs : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 4 "..\..\HDDs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WidgetDesktop.HDDs Hdds;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\HDDs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel HDD_Stack;
        
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
            System.Uri resourceLocater = new System.Uri("/WidgetDesktop;component/hdds.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\HDDs.xaml"
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
            this.Hdds = ((WidgetDesktop.HDDs)(target));
            
            #line 5 "..\..\HDDs.xaml"
            this.Hdds.Closing += new System.ComponentModel.CancelEventHandler(this.Hdds_Closing);
            
            #line default
            #line hidden
            
            #line 9 "..\..\HDDs.xaml"
            this.Hdds.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.Hdds_MouseUp);
            
            #line default
            #line hidden
            
            #line 10 "..\..\HDDs.xaml"
            this.Hdds.MouseEnter += new System.Windows.Input.MouseEventHandler(this.Hdds_MouseEnter);
            
            #line default
            #line hidden
            
            #line 11 "..\..\HDDs.xaml"
            this.Hdds.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Hdds_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 2:
            this.HDD_Stack = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
