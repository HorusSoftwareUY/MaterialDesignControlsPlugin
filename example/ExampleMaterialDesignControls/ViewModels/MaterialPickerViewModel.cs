using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace ExampleMaterialDesignControls.ViewModels
{
    public partial class MaterialPickerViewModel : BaseViewModel
    {
        [ObservableProperty]
        private ObservableCollection<string> _itemsSourceColors;

        [ObservableProperty]
        private string _selectedItemColor;

        [ObservableProperty]
        private string _modelAssistiveText;

        [ObservableProperty]
        private string _selectedSizes;

        [ObservableProperty]
        private string _selectedItem;

        [ObservableProperty]
        private string _selectedModel;

        [ObservableProperty]
        private string _secondarySelectedItem;

        [ObservableProperty]
        private ObservableCollection<string> _itemsSource;

        [ObservableProperty]
        private List<string> _secondaryItemsSource;

        public Action FocusOnPicker { get; set; }

        public Action ClearSelectedItem { get; set; }

        public MaterialPickerViewModel()
        {
            ItemsSourceColors = new ObservableCollection<string> { "Red", "Blue", "Green" };

            ItemsSource = new ObservableCollection<string> { "Model 1", "Model 2", "Model 3", "Model 4" };
            SecondaryItemsSource = new List<string> { "A", "B", "C", "D" };
            SelectedItem = "Model 2";
            SecondarySelectedItem = "C";
        }

        [ICommand]
        private async Task Tap(object parameter)
        {
            if (!string.IsNullOrEmpty(SelectedModel))
            {
                ModelAssistiveText = null;
                await DisplayAlert("Saved", !string.IsNullOrEmpty(SelectedModel) ? SelectedModel : "Select option", "Ok");
            }
            else
                ModelAssistiveText = "The model is required";
        }

        [ICommand]
        private async Task Tap2(object parameter)
        {
            await DisplayAlert("Saved", $"{SelectedItem} - {SecondarySelectedItem}", "Ok");
        }

        [ICommand]
        public async Task Tap3(object parameter)
        {
            FocusOnPicker?.Invoke();
        }

        [ICommand]
        public void Clear()
        {
            ClearSelectedItem?.Invoke();
        }

        [ICommand]
        public async Task Show()
        {
            if (!string.IsNullOrEmpty(SelectedItemColor))
                await DisplayAlert("Color", SelectedItemColor, "Ok");
            else
                await DisplayAlert("Color", "No color selected", "Ok");
        }

        [ICommand]
        private async Task Icon(object parameter)
        {
            await DisplayAlert("Saved", $"Command {parameter}", "Ok");
        }
    }
}