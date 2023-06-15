using System;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Implementations
{
    [Obsolete("CustomPicker is deprecated, please use CustomPicker of Material 3 instead.")]
    public class CustomPicker : Picker
    {
        public TextAlignment HorizontalTextAlignment { get; set; }

        public string Placeholder { get; set; }

        public Color PlaceholderColor { get; set; }

        public bool MultilineEnabled { get; set; } = false;

        public int PickerRowHeight { get; set; } = 50;
    }
}
