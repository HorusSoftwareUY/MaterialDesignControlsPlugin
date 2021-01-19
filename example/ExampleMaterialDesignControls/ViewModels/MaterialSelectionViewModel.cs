using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.ViewModels
{
    public class MaterialSelectionViewModel : BaseViewModel
    {
        private string selectedText;

        public string SelectedText
        {
            get { return selectedText; }
            set { SetProperty(ref selectedText, value); }
        }

        public delegate Task DisplayAlertType(string title, string message, string cancel);

        public DisplayAlertType DisplayAlert { get; set; }

        public ICommand TapCommand => new Command<string>(OnTap);

        public async void OnTap(object parameter)
        {
            string text = parameter.ToString();
            await this.DisplayAlert("", text, "Ok");
            SelectedText = text;
        }
    }
}
