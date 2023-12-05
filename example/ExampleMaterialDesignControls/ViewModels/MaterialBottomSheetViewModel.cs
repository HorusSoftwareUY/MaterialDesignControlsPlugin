using ExampleMaterialDesignControls.Pages;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;

namespace ExampleMaterialDesignControls.ViewModels
{
	public partial class MaterialBottomSheetViewModel : BaseViewModel
    {
        public Action OpenBottomSheetControl { get; set; }

        public Action CloseBottomSheetControl { get; set; }

        [ICommand]
        private async Task OpenBottomSheet()
        {
            OpenBottomSheetControl?.Invoke();
        }

        [ICommand]
        private async Task OpenInModalPage()
        {
            await Navigation.PushModalAsync(new MaterialBottomSheetPage(isModalPage: true));
        }

        [ICommand]
        private async Task CloseBottomSheet()
        {
            CloseBottomSheetControl?.Invoke();
        }
    }
}