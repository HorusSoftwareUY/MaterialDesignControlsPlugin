using System;
using System.Collections.Generic;
using ExampleMaterialDesignControls.ViewModels;
using Plugin.MaterialDesignControls;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class MaterialPickerPage : ContentPage
    {
        public MaterialPickerPage()
        {
            InitializeComponent();

            //pckSizes.ItemsSource = new List<string> { "P", "M", "X", "XL" };

            //pckModels.ItemsSource = new List<string> { "Model A", "Model B", "Model C", "Model D" };
            //pckModels.SelectedIndexChanged += PckModels_SelectedIndexChanged;

            pckModels2.ItemsSource = new List<string> { "Model A", "Model B", "Model C", "Model D" };            
            pckModels23.ItemsSource = new List<string> { "Model A", "Model B", "Model C", "Model D" };
            //pckModels3.ItemsSource = new List<string> { "Model A", "Model B", "Model C", "Model D" };
            //pckModels4.ItemsSource = new List<string> { "Model A", "Model B", "Model C", "Model D" };

            //pckDouble.SelectedIndexesChanged += PckDouble_SelectedIndexChanged;

            var viewModel = new MaterialPickerViewModel { DisplayAlert = DisplayAlert, Navigation = Navigation };

            //viewModel.FocusOnPicker = () =>
            //{
            //    pckDoubleWithFocus.Focus();
            //};

            viewModel.ClearSelectedItem = () =>
            {
                pckColors.ClearSelectedItem();
            };

            BindingContext = viewModel;
        }

        private void PckDouble_SelectedIndexChanged(object sender, SelectedIndexesEventArgs e)
        {
            //lblSelectedIndexes.Text = $"SelectedIndexes: {e.SelectedIndexes[0]} - {e.SelectedIndexes[1]}";
        }

        private void PckModels_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lblSelectedIndex.Text = $"SelectedIndex: {pckModels.SelectedIndex}";
        }
    }
}