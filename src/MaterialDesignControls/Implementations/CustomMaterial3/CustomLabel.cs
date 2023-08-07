using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Material3.Implementations
{
    public class CustomLabel : Plugin.MaterialDesignControls.MaterialLabel, IBaseMaterialFieldControl
    {
        public bool IsControlFocused() => false;

        public bool IsControlEnabled() => this.IsEnabled;

        public void SetIsEnabled(bool isEnabled)
        {
            this.IsEnabled = isEnabled;
        }

        public void SetTextColor(Color textColor)
        {
            this.TextColor = textColor;
        }

        public void SetFontSize(double fontSize)
        {
            this.FontSize = FontSize;
        }

        public void SetFontFamily(string fontFamily)
        {
            this.FontFamily = FontFamily;
        }

        public void SetPlaceholder(string placeHolder)
        {
            if (string.IsNullOrEmpty(this.Text))
            {
                this.Text = placeHolder;
            }
        }

        public void SetPlaceholderColor(Color placeHolderColor)
        {
            if (string.IsNullOrEmpty(this.Text))
            {
                this.TextColor = placeHolderColor;
            }
        }

        public void SetHorizontalTextAlignment(TextAlignment horizontalTextAlignment)
        {
            this.HorizontalTextAlignment = horizontalTextAlignment;
        }

        public bool ValidateIfAnimatePlaceHolder() => false;

        public void FocusControl() { }
    }
}
