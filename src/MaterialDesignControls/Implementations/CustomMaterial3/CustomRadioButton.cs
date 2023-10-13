using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Plugin.MaterialDesignControls.Animations;
using Plugin.MaterialDesignControls.Styles;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Material3.Implementations
{
	public class CustomRadioButton : Frame
	{
        public static readonly BindableProperty IsCheckedProperty =
            BindableProperty.Create(nameof(IsChecked), typeof(bool), typeof(BaseMaterialCheckboxes), defaultValue: false, defaultBindingMode: BindingMode.TwoWay);

        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }

        public static readonly BindableProperty ColorProperty =
            BindableProperty.Create(nameof(Color), typeof(Color), typeof(BaseMaterialCheckboxes), defaultValue: MaterialColor.Primary);

        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public CustomRadioButton()
        {
            UpdateLayout();
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            switch (propertyName)
            {
                case nameof(Color):
                case nameof(IsChecked):
                    UpdateLayout();
                    break;
                default:
                    base.OnPropertyChanged(propertyName);
                    break;
            }
        }

        private void UpdateLayout()
        {
            HasShadow = false;
            Padding = new Thickness(0);
            HeightRequest = 20;
            WidthRequest = 20;
            CornerRadius = 10;
            BorderColor = Color;
            BackgroundColor = Color.Transparent;

            if (IsChecked)
            {
                Content = new Frame
                {
                    HasShadow = false,
                    Padding = new Thickness(0),
                    HeightRequest = 12,
                    WidthRequest = 12,
                    CornerRadius = 6,
                    BackgroundColor = Color,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };
            }
            else
                Content = null;
        }
    }
}