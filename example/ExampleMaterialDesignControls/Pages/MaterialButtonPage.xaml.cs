using ExampleMaterialDesignControls.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class MaterialButtonPage : ContentPage
    {
        public MaterialButtonPage()
        {
            InitializeComponent();

            this.BindingContext = new MaterialButtonViewModel { DisplayAlert = this.DisplayAlert };
        }
    }
}
