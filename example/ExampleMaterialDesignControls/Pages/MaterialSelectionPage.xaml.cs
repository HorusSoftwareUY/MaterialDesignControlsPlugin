using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class MaterialSelectionPage : ContentPage
    {
        public MaterialSelectionPage()
        {
            InitializeComponent();

            this.TapCommand = new Command<string>(OnTap);

            this.BindingContext = this;
        }

        public ICommand TapCommand { get; set; }

        public async void OnTap(object parameter)
        {
            string text = parameter.ToString();
            await this.DisplayAlert("", text, "Ok");
        }
    }
}
