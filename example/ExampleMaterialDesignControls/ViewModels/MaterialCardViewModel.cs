using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.Input;

namespace ExampleMaterialDesignControls.ViewModels
{
    public partial class MaterialCardViewModel : BaseViewModel
    {
        private string _controlTitle = "MaterialCard";

        [ICommand]
        private async Task Tap()
        {
            await this.DisplayAlert(_controlTitle, $"MaterialCard was tapped", "Ok");
        }
    }
}