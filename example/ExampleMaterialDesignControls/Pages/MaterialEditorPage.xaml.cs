using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class MaterialEditorPage : ContentPage
    {
        public MaterialEditorPage()
        {
            InitializeComponent();

            this.TapCommand = new Command<string>(OnTap);

            this.BindingContext = this;
        }

        public ICommand TapCommand { get; set; }

        public async void OnTap(object parameter)
        {
            if (!string.IsNullOrEmpty(this.txtEditor.Text))
            {
                this.txtEditor.AssistiveText = null;
                await this.DisplayAlert("", "Saved", "Ok");
            }
            else
            {
                this.txtEditor.AssistiveText = "The message is required";
            }
        }
    }
}
