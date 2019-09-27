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
            this.pckModels.SelectedIndexChanged += PckModels_SelectedIndexChanged;

            this.SelectedSizes = "M";

            this.TapCommand = new Command<string>(OnTap);

            this.BindingContext = this;
        }

        private void PckModels_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblSelectedIndex.Text = $"SelectedIndex: {this.pckModels.SelectedIndex}";
        }

        public ICommand TapCommand { get; set; }

        public async void OnTap(object parameter)
        {
            if (!string.IsNullOrEmpty(this.pckColors.SelectedItem))
            {
                this.pckColors.AssistiveText = null;
                await this.DisplayAlert("", "Saved", "Ok");
            }
            else
            {
                this.pckColors.AssistiveText = "The color is required";
            }
        }
    }
}
