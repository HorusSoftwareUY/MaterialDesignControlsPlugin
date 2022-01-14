using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.ViewModels
{
    public class MaterialRatingControlViewModel : BaseViewModel
    {
        public int _value = 2;

        public int Value
        {
            get { return _value; }
            set
            {
                _value = value;
                OnPropertyChanged();
            }
        }

        public string error;
        public string Error
        {
            get { return error; }
            set
            {
                error = value;
                OnPropertyChanged();
            }
        }

        public delegate Task DisplayAlertType(string title, string message, string cancel);

        public DisplayAlertType DisplayAlert { get; set; }

        public ICommand ClearCommand => new Command(() =>
        {
            Value = 0;
            Error = null;
        });

        public ICommand ShowCommand => new Command(async () =>
        {
            await DisplayAlert("Selected value", Value.ToString(), "Ok");

            Error = Value == 0 ? "Required field" : null;
        });
    }
}