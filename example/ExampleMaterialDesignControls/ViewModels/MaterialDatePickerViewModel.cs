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

        public delegate Task DisplayAlertType(string title, string message, string cancel);

        public DisplayAlertType DisplayAlert { get; set; }

        public ICommand TapCommand => new Command(OnTapCommand);

        private async void OnTapCommand()
        {
            await this.DisplayAlert.Invoke("", this.Date.HasValue ? this.Date.Value.ToShortDateString() : "Select date", "Ok");
        }
    }
}
