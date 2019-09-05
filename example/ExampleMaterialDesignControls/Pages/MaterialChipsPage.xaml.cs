using System;
using System.Collections.Generic;
using System.Windows.Input;
using ExampleMaterialDesignControls.ViewModels;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class MaterialChipsPage : ContentPage
    {
        public MaterialChipsPage()
        {
            InitializeComponent();
            this.BindingContext = new MaterialChipViewModel() { DisplayAlert = this.DisplayAlert };
        }
    }
}
