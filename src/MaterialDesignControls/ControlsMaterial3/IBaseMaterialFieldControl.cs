using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Material3
{
    public interface IBaseMaterialFieldControl
    {
        public bool IsControlFocused();

        public bool IsControlEnabled();

        public void SetIsEnabled(bool isEnabled);

        public void SetTextColor(Color textColor);

        public void SetFontSize(double fontSize);

        public void SetFontFamily(string fontFamily);

        public void SetPlaceholder(string placeHolder);

        public void SetPlaceholderColor(Color placeHolderColor);

        public void SetHorizontalTextAlignment(TextAlignment horizontalTextAlignment);

        public bool ValidateIfAnimate();
    }
}
