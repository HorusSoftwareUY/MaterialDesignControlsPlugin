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
                this.NameError = "This field is required";
            }
        }

        public ICommand FocusedCommand => new Command(OnFocusedCommand);

        private async void OnFocusedCommand()
        {
            await this.DisplayAlert.Invoke("", "Focused", "Ok");
        }

        public ICommand UnfocusedCommand => new Command(OnUnfocusedCommand);

        private async void OnUnfocusedCommand()
        {
            await this.DisplayAlert.Invoke("", "Unfocused", "Ok");
        }

        public ICommand HelpCommand => new Command<string>(OnHelpCommand);

        private async void OnHelpCommand(string parameter)
        {
            System.Console.WriteLine("Executed command");
            await this.DisplayAlert.Invoke("Help", parameter, "Ok");
        }

        private string searchText;

        public string SearchText
        {
            get { return searchText; }
            set { SetProperty(ref searchText, value); }
        }

        public ICommand SearchCommand => new Command(OnSearchCommand);

        private async void OnSearchCommand()
        {
            await this.DisplayAlert.Invoke("Search", SearchText, "Ok");
        }
    }
}