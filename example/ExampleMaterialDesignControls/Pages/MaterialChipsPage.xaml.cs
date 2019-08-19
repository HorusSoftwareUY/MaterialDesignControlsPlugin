using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class MaterialChipsPage : ContentPage
    {
        public string SelectedSizes { get; set; }

        public List<string> Sizes { get; set; }

        public MaterialChipsPage()
        {
            InitializeComponent();

            this.Sizes = new List<string> { "P", "M", "X", "XL" };

            this.SelectedSizes = "M";

            this.TapCommand = new Command<string>(OnTap);

            this.BindingContext = this;
        }

        public ICommand TapCommand { get; set; }

        public async void OnTap(object parameter)
        {
            await this.DisplayAlert("Saved", this.SelectedSizes, "Ok");
        }
    }
}
