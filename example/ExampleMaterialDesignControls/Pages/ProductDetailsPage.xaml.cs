using System;
using System.Collections.Generic;
using System.Windows.Input;
using ExampleMaterialDesignControls.ViewModels;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class ProductDetailsPage : ContentPage
    {
        public ProductDetailsPage()
        {
            InitializeComponent();
            this.BindingContext = new ProductDetailsViewModel() { DisplayAlert = this.DisplayAlert };
        }
    }
}
