using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.ViewModels
{
    public class MaterialCustomControlViewModel : BaseViewModel
    {
        private string assistiveText;

        public string AssistiveText
        {
            get { return assistiveText; }
            set
            {
                assistiveText = value;
                OnPropertyChanged();
            }
        }

        public delegate Task DisplayAlertType(string title, string message, string cancel);

        public DisplayAlertType DisplayAlert { get; set; }

        public ICommand TapCommand => new Command(OnTapCommand);

        private async void OnTapCommand()
        {
            this.AssistiveText = "The field is invalid";
        }
    }
}