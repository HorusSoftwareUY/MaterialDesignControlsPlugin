using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Material3.Implementations
{
    public class CustomPicker : Picker, IBaseMaterialFieldControl
    {
        public TextAlignment HorizontalTextAlignment { get; set; }

        public string Placeholder { get; set; }

        public Color PlaceholderColor { get; set; }

        public bool MultilineEnabled { get; set; } = false;

        public int PickerRowHeight { get; set; } = 50;

        public bool IsControlEnabled() => this.IsEnabled;

        public bool IsControlFocused() => this.IsFocused;

        public void SetFontFamily(string fontFamily)
        {
            this.FontFamily = FontFamily;
        }

        public void SetFontSize(double fontSize)
        {
            this.FontSize = fontSize;
        }

        public void SetHorizontalTextAlignment(TextAlignment horizontalTextAlignment)
        {
            this.HorizontalTextAlignment = HorizontalTextAlignment;
        }

        public void SetIsEnabled(bool isEnabled)
        {
            this.IsEnabled = IsEnabled;
        }

        public void SetPlaceholder(string placeHolder)
        {
            this.Placeholder = Placeholder;
        }

        public void SetPlaceholderColor(Color placeHolderColor)
        {
            this.PlaceholderColor = PlaceholderColor;
        }

        public void SetTextColor(Color textColor)
        {
            this.TextColor = textColor;
        }
    }
}
