using System;
using System.Collections.Generic;
using System.Windows.Input;
using ExampleMaterialDesignControls.ViewModels;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class AddCardPage : ContentPage
    {
        public AddCardPage()
        {
            InitializeComponent();
            this.BindingContext = new AddCardViewModel() { DisplayAlert = this.DisplayAlert };
        }

    }
}
