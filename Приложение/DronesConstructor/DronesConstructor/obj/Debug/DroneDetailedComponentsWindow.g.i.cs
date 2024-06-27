﻿#pragma checksum "..\..\DroneDetailedComponentsWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E9DF1A2D6BD1A37AF08E2DF1B67EDA08A958758C486C4CDFCEC4484DB9ECCBA5"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using DronesConstructor;
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


namespace DronesConstructor {
    
    
    /// <summary>
    /// DroneDetailedComponentsWindow
    /// </summary>
    public partial class DroneDetailedComponentsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 51 "..\..\DroneDetailedComponentsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid motorDataGrid;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\DroneDetailedComponentsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid batteryDataGrid;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\DroneDetailedComponentsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid propDataGrid;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\DroneDetailedComponentsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid boardDataGrid;
        
        #line default
        #line hidden
        
        
        #line 149 "..\..\DroneDetailedComponentsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid escDataGrid;
        
        #line default
        #line hidden
        
        
        #line 173 "..\..\DroneDetailedComponentsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid moduleDataGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/DronesConstructor;component/dronedetailedcomponentswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\DroneDetailedComponentsWindow.xaml"
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
            this.motorDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 51 "..\..\DroneDetailedComponentsWindow.xaml"
            this.motorDataGrid.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.dataGrid_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 59 "..\..\DroneDetailedComponentsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddMotor_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 60 "..\..\DroneDetailedComponentsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditMotor_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 61 "..\..\DroneDetailedComponentsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteMotor_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.batteryDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 72 "..\..\DroneDetailedComponentsWindow.xaml"
            this.batteryDataGrid.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.dataGrid_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 85 "..\..\DroneDetailedComponentsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddBattery_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 86 "..\..\DroneDetailedComponentsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditBattery_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 87 "..\..\DroneDetailedComponentsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteBattery_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.propDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 101 "..\..\DroneDetailedComponentsWindow.xaml"
            this.propDataGrid.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.dataGrid_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 109 "..\..\DroneDetailedComponentsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddBattery_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 110 "..\..\DroneDetailedComponentsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditBattery_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 111 "..\..\DroneDetailedComponentsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteBattery_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.boardDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 125 "..\..\DroneDetailedComponentsWindow.xaml"
            this.boardDataGrid.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.dataGrid_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 133 "..\..\DroneDetailedComponentsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddBattery_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 134 "..\..\DroneDetailedComponentsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditBattery_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 135 "..\..\DroneDetailedComponentsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteBattery_Click);
            
            #line default
            #line hidden
            return;
            case 17:
            this.escDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 149 "..\..\DroneDetailedComponentsWindow.xaml"
            this.escDataGrid.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.dataGrid_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 18:
            
            #line 157 "..\..\DroneDetailedComponentsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddBattery_Click);
            
            #line default
            #line hidden
            return;
            case 19:
            
            #line 158 "..\..\DroneDetailedComponentsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditBattery_Click);
            
            #line default
            #line hidden
            return;
            case 20:
            
            #line 159 "..\..\DroneDetailedComponentsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteBattery_Click);
            
            #line default
            #line hidden
            return;
            case 21:
            this.moduleDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 173 "..\..\DroneDetailedComponentsWindow.xaml"
            this.moduleDataGrid.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.dataGrid_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 22:
            
            #line 181 "..\..\DroneDetailedComponentsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddBattery_Click);
            
            #line default
            #line hidden
            return;
            case 23:
            
            #line 182 "..\..\DroneDetailedComponentsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditBattery_Click);
            
            #line default
            #line hidden
            return;
            case 24:
            
            #line 183 "..\..\DroneDetailedComponentsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteBattery_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

