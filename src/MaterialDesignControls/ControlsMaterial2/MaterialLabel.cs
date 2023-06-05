using Plugin.MaterialDesignControls.Material3;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls
{
    public class MaterialLabel : Label, IBaseMaterialFieldControl
    {
        #region Properties

        public static new readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(MaterialLabel), defaultValue: null, propertyChanged: OnTextChanged);

        public new string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty ToUpperProperty =
            BindableProperty.Create(nameof(ToUpper), typeof(bool), typeof(MaterialLabel), defaultValue: false);

        public bool ToUpper
        {
            get { return (bool)GetValue(ToUpperProperty); }
            set { SetValue(ToUpperProperty, value); }
        }

        #endregion Properties

        #region Methods

        private static void OnTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialLabel)bindable;
            control.ApplyTextProperty();
        }

        private void ApplyTextProperty()
        {
            base.Text = this.ToUpper ? this.Text?.ToUpper() : this.Text;
        }

        public bool IsControlFocused() => false;

        public bool IsControlEnabled() => this.IsEnabled;

        public void SetIsEnabled(bool isEnabled)
        {
            this.IsEnabled = isEnabled;
        }

        public void SetTextColor(Color textColor)
        {
            this.TextColor = textColor;
        }

        public void SetFontSize(double fontSize)
        {
            this.FontSize = FontSize;
        }

        public void SetFontFamily(string fontFamily)
        {
            this.FontFamily = FontFamily;
        }

        public void SetPlaceholder(string placeHolder)
        {
            if (string.IsNullOrEmpty(this.Text))
            {
                this.Text = placeHolder;
            }
        }

        public void SetPlaceholderColor(Color placeHolderColor)
        {
            if (string.IsNullOrEmpty(this.Text))
            {
                this.TextColor = placeHolderColor;
            }
        }

        public void SetHorizontalTextAlignment(TextAlignment horizontalTextAlignment)
        {
            this.HorizontalTextAlignment = horizontalTextAlignment;
        }

        public bool ValidateIfAnimatePlaceHolder() => false;

        public void FocusControl(){   }

        #endregion Methods
    }
}
