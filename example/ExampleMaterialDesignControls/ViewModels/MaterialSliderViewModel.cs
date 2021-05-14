using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.ViewModels
{
    public class MaterialSliderViewModel : BaseViewModel
    {
        public double _value;
        public double Value
        {
            get { return _value; }
            set
            {
                _value = value;
                OnPropertyChanged();
            }
        }

        public delegate Task DisplayAlertType(string title, string message, string cancel);

        public DisplayAlertType DisplayAlert { get; set; }

        public ICommand TapCommand => new Command(OnTapCommand);

        private async void OnTapCommand()
        {
            await this.DisplayAlert.Invoke("", $"Opacity= {Value}", "Ok");
        }
    }
}
