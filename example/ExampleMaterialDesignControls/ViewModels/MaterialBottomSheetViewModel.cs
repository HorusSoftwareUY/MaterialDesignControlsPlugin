using ExampleMaterialDesignControls.Pages;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;

namespace ExampleMaterialDesignControls.ViewModels
{
	public partial class MaterialBottomSheetViewModel : BaseViewModel
    {
        public Action<string> OpenBottomSheetControl { get; set; }

        public Action<string> CloseBottomSheetControl { get; set; }

        [ICommand]
        private async Task OpenBottomSheet(string controlName)
        {
            OpenBottomSheetControl?.Invoke(controlName);
        }

        [ICommand]
        private async Task OpenInModalPage()
        {
            await Navigation.PushModalAsync(new MaterialBottomSheetPage(isModalPage: true));
        }

        [ICommand]
        private async Task CloseBottomSheet(string controlName)
        {
            CloseBottomSheetControl?.Invoke(controlName);
        }
    }
}