using System;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Implementations
{
    [Obsolete("CustomTimePicker is deprecated, please use CustomTimePicker of Material 3 instead.")]
    public class CustomTimePicker : TimePicker
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
    }
}