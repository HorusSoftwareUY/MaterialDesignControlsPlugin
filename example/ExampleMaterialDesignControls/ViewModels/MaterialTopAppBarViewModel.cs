using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.Input;

namespace ExampleMaterialDesignControls.ViewModels
{
    public partial class MaterialTopAppBarViewModel : BaseViewModel
    {
        private string _controlTitle = "MaterialTopAppBar";

        [ICommand]
        private async Task Volume()
        {
            await this.DisplayAlert(_controlTitle, $"Volume icon tapped!", "Ok");
        }

        [ICommand]
        private async Task VolumeWithWait()
        {
            await Task.Delay(2000);
            await this.DisplayAlert(_controlTitle, $"Volume icon tapped!", "Ok");
        }
    }
}