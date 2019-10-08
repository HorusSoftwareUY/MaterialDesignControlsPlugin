using System;
using System.Collections.Generic;
using ExampleMaterialDesignControls.ViewModels;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class MaterialDatePickerPage : ContentPage
    {
        public MaterialDatePickerPage()
        {
            InitializeComponent();

            this.BindingContext = new MaterialDatePickerViewModel { DisplayAlert = this.DisplayAlert };
        }
    }
}
