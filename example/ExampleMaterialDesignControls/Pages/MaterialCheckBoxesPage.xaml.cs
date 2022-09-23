using System;
using ExampleMaterialDesignControls.ViewModels;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class MaterialCheckBoxesPage : ContentPage
    {
        public MaterialCheckBoxesPage()
        {
            InitializeComponent();
            BindingContext = new MaterialCheckboxViewModel { DisplayAlert = DisplayAlert, Navigation = Navigation };
        }

        private void Checkbox_IsCheckedChanged(object sender, EventArgs eventArgs)
        {
            DisplayAlert("Message","Checkbox checked changed","Ok");
	    }
    }
}