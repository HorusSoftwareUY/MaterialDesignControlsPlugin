using System;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Material3.Implementations
{
    public class CustomDatePicker : DatePicker, IBaseMaterialFieldControl
    {
        public TextAlignment HorizontalTextAlignment { get; set; }

        private DateTime? customDate;

        public DateTime? CustomDate
        {
            get { return this.customDate; }
            set
            {
                this.customDate = value;
                if (this.customDate.HasValue)
                {
                    base.Date = this.customDate.Value;
                    EmptyDate = false;
                }
                else
                    EmptyDate = true;
            }
        }

        public DateTime InternalDateTime
        {
            get { return base.Date; }
        }

        public string Placeholder { get; set; }

        public Color PlaceholderColor { get; set; }

        public static readonly BindableProperty EmptyDateProperty =
            BindableProperty.Create(nameof(EmptyDate), typeof(bool), typeof(CustomDatePicker), defaultValue: true);

        public bool EmptyDate
        {
            get { return (bool)GetValue(EmptyDateProperty); }
            set { SetValue(EmptyDateProperty, value); }
        }

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
            this.IsEnabled && !this.CustomDate.HasValue;
    }
}
