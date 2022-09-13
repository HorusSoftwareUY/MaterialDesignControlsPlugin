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

            this.BindingContext = new MaterialButtonViewModel { DisplayAlert = this.DisplayAlert };
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Clicked Event", "Executing the click event in the code behind", "Ok");
        }
    }
}