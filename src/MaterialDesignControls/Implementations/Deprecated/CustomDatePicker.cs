using System;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Implementations
{
    public class CustomDatePicker : DatePicker
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
    }
}