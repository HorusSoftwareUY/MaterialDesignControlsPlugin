using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class MaterialPickerPage : ContentPage
    {
        public MaterialPickerPage()
        {
            InitializeComponent();

            this.pckColors.ItemsSource = new List<string> { "Red", "Blue", "Green" };
            this.pckSizes.ItemsSource = new List<string> { "P", "M", "X", "XL" };
            this.pckModels.ItemsSource = new List<string> { "Model A", "Model B", "Model C", "Model D" };
        }
    }
}
