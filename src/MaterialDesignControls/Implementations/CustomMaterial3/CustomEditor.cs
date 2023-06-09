using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Material3.Implementations
{
    public class CustomEditor : Editor, IBaseMaterialFieldControl
    {
        //public double MaxHeight { get; set; } = 100;

        //protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        //{
        //    var sizeRequest = base.OnMeasure(widthConstraint, heightConstraint);

        //    var newHeight = sizeRequest.Request.Height;
        //    if (newHeight > MaxHeight)
        //        newHeight = MaxHeight;

        //    return new SizeRequest(new Size(sizeRequest.Request.Width, newHeight));
        //}

        public CustomEditor()
        {
            BackgroundColor = Color.Red;
        }

        public void FocusControl()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                _ = Focus();
            });
        }

        public bool IsControlEnabled() => this.IsEnabled;

        public bool IsControlFocused() => this.IsFocused;

        public void SetFontFamily(string fontFamily)
        {
            this.FontFamily = fontFamily;
        }

        public void SetFontSize(double fontSize)
        {
            this.FontSize = fontSize;
        }

        public void SetHorizontalTextAlignment(TextAlignment horizontalTextAlignment){  }

        public void SetIsEnabled(bool isEnabled)
        {
            this.IsEnabled = isEnabled;
        }

        public void SetPlaceholder(string placeHolder)
        {
            this.Placeholder = placeHolder;
        }

        public void SetPlaceholderColor(Color placeHolderColor)
        {
            this.PlaceholderColor = placeHolderColor;
        }

        public void SetTextColor(Color textColor)
        {
            this.TextColor = textColor;
        }

        public bool ValidateIfAnimatePlaceHolder() =>
            this.IsEnabled && string.IsNullOrEmpty(this.Text);
    }
}
