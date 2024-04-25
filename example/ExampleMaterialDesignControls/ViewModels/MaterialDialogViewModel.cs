using System.Collections.ObjectModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Plugin.MaterialDesignControls.Material3;
using System.Linq;

namespace ExampleMaterialDesignControls.ViewModels
{
    public partial class MaterialDialogViewModel : BaseViewModel
    {
        private string _controlTitle = "MaterialDialog";

        [ObservableProperty]
        private ObservableCollection<MaterialDialogItem> _itemsSourceColors;

        [ObservableProperty]
        private string _inputText;

        public MaterialDialogViewModel()
        {
            ItemsSourceColors = new ObservableCollection<MaterialDialogItem>
            {
                new MaterialDialogItem()
                {
                    Text = "Red",
                    Id = "1"
                },
                new MaterialDialogItem()
                {
                    IsSelected = true,
                    Text = "Blue",
                    Id = "2"
                },
                new MaterialDialogItem()
                {
                    Text = "Green",
                    Id = "3"
                },
                new MaterialDialogItem()
                {
                    Text = "Air force blue",
                    Id = "4"
                },
                new MaterialDialogItem()
                {
                    Text = "Alice blue",
                    Id = "5"
                },
                new MaterialDialogItem()
                {
                    Text = "Alizarin",
                    Id = "6"
                },
                new MaterialDialogItem()
                {
                    Text = "Almond",
                    Id = "7"
                },
                new MaterialDialogItem()
                {
                    Text = "Amber",
                    Id = "8"
                },
                new MaterialDialogItem()
                {
                    Text = "American rose",
                    Id = "9"
                },
                new MaterialDialogItem()
                {
                    Text = "Android green",
                    Id = "10"
                },
                new MaterialDialogItem()
                {
                    Text = "Antique fuchsia",
                    Id = "11"
                },
                new MaterialDialogItem()
                {
                    Text = "Antique white",
                    Id = "12"
                },
                new MaterialDialogItem()
                {
                    Text = "Aquamarine",
                    Id = "13"
                },
                new MaterialDialogItem()
                {
                    Text = "Ash grey",
                    Id = "14"
                }
            };
        }

        [ICommand]
        private async Task Accept()
        {
            await this.DisplayAlert(_controlTitle, "Accept button was tapped", "Ok");
        }

        [ICommand]
        private async Task AcceptTask()
        {
            await Task.Delay(1000);
            await this.DisplayAlert(_controlTitle, "Accept button was tapped", "Ok");
        }

        [ICommand]
        private async Task AcceptWithCustomContent()
        {
            await this.DisplayAlert(_controlTitle, $"Accept button was tapped: {InputText}", "Ok");
        }

        [ICommand]
        private async Task Cancel()
        {
            await this.DisplayAlert(_controlTitle, $"Cancel button was tapped", "Ok");
        }

        [ICommand]
        private async Task AcceptSelection(MaterialDialogItem selectedItem)
        {
            await this.DisplayAlert(_controlTitle, $"Selection: {selectedItem.Text}", "Ok");
        }

        [ICommand]
        private async Task AcceptMultipleSelection(List<MaterialDialogItem> selectedItems)
        {
            var itemTexts = selectedItems.Select(x => x.Text);
            await this.DisplayAlert(_controlTitle, $"Selection: {string.Join(", ", itemTexts)}", "Ok");
        }
    }
}