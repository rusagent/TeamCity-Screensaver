﻿#pragma checksum "..\..\ScreenSaver.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3D53BC3548961123EAB80C85E09CA823"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.239
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using Mo.TeamCityScreensaver.controls;
using Mo.TeamCityScreensaver.convert;
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


namespace Mo.TeamCityScreensaver {
    
    
    /// <summary>
    /// ScreenSaver
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class ScreenSaver : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\ScreenSaver.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        private System.Windows.Controls.ItemsControl ProjectsPanelCtrl;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\ScreenSaver.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        private Mo.TeamCityScreensaver.controls.ProjectsControl ProjectsCtrl;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TeamCityScreensaver;component/screensaver.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ScreenSaver.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 4 "..\..\ScreenSaver.xaml"
            ((Mo.TeamCityScreensaver.ScreenSaver)(target)).MouseMove += new System.Windows.Input.MouseEventHandler(this.WindowMouseMove);
            
            #line default
            #line hidden
            
            #line 5 "..\..\ScreenSaver.xaml"
            ((Mo.TeamCityScreensaver.ScreenSaver)(target)).PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.WindowPreviewKeyDown);
            
            #line default
            #line hidden
            
            #line 5 "..\..\ScreenSaver.xaml"
            ((Mo.TeamCityScreensaver.ScreenSaver)(target)).Loaded += new System.Windows.RoutedEventHandler(this.WindowLoaded);
            
            #line default
            #line hidden
            
            #line 5 "..\..\ScreenSaver.xaml"
            ((Mo.TeamCityScreensaver.ScreenSaver)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.WindowClosing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ProjectsPanelCtrl = ((System.Windows.Controls.ItemsControl)(target));
            return;
            case 3:
            this.ProjectsCtrl = ((Mo.TeamCityScreensaver.controls.ProjectsControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
