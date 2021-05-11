using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Implementations
{
    public class CustomPicker : Picker
    {
        public TextAlignment HorizontalTextAlignment { get; set; }

        public string Placeholder { get; set; }

        public Color PlaceholderColor { get; set; }

        public bool MultilineEnabled { get; set; } = false;

        public int PickerRowHeight { get; set; } = 50;

    }
}
