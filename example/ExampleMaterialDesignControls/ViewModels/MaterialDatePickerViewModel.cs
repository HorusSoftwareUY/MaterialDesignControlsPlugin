using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.ViewModels
{
    public class MaterialDatePickerViewModel : BaseViewModel
    {
        private DateTime? date;

        public DateTime? Date
        {
            get { return date; }
            set { SetProperty(ref date, value); }
        }

        public DateTime MinimumDate => DateTime.Today.AddDays(-10);
        public DateTime MaximumDate => DateTime.Today.AddDays(10);

        public delegate Task DisplayAlertType(string title, string message, string cancel);

        public DisplayAlertType DisplayAlert { get; set; }

        public ICommand ClearCommand => new Command(() =>
        {
            Date = null;
        });

        public ICommand ShowCommand => new Command(async () =>
        {
            if (Date.HasValue)
                await DisplayAlert("Date", Date.ToString(), "Ok");
            else
                await DisplayAlert("Date", "No date selected", "Ok");
        });

        public ICommand IconCommand => new Command(OnIconCommand);

        private async void OnIconCommand(object commandParameter)
        {
            await DisplayAlert("Saved", $"Command {commandParameter}", "Ok");

        }
    }
}