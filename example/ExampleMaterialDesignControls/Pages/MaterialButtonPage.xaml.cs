using ExampleMaterialDesignControls.ViewModels;
using System;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class MaterialButtonPage : ContentPage
    {
        public MaterialButtonPage()
        {
            InitializeComponent();

            BindingContext = new MaterialButtonViewModel { DisplayAlert = DisplayAlert, Navigation = Navigation };
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Clicked Event", "Executing the click event in the code behind", "Ok");
        }
    }
}