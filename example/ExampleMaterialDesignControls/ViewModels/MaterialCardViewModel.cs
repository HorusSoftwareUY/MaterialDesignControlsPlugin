using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.ViewModels
{
    public partial class MaterialCardViewModel : BaseViewModel
    {
        private string _controlTitle = "MaterialCard";
        private int _index = 0;
        private List<Color> _backgroundColors = new List<Color> { Color.LightCyan, Color.LightCoral, Color.LightGreen };
        private List<Color> _borderColors = new List<Color> { Color.DarkGreen, Color.LightYellow, Color.DarkMagenta };
        private List<Color> _shadowColors = new List<Color> { Color.DarkRed, Color.Black, Color.DarkGoldenrod };

        [ObservableProperty]
        private Color _backgroundColor;

        [ObservableProperty]
        private Color _borderColor;

        [ObservableProperty]
        private Color _shadowColor;

        public MaterialCardViewModel()
        {
            BackgroundColor = _backgroundColors[_index];
            BorderColor = _borderColors[_index];
            ShadowColor = _shadowColors[_index];
        }

        [ICommand]
        private async Task Tap()
        {
            await this.DisplayAlert(_controlTitle, $"MaterialCard was tapped", "Ok");
        }

        [ICommand]
        private void ChangeColors()
        {
            if (++_index == 3)
            {
                _index = 0;
            }
            BackgroundColor = _backgroundColors[_index];
            BorderColor = _borderColors[_index];
            ShadowColor = _shadowColors[_index];
        }
    }
}