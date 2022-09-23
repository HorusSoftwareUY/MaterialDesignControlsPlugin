using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace ExampleMaterialDesignControls.ViewModels
{
    public partial class MaterialButtonViewModel : BaseViewModel
    {
        private string _controlTitle = "MaterialButton";

        [ObservableProperty]
        private bool _isEnabled = true;

        [ObservableProperty]
        private bool _isVisible = true;

        [ICommand]
        private async Task SaveFile()
        {
            await Task.Delay(2000);
            await this.DisplayAlert(_controlTitle, $"Save file executed!", "Ok");
        }

        [ICommand]
        private async Task DownloadFile()
        {
            await Task.Delay(2000);
            await this.DisplayAlert(_controlTitle, $"Download file executed!", "Ok");
        }

        [ICommand]
        private async Task OpenTutorial()
        {
            await Task.Delay(2000);
            await this.DisplayAlert(_controlTitle, $"Open tutorial executed!", "Ok");
        }

        [ICommand]
        private async Task CancelAction()
        {
            await Task.Delay(2000);
            await this.DisplayAlert(_controlTitle, $"Cancel action executed!", "Ok");
        }

        [ICommand]
        private async Task DeleteItem()
        {
            await Task.Delay(2000);
            await this.DisplayAlert(_controlTitle, $"Delete item executed!", "Ok");
        }
    }
}