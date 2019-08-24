using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Windows.Input;
using ExampleMaterialDesignControls.ViewModels;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class MaterialEntryPage : ContentPage
    {
        public MaterialEntryPage()
        {
            InitializeComponent();

            this.BindingContext = new MaterialEntryViewModel { DisplayAlert = this.DisplayAlert };
        }
    }
}
