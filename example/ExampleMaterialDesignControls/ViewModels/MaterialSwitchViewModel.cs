using System.Windows.Input;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.ViewModels
{
    public class MaterialSwitchViewModel : BaseViewModel
    {
        private bool propertyA = true;

        public bool PropertyA
        {
            get { return propertyA; }
            set { SetProperty(ref propertyA, value); }
        }

        private bool propertyB = false;

        public bool PropertyB
        {
            get { return propertyB; }
            set { SetProperty(ref propertyB, value); }
        }

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
        private void OnSaveCommand()
        {
            if (IsOn)
            {
                this.Error = null;
                await this.DisplayAlert.Invoke("Saved", $"Dark mode activated", "Ok");
            }
            else
            {
                this.Error = "The dark mode is required";
            }
        }
    }
}