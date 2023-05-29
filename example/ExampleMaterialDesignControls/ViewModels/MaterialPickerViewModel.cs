using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace ExampleMaterialDesignControls.ViewModels
{
    public partial class MaterialPickerViewModel : BaseViewModel
    {
        [ObservableProperty]
        private ObservableCollection<CustomColor> _itemsSourceColors;

        [ObservableProperty]
        private CustomColor _selectedItemColor;

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

            ItemsSourceColors = new ObservableCollection<CustomColor> 
            { 
                new CustomColor()
                {
                    Color = "Red",
                    Id = 1
                },
                new CustomColor()
                {
                    Color = "Blue",
                    Id = 2
                },
                new CustomColor()
                {
                    Color = "Green",
                    Id = 3
                }
            };

            ItemsSource = new ObservableCollection<string> { "Model 1", "Model 2", "Model 3", "Model 4" };
            SecondaryItemsSource = new List<string> { "A", "B", "C", "D" };
            SelectedItem = "Model 2";
            SecondarySelectedItem = "C";

            SelectedItemColor = ItemsSourceColors.FirstOrDefault();
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
            if (SelectedItemColor != null)
                await DisplayAlert("Color", SelectedItemColor.Color, "Ok");
            else
                await DisplayAlert("Color", "No color selected", "Ok");
        }

        [ICommand]
        private async Task Icon(object parameter)
        {
            await DisplayAlert("Saved", $"Command {parameter}", "Ok");
        }

        [ICommand]
        private async Task AddNewColor()
        {
            var lastId = ItemsSourceColors.LastOrDefault().Id;
            var newColor = new CustomColor() { Color = $"New Color ({++lastId})", Id = lastId };
            ItemsSourceColors.Add(newColor);
            await DisplayAlert("Saved", $"New color {newColor.Color} added", "Ok");
        }
    }

    public class CustomColor
    {
        public int Id { get; set;}

        public string Color { get; set; }

        // We override this method only to show a Custom Object without set PropertyPath in Full API example.
        public override string ToString()
        {
            return Color;
        }
    }
}