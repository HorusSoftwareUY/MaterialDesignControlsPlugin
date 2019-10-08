using System;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Implementations
{
    public class CustomDatePicker : DatePicker
    {
        public TextAlignment HorizontalTextAlignment { get; set; }

        private DateTime? date;

        public new DateTime? Date
        {
            get { return this.date; }
            set
            {
                this.date = value;
                if (this.Date.HasValue)
                {
                    base.Date = this.Date.Value;
                }
            }
        }

        public string Placeholder { get; set; }

        public Color PlaceholderColor { get; set; }
    }
}
