using ExampleMaterialDesignControls.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class ProductDetailPage : ContentPage
    {
        public ProductDetailPage()
        {
            InitializeComponent();

            this.BindingContext = new ViewModel { DisplayAlert = this.DisplayAlert };
        }
    }
}
