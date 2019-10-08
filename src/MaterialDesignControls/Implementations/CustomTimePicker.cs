using System;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Implementations
{
    public class CustomTimePicker : TimePicker
    {
        public TextAlignment HorizontalTextAlignment { get; set; }

        private TimeSpan? time;

        public new TimeSpan? Time
        {
            get { return this.time; }
            set
            {
                this.time = value;
                if (this.Time.HasValue)
                {
                    base.Time = this.Time.Value;
                }
            }
        }

        public string Placeholder { get; set; }

        public Color PlaceholderColor { get; set; }
    }
}
