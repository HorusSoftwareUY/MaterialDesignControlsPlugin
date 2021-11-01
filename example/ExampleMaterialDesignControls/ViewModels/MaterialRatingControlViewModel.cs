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

        public string nameError;
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

        public ICommand ClearCommand => new Command(() =>
        {
            Value = 0;
        });

        public ICommand ShowCommand => new Command(async () =>
        {
            await DisplayAlert("Selected value", Value.ToString(), "Ok");
        });
    }
}