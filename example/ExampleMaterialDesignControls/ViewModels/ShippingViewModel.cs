using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.ViewModels
{
    public class ShippingViewModel : BaseViewModel
    {
        private bool isEnabled;

        public bool IsEnabled
        {
            get { return isEnabled; }
            set { SetProperty(ref isEnabled, value); }
        }

        private bool isBusy;

        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        private bool cancelIsVisible = true;

        public bool CancelIsVisible
        {
            get { return cancelIsVisible; }
            set { SetProperty(ref cancelIsVisible, value); }
        }

        private bool deleteIsVisible = false;

        public bool DeleteIsVisible
        {
            get { return deleteIsVisible; }
            set { SetProperty(ref deleteIsVisible, value); }
        }

        public ICommand TapCommand => new Command<string>(OnTap);

        public ICommand TapCommand2 => new Command<string>(OnTap2, (var) => { return IsEnabled; });

        public async void OnTap(object parameter)
        {
            if (parameter != null)
            {
                if (parameter is string && ((string)parameter).ToString().Equals("Saved"))
                {
                    this.IsBusy = true;
                    await Task.Delay(2000);
                    this.IsBusy = false;

                    this.IsEnabled = true;
                }

                string text = parameter.ToString();
                await this.DisplayAlert("", text, "Ok");
            }
        }

        public async void OnTap2(object parameter)
        {
            if (parameter != null)
            {
                string text = parameter.ToString();
                await this.DisplayAlert("", text, "Ok");

                this.CancelIsVisible = false;
                this.DeleteIsVisible = true;
            }
        }
    }
}
