﻿#pragma checksum "..\..\..\List_Recipe.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4F905806C9B51C0CB8A841972F78E2FCF38CFA97"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CookeBookClient;
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


namespace CookeBookClient {
    
    
    /// <summary>
    /// List_Recipe
    /// </summary>
    public partial class List_Recipe : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\List_Recipe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddRecipe;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\List_Recipe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDeleteRecipe;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\List_Recipe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listViewRecipes;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\List_Recipe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBack;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CookeBookClient;component/list_recipe.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\List_Recipe.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\..\List_Recipe.xaml"
            ((CookeBookClient.List_Recipe)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnAddRecipe = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\List_Recipe.xaml"
            this.btnAddRecipe.Click += new System.Windows.RoutedEventHandler(this.btnAddRecipe_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnDeleteRecipe = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\List_Recipe.xaml"
            this.btnDeleteRecipe.Click += new System.Windows.RoutedEventHandler(this.btnDeleteRecipe_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.listViewRecipes = ((System.Windows.Controls.ListView)(target));
            
            #line 19 "..\..\..\List_Recipe.xaml"
            this.listViewRecipes.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.listViewRecipes_MouseDoubleClick_1);
            
            #line default
            #line hidden
            
            #line 19 "..\..\..\List_Recipe.xaml"
            this.listViewRecipes.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.listViewRecipes_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnBack = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\List_Recipe.xaml"
            this.btnBack.Click += new System.Windows.RoutedEventHandler(this.btnBack_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

