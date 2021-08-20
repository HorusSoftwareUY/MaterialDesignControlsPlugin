using System;
using System.Collections.Generic;
using System.Windows.Input;
using ExampleMaterialDesignControls.ViewModels;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class ShippingPage : ContentPage
    {
        public ShippingPage()
        {
            InitializeComponent();
            this.BindingContext = new ShippingViewModel() { DisplayAlert = this.DisplayAlert };

            this.pckSizes.ItemsSource = new List<string> { "United States", "Canada", "Mexico" };
        }
    }
}
