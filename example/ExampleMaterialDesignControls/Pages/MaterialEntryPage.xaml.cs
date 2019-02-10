using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class MaterialEntryPage : ContentPage
    {
        public MaterialEntryPage()
        {
            InitializeComponent();

            this.TapCommand = new Command<string>(OnTap);

            this.BindingContext = this;

            Plugin.MaterialDesignControls.FieldsValidator.Initialize(this);
        }

        public ICommand TapCommand { get; set; }

        public async void OnTap(object parameter)
        {
            bool isValid = Plugin.MaterialDesignControls.FieldsValidator.Validate();

            if (isValid)
            {
                await this.DisplayAlert("", "Saved", "Ok");
            }
            else
            {
                await this.DisplayAlert("", "The form has invalid fields", "Ok");
            }
        }
    }
}
