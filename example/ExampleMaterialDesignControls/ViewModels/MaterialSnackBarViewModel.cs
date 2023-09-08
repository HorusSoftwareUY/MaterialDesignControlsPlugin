using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.ViewModels
{
	public class MaterialSnackBarViewModel : BaseViewModel
	{
        private string _controlTitle = "MaterialSnackBar";

        public ICommand TrailingIconTapCommand => new Command(OnTrailingIconTapCommand);
        private async void OnTrailingIconTapCommand()
        {
            await this.DisplayAlert(_controlTitle, $"Trailing icon was tapped", "Ok");
        }

        public ICommand LeadingIconTapCommand => new Command(OnLeadingIconTapCommand);
        private async void OnLeadingIconTapCommand()
        {
            await this.DisplayAlert(_controlTitle, $"Leading icon was tapped", "Ok");
        }

        public ICommand ActionCommand => new Command(OnActionCommand);
        private async void OnActionCommand()
        {
            await this.DisplayAlert(_controlTitle, $"Action button was tapped", "Ok");
        }

    }

}

