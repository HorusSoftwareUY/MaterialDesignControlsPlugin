using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.ViewModels
{
    public class MaterialCheckboxViewModel : BaseViewModel
    {
        private bool isChecked;

        public bool IsChecked
        {
            get { return isChecked; }
            set { SetProperty(ref isChecked, value); }
        }

        private string nameError="algo";

        public string NameError
        {
            get { return nameError; }
            set
            {
                nameError = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand => new Command(OnTapCommand);

        private async void OnTapCommand()
        {
            if (IsChecked)
            {
                this.NameError = null;
                await this.DisplayAlert.Invoke("", "Saved", "Ok");
            }
            else
            {
                this.NameError = "You have to accept!";
            }
        }
    }
}
