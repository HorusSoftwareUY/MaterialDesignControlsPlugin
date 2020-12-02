using ExampleMaterialDesignControls.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class MaterialControlsPage : ContentPage
    {
        public MaterialControlsPage()
        {
            InitializeComponent();

            BindingContext = new MaterialControlsPageViewModel { DisplayAlert = this.DisplayAlert, Navigation = this.Navigation };
        }
    }
}


