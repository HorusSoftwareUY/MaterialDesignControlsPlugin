using System.Windows.Input;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.ViewModels
{
    public class MaterialEditorViewModel : BaseViewModel
    {
        private string message;
        public string Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }

        private string messageError;

        public string MessageError
        {
            get { return messageError; }
            set
            {
                messageError = value;
                OnPropertyChanged();
            }
        }

        private string observation;
        public string Observation
        {
            get { return observation; }
            set { SetProperty(ref observation, value); }
        }

        public ICommand TapCommand => new Command(OnTap);

        public MaterialEditorViewModel()
        {
            Observation = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur nisl tellus, elementum sit amet semper vel, fermentum vitae turpis. Integer vel auctor orci.";
        }

        public async void OnTap(object parameter)
        {
            if (!string.IsNullOrEmpty(Message))
            {
                MessageError = null;
                await this.DisplayAlert("", "Saved", "Ok");
            }
            else
            {
                MessageError = "The message is required";
            }
        }
    }
}