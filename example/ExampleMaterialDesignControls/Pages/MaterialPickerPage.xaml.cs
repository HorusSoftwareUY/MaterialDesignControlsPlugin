using System;
using System.Collections.Generic;
using System.Windows.Input;
using Plugin.MaterialDesignControls;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class MaterialPickerPage : ContentPage
    {
        public string SelectedSizes { get; set; }

        public string SelectedItem { get; set; }

        public string SecondarySelectedItem { get; set; }

        public List<string> ItemsSource { get; set; }

        public List<string> SecondaryItemsSource { get; set; }

        public MaterialPickerPage()
        {
            InitializeComponent();

            this.pckColors.ItemsSource = new List<string> { "Red", "Blue", "Green" };
            this.pckSizes.ItemsSource = new List<string> { "P", "M", "X", "XL" };

            this.pckModels.ItemsSource = new List<string> { "Model A", "Model B", "Model C", "Model D" };
            this.pckModels.SelectedIndexChanged += PckModels_SelectedIndexChanged;

            this.pckModels2.ItemsSource = new List<string> { "Model A", "Model B", "Model C", "Model D" };
            this.pckModels3.ItemsSource = new List<string> { "Model A", "Model B", "Model C", "Model D" };
            this.pckModels4.ItemsSource = new List<string> { "Model A", "Model B", "Model C", "Model D" };

            this.pckDouble.SelectedIndexesChanged += PckDouble_SelectedIndexChanged;
            this.ItemsSource = new List<string> { "Model 1", "Model 2", "Model 3", "Model 4" };
            this.SecondaryItemsSource = new List<string> { "A", "B", "C", "D" };
            this.SelectedItem = "Model 2";
            this.SecondarySelectedItem = "C";

            this.TapCommand = new Command<string>(OnTap);

            this.Tap2Command = new Command<string>(OnTap2);

            this.Tap3Command = new Command<string>(OnTap3);

            this.BindingContext = this;
        }

        private void PckDouble_SelectedIndexChanged(object sender, SelectedIndexesEventArgs e)
        {
            this.lblSelectedIndexes.Text = $"SelectedIndexes: {e.SelectedIndexes[0]} - {e.SelectedIndexes[1]}";
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
                await this.DisplayAlert("Saved", !string.IsNullOrEmpty(this.SelectedSizes) ? this.SelectedSizes : "Select option", "Ok");
            }
            else
            {
                this.pckColors.AssistiveText = "The color is required";
            }
        }

        public ICommand Tap2Command { get; set; }

        public async void OnTap2(object parameter)
        {
            await this.DisplayAlert("Saved", $"{SelectedItem} - {SecondarySelectedItem}", "Ok");
        }

        public ICommand Tap3Command { get; set; }

        public async void OnTap3(object parameter)
        {
            this.pckDoubleWithFocus.Focus();
        }
    }
}
