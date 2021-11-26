using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.ViewModels
{
    public class MaterialSwitchViewModel : BaseViewModel
    {
        private bool isOn;

        public bool IsOn
        {
            get { return isOn; }
            set { SetProperty(ref isOn, value); }
	    }

        private string error;

        public string Error
        {
            get { return error; }
            set
            {
                error = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand => new Command(OnSaveCommand);
        private async void OnSaveCommand()
        {
            if (IsOn)
            {
                this.Error = null;
                await this.DisplayAlert.Invoke("Saved", $"Night mode activated", "Ok");
            }
            else
            {
                this.Error = "The night mode is required";
            }
        }
    }
}
