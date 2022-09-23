using System.Collections.Generic;
using ExampleMaterialDesignControls.ViewModels;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class ShippingPage : ContentPage
    {
        public ShippingPage()
        {
            InitializeComponent();

            this.BindingContext = new ShippingViewModel() { DisplayAlert = DisplayAlert, Navigation = Navigation };

            this.pckSizes.ItemsSource = new List<string> { "United States", "Canada", "Mexico" };
        }
    }
}