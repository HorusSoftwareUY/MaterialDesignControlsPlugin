using System;
using ExampleMaterialDesignControls.ViewModels;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class MaterialSwitchPage : ContentPage
    {
        public MaterialSwitchPage()
        {
            InitializeComponent();
            BindingContext = new MaterialSwitchViewModel { DisplayAlert = DisplayAlert, Navigation = Navigation };
        }

        private void Switch_toggled(object sender, EventArgs eventArgs)
        {
            DisplayAlert("Message","Switch toggled","OK");
        }
    }
}