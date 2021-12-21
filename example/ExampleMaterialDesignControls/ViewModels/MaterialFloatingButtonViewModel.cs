using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.ViewModels
{
    public class MaterialFloatingButtonViewModel : BaseViewModel
    {

        public ICommand TapCommand => new Command<string>(OnTap);

        public async void OnTap(object parameter)
        {
            if (parameter != null)
            {
                string text = parameter.ToString();
                await this.DisplayAlert("", text, "Ok");
            }
        }
    }
}
