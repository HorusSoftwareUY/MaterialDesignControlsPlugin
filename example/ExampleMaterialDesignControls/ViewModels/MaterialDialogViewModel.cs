using System.Collections.ObjectModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ExampleMaterialDesignControls.ViewModels
{
    public partial class MaterialDialogViewModel : BaseViewModel
    {
        private string _controlTitle = "MaterialDialog";

        private ObservableCollection<string> rigtones;
        public ObservableCollection<string> Rigtones
        {
            get { return rigtones; }
            set { SetProperty(ref rigtones, value); }
        }

        public MaterialDialogViewModel()
        {
            this.Rigtones = new ObservableCollection<string> { "Callisto", "Ganymede", "Luna", "Option A", "Option B", "Option C" };
        }

        [ICommand]
        private async Task Accept()
        {
            await this.DisplayAlert(_controlTitle, "Accept button was tapped", "Ok");
        }

        [ICommand]
        private async Task Cancel()
        {
            await this.DisplayAlert(_controlTitle, $"Cancel button was tapped", "Ok");
        }

        [ICommand]
        private async Task AcceptSelection(string option)
        {
            await this.DisplayAlert(_controlTitle, $"Selection: {option}", "Ok");
        }

        [ICommand]
        private async Task AcceptMultipleSelection(List<string> options)
        {
            await this.DisplayAlert(_controlTitle, $"Selection: {string.Join(", ", options)}", "Ok");
        }
    }
}