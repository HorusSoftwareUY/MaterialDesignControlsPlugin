using System;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Implementations
{
    public class CustomTimePicker : TimePicker
    {
        public TextAlignment HorizontalTextAlignment { get; set; }

        public new TimeSpan? Time { get; set; }
        
        public string Placeholder { get; set; }

        public Color PlaceholderColor { get; set; }
    }
}
