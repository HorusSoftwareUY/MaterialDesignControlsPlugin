using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.ViewModels
{
    public class MaterialCodeEntryViewModel : BaseViewModel
    {
        private string code;

        public string Code
        {
            get { return code; }
            set { SetProperty(ref code, value); }
        }

        private string codeError;

        public string CodeError
        {
            get { return codeError; }
            set { SetProperty(ref codeError, value); }
        }

        public delegate Task DisplayAlertType(string title, string message, string cancel);

        public DisplayAlertType DisplayAlert { get; set; }

        public ICommand TapCommand => new Command(OnTapCommand);

        private async void OnTapCommand()
        {
            if (string.IsNullOrEmpty(this.Code))
            {
                this.CodeError = "The code is required";
            }
            else if (this.Code.Length < 6)
            {
                this.CodeError = "You must complete the 6 digit code";
            }
            else
            {
                this.CodeError = null;
                await this.DisplayAlert.Invoke("", "Saved", "Ok");
            }
        }
    }
}