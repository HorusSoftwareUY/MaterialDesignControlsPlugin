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
            this.BindingContext = new MaterialSwitchViewModel { DisplayAlert = this.DisplayAlert };
        }

        private void Switch_toggled(object sender, EventArgs eventArgs)
        {
            DisplayAlert("Message","Switch toggled","OK");
	    }
    }
}
