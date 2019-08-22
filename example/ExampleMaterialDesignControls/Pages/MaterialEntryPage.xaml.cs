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
        }

        public ICommand TapCommand { get; set; }

        public async void OnTap(object parameter)
        {
            if (!string.IsNullOrEmpty(this.txtEntry.Text))
            {
                this.txtEntry.AssistiveText = null;
                await this.DisplayAlert("", "Saved", "Ok");
            }
            else
            {
                this.txtEntry.AssistiveText = "The message is required";
            }
        }
    }
}
