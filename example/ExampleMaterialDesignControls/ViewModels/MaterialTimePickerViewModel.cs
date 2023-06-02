using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.ViewModels
{
    public class MaterialTimePickerViewModel : BaseViewModel
    {
        private TimeSpan? time;

        public TimeSpan? Time
        {
            get { return time; }
            set { SetProperty(ref time, value); }
        }

        public delegate Task DisplayAlertType(string title, string message, string cancel);

        public DisplayAlertType DisplayAlert { get; set; }

        public ICommand TapCommand => new Command(OnTapCommand);

        private async void OnTapCommand()
        {
            await this.DisplayAlert.Invoke("", this.Time.HasValue ? this.Time.Value.ToString() : "Select time", "Ok");
        }

        public ICommand ClearCommand => new Command(() =>
        {
            Time = null;
        });

        public ICommand ShowCommand => new Command(async () =>
        {
            if (Time.HasValue)
                await DisplayAlert("Time", Time.ToString(), "Ok");
            else
                await DisplayAlert("Time", "No time selected", "Ok");
        });

        public ICommand IconCommand => new Command(async (parameter) =>
        {
            await DisplayAlert("Saved", $"Command {parameter}", "Ok");

        });
    }
}