using System;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Implementations
{
    public class CustomDatePicker : DatePicker
    {
        public TextAlignment HorizontalTextAlignment { get; set; }

        public new DateTime? Date { get; set; }

        public string Placeholder { get; set; }

        public Color PlaceholderColor { get; set; }
    }
}
