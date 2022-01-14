using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.ViewModels
{
    public class MaterialFloatingButtonViewModel : BaseViewModel
    {
        private bool isEnabled;

        public bool IsEnabled
        {
            get { return isEnabled; }
            set { SetProperty(ref isEnabled, value); }
        }

        public ICommand EnableCommand => new Command(OnEnable);

        public void OnEnable()
        {
            IsEnabled = !IsEnabled;
        }

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
