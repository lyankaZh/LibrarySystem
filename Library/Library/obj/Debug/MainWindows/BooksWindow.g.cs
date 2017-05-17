﻿#pragma checksum "..\..\..\MainWindows\BooksWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "652B8B9A3F96AA4BD5CF7CA8A38B1980"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Library;
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


namespace Library.MainWindows {
    
    
    /// <summary>
    /// BooksWindow
    /// </summary>
    public partial class BooksWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\MainWindows\BooksWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ToolBar toolBar;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\MainWindows\BooksWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addBookButton;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\MainWindows\BooksWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button editBookButton;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\MainWindows\BooksWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deleteButton;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\MainWindows\BooksWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\MainWindows\BooksWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox searchCriteriaComboBox;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\MainWindows\BooksWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searchTextTextBox;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\MainWindows\BooksWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button searchButton;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\MainWindows\BooksWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid booksTable;
        
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
            System.Uri resourceLocater = new System.Uri("/Library;component/mainwindows/bookswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindows\BooksWindow.xaml"
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
            
            #line 15 "..\..\..\MainWindows\BooksWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.editCommand_CanExecute);
            
            #line default
            #line hidden
            
            #line 15 "..\..\..\MainWindows\BooksWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.editCommand_Executed);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 16 "..\..\..\MainWindows\BooksWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.deleteCommand_CanExecute);
            
            #line default
            #line hidden
            
            #line 16 "..\..\..\MainWindows\BooksWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.deleteCommand_Executed);
            
            #line default
            #line hidden
            return;
            case 3:
            this.toolBar = ((System.Windows.Controls.ToolBar)(target));
            return;
            case 4:
            this.addBookButton = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\MainWindows\BooksWindow.xaml"
            this.addBookButton.Click += new System.Windows.RoutedEventHandler(this.addBookButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.editBookButton = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.deleteButton = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.label = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.searchCriteriaComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.searchTextTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 25 "..\..\..\MainWindows\BooksWindow.xaml"
            this.searchTextTextBox.GotFocus += new System.Windows.RoutedEventHandler(this.searchTextTextBox_GotFocus);
            
            #line default
            #line hidden
            
            #line 25 "..\..\..\MainWindows\BooksWindow.xaml"
            this.searchTextTextBox.LostFocus += new System.Windows.RoutedEventHandler(this.searchTextTextBox_LostFocus);
            
            #line default
            #line hidden
            return;
            case 10:
            this.searchButton = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\MainWindows\BooksWindow.xaml"
            this.searchButton.Click += new System.Windows.RoutedEventHandler(this.searchButton_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.booksTable = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

