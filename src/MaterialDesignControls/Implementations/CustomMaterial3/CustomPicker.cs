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
            this.FontFamily = fontFamily;
        }

        public void SetFontSize(double fontSize)
        {
            this.FontSize = fontSize;
        }

        public void SetHorizontalTextAlignment(TextAlignment horizontalTextAlignment)
        {
            this.HorizontalTextAlignment = horizontalTextAlignment;
        }

        public void SetIsEnabled(bool isEnabled)
        {
            this.IsEnabled = isEnabled;
        }

        public void SetPlaceholder(string placeHolder)
        {
            this.Placeholder = placeHolder;
        }

        public void SetPlaceholderColor(Color placeHolderColor)
        {
            this.PlaceholderColor = placeHolderColor;
        }

        public void SetTextColor(Color textColor)
        {
            this.TextColor = textColor;
        }

        public bool ValidateIfAnimatePlaceHolder() =>
            this.IsEnabled && this.SelectedIndex == -1;
    }
}
