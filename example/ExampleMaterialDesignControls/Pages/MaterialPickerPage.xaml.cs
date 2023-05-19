using System;
using System.Collections.Generic;
using ExampleMaterialDesignControls.ViewModels;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class MaterialPickerPage : ContentPage
    {
        public MaterialPickerPage()
        {
            InitializeComponent();

            pckModels.ItemsSource = new List<string> { "Model A", "Model B", "Model C", "Model D" };
            pckModels.SelectedIndexChanged += PckModels_SelectedIndexChanged;

            pckModels2.ItemsSource = new List<string> { "Model A", "Model B", "Model C", "Model D" };
            pckModels3.ItemsSource = new List<string> { "Model A", "Model B", "Model C", "Model D" };
            pckModels4.ItemsSource = new List<string> { "Model A", "Model B", "Model C", "Model D" };
            pckModels5.ItemsSource = new List<string> { "Model A", "Model B", "Model C", "Model D" };

            var viewModel = new MaterialPickerViewModel { DisplayAlert = DisplayAlert, Navigation = Navigation };

            viewModel.ClearSelectedItem = () =>
            {
                pckColors.ClearSelectedItem();
            };

            BindingContext = viewModel;
        }

        private void PckModels_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSelectedIndex.Text = $"SelectedIndex: {pckModels.SelectedIndex}";
        }
    }
}