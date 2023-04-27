using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.ControlsMaterial3
{
    public interface IBaseMaterialFieldControl
    {
        public bool IsControlFocused();

        public bool IsControlEnabled();

        public Color BackgroundColorControl();

        public void SetIsEnabled();

        public void SetTextColor(Color focusedTextColor, Color textColor, Color disabledTextColor);

        public void SetFontSize();

        public void SetFontFamily();

        public void SetPlaceholder();

        public void SetPlaceholderColor();

        public void SetHorizontalTextAlignment();
    }
}
