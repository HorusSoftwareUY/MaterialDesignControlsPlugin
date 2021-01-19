using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using ExampleMaterialDesignControls.ViewModels;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class MaterialSelectionPage : ContentPage
    {
        public MaterialSelectionPage()
        {
            InitializeComponent();

            this.BindingContext = new MaterialSelectionViewModel { DisplayAlert = this.DisplayAlert };
        }
    }
}
