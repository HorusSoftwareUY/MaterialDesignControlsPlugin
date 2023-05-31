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
        private string _selectedModel;

        public Action ClearSelectedItem { get; set; }

        // DoublePicker

        [ObservableProperty]
        private int _selectedItem;

        [ObservableProperty]
        private Weight _secondarySelectedItem;

        [ObservableProperty]
        private ObservableCollection<int> _itemsSource;

        [ObservableProperty]
        private ObservableCollection<Weight> _secondaryItemsSource;

        public Action FocusOnPicker { get; set; }

        public Action ClearDoubleSelectedItem { get; set; }

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

            ItemsSource = new ObservableCollection<int>
            {
                30,31,32,33,34,35,36,37
            };

            SecondaryItemsSource = new ObservableCollection<Weight>
            {
                new Weight()
                {
                    Name = "kgs",
                    Id = 1
                },
                new Weight()
                {
                    Name = "lbs",
                    Id = 2
                }
            };

            SelectedItemColor = ItemsSourceColors.FirstOrDefault();
            SelectedItem = ItemsSource.FirstOrDefault();
            SecondarySelectedItem = SecondaryItemsSource.FirstOrDefault();
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
        public void Tap3(object parameter)
        {
            FocusOnPicker?.Invoke();
        }

        [ICommand]
        public void Clear()
        {
            ClearSelectedItem?.Invoke();
        }

        [ICommand]
        public void ClearDouble()
        {
            ClearDoubleSelectedItem?.Invoke();
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
        public async Task ShowDouble()
        {
            if (SelectedItem != null && SecondarySelectedItem != null )
                await DisplayAlert("Weight", $"Weight={SelectedItem} {SecondarySelectedItem.Name}", "Ok");
            else
                await DisplayAlert("Weight", "No weight selected", "Ok");
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

        [ICommand]
        private async Task AddNewWeight()
        {
            var lastWeight = ItemsSource.LastOrDefault();
            var lastWeightId = SecondaryItemsSource.LastOrDefault().Id;

            ItemsSource.Add(++lastWeight);

            var newWeight = new Weight() { Name = $"New weight ({++lastWeightId})", Id = lastWeightId };
            SecondaryItemsSource.Add(newWeight);

            await DisplayAlert("Saved", $"New weight {lastWeight} {newWeight.Name} added", "Ok");
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

    public class Weight
    {
        public int Id { get; set; }

        public string Name { get; set; }

        // We override this method only to show a Custom Object without set PropertyPath/SecondaryPropertyPath in Full API example.
        public override string ToString()
        {
            return Name;
        }
    }
}