using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class MaterialButtonPage : ContentPage
    {
        public MaterialButtonPage()
        {
            InitializeComponent();

            this.TapCommand = new Command<string>(OnTap);

            this.BindingContext = this;
        }

        public ICommand TapCommand { get; set; }

        public async void OnTap(object parameter)
        {
            if (parameter is string && ((string)parameter).ToString().Equals("Saved"))
            {
                this.btnSave.IsBusy = true;
                await Task.Delay(2000);
                this.btnSave.IsBusy = false;
            }

            string text = parameter.ToString();
            await this.DisplayAlert("", text, "Ok");
        }
    }
}
