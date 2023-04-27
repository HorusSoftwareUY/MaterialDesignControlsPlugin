using Plugin.MaterialDesignControls.ControlsMaterial3;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Material3.Implementations
{
    public class CustomEntry : Entry, IBaseMaterialFieldControl
    {
        public static readonly BindableProperty IsCodeProperty =
            BindableProperty.Create(nameof(IsCode), typeof(bool), typeof(CustomEntry), defaultValue: false);

        public bool IsCode
        {
            get { return (bool)GetValue(IsCodeProperty); }
            set { SetValue(IsCodeProperty, value); }
        }

        public bool IsControlFocused() => this.IsFocused; 

        public bool IsControlEnabled() => this.IsEnabled; 

        public Color BackgroundColorControl() => this.BackgroundColor;

        public void SetIsEnabled()
        {
            if (Device.RuntimePlatform == Device.iOS)
                this.IsEnabled = IsEnabled;
            else
            {
                // Workaround to a disabled text color issue in Android
                this.IsReadOnly = !IsEnabled;
            }
        }

        public void SetTextColor(Color focusedTextColor, Color textColor, Color disabledTextColor)
        {
            if (IsControlEnabled())
                this.TextColor = IsControlFocused() && focusedTextColor != Color.Transparent ? focusedTextColor : textColor;
            else
                this.TextColor = disabledTextColor;
        }

        public void SetFontSize()
        {
            this.FontSize = FontSize;
        }

        public void SetFontFamily()
        {
            this.FontFamily = FontFamily;
        }

        public void SetPlaceholder()
        {
            this.Placeholder = Placeholder;
        }

        public void SetPlaceholderColor()
        {
            this.PlaceholderColor = PlaceholderColor;
        }

        public void SetHorizontalTextAlignment()
        {
            this.HorizontalTextAlignment = HorizontalTextAlignment;
        }
    }
}