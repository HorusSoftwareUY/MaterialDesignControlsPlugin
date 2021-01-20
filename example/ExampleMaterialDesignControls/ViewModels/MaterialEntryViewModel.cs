using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.ViewModels
{
    public class MaterialEntryViewModel : BaseViewModel
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private string nameError;

        public string NameError
        {
            get { return nameError; }
            set
            {
                nameError = value;
                OnPropertyChanged();
            }
        }

        public delegate Task DisplayAlertType(string title, string message, string cancel);

        public DisplayAlertType DisplayAlert { get; set; }

        public ICommand TapCommand => new Command(OnTapCommand);

        private async void OnTapCommand()
        {
            if (!string.IsNullOrEmpty(this.Name))
            {
                this.NameError = null;
                await this.DisplayAlert.Invoke("", "Saved", "Ok");
            }
            else
            {
                this.NameError = "The message is required";
            }
        }

        public ICommand HelpCommand => new Command<string>(OnHelpCommand);

        private async void OnHelpCommand(string parameter)
        {
            await this.DisplayAlert.Invoke("Help", parameter, "Ok");
        }
    }
}
