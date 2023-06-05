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

        public void SetIsEnabled(bool isEnabled)
        {
            if (Device.RuntimePlatform == Device.iOS)
                this.IsEnabled = isEnabled;
            else
            {
                // Workaround to a disabled text color issue in Android
                this.IsReadOnly = !isEnabled;
            }
        }

        public void SetTextColor(Color textColor)
        {
            this.TextColor = textColor;
        }

        public void SetFontSize(double fontSize)
        {
            this.FontSize = fontSize;
        }

        public void SetFontFamily(string fontFamily)
        {
            this.FontFamily = fontFamily;
        }

        public void SetPlaceholder(string placeHolder)
        {
            this.Placeholder = placeHolder;
        }

        public void SetPlaceholderColor(Color placeHolderColor)
        {
            this.PlaceholderColor = placeHolderColor;
        }

        public void SetHorizontalTextAlignment(TextAlignment horizontalTextAlignment)
        {
            this.HorizontalTextAlignment = horizontalTextAlignment;
        }

        public bool ValidateIfAnimatePlaceHolder() =>
            this.IsEnabled && string.IsNullOrEmpty(this.Text);

        public void FocusControl()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                _ = Focus();
            });
        }
    }
}