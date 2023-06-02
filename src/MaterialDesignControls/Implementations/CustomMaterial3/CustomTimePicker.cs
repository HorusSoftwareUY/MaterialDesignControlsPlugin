
using System;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Material3.Implementations
{
    public class CustomTimePicker : TimePicker, IBaseMaterialFieldControl
    {
        public TextAlignment HorizontalTextAlignment { get; set; }

        private TimeSpan? customTime;

        public TimeSpan? CustomTime
        {
            get { return this.customTime; }
            set
            {
                this.customTime = value;
                if (this.customTime.HasValue)
                {
                    base.Time = this.customTime.Value;
                    EmptyTime = false;
                }
                else
                    EmptyTime = true;
            }
        }

        public TimeSpan InternalTime
        {
            get { return base.Time; }
        }

        public string Placeholder { get; set; }

        public Color PlaceholderColor { get; set; }

        public static readonly BindableProperty EmptyTimeProperty =
            BindableProperty.Create(nameof(EmptyTime), typeof(bool), typeof(CustomTimePicker), defaultValue: true);

        public bool EmptyTime
        {
            get { return (bool)GetValue(EmptyTimeProperty); }
            set { SetValue(EmptyTimeProperty, value); }
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

        public bool ValidateIfAnimatePlaceHolder() 
            => this.IsEnabled && !this.CustomTime.HasValue;
    }
}
