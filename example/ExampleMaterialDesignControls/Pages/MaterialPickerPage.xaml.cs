using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class MaterialPickerPage : ContentPage
    {
        public string SelectedSizes { get; set; }

        public MaterialPickerPage()
        {
            InitializeComponent();

            this.pckColors.ItemsSource = new List<string> { "Red", "Blue", "Green" };
            this.pckSizes.ItemsSource = new List<string> { "P", "M", "X", "XL" };
            this.pckModels.ItemsSource = new List<string> { "Model A", "Model B", "Model C", "Model D" };

            this.SelectedSizes = "M";

            this.TapCommand = new Command<string>(OnTap);

            this.BindingContext = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Plugin.MaterialDesignControls.FieldsValidator.Initialize(this);
        }

        public ICommand TapCommand { get; set; }

        public async void OnTap(object parameter)
        {
            bool isValid = Plugin.MaterialDesignControls.FieldsValidator.Validate(this);

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
