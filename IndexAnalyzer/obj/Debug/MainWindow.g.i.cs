﻿#pragma checksum "..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B07C7FAD8558F843612FF8ED97D3B1C4D89B2D95"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using IndexAnalyzer;
using IndexAnalyzer.Behaviors;
using IndexAnalyzer.Objects;
using System;
using System.Collections;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interactivity;
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


namespace IndexAnalyzer {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 55 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtFilePath;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSelectFile;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgIndexDefinitions;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chkIgnoreHeader;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chkIgnoreFooter;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chkIncludeRowIdColumn;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chkIncludeFlagColumn;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnImportDefinitions;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnExportDefinitions;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClearDefinitions;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAnalyzeFile;
        
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
            System.Uri resourceLocater = new System.Uri("/IndexAnalyzer;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
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
            
            #line 12 "..\..\MainWindow.xaml"
            ((IndexAnalyzer.MainWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 39 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_ImportTemplate_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 44 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_ExportTemplate_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 50 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Exit_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtFilePath = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.btnSelectFile = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\MainWindow.xaml"
            this.btnSelectFile.Click += new System.Windows.RoutedEventHandler(this.btnSelectFile_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.dgIndexDefinitions = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 8:
            this.chkIgnoreHeader = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 9:
            this.chkIgnoreFooter = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 10:
            this.chkIncludeRowIdColumn = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 11:
            this.chkIncludeFlagColumn = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 12:
            this.btnImportDefinitions = ((System.Windows.Controls.Button)(target));
            
            #line 115 "..\..\MainWindow.xaml"
            this.btnImportDefinitions.Click += new System.Windows.RoutedEventHandler(this.btnImportDefinitions_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.btnExportDefinitions = ((System.Windows.Controls.Button)(target));
            
            #line 116 "..\..\MainWindow.xaml"
            this.btnExportDefinitions.Click += new System.Windows.RoutedEventHandler(this.btnExportDefinitions_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.btnClearDefinitions = ((System.Windows.Controls.Button)(target));
            
            #line 117 "..\..\MainWindow.xaml"
            this.btnClearDefinitions.Click += new System.Windows.RoutedEventHandler(this.btnClearDefinitions_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.btnAnalyzeFile = ((System.Windows.Controls.Button)(target));
            
            #line 124 "..\..\MainWindow.xaml"
            this.btnAnalyzeFile.Click += new System.Windows.RoutedEventHandler(this.btnAnalyzeFile_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

