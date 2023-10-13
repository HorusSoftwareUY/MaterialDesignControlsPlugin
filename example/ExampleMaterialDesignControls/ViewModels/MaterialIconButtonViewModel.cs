using System;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace ExampleMaterialDesignControls.ViewModels
{
	public partial class MaterialIconButtonViewModel : BaseViewModel
    {
        private string _controlTitle = "MaterialButton";

        [ObservableProperty]
        private bool _isEnabled = true;

        public MaterialIconButtonViewModel()
		{
		}

        [ICommand]
        private async Task Standard()
        {
            await Task.Delay(1500);
            await this.DisplayAlert(_controlTitle, $"Standard button command executed", "Ok");
        }

        [ICommand]
        private async Task Filled()
        {
            await this.DisplayAlert(_controlTitle, $"Filled button command executed", "Ok");
        }

        [ICommand]
        private async Task Outlined()
        {
            await this.DisplayAlert(_controlTitle, $"Filled button command executed", "Ok");
        }

        [ICommand]
        private async Task Tonal()
        {
            await Task.Delay(1500);
            await this.DisplayAlert(_controlTitle, $"Filled button command executed", "Ok");
        }

    }
}

